#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class TipoEnderecoSistemaService(IOptions<AppSettings> appSettings, ITipoEnderecoSistemaReader reader, ITipoEnderecoSistemaValidation validation, ITipoEnderecoSistemaWriter writer, IEnderecoSistemaService enderecosistemaService, IHttpContextAccessor httpContextAccessor, HybridCache cache, IMemoryCache memory) : ITipoEnderecoSistemaService, IDisposable
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly IOptions<AppSettings> _appSettings = appSettings;
    private readonly HybridCache _cache = cache;
    private readonly IMemoryCache _memoryCache = memory;
    private bool _disposed;
    public async Task<IEnumerable<TipoEnderecoSistemaResponseAll>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("TipoEnderecoSistema: URI inválida");
            }
        }

        var cacheKey = $"{uri}-TipoEnderecoSistema-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, string.Empty, [], uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<TipoEnderecoSistemaResponseAll>> GetDataAllAsync(int max, string where, List<SqlParameter> parameters, string uri, CancellationToken token)
    {
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        if (oCnn == null)
        {
            throw new Exception("Conexão nula.");
        }

        var query = $@"SELECT TOP ({max})
                   {DBTipoEnderecoSistema.SensivelCamposSqlX}
                   FROM {DBTipoEnderecoSistema.PTabelaNome.dbo(oCnn)} (NOLOCK)
                    
                   {where}
                   ORDER BY [TipoEnderecoSistema].[tesNome]
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var lista = new List<TipoEnderecoSistemaResponseAll>(max);
        var ds = await ConfiguracoesDBT.GetDataTable2Async(query, parameters, oCnn);
        if (ds != null)
            foreach (DataRow item in ds.Rows)
            {
                var dbRec = new DBTipoEnderecoSistema(item);
                if (dbRec.ID.IsEmptyIDNumber())
                {
                    continue;
                }

                var tipoenderecosistema = reader.ReadAll(dbRec, item);
                if (tipoenderecosistema != null)
                {
                    lista.Add(tipoenderecosistema);
                }
            }

        return lista;
    }

    public async Task<IEnumerable<TipoEnderecoSistemaResponseAll>> Filter(Filters.FilterTipoEnderecoSistema filtro, [FromRoute, Required] string uri)
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
        var cacheKey = $"{uri}-TipoEnderecoSistema-Filter-{where.GetHashCode()}{parameters.GetHashCode()}{keyCache}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(BaseConsts.PMaxItens, string.IsNullOrEmpty(where) ? string.Empty : TSql.Where + where, parameters, uri, cancel), entryOptions, cancellationToken: new());
    }

    public async Task<TipoEnderecoSistemaResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (id < 1)
        {
            return new TipoEnderecoSistemaResponse();
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
            var result = await _cache.GetOrCreateAsync($"{uri}-TipoEnderecoSistema-GetById-{id}-{keyCache}", async cancel => await GetDataByIdAsync(id, oCnn, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"TipoEnderecoSistema - {uri}-: GetById");
        }
    }

    private async Task<TipoEnderecoSistemaResponse?> GetDataByIdAsync(int id, MsiSqlConnection oCnn, CancellationToken token) => await Task.Run(() => reader.Read(id, oCnn));
    public async Task<TipoEnderecoSistemaResponse?> AddAndUpdate([FromBody] Models.TipoEnderecoSistema regTipoEnderecoSistema, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("TipoEnderecoSistema: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regTipoEnderecoSistema == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regTipoEnderecoSistema, this, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            var saved = writer.Write(regTipoEnderecoSistema, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
            return reader.Read(saved, oCnn);
        });
    }

    public async Task<TipoEnderecoSistemaResponse?> Validation([FromBody] Models.TipoEnderecoSistema regTipoEnderecoSistema, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("TipoEnderecoSistema: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regTipoEnderecoSistema == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regTipoEnderecoSistema, this, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            if (regTipoEnderecoSistema.Id.IsEmptyIDNumber())
            {
                return new TipoEnderecoSistemaResponse();
            }

            return reader.Read(regTipoEnderecoSistema.Id, oCnn);
        });
    }

    public async Task<TipoEnderecoSistemaResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("TipoEnderecoSistema: URI inválida");
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

            var deleteValidation = await validation.CanDelete(id, this, enderecosistemaService, uri, oCnn);
            if (deleteValidation.Length > 0)
            {
                throw new Exception(deleteValidation);
            }

            var tipoenderecosistema = reader.Read(id, oCnn);
            try
            {
                if (tipoenderecosistema != null)
                {
                    writer.Delete(tipoenderecosistema, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
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

            return tipoenderecosistema;
        });
    }

    public async Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterTipoEnderecoSistema? filtro, [FromRoute, Required] string uri, CancellationToken token)
    {
        // Tracking: 20250606-0
        ThrowIfDisposed();
        var filtroResult = filtro == null ? null : WFiltro(filtro!);
        string where = filtroResult?.where ?? string.Empty;
        List<SqlParameter> parameters = filtroResult?.parametros ?? [];
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        if (oCnn == null)
        {
            throw new Exception($"Coneão nula.");
        }

        var keyCache = await reader.ReadStringAuditor(uri, "", [], oCnn);
        var cacheKey = $"{uri}-TipoEnderecoSistema-{max}-{where.GetHashCode()}-GetListN-{keyCache}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxSecondsCacheId)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataListNAsync(max, uri, where, parameters, cancel), entryOptions, cancellationToken: token) ?? [];
    }

    private async Task<IEnumerable<NomeID>> GetDataListNAsync(int max, string uri, string where, List<SqlParameter> parameters, CancellationToken token)
    {
        return await Task.Run(() =>
        {
            var result = new List<NomeID>(max);
            foreach (var item in reader.ListarN(max, uri, where, parameters, DBTipoEnderecoSistemaDicInfo.CampoNome))
            {
                if (token.IsCancellationRequested)
                    break;
                if (item?.FNome != null)
                {
                    result.Add(new NomeID { Nome = item.FNome, ID = item.ID });
                }
            }

            return result;
        }, token);
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

    private static (string where, List<SqlParameter> parametros)? WFiltro(Filters.FilterTipoEnderecoSistema filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var parameters = new List<SqlParameter>();
        if (!string.IsNullOrEmpty(filtro.Nome))
        {
            parameters.Add(new($"@{nameof(DBTipoEnderecoSistemaDicInfo.Nome)}", filtro.Nome));
        }

        if (!string.IsNullOrEmpty(filtro.GUID))
        {
            parameters.Add(new($"@{nameof(DBTipoEnderecoSistemaDicInfo.GUID)}", filtro.GUID));
        }

        var cWhere = filtro.Nome.IsEmpty() ? string.Empty : $"{DBTipoEnderecoSistemaDicInfo.Nome} = @{nameof(DBTipoEnderecoSistemaDicInfo.Nome)}";
        cWhere += filtro.GUID.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBTipoEnderecoSistemaDicInfo.GUID} = @{nameof(DBTipoEnderecoSistemaDicInfo.GUID)}";
        return (cWhere, parameters);
    }
}