#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class OperadorGrupoService(IOptions<AppSettings> appSettings, IOperadorGrupoReader reader, IOperadorGrupoValidation validation, IOperadorGrupoWriter writer, IOperadorReader operadorReader, IHttpContextAccessor httpContextAccessor, HybridCache cache, IMemoryCache memory) : IOperadorGrupoService, IDisposable
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly IOptions<AppSettings> _appSettings = appSettings;
    private readonly HybridCache _cache = cache;
    private readonly IMemoryCache _memoryCache = memory;
    private bool _disposed;
    public async Task<IEnumerable<OperadorGrupoResponseAll>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("OperadorGrupo: URI inválida");
            }
        }

        var cacheKey = $"{uri}-OperadorGrupo-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, string.Empty, [], uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<OperadorGrupoResponseAll>> GetDataAllAsync(int max, string where, List<SqlParameter> parameters, string uri, CancellationToken token)
    {
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        if (oCnn == null)
        {
            throw new Exception("Conexão nula.");
        }

        var query = $@"SELECT TOP ({max})
                   {DBOperadorGrupo.SensivelCamposSqlX}, [Operador].[operNome]
                   FROM {DBOperadorGrupo.PTabelaNome.dbo(oCnn)} (NOLOCK)
                   LEFT JOIN {"Operador".dbo(oCnn)} (NOLOCK) ON [Operador].[operCodigo]=[OperadorGrupo].[ogrOperador]
 
                   {where}
                   ORDER BY [OperadorGrupo].[]
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var lista = new List<OperadorGrupoResponseAll>(max);
        var ds = await ConfiguracoesDBT.GetDataTable2Async(query, parameters, oCnn);
        if (ds != null)
            foreach (DataRow item in ds.Rows)
            {
                var dbRec = new DBOperadorGrupo(item);
                if (dbRec.ID.IsEmptyIDNumber())
                {
                    continue;
                }

                var operadorgrupo = reader.ReadAll(dbRec, item);
                if (operadorgrupo != null)
                {
                    lista.Add(operadorgrupo);
                }
            }

        return lista;
    }

    public async Task<IEnumerable<OperadorGrupoResponseAll>> Filter(Filters.FilterOperadorGrupo filtro, [FromRoute, Required] string uri)
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
        var cacheKey = $"{uri}-OperadorGrupo-Filter-{where.GetHashCode()}{parameters.GetHashCode()}{keyCache}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(BaseConsts.PMaxItens, string.IsNullOrEmpty(where) ? string.Empty : TSql.Where + where, parameters, uri, cancel), entryOptions, cancellationToken: new());
    }

    public async Task<OperadorGrupoResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (id < 1)
        {
            return new OperadorGrupoResponse();
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
            var result = await _cache.GetOrCreateAsync($"{uri}-OperadorGrupo-GetById-{id}-{keyCache}", async cancel => await GetDataByIdAsync(id, oCnn, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"OperadorGrupo - {uri}-: GetById");
        }
    }

    private async Task<OperadorGrupoResponse?> GetDataByIdAsync(int id, MsiSqlConnection oCnn, CancellationToken token) => await Task.Run(() => reader.Read(id, oCnn));
    public async Task<OperadorGrupoResponse?> AddAndUpdate([FromBody] Models.OperadorGrupo regOperadorGrupo, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("OperadorGrupo: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regOperadorGrupo == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regOperadorGrupo, this, operadorReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            var saved = writer.Write(regOperadorGrupo, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
            return reader.Read(saved, oCnn);
        });
    }

    public async Task<OperadorGrupoResponse?> Validation([FromBody] Models.OperadorGrupo regOperadorGrupo, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("OperadorGrupo: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regOperadorGrupo == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regOperadorGrupo, this, operadorReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            if (regOperadorGrupo.Id.IsEmptyIDNumber())
            {
                return new OperadorGrupoResponse();
            }

            return reader.Read(regOperadorGrupo.Id, oCnn);
        });
    }

    public async Task<OperadorGrupoResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("OperadorGrupo: URI inválida");
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

            var operadorgrupo = reader.Read(id, oCnn);
            try
            {
                if (operadorgrupo != null)
                {
                    writer.Delete(operadorgrupo, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
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

            return operadorgrupo;
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

    private static (string where, List<SqlParameter> parametros)? WFiltro(Filters.FilterOperadorGrupo filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var parameters = new List<SqlParameter>();
        if (filtro.Operador != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBOperadorGrupoDicInfo.Operador)}", filtro.Operador));
        }

        if (filtro.Grupo != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBOperadorGrupoDicInfo.Grupo)}", filtro.Grupo));
        }

        var cWhere = filtro.Operador == int.MinValue ? string.Empty : $"{DBOperadorGrupoDicInfo.Operador} = @{nameof(DBOperadorGrupoDicInfo.Operador)}";
        cWhere += filtro.Grupo == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOperadorGrupoDicInfo.Grupo} = @{nameof(DBOperadorGrupoDicInfo.Grupo)}";
        return (cWhere, parameters);
    }
}