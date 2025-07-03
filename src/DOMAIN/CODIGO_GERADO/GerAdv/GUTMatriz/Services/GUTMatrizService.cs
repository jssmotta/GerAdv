#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class GUTMatrizService(IOptions<AppSettings> appSettings, IGUTMatrizReader reader, IGUTMatrizValidation validation, IGUTMatrizWriter writer, IGUTTipoReader guttipoReader, IGUTAtividadesMatrizService gutatividadesmatrizService, HybridCache cache, IMemoryCache memory) : IGUTMatrizService, IDisposable
{
    private readonly IOptions<AppSettings> _appSettings = appSettings;
    private readonly HybridCache _cache = cache;
    private readonly IMemoryCache _memoryCache = memory;
    private bool _disposed;
    public async Task<IEnumerable<GUTMatrizResponseAll>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("GUTMatriz: URI inválida");
            }
        }

        var cacheKey = $"{uri}-GUTMatriz-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, string.Empty, [], uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<GUTMatrizResponseAll>> GetDataAllAsync(int max, string where, List<SqlParameter> parameters, string uri, CancellationToken token)
    {
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        if (oCnn == null)
        {
            throw new Exception("Conexão nula.");
        }

        var query = $@"SELECT TOP ({max})
                   {DBGUTMatriz.SensivelCamposSqlX}, [GUTTipo].[gttNome]
                   FROM {DBGUTMatriz.PTabelaNome.dbo(oCnn)} (NOLOCK)
                   LEFT JOIN {"GUTTipo".dbo(oCnn)} (NOLOCK) ON [GUTTipo].[gttCodigo]=[GUTMatriz].[gutGUTTipo]
 
                   {where}
                   ORDER BY [GUTMatriz].[gutDescricao]
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var lista = new List<GUTMatrizResponseAll>(max);
        var ds = await ConfiguracoesDBT.GetDataTable2Async(query, parameters, oCnn);
        if (ds != null)
            foreach (DataRow item in ds.Rows)
            {
                var dbRec = new DBGUTMatriz(item);
                if (dbRec.ID.IsEmptyIDNumber())
                {
                    continue;
                }

                var gutmatriz = reader.ReadAll(dbRec, item);
                if (gutmatriz != null)
                {
                    lista.Add(gutmatriz);
                }
            }

        return lista;
    }

    public async Task<IEnumerable<GUTMatrizResponseAll>> Filter(Filters.FilterGUTMatriz filtro, [FromRoute, Required] string uri)
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
        var cacheKey = $"{uri}-GUTMatriz-Filter-{where.GetHashCode()}{parameters.GetHashCode()}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(BaseConsts.PMaxItens, string.IsNullOrEmpty(where) ? string.Empty : TSql.Where + where, parameters, uri, cancel), entryOptions, cancellationToken: new());
    }

    public async Task<GUTMatrizResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (id < 1)
        {
            return new GUTMatrizResponse();
        }

        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxSecondsCacheId)
        };
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        try
        {
            var result = await _cache.GetOrCreateAsync($"{uri}-GUTMatriz-GetById-{id}", async cancel => await GetDataByIdAsync(id, oCnn, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"GUTMatriz - {uri}-: GetById");
        }
    }

    private async Task<GUTMatrizResponse?> GetDataByIdAsync(int id, MsiSqlConnection oCnn, CancellationToken token) => await Task.Run(() => reader.Read(id, oCnn));
    public async Task<GUTMatrizResponse?> AddAndUpdate([FromBody] Models.GUTMatriz regGUTMatriz, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("GUTMatriz: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regGUTMatriz == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regGUTMatriz, this, guttipoReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            var saved = writer.Write(regGUTMatriz, oCnn);
            return reader.Read(saved.ID, oCnn);
        });
    }

    public async Task<GUTMatrizResponse?> Validation([FromBody] Models.GUTMatriz regGUTMatriz, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("GUTMatriz: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regGUTMatriz == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regGUTMatriz, this, guttipoReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            if (regGUTMatriz.Id.IsEmptyIDNumber())
            {
                return new GUTMatrizResponse();
            }

            return reader.Read(regGUTMatriz.Id, oCnn);
        });
    }

    public async Task<GUTMatrizResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("GUTMatriz: URI inválida");
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

            var deleteValidation = await validation.CanDelete(id, this, gutatividadesmatrizService, uri, oCnn);
            if (deleteValidation.Length > 0)
            {
                throw new Exception(deleteValidation);
            }

            var gutmatriz = reader.Read(id, oCnn);
            try
            {
                if (gutmatriz != null)
                {
                    writer.Delete(gutmatriz, 0, oCnn);
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

            return gutmatriz;
        });
    }

    public async Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterGUTMatriz? filtro, [FromRoute, Required] string uri, CancellationToken token)
    {
        // Tracking: 20250606-1
        ThrowIfDisposed();
        var filtroResult = filtro == null ? null : WFiltro(filtro!);
        string where = filtroResult?.where ?? string.Empty;
        List<SqlParameter> parameters = filtroResult?.parametros ?? [];
        var cacheKey = $"{uri}-GUTMatriz-{max}-{where.GetHashCode()}-{parameters.GetHashCode()}GetListN";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataListNAsync(max, uri, where, parameters, cancel), entryOptions, cancellationToken: token) ?? [];
    }

    private async Task<IEnumerable<NomeID>> GetDataListNAsync(int max, string uri, string where, List<SqlParameter> parameters, CancellationToken token)
    {
        return await Task.Run(() =>
        {
            var result = new List<NomeID>(max);
            foreach (var item in reader.ListarN(max, uri, where, parameters, DBGUTMatrizDicInfo.CampoNome))
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

    private static (string where, List<SqlParameter> parametros)? WFiltro(Filters.FilterGUTMatriz filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var parameters = new List<SqlParameter>();
        if (!string.IsNullOrEmpty(filtro.Descricao))
        {
            parameters.Add(new($"@{nameof(DBGUTMatrizDicInfo.Descricao)}", filtro.Descricao));
        }

        if (filtro.GUTTipo != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBGUTMatrizDicInfo.GUTTipo)}", filtro.GUTTipo));
        }

        if (filtro.Valor != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBGUTMatrizDicInfo.Valor)}", filtro.Valor));
        }

        var cWhere = filtro.Descricao.IsEmpty() ? string.Empty : $"{DBGUTMatrizDicInfo.Descricao} = @{nameof(DBGUTMatrizDicInfo.Descricao)}";
        cWhere += filtro.GUTTipo == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBGUTMatrizDicInfo.GUTTipo} = @{nameof(DBGUTMatrizDicInfo.GUTTipo)}";
        cWhere += filtro.Valor == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBGUTMatrizDicInfo.Valor} = @{nameof(DBGUTMatrizDicInfo.Valor)}";
        return (cWhere, parameters);
    }
}