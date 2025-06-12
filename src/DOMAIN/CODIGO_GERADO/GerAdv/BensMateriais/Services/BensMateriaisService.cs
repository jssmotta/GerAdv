#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class BensMateriaisService(IOptions<AppSettings> appSettings, IBensMateriaisReader reader, IBensMateriaisValidation validation, IBensMateriaisWriter writer, IBensClassificacaoReader bensclassificacaoReader, IFornecedoresReader fornecedoresReader, ICidadeReader cidadeReader, IHttpContextAccessor httpContextAccessor, HybridCache cache, IMemoryCache memory) : IBensMateriaisService, IDisposable
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly IOptions<AppSettings> _appSettings = appSettings;
    private readonly HybridCache _cache = cache;
    private readonly IMemoryCache _memoryCache = memory;
    private bool _disposed;
    public async Task<IEnumerable<BensMateriaisResponseAll>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("BensMateriais: URI inválida");
            }
        }

        var cacheKey = $"{uri}-BensMateriais-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, string.Empty, [], uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<BensMateriaisResponseAll>> GetDataAllAsync(int max, string where, List<SqlParameter> parameters, string uri, CancellationToken token)
    {
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        if (oCnn == null)
        {
            throw new Exception("Conexão nula.");
        }

        var query = $@"SELECT TOP ({max})
                   {DBBensMateriais.SensivelCamposSqlX}, bcsNome,forNome,cidNome
                   FROM {DBBensMateriais.PTabelaNome.dbo(oCnn)} (NOLOCK)
                   LEFT JOIN {"BensClassificacao".dbo(oCnn)} (NOLOCK) ON bcsCodigo=bmtBensClassificacao
LEFT JOIN {"Fornecedores".dbo(oCnn)} (NOLOCK) ON forCodigo=bmtFornecedor
LEFT JOIN {"Cidade".dbo(oCnn)} (NOLOCK) ON cidCodigo=bmtCidade
 
                   {where}
                   ORDER BY bmtNome
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var lista = new List<BensMateriaisResponseAll>(max);
        var ds = await ConfiguracoesDBT.GetDataTable2Async(query, parameters, oCnn);
        if (ds != null)
            foreach (DataRow item in ds.Rows)
            {
                var dbRec = new DBBensMateriais(item);
                if (dbRec.ID.IsEmptyIDNumber())
                {
                    continue;
                }

                var bensmateriais = reader.ReadAll(dbRec, item);
                if (bensmateriais != null)
                {
                    lista.Add(bensmateriais);
                }
            }

        return lista;
    }

    public async Task<IEnumerable<BensMateriaisResponseAll>> Filter(Filters.FilterBensMateriais filtro, [FromRoute, Required] string uri)
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
        var cacheKey = $"{uri}-BensMateriais-Filter-{where.GetHashCode()}{parameters.GetHashCode()}{keyCache}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(BaseConsts.PMaxItens, string.IsNullOrEmpty(where) ? string.Empty : TSql.Where + where, parameters, uri, cancel), entryOptions, cancellationToken: new());
    }

    public async Task<BensMateriaisResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (id < 1)
        {
            return new BensMateriaisResponse();
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
            var result = await _cache.GetOrCreateAsync($"{uri}-BensMateriais-GetById-{id}-{keyCache}", async cancel => await GetDataByIdAsync(id, oCnn, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"BensMateriais - {uri}-: GetById");
        }
    }

    private async Task<BensMateriaisResponse?> GetDataByIdAsync(int id, MsiSqlConnection oCnn, CancellationToken token) => await Task.Run(() => reader.Read(id, oCnn));
    public async Task<BensMateriaisResponse?> AddAndUpdate([FromBody] Models.BensMateriais regBensMateriais, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("BensMateriais: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regBensMateriais == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regBensMateriais, this, bensclassificacaoReader, fornecedoresReader, cidadeReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception($"BensMateriais: {validade}");
            }

            var saved = writer.Write(regBensMateriais, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
            return reader.Read(saved.ID, oCnn);
        });
    }

    public async Task<BensMateriaisResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("BensMateriais: URI inválida");
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

            var bensmateriais = reader.Read(id, oCnn);
            try
            {
                if (bensmateriais != null)
                {
                    writer.Delete(bensmateriais, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
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

            return bensmateriais;
        });
    }

    public async Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterBensMateriais? filtro, [FromRoute, Required] string uri, CancellationToken token)
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
        var cacheKey = $"{uri}-BensMateriais-{max}-{where.GetHashCode()}-GetListN-{keyCache}";
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
            foreach (var item in reader.ListarN(max, uri, where, parameters, DBBensMateriaisDicInfo.CampoNome))
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

    private static (string where, List<SqlParameter> parametros)? WFiltro(Filters.FilterBensMateriais filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var parameters = new List<SqlParameter>();
        if (!string.IsNullOrEmpty(filtro.Nome))
        {
            parameters.Add(new($"@{nameof(DBBensMateriaisDicInfo.Nome)}", filtro.Nome));
        }

        if (filtro.BensClassificacao != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBBensMateriaisDicInfo.BensClassificacao)}", filtro.BensClassificacao));
        }

        if (!string.IsNullOrEmpty(filtro.NFNRO))
        {
            parameters.Add(new($"@{nameof(DBBensMateriaisDicInfo.NFNRO)}", filtro.NFNRO));
        }

        if (filtro.Fornecedor != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBBensMateriaisDicInfo.Fornecedor)}", filtro.Fornecedor));
        }

        if (!string.IsNullOrEmpty(filtro.NroSerieProduto))
        {
            parameters.Add(new($"@{nameof(DBBensMateriaisDicInfo.NroSerieProduto)}", filtro.NroSerieProduto));
        }

        if (!string.IsNullOrEmpty(filtro.Comprador))
        {
            parameters.Add(new($"@{nameof(DBBensMateriaisDicInfo.Comprador)}", filtro.Comprador));
        }

        if (filtro.Cidade != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBBensMateriaisDicInfo.Cidade)}", filtro.Cidade));
        }

        if (!string.IsNullOrEmpty(filtro.Observacoes))
        {
            parameters.Add(new($"@{nameof(DBBensMateriaisDicInfo.Observacoes)}", filtro.Observacoes));
        }

        if (!string.IsNullOrEmpty(filtro.NomeVendedor))
        {
            parameters.Add(new($"@{nameof(DBBensMateriaisDicInfo.NomeVendedor)}", filtro.NomeVendedor));
        }

        if (!string.IsNullOrEmpty(filtro.GUID))
        {
            parameters.Add(new($"@{nameof(DBBensMateriaisDicInfo.GUID)}", filtro.GUID));
        }

        var cWhere = filtro.Nome.IsEmpty() ? string.Empty : $"{DBBensMateriaisDicInfo.Nome} = @{nameof(DBBensMateriaisDicInfo.Nome)}";
        cWhere += filtro.BensClassificacao == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBBensMateriaisDicInfo.BensClassificacao} = @{nameof(DBBensMateriaisDicInfo.BensClassificacao)}";
        cWhere += filtro.NFNRO.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBBensMateriaisDicInfo.NFNRO} = @{nameof(DBBensMateriaisDicInfo.NFNRO)}";
        cWhere += filtro.Fornecedor == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBBensMateriaisDicInfo.Fornecedor} = @{nameof(DBBensMateriaisDicInfo.Fornecedor)}";
        cWhere += filtro.NroSerieProduto.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBBensMateriaisDicInfo.NroSerieProduto} = @{nameof(DBBensMateriaisDicInfo.NroSerieProduto)}";
        cWhere += filtro.Comprador.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBBensMateriaisDicInfo.Comprador} = @{nameof(DBBensMateriaisDicInfo.Comprador)}";
        cWhere += filtro.Cidade == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBBensMateriaisDicInfo.Cidade} = @{nameof(DBBensMateriaisDicInfo.Cidade)}";
        cWhere += filtro.Observacoes.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBBensMateriaisDicInfo.Observacoes} = @{nameof(DBBensMateriaisDicInfo.Observacoes)}";
        cWhere += filtro.NomeVendedor.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBBensMateriaisDicInfo.NomeVendedor} = @{nameof(DBBensMateriaisDicInfo.NomeVendedor)}";
        cWhere += filtro.GUID.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBBensMateriaisDicInfo.GUID} = @{nameof(DBBensMateriaisDicInfo.GUID)}";
        return (cWhere, parameters);
    }
}