#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class LivroCaixaService(IOptions<AppSettings> appSettings, ILivroCaixaReader reader, ILivroCaixaValidation validation, ILivroCaixaWriter writer, IProcessosReader processosReader, ILivroCaixaClientesService livrocaixaclientesService, IHttpContextAccessor httpContextAccessor, HybridCache cache, IMemoryCache memory) : ILivroCaixaService, IDisposable
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly IOptions<AppSettings> _appSettings = appSettings;
    private readonly HybridCache _cache = cache;
    private readonly IMemoryCache _memoryCache = memory;
    private bool _disposed;
    public async Task<IEnumerable<LivroCaixaResponseAll>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("LivroCaixa: URI inválida");
            }
        }

        var cacheKey = $"{uri}-LivroCaixa-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, string.Empty, [], uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<LivroCaixaResponseAll>> GetDataAllAsync(int max, string where, List<SqlParameter> parameters, string uri, CancellationToken token)
    {
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        if (oCnn == null)
        {
            throw new Exception("Conexão nula.");
        }

        var query = $@"SELECT TOP ({max})
                   {DBLivroCaixa.SensivelCamposSqlX}, [Processos].[proNroPasta]
                   FROM {DBLivroCaixa.PTabelaNome.dbo(oCnn)} (NOLOCK)
                   LEFT JOIN {"Processos".dbo(oCnn)} (NOLOCK) ON [Processos].[proCodigo]=[LivroCaixa].[livProcesso]
 
                   {where}
                   ORDER BY [LivroCaixa].[]
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var lista = new List<LivroCaixaResponseAll>(max);
        var ds = await ConfiguracoesDBT.GetDataTable2Async(query, parameters, oCnn);
        if (ds != null)
            foreach (DataRow item in ds.Rows)
            {
                var dbRec = new DBLivroCaixa(item);
                if (dbRec.ID.IsEmptyIDNumber())
                {
                    continue;
                }

                var livrocaixa = reader.ReadAll(dbRec, item);
                if (livrocaixa != null)
                {
                    lista.Add(livrocaixa);
                }
            }

        return lista;
    }

    public async Task<IEnumerable<LivroCaixaResponseAll>> Filter(Filters.FilterLivroCaixa filtro, [FromRoute, Required] string uri)
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
        var cacheKey = $"{uri}-LivroCaixa-Filter-{where.GetHashCode()}{parameters.GetHashCode()}{keyCache}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(BaseConsts.PMaxItens, string.IsNullOrEmpty(where) ? string.Empty : TSql.Where + where, parameters, uri, cancel), entryOptions, cancellationToken: new());
    }

    public async Task<LivroCaixaResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (id < 1)
        {
            return new LivroCaixaResponse();
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
            var result = await _cache.GetOrCreateAsync($"{uri}-LivroCaixa-GetById-{id}-{keyCache}", async cancel => await GetDataByIdAsync(id, oCnn, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"LivroCaixa - {uri}-: GetById");
        }
    }

    private async Task<LivroCaixaResponse?> GetDataByIdAsync(int id, MsiSqlConnection oCnn, CancellationToken token) => await Task.Run(() => reader.Read(id, oCnn));
    public async Task<LivroCaixaResponse?> AddAndUpdate([FromBody] Models.LivroCaixa regLivroCaixa, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("LivroCaixa: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regLivroCaixa == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regLivroCaixa, this, processosReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            var saved = writer.Write(regLivroCaixa, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
            return reader.Read(saved.ID, oCnn);
        });
    }

    public async Task<LivroCaixaResponse?> Validation([FromBody] Models.LivroCaixa regLivroCaixa, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("LivroCaixa: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regLivroCaixa == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regLivroCaixa, this, processosReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            if (regLivroCaixa.Id.IsEmptyIDNumber())
            {
                return new LivroCaixaResponse();
            }

            return reader.Read(regLivroCaixa.Id, oCnn);
        });
    }

    public async Task<LivroCaixaResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("LivroCaixa: URI inválida");
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

            var deleteValidation = await validation.CanDelete(id, this, livrocaixaclientesService, uri, oCnn);
            if (deleteValidation.Length > 0)
            {
                throw new Exception(deleteValidation);
            }

            var livrocaixa = reader.Read(id, oCnn);
            try
            {
                if (livrocaixa != null)
                {
                    writer.Delete(livrocaixa, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
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

            return livrocaixa;
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

    private static (string where, List<SqlParameter> parametros)? WFiltro(Filters.FilterLivroCaixa filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var parameters = new List<SqlParameter>();
        if (filtro.IDDes != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBLivroCaixaDicInfo.IDDes)}", filtro.IDDes));
        }

        if (filtro.Pessoal != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBLivroCaixaDicInfo.Pessoal)}", filtro.Pessoal));
        }

        if (filtro.IDHon != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBLivroCaixaDicInfo.IDHon)}", filtro.IDHon));
        }

        if (filtro.IDHonParc != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBLivroCaixaDicInfo.IDHonParc)}", filtro.IDHonParc));
        }

        if (filtro.Processo != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBLivroCaixaDicInfo.Processo)}", filtro.Processo));
        }

        if (!string.IsNullOrEmpty(filtro.Historico))
        {
            parameters.Add(new($"@{nameof(DBLivroCaixaDicInfo.Historico)}", filtro.Historico));
        }

        if (filtro.Grupo != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBLivroCaixaDicInfo.Grupo)}", filtro.Grupo));
        }

        var cWhere = filtro.IDDes == int.MinValue ? string.Empty : $"{DBLivroCaixaDicInfo.IDDes} = @{nameof(DBLivroCaixaDicInfo.IDDes)}";
        cWhere += filtro.Pessoal == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBLivroCaixaDicInfo.Pessoal} = @{nameof(DBLivroCaixaDicInfo.Pessoal)}";
        cWhere += filtro.IDHon == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBLivroCaixaDicInfo.IDHon} = @{nameof(DBLivroCaixaDicInfo.IDHon)}";
        cWhere += filtro.IDHonParc == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBLivroCaixaDicInfo.IDHonParc} = @{nameof(DBLivroCaixaDicInfo.IDHonParc)}";
        cWhere += filtro.Processo == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBLivroCaixaDicInfo.Processo} = @{nameof(DBLivroCaixaDicInfo.Processo)}";
        cWhere += filtro.Historico.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBLivroCaixaDicInfo.Historico} = @{nameof(DBLivroCaixaDicInfo.Historico)}";
        cWhere += filtro.Grupo == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBLivroCaixaDicInfo.Grupo} = @{nameof(DBLivroCaixaDicInfo.Grupo)}";
        return (cWhere, parameters);
    }
}