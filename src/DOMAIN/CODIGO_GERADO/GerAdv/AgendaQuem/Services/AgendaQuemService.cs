#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class AgendaQuemService(IOptions<AppSettings> appSettings, IAgendaQuemReader reader, IAgendaQuemValidation validation, IAgendaQuemWriter writer, IAdvogadosReader advogadosReader, IFuncionariosReader funcionariosReader, IPrepostosReader prepostosReader, HybridCache cache, IMemoryCache memory) : IAgendaQuemService, IDisposable
{
    private readonly IOptions<AppSettings> _appSettings = appSettings;
    private readonly HybridCache _cache = cache;
    private readonly IMemoryCache _memoryCache = memory;
    private bool _disposed;
    public async Task<IEnumerable<AgendaQuemResponseAll>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("AgendaQuem: URI inválida");
            }
        }

        var cacheKey = $"{uri}-AgendaQuem-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, string.Empty, [], uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<AgendaQuemResponseAll>> GetDataAllAsync(int max, string where, List<SqlParameter> parameters, string uri, CancellationToken token)
    {
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        if (oCnn == null)
        {
            throw new Exception("Conexão nula.");
        }

        var query = $@"SELECT TOP ({max})
                   {DBAgendaQuem.SensivelCamposSqlX}, [Advogados].[advNome],[Funcionarios].[funNome],[Prepostos].[preNome]
                   FROM {DBAgendaQuem.PTabelaNome.dbo(oCnn)} (NOLOCK)
                   LEFT JOIN {"Advogados".dbo(oCnn)} (NOLOCK) ON [Advogados].[advCodigo]=[AgendaQuem].[agqAdvogado]
LEFT JOIN {"Funcionarios".dbo(oCnn)} (NOLOCK) ON [Funcionarios].[funCodigo]=[AgendaQuem].[agqFuncionario]
LEFT JOIN {"Prepostos".dbo(oCnn)} (NOLOCK) ON [Prepostos].[preCodigo]=[AgendaQuem].[agqPreposto]
 
                   {where}
                   ORDER BY [AgendaQuem].[]
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var lista = new List<AgendaQuemResponseAll>(max);
        var ds = await ConfiguracoesDBT.GetDataTable2Async(query, parameters, oCnn);
        if (ds != null)
            foreach (DataRow item in ds.Rows)
            {
                var dbRec = new DBAgendaQuem(item);
                if (dbRec.ID.IsEmptyIDNumber())
                {
                    continue;
                }

                var agendaquem = reader.ReadAll(dbRec, item);
                if (agendaquem != null)
                {
                    lista.Add(agendaquem);
                }
            }

        return lista;
    }

    public async Task<IEnumerable<AgendaQuemResponseAll>> Filter(Filters.FilterAgendaQuem filtro, [FromRoute, Required] string uri)
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
        var cacheKey = $"{uri}-AgendaQuem-Filter-{where.GetHashCode()}{parameters.GetHashCode()}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(BaseConsts.PMaxItens, string.IsNullOrEmpty(where) ? string.Empty : TSql.Where + where, parameters, uri, cancel), entryOptions, cancellationToken: new());
    }

    public async Task<AgendaQuemResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (id < 1)
        {
            return new AgendaQuemResponse();
        }

        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxSecondsCacheId)
        };
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        try
        {
            var result = await _cache.GetOrCreateAsync($"{uri}-AgendaQuem-GetById-{id}", async cancel => await GetDataByIdAsync(id, oCnn, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"AgendaQuem - {uri}-: GetById");
        }
    }

    private async Task<AgendaQuemResponse?> GetDataByIdAsync(int id, MsiSqlConnection oCnn, CancellationToken token) => await Task.Run(() => reader.Read(id, oCnn));
    public async Task<AgendaQuemResponse?> AddAndUpdate([FromBody] Models.AgendaQuem regAgendaQuem, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("AgendaQuem: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regAgendaQuem == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regAgendaQuem, this, advogadosReader, funcionariosReader, prepostosReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            var saved = writer.Write(regAgendaQuem, oCnn);
            return reader.Read(saved.ID, oCnn);
        });
    }

    public async Task<AgendaQuemResponse?> Validation([FromBody] Models.AgendaQuem regAgendaQuem, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("AgendaQuem: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regAgendaQuem == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regAgendaQuem, this, advogadosReader, funcionariosReader, prepostosReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            if (regAgendaQuem.Id.IsEmptyIDNumber())
            {
                return new AgendaQuemResponse();
            }

            return reader.Read(regAgendaQuem.Id, oCnn);
        });
    }

    public async Task<AgendaQuemResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("AgendaQuem: URI inválida");
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

            var agendaquem = reader.Read(id, oCnn);
            try
            {
                if (agendaquem != null)
                {
                    writer.Delete(agendaquem, 0, oCnn);
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

            return agendaquem;
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

    private static (string where, List<SqlParameter> parametros)? WFiltro(Filters.FilterAgendaQuem filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var parameters = new List<SqlParameter>();
        if (filtro.IDAgenda != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaQuemDicInfo.IDAgenda)}", filtro.IDAgenda));
        }

        if (filtro.Advogado != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaQuemDicInfo.Advogado)}", filtro.Advogado));
        }

        if (filtro.Funcionario != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaQuemDicInfo.Funcionario)}", filtro.Funcionario));
        }

        if (filtro.Preposto != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaQuemDicInfo.Preposto)}", filtro.Preposto));
        }

        var cWhere = filtro.IDAgenda == int.MinValue ? string.Empty : $"{DBAgendaQuemDicInfo.IDAgenda} = @{nameof(DBAgendaQuemDicInfo.IDAgenda)}";
        cWhere += filtro.Advogado == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaQuemDicInfo.Advogado} = @{nameof(DBAgendaQuemDicInfo.Advogado)}";
        cWhere += filtro.Funcionario == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaQuemDicInfo.Funcionario} = @{nameof(DBAgendaQuemDicInfo.Funcionario)}";
        cWhere += filtro.Preposto == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaQuemDicInfo.Preposto} = @{nameof(DBAgendaQuemDicInfo.Preposto)}";
        return (cWhere, parameters);
    }
}