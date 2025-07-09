#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class HistoricoService(IOptions<AppSettings> appSettings, IHistoricoReader reader, IHistoricoValidation validation, IHistoricoWriter writer, IProcessosReader processosReader, IPrecatoriaReader precatoriaReader, IApensoReader apensoReader, IFaseReader faseReader, IStatusAndamentoReader statusandamentoReader, IProcessosObsReportService processosobsreportService, IRecadosService recadosService, IHttpContextAccessor httpContextAccessor, HybridCache cache, IMemoryCache memory) : IHistoricoService, IDisposable
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly IOptions<AppSettings> _appSettings = appSettings;
    private readonly HybridCache _cache = cache;
    private readonly IMemoryCache _memoryCache = memory;
    private bool _disposed;
    public async Task<IEnumerable<HistoricoResponseAll>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("Historico: URI inválida");
            }
        }

        var cacheKey = $"{uri}-Historico-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, string.Empty, [], uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<HistoricoResponseAll>> GetDataAllAsync(int max, string where, List<SqlParameter> parameters, string uri, CancellationToken token)
    {
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        if (oCnn == null)
        {
            throw new Exception("Conexão nula.");
        }

        var query = $@"SELECT TOP ({max})
                   {DBHistorico.SensivelCamposSqlX}, [Processos].[proNroPasta],[Precatoria].[],[Apenso].[],[Fase].[fasDescricao],[StatusAndamento].[sanNome]
                   FROM {DBHistorico.PTabelaNome.dbo(oCnn)} (NOLOCK)
                   LEFT JOIN {"Processos".dbo(oCnn)} (NOLOCK) ON [Processos].[proCodigo]=[Historico].[hisProcesso]
LEFT JOIN {"Precatoria".dbo(oCnn)} (NOLOCK) ON [Precatoria].[preCodigo]=[Historico].[hisPrecatoria]
LEFT JOIN {"Apenso".dbo(oCnn)} (NOLOCK) ON [Apenso].[apeCodigo]=[Historico].[hisApenso]
LEFT JOIN {"Fase".dbo(oCnn)} (NOLOCK) ON [Fase].[fasCodigo]=[Historico].[hisFase]
LEFT JOIN {"StatusAndamento".dbo(oCnn)} (NOLOCK) ON [StatusAndamento].[sanCodigo]=[Historico].[hisStatusAndamento]
 
                   {where}
                   ORDER BY [Historico].[]
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var lista = new List<HistoricoResponseAll>(max);
        var ds = await ConfiguracoesDBT.GetDataTable2Async(query, parameters, oCnn);
        if (ds != null)
            foreach (DataRow item in ds.Rows)
            {
                var dbRec = new DBHistorico(item);
                if (dbRec.ID.IsEmptyIDNumber())
                {
                    continue;
                }

                var historico = reader.ReadAll(dbRec, item);
                if (historico != null)
                {
                    lista.Add(historico);
                }
            }

        return lista;
    }

    public async Task<IEnumerable<HistoricoResponseAll>> Filter(Filters.FilterHistorico filtro, [FromRoute, Required] string uri)
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
        var cacheKey = $"{uri}-Historico-Filter-{where.GetHashCode()}{parameters.GetHashCode()}{keyCache}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(BaseConsts.PMaxItens, string.IsNullOrEmpty(where) ? string.Empty : TSql.Where + where, parameters, uri, cancel), entryOptions, cancellationToken: new());
    }

    public async Task<HistoricoResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (id < 1)
        {
            return new HistoricoResponse();
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
            var result = await _cache.GetOrCreateAsync($"{uri}-Historico-GetById-{id}-{keyCache}", async cancel => await GetDataByIdAsync(id, oCnn, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"Historico - {uri}-: GetById");
        }
    }

    private async Task<HistoricoResponse?> GetDataByIdAsync(int id, MsiSqlConnection oCnn, CancellationToken token) => await Task.Run(() => reader.Read(id, oCnn));
    public async Task<HistoricoResponse?> AddAndUpdate([FromBody] Models.Historico regHistorico, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("Historico: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regHistorico == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regHistorico, this, processosReader, precatoriaReader, apensoReader, faseReader, statusandamentoReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            var saved = writer.Write(regHistorico, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
            return reader.Read(saved, oCnn);
        });
    }

    public async Task<HistoricoResponse?> Validation([FromBody] Models.Historico regHistorico, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("Historico: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regHistorico == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regHistorico, this, processosReader, precatoriaReader, apensoReader, faseReader, statusandamentoReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            if (regHistorico.Id.IsEmptyIDNumber())
            {
                return new HistoricoResponse();
            }

            return reader.Read(regHistorico.Id, oCnn);
        });
    }

    public async Task<HistoricoResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("Historico: URI inválida");
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

            var deleteValidation = await validation.CanDelete(id, this, processosobsreportService, recadosService, uri, oCnn);
            if (deleteValidation.Length > 0)
            {
                throw new Exception(deleteValidation);
            }

            var historico = reader.Read(id, oCnn);
            try
            {
                if (historico != null)
                {
                    writer.Delete(historico, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
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

            return historico;
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

    private static (string where, List<SqlParameter> parametros)? WFiltro(Filters.FilterHistorico filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var parameters = new List<SqlParameter>();
        if (filtro.ExtraID != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBHistoricoDicInfo.ExtraID)}", filtro.ExtraID));
        }

        if (filtro.IDNE != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBHistoricoDicInfo.IDNE)}", filtro.IDNE));
        }

        if (!string.IsNullOrEmpty(filtro.ExtraGUID))
        {
            parameters.Add(new($"@{nameof(DBHistoricoDicInfo.ExtraGUID)}", filtro.ExtraGUID));
        }

        if (filtro.LiminarOrigem != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBHistoricoDicInfo.LiminarOrigem)}", filtro.LiminarOrigem));
        }

        if (filtro.Processo != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBHistoricoDicInfo.Processo)}", filtro.Processo));
        }

        if (filtro.Precatoria != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBHistoricoDicInfo.Precatoria)}", filtro.Precatoria));
        }

        if (filtro.Apenso != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBHistoricoDicInfo.Apenso)}", filtro.Apenso));
        }

        if (filtro.IDInstProcesso != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBHistoricoDicInfo.IDInstProcesso)}", filtro.IDInstProcesso));
        }

        if (filtro.Fase != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBHistoricoDicInfo.Fase)}", filtro.Fase));
        }

        if (!string.IsNullOrEmpty(filtro.Observacao))
        {
            parameters.Add(new($"@{nameof(DBHistoricoDicInfo.Observacao)}", filtro.Observacao));
        }

        if (filtro.SAD != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBHistoricoDicInfo.SAD)}", filtro.SAD));
        }

        if (filtro.StatusAndamento != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBHistoricoDicInfo.StatusAndamento)}", filtro.StatusAndamento));
        }

        if (!string.IsNullOrEmpty(filtro.GUID))
        {
            parameters.Add(new($"@{nameof(DBHistoricoDicInfo.GUID)}", filtro.GUID));
        }

        var cWhere = filtro.ExtraID == int.MinValue ? string.Empty : $"{DBHistoricoDicInfo.ExtraID} = @{nameof(DBHistoricoDicInfo.ExtraID)}";
        cWhere += filtro.IDNE == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBHistoricoDicInfo.IDNE} = @{nameof(DBHistoricoDicInfo.IDNE)}";
        cWhere += filtro.ExtraGUID.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBHistoricoDicInfo.ExtraGUID} = @{nameof(DBHistoricoDicInfo.ExtraGUID)}";
        cWhere += filtro.LiminarOrigem == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBHistoricoDicInfo.LiminarOrigem} = @{nameof(DBHistoricoDicInfo.LiminarOrigem)}";
        cWhere += filtro.Processo == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBHistoricoDicInfo.Processo} = @{nameof(DBHistoricoDicInfo.Processo)}";
        cWhere += filtro.Precatoria == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBHistoricoDicInfo.Precatoria} = @{nameof(DBHistoricoDicInfo.Precatoria)}";
        cWhere += filtro.Apenso == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBHistoricoDicInfo.Apenso} = @{nameof(DBHistoricoDicInfo.Apenso)}";
        cWhere += filtro.IDInstProcesso == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBHistoricoDicInfo.IDInstProcesso} = @{nameof(DBHistoricoDicInfo.IDInstProcesso)}";
        cWhere += filtro.Fase == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBHistoricoDicInfo.Fase} = @{nameof(DBHistoricoDicInfo.Fase)}";
        cWhere += filtro.Observacao.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBHistoricoDicInfo.Observacao} = @{nameof(DBHistoricoDicInfo.Observacao)}";
        cWhere += filtro.SAD == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBHistoricoDicInfo.SAD} = @{nameof(DBHistoricoDicInfo.SAD)}";
        cWhere += filtro.StatusAndamento == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBHistoricoDicInfo.StatusAndamento} = @{nameof(DBHistoricoDicInfo.StatusAndamento)}";
        cWhere += filtro.GUID.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBHistoricoDicInfo.GUID} = @{nameof(DBHistoricoDicInfo.GUID)}";
        return (cWhere, parameters);
    }
}