#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class PontoVirtualService(IOptions<AppSettings> appSettings, IPontoVirtualReader reader, IPontoVirtualValidation validation, IPontoVirtualWriter writer, IOperadorReader operadorReader, HybridCache cache, IMemoryCache memory) : IPontoVirtualService, IDisposable
{
    private readonly IOptions<AppSettings> _appSettings = appSettings;
    private readonly HybridCache _cache = cache;
    private readonly IMemoryCache _memoryCache = memory;
    private bool _disposed;
    public async Task<IEnumerable<PontoVirtualResponseAll>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("PontoVirtual: URI inválida");
            }
        }

        var cacheKey = $"{uri}-PontoVirtual-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, string.Empty, [], uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<PontoVirtualResponseAll>> GetDataAllAsync(int max, string where, List<SqlParameter> parameters, string uri, CancellationToken token)
    {
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        if (oCnn == null)
        {
            throw new Exception("Conexão nula.");
        }

        var query = $@"SELECT TOP ({max})
                   {DBPontoVirtual.SensivelCamposSqlX}, [Operador].[operNome]
                   FROM {DBPontoVirtual.PTabelaNome.dbo(oCnn)} (NOLOCK)
                   LEFT JOIN {"Operador".dbo(oCnn)} (NOLOCK) ON [Operador].[operCodigo]=[PontoVirtual].[pvtOperador]
 
                   {where}
                   ORDER BY [PontoVirtual].[]
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var lista = new List<PontoVirtualResponseAll>(max);
        var ds = await ConfiguracoesDBT.GetDataTable2Async(query, parameters, oCnn);
        if (ds != null)
            foreach (DataRow item in ds.Rows)
            {
                var dbRec = new DBPontoVirtual(item);
                if (dbRec.ID.IsEmptyIDNumber())
                {
                    continue;
                }

                var pontovirtual = reader.ReadAll(dbRec, item);
                if (pontovirtual != null)
                {
                    lista.Add(pontovirtual);
                }
            }

        return lista;
    }

    public async Task<IEnumerable<PontoVirtualResponseAll>> Filter(Filters.FilterPontoVirtual filtro, [FromRoute, Required] string uri)
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
        var cacheKey = $"{uri}-PontoVirtual-Filter-{where.GetHashCode()}{parameters.GetHashCode()}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(BaseConsts.PMaxItens, string.IsNullOrEmpty(where) ? string.Empty : TSql.Where + where, parameters, uri, cancel), entryOptions, cancellationToken: new());
    }

    public async Task<PontoVirtualResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (id < 1)
        {
            return new PontoVirtualResponse();
        }

        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxSecondsCacheId)
        };
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        try
        {
            var result = await _cache.GetOrCreateAsync($"{uri}-PontoVirtual-GetById-{id}", async cancel => await GetDataByIdAsync(id, oCnn, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"PontoVirtual - {uri}-: GetById");
        }
    }

    private async Task<PontoVirtualResponse?> GetDataByIdAsync(int id, MsiSqlConnection oCnn, CancellationToken token) => await Task.Run(() => reader.Read(id, oCnn));
    public async Task<PontoVirtualResponse?> AddAndUpdate([FromBody] Models.PontoVirtual regPontoVirtual, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("PontoVirtual: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regPontoVirtual == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regPontoVirtual, this, operadorReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            var saved = writer.Write(regPontoVirtual, oCnn);
            return reader.Read(saved, oCnn);
        });
    }

    public async Task<PontoVirtualResponse?> Validation([FromBody] Models.PontoVirtual regPontoVirtual, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("PontoVirtual: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regPontoVirtual == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regPontoVirtual, this, operadorReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            if (regPontoVirtual.Id.IsEmptyIDNumber())
            {
                return new PontoVirtualResponse();
            }

            return reader.Read(regPontoVirtual.Id, oCnn);
        });
    }

    public async Task<PontoVirtualResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("PontoVirtual: URI inválida");
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

            var pontovirtual = reader.Read(id, oCnn);
            try
            {
                if (pontovirtual != null)
                {
                    writer.Delete(pontovirtual, 0, oCnn);
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

            return pontovirtual;
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

    private static (string where, List<SqlParameter> parametros)? WFiltro(Filters.FilterPontoVirtual filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var parameters = new List<SqlParameter>();
        if (filtro.Operador != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBPontoVirtualDicInfo.Operador)}", filtro.Operador));
        }

        if (!string.IsNullOrEmpty(filtro.Key))
        {
            parameters.Add(new($"@{nameof(DBPontoVirtualDicInfo.Key)}", filtro.Key));
        }

        var cWhere = filtro.Operador == int.MinValue ? string.Empty : $"{DBPontoVirtualDicInfo.Operador} = @{nameof(DBPontoVirtualDicInfo.Operador)}";
        cWhere += filtro.Key.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBPontoVirtualDicInfo.Key} = @{nameof(DBPontoVirtualDicInfo.Key)}";
        return (cWhere, parameters);
    }
}