#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class EscritoriosService(IOptions<AppSettings> appSettings, IEscritoriosReader reader, IEscritoriosValidation validation, IEscritoriosWriter writer, ICidadeReader cidadeReader, IAdvogadosService advogadosService, IHttpContextAccessor httpContextAccessor, HybridCache cache, IMemoryCache memory) : IEscritoriosService, IDisposable
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly IOptions<AppSettings> _appSettings = appSettings;
    private readonly HybridCache _cache = cache;
    private readonly IMemoryCache _memoryCache = memory;
    private bool _disposed;
    public async Task<IEnumerable<EscritoriosResponseAll>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("Escritorios: URI inválida");
            }
        }

        var cacheKey = $"{uri}-Escritorios-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, string.Empty, [], uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<EscritoriosResponseAll>> GetDataAllAsync(int max, string where, List<SqlParameter> parameters, string uri, CancellationToken token)
    {
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        if (oCnn == null)
        {
            throw new Exception("Conexão nula.");
        }

        var query = $@"SELECT TOP ({max})
                   {DBEscritorios.SensivelCamposSqlX}, [Cidade].[cidNome]
                   FROM {DBEscritorios.PTabelaNome.dbo(oCnn)} (NOLOCK)
                   LEFT JOIN {"Cidade".dbo(oCnn)} (NOLOCK) ON [Cidade].[cidCodigo]=[Escritorios].[escCidade]
 
                   {where}
                   ORDER BY [Escritorios].[escNome]
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var lista = new List<EscritoriosResponseAll>(max);
        var ds = await ConfiguracoesDBT.GetDataTable2Async(query, parameters, oCnn);
        if (ds != null)
            foreach (DataRow item in ds.Rows)
            {
                var dbRec = new DBEscritorios(item);
                if (dbRec.ID.IsEmptyIDNumber())
                {
                    continue;
                }

                var escritorios = reader.ReadAll(dbRec, item);
                if (escritorios != null)
                {
                    lista.Add(escritorios);
                }
            }

        return lista;
    }

    public async Task<IEnumerable<EscritoriosResponseAll>> Filter(Filters.FilterEscritorios filtro, [FromRoute, Required] string uri)
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
        var cacheKey = $"{uri}-Escritorios-Filter-{where.GetHashCode()}{parameters.GetHashCode()}{keyCache}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(BaseConsts.PMaxItens, string.IsNullOrEmpty(where) ? string.Empty : TSql.Where + where, parameters, uri, cancel), entryOptions, cancellationToken: new());
    }

    public async Task<EscritoriosResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (id < 1)
        {
            return new EscritoriosResponse();
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
            var result = await _cache.GetOrCreateAsync($"{uri}-Escritorios-GetById-{id}-{keyCache}", async cancel => await GetDataByIdAsync(id, oCnn, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"Escritorios - {uri}-: GetById");
        }
    }

    private async Task<EscritoriosResponse?> GetDataByIdAsync(int id, MsiSqlConnection oCnn, CancellationToken token) => await Task.Run(() => reader.Read(id, oCnn));
    public async Task<EscritoriosResponse?> AddAndUpdate([FromBody] Models.Escritorios regEscritorios, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("Escritorios: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regEscritorios == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regEscritorios, this, cidadeReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            var saved = writer.Write(regEscritorios, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
            return reader.Read(saved, oCnn);
        });
    }

    public async Task<EscritoriosResponse?> Validation([FromBody] Models.Escritorios regEscritorios, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("Escritorios: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regEscritorios == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regEscritorios, this, cidadeReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            if (regEscritorios.Id.IsEmptyIDNumber())
            {
                return new EscritoriosResponse();
            }

            return reader.Read(regEscritorios.Id, oCnn);
        });
    }

    public async Task<EscritoriosResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("Escritorios: URI inválida");
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

            var deleteValidation = await validation.CanDelete(id, this, advogadosService, uri, oCnn);
            if (deleteValidation.Length > 0)
            {
                throw new Exception(deleteValidation);
            }

            var escritorios = reader.Read(id, oCnn);
            try
            {
                if (escritorios != null)
                {
                    writer.Delete(escritorios, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
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

            return escritorios;
        });
    }

    public async Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterEscritorios? filtro, [FromRoute, Required] string uri, CancellationToken token)
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
        var cacheKey = $"{uri}-Escritorios-{max}-{where.GetHashCode()}-GetListN-{keyCache}";
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
            foreach (var item in reader.ListarN(max, uri, where, parameters, DBEscritoriosDicInfo.CampoNome))
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

    private static (string where, List<SqlParameter> parametros)? WFiltro(Filters.FilterEscritorios filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var parameters = new List<SqlParameter>();
        if (!string.IsNullOrEmpty(filtro.CNPJ))
        {
            parameters.Add(new($"@{nameof(DBEscritoriosDicInfo.CNPJ)}", filtro.CNPJ));
        }

        if (!string.IsNullOrEmpty(filtro.Nome))
        {
            parameters.Add(new($"@{nameof(DBEscritoriosDicInfo.Nome)}", filtro.Nome));
        }

        if (!string.IsNullOrEmpty(filtro.OAB))
        {
            parameters.Add(new($"@{nameof(DBEscritoriosDicInfo.OAB)}", filtro.OAB));
        }

        if (!string.IsNullOrEmpty(filtro.Endereco))
        {
            parameters.Add(new($"@{nameof(DBEscritoriosDicInfo.Endereco)}", filtro.Endereco));
        }

        if (filtro.Cidade != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBEscritoriosDicInfo.Cidade)}", filtro.Cidade));
        }

        if (!string.IsNullOrEmpty(filtro.Bairro))
        {
            parameters.Add(new($"@{nameof(DBEscritoriosDicInfo.Bairro)}", filtro.Bairro));
        }

        if (!string.IsNullOrEmpty(filtro.CEP))
        {
            parameters.Add(new($"@{nameof(DBEscritoriosDicInfo.CEP)}", filtro.CEP));
        }

        if (!string.IsNullOrEmpty(filtro.Fone))
        {
            parameters.Add(new($"@{nameof(DBEscritoriosDicInfo.Fone)}", filtro.Fone));
        }

        if (!string.IsNullOrEmpty(filtro.Fax))
        {
            parameters.Add(new($"@{nameof(DBEscritoriosDicInfo.Fax)}", filtro.Fax));
        }

        if (!string.IsNullOrEmpty(filtro.Site))
        {
            parameters.Add(new($"@{nameof(DBEscritoriosDicInfo.Site)}", filtro.Site));
        }

        if (!string.IsNullOrEmpty(filtro.EMail))
        {
            parameters.Add(new($"@{nameof(DBEscritoriosDicInfo.EMail)}", filtro.EMail));
        }

        if (!string.IsNullOrEmpty(filtro.OBS))
        {
            parameters.Add(new($"@{nameof(DBEscritoriosDicInfo.OBS)}", filtro.OBS));
        }

        if (!string.IsNullOrEmpty(filtro.AdvResponsavel))
        {
            parameters.Add(new($"@{nameof(DBEscritoriosDicInfo.AdvResponsavel)}", filtro.AdvResponsavel));
        }

        if (!string.IsNullOrEmpty(filtro.Secretaria))
        {
            parameters.Add(new($"@{nameof(DBEscritoriosDicInfo.Secretaria)}", filtro.Secretaria));
        }

        if (!string.IsNullOrEmpty(filtro.InscEst))
        {
            parameters.Add(new($"@{nameof(DBEscritoriosDicInfo.InscEst)}", filtro.InscEst));
        }

        if (!string.IsNullOrEmpty(filtro.GUID))
        {
            parameters.Add(new($"@{nameof(DBEscritoriosDicInfo.GUID)}", filtro.GUID));
        }

        var cWhere = filtro.CNPJ.IsEmpty() ? string.Empty : $"{DBEscritoriosDicInfo.CNPJ} = @{nameof(DBEscritoriosDicInfo.CNPJ)}";
        cWhere += filtro.Nome.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBEscritoriosDicInfo.Nome} = @{nameof(DBEscritoriosDicInfo.Nome)}";
        cWhere += filtro.OAB.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBEscritoriosDicInfo.OAB} = @{nameof(DBEscritoriosDicInfo.OAB)}";
        cWhere += filtro.Endereco.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBEscritoriosDicInfo.Endereco} = @{nameof(DBEscritoriosDicInfo.Endereco)}";
        cWhere += filtro.Cidade == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBEscritoriosDicInfo.Cidade} = @{nameof(DBEscritoriosDicInfo.Cidade)}";
        cWhere += filtro.Bairro.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBEscritoriosDicInfo.Bairro} = @{nameof(DBEscritoriosDicInfo.Bairro)}";
        cWhere += filtro.CEP.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBEscritoriosDicInfo.CEP} = @{nameof(DBEscritoriosDicInfo.CEP)}";
        cWhere += filtro.Fone.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBEscritoriosDicInfo.Fone} = @{nameof(DBEscritoriosDicInfo.Fone)}";
        cWhere += filtro.Fax.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBEscritoriosDicInfo.Fax} = @{nameof(DBEscritoriosDicInfo.Fax)}";
        cWhere += filtro.Site.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBEscritoriosDicInfo.Site} = @{nameof(DBEscritoriosDicInfo.Site)}";
        cWhere += filtro.EMail.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBEscritoriosDicInfo.EMail} = @{nameof(DBEscritoriosDicInfo.EMail)}";
        cWhere += filtro.OBS.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBEscritoriosDicInfo.OBS} = @{nameof(DBEscritoriosDicInfo.OBS)}";
        cWhere += filtro.AdvResponsavel.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBEscritoriosDicInfo.AdvResponsavel} = @{nameof(DBEscritoriosDicInfo.AdvResponsavel)}";
        cWhere += filtro.Secretaria.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBEscritoriosDicInfo.Secretaria} = @{nameof(DBEscritoriosDicInfo.Secretaria)}";
        cWhere += filtro.InscEst.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBEscritoriosDicInfo.InscEst} = @{nameof(DBEscritoriosDicInfo.InscEst)}";
        cWhere += filtro.GUID.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBEscritoriosDicInfo.GUID} = @{nameof(DBEscritoriosDicInfo.GUID)}";
        return (cWhere, parameters);
    }
}