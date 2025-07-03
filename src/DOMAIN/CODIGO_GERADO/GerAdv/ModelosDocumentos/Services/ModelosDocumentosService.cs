#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class ModelosDocumentosService(IOptions<AppSettings> appSettings, IModelosDocumentosReader reader, IModelosDocumentosValidation validation, IModelosDocumentosWriter writer, ITipoModeloDocumentoReader tipomodelodocumentoReader, IHttpContextAccessor httpContextAccessor, HybridCache cache, IMemoryCache memory) : IModelosDocumentosService, IDisposable
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly IOptions<AppSettings> _appSettings = appSettings;
    private readonly HybridCache _cache = cache;
    private readonly IMemoryCache _memoryCache = memory;
    private bool _disposed;
    public async Task<IEnumerable<ModelosDocumentosResponseAll>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("ModelosDocumentos: URI inválida");
            }
        }

        var cacheKey = $"{uri}-ModelosDocumentos-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, string.Empty, [], uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<ModelosDocumentosResponseAll>> GetDataAllAsync(int max, string where, List<SqlParameter> parameters, string uri, CancellationToken token)
    {
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        if (oCnn == null)
        {
            throw new Exception("Conexão nula.");
        }

        var query = $@"SELECT TOP ({max})
                   {DBModelosDocumentos.SensivelCamposSqlX}, [TipoModeloDocumento].[tpdNome]
                   FROM {DBModelosDocumentos.PTabelaNome.dbo(oCnn)} (NOLOCK)
                   LEFT JOIN {"TipoModeloDocumento".dbo(oCnn)} (NOLOCK) ON [TipoModeloDocumento].[tpdCodigo]=[ModelosDocumentos].[mdcTipoModeloDocumento]
 
                   {where}
                   ORDER BY [ModelosDocumentos].[mdcNome]
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var lista = new List<ModelosDocumentosResponseAll>(max);
        var ds = await ConfiguracoesDBT.GetDataTable2Async(query, parameters, oCnn);
        if (ds != null)
            foreach (DataRow item in ds.Rows)
            {
                var dbRec = new DBModelosDocumentos(item);
                if (dbRec.ID.IsEmptyIDNumber())
                {
                    continue;
                }

                var modelosdocumentos = reader.ReadAll(dbRec, item);
                if (modelosdocumentos != null)
                {
                    lista.Add(modelosdocumentos);
                }
            }

        return lista;
    }

    public async Task<IEnumerable<ModelosDocumentosResponseAll>> Filter(Filters.FilterModelosDocumentos filtro, [FromRoute, Required] string uri)
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
        var cacheKey = $"{uri}-ModelosDocumentos-Filter-{where.GetHashCode()}{parameters.GetHashCode()}{keyCache}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(BaseConsts.PMaxItens, string.IsNullOrEmpty(where) ? string.Empty : TSql.Where + where, parameters, uri, cancel), entryOptions, cancellationToken: new());
    }

    public async Task<ModelosDocumentosResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (id < 1)
        {
            return new ModelosDocumentosResponse();
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
            var result = await _cache.GetOrCreateAsync($"{uri}-ModelosDocumentos-GetById-{id}-{keyCache}", async cancel => await GetDataByIdAsync(id, oCnn, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"ModelosDocumentos - {uri}-: GetById");
        }
    }

    private async Task<ModelosDocumentosResponse?> GetDataByIdAsync(int id, MsiSqlConnection oCnn, CancellationToken token) => await Task.Run(() => reader.Read(id, oCnn));
    public async Task<ModelosDocumentosResponse?> AddAndUpdate([FromBody] Models.ModelosDocumentos regModelosDocumentos, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("ModelosDocumentos: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regModelosDocumentos == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regModelosDocumentos, this, tipomodelodocumentoReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            var saved = writer.Write(regModelosDocumentos, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
            return reader.Read(saved.ID, oCnn);
        });
    }

    public async Task<ModelosDocumentosResponse?> Validation([FromBody] Models.ModelosDocumentos regModelosDocumentos, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("ModelosDocumentos: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regModelosDocumentos == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regModelosDocumentos, this, tipomodelodocumentoReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            if (regModelosDocumentos.Id.IsEmptyIDNumber())
            {
                return new ModelosDocumentosResponse();
            }

            return reader.Read(regModelosDocumentos.Id, oCnn);
        });
    }

    public async Task<ModelosDocumentosResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("ModelosDocumentos: URI inválida");
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

            var modelosdocumentos = reader.Read(id, oCnn);
            try
            {
                if (modelosdocumentos != null)
                {
                    writer.Delete(modelosdocumentos, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
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

            return modelosdocumentos;
        });
    }

    public async Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterModelosDocumentos? filtro, [FromRoute, Required] string uri, CancellationToken token)
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
        var cacheKey = $"{uri}-ModelosDocumentos-{max}-{where.GetHashCode()}-GetListN-{keyCache}";
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
            foreach (var item in reader.ListarN(max, uri, where, parameters, DBModelosDocumentosDicInfo.CampoNome))
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

    private static (string where, List<SqlParameter> parametros)? WFiltro(Filters.FilterModelosDocumentos filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var parameters = new List<SqlParameter>();
        if (!string.IsNullOrEmpty(filtro.Nome))
        {
            parameters.Add(new($"@{nameof(DBModelosDocumentosDicInfo.Nome)}", filtro.Nome));
        }

        if (!string.IsNullOrEmpty(filtro.Remuneracao))
        {
            parameters.Add(new($"@{nameof(DBModelosDocumentosDicInfo.Remuneracao)}", filtro.Remuneracao));
        }

        if (!string.IsNullOrEmpty(filtro.Assinatura))
        {
            parameters.Add(new($"@{nameof(DBModelosDocumentosDicInfo.Assinatura)}", filtro.Assinatura));
        }

        if (!string.IsNullOrEmpty(filtro.Header))
        {
            parameters.Add(new($"@{nameof(DBModelosDocumentosDicInfo.Header)}", filtro.Header));
        }

        if (!string.IsNullOrEmpty(filtro.Footer))
        {
            parameters.Add(new($"@{nameof(DBModelosDocumentosDicInfo.Footer)}", filtro.Footer));
        }

        if (!string.IsNullOrEmpty(filtro.Extra1))
        {
            parameters.Add(new($"@{nameof(DBModelosDocumentosDicInfo.Extra1)}", filtro.Extra1));
        }

        if (!string.IsNullOrEmpty(filtro.Extra2))
        {
            parameters.Add(new($"@{nameof(DBModelosDocumentosDicInfo.Extra2)}", filtro.Extra2));
        }

        if (!string.IsNullOrEmpty(filtro.Extra3))
        {
            parameters.Add(new($"@{nameof(DBModelosDocumentosDicInfo.Extra3)}", filtro.Extra3));
        }

        if (!string.IsNullOrEmpty(filtro.Outorgante))
        {
            parameters.Add(new($"@{nameof(DBModelosDocumentosDicInfo.Outorgante)}", filtro.Outorgante));
        }

        if (!string.IsNullOrEmpty(filtro.Outorgados))
        {
            parameters.Add(new($"@{nameof(DBModelosDocumentosDicInfo.Outorgados)}", filtro.Outorgados));
        }

        if (!string.IsNullOrEmpty(filtro.Poderes))
        {
            parameters.Add(new($"@{nameof(DBModelosDocumentosDicInfo.Poderes)}", filtro.Poderes));
        }

        if (!string.IsNullOrEmpty(filtro.Objeto))
        {
            parameters.Add(new($"@{nameof(DBModelosDocumentosDicInfo.Objeto)}", filtro.Objeto));
        }

        if (!string.IsNullOrEmpty(filtro.Titulo))
        {
            parameters.Add(new($"@{nameof(DBModelosDocumentosDicInfo.Titulo)}", filtro.Titulo));
        }

        if (!string.IsNullOrEmpty(filtro.Testemunhas))
        {
            parameters.Add(new($"@{nameof(DBModelosDocumentosDicInfo.Testemunhas)}", filtro.Testemunhas));
        }

        if (filtro.TipoModeloDocumento != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBModelosDocumentosDicInfo.TipoModeloDocumento)}", filtro.TipoModeloDocumento));
        }

        if (!string.IsNullOrEmpty(filtro.CSS))
        {
            parameters.Add(new($"@{nameof(DBModelosDocumentosDicInfo.CSS)}", filtro.CSS));
        }

        if (!string.IsNullOrEmpty(filtro.GUID))
        {
            parameters.Add(new($"@{nameof(DBModelosDocumentosDicInfo.GUID)}", filtro.GUID));
        }

        var cWhere = filtro.Nome.IsEmpty() ? string.Empty : $"{DBModelosDocumentosDicInfo.Nome} = @{nameof(DBModelosDocumentosDicInfo.Nome)}";
        cWhere += filtro.Remuneracao.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBModelosDocumentosDicInfo.Remuneracao} = @{nameof(DBModelosDocumentosDicInfo.Remuneracao)}";
        cWhere += filtro.Assinatura.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBModelosDocumentosDicInfo.Assinatura} = @{nameof(DBModelosDocumentosDicInfo.Assinatura)}";
        cWhere += filtro.Header.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBModelosDocumentosDicInfo.Header} = @{nameof(DBModelosDocumentosDicInfo.Header)}";
        cWhere += filtro.Footer.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBModelosDocumentosDicInfo.Footer} = @{nameof(DBModelosDocumentosDicInfo.Footer)}";
        cWhere += filtro.Extra1.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBModelosDocumentosDicInfo.Extra1} = @{nameof(DBModelosDocumentosDicInfo.Extra1)}";
        cWhere += filtro.Extra2.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBModelosDocumentosDicInfo.Extra2} = @{nameof(DBModelosDocumentosDicInfo.Extra2)}";
        cWhere += filtro.Extra3.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBModelosDocumentosDicInfo.Extra3} = @{nameof(DBModelosDocumentosDicInfo.Extra3)}";
        cWhere += filtro.Outorgante.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBModelosDocumentosDicInfo.Outorgante} = @{nameof(DBModelosDocumentosDicInfo.Outorgante)}";
        cWhere += filtro.Outorgados.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBModelosDocumentosDicInfo.Outorgados} = @{nameof(DBModelosDocumentosDicInfo.Outorgados)}";
        cWhere += filtro.Poderes.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBModelosDocumentosDicInfo.Poderes} = @{nameof(DBModelosDocumentosDicInfo.Poderes)}";
        cWhere += filtro.Objeto.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBModelosDocumentosDicInfo.Objeto} = @{nameof(DBModelosDocumentosDicInfo.Objeto)}";
        cWhere += filtro.Titulo.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBModelosDocumentosDicInfo.Titulo} = @{nameof(DBModelosDocumentosDicInfo.Titulo)}";
        cWhere += filtro.Testemunhas.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBModelosDocumentosDicInfo.Testemunhas} = @{nameof(DBModelosDocumentosDicInfo.Testemunhas)}";
        cWhere += filtro.TipoModeloDocumento == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBModelosDocumentosDicInfo.TipoModeloDocumento} = @{nameof(DBModelosDocumentosDicInfo.TipoModeloDocumento)}";
        cWhere += filtro.CSS.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBModelosDocumentosDicInfo.CSS} = @{nameof(DBModelosDocumentosDicInfo.CSS)}";
        cWhere += filtro.GUID.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBModelosDocumentosDicInfo.GUID} = @{nameof(DBModelosDocumentosDicInfo.GUID)}";
        return (cWhere, parameters);
    }
}