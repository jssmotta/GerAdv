#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class NECompromissosService(IOptions<AppSettings> appSettings, INECompromissosReader reader, INECompromissosValidation validation, INECompromissosWriter writer, ITipoCompromissoReader tipocompromissoReader, IHttpContextAccessor httpContextAccessor, HybridCache cache, IMemoryCache memory) : INECompromissosService, IDisposable
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly IOptions<AppSettings> _appSettings = appSettings;
    private readonly HybridCache _cache = cache;
    private readonly IMemoryCache _memoryCache = memory;
    private bool _disposed;
    public async Task<IEnumerable<NECompromissosResponseAll>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("NECompromissos: URI inválida");
            }
        }

        var cacheKey = $"{uri}-NECompromissos-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, string.Empty, [], uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<NECompromissosResponseAll>> GetDataAllAsync(int max, string where, List<SqlParameter> parameters, string uri, CancellationToken token)
    {
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        if (oCnn == null)
        {
            throw new Exception("Conexão nula.");
        }

        var query = $@"SELECT TOP ({max})
                   {DBNECompromissos.SensivelCamposSqlX}, [TipoCompromisso].[tipDescricao]
                   FROM {DBNECompromissos.PTabelaNome.dbo(oCnn)} (NOLOCK)
                   LEFT JOIN {"TipoCompromisso".dbo(oCnn)} (NOLOCK) ON [TipoCompromisso].[tipCodigo]=[NECompromissos].[ncpTipoCompromisso]
 
                   {where}
                   ORDER BY [NECompromissos].[]
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var lista = new List<NECompromissosResponseAll>(max);
        var ds = await ConfiguracoesDBT.GetDataTable2Async(query, parameters, oCnn);
        if (ds != null)
            foreach (DataRow item in ds.Rows)
            {
                var dbRec = new DBNECompromissos(item);
                if (dbRec.ID.IsEmptyIDNumber())
                {
                    continue;
                }

                var necompromissos = reader.ReadAll(dbRec, item);
                if (necompromissos != null)
                {
                    lista.Add(necompromissos);
                }
            }

        return lista;
    }

    public async Task<IEnumerable<NECompromissosResponseAll>> Filter(Filters.FilterNECompromissos filtro, [FromRoute, Required] string uri)
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
        var cacheKey = $"{uri}-NECompromissos-Filter-{where.GetHashCode()}{parameters.GetHashCode()}{keyCache}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(BaseConsts.PMaxItens, string.IsNullOrEmpty(where) ? string.Empty : TSql.Where + where, parameters, uri, cancel), entryOptions, cancellationToken: new());
    }

    public async Task<NECompromissosResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (id < 1)
        {
            return new NECompromissosResponse();
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
            var result = await _cache.GetOrCreateAsync($"{uri}-NECompromissos-GetById-{id}-{keyCache}", async cancel => await GetDataByIdAsync(id, oCnn, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"NECompromissos - {uri}-: GetById");
        }
    }

    private async Task<NECompromissosResponse?> GetDataByIdAsync(int id, MsiSqlConnection oCnn, CancellationToken token) => await Task.Run(() => reader.Read(id, oCnn));
    public async Task<NECompromissosResponse?> AddAndUpdate([FromBody] Models.NECompromissos regNECompromissos, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("NECompromissos: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regNECompromissos == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regNECompromissos, this, tipocompromissoReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            var saved = writer.Write(regNECompromissos, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
            return reader.Read(saved, oCnn);
        });
    }

    public async Task<NECompromissosResponse?> Validation([FromBody] Models.NECompromissos regNECompromissos, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("NECompromissos: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regNECompromissos == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regNECompromissos, this, tipocompromissoReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            if (regNECompromissos.Id.IsEmptyIDNumber())
            {
                return new NECompromissosResponse();
            }

            return reader.Read(regNECompromissos.Id, oCnn);
        });
    }

    public async Task<NECompromissosResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("NECompromissos: URI inválida");
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

            var necompromissos = reader.Read(id, oCnn);
            try
            {
                if (necompromissos != null)
                {
                    writer.Delete(necompromissos, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
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

            return necompromissos;
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

    private static (string where, List<SqlParameter> parametros)? WFiltro(Filters.FilterNECompromissos filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var parameters = new List<SqlParameter>();
        if (filtro.PalavraChave != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBNECompromissosDicInfo.PalavraChave)}", filtro.PalavraChave));
        }

        if (filtro.TipoCompromisso != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBNECompromissosDicInfo.TipoCompromisso)}", filtro.TipoCompromisso));
        }

        if (!string.IsNullOrEmpty(filtro.TextoCompromisso))
        {
            parameters.Add(new($"@{nameof(DBNECompromissosDicInfo.TextoCompromisso)}", filtro.TextoCompromisso));
        }

        var cWhere = filtro.PalavraChave == int.MinValue ? string.Empty : $"{DBNECompromissosDicInfo.PalavraChave} = @{nameof(DBNECompromissosDicInfo.PalavraChave)}";
        cWhere += filtro.TipoCompromisso == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBNECompromissosDicInfo.TipoCompromisso} = @{nameof(DBNECompromissosDicInfo.TipoCompromisso)}";
        cWhere += filtro.TextoCompromisso.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBNECompromissosDicInfo.TextoCompromisso} = @{nameof(DBNECompromissosDicInfo.TextoCompromisso)}";
        return (cWhere, parameters);
    }
}