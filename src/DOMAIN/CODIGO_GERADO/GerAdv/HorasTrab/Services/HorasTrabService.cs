#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class HorasTrabService(IOptions<AppSettings> appSettings, IHorasTrabReader reader, IHorasTrabValidation validation, IHorasTrabWriter writer, IClientesReader clientesReader, IProcessosReader processosReader, IAdvogadosReader advogadosReader, IFuncionariosReader funcionariosReader, IServicosReader servicosReader, IHttpContextAccessor httpContextAccessor, HybridCache cache, IMemoryCache memory) : IHorasTrabService, IDisposable
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly IOptions<AppSettings> _appSettings = appSettings;
    private readonly HybridCache _cache = cache;
    private readonly IMemoryCache _memoryCache = memory;
    private bool _disposed;
    public async Task<IEnumerable<HorasTrabResponseAll>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("HorasTrab: URI inválida");
            }
        }

        var cacheKey = $"{uri}-HorasTrab-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, string.Empty, [], uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<HorasTrabResponseAll>> GetDataAllAsync(int max, string where, List<SqlParameter> parameters, string uri, CancellationToken token)
    {
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        if (oCnn == null)
        {
            throw new Exception("Conexão nula.");
        }

        var query = $@"SELECT TOP ({max})
                   {DBHorasTrab.SensivelCamposSqlX}, [Clientes].[cliNome],[Processos].[proNroPasta],[Advogados].[advNome],[Funcionarios].[funNome],[Servicos].[serDescricao]
                   FROM {DBHorasTrab.PTabelaNome.dbo(oCnn)} (NOLOCK)
                   LEFT JOIN {"Clientes".dbo(oCnn)} (NOLOCK) ON [Clientes].[cliCodigo]=[HorasTrab].[htbCliente]
LEFT JOIN {"Processos".dbo(oCnn)} (NOLOCK) ON [Processos].[proCodigo]=[HorasTrab].[htbProcesso]
LEFT JOIN {"Advogados".dbo(oCnn)} (NOLOCK) ON [Advogados].[advCodigo]=[HorasTrab].[htbAdvogado]
LEFT JOIN {"Funcionarios".dbo(oCnn)} (NOLOCK) ON [Funcionarios].[funCodigo]=[HorasTrab].[htbFuncionario]
LEFT JOIN {"Servicos".dbo(oCnn)} (NOLOCK) ON [Servicos].[serCodigo]=[HorasTrab].[htbServico]
 
                   {where}
                   ORDER BY [HorasTrab].[]
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var lista = new List<HorasTrabResponseAll>(max);
        var ds = await ConfiguracoesDBT.GetDataTable2Async(query, parameters, oCnn);
        if (ds != null)
            foreach (DataRow item in ds.Rows)
            {
                var dbRec = new DBHorasTrab(item);
                if (dbRec.ID.IsEmptyIDNumber())
                {
                    continue;
                }

                var horastrab = reader.ReadAll(dbRec, item);
                if (horastrab != null)
                {
                    lista.Add(horastrab);
                }
            }

        return lista;
    }

    public async Task<IEnumerable<HorasTrabResponseAll>> Filter(Filters.FilterHorasTrab filtro, [FromRoute, Required] string uri)
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
        var cacheKey = $"{uri}-HorasTrab-Filter-{where.GetHashCode()}{parameters.GetHashCode()}{keyCache}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(BaseConsts.PMaxItens, string.IsNullOrEmpty(where) ? string.Empty : TSql.Where + where, parameters, uri, cancel), entryOptions, cancellationToken: new());
    }

    public async Task<HorasTrabResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (id < 1)
        {
            return new HorasTrabResponse();
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
            var result = await _cache.GetOrCreateAsync($"{uri}-HorasTrab-GetById-{id}-{keyCache}", async cancel => await GetDataByIdAsync(id, oCnn, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"HorasTrab - {uri}-: GetById");
        }
    }

    private async Task<HorasTrabResponse?> GetDataByIdAsync(int id, MsiSqlConnection oCnn, CancellationToken token) => await Task.Run(() => reader.Read(id, oCnn));
    public async Task<HorasTrabResponse?> AddAndUpdate([FromBody] Models.HorasTrab regHorasTrab, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("HorasTrab: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regHorasTrab == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regHorasTrab, this, clientesReader, processosReader, advogadosReader, funcionariosReader, servicosReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            var saved = writer.Write(regHorasTrab, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
            return reader.Read(saved, oCnn);
        });
    }

    public async Task<HorasTrabResponse?> Validation([FromBody] Models.HorasTrab regHorasTrab, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("HorasTrab: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regHorasTrab == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regHorasTrab, this, clientesReader, processosReader, advogadosReader, funcionariosReader, servicosReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            if (regHorasTrab.Id.IsEmptyIDNumber())
            {
                return new HorasTrabResponse();
            }

            return reader.Read(regHorasTrab.Id, oCnn);
        });
    }

    public async Task<HorasTrabResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("HorasTrab: URI inválida");
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

            var horastrab = reader.Read(id, oCnn);
            try
            {
                if (horastrab != null)
                {
                    writer.Delete(horastrab, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
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

            return horastrab;
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

    private static (string where, List<SqlParameter> parametros)? WFiltro(Filters.FilterHorasTrab filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var parameters = new List<SqlParameter>();
        if (filtro.IDContatoCRM != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBHorasTrabDicInfo.IDContatoCRM)}", filtro.IDContatoCRM));
        }

        if (filtro.IDAgenda != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBHorasTrabDicInfo.IDAgenda)}", filtro.IDAgenda));
        }

        if (filtro.Cliente != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBHorasTrabDicInfo.Cliente)}", filtro.Cliente));
        }

        if (filtro.Status != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBHorasTrabDicInfo.Status)}", filtro.Status));
        }

        if (filtro.Processo != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBHorasTrabDicInfo.Processo)}", filtro.Processo));
        }

        if (filtro.Advogado != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBHorasTrabDicInfo.Advogado)}", filtro.Advogado));
        }

        if (filtro.Funcionario != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBHorasTrabDicInfo.Funcionario)}", filtro.Funcionario));
        }

        if (!string.IsNullOrEmpty(filtro.HrIni))
        {
            parameters.Add(new($"@{nameof(DBHorasTrabDicInfo.HrIni)}", filtro.HrIni));
        }

        if (!string.IsNullOrEmpty(filtro.HrFim))
        {
            parameters.Add(new($"@{nameof(DBHorasTrabDicInfo.HrFim)}", filtro.HrFim));
        }

        if (!string.IsNullOrEmpty(filtro.OBS))
        {
            parameters.Add(new($"@{nameof(DBHorasTrabDicInfo.OBS)}", filtro.OBS));
        }

        if (!string.IsNullOrEmpty(filtro.Anexo))
        {
            parameters.Add(new($"@{nameof(DBHorasTrabDicInfo.Anexo)}", filtro.Anexo));
        }

        if (!string.IsNullOrEmpty(filtro.AnexoComp))
        {
            parameters.Add(new($"@{nameof(DBHorasTrabDicInfo.AnexoComp)}", filtro.AnexoComp));
        }

        if (!string.IsNullOrEmpty(filtro.AnexoUNC))
        {
            parameters.Add(new($"@{nameof(DBHorasTrabDicInfo.AnexoUNC)}", filtro.AnexoUNC));
        }

        if (filtro.Servico != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBHorasTrabDicInfo.Servico)}", filtro.Servico));
        }

        if (!string.IsNullOrEmpty(filtro.GUID))
        {
            parameters.Add(new($"@{nameof(DBHorasTrabDicInfo.GUID)}", filtro.GUID));
        }

        var cWhere = filtro.IDContatoCRM == int.MinValue ? string.Empty : $"{DBHorasTrabDicInfo.IDContatoCRM} = @{nameof(DBHorasTrabDicInfo.IDContatoCRM)}";
        cWhere += filtro.IDAgenda == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBHorasTrabDicInfo.IDAgenda} = @{nameof(DBHorasTrabDicInfo.IDAgenda)}";
        cWhere += filtro.Cliente == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBHorasTrabDicInfo.Cliente} = @{nameof(DBHorasTrabDicInfo.Cliente)}";
        cWhere += filtro.Status == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBHorasTrabDicInfo.Status} = @{nameof(DBHorasTrabDicInfo.Status)}";
        cWhere += filtro.Processo == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBHorasTrabDicInfo.Processo} = @{nameof(DBHorasTrabDicInfo.Processo)}";
        cWhere += filtro.Advogado == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBHorasTrabDicInfo.Advogado} = @{nameof(DBHorasTrabDicInfo.Advogado)}";
        cWhere += filtro.Funcionario == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBHorasTrabDicInfo.Funcionario} = @{nameof(DBHorasTrabDicInfo.Funcionario)}";
        cWhere += filtro.HrIni.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBHorasTrabDicInfo.HrIni} = @{nameof(DBHorasTrabDicInfo.HrIni)}";
        cWhere += filtro.HrFim.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBHorasTrabDicInfo.HrFim} = @{nameof(DBHorasTrabDicInfo.HrFim)}";
        cWhere += filtro.OBS.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBHorasTrabDicInfo.OBS} = @{nameof(DBHorasTrabDicInfo.OBS)}";
        cWhere += filtro.Anexo.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBHorasTrabDicInfo.Anexo} = @{nameof(DBHorasTrabDicInfo.Anexo)}";
        cWhere += filtro.AnexoComp.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBHorasTrabDicInfo.AnexoComp} = @{nameof(DBHorasTrabDicInfo.AnexoComp)}";
        cWhere += filtro.AnexoUNC.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBHorasTrabDicInfo.AnexoUNC} = @{nameof(DBHorasTrabDicInfo.AnexoUNC)}";
        cWhere += filtro.Servico == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBHorasTrabDicInfo.Servico} = @{nameof(DBHorasTrabDicInfo.Servico)}";
        cWhere += filtro.GUID.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBHorasTrabDicInfo.GUID} = @{nameof(DBHorasTrabDicInfo.GUID)}";
        return (cWhere, parameters);
    }
}