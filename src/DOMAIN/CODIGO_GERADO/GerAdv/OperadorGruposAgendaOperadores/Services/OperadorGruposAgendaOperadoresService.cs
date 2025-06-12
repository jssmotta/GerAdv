#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class OperadorGruposAgendaOperadoresService(IOptions<AppSettings> appSettings, IOperadorGruposAgendaOperadoresReader reader, IOperadorGruposAgendaOperadoresValidation validation, IOperadorGruposAgendaOperadoresWriter writer, IOperadorGruposAgendaReader operadorgruposagendaReader, IOperadorReader operadorReader, IHttpContextAccessor httpContextAccessor, HybridCache cache, IMemoryCache memory) : IOperadorGruposAgendaOperadoresService, IDisposable
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly IOptions<AppSettings> _appSettings = appSettings;
    private readonly HybridCache _cache = cache;
    private readonly IMemoryCache _memoryCache = memory;
    private bool _disposed;
    public async Task<IEnumerable<OperadorGruposAgendaOperadoresResponseAll>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("OperadorGruposAgendaOperadores: URI inválida");
            }
        }

        var cacheKey = $"{uri}-OperadorGruposAgendaOperadores-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, string.Empty, [], uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<OperadorGruposAgendaOperadoresResponseAll>> GetDataAllAsync(int max, string where, List<SqlParameter> parameters, string uri, CancellationToken token)
    {
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        if (oCnn == null)
        {
            throw new Exception("Conexão nula.");
        }

        var query = $@"SELECT TOP ({max})
                   {DBOperadorGruposAgendaOperadores.SensivelCamposSqlX}, groNome,operNome
                   FROM {DBOperadorGruposAgendaOperadores.PTabelaNome.dbo(oCnn)} (NOLOCK)
                   LEFT JOIN {"OperadorGruposAgenda".dbo(oCnn)} (NOLOCK) ON groCodigo=ogpOperadorGruposAgenda
LEFT JOIN {"Operador".dbo(oCnn)} (NOLOCK) ON operCodigo=ogpOperador
 
                   {where}
                   ORDER BY 
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var lista = new List<OperadorGruposAgendaOperadoresResponseAll>(max);
        var ds = await ConfiguracoesDBT.GetDataTable2Async(query, parameters, oCnn);
        if (ds != null)
            foreach (DataRow item in ds.Rows)
            {
                var dbRec = new DBOperadorGruposAgendaOperadores(item);
                if (dbRec.ID.IsEmptyIDNumber())
                {
                    continue;
                }

                var operadorgruposagendaoperadores = reader.ReadAll(dbRec, item);
                if (operadorgruposagendaoperadores != null)
                {
                    lista.Add(operadorgruposagendaoperadores);
                }
            }

        return lista;
    }

    public async Task<IEnumerable<OperadorGruposAgendaOperadoresResponseAll>> Filter(Filters.FilterOperadorGruposAgendaOperadores filtro, [FromRoute, Required] string uri)
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
        var cacheKey = $"{uri}-OperadorGruposAgendaOperadores-Filter-{where.GetHashCode()}{parameters.GetHashCode()}{keyCache}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(BaseConsts.PMaxItens, string.IsNullOrEmpty(where) ? string.Empty : TSql.Where + where, parameters, uri, cancel), entryOptions, cancellationToken: new());
    }

    public async Task<OperadorGruposAgendaOperadoresResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (id < 1)
        {
            return new OperadorGruposAgendaOperadoresResponse();
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
            var result = await _cache.GetOrCreateAsync($"{uri}-OperadorGruposAgendaOperadores-GetById-{id}-{keyCache}", async cancel => await GetDataByIdAsync(id, oCnn, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"OperadorGruposAgendaOperadores - {uri}-: GetById");
        }
    }

    private async Task<OperadorGruposAgendaOperadoresResponse?> GetDataByIdAsync(int id, MsiSqlConnection oCnn, CancellationToken token) => await Task.Run(() => reader.Read(id, oCnn));
    public async Task<OperadorGruposAgendaOperadoresResponse?> AddAndUpdate([FromBody] Models.OperadorGruposAgendaOperadores regOperadorGruposAgendaOperadores, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("OperadorGruposAgendaOperadores: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regOperadorGruposAgendaOperadores == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regOperadorGruposAgendaOperadores, this, operadorgruposagendaReader, operadorReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception($"OperadorGruposAgendaOperadores: {validade}");
            }

            var saved = writer.Write(regOperadorGruposAgendaOperadores, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
            return reader.Read(saved.ID, oCnn);
        });
    }

    public async Task<OperadorGruposAgendaOperadoresResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("OperadorGruposAgendaOperadores: URI inválida");
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

            var operadorgruposagendaoperadores = reader.Read(id, oCnn);
            try
            {
                if (operadorgruposagendaoperadores != null)
                {
                    writer.Delete(operadorgruposagendaoperadores, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
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

            return operadorgruposagendaoperadores;
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

    private static (string where, List<SqlParameter> parametros)? WFiltro(Filters.FilterOperadorGruposAgendaOperadores filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var parameters = new List<SqlParameter>();
        if (filtro.OperadorGruposAgenda != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBOperadorGruposAgendaOperadoresDicInfo.OperadorGruposAgenda)}", filtro.OperadorGruposAgenda));
        }

        if (filtro.Operador != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBOperadorGruposAgendaOperadoresDicInfo.Operador)}", filtro.Operador));
        }

        if (!string.IsNullOrEmpty(filtro.GUID))
        {
            parameters.Add(new($"@{nameof(DBOperadorGruposAgendaOperadoresDicInfo.GUID)}", filtro.GUID));
        }

        var cWhere = filtro.OperadorGruposAgenda == int.MinValue ? string.Empty : $"{DBOperadorGruposAgendaOperadoresDicInfo.OperadorGruposAgenda} = @{nameof(DBOperadorGruposAgendaOperadoresDicInfo.OperadorGruposAgenda)}";
        cWhere += filtro.Operador == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOperadorGruposAgendaOperadoresDicInfo.Operador} = @{nameof(DBOperadorGruposAgendaOperadoresDicInfo.Operador)}";
        cWhere += filtro.GUID.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOperadorGruposAgendaOperadoresDicInfo.GUID} = @{nameof(DBOperadorGruposAgendaOperadoresDicInfo.GUID)}";
        return (cWhere, parameters);
    }
}