#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class AgendaService(IOptions<AppSettings> appSettings, IAgendaReader reader, IAgendaValidation validation, IAgendaWriter writer, IAdvogadosReader advogadosReader, IFuncionariosReader funcionariosReader, ITipoCompromissoReader tipocompromissoReader, IClientesReader clientesReader, IAreaReader areaReader, IJusticaReader justicaReader, IProcessosReader processosReader, IOperadorReader operadorReader, IPrepostosReader prepostosReader, IHttpContextAccessor httpContextAccessor, HybridCache cache) : IAgendaService, IDisposable
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly string _uris = appSettings.Value.ValidUris;
    private readonly HybridCache _cache = cache;
    private bool _disposed;
    public async Task<IEnumerable<AgendaResponse>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("Agenda: URI inválida");
            }
        }

        var cacheKey = $"{uri}-Agenda-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<AgendaResponse>> GetDataAllAsync(int max, string uri, CancellationToken token)
    {
        var query = $@"SELECT DISTINCT TOP {max} 
                   {DBAgenda.SensivelCamposSqlX} 
                   FROM {DBAgenda.PTabelaNome} (NOLOCK)
                   ORDER BY {DBAgendaDicInfo.CampoNome}
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var connection = Configuracoes.ConnectionByUri(uri);
        var lista = new List<DBAgenda>(max);
        await foreach (var item in DBAgenda.ListarAsync(query, string.Empty, string.Empty, connection).WithCancellation(token).ConfigureAwait(false))
        {
            if (item != null)
            {
                lista.Add(item);
                if (lista.Count % 100 == 0)
                    token.ThrowIfCancellationRequested();
            }
        }

        return lista.Count > 0 ? lista.Select(item => reader.Read(item)!).Where(item => item != null).ToList() : [];
    }

    public async Task<IEnumerable<AgendaResponse>> Filter(Filters.FilterAgenda filtro, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            throw new Exception("Agenda: URI inválida");
        }

        return await Task.Run(() =>
        {
            using var scope = Configuracoes.CreateConnectionScope(uri);
            var oCnn = scope.Connection;
            if (oCnn == null)
            {
                return[];
            }

            var result = new List<AgendaResponse>();
            var cWhere = filtro == null ? string.Empty : WFiltro(filtro!);
            var list = DBAgenda.Listar("", cWhere, "", Configuracoes.ConnectionByUri(uri));
            if (list != null)
            {
                foreach (var item in list)
                    result.Add(reader.Read(item)!);
            }

            return result;
        });
    }

    public async Task<AgendaResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("Agenda: URI inválida");
            }
        }

        if (id.IsEmptyIDNumber())
        {
            return new AgendaResponse();
        }

        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxSecondsCacheId)
        };
        try
        {
            using var scope = Configuracoes.CreateConnectionScope(uri);
            var oCnn = scope.Connection;
            var keyCache = await reader.ReadStringAuditor(id, uri, oCnn);
            var result = await _cache.GetOrCreateAsync($"{uri}-Agenda-GetById-{id}-{keyCache}", async cancel => await GetDataByIdAsync(id, uri, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"Agenda - {uri}-: GetById - {ex.Message}");
        }
    }

    private async Task<AgendaResponse?> GetDataByIdAsync(int id, string uri, CancellationToken token)
    {
        return await Task.Run(() =>
        {
            if (id.IsEmptyIDNumber())
            {
                return null;
            }

            using var scope = Configuracoes.CreateConnectionScope(uri);
            var oCnn = scope.Connection;
            return oCnn == null ? null : reader.Read(id, oCnn);
        });
    }

    public async Task<AgendaResponse?> AddAndUpdate([FromBody] Models.Agenda regAgenda, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("Agenda: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regAgenda == null)
            {
                return null;
            }

            using var scope = Configuracoes.CreateConnectionScopeRw(uri);
            var oCnn = scope.Connection;
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regAgenda, this, advogadosReader, funcionariosReader, tipocompromissoReader, clientesReader, areaReader, justicaReader, processosReader, operadorReader, prepostosReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception($"Agenda: {validade}");
            }

            var saved = writer.Write(regAgenda, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
            return reader.Read(saved.ID, oCnn);
        });
    }

    public async Task<AgendaResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("Agenda: URI inválida");
            }
        }

        return await Task.Run(() =>
        {
            if (id.IsEmptyIDNumber())
            {
                return null;
            }

            using var scope = Configuracoes.CreateConnectionScopeRw(uri);
            var oCnn = scope.Connection;
            if (oCnn == null)
            {
                return null;
            }

            var agenda = reader.Read(id, oCnn);
            if (agenda != null)
            {
                new DBAgenda().DeletarItem(agenda.Id, oCnn, null);
            }

            return agenda;
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

    private static string WFiltro(Filters.FilterAgenda filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var cWhere = filtro.IDCOB == -2147483648 ? string.Empty : DBAgendaDicInfo.IDCOBSql(filtro.IDCOB);
        cWhere += filtro.IDNE == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaDicInfo.IDNESql(filtro.IDNE);
        cWhere += filtro.Cidade == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaDicInfo.CidadeSql(filtro.Cidade);
        cWhere += filtro.Oculto == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaDicInfo.OcultoSql(filtro.Oculto);
        cWhere += filtro.CartaPrecatoria == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaDicInfo.CartaPrecatoriaSql(filtro.CartaPrecatoria);
        cWhere += filtro.Advogado == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaDicInfo.AdvogadoSql(filtro.Advogado);
        cWhere += filtro.EventoGerador == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaDicInfo.EventoGeradorSql(filtro.EventoGerador);
        cWhere += filtro.Funcionario == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaDicInfo.FuncionarioSql(filtro.Funcionario);
        cWhere += filtro.EventoPrazo == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaDicInfo.EventoPrazoSql(filtro.EventoPrazo);
        cWhere += filtro.Compromisso.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaDicInfo.CompromissoSql(filtro.Compromisso);
        cWhere += filtro.TipoCompromisso == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaDicInfo.TipoCompromissoSql(filtro.TipoCompromisso);
        cWhere += filtro.Cliente == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaDicInfo.ClienteSql(filtro.Cliente);
        cWhere += filtro.Area == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaDicInfo.AreaSql(filtro.Area);
        cWhere += filtro.Justica == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaDicInfo.JusticaSql(filtro.Justica);
        cWhere += filtro.Processo == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaDicInfo.ProcessoSql(filtro.Processo);
        cWhere += filtro.IDHistorico == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaDicInfo.IDHistoricoSql(filtro.IDHistorico);
        cWhere += filtro.IDInsProcesso == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaDicInfo.IDInsProcessoSql(filtro.IDInsProcesso);
        cWhere += filtro.Usuario == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaDicInfo.UsuarioSql(filtro.Usuario);
        cWhere += filtro.Preposto == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaDicInfo.PrepostoSql(filtro.Preposto);
        cWhere += filtro.QuemID == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaDicInfo.QuemIDSql(filtro.QuemID);
        cWhere += filtro.QuemCodigo == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaDicInfo.QuemCodigoSql(filtro.QuemCodigo);
        cWhere += filtro.Status.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaDicInfo.StatusSql(filtro.Status);
        cWhere += filtro.Decisao.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaDicInfo.DecisaoSql(filtro.Decisao);
        cWhere += filtro.Sempre == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaDicInfo.SempreSql(filtro.Sempre);
        cWhere += filtro.PrazoDias == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaDicInfo.PrazoDiasSql(filtro.PrazoDias);
        cWhere += filtro.ProtocoloIntegrado == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaDicInfo.ProtocoloIntegradoSql(filtro.ProtocoloIntegrado);
        cWhere += filtro.GUID.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaDicInfo.GUIDSql(filtro.GUID);
        return cWhere;
    }
}