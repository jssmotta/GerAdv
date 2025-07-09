#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class OperadorService(IOptions<AppSettings> appSettings, IOperadorReader reader, IOperadorValidation validation, IOperadorWriter writer, IStatusBiuReader statusbiuReader, IAgendaService agendaService, IAgendaFinanceiroService agendafinanceiroService, IAlarmSMSService alarmsmsService, IAlertasService alertasService, IAlertasEnviadosService alertasenviadosService, IContatoCRMService contatocrmService, IContatoCRMOperadorService contatocrmoperadorService, IDiario2Service diario2Service, IGUTAtividadesService gutatividadesService, IOperadorEMailPopupService operadoremailpopupService, IOperadorGrupoService operadorgrupoService, IOperadorGruposAgendaService operadorgruposagendaService, IOperadorGruposAgendaOperadoresService operadorgruposagendaoperadoresService, IPontoVirtualService pontovirtualService, IPontoVirtualAcessosService pontovirtualacessosService, IProcessosParadosService processosparadosService, IProcessOutputRequestService processoutputrequestService, IReuniaoPessoasService reuniaopessoasService, ISMSAliceService smsaliceService, IStatusBiuService statusbiuService, IHttpContextAccessor httpContextAccessor, HybridCache cache, IMemoryCache memory) : IOperadorService, IDisposable
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly IOptions<AppSettings> _appSettings = appSettings;
    private readonly HybridCache _cache = cache;
    private readonly IMemoryCache _memoryCache = memory;
    private bool _disposed;
    public async Task<IEnumerable<OperadorResponseAll>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("Operador: URI inválida");
            }
        }

        var cacheKey = $"{uri}-Operador-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, string.Empty, [], uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<OperadorResponseAll>> GetDataAllAsync(int max, string where, List<SqlParameter> parameters, string uri, CancellationToken token)
    {
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        if (oCnn == null)
        {
            throw new Exception("Conexão nula.");
        }

        var query = $@"SELECT TOP ({max})
                   {DBOperador.SensivelCamposSqlX}, [StatusBiu].[stbNome]
                   FROM {DBOperador.PTabelaNome.dbo(oCnn)} (NOLOCK)
                   LEFT JOIN {"StatusBiu".dbo(oCnn)} (NOLOCK) ON [StatusBiu].[stbCodigo]=[Operador].[operStatusId]
 
                   {where}
                   ORDER BY [Operador].[operNome]
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var lista = new List<OperadorResponseAll>(max);
        var ds = await ConfiguracoesDBT.GetDataTable2Async(query, parameters, oCnn);
        if (ds != null)
            foreach (DataRow item in ds.Rows)
            {
                var dbRec = new DBOperador(item);
                if (dbRec.ID.IsEmptyIDNumber())
                {
                    continue;
                }

                var operador = reader.ReadAll(dbRec, item);
                if (operador != null)
                {
                    lista.Add(operador);
                }
            }

        return lista;
    }

    public async Task<IEnumerable<OperadorResponseAll>> Filter(Filters.FilterOperador filtro, [FromRoute, Required] string uri)
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
        var cacheKey = $"{uri}-Operador-Filter-{where.GetHashCode()}{parameters.GetHashCode()}{keyCache}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(BaseConsts.PMaxItens, string.IsNullOrEmpty(where) ? string.Empty : TSql.Where + where, parameters, uri, cancel), entryOptions, cancellationToken: new());
    }

    public async Task<OperadorResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (id < 1)
        {
            return new OperadorResponse();
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
            var result = await _cache.GetOrCreateAsync($"{uri}-Operador-GetById-{id}-{keyCache}", async cancel => await GetDataByIdAsync(id, oCnn, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"Operador - {uri}-: GetById");
        }
    }

    private async Task<OperadorResponse?> GetDataByIdAsync(int id, MsiSqlConnection oCnn, CancellationToken token) => await Task.Run(() => reader.Read(id, oCnn));
    public async Task<OperadorResponse?> AddAndUpdate([FromBody] Models.Operador regOperador, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("Operador: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regOperador == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regOperador, this, statusbiuReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            var saved = writer.Write(regOperador, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
            return reader.Read(saved, oCnn);
        });
    }

    public async Task<OperadorResponse?> Validation([FromBody] Models.Operador regOperador, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("Operador: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regOperador == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regOperador, this, statusbiuReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            if (regOperador.Id.IsEmptyIDNumber())
            {
                return new OperadorResponse();
            }

            return reader.Read(regOperador.Id, oCnn);
        });
    }

    public async Task<OperadorResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("Operador: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (id.IsEmptyIDNumber())
            {
                return null;
            }

            if (id == UserTools.GetAuthenticatedUserId(_httpContextAccessor))
            {
                throw new Exception("Você não pode excluir a si mesmo.");
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var currentOperador = reader.Read(UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
            if (currentOperador == null)
            {
                throw new Exception("Operador atual não encontrado.");
            }

            if (!currentOperador.Situacao || !currentOperador.Master)
            {
                throw new Exception("Você não tem privilégios para excluir operador.");
            }

            var deleteValidation = await validation.CanDelete(id, this, agendaService, agendafinanceiroService, alarmsmsService, alertasService, alertasenviadosService, contatocrmService, contatocrmoperadorService, diario2Service, gutatividadesService, operadoremailpopupService, operadorgrupoService, operadorgruposagendaService, operadorgruposagendaoperadoresService, pontovirtualService, pontovirtualacessosService, processosparadosService, processoutputrequestService, reuniaopessoasService, smsaliceService, statusbiuService, uri, oCnn);
            if (deleteValidation.Length > 0)
            {
                throw new Exception(deleteValidation);
            }

            var operador = reader.Read(id, oCnn);
            try
            {
                if (operador != null)
                {
                    var operWrite = new Models.Operador
                    {
                        Id = operador.Id,
                        Master = operador.Master,
                        Telefonista = operador.Telefonista,
                        Nome = operador.Nome,
                        Ramal = operador.Ramal,
                        Excluido = operador.Excluido,
                        Situacao = operador.Situacao,
                        Computador = operador.Computador,
                        MinhaDescricao = operador.MinhaDescricao,
                        Pasta = operador.Pasta,
                        EMail = operador.EMail,
                        Nick = operador.Nick,
                        OnlineIP = operador.OnlineIP,
                        EMailNet = operador.EMailNet,
                        OnLine = false,
                        SysOp = operador.SysOp,
                        StatusId = operador.StatusId,
                        StatusMessage = operador.StatusMessage ?? string.Empty,
                        IsFinanceiro = operador.IsFinanceiro,
                        Top = operador.Top,
                        Sexo = operador.Sexo,
                    };
                    operWrite.Situacao = false;
                    operWrite.Excluido = true;
                    var saved = writer.Write(operWrite, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
                    return operador;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return operador;
        });
    }

    public async Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterOperador? filtro, [FromRoute, Required] string uri, CancellationToken token)
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
        var cacheKey = $"{uri}-Operador-{max}-{where.GetHashCode()}-GetListN-{keyCache}";
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
            foreach (var item in reader.ListarN(max, uri, where, parameters, DBOperadorDicInfo.CampoNome))
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

    private static (string where, List<SqlParameter> parametros)? WFiltro(Filters.FilterOperador filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var parameters = new List<SqlParameter>();
        if (!string.IsNullOrEmpty(filtro.EMail))
        {
            parameters.Add(new($"@{nameof(DBOperadorDicInfo.EMail)}", filtro.EMail));
        }

        if (!string.IsNullOrEmpty(filtro.Pasta))
        {
            parameters.Add(new($"@{nameof(DBOperadorDicInfo.Pasta)}", filtro.Pasta));
        }

        if (!string.IsNullOrEmpty(filtro.Nome))
        {
            parameters.Add(new($"@{nameof(DBOperadorDicInfo.Nome)}", filtro.Nome));
        }

        if (!string.IsNullOrEmpty(filtro.Nick))
        {
            parameters.Add(new($"@{nameof(DBOperadorDicInfo.Nick)}", filtro.Nick));
        }

        if (!string.IsNullOrEmpty(filtro.Ramal))
        {
            parameters.Add(new($"@{nameof(DBOperadorDicInfo.Ramal)}", filtro.Ramal));
        }

        if (filtro.CadID != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBOperadorDicInfo.CadID)}", filtro.CadID));
        }

        if (filtro.CadCod != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBOperadorDicInfo.CadCod)}", filtro.CadCod));
        }

        if (filtro.Computador != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBOperadorDicInfo.Computador)}", filtro.Computador));
        }

        if (!string.IsNullOrEmpty(filtro.MinhaDescricao))
        {
            parameters.Add(new($"@{nameof(DBOperadorDicInfo.MinhaDescricao)}", filtro.MinhaDescricao));
        }

        if (!string.IsNullOrEmpty(filtro.EMailNet))
        {
            parameters.Add(new($"@{nameof(DBOperadorDicInfo.EMailNet)}", filtro.EMailNet));
        }

        if (!string.IsNullOrEmpty(filtro.OnlineIP))
        {
            parameters.Add(new($"@{nameof(DBOperadorDicInfo.OnlineIP)}", filtro.OnlineIP));
        }

        if (filtro.StatusId != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBOperadorDicInfo.StatusId)}", filtro.StatusId));
        }

        if (!string.IsNullOrEmpty(filtro.StatusMessage))
        {
            parameters.Add(new($"@{nameof(DBOperadorDicInfo.StatusMessage)}", filtro.StatusMessage));
        }

        if (!string.IsNullOrEmpty(filtro.Senha256))
        {
            parameters.Add(new($"@{nameof(DBOperadorDicInfo.Senha256)}", filtro.Senha256));
        }

        if (!string.IsNullOrEmpty(filtro.SuporteSenha256))
        {
            parameters.Add(new($"@{nameof(DBOperadorDicInfo.SuporteSenha256)}", filtro.SuporteSenha256));
        }

        if (!string.IsNullOrEmpty(filtro.SuporteNomeSolicitante))
        {
            parameters.Add(new($"@{nameof(DBOperadorDicInfo.SuporteNomeSolicitante)}", filtro.SuporteNomeSolicitante));
        }

        if (!string.IsNullOrEmpty(filtro.SuporteIpUltimoAcesso))
        {
            parameters.Add(new($"@{nameof(DBOperadorDicInfo.SuporteIpUltimoAcesso)}", filtro.SuporteIpUltimoAcesso));
        }

        if (!string.IsNullOrEmpty(filtro.GUID))
        {
            parameters.Add(new($"@{nameof(DBOperadorDicInfo.GUID)}", filtro.GUID));
        }

        var cWhere = filtro.EMail.IsEmpty() ? string.Empty : $"{DBOperadorDicInfo.EMail} = @{nameof(DBOperadorDicInfo.EMail)}";
        cWhere += filtro.Pasta.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOperadorDicInfo.Pasta} = @{nameof(DBOperadorDicInfo.Pasta)}";
        cWhere += filtro.Nome.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOperadorDicInfo.Nome} = @{nameof(DBOperadorDicInfo.Nome)}";
        cWhere += filtro.Nick.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOperadorDicInfo.Nick} = @{nameof(DBOperadorDicInfo.Nick)}";
        cWhere += filtro.Ramal.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOperadorDicInfo.Ramal} = @{nameof(DBOperadorDicInfo.Ramal)}";
        cWhere += filtro.CadID == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOperadorDicInfo.CadID} = @{nameof(DBOperadorDicInfo.CadID)}";
        cWhere += filtro.CadCod == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOperadorDicInfo.CadCod} = @{nameof(DBOperadorDicInfo.CadCod)}";
        cWhere += filtro.Computador == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOperadorDicInfo.Computador} = @{nameof(DBOperadorDicInfo.Computador)}";
        cWhere += filtro.MinhaDescricao.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOperadorDicInfo.MinhaDescricao} = @{nameof(DBOperadorDicInfo.MinhaDescricao)}";
        cWhere += filtro.EMailNet.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOperadorDicInfo.EMailNet} = @{nameof(DBOperadorDicInfo.EMailNet)}";
        cWhere += filtro.OnlineIP.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOperadorDicInfo.OnlineIP} = @{nameof(DBOperadorDicInfo.OnlineIP)}";
        cWhere += filtro.StatusId == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOperadorDicInfo.StatusId} = @{nameof(DBOperadorDicInfo.StatusId)}";
        cWhere += filtro.StatusMessage.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOperadorDicInfo.StatusMessage} = @{nameof(DBOperadorDicInfo.StatusMessage)}";
        cWhere += filtro.Senha256.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOperadorDicInfo.Senha256} = @{nameof(DBOperadorDicInfo.Senha256)}";
        cWhere += filtro.SuporteSenha256.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOperadorDicInfo.SuporteSenha256} = @{nameof(DBOperadorDicInfo.SuporteSenha256)}";
        cWhere += filtro.SuporteNomeSolicitante.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOperadorDicInfo.SuporteNomeSolicitante} = @{nameof(DBOperadorDicInfo.SuporteNomeSolicitante)}";
        cWhere += filtro.SuporteIpUltimoAcesso.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOperadorDicInfo.SuporteIpUltimoAcesso} = @{nameof(DBOperadorDicInfo.SuporteIpUltimoAcesso)}";
        cWhere += filtro.GUID.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOperadorDicInfo.GUID} = @{nameof(DBOperadorDicInfo.GUID)}";
        return (cWhere, parameters);
    }
}