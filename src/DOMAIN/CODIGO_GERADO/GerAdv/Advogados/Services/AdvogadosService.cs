#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class AdvogadosService(IOptions<AppSettings> appSettings, IAdvogadosReader reader, IAdvogadosValidation validation, IAdvogadosWriter writer, ICargosReader cargosReader, IEscritoriosReader escritoriosReader, ICidadeReader cidadeReader, IAgendaService agendaService, IAgendaFinanceiroService agendafinanceiroService, IAgendaQuemService agendaquemService, IAgendaRepetirService agendarepetirService, IContratosService contratosService, IHorasTrabService horastrabService, IParceriaProcService parceriaprocService, IProcessosService processosService, IProProcuradoresService proprocuradoresService, IHttpContextAccessor httpContextAccessor, HybridCache cache, IMemoryCache memory) : IAdvogadosService, IDisposable
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly IOptions<AppSettings> _appSettings = appSettings;
    private readonly HybridCache _cache = cache;
    private readonly IMemoryCache _memoryCache = memory;
    private bool _disposed;
    public async Task<IEnumerable<AdvogadosResponseAll>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("Advogados: URI inválida");
            }
        }

        var cacheKey = $"{uri}-Advogados-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, string.Empty, [], uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<AdvogadosResponseAll>> GetDataAllAsync(int max, string where, List<SqlParameter> parameters, string uri, CancellationToken token)
    {
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        if (oCnn == null)
        {
            throw new Exception("Conexão nula.");
        }

        var query = $@"SELECT TOP ({max})
                   {DBAdvogados.SensivelCamposSqlX}, [Cargos].[carNome],[Escritorios].[escNome],[Cidade].[cidNome]
                   FROM {DBAdvogados.PTabelaNome.dbo(oCnn)} (NOLOCK)
                   LEFT JOIN {"Cargos".dbo(oCnn)} (NOLOCK) ON [Cargos].[carCodigo]=[Advogados].[advCargo]
LEFT JOIN {"Escritorios".dbo(oCnn)} (NOLOCK) ON [Escritorios].[escCodigo]=[Advogados].[advEscritorio]
LEFT JOIN {"Cidade".dbo(oCnn)} (NOLOCK) ON [Cidade].[cidCodigo]=[Advogados].[advCidade]
 
                   {where}
                   ORDER BY [Advogados].[advNome]
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var lista = new List<AdvogadosResponseAll>(max);
        var ds = await ConfiguracoesDBT.GetDataTable2Async(query, parameters, oCnn);
        if (ds != null)
            foreach (DataRow item in ds.Rows)
            {
                var dbRec = new DBAdvogados(item);
                if (dbRec.ID.IsEmptyIDNumber())
                {
                    continue;
                }

                var advogados = reader.ReadAll(dbRec, item);
                if (advogados != null)
                {
                    lista.Add(advogados);
                }
            }

        return lista;
    }

    public async Task<IEnumerable<AdvogadosResponseAll>> Filter(Filters.FilterAdvogados filtro, [FromRoute, Required] string uri)
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
        var cacheKey = $"{uri}-Advogados-Filter-{where.GetHashCode()}{parameters.GetHashCode()}{keyCache}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(BaseConsts.PMaxItens, string.IsNullOrEmpty(where) ? string.Empty : TSql.Where + where, parameters, uri, cancel), entryOptions, cancellationToken: new());
    }

    public async Task<AdvogadosResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (id < 1)
        {
            return new AdvogadosResponse();
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
            var result = await _cache.GetOrCreateAsync($"{uri}-Advogados-GetById-{id}-{keyCache}", async cancel => await GetDataByIdAsync(id, oCnn, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"Advogados - {uri}-: GetById");
        }
    }

    private async Task<AdvogadosResponse?> GetDataByIdAsync(int id, MsiSqlConnection oCnn, CancellationToken token) => await Task.Run(() => reader.Read(id, oCnn));
    public async Task<AdvogadosResponse?> AddAndUpdate([FromBody] Models.Advogados regAdvogados, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("Advogados: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regAdvogados == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regAdvogados, this, cargosReader, escritoriosReader, cidadeReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            var saved = writer.Write(regAdvogados, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
            return reader.Read(saved.ID, oCnn);
        });
    }

    public async Task<AdvogadosResponse?> Validation([FromBody] Models.Advogados regAdvogados, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("Advogados: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regAdvogados == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regAdvogados, this, cargosReader, escritoriosReader, cidadeReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            if (regAdvogados.Id.IsEmptyIDNumber())
            {
                return new AdvogadosResponse();
            }

            return reader.Read(regAdvogados.Id, oCnn);
        });
    }

    public async Task<AdvogadosResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("Advogados: URI inválida");
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

            var deleteValidation = await validation.CanDelete(id, this, agendaService, agendafinanceiroService, agendaquemService, agendarepetirService, contratosService, horastrabService, parceriaprocService, processosService, proprocuradoresService, uri, oCnn);
            if (deleteValidation.Length > 0)
            {
                throw new Exception(deleteValidation);
            }

            var advogados = reader.Read(id, oCnn);
            try
            {
                if (advogados != null)
                {
                    writer.Delete(advogados, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
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

            return advogados;
        });
    }

    public async Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterAdvogados? filtro, [FromRoute, Required] string uri, CancellationToken token)
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
        var cacheKey = $"{uri}-Advogados-{max}-{where.GetHashCode()}-GetListN-{keyCache}";
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
            foreach (var item in reader.ListarN(max, uri, where, parameters, DBAdvogadosDicInfo.CampoNome))
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

    private static (string where, List<SqlParameter> parametros)? WFiltro(Filters.FilterAdvogados filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var parameters = new List<SqlParameter>();
        if (filtro.Cargo != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAdvogadosDicInfo.Cargo)}", filtro.Cargo));
        }

        if (!string.IsNullOrEmpty(filtro.EMailPro))
        {
            parameters.Add(new($"@{nameof(DBAdvogadosDicInfo.EMailPro)}", filtro.EMailPro));
        }

        if (!string.IsNullOrEmpty(filtro.CPF))
        {
            parameters.Add(new($"@{nameof(DBAdvogadosDicInfo.CPF)}", filtro.CPF));
        }

        if (!string.IsNullOrEmpty(filtro.Nome))
        {
            parameters.Add(new($"@{nameof(DBAdvogadosDicInfo.Nome)}", filtro.Nome));
        }

        if (!string.IsNullOrEmpty(filtro.RG))
        {
            parameters.Add(new($"@{nameof(DBAdvogadosDicInfo.RG)}", filtro.RG));
        }

        if (!string.IsNullOrEmpty(filtro.NomeMae))
        {
            parameters.Add(new($"@{nameof(DBAdvogadosDicInfo.NomeMae)}", filtro.NomeMae));
        }

        if (filtro.Escritorio != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAdvogadosDicInfo.Escritorio)}", filtro.Escritorio));
        }

        if (!string.IsNullOrEmpty(filtro.OAB))
        {
            parameters.Add(new($"@{nameof(DBAdvogadosDicInfo.OAB)}", filtro.OAB));
        }

        if (!string.IsNullOrEmpty(filtro.NomeCompleto))
        {
            parameters.Add(new($"@{nameof(DBAdvogadosDicInfo.NomeCompleto)}", filtro.NomeCompleto));
        }

        if (!string.IsNullOrEmpty(filtro.Endereco))
        {
            parameters.Add(new($"@{nameof(DBAdvogadosDicInfo.Endereco)}", filtro.Endereco));
        }

        if (filtro.Cidade != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAdvogadosDicInfo.Cidade)}", filtro.Cidade));
        }

        if (!string.IsNullOrEmpty(filtro.CEP))
        {
            parameters.Add(new($"@{nameof(DBAdvogadosDicInfo.CEP)}", filtro.CEP));
        }

        if (!string.IsNullOrEmpty(filtro.Bairro))
        {
            parameters.Add(new($"@{nameof(DBAdvogadosDicInfo.Bairro)}", filtro.Bairro));
        }

        if (!string.IsNullOrEmpty(filtro.CTPSSerie))
        {
            parameters.Add(new($"@{nameof(DBAdvogadosDicInfo.CTPSSerie)}", filtro.CTPSSerie));
        }

        if (!string.IsNullOrEmpty(filtro.CTPS))
        {
            parameters.Add(new($"@{nameof(DBAdvogadosDicInfo.CTPS)}", filtro.CTPS));
        }

        if (!string.IsNullOrEmpty(filtro.Fone))
        {
            parameters.Add(new($"@{nameof(DBAdvogadosDicInfo.Fone)}", filtro.Fone));
        }

        if (!string.IsNullOrEmpty(filtro.Fax))
        {
            parameters.Add(new($"@{nameof(DBAdvogadosDicInfo.Fax)}", filtro.Fax));
        }

        if (filtro.Comissao != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAdvogadosDicInfo.Comissao)}", filtro.Comissao));
        }

        if (!string.IsNullOrEmpty(filtro.Secretaria))
        {
            parameters.Add(new($"@{nameof(DBAdvogadosDicInfo.Secretaria)}", filtro.Secretaria));
        }

        if (!string.IsNullOrEmpty(filtro.TextoProcuracao))
        {
            parameters.Add(new($"@{nameof(DBAdvogadosDicInfo.TextoProcuracao)}", filtro.TextoProcuracao));
        }

        if (!string.IsNullOrEmpty(filtro.EMail))
        {
            parameters.Add(new($"@{nameof(DBAdvogadosDicInfo.EMail)}", filtro.EMail));
        }

        if (!string.IsNullOrEmpty(filtro.Especializacao))
        {
            parameters.Add(new($"@{nameof(DBAdvogadosDicInfo.Especializacao)}", filtro.Especializacao));
        }

        if (!string.IsNullOrEmpty(filtro.Pasta))
        {
            parameters.Add(new($"@{nameof(DBAdvogadosDicInfo.Pasta)}", filtro.Pasta));
        }

        if (!string.IsNullOrEmpty(filtro.Observacao))
        {
            parameters.Add(new($"@{nameof(DBAdvogadosDicInfo.Observacao)}", filtro.Observacao));
        }

        if (!string.IsNullOrEmpty(filtro.ContaBancaria))
        {
            parameters.Add(new($"@{nameof(DBAdvogadosDicInfo.ContaBancaria)}", filtro.ContaBancaria));
        }

        if (!string.IsNullOrEmpty(filtro.Class))
        {
            parameters.Add(new($"@{nameof(DBAdvogadosDicInfo.Class)}", filtro.Class));
        }

        if (!string.IsNullOrEmpty(filtro.GUID))
        {
            parameters.Add(new($"@{nameof(DBAdvogadosDicInfo.GUID)}", filtro.GUID));
        }

        var cWhere = filtro.Cargo == int.MinValue ? string.Empty : $"{DBAdvogadosDicInfo.Cargo} = @{nameof(DBAdvogadosDicInfo.Cargo)}";
        cWhere += filtro.EMailPro.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAdvogadosDicInfo.EMailPro} = @{nameof(DBAdvogadosDicInfo.EMailPro)}";
        cWhere += filtro.CPF.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAdvogadosDicInfo.CPF} = @{nameof(DBAdvogadosDicInfo.CPF)}";
        cWhere += filtro.Nome.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAdvogadosDicInfo.Nome} = @{nameof(DBAdvogadosDicInfo.Nome)}";
        cWhere += filtro.RG.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAdvogadosDicInfo.RG} = @{nameof(DBAdvogadosDicInfo.RG)}";
        cWhere += filtro.NomeMae.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAdvogadosDicInfo.NomeMae} = @{nameof(DBAdvogadosDicInfo.NomeMae)}";
        cWhere += filtro.Escritorio == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAdvogadosDicInfo.Escritorio} = @{nameof(DBAdvogadosDicInfo.Escritorio)}";
        cWhere += filtro.OAB.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAdvogadosDicInfo.OAB} = @{nameof(DBAdvogadosDicInfo.OAB)}";
        cWhere += filtro.NomeCompleto.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAdvogadosDicInfo.NomeCompleto} = @{nameof(DBAdvogadosDicInfo.NomeCompleto)}";
        cWhere += filtro.Endereco.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAdvogadosDicInfo.Endereco} = @{nameof(DBAdvogadosDicInfo.Endereco)}";
        cWhere += filtro.Cidade == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAdvogadosDicInfo.Cidade} = @{nameof(DBAdvogadosDicInfo.Cidade)}";
        cWhere += filtro.CEP.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAdvogadosDicInfo.CEP} = @{nameof(DBAdvogadosDicInfo.CEP)}";
        cWhere += filtro.Bairro.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAdvogadosDicInfo.Bairro} = @{nameof(DBAdvogadosDicInfo.Bairro)}";
        cWhere += filtro.CTPSSerie.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAdvogadosDicInfo.CTPSSerie} = @{nameof(DBAdvogadosDicInfo.CTPSSerie)}";
        cWhere += filtro.CTPS.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAdvogadosDicInfo.CTPS} = @{nameof(DBAdvogadosDicInfo.CTPS)}";
        cWhere += filtro.Fone.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAdvogadosDicInfo.Fone} = @{nameof(DBAdvogadosDicInfo.Fone)}";
        cWhere += filtro.Fax.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAdvogadosDicInfo.Fax} = @{nameof(DBAdvogadosDicInfo.Fax)}";
        cWhere += filtro.Comissao == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAdvogadosDicInfo.Comissao} = @{nameof(DBAdvogadosDicInfo.Comissao)}";
        cWhere += filtro.Secretaria.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAdvogadosDicInfo.Secretaria} = @{nameof(DBAdvogadosDicInfo.Secretaria)}";
        cWhere += filtro.TextoProcuracao.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAdvogadosDicInfo.TextoProcuracao} = @{nameof(DBAdvogadosDicInfo.TextoProcuracao)}";
        cWhere += filtro.EMail.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAdvogadosDicInfo.EMail} = @{nameof(DBAdvogadosDicInfo.EMail)}";
        cWhere += filtro.Especializacao.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAdvogadosDicInfo.Especializacao} = @{nameof(DBAdvogadosDicInfo.Especializacao)}";
        cWhere += filtro.Pasta.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAdvogadosDicInfo.Pasta} = @{nameof(DBAdvogadosDicInfo.Pasta)}";
        cWhere += filtro.Observacao.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAdvogadosDicInfo.Observacao} = @{nameof(DBAdvogadosDicInfo.Observacao)}";
        cWhere += filtro.ContaBancaria.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAdvogadosDicInfo.ContaBancaria} = @{nameof(DBAdvogadosDicInfo.ContaBancaria)}";
        cWhere += filtro.Class.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAdvogadosDicInfo.Class} = @{nameof(DBAdvogadosDicInfo.Class)}";
        cWhere += filtro.GUID.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAdvogadosDicInfo.GUID} = @{nameof(DBAdvogadosDicInfo.GUID)}";
        return (cWhere, parameters);
    }
}