#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class PontoVirtualAcessosService(IOptions<AppSettings> appSettings, IPontoVirtualAcessosReader reader, IPontoVirtualAcessosValidation validation, IPontoVirtualAcessosWriter writer, IOperadorReader operadorReader, HybridCache cache, IMemoryCache memory) : IPontoVirtualAcessosService, IDisposable
{
    private readonly IOptions<AppSettings> _appSettings = appSettings;
    private readonly HybridCache _cache = cache;
    private readonly IMemoryCache _memoryCache = memory;
    private bool _disposed;
    public async Task<IEnumerable<PontoVirtualAcessosResponseAll>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("PontoVirtualAcessos: URI inválida");
            }
        }

        var cacheKey = $"{uri}-PontoVirtualAcessos-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, string.Empty, [], uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<PontoVirtualAcessosResponseAll>> GetDataAllAsync(int max, string where, List<SqlParameter> parameters, string uri, CancellationToken token)
    {
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        if (oCnn == null)
        {
            throw new Exception("Conexão nula.");
        }

        var query = $@"SELECT TOP ({max})
                   {DBPontoVirtualAcessos.SensivelCamposSqlX}, [Operador].[operNome]
                   FROM {DBPontoVirtualAcessos.PTabelaNome.dbo(oCnn)} (NOLOCK)
                   LEFT JOIN {"Operador".dbo(oCnn)} (NOLOCK) ON [Operador].[operCodigo]=[PontoVirtualAcessos].[pvaOperador]
 
                   {where}
                   ORDER BY [PontoVirtualAcessos].[]
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var lista = new List<PontoVirtualAcessosResponseAll>(max);
        var ds = await ConfiguracoesDBT.GetDataTable2Async(query, parameters, oCnn);
        if (ds != null)
            foreach (DataRow item in ds.Rows)
            {
                var dbRec = new DBPontoVirtualAcessos(item);
                if (dbRec.ID.IsEmptyIDNumber())
                {
                    continue;
                }

                var pontovirtualacessos = reader.ReadAll(dbRec, item);
                if (pontovirtualacessos != null)
                {
                    lista.Add(pontovirtualacessos);
                }
            }

        return lista;
    }

    public async Task<IEnumerable<PontoVirtualAcessosResponseAll>> Filter(Filters.FilterPontoVirtualAcessos filtro, [FromRoute, Required] string uri)
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
        var cacheKey = $"{uri}-PontoVirtualAcessos-Filter-{where.GetHashCode()}{parameters.GetHashCode()}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(BaseConsts.PMaxItens, string.IsNullOrEmpty(where) ? string.Empty : TSql.Where + where, parameters, uri, cancel), entryOptions, cancellationToken: new());
    }

    public async Task<PontoVirtualAcessosResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (id < 1)
        {
            return new PontoVirtualAcessosResponse();
        }

        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxSecondsCacheId)
        };
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        try
        {
            var result = await _cache.GetOrCreateAsync($"{uri}-PontoVirtualAcessos-GetById-{id}", async cancel => await GetDataByIdAsync(id, oCnn, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"PontoVirtualAcessos - {uri}-: GetById");
        }
    }

    private async Task<PontoVirtualAcessosResponse?> GetDataByIdAsync(int id, MsiSqlConnection oCnn, CancellationToken token) => await Task.Run(() => reader.Read(id, oCnn));
    public async Task<PontoVirtualAcessosResponse?> AddAndUpdate([FromBody] Models.PontoVirtualAcessos regPontoVirtualAcessos, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("PontoVirtualAcessos: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regPontoVirtualAcessos == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regPontoVirtualAcessos, this, operadorReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            var saved = writer.Write(regPontoVirtualAcessos, oCnn);
            return reader.Read(saved, oCnn);
        });
    }

    public async Task<PontoVirtualAcessosResponse?> Validation([FromBody] Models.PontoVirtualAcessos regPontoVirtualAcessos, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("PontoVirtualAcessos: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regPontoVirtualAcessos == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regPontoVirtualAcessos, this, operadorReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            if (regPontoVirtualAcessos.Id.IsEmptyIDNumber())
            {
                return new PontoVirtualAcessosResponse();
            }

            return reader.Read(regPontoVirtualAcessos.Id, oCnn);
        });
    }

    public async Task<PontoVirtualAcessosResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("PontoVirtualAcessos: URI inválida");
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

            var pontovirtualacessos = reader.Read(id, oCnn);
            try
            {
                if (pontovirtualacessos != null)
                {
                    writer.Delete(pontovirtualacessos, 0, oCnn);
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

            return pontovirtualacessos;
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

    private static (string where, List<SqlParameter> parametros)? WFiltro(Filters.FilterPontoVirtualAcessos filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var parameters = new List<SqlParameter>();
        if (filtro.Operador != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBPontoVirtualAcessosDicInfo.Operador)}", filtro.Operador));
        }

        if (!string.IsNullOrEmpty(filtro.Origem))
        {
            parameters.Add(new($"@{nameof(DBPontoVirtualAcessosDicInfo.Origem)}", filtro.Origem));
        }

        var cWhere = filtro.Operador == int.MinValue ? string.Empty : $"{DBPontoVirtualAcessosDicInfo.Operador} = @{nameof(DBPontoVirtualAcessosDicInfo.Operador)}";
        cWhere += filtro.Origem.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBPontoVirtualAcessosDicInfo.Origem} = @{nameof(DBPontoVirtualAcessosDicInfo.Origem)}";
        return (cWhere, parameters);
    }
}