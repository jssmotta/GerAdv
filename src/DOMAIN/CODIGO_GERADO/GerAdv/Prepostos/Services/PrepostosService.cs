#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class PrepostosService(IOptions<AppSettings> appSettings, IPrepostosReader reader, IPrepostosValidation validation, IPrepostosWriter writer, IFuncaoReader funcaoReader, ISetorReader setorReader, ICidadeReader cidadeReader, IAgendaService agendaService, IAgendaFinanceiroService agendafinanceiroService, IAgendaQuemService agendaquemService, IProcessosService processosService, IHttpContextAccessor httpContextAccessor, HybridCache cache, IMemoryCache memory) : IPrepostosService, IDisposable
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly IOptions<AppSettings> _appSettings = appSettings;
    private readonly HybridCache _cache = cache;
    private readonly IMemoryCache _memoryCache = memory;
    private bool _disposed;
    public async Task<IEnumerable<PrepostosResponseAll>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("Prepostos: URI inválida");
            }
        }

        var cacheKey = $"{uri}-Prepostos-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, string.Empty, [], uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<PrepostosResponseAll>> GetDataAllAsync(int max, string where, List<SqlParameter> parameters, string uri, CancellationToken token)
    {
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        if (oCnn == null)
        {
            throw new Exception("Conexão nula.");
        }

        var query = $@"SELECT TOP ({max})
                   {DBPrepostos.SensivelCamposSqlX}, [Funcao].[funDescricao],[Setor].[setDescricao],[Cidade].[cidNome]
                   FROM {DBPrepostos.PTabelaNome.dbo(oCnn)} (NOLOCK)
                   LEFT JOIN {"Funcao".dbo(oCnn)} (NOLOCK) ON [Funcao].[funCodigo]=[Prepostos].[preFuncao]
LEFT JOIN {"Setor".dbo(oCnn)} (NOLOCK) ON [Setor].[setCodigo]=[Prepostos].[preSetor]
LEFT JOIN {"Cidade".dbo(oCnn)} (NOLOCK) ON [Cidade].[cidCodigo]=[Prepostos].[preCidade]
 
                   {where}
                   ORDER BY [Prepostos].[preNome]
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var lista = new List<PrepostosResponseAll>(max);
        var ds = await ConfiguracoesDBT.GetDataTable2Async(query, parameters, oCnn);
        if (ds != null)
            foreach (DataRow item in ds.Rows)
            {
                var dbRec = new DBPrepostos(item);
                if (dbRec.ID.IsEmptyIDNumber())
                {
                    continue;
                }

                var prepostos = reader.ReadAll(dbRec, item);
                if (prepostos != null)
                {
                    lista.Add(prepostos);
                }
            }

        return lista;
    }

    public async Task<IEnumerable<PrepostosResponseAll>> Filter(Filters.FilterPrepostos filtro, [FromRoute, Required] string uri)
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
        var cacheKey = $"{uri}-Prepostos-Filter-{where.GetHashCode()}{parameters.GetHashCode()}{keyCache}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(BaseConsts.PMaxItens, string.IsNullOrEmpty(where) ? string.Empty : TSql.Where + where, parameters, uri, cancel), entryOptions, cancellationToken: new());
    }

    public async Task<PrepostosResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (id < 1)
        {
            return new PrepostosResponse();
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
            var result = await _cache.GetOrCreateAsync($"{uri}-Prepostos-GetById-{id}-{keyCache}", async cancel => await GetDataByIdAsync(id, oCnn, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"Prepostos - {uri}-: GetById");
        }
    }

    private async Task<PrepostosResponse?> GetDataByIdAsync(int id, MsiSqlConnection oCnn, CancellationToken token) => await Task.Run(() => reader.Read(id, oCnn));
    public async Task<PrepostosResponse?> AddAndUpdate([FromBody] Models.Prepostos regPrepostos, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("Prepostos: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regPrepostos == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regPrepostos, this, funcaoReader, setorReader, cidadeReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            var saved = writer.Write(regPrepostos, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
            return reader.Read(saved, oCnn);
        });
    }

    public async Task<PrepostosResponse?> Validation([FromBody] Models.Prepostos regPrepostos, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("Prepostos: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regPrepostos == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regPrepostos, this, funcaoReader, setorReader, cidadeReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            if (regPrepostos.Id.IsEmptyIDNumber())
            {
                return new PrepostosResponse();
            }

            return reader.Read(regPrepostos.Id, oCnn);
        });
    }

    public async Task<PrepostosResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("Prepostos: URI inválida");
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

            var deleteValidation = await validation.CanDelete(id, this, agendaService, agendafinanceiroService, agendaquemService, processosService, uri, oCnn);
            if (deleteValidation.Length > 0)
            {
                throw new Exception(deleteValidation);
            }

            var prepostos = reader.Read(id, oCnn);
            try
            {
                if (prepostos != null)
                {
                    writer.Delete(prepostos, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
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

            return prepostos;
        });
    }

    public async Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterPrepostos? filtro, [FromRoute, Required] string uri, CancellationToken token)
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
        var cacheKey = $"{uri}-Prepostos-{max}-{where.GetHashCode()}-GetListN-{keyCache}";
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
            foreach (var item in reader.ListarN(max, uri, where, parameters, DBPrepostosDicInfo.CampoNome))
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

    private static (string where, List<SqlParameter> parametros)? WFiltro(Filters.FilterPrepostos filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var parameters = new List<SqlParameter>();
        if (!string.IsNullOrEmpty(filtro.Nome))
        {
            parameters.Add(new($"@{nameof(DBPrepostosDicInfo.Nome)}", filtro.Nome));
        }

        if (filtro.Funcao != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBPrepostosDicInfo.Funcao)}", filtro.Funcao));
        }

        if (filtro.Setor != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBPrepostosDicInfo.Setor)}", filtro.Setor));
        }

        if (!string.IsNullOrEmpty(filtro.Qualificacao))
        {
            parameters.Add(new($"@{nameof(DBPrepostosDicInfo.Qualificacao)}", filtro.Qualificacao));
        }

        if (filtro.Idade != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBPrepostosDicInfo.Idade)}", filtro.Idade));
        }

        if (!string.IsNullOrEmpty(filtro.CPF))
        {
            parameters.Add(new($"@{nameof(DBPrepostosDicInfo.CPF)}", filtro.CPF));
        }

        if (!string.IsNullOrEmpty(filtro.RG))
        {
            parameters.Add(new($"@{nameof(DBPrepostosDicInfo.RG)}", filtro.RG));
        }

        if (!string.IsNullOrEmpty(filtro.Registro))
        {
            parameters.Add(new($"@{nameof(DBPrepostosDicInfo.Registro)}", filtro.Registro));
        }

        if (!string.IsNullOrEmpty(filtro.CTPSNumero))
        {
            parameters.Add(new($"@{nameof(DBPrepostosDicInfo.CTPSNumero)}", filtro.CTPSNumero));
        }

        if (!string.IsNullOrEmpty(filtro.CTPSSerie))
        {
            parameters.Add(new($"@{nameof(DBPrepostosDicInfo.CTPSSerie)}", filtro.CTPSSerie));
        }

        if (!string.IsNullOrEmpty(filtro.PIS))
        {
            parameters.Add(new($"@{nameof(DBPrepostosDicInfo.PIS)}", filtro.PIS));
        }

        if (!string.IsNullOrEmpty(filtro.Observacao))
        {
            parameters.Add(new($"@{nameof(DBPrepostosDicInfo.Observacao)}", filtro.Observacao));
        }

        if (!string.IsNullOrEmpty(filtro.Endereco))
        {
            parameters.Add(new($"@{nameof(DBPrepostosDicInfo.Endereco)}", filtro.Endereco));
        }

        if (!string.IsNullOrEmpty(filtro.Bairro))
        {
            parameters.Add(new($"@{nameof(DBPrepostosDicInfo.Bairro)}", filtro.Bairro));
        }

        if (filtro.Cidade != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBPrepostosDicInfo.Cidade)}", filtro.Cidade));
        }

        if (!string.IsNullOrEmpty(filtro.CEP))
        {
            parameters.Add(new($"@{nameof(DBPrepostosDicInfo.CEP)}", filtro.CEP));
        }

        if (!string.IsNullOrEmpty(filtro.Fone))
        {
            parameters.Add(new($"@{nameof(DBPrepostosDicInfo.Fone)}", filtro.Fone));
        }

        if (!string.IsNullOrEmpty(filtro.Fax))
        {
            parameters.Add(new($"@{nameof(DBPrepostosDicInfo.Fax)}", filtro.Fax));
        }

        if (!string.IsNullOrEmpty(filtro.EMail))
        {
            parameters.Add(new($"@{nameof(DBPrepostosDicInfo.EMail)}", filtro.EMail));
        }

        if (!string.IsNullOrEmpty(filtro.Pai))
        {
            parameters.Add(new($"@{nameof(DBPrepostosDicInfo.Pai)}", filtro.Pai));
        }

        if (!string.IsNullOrEmpty(filtro.Mae))
        {
            parameters.Add(new($"@{nameof(DBPrepostosDicInfo.Mae)}", filtro.Mae));
        }

        if (!string.IsNullOrEmpty(filtro.Class))
        {
            parameters.Add(new($"@{nameof(DBPrepostosDicInfo.Class)}", filtro.Class));
        }

        if (!string.IsNullOrEmpty(filtro.GUID))
        {
            parameters.Add(new($"@{nameof(DBPrepostosDicInfo.GUID)}", filtro.GUID));
        }

        var cWhere = filtro.Nome.IsEmpty() ? string.Empty : $"{DBPrepostosDicInfo.Nome} = @{nameof(DBPrepostosDicInfo.Nome)}";
        cWhere += filtro.Funcao == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBPrepostosDicInfo.Funcao} = @{nameof(DBPrepostosDicInfo.Funcao)}";
        cWhere += filtro.Setor == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBPrepostosDicInfo.Setor} = @{nameof(DBPrepostosDicInfo.Setor)}";
        cWhere += filtro.Qualificacao.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBPrepostosDicInfo.Qualificacao} = @{nameof(DBPrepostosDicInfo.Qualificacao)}";
        cWhere += filtro.Idade == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBPrepostosDicInfo.Idade} = @{nameof(DBPrepostosDicInfo.Idade)}";
        cWhere += filtro.CPF.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBPrepostosDicInfo.CPF} = @{nameof(DBPrepostosDicInfo.CPF)}";
        cWhere += filtro.RG.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBPrepostosDicInfo.RG} = @{nameof(DBPrepostosDicInfo.RG)}";
        cWhere += filtro.Registro.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBPrepostosDicInfo.Registro} = @{nameof(DBPrepostosDicInfo.Registro)}";
        cWhere += filtro.CTPSNumero.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBPrepostosDicInfo.CTPSNumero} = @{nameof(DBPrepostosDicInfo.CTPSNumero)}";
        cWhere += filtro.CTPSSerie.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBPrepostosDicInfo.CTPSSerie} = @{nameof(DBPrepostosDicInfo.CTPSSerie)}";
        cWhere += filtro.PIS.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBPrepostosDicInfo.PIS} = @{nameof(DBPrepostosDicInfo.PIS)}";
        cWhere += filtro.Observacao.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBPrepostosDicInfo.Observacao} = @{nameof(DBPrepostosDicInfo.Observacao)}";
        cWhere += filtro.Endereco.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBPrepostosDicInfo.Endereco} = @{nameof(DBPrepostosDicInfo.Endereco)}";
        cWhere += filtro.Bairro.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBPrepostosDicInfo.Bairro} = @{nameof(DBPrepostosDicInfo.Bairro)}";
        cWhere += filtro.Cidade == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBPrepostosDicInfo.Cidade} = @{nameof(DBPrepostosDicInfo.Cidade)}";
        cWhere += filtro.CEP.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBPrepostosDicInfo.CEP} = @{nameof(DBPrepostosDicInfo.CEP)}";
        cWhere += filtro.Fone.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBPrepostosDicInfo.Fone} = @{nameof(DBPrepostosDicInfo.Fone)}";
        cWhere += filtro.Fax.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBPrepostosDicInfo.Fax} = @{nameof(DBPrepostosDicInfo.Fax)}";
        cWhere += filtro.EMail.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBPrepostosDicInfo.EMail} = @{nameof(DBPrepostosDicInfo.EMail)}";
        cWhere += filtro.Pai.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBPrepostosDicInfo.Pai} = @{nameof(DBPrepostosDicInfo.Pai)}";
        cWhere += filtro.Mae.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBPrepostosDicInfo.Mae} = @{nameof(DBPrepostosDicInfo.Mae)}";
        cWhere += filtro.Class.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBPrepostosDicInfo.Class} = @{nameof(DBPrepostosDicInfo.Class)}";
        cWhere += filtro.GUID.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBPrepostosDicInfo.GUID} = @{nameof(DBPrepostosDicInfo.GUID)}";
        return (cWhere, parameters);
    }
}