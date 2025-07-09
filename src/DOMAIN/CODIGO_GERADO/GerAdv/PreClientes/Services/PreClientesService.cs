#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class PreClientesService(IOptions<AppSettings> appSettings, IPreClientesReader reader, IPreClientesValidation validation, IPreClientesWriter writer, IClientesReader clientesReader, ICidadeReader cidadeReader, IHttpContextAccessor httpContextAccessor, HybridCache cache, IMemoryCache memory) : IPreClientesService, IDisposable
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly IOptions<AppSettings> _appSettings = appSettings;
    private readonly HybridCache _cache = cache;
    private readonly IMemoryCache _memoryCache = memory;
    private bool _disposed;
    public async Task<IEnumerable<PreClientesResponseAll>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("PreClientes: URI inválida");
            }
        }

        var cacheKey = $"{uri}-PreClientes-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, string.Empty, [], uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<PreClientesResponseAll>> GetDataAllAsync(int max, string where, List<SqlParameter> parameters, string uri, CancellationToken token)
    {
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        if (oCnn == null)
        {
            throw new Exception("Conexão nula.");
        }

        var query = $@"SELECT TOP ({max})
                   {DBPreClientes.SensivelCamposSqlX}, [Clientes].[cliNome],[Cidade].[cidNome]
                   FROM {DBPreClientes.PTabelaNome.dbo(oCnn)} (NOLOCK)
                   LEFT JOIN {"Clientes".dbo(oCnn)} (NOLOCK) ON [Clientes].[cliCodigo]=[PreClientes].[cliIDRep]
LEFT JOIN {"Cidade".dbo(oCnn)} (NOLOCK) ON [Cidade].[cidCodigo]=[PreClientes].[cliCidade]
 
                   {where}
                   ORDER BY [PreClientes].[cliNome]
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var lista = new List<PreClientesResponseAll>(max);
        var ds = await ConfiguracoesDBT.GetDataTable2Async(query, parameters, oCnn);
        if (ds != null)
            foreach (DataRow item in ds.Rows)
            {
                var dbRec = new DBPreClientes(item);
                if (dbRec.ID.IsEmptyIDNumber())
                {
                    continue;
                }

                var preclientes = reader.ReadAll(dbRec, item);
                if (preclientes != null)
                {
                    lista.Add(preclientes);
                }
            }

        return lista;
    }

    public async Task<IEnumerable<PreClientesResponseAll>> Filter(Filters.FilterPreClientes filtro, [FromRoute, Required] string uri)
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
        var cacheKey = $"{uri}-PreClientes-Filter-{where.GetHashCode()}{parameters.GetHashCode()}{keyCache}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(BaseConsts.PMaxItens, string.IsNullOrEmpty(where) ? string.Empty : TSql.Where + where, parameters, uri, cancel), entryOptions, cancellationToken: new());
    }

    public async Task<PreClientesResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (id < 1)
        {
            return new PreClientesResponse();
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
            var result = await _cache.GetOrCreateAsync($"{uri}-PreClientes-GetById-{id}-{keyCache}", async cancel => await GetDataByIdAsync(id, oCnn, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"PreClientes - {uri}-: GetById");
        }
    }

    private async Task<PreClientesResponse?> GetDataByIdAsync(int id, MsiSqlConnection oCnn, CancellationToken token) => await Task.Run(() => reader.Read(id, oCnn));
    public async Task<PreClientesResponse?> AddAndUpdate([FromBody] Models.PreClientes regPreClientes, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("PreClientes: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regPreClientes == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regPreClientes, this, clientesReader, cidadeReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            var saved = writer.Write(regPreClientes, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
            return reader.Read(saved, oCnn);
        });
    }

    public async Task<PreClientesResponse?> Validation([FromBody] Models.PreClientes regPreClientes, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("PreClientes: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regPreClientes == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regPreClientes, this, clientesReader, cidadeReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            if (regPreClientes.Id.IsEmptyIDNumber())
            {
                return new PreClientesResponse();
            }

            return reader.Read(regPreClientes.Id, oCnn);
        });
    }

    public async Task<PreClientesResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("PreClientes: URI inválida");
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

            var preclientes = reader.Read(id, oCnn);
            try
            {
                if (preclientes != null)
                {
                    writer.Delete(preclientes, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
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

            return preclientes;
        });
    }

    public async Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterPreClientes? filtro, [FromRoute, Required] string uri, CancellationToken token)
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
        var cacheKey = $"{uri}-PreClientes-{max}-{where.GetHashCode()}-GetListN-{keyCache}";
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
            foreach (var item in reader.ListarN(max, uri, where, parameters, DBPreClientesDicInfo.CampoNome))
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

    private static (string where, List<SqlParameter> parametros)? WFiltro(Filters.FilterPreClientes filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var parameters = new List<SqlParameter>();
        if (!string.IsNullOrEmpty(filtro.QuemIndicou))
        {
            parameters.Add(new($"@{nameof(DBPreClientesDicInfo.QuemIndicou)}", filtro.QuemIndicou));
        }

        if (!string.IsNullOrEmpty(filtro.Nome))
        {
            parameters.Add(new($"@{nameof(DBPreClientesDicInfo.Nome)}", filtro.Nome));
        }

        if (filtro.Adv != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBPreClientesDicInfo.Adv)}", filtro.Adv));
        }

        if (filtro.IDRep != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBPreClientesDicInfo.IDRep)}", filtro.IDRep));
        }

        if (!string.IsNullOrEmpty(filtro.NomeFantasia))
        {
            parameters.Add(new($"@{nameof(DBPreClientesDicInfo.NomeFantasia)}", filtro.NomeFantasia));
        }

        if (!string.IsNullOrEmpty(filtro.Class))
        {
            parameters.Add(new($"@{nameof(DBPreClientesDicInfo.Class)}", filtro.Class));
        }

        if (!string.IsNullOrEmpty(filtro.InscEst))
        {
            parameters.Add(new($"@{nameof(DBPreClientesDicInfo.InscEst)}", filtro.InscEst));
        }

        if (!string.IsNullOrEmpty(filtro.Qualificacao))
        {
            parameters.Add(new($"@{nameof(DBPreClientesDicInfo.Qualificacao)}", filtro.Qualificacao));
        }

        if (filtro.Idade != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBPreClientesDicInfo.Idade)}", filtro.Idade));
        }

        if (!string.IsNullOrEmpty(filtro.CNPJ))
        {
            parameters.Add(new($"@{nameof(DBPreClientesDicInfo.CNPJ)}", filtro.CNPJ));
        }

        if (!string.IsNullOrEmpty(filtro.CPF))
        {
            parameters.Add(new($"@{nameof(DBPreClientesDicInfo.CPF)}", filtro.CPF));
        }

        if (!string.IsNullOrEmpty(filtro.RG))
        {
            parameters.Add(new($"@{nameof(DBPreClientesDicInfo.RG)}", filtro.RG));
        }

        if (!string.IsNullOrEmpty(filtro.Observacao))
        {
            parameters.Add(new($"@{nameof(DBPreClientesDicInfo.Observacao)}", filtro.Observacao));
        }

        if (!string.IsNullOrEmpty(filtro.Endereco))
        {
            parameters.Add(new($"@{nameof(DBPreClientesDicInfo.Endereco)}", filtro.Endereco));
        }

        if (!string.IsNullOrEmpty(filtro.Bairro))
        {
            parameters.Add(new($"@{nameof(DBPreClientesDicInfo.Bairro)}", filtro.Bairro));
        }

        if (filtro.Cidade != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBPreClientesDicInfo.Cidade)}", filtro.Cidade));
        }

        if (!string.IsNullOrEmpty(filtro.CEP))
        {
            parameters.Add(new($"@{nameof(DBPreClientesDicInfo.CEP)}", filtro.CEP));
        }

        if (!string.IsNullOrEmpty(filtro.Fax))
        {
            parameters.Add(new($"@{nameof(DBPreClientesDicInfo.Fax)}", filtro.Fax));
        }

        if (!string.IsNullOrEmpty(filtro.Fone))
        {
            parameters.Add(new($"@{nameof(DBPreClientesDicInfo.Fone)}", filtro.Fone));
        }

        if (!string.IsNullOrEmpty(filtro.HomePage))
        {
            parameters.Add(new($"@{nameof(DBPreClientesDicInfo.HomePage)}", filtro.HomePage));
        }

        if (!string.IsNullOrEmpty(filtro.EMail))
        {
            parameters.Add(new($"@{nameof(DBPreClientesDicInfo.EMail)}", filtro.EMail));
        }

        if (!string.IsNullOrEmpty(filtro.Assistido))
        {
            parameters.Add(new($"@{nameof(DBPreClientesDicInfo.Assistido)}", filtro.Assistido));
        }

        if (!string.IsNullOrEmpty(filtro.AssRG))
        {
            parameters.Add(new($"@{nameof(DBPreClientesDicInfo.AssRG)}", filtro.AssRG));
        }

        if (!string.IsNullOrEmpty(filtro.AssCPF))
        {
            parameters.Add(new($"@{nameof(DBPreClientesDicInfo.AssCPF)}", filtro.AssCPF));
        }

        if (!string.IsNullOrEmpty(filtro.AssEndereco))
        {
            parameters.Add(new($"@{nameof(DBPreClientesDicInfo.AssEndereco)}", filtro.AssEndereco));
        }

        if (!string.IsNullOrEmpty(filtro.CNH))
        {
            parameters.Add(new($"@{nameof(DBPreClientesDicInfo.CNH)}", filtro.CNH));
        }

        var cWhere = filtro.QuemIndicou.IsEmpty() ? string.Empty : $"{DBPreClientesDicInfo.QuemIndicou} = @{nameof(DBPreClientesDicInfo.QuemIndicou)}";
        cWhere += filtro.Nome.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBPreClientesDicInfo.Nome} = @{nameof(DBPreClientesDicInfo.Nome)}";
        cWhere += filtro.Adv == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBPreClientesDicInfo.Adv} = @{nameof(DBPreClientesDicInfo.Adv)}";
        cWhere += filtro.IDRep == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBPreClientesDicInfo.IDRep} = @{nameof(DBPreClientesDicInfo.IDRep)}";
        cWhere += filtro.NomeFantasia.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBPreClientesDicInfo.NomeFantasia} = @{nameof(DBPreClientesDicInfo.NomeFantasia)}";
        cWhere += filtro.Class.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBPreClientesDicInfo.Class} = @{nameof(DBPreClientesDicInfo.Class)}";
        cWhere += filtro.InscEst.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBPreClientesDicInfo.InscEst} = @{nameof(DBPreClientesDicInfo.InscEst)}";
        cWhere += filtro.Qualificacao.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBPreClientesDicInfo.Qualificacao} = @{nameof(DBPreClientesDicInfo.Qualificacao)}";
        cWhere += filtro.Idade == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBPreClientesDicInfo.Idade} = @{nameof(DBPreClientesDicInfo.Idade)}";
        cWhere += filtro.CNPJ.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBPreClientesDicInfo.CNPJ} = @{nameof(DBPreClientesDicInfo.CNPJ)}";
        cWhere += filtro.CPF.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBPreClientesDicInfo.CPF} = @{nameof(DBPreClientesDicInfo.CPF)}";
        cWhere += filtro.RG.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBPreClientesDicInfo.RG} = @{nameof(DBPreClientesDicInfo.RG)}";
        cWhere += filtro.Observacao.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBPreClientesDicInfo.Observacao} = @{nameof(DBPreClientesDicInfo.Observacao)}";
        cWhere += filtro.Endereco.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBPreClientesDicInfo.Endereco} = @{nameof(DBPreClientesDicInfo.Endereco)}";
        cWhere += filtro.Bairro.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBPreClientesDicInfo.Bairro} = @{nameof(DBPreClientesDicInfo.Bairro)}";
        cWhere += filtro.Cidade == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBPreClientesDicInfo.Cidade} = @{nameof(DBPreClientesDicInfo.Cidade)}";
        cWhere += filtro.CEP.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBPreClientesDicInfo.CEP} = @{nameof(DBPreClientesDicInfo.CEP)}";
        cWhere += filtro.Fax.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBPreClientesDicInfo.Fax} = @{nameof(DBPreClientesDicInfo.Fax)}";
        cWhere += filtro.Fone.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBPreClientesDicInfo.Fone} = @{nameof(DBPreClientesDicInfo.Fone)}";
        cWhere += filtro.HomePage.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBPreClientesDicInfo.HomePage} = @{nameof(DBPreClientesDicInfo.HomePage)}";
        cWhere += filtro.EMail.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBPreClientesDicInfo.EMail} = @{nameof(DBPreClientesDicInfo.EMail)}";
        cWhere += filtro.Assistido.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBPreClientesDicInfo.Assistido} = @{nameof(DBPreClientesDicInfo.Assistido)}";
        cWhere += filtro.AssRG.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBPreClientesDicInfo.AssRG} = @{nameof(DBPreClientesDicInfo.AssRG)}";
        cWhere += filtro.AssCPF.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBPreClientesDicInfo.AssCPF} = @{nameof(DBPreClientesDicInfo.AssCPF)}";
        cWhere += filtro.AssEndereco.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBPreClientesDicInfo.AssEndereco} = @{nameof(DBPreClientesDicInfo.AssEndereco)}";
        cWhere += filtro.CNH.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBPreClientesDicInfo.CNH} = @{nameof(DBPreClientesDicInfo.CNH)}";
        return (cWhere, parameters);
    }
}