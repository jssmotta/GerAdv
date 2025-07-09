#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class ProSucumbenciaService(IOptions<AppSettings> appSettings, IProSucumbenciaReader reader, IProSucumbenciaValidation validation, IProSucumbenciaWriter writer, IProcessosReader processosReader, IInstanciaReader instanciaReader, ITipoOrigemSucumbenciaReader tipoorigemsucumbenciaReader, IHttpContextAccessor httpContextAccessor, HybridCache cache, IMemoryCache memory) : IProSucumbenciaService, IDisposable
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly IOptions<AppSettings> _appSettings = appSettings;
    private readonly HybridCache _cache = cache;
    private readonly IMemoryCache _memoryCache = memory;
    private bool _disposed;
    public async Task<IEnumerable<ProSucumbenciaResponseAll>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("ProSucumbencia: URI inválida");
            }
        }

        var cacheKey = $"{uri}-ProSucumbencia-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, string.Empty, [], uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<ProSucumbenciaResponseAll>> GetDataAllAsync(int max, string where, List<SqlParameter> parameters, string uri, CancellationToken token)
    {
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        if (oCnn == null)
        {
            throw new Exception("Conexão nula.");
        }

        var query = $@"SELECT TOP ({max})
                   {DBProSucumbencia.SensivelCamposSqlX}, [Processos].[proNroPasta],[Instancia].[insNroProcesso],[TipoOrigemSucumbencia].[tosNome]
                   FROM {DBProSucumbencia.PTabelaNome.dbo(oCnn)} (NOLOCK)
                   LEFT JOIN {"Processos".dbo(oCnn)} (NOLOCK) ON [Processos].[proCodigo]=[ProSucumbencia].[scbProcesso]
LEFT JOIN {"Instancia".dbo(oCnn)} (NOLOCK) ON [Instancia].[insCodigo]=[ProSucumbencia].[scbInstancia]
LEFT JOIN {"TipoOrigemSucumbencia".dbo(oCnn)} (NOLOCK) ON [TipoOrigemSucumbencia].[tosCodigo]=[ProSucumbencia].[scbTipoOrigemSucumbencia]
 
                   {where}
                   ORDER BY [ProSucumbencia].[scbNome]
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var lista = new List<ProSucumbenciaResponseAll>(max);
        var ds = await ConfiguracoesDBT.GetDataTable2Async(query, parameters, oCnn);
        if (ds != null)
            foreach (DataRow item in ds.Rows)
            {
                var dbRec = new DBProSucumbencia(item);
                if (dbRec.ID.IsEmptyIDNumber())
                {
                    continue;
                }

                var prosucumbencia = reader.ReadAll(dbRec, item);
                if (prosucumbencia != null)
                {
                    lista.Add(prosucumbencia);
                }
            }

        return lista;
    }

    public async Task<IEnumerable<ProSucumbenciaResponseAll>> Filter(Filters.FilterProSucumbencia filtro, [FromRoute, Required] string uri)
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
        var cacheKey = $"{uri}-ProSucumbencia-Filter-{where.GetHashCode()}{parameters.GetHashCode()}{keyCache}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(BaseConsts.PMaxItens, string.IsNullOrEmpty(where) ? string.Empty : TSql.Where + where, parameters, uri, cancel), entryOptions, cancellationToken: new());
    }

    public async Task<ProSucumbenciaResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (id < 1)
        {
            return new ProSucumbenciaResponse();
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
            var result = await _cache.GetOrCreateAsync($"{uri}-ProSucumbencia-GetById-{id}-{keyCache}", async cancel => await GetDataByIdAsync(id, oCnn, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"ProSucumbencia - {uri}-: GetById");
        }
    }

    private async Task<ProSucumbenciaResponse?> GetDataByIdAsync(int id, MsiSqlConnection oCnn, CancellationToken token) => await Task.Run(() => reader.Read(id, oCnn));
    public async Task<ProSucumbenciaResponse?> AddAndUpdate([FromBody] Models.ProSucumbencia regProSucumbencia, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("ProSucumbencia: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regProSucumbencia == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regProSucumbencia, this, processosReader, instanciaReader, tipoorigemsucumbenciaReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            var saved = writer.Write(regProSucumbencia, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
            return reader.Read(saved, oCnn);
        });
    }

    public async Task<ProSucumbenciaResponse?> Validation([FromBody] Models.ProSucumbencia regProSucumbencia, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("ProSucumbencia: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regProSucumbencia == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regProSucumbencia, this, processosReader, instanciaReader, tipoorigemsucumbenciaReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            if (regProSucumbencia.Id.IsEmptyIDNumber())
            {
                return new ProSucumbenciaResponse();
            }

            return reader.Read(regProSucumbencia.Id, oCnn);
        });
    }

    public async Task<ProSucumbenciaResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("ProSucumbencia: URI inválida");
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

            var prosucumbencia = reader.Read(id, oCnn);
            try
            {
                if (prosucumbencia != null)
                {
                    writer.Delete(prosucumbencia, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
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

            return prosucumbencia;
        });
    }

    public async Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterProSucumbencia? filtro, [FromRoute, Required] string uri, CancellationToken token)
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
        var cacheKey = $"{uri}-ProSucumbencia-{max}-{where.GetHashCode()}-GetListN-{keyCache}";
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
            foreach (var item in reader.ListarN(max, uri, where, parameters, DBProSucumbenciaDicInfo.CampoNome))
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

    private static (string where, List<SqlParameter> parametros)? WFiltro(Filters.FilterProSucumbencia filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var parameters = new List<SqlParameter>();
        if (filtro.Processo != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBProSucumbenciaDicInfo.Processo)}", filtro.Processo));
        }

        if (filtro.Instancia != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBProSucumbenciaDicInfo.Instancia)}", filtro.Instancia));
        }

        if (!string.IsNullOrEmpty(filtro.Nome))
        {
            parameters.Add(new($"@{nameof(DBProSucumbenciaDicInfo.Nome)}", filtro.Nome));
        }

        if (filtro.TipoOrigemSucumbencia != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBProSucumbenciaDicInfo.TipoOrigemSucumbencia)}", filtro.TipoOrigemSucumbencia));
        }

        if (!string.IsNullOrEmpty(filtro.Percentual))
        {
            parameters.Add(new($"@{nameof(DBProSucumbenciaDicInfo.Percentual)}", filtro.Percentual));
        }

        if (!string.IsNullOrEmpty(filtro.GUID))
        {
            parameters.Add(new($"@{nameof(DBProSucumbenciaDicInfo.GUID)}", filtro.GUID));
        }

        var cWhere = filtro.Processo == int.MinValue ? string.Empty : $"{DBProSucumbenciaDicInfo.Processo} = @{nameof(DBProSucumbenciaDicInfo.Processo)}";
        cWhere += filtro.Instancia == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBProSucumbenciaDicInfo.Instancia} = @{nameof(DBProSucumbenciaDicInfo.Instancia)}";
        cWhere += filtro.Nome.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBProSucumbenciaDicInfo.Nome} = @{nameof(DBProSucumbenciaDicInfo.Nome)}";
        cWhere += filtro.TipoOrigemSucumbencia == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBProSucumbenciaDicInfo.TipoOrigemSucumbencia} = @{nameof(DBProSucumbenciaDicInfo.TipoOrigemSucumbencia)}";
        cWhere += filtro.Percentual.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBProSucumbenciaDicInfo.Percentual} = @{nameof(DBProSucumbenciaDicInfo.Percentual)}";
        cWhere += filtro.GUID.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBProSucumbenciaDicInfo.GUID} = @{nameof(DBProSucumbenciaDicInfo.GUID)}";
        return (cWhere, parameters);
    }
}