#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class TipoValorProcessoService(IOptions<AppSettings> appSettings, ITipoValorProcessoReader reader, ITipoValorProcessoValidation validation, ITipoValorProcessoWriter writer, IProValoresService provaloresService, HybridCache cache, IMemoryCache memory) : ITipoValorProcessoService, IDisposable
{
    private readonly IOptions<AppSettings> _appSettings = appSettings;
    private readonly HybridCache _cache = cache;
    private readonly IMemoryCache _memoryCache = memory;
    private bool _disposed;
    public async Task<IEnumerable<TipoValorProcessoResponseAll>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("TipoValorProcesso: URI inválida");
            }
        }

        var cacheKey = $"{uri}-TipoValorProcesso-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, string.Empty, [], uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<TipoValorProcessoResponseAll>> GetDataAllAsync(int max, string where, List<SqlParameter> parameters, string uri, CancellationToken token)
    {
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        if (oCnn == null)
        {
            throw new Exception("Conexão nula.");
        }

        var query = $@"SELECT TOP ({max})
                   {DBTipoValorProcesso.SensivelCamposSqlX}
                   FROM {DBTipoValorProcesso.PTabelaNome.dbo(oCnn)} (NOLOCK)
                    
                   {where}
                   ORDER BY [TipoValorProcesso].[ptvDescricao]
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var lista = new List<TipoValorProcessoResponseAll>(max);
        var ds = await ConfiguracoesDBT.GetDataTable2Async(query, parameters, oCnn);
        if (ds != null)
            foreach (DataRow item in ds.Rows)
            {
                var dbRec = new DBTipoValorProcesso(item);
                if (dbRec.ID.IsEmptyIDNumber())
                {
                    continue;
                }

                var tipovalorprocesso = reader.ReadAll(dbRec, item);
                if (tipovalorprocesso != null)
                {
                    lista.Add(tipovalorprocesso);
                }
            }

        return lista;
    }

    public async Task<IEnumerable<TipoValorProcessoResponseAll>> Filter(Filters.FilterTipoValorProcesso filtro, [FromRoute, Required] string uri)
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
        var cacheKey = $"{uri}-TipoValorProcesso-Filter-{where.GetHashCode()}{parameters.GetHashCode()}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(BaseConsts.PMaxItens, string.IsNullOrEmpty(where) ? string.Empty : TSql.Where + where, parameters, uri, cancel), entryOptions, cancellationToken: new());
    }

    public async Task<TipoValorProcessoResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (id < 1)
        {
            return new TipoValorProcessoResponse();
        }

        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxSecondsCacheId)
        };
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        try
        {
            var result = await _cache.GetOrCreateAsync($"{uri}-TipoValorProcesso-GetById-{id}", async cancel => await GetDataByIdAsync(id, oCnn, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"TipoValorProcesso - {uri}-: GetById");
        }
    }

    private async Task<TipoValorProcessoResponse?> GetDataByIdAsync(int id, MsiSqlConnection oCnn, CancellationToken token) => await Task.Run(() => reader.Read(id, oCnn));
    public async Task<TipoValorProcessoResponse?> AddAndUpdate([FromBody] Models.TipoValorProcesso regTipoValorProcesso, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("TipoValorProcesso: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regTipoValorProcesso == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regTipoValorProcesso, this, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            var saved = writer.Write(regTipoValorProcesso, oCnn);
            return reader.Read(saved, oCnn);
        });
    }

    public async Task<TipoValorProcessoResponse?> Validation([FromBody] Models.TipoValorProcesso regTipoValorProcesso, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("TipoValorProcesso: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regTipoValorProcesso == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regTipoValorProcesso, this, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            if (regTipoValorProcesso.Id.IsEmptyIDNumber())
            {
                return new TipoValorProcessoResponse();
            }

            return reader.Read(regTipoValorProcesso.Id, oCnn);
        });
    }

    public async Task<TipoValorProcessoResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("TipoValorProcesso: URI inválida");
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

            var deleteValidation = await validation.CanDelete(id, this, provaloresService, uri, oCnn);
            if (deleteValidation.Length > 0)
            {
                throw new Exception(deleteValidation);
            }

            var tipovalorprocesso = reader.Read(id, oCnn);
            try
            {
                if (tipovalorprocesso != null)
                {
                    writer.Delete(tipovalorprocesso, 0, oCnn);
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

            return tipovalorprocesso;
        });
    }

    public async Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterTipoValorProcesso? filtro, [FromRoute, Required] string uri, CancellationToken token)
    {
        // Tracking: 20250606-1
        ThrowIfDisposed();
        var filtroResult = filtro == null ? null : WFiltro(filtro!);
        string where = filtroResult?.where ?? string.Empty;
        List<SqlParameter> parameters = filtroResult?.parametros ?? [];
        var cacheKey = $"{uri}-TipoValorProcesso-{max}-{where.GetHashCode()}-{parameters.GetHashCode()}GetListN";
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
            foreach (var item in reader.ListarN(max, uri, where, parameters, DBTipoValorProcessoDicInfo.CampoNome))
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

    private static (string where, List<SqlParameter> parametros)? WFiltro(Filters.FilterTipoValorProcesso filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var parameters = new List<SqlParameter>();
        if (!string.IsNullOrEmpty(filtro.Descricao))
        {
            parameters.Add(new($"@{nameof(DBTipoValorProcessoDicInfo.Descricao)}", filtro.Descricao));
        }

        if (!string.IsNullOrEmpty(filtro.GUID))
        {
            parameters.Add(new($"@{nameof(DBTipoValorProcessoDicInfo.GUID)}", filtro.GUID));
        }

        var cWhere = filtro.Descricao.IsEmpty() ? string.Empty : $"{DBTipoValorProcessoDicInfo.Descricao} = @{nameof(DBTipoValorProcessoDicInfo.Descricao)}";
        cWhere += filtro.GUID.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBTipoValorProcessoDicInfo.GUID} = @{nameof(DBTipoValorProcessoDicInfo.GUID)}";
        return (cWhere, parameters);
    }
}