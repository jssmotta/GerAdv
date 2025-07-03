#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class UltimosProcessosService(IOptions<AppSettings> appSettings, IUltimosProcessosReader reader, IUltimosProcessosValidation validation, IUltimosProcessosWriter writer, IProcessosReader processosReader, HybridCache cache, IMemoryCache memory) : IUltimosProcessosService, IDisposable
{
    private readonly IOptions<AppSettings> _appSettings = appSettings;
    private readonly HybridCache _cache = cache;
    private readonly IMemoryCache _memoryCache = memory;
    private bool _disposed;
    public async Task<IEnumerable<UltimosProcessosResponseAll>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("UltimosProcessos: URI inválida");
            }
        }

        var cacheKey = $"{uri}-UltimosProcessos-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, string.Empty, [], uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<UltimosProcessosResponseAll>> GetDataAllAsync(int max, string where, List<SqlParameter> parameters, string uri, CancellationToken token)
    {
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        if (oCnn == null)
        {
            throw new Exception("Conexão nula.");
        }

        var query = $@"SELECT TOP ({max})
                   {DBUltimosProcessos.SensivelCamposSqlX}, [Processos].[proNroPasta]
                   FROM {DBUltimosProcessos.PTabelaNome.dbo(oCnn)} (NOLOCK)
                   LEFT JOIN {"Processos".dbo(oCnn)} (NOLOCK) ON [Processos].[proCodigo]=[UltimosProcessos].[ultProcesso]
 
                   {where}
                   ORDER BY [UltimosProcessos].[]
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var lista = new List<UltimosProcessosResponseAll>(max);
        var ds = await ConfiguracoesDBT.GetDataTable2Async(query, parameters, oCnn);
        if (ds != null)
            foreach (DataRow item in ds.Rows)
            {
                var dbRec = new DBUltimosProcessos(item);
                if (dbRec.ID.IsEmptyIDNumber())
                {
                    continue;
                }

                var ultimosprocessos = reader.ReadAll(dbRec, item);
                if (ultimosprocessos != null)
                {
                    lista.Add(ultimosprocessos);
                }
            }

        return lista;
    }

    public async Task<IEnumerable<UltimosProcessosResponseAll>> Filter(Filters.FilterUltimosProcessos filtro, [FromRoute, Required] string uri)
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
        var cacheKey = $"{uri}-UltimosProcessos-Filter-{where.GetHashCode()}{parameters.GetHashCode()}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(BaseConsts.PMaxItens, string.IsNullOrEmpty(where) ? string.Empty : TSql.Where + where, parameters, uri, cancel), entryOptions, cancellationToken: new());
    }

    public async Task<UltimosProcessosResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (id < 1)
        {
            return new UltimosProcessosResponse();
        }

        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxSecondsCacheId)
        };
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        try
        {
            var result = await _cache.GetOrCreateAsync($"{uri}-UltimosProcessos-GetById-{id}", async cancel => await GetDataByIdAsync(id, oCnn, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"UltimosProcessos - {uri}-: GetById");
        }
    }

    private async Task<UltimosProcessosResponse?> GetDataByIdAsync(int id, MsiSqlConnection oCnn, CancellationToken token) => await Task.Run(() => reader.Read(id, oCnn));
    public async Task<UltimosProcessosResponse?> AddAndUpdate([FromBody] Models.UltimosProcessos regUltimosProcessos, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("UltimosProcessos: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regUltimosProcessos == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regUltimosProcessos, this, processosReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            var saved = writer.Write(regUltimosProcessos, oCnn);
            return reader.Read(saved.ID, oCnn);
        });
    }

    public async Task<UltimosProcessosResponse?> Validation([FromBody] Models.UltimosProcessos regUltimosProcessos, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("UltimosProcessos: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regUltimosProcessos == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regUltimosProcessos, this, processosReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            if (regUltimosProcessos.Id.IsEmptyIDNumber())
            {
                return new UltimosProcessosResponse();
            }

            return reader.Read(regUltimosProcessos.Id, oCnn);
        });
    }

    public async Task<UltimosProcessosResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("UltimosProcessos: URI inválida");
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

            var ultimosprocessos = reader.Read(id, oCnn);
            try
            {
                if (ultimosprocessos != null)
                {
                    writer.Delete(ultimosprocessos, 0, oCnn);
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

            return ultimosprocessos;
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

    private static (string where, List<SqlParameter> parametros)? WFiltro(Filters.FilterUltimosProcessos filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var parameters = new List<SqlParameter>();
        if (filtro.Processo != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBUltimosProcessosDicInfo.Processo)}", filtro.Processo));
        }

        if (filtro.Quem != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBUltimosProcessosDicInfo.Quem)}", filtro.Quem));
        }

        var cWhere = filtro.Processo == int.MinValue ? string.Empty : $"{DBUltimosProcessosDicInfo.Processo} = @{nameof(DBUltimosProcessosDicInfo.Processo)}";
        cWhere += filtro.Quem == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBUltimosProcessosDicInfo.Quem} = @{nameof(DBUltimosProcessosDicInfo.Quem)}";
        return (cWhere, parameters);
    }
}