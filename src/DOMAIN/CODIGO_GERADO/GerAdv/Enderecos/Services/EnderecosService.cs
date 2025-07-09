#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class EnderecosService(IOptions<AppSettings> appSettings, IEnderecosReader reader, IEnderecosValidation validation, IEnderecosWriter writer, ICidadeReader cidadeReader, IHttpContextAccessor httpContextAccessor, HybridCache cache, IMemoryCache memory) : IEnderecosService, IDisposable
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly IOptions<AppSettings> _appSettings = appSettings;
    private readonly HybridCache _cache = cache;
    private readonly IMemoryCache _memoryCache = memory;
    private bool _disposed;
    public async Task<IEnumerable<EnderecosResponseAll>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("Enderecos: URI inválida");
            }
        }

        var cacheKey = $"{uri}-Enderecos-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, string.Empty, [], uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<EnderecosResponseAll>> GetDataAllAsync(int max, string where, List<SqlParameter> parameters, string uri, CancellationToken token)
    {
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        if (oCnn == null)
        {
            throw new Exception("Conexão nula.");
        }

        var query = $@"SELECT TOP ({max})
                   {DBEnderecos.SensivelCamposSqlX}, [Cidade].[cidNome]
                   FROM {DBEnderecos.PTabelaNome.dbo(oCnn)} (NOLOCK)
                   LEFT JOIN {"Cidade".dbo(oCnn)} (NOLOCK) ON [Cidade].[cidCodigo]=[Enderecos].[endCidade]
 
                   {where}
                   ORDER BY [Enderecos].[endDescricao]
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var lista = new List<EnderecosResponseAll>(max);
        var ds = await ConfiguracoesDBT.GetDataTable2Async(query, parameters, oCnn);
        if (ds != null)
            foreach (DataRow item in ds.Rows)
            {
                var dbRec = new DBEnderecos(item);
                if (dbRec.ID.IsEmptyIDNumber())
                {
                    continue;
                }

                var enderecos = reader.ReadAll(dbRec, item);
                if (enderecos != null)
                {
                    lista.Add(enderecos);
                }
            }

        return lista;
    }

    public async Task<IEnumerable<EnderecosResponseAll>> Filter(Filters.FilterEnderecos filtro, [FromRoute, Required] string uri)
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
        var cacheKey = $"{uri}-Enderecos-Filter-{where.GetHashCode()}{parameters.GetHashCode()}{keyCache}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(BaseConsts.PMaxItens, string.IsNullOrEmpty(where) ? string.Empty : TSql.Where + where, parameters, uri, cancel), entryOptions, cancellationToken: new());
    }

    public async Task<EnderecosResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (id < 1)
        {
            return new EnderecosResponse();
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
            var result = await _cache.GetOrCreateAsync($"{uri}-Enderecos-GetById-{id}-{keyCache}", async cancel => await GetDataByIdAsync(id, oCnn, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"Enderecos - {uri}-: GetById");
        }
    }

    private async Task<EnderecosResponse?> GetDataByIdAsync(int id, MsiSqlConnection oCnn, CancellationToken token) => await Task.Run(() => reader.Read(id, oCnn));
    public async Task<EnderecosResponse?> AddAndUpdate([FromBody] Models.Enderecos regEnderecos, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("Enderecos: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regEnderecos == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regEnderecos, this, cidadeReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            var saved = writer.Write(regEnderecos, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
            return reader.Read(saved, oCnn);
        });
    }

    public async Task<EnderecosResponse?> Validation([FromBody] Models.Enderecos regEnderecos, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("Enderecos: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regEnderecos == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regEnderecos, this, cidadeReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            if (regEnderecos.Id.IsEmptyIDNumber())
            {
                return new EnderecosResponse();
            }

            return reader.Read(regEnderecos.Id, oCnn);
        });
    }

    public async Task<EnderecosResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("Enderecos: URI inválida");
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

            var enderecos = reader.Read(id, oCnn);
            try
            {
                if (enderecos != null)
                {
                    writer.Delete(enderecos, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
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

            return enderecos;
        });
    }

    public async Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterEnderecos? filtro, [FromRoute, Required] string uri, CancellationToken token)
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
        var cacheKey = $"{uri}-Enderecos-{max}-{where.GetHashCode()}-GetListN-{keyCache}";
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
            foreach (var item in reader.ListarN(max, uri, where, parameters, DBEnderecosDicInfo.CampoNome))
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

    private static (string where, List<SqlParameter> parametros)? WFiltro(Filters.FilterEnderecos filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var parameters = new List<SqlParameter>();
        if (!string.IsNullOrEmpty(filtro.Descricao))
        {
            parameters.Add(new($"@{nameof(DBEnderecosDicInfo.Descricao)}", filtro.Descricao));
        }

        if (!string.IsNullOrEmpty(filtro.Contato))
        {
            parameters.Add(new($"@{nameof(DBEnderecosDicInfo.Contato)}", filtro.Contato));
        }

        if (!string.IsNullOrEmpty(filtro.Endereco))
        {
            parameters.Add(new($"@{nameof(DBEnderecosDicInfo.Endereco)}", filtro.Endereco));
        }

        if (!string.IsNullOrEmpty(filtro.Bairro))
        {
            parameters.Add(new($"@{nameof(DBEnderecosDicInfo.Bairro)}", filtro.Bairro));
        }

        if (!string.IsNullOrEmpty(filtro.CEP))
        {
            parameters.Add(new($"@{nameof(DBEnderecosDicInfo.CEP)}", filtro.CEP));
        }

        if (!string.IsNullOrEmpty(filtro.OAB))
        {
            parameters.Add(new($"@{nameof(DBEnderecosDicInfo.OAB)}", filtro.OAB));
        }

        if (!string.IsNullOrEmpty(filtro.OBS))
        {
            parameters.Add(new($"@{nameof(DBEnderecosDicInfo.OBS)}", filtro.OBS));
        }

        if (!string.IsNullOrEmpty(filtro.Fone))
        {
            parameters.Add(new($"@{nameof(DBEnderecosDicInfo.Fone)}", filtro.Fone));
        }

        if (!string.IsNullOrEmpty(filtro.Fax))
        {
            parameters.Add(new($"@{nameof(DBEnderecosDicInfo.Fax)}", filtro.Fax));
        }

        if (!string.IsNullOrEmpty(filtro.Tratamento))
        {
            parameters.Add(new($"@{nameof(DBEnderecosDicInfo.Tratamento)}", filtro.Tratamento));
        }

        if (filtro.Cidade != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBEnderecosDicInfo.Cidade)}", filtro.Cidade));
        }

        if (!string.IsNullOrEmpty(filtro.Site))
        {
            parameters.Add(new($"@{nameof(DBEnderecosDicInfo.Site)}", filtro.Site));
        }

        if (!string.IsNullOrEmpty(filtro.EMail))
        {
            parameters.Add(new($"@{nameof(DBEnderecosDicInfo.EMail)}", filtro.EMail));
        }

        if (filtro.Quem != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBEnderecosDicInfo.Quem)}", filtro.Quem));
        }

        if (!string.IsNullOrEmpty(filtro.QuemIndicou))
        {
            parameters.Add(new($"@{nameof(DBEnderecosDicInfo.QuemIndicou)}", filtro.QuemIndicou));
        }

        if (!string.IsNullOrEmpty(filtro.GUID))
        {
            parameters.Add(new($"@{nameof(DBEnderecosDicInfo.GUID)}", filtro.GUID));
        }

        var cWhere = filtro.Descricao.IsEmpty() ? string.Empty : $"{DBEnderecosDicInfo.Descricao} = @{nameof(DBEnderecosDicInfo.Descricao)}";
        cWhere += filtro.Contato.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBEnderecosDicInfo.Contato} = @{nameof(DBEnderecosDicInfo.Contato)}";
        cWhere += filtro.Endereco.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBEnderecosDicInfo.Endereco} = @{nameof(DBEnderecosDicInfo.Endereco)}";
        cWhere += filtro.Bairro.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBEnderecosDicInfo.Bairro} = @{nameof(DBEnderecosDicInfo.Bairro)}";
        cWhere += filtro.CEP.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBEnderecosDicInfo.CEP} = @{nameof(DBEnderecosDicInfo.CEP)}";
        cWhere += filtro.OAB.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBEnderecosDicInfo.OAB} = @{nameof(DBEnderecosDicInfo.OAB)}";
        cWhere += filtro.OBS.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBEnderecosDicInfo.OBS} = @{nameof(DBEnderecosDicInfo.OBS)}";
        cWhere += filtro.Fone.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBEnderecosDicInfo.Fone} = @{nameof(DBEnderecosDicInfo.Fone)}";
        cWhere += filtro.Fax.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBEnderecosDicInfo.Fax} = @{nameof(DBEnderecosDicInfo.Fax)}";
        cWhere += filtro.Tratamento.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBEnderecosDicInfo.Tratamento} = @{nameof(DBEnderecosDicInfo.Tratamento)}";
        cWhere += filtro.Cidade == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBEnderecosDicInfo.Cidade} = @{nameof(DBEnderecosDicInfo.Cidade)}";
        cWhere += filtro.Site.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBEnderecosDicInfo.Site} = @{nameof(DBEnderecosDicInfo.Site)}";
        cWhere += filtro.EMail.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBEnderecosDicInfo.EMail} = @{nameof(DBEnderecosDicInfo.EMail)}";
        cWhere += filtro.Quem == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBEnderecosDicInfo.Quem} = @{nameof(DBEnderecosDicInfo.Quem)}";
        cWhere += filtro.QuemIndicou.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBEnderecosDicInfo.QuemIndicou} = @{nameof(DBEnderecosDicInfo.QuemIndicou)}";
        cWhere += filtro.GUID.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBEnderecosDicInfo.GUID} = @{nameof(DBEnderecosDicInfo.GUID)}";
        return (cWhere, parameters);
    }
}