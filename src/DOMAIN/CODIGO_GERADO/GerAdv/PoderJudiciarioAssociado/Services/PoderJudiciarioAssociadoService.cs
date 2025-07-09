#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class PoderJudiciarioAssociadoService(IOptions<AppSettings> appSettings, IPoderJudiciarioAssociadoReader reader, IPoderJudiciarioAssociadoValidation validation, IPoderJudiciarioAssociadoWriter writer, IJusticaReader justicaReader, IAreaReader areaReader, ITribunalReader tribunalReader, IForoReader foroReader, ICidadeReader cidadeReader, IHttpContextAccessor httpContextAccessor, HybridCache cache, IMemoryCache memory) : IPoderJudiciarioAssociadoService, IDisposable
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly IOptions<AppSettings> _appSettings = appSettings;
    private readonly HybridCache _cache = cache;
    private readonly IMemoryCache _memoryCache = memory;
    private bool _disposed;
    public async Task<IEnumerable<PoderJudiciarioAssociadoResponseAll>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("PoderJudiciarioAssociado: URI inválida");
            }
        }

        var cacheKey = $"{uri}-PoderJudiciarioAssociado-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, string.Empty, [], uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<PoderJudiciarioAssociadoResponseAll>> GetDataAllAsync(int max, string where, List<SqlParameter> parameters, string uri, CancellationToken token)
    {
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        if (oCnn == null)
        {
            throw new Exception("Conexão nula.");
        }

        var query = $@"SELECT TOP ({max})
                   {DBPoderJudiciarioAssociado.SensivelCamposSqlX}, [Justica].[jusNome],[Area].[areDescricao],[Tribunal].[triNome],[Foro].[forNome],[Cidade].[cidNome]
                   FROM {DBPoderJudiciarioAssociado.PTabelaNome.dbo(oCnn)} (NOLOCK)
                   LEFT JOIN {"Justica".dbo(oCnn)} (NOLOCK) ON [Justica].[jusCodigo]=[PoderJudiciarioAssociado].[pjaJustica]
LEFT JOIN {"Area".dbo(oCnn)} (NOLOCK) ON [Area].[areCodigo]=[PoderJudiciarioAssociado].[pjaArea]
LEFT JOIN {"Tribunal".dbo(oCnn)} (NOLOCK) ON [Tribunal].[triCodigo]=[PoderJudiciarioAssociado].[pjaTribunal]
LEFT JOIN {"Foro".dbo(oCnn)} (NOLOCK) ON [Foro].[forCodigo]=[PoderJudiciarioAssociado].[pjaForo]
LEFT JOIN {"Cidade".dbo(oCnn)} (NOLOCK) ON [Cidade].[cidCodigo]=[PoderJudiciarioAssociado].[pjaCidade]
 
                   {where}
                   ORDER BY [PoderJudiciarioAssociado].[]
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var lista = new List<PoderJudiciarioAssociadoResponseAll>(max);
        var ds = await ConfiguracoesDBT.GetDataTable2Async(query, parameters, oCnn);
        if (ds != null)
            foreach (DataRow item in ds.Rows)
            {
                var dbRec = new DBPoderJudiciarioAssociado(item);
                if (dbRec.ID.IsEmptyIDNumber())
                {
                    continue;
                }

                var poderjudiciarioassociado = reader.ReadAll(dbRec, item);
                if (poderjudiciarioassociado != null)
                {
                    lista.Add(poderjudiciarioassociado);
                }
            }

        return lista;
    }

    public async Task<IEnumerable<PoderJudiciarioAssociadoResponseAll>> Filter(Filters.FilterPoderJudiciarioAssociado filtro, [FromRoute, Required] string uri)
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
        var cacheKey = $"{uri}-PoderJudiciarioAssociado-Filter-{where.GetHashCode()}{parameters.GetHashCode()}{keyCache}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(BaseConsts.PMaxItens, string.IsNullOrEmpty(where) ? string.Empty : TSql.Where + where, parameters, uri, cancel), entryOptions, cancellationToken: new());
    }

    public async Task<PoderJudiciarioAssociadoResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (id < 1)
        {
            return new PoderJudiciarioAssociadoResponse();
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
            var result = await _cache.GetOrCreateAsync($"{uri}-PoderJudiciarioAssociado-GetById-{id}-{keyCache}", async cancel => await GetDataByIdAsync(id, oCnn, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"PoderJudiciarioAssociado - {uri}-: GetById");
        }
    }

    private async Task<PoderJudiciarioAssociadoResponse?> GetDataByIdAsync(int id, MsiSqlConnection oCnn, CancellationToken token) => await Task.Run(() => reader.Read(id, oCnn));
    public async Task<PoderJudiciarioAssociadoResponse?> AddAndUpdate([FromBody] Models.PoderJudiciarioAssociado regPoderJudiciarioAssociado, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("PoderJudiciarioAssociado: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regPoderJudiciarioAssociado == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regPoderJudiciarioAssociado, this, justicaReader, areaReader, tribunalReader, foroReader, cidadeReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            var saved = writer.Write(regPoderJudiciarioAssociado, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
            return reader.Read(saved, oCnn);
        });
    }

    public async Task<PoderJudiciarioAssociadoResponse?> Validation([FromBody] Models.PoderJudiciarioAssociado regPoderJudiciarioAssociado, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("PoderJudiciarioAssociado: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regPoderJudiciarioAssociado == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regPoderJudiciarioAssociado, this, justicaReader, areaReader, tribunalReader, foroReader, cidadeReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            if (regPoderJudiciarioAssociado.Id.IsEmptyIDNumber())
            {
                return new PoderJudiciarioAssociadoResponse();
            }

            return reader.Read(regPoderJudiciarioAssociado.Id, oCnn);
        });
    }

    public async Task<PoderJudiciarioAssociadoResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("PoderJudiciarioAssociado: URI inválida");
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

            var poderjudiciarioassociado = reader.Read(id, oCnn);
            try
            {
                if (poderjudiciarioassociado != null)
                {
                    writer.Delete(poderjudiciarioassociado, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
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

            return poderjudiciarioassociado;
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

    private static (string where, List<SqlParameter> parametros)? WFiltro(Filters.FilterPoderJudiciarioAssociado filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var parameters = new List<SqlParameter>();
        if (filtro.Justica != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBPoderJudiciarioAssociadoDicInfo.Justica)}", filtro.Justica));
        }

        if (!string.IsNullOrEmpty(filtro.JusticaNome))
        {
            parameters.Add(new($"@{nameof(DBPoderJudiciarioAssociadoDicInfo.JusticaNome)}", filtro.JusticaNome));
        }

        if (filtro.Area != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBPoderJudiciarioAssociadoDicInfo.Area)}", filtro.Area));
        }

        if (!string.IsNullOrEmpty(filtro.AreaNome))
        {
            parameters.Add(new($"@{nameof(DBPoderJudiciarioAssociadoDicInfo.AreaNome)}", filtro.AreaNome));
        }

        if (filtro.Tribunal != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBPoderJudiciarioAssociadoDicInfo.Tribunal)}", filtro.Tribunal));
        }

        if (!string.IsNullOrEmpty(filtro.TribunalNome))
        {
            parameters.Add(new($"@{nameof(DBPoderJudiciarioAssociadoDicInfo.TribunalNome)}", filtro.TribunalNome));
        }

        if (filtro.Foro != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBPoderJudiciarioAssociadoDicInfo.Foro)}", filtro.Foro));
        }

        if (!string.IsNullOrEmpty(filtro.ForoNome))
        {
            parameters.Add(new($"@{nameof(DBPoderJudiciarioAssociadoDicInfo.ForoNome)}", filtro.ForoNome));
        }

        if (filtro.Cidade != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBPoderJudiciarioAssociadoDicInfo.Cidade)}", filtro.Cidade));
        }

        if (!string.IsNullOrEmpty(filtro.SubDivisaoNome))
        {
            parameters.Add(new($"@{nameof(DBPoderJudiciarioAssociadoDicInfo.SubDivisaoNome)}", filtro.SubDivisaoNome));
        }

        if (!string.IsNullOrEmpty(filtro.CidadeNome))
        {
            parameters.Add(new($"@{nameof(DBPoderJudiciarioAssociadoDicInfo.CidadeNome)}", filtro.CidadeNome));
        }

        if (filtro.SubDivisao != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBPoderJudiciarioAssociadoDicInfo.SubDivisao)}", filtro.SubDivisao));
        }

        if (filtro.Tipo != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBPoderJudiciarioAssociadoDicInfo.Tipo)}", filtro.Tipo));
        }

        if (!string.IsNullOrEmpty(filtro.GUID))
        {
            parameters.Add(new($"@{nameof(DBPoderJudiciarioAssociadoDicInfo.GUID)}", filtro.GUID));
        }

        var cWhere = filtro.Justica == int.MinValue ? string.Empty : $"{DBPoderJudiciarioAssociadoDicInfo.Justica} = @{nameof(DBPoderJudiciarioAssociadoDicInfo.Justica)}";
        cWhere += filtro.JusticaNome.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBPoderJudiciarioAssociadoDicInfo.JusticaNome} = @{nameof(DBPoderJudiciarioAssociadoDicInfo.JusticaNome)}";
        cWhere += filtro.Area == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBPoderJudiciarioAssociadoDicInfo.Area} = @{nameof(DBPoderJudiciarioAssociadoDicInfo.Area)}";
        cWhere += filtro.AreaNome.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBPoderJudiciarioAssociadoDicInfo.AreaNome} = @{nameof(DBPoderJudiciarioAssociadoDicInfo.AreaNome)}";
        cWhere += filtro.Tribunal == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBPoderJudiciarioAssociadoDicInfo.Tribunal} = @{nameof(DBPoderJudiciarioAssociadoDicInfo.Tribunal)}";
        cWhere += filtro.TribunalNome.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBPoderJudiciarioAssociadoDicInfo.TribunalNome} = @{nameof(DBPoderJudiciarioAssociadoDicInfo.TribunalNome)}";
        cWhere += filtro.Foro == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBPoderJudiciarioAssociadoDicInfo.Foro} = @{nameof(DBPoderJudiciarioAssociadoDicInfo.Foro)}";
        cWhere += filtro.ForoNome.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBPoderJudiciarioAssociadoDicInfo.ForoNome} = @{nameof(DBPoderJudiciarioAssociadoDicInfo.ForoNome)}";
        cWhere += filtro.Cidade == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBPoderJudiciarioAssociadoDicInfo.Cidade} = @{nameof(DBPoderJudiciarioAssociadoDicInfo.Cidade)}";
        cWhere += filtro.SubDivisaoNome.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBPoderJudiciarioAssociadoDicInfo.SubDivisaoNome} = @{nameof(DBPoderJudiciarioAssociadoDicInfo.SubDivisaoNome)}";
        cWhere += filtro.CidadeNome.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBPoderJudiciarioAssociadoDicInfo.CidadeNome} = @{nameof(DBPoderJudiciarioAssociadoDicInfo.CidadeNome)}";
        cWhere += filtro.SubDivisao == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBPoderJudiciarioAssociadoDicInfo.SubDivisao} = @{nameof(DBPoderJudiciarioAssociadoDicInfo.SubDivisao)}";
        cWhere += filtro.Tipo == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBPoderJudiciarioAssociadoDicInfo.Tipo} = @{nameof(DBPoderJudiciarioAssociadoDicInfo.Tipo)}";
        cWhere += filtro.GUID.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBPoderJudiciarioAssociadoDicInfo.GUID} = @{nameof(DBPoderJudiciarioAssociadoDicInfo.GUID)}";
        return (cWhere, parameters);
    }
}