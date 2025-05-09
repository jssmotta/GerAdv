﻿#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class AgendaFinanceiroService(IOptions<AppSettings> appSettings, IAgendaFinanceiroReader reader, IAgendaFinanceiroValidation validation, IAgendaFinanceiroWriter writer, IAdvogadosReader advogadosReader, IFuncionariosReader funcionariosReader, ITipoCompromissoReader tipocompromissoReader, IClientesReader clientesReader, IAreaReader areaReader, IJusticaReader justicaReader, IProcessosReader processosReader, IOperadorReader operadorReader, IPrepostosReader prepostosReader, IHttpContextAccessor httpContextAccessor, HybridCache cache) : IAgendaFinanceiroService, IDisposable
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly string _uris = appSettings.Value.ValidUris;
    private readonly HybridCache _cache = cache;
    private bool _disposed;
    public async Task<IEnumerable<AgendaFinanceiroResponse>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("AgendaFinanceiro: URI inválida");
            }
        }

        var cacheKey = $"{uri}-AgendaFinanceiro-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<AgendaFinanceiroResponse>> GetDataAllAsync(int max, string uri, CancellationToken token)
    {
        var query = $@"SELECT DISTINCT TOP {max} 
                   {DBAgendaFinanceiro.SensivelCamposSqlX} 
                   FROM {DBAgendaFinanceiro.PTabelaNome} (NOLOCK)
                   ORDER BY {DBAgendaFinanceiroDicInfo.CampoNome}
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var connection = Configuracoes.ConnectionByUri(uri);
        var lista = new List<DBAgendaFinanceiro>(max);
        await foreach (var item in DBAgendaFinanceiro.ListarAsync(query, string.Empty, string.Empty, connection).WithCancellation(token).ConfigureAwait(false))
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

    public async Task<IEnumerable<AgendaFinanceiroResponse>> Filter(Filters.FilterAgendaFinanceiro filtro, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            throw new Exception("AgendaFinanceiro: URI inválida");
        }

        return await Task.Run(() =>
        {
            using var scope = Configuracoes.CreateConnectionScope(uri);
            var oCnn = scope.Connection;
            if (oCnn == null)
            {
                return[];
            }

            var result = new List<AgendaFinanceiroResponse>();
            var cWhere = filtro == null ? string.Empty : WFiltro(filtro!);
            var list = DBAgendaFinanceiro.Listar("", cWhere, "", Configuracoes.ConnectionByUri(uri));
            if (list != null)
            {
                foreach (var item in list)
                    result.Add(reader.Read(item)!);
            }

            return result;
        });
    }

    public async Task<AgendaFinanceiroResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("AgendaFinanceiro: URI inválida");
            }
        }

        if (id.IsEmptyIDNumber())
        {
            return new AgendaFinanceiroResponse();
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
            var result = await _cache.GetOrCreateAsync($"{uri}-AgendaFinanceiro-GetById-{id}-{keyCache}", async cancel => await GetDataByIdAsync(id, uri, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"AgendaFinanceiro - {uri}-: GetById - {ex.Message}");
        }
    }

    private async Task<AgendaFinanceiroResponse?> GetDataByIdAsync(int id, string uri, CancellationToken token)
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

    public async Task<AgendaFinanceiroResponse?> AddAndUpdate([FromBody] Models.AgendaFinanceiro regAgendaFinanceiro, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("AgendaFinanceiro: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regAgendaFinanceiro == null)
            {
                return null;
            }

            using var scope = Configuracoes.CreateConnectionScopeRw(uri);
            var oCnn = scope.Connection;
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regAgendaFinanceiro, this, advogadosReader, funcionariosReader, tipocompromissoReader, clientesReader, areaReader, justicaReader, processosReader, operadorReader, prepostosReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception($"AgendaFinanceiro: {validade}");
            }

            var saved = writer.Write(regAgendaFinanceiro, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
            return reader.Read(saved.ID, oCnn);
        });
    }

    public async Task<AgendaFinanceiroResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("AgendaFinanceiro: URI inválida");
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

            var agendafinanceiro = reader.Read(id, oCnn);
            if (agendafinanceiro != null)
            {
                new DBAgendaFinanceiro().DeletarItem(agendafinanceiro.Id, oCnn, null);
            }

            return agendafinanceiro;
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

    private static string WFiltro(Filters.FilterAgendaFinanceiro filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var cWhere = filtro.IDCOB == -2147483648 ? string.Empty : DBAgendaFinanceiroDicInfo.IDCOBSql(filtro.IDCOB);
        cWhere += filtro.IDNE == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaFinanceiroDicInfo.IDNESql(filtro.IDNE);
        cWhere += filtro.PrazoProvisionado == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaFinanceiroDicInfo.PrazoProvisionadoSql(filtro.PrazoProvisionado);
        cWhere += filtro.Cidade == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaFinanceiroDicInfo.CidadeSql(filtro.Cidade);
        cWhere += filtro.Oculto == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaFinanceiroDicInfo.OcultoSql(filtro.Oculto);
        cWhere += filtro.CartaPrecatoria == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaFinanceiroDicInfo.CartaPrecatoriaSql(filtro.CartaPrecatoria);
        cWhere += filtro.RepetirDias == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaFinanceiroDicInfo.RepetirDiasSql(filtro.RepetirDias);
        cWhere += filtro.Repetir == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaFinanceiroDicInfo.RepetirSql(filtro.Repetir);
        cWhere += filtro.Advogado == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaFinanceiroDicInfo.AdvogadoSql(filtro.Advogado);
        cWhere += filtro.EventoGerador == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaFinanceiroDicInfo.EventoGeradorSql(filtro.EventoGerador);
        cWhere += filtro.Funcionario == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaFinanceiroDicInfo.FuncionarioSql(filtro.Funcionario);
        cWhere += filtro.EventoPrazo == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaFinanceiroDicInfo.EventoPrazoSql(filtro.EventoPrazo);
        cWhere += filtro.Compromisso.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaFinanceiroDicInfo.CompromissoSql(filtro.Compromisso);
        cWhere += filtro.TipoCompromisso == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaFinanceiroDicInfo.TipoCompromissoSql(filtro.TipoCompromisso);
        cWhere += filtro.Cliente == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaFinanceiroDicInfo.ClienteSql(filtro.Cliente);
        cWhere += filtro.Dias == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaFinanceiroDicInfo.DiasSql(filtro.Dias);
        cWhere += filtro.Area == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaFinanceiroDicInfo.AreaSql(filtro.Area);
        cWhere += filtro.Justica == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaFinanceiroDicInfo.JusticaSql(filtro.Justica);
        cWhere += filtro.Processo == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaFinanceiroDicInfo.ProcessoSql(filtro.Processo);
        cWhere += filtro.IDHistorico == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaFinanceiroDicInfo.IDHistoricoSql(filtro.IDHistorico);
        cWhere += filtro.IDInsProcesso == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaFinanceiroDicInfo.IDInsProcessoSql(filtro.IDInsProcesso);
        cWhere += filtro.Usuario == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaFinanceiroDicInfo.UsuarioSql(filtro.Usuario);
        cWhere += filtro.Preposto == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaFinanceiroDicInfo.PrepostoSql(filtro.Preposto);
        cWhere += filtro.QuemID == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaFinanceiroDicInfo.QuemIDSql(filtro.QuemID);
        cWhere += filtro.QuemCodigo == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaFinanceiroDicInfo.QuemCodigoSql(filtro.QuemCodigo);
        cWhere += filtro.Status.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaFinanceiroDicInfo.StatusSql(filtro.Status);
        cWhere += filtro.CompromissoHTML.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaFinanceiroDicInfo.CompromissoHTMLSql(filtro.CompromissoHTML);
        cWhere += filtro.Decisao.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaFinanceiroDicInfo.DecisaoSql(filtro.Decisao);
        cWhere += filtro.Sempre == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaFinanceiroDicInfo.SempreSql(filtro.Sempre);
        cWhere += filtro.PrazoDias == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaFinanceiroDicInfo.PrazoDiasSql(filtro.PrazoDias);
        cWhere += filtro.ProtocoloIntegrado == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaFinanceiroDicInfo.ProtocoloIntegradoSql(filtro.ProtocoloIntegrado);
        cWhere += filtro.GUID.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaFinanceiroDicInfo.GUIDSql(filtro.GUID);
        return cWhere;
    }
}