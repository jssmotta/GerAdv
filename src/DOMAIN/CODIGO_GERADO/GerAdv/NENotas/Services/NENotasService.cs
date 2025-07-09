#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class NENotasService(IOptions<AppSettings> appSettings, INENotasReader reader, INENotasValidation validation, INENotasWriter writer, IApensoReader apensoReader, IPrecatoriaReader precatoriaReader, IInstanciaReader instanciaReader, IProcessosReader processosReader, IHttpContextAccessor httpContextAccessor, HybridCache cache, IMemoryCache memory) : INENotasService, IDisposable
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly IOptions<AppSettings> _appSettings = appSettings;
    private readonly HybridCache _cache = cache;
    private readonly IMemoryCache _memoryCache = memory;
    private bool _disposed;
    public async Task<IEnumerable<NENotasResponseAll>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("NENotas: URI inválida");
            }
        }

        var cacheKey = $"{uri}-NENotas-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, string.Empty, [], uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<NENotasResponseAll>> GetDataAllAsync(int max, string where, List<SqlParameter> parameters, string uri, CancellationToken token)
    {
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        if (oCnn == null)
        {
            throw new Exception("Conexão nula.");
        }

        var query = $@"SELECT TOP ({max})
                   {DBNENotas.SensivelCamposSqlX}, [Apenso].[],[Precatoria].[],[Instancia].[insNroProcesso],[Processos].[proNroPasta]
                   FROM {DBNENotas.PTabelaNome.dbo(oCnn)} (NOLOCK)
                   LEFT JOIN {"Apenso".dbo(oCnn)} (NOLOCK) ON [Apenso].[apeCodigo]=[NENotas].[nepApenso]
LEFT JOIN {"Precatoria".dbo(oCnn)} (NOLOCK) ON [Precatoria].[preCodigo]=[NENotas].[nepPrecatoria]
LEFT JOIN {"Instancia".dbo(oCnn)} (NOLOCK) ON [Instancia].[insCodigo]=[NENotas].[nepInstancia]
LEFT JOIN {"Processos".dbo(oCnn)} (NOLOCK) ON [Processos].[proCodigo]=[NENotas].[nepProcesso]
 
                   {where}
                   ORDER BY [NENotas].[nepNome]
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var lista = new List<NENotasResponseAll>(max);
        var ds = await ConfiguracoesDBT.GetDataTable2Async(query, parameters, oCnn);
        if (ds != null)
            foreach (DataRow item in ds.Rows)
            {
                var dbRec = new DBNENotas(item);
                if (dbRec.ID.IsEmptyIDNumber())
                {
                    continue;
                }

                var nenotas = reader.ReadAll(dbRec, item);
                if (nenotas != null)
                {
                    lista.Add(nenotas);
                }
            }

        return lista;
    }

    public async Task<IEnumerable<NENotasResponseAll>> Filter(Filters.FilterNENotas filtro, [FromRoute, Required] string uri)
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
        var cacheKey = $"{uri}-NENotas-Filter-{where.GetHashCode()}{parameters.GetHashCode()}{keyCache}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(BaseConsts.PMaxItens, string.IsNullOrEmpty(where) ? string.Empty : TSql.Where + where, parameters, uri, cancel), entryOptions, cancellationToken: new());
    }

    public async Task<NENotasResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (id < 1)
        {
            return new NENotasResponse();
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
            var result = await _cache.GetOrCreateAsync($"{uri}-NENotas-GetById-{id}-{keyCache}", async cancel => await GetDataByIdAsync(id, oCnn, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"NENotas - {uri}-: GetById");
        }
    }

    private async Task<NENotasResponse?> GetDataByIdAsync(int id, MsiSqlConnection oCnn, CancellationToken token) => await Task.Run(() => reader.Read(id, oCnn));
    public async Task<NENotasResponse?> AddAndUpdate([FromBody] Models.NENotas regNENotas, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("NENotas: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regNENotas == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regNENotas, this, apensoReader, precatoriaReader, instanciaReader, processosReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            var saved = writer.Write(regNENotas, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
            return reader.Read(saved, oCnn);
        });
    }

    public async Task<NENotasResponse?> Validation([FromBody] Models.NENotas regNENotas, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("NENotas: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regNENotas == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regNENotas, this, apensoReader, precatoriaReader, instanciaReader, processosReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            if (regNENotas.Id.IsEmptyIDNumber())
            {
                return new NENotasResponse();
            }

            return reader.Read(regNENotas.Id, oCnn);
        });
    }

    public async Task<NENotasResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("NENotas: URI inválida");
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

            var nenotas = reader.Read(id, oCnn);
            try
            {
                if (nenotas != null)
                {
                    writer.Delete(nenotas, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
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

            return nenotas;
        });
    }

    public async Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterNENotas? filtro, [FromRoute, Required] string uri, CancellationToken token)
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
        var cacheKey = $"{uri}-NENotas-{max}-{where.GetHashCode()}-GetListN-{keyCache}";
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
            foreach (var item in reader.ListarN(max, uri, where, parameters, DBNENotasDicInfo.CampoNome))
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

    private static (string where, List<SqlParameter> parametros)? WFiltro(Filters.FilterNENotas filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var parameters = new List<SqlParameter>();
        if (filtro.Apenso != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBNENotasDicInfo.Apenso)}", filtro.Apenso));
        }

        if (filtro.Precatoria != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBNENotasDicInfo.Precatoria)}", filtro.Precatoria));
        }

        if (filtro.Instancia != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBNENotasDicInfo.Instancia)}", filtro.Instancia));
        }

        if (!string.IsNullOrEmpty(filtro.Nome))
        {
            parameters.Add(new($"@{nameof(DBNENotasDicInfo.Nome)}", filtro.Nome));
        }

        if (filtro.Processo != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBNENotasDicInfo.Processo)}", filtro.Processo));
        }

        if (filtro.PalavraChave != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBNENotasDicInfo.PalavraChave)}", filtro.PalavraChave));
        }

        if (!string.IsNullOrEmpty(filtro.NotaPublicada))
        {
            parameters.Add(new($"@{nameof(DBNENotasDicInfo.NotaPublicada)}", filtro.NotaPublicada));
        }

        var cWhere = filtro.Apenso == int.MinValue ? string.Empty : $"{DBNENotasDicInfo.Apenso} = @{nameof(DBNENotasDicInfo.Apenso)}";
        cWhere += filtro.Precatoria == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBNENotasDicInfo.Precatoria} = @{nameof(DBNENotasDicInfo.Precatoria)}";
        cWhere += filtro.Instancia == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBNENotasDicInfo.Instancia} = @{nameof(DBNENotasDicInfo.Instancia)}";
        cWhere += filtro.Nome.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBNENotasDicInfo.Nome} = @{nameof(DBNENotasDicInfo.Nome)}";
        cWhere += filtro.Processo == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBNENotasDicInfo.Processo} = @{nameof(DBNENotasDicInfo.Processo)}";
        cWhere += filtro.PalavraChave == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBNENotasDicInfo.PalavraChave} = @{nameof(DBNENotasDicInfo.PalavraChave)}";
        cWhere += filtro.NotaPublicada.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBNENotasDicInfo.NotaPublicada} = @{nameof(DBNENotasDicInfo.NotaPublicada)}";
        return (cWhere, parameters);
    }
}