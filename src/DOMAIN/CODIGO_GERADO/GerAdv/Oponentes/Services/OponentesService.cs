#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class OponentesService(IOptions<AppSettings> appSettings, IOponentesReader reader, IOponentesValidation validation, IOponentesWriter writer, ICidadeReader cidadeReader, IGruposEmpresasService gruposempresasService, IOponentesRepLegalService oponentesreplegalService, IProcessosService processosService, IHttpContextAccessor httpContextAccessor, HybridCache cache, IMemoryCache memory) : IOponentesService, IDisposable
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly IOptions<AppSettings> _appSettings = appSettings;
    private readonly HybridCache _cache = cache;
    private readonly IMemoryCache _memoryCache = memory;
    private bool _disposed;
    public async Task<IEnumerable<OponentesResponseAll>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("Oponentes: URI inválida");
            }
        }

        var cacheKey = $"{uri}-Oponentes-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, string.Empty, [], uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<OponentesResponseAll>> GetDataAllAsync(int max, string where, List<SqlParameter> parameters, string uri, CancellationToken token)
    {
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        if (oCnn == null)
        {
            throw new Exception("Conexão nula.");
        }

        var query = $@"SELECT TOP ({max})
                   {DBOponentes.SensivelCamposSqlX}, [Cidade].[cidNome]
                   FROM {DBOponentes.PTabelaNome.dbo(oCnn)} (NOLOCK)
                   LEFT JOIN {"Cidade".dbo(oCnn)} (NOLOCK) ON [Cidade].[cidCodigo]=[Oponentes].[opoCidade]
 
                   {where}
                   ORDER BY [Oponentes].[opoNome]
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var lista = new List<OponentesResponseAll>(max);
        var ds = await ConfiguracoesDBT.GetDataTable2Async(query, parameters, oCnn);
        if (ds != null)
            foreach (DataRow item in ds.Rows)
            {
                var dbRec = new DBOponentes(item);
                if (dbRec.ID.IsEmptyIDNumber())
                {
                    continue;
                }

                var oponentes = reader.ReadAll(dbRec, item);
                if (oponentes != null)
                {
                    lista.Add(oponentes);
                }
            }

        return lista;
    }

    public async Task<IEnumerable<OponentesResponseAll>> Filter(Filters.FilterOponentes filtro, [FromRoute, Required] string uri)
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
        var cacheKey = $"{uri}-Oponentes-Filter-{where.GetHashCode()}{parameters.GetHashCode()}{keyCache}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(BaseConsts.PMaxItens, string.IsNullOrEmpty(where) ? string.Empty : TSql.Where + where, parameters, uri, cancel), entryOptions, cancellationToken: new());
    }

    public async Task<OponentesResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (id < 1)
        {
            return new OponentesResponse();
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
            var result = await _cache.GetOrCreateAsync($"{uri}-Oponentes-GetById-{id}-{keyCache}", async cancel => await GetDataByIdAsync(id, oCnn, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"Oponentes - {uri}-: GetById");
        }
    }

    private async Task<OponentesResponse?> GetDataByIdAsync(int id, MsiSqlConnection oCnn, CancellationToken token) => await Task.Run(() => reader.Read(id, oCnn));
    public async Task<OponentesResponse?> AddAndUpdate([FromBody] Models.Oponentes regOponentes, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("Oponentes: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regOponentes == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regOponentes, this, cidadeReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            var saved = writer.Write(regOponentes, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
            return reader.Read(saved.ID, oCnn);
        });
    }

    public async Task<OponentesResponse?> Validation([FromBody] Models.Oponentes regOponentes, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("Oponentes: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regOponentes == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regOponentes, this, cidadeReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            if (regOponentes.Id.IsEmptyIDNumber())
            {
                return new OponentesResponse();
            }

            return reader.Read(regOponentes.Id, oCnn);
        });
    }

    public async Task<OponentesResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("Oponentes: URI inválida");
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

            var deleteValidation = await validation.CanDelete(id, this, gruposempresasService, oponentesreplegalService, processosService, uri, oCnn);
            if (deleteValidation.Length > 0)
            {
                throw new Exception(deleteValidation);
            }

            var oponentes = reader.Read(id, oCnn);
            try
            {
                if (oponentes != null)
                {
                    writer.Delete(oponentes, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
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

            return oponentes;
        });
    }

    public async Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterOponentes? filtro, [FromRoute, Required] string uri, CancellationToken token)
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
        var cacheKey = $"{uri}-Oponentes-{max}-{where.GetHashCode()}-GetListN-{keyCache}";
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
            foreach (var item in reader.ListarN(max, uri, where, parameters, DBOponentesDicInfo.CampoNome))
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

    private static (string where, List<SqlParameter> parametros)? WFiltro(Filters.FilterOponentes filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var parameters = new List<SqlParameter>();
        if (filtro.EMPFuncao != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBOponentesDicInfo.EMPFuncao)}", filtro.EMPFuncao));
        }

        if (!string.IsNullOrEmpty(filtro.CTPSNumero))
        {
            parameters.Add(new($"@{nameof(DBOponentesDicInfo.CTPSNumero)}", filtro.CTPSNumero));
        }

        if (!string.IsNullOrEmpty(filtro.Site))
        {
            parameters.Add(new($"@{nameof(DBOponentesDicInfo.Site)}", filtro.Site));
        }

        if (!string.IsNullOrEmpty(filtro.CTPSSerie))
        {
            parameters.Add(new($"@{nameof(DBOponentesDicInfo.CTPSSerie)}", filtro.CTPSSerie));
        }

        if (!string.IsNullOrEmpty(filtro.Nome))
        {
            parameters.Add(new($"@{nameof(DBOponentesDicInfo.Nome)}", filtro.Nome));
        }

        if (filtro.Adv != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBOponentesDicInfo.Adv)}", filtro.Adv));
        }

        if (filtro.EMPCliente != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBOponentesDicInfo.EMPCliente)}", filtro.EMPCliente));
        }

        if (filtro.IDRep != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBOponentesDicInfo.IDRep)}", filtro.IDRep));
        }

        if (!string.IsNullOrEmpty(filtro.PIS))
        {
            parameters.Add(new($"@{nameof(DBOponentesDicInfo.PIS)}", filtro.PIS));
        }

        if (!string.IsNullOrEmpty(filtro.Contato))
        {
            parameters.Add(new($"@{nameof(DBOponentesDicInfo.Contato)}", filtro.Contato));
        }

        if (!string.IsNullOrEmpty(filtro.CNPJ))
        {
            parameters.Add(new($"@{nameof(DBOponentesDicInfo.CNPJ)}", filtro.CNPJ));
        }

        if (!string.IsNullOrEmpty(filtro.RG))
        {
            parameters.Add(new($"@{nameof(DBOponentesDicInfo.RG)}", filtro.RG));
        }

        if (!string.IsNullOrEmpty(filtro.CPF))
        {
            parameters.Add(new($"@{nameof(DBOponentesDicInfo.CPF)}", filtro.CPF));
        }

        if (!string.IsNullOrEmpty(filtro.Endereco))
        {
            parameters.Add(new($"@{nameof(DBOponentesDicInfo.Endereco)}", filtro.Endereco));
        }

        if (!string.IsNullOrEmpty(filtro.Fone))
        {
            parameters.Add(new($"@{nameof(DBOponentesDicInfo.Fone)}", filtro.Fone));
        }

        if (!string.IsNullOrEmpty(filtro.Fax))
        {
            parameters.Add(new($"@{nameof(DBOponentesDicInfo.Fax)}", filtro.Fax));
        }

        if (filtro.Cidade != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBOponentesDicInfo.Cidade)}", filtro.Cidade));
        }

        if (!string.IsNullOrEmpty(filtro.Bairro))
        {
            parameters.Add(new($"@{nameof(DBOponentesDicInfo.Bairro)}", filtro.Bairro));
        }

        if (!string.IsNullOrEmpty(filtro.CEP))
        {
            parameters.Add(new($"@{nameof(DBOponentesDicInfo.CEP)}", filtro.CEP));
        }

        if (!string.IsNullOrEmpty(filtro.InscEst))
        {
            parameters.Add(new($"@{nameof(DBOponentesDicInfo.InscEst)}", filtro.InscEst));
        }

        if (!string.IsNullOrEmpty(filtro.Observacao))
        {
            parameters.Add(new($"@{nameof(DBOponentesDicInfo.Observacao)}", filtro.Observacao));
        }

        if (!string.IsNullOrEmpty(filtro.EMail))
        {
            parameters.Add(new($"@{nameof(DBOponentesDicInfo.EMail)}", filtro.EMail));
        }

        if (!string.IsNullOrEmpty(filtro.Class))
        {
            parameters.Add(new($"@{nameof(DBOponentesDicInfo.Class)}", filtro.Class));
        }

        if (!string.IsNullOrEmpty(filtro.GUID))
        {
            parameters.Add(new($"@{nameof(DBOponentesDicInfo.GUID)}", filtro.GUID));
        }

        var cWhere = filtro.EMPFuncao == int.MinValue ? string.Empty : $"{DBOponentesDicInfo.EMPFuncao} = @{nameof(DBOponentesDicInfo.EMPFuncao)}";
        cWhere += filtro.CTPSNumero.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOponentesDicInfo.CTPSNumero} = @{nameof(DBOponentesDicInfo.CTPSNumero)}";
        cWhere += filtro.Site.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOponentesDicInfo.Site} = @{nameof(DBOponentesDicInfo.Site)}";
        cWhere += filtro.CTPSSerie.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOponentesDicInfo.CTPSSerie} = @{nameof(DBOponentesDicInfo.CTPSSerie)}";
        cWhere += filtro.Nome.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOponentesDicInfo.Nome} = @{nameof(DBOponentesDicInfo.Nome)}";
        cWhere += filtro.Adv == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOponentesDicInfo.Adv} = @{nameof(DBOponentesDicInfo.Adv)}";
        cWhere += filtro.EMPCliente == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOponentesDicInfo.EMPCliente} = @{nameof(DBOponentesDicInfo.EMPCliente)}";
        cWhere += filtro.IDRep == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOponentesDicInfo.IDRep} = @{nameof(DBOponentesDicInfo.IDRep)}";
        cWhere += filtro.PIS.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOponentesDicInfo.PIS} = @{nameof(DBOponentesDicInfo.PIS)}";
        cWhere += filtro.Contato.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOponentesDicInfo.Contato} = @{nameof(DBOponentesDicInfo.Contato)}";
        cWhere += filtro.CNPJ.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOponentesDicInfo.CNPJ} = @{nameof(DBOponentesDicInfo.CNPJ)}";
        cWhere += filtro.RG.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOponentesDicInfo.RG} = @{nameof(DBOponentesDicInfo.RG)}";
        cWhere += filtro.CPF.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOponentesDicInfo.CPF} = @{nameof(DBOponentesDicInfo.CPF)}";
        cWhere += filtro.Endereco.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOponentesDicInfo.Endereco} = @{nameof(DBOponentesDicInfo.Endereco)}";
        cWhere += filtro.Fone.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOponentesDicInfo.Fone} = @{nameof(DBOponentesDicInfo.Fone)}";
        cWhere += filtro.Fax.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOponentesDicInfo.Fax} = @{nameof(DBOponentesDicInfo.Fax)}";
        cWhere += filtro.Cidade == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOponentesDicInfo.Cidade} = @{nameof(DBOponentesDicInfo.Cidade)}";
        cWhere += filtro.Bairro.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOponentesDicInfo.Bairro} = @{nameof(DBOponentesDicInfo.Bairro)}";
        cWhere += filtro.CEP.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOponentesDicInfo.CEP} = @{nameof(DBOponentesDicInfo.CEP)}";
        cWhere += filtro.InscEst.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOponentesDicInfo.InscEst} = @{nameof(DBOponentesDicInfo.InscEst)}";
        cWhere += filtro.Observacao.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOponentesDicInfo.Observacao} = @{nameof(DBOponentesDicInfo.Observacao)}";
        cWhere += filtro.EMail.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOponentesDicInfo.EMail} = @{nameof(DBOponentesDicInfo.EMail)}";
        cWhere += filtro.Class.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOponentesDicInfo.Class} = @{nameof(DBOponentesDicInfo.Class)}";
        cWhere += filtro.GUID.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOponentesDicInfo.GUID} = @{nameof(DBOponentesDicInfo.GUID)}";
        return (cWhere, parameters);
    }
}