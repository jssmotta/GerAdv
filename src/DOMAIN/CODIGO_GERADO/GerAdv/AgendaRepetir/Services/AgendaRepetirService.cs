#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class AgendaRepetirService(IOptions<AppSettings> appSettings, IAgendaRepetirReader reader, IAgendaRepetirValidation validation, IAgendaRepetirWriter writer, IAdvogadosReader advogadosReader, IClientesReader clientesReader, IFuncionariosReader funcionariosReader, IProcessosReader processosReader, IHttpContextAccessor httpContextAccessor, HybridCache cache, IMemoryCache memory) : IAgendaRepetirService, IDisposable
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly IOptions<AppSettings> _appSettings = appSettings;
    private readonly HybridCache _cache = cache;
    private readonly IMemoryCache _memoryCache = memory;
    private bool _disposed;
    public async Task<IEnumerable<AgendaRepetirResponseAll>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("AgendaRepetir: URI inválida");
            }
        }

        var cacheKey = $"{uri}-AgendaRepetir-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, string.Empty, [], uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<AgendaRepetirResponseAll>> GetDataAllAsync(int max, string where, List<SqlParameter> parameters, string uri, CancellationToken token)
    {
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        if (oCnn == null)
        {
            throw new Exception("Conexão nula.");
        }

        var query = $@"SELECT TOP ({max})
                   {DBAgendaRepetir.SensivelCamposSqlX}, [Advogados].[advNome],[Clientes].[cliNome],[Funcionarios].[funNome],[Processos].[proNroPasta]
                   FROM {DBAgendaRepetir.PTabelaNome.dbo(oCnn)} (NOLOCK)
                   LEFT JOIN {"Advogados".dbo(oCnn)} (NOLOCK) ON [Advogados].[advCodigo]=[AgendaRepetir].[rptAdvogado]
LEFT JOIN {"Clientes".dbo(oCnn)} (NOLOCK) ON [Clientes].[cliCodigo]=[AgendaRepetir].[rptCliente]
LEFT JOIN {"Funcionarios".dbo(oCnn)} (NOLOCK) ON [Funcionarios].[funCodigo]=[AgendaRepetir].[rptFuncionario]
LEFT JOIN {"Processos".dbo(oCnn)} (NOLOCK) ON [Processos].[proCodigo]=[AgendaRepetir].[rptProcesso]
 
                   {where}
                   ORDER BY [AgendaRepetir].[]
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var lista = new List<AgendaRepetirResponseAll>(max);
        var ds = await ConfiguracoesDBT.GetDataTable2Async(query, parameters, oCnn);
        if (ds != null)
            foreach (DataRow item in ds.Rows)
            {
                var dbRec = new DBAgendaRepetir(item);
                if (dbRec.ID.IsEmptyIDNumber())
                {
                    continue;
                }

                var agendarepetir = reader.ReadAll(dbRec, item);
                if (agendarepetir != null)
                {
                    lista.Add(agendarepetir);
                }
            }

        return lista;
    }

    public async Task<IEnumerable<AgendaRepetirResponseAll>> Filter(Filters.FilterAgendaRepetir filtro, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        if (oCnn == null)
        {
            throw new Exception("Conexão nula.");
        }

        var filtroResult = filtro == null ? null : WFiltro(filtro!);
        string where = filtroResult?.where ?? string.Empty;
        List<SqlParameter> parameters = filtroResult?.parametros ?? [];
        var keyCache = await reader.ReadStringAuditor(uri, where, parameters, oCnn);
        var cacheKey = $"{uri}-AgendaRepetir-Filter-{where.GetHashCode()}{parameters.GetHashCode()}{keyCache}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(BaseConsts.PMaxItens, string.IsNullOrEmpty(where) ? string.Empty : TSql.Where + where, parameters, uri, cancel), entryOptions, cancellationToken: new());
    }

    public async Task<AgendaRepetirResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (id < 1)
        {
            return new AgendaRepetirResponse();
        }

        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxSecondsCacheId)
        };
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        try
        {
            var keyCache = await reader.ReadStringAuditor(id, uri, oCnn);
            var result = await _cache.GetOrCreateAsync($"{uri}-AgendaRepetir-GetById-{id}-{keyCache}", async cancel => await GetDataByIdAsync(id, oCnn, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"AgendaRepetir - {uri}-: GetById");
        }
    }

    private async Task<AgendaRepetirResponse?> GetDataByIdAsync(int id, MsiSqlConnection oCnn, CancellationToken token) => await Task.Run(() => reader.Read(id, oCnn));
    public async Task<AgendaRepetirResponse?> AddAndUpdate([FromBody] Models.AgendaRepetir regAgendaRepetir, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("AgendaRepetir: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regAgendaRepetir == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regAgendaRepetir, this, advogadosReader, clientesReader, funcionariosReader, processosReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            var saved = writer.Write(regAgendaRepetir, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
            return reader.Read(saved, oCnn);
        });
    }

    public async Task<AgendaRepetirResponse?> Validation([FromBody] Models.AgendaRepetir regAgendaRepetir, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("AgendaRepetir: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regAgendaRepetir == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regAgendaRepetir, this, advogadosReader, clientesReader, funcionariosReader, processosReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            if (regAgendaRepetir.Id.IsEmptyIDNumber())
            {
                return new AgendaRepetirResponse();
            }

            return reader.Read(regAgendaRepetir.Id, oCnn);
        });
    }

    public async Task<AgendaRepetirResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("AgendaRepetir: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (id.IsEmptyIDNumber())
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var deleteValidation = await validation.CanDelete(id, this, uri, oCnn);
            if (deleteValidation.Length > 0)
            {
                throw new Exception(deleteValidation);
            }

            var agendarepetir = reader.Read(id, oCnn);
            try
            {
                if (agendarepetir != null)
                {
                    writer.Delete(agendarepetir, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
                    if (_memoryCache is MemoryCache memCache)
                    {
                        memCache.Compact(1.0);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return agendarepetir;
        });
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
            return;
        if (disposing)
        {
        //_cache?.Dispose();
        }

        _disposed = true;
    }

    private void ThrowIfDisposed()
    {
        if (_disposed)
        {
            throw new ObjectDisposedException(GetType().Name);
        }
    }

    private static (string where, List<SqlParameter> parametros)? WFiltro(Filters.FilterAgendaRepetir filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var parameters = new List<SqlParameter>();
        if (filtro.Advogado != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaRepetirDicInfo.Advogado)}", filtro.Advogado));
        }

        if (filtro.Cliente != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaRepetirDicInfo.Cliente)}", filtro.Cliente));
        }

        if (filtro.Funcionario != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaRepetirDicInfo.Funcionario)}", filtro.Funcionario));
        }

        if (filtro.Processo != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaRepetirDicInfo.Processo)}", filtro.Processo));
        }

        if (filtro.Frequencia != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaRepetirDicInfo.Frequencia)}", filtro.Frequencia));
        }

        if (filtro.Dia != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaRepetirDicInfo.Dia)}", filtro.Dia));
        }

        if (filtro.Mes != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaRepetirDicInfo.Mes)}", filtro.Mes));
        }

        if (filtro.IDQuem != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaRepetirDicInfo.IDQuem)}", filtro.IDQuem));
        }

        if (filtro.IDQuem2 != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaRepetirDicInfo.IDQuem2)}", filtro.IDQuem2));
        }

        if (!string.IsNullOrEmpty(filtro.Mensagem))
        {
            parameters.Add(new($"@{nameof(DBAgendaRepetirDicInfo.Mensagem)}", filtro.Mensagem));
        }

        if (filtro.IDTipo != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaRepetirDicInfo.IDTipo)}", filtro.IDTipo));
        }

        if (filtro.ID1 != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaRepetirDicInfo.ID1)}", filtro.ID1));
        }

        if (filtro.ID2 != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaRepetirDicInfo.ID2)}", filtro.ID2));
        }

        if (filtro.ID3 != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaRepetirDicInfo.ID3)}", filtro.ID3));
        }

        if (filtro.ID4 != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaRepetirDicInfo.ID4)}", filtro.ID4));
        }

        var cWhere = filtro.Advogado == int.MinValue ? string.Empty : $"{DBAgendaRepetirDicInfo.Advogado} = @{nameof(DBAgendaRepetirDicInfo.Advogado)}";
        cWhere += filtro.Cliente == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaRepetirDicInfo.Cliente} = @{nameof(DBAgendaRepetirDicInfo.Cliente)}";
        cWhere += filtro.Funcionario == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaRepetirDicInfo.Funcionario} = @{nameof(DBAgendaRepetirDicInfo.Funcionario)}";
        cWhere += filtro.Processo == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaRepetirDicInfo.Processo} = @{nameof(DBAgendaRepetirDicInfo.Processo)}";
        cWhere += filtro.Frequencia == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaRepetirDicInfo.Frequencia} = @{nameof(DBAgendaRepetirDicInfo.Frequencia)}";
        cWhere += filtro.Dia == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaRepetirDicInfo.Dia} = @{nameof(DBAgendaRepetirDicInfo.Dia)}";
        cWhere += filtro.Mes == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaRepetirDicInfo.Mes} = @{nameof(DBAgendaRepetirDicInfo.Mes)}";
        cWhere += filtro.IDQuem == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaRepetirDicInfo.IDQuem} = @{nameof(DBAgendaRepetirDicInfo.IDQuem)}";
        cWhere += filtro.IDQuem2 == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaRepetirDicInfo.IDQuem2} = @{nameof(DBAgendaRepetirDicInfo.IDQuem2)}";
        cWhere += filtro.Mensagem.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaRepetirDicInfo.Mensagem} = @{nameof(DBAgendaRepetirDicInfo.Mensagem)}";
        cWhere += filtro.IDTipo == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaRepetirDicInfo.IDTipo} = @{nameof(DBAgendaRepetirDicInfo.IDTipo)}";
        cWhere += filtro.ID1 == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaRepetirDicInfo.ID1} = @{nameof(DBAgendaRepetirDicInfo.ID1)}";
        cWhere += filtro.ID2 == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaRepetirDicInfo.ID2} = @{nameof(DBAgendaRepetirDicInfo.ID2)}";
        cWhere += filtro.ID3 == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaRepetirDicInfo.ID3} = @{nameof(DBAgendaRepetirDicInfo.ID3)}";
        cWhere += filtro.ID4 == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaRepetirDicInfo.ID4} = @{nameof(DBAgendaRepetirDicInfo.ID4)}";
        return (cWhere, parameters);
    }
}