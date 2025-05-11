#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class HistoricoService(IOptions<AppSettings> appSettings, IHistoricoReader reader, IHistoricoValidation validation, IHistoricoWriter writer, IProcessosReader processosReader, IPrecatoriaReader precatoriaReader, IApensoReader apensoReader, IFaseReader faseReader, IStatusAndamentoReader statusandamentoReader, IHttpContextAccessor httpContextAccessor, HybridCache cache) : IHistoricoService, IDisposable
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly string _uris = appSettings.Value.ValidUris;
    private readonly HybridCache _cache = cache;
    private bool _disposed;
    public async Task<IEnumerable<HistoricoResponse>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
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
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<HistoricoResponse>> GetDataAllAsync(int max, string uri, CancellationToken token)
    {
        var query = $@"SELECT DISTINCT TOP {max} 
                   {DBHistorico.SensivelCamposSqlX} 
                   FROM {DBHistorico.PTabelaNome} (NOLOCK)
                   ORDER BY {DBHistoricoDicInfo.CampoNome}
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var connection = Configuracoes.ConnectionByUri(uri);
        var lista = new List<DBHistorico>(max);
        await foreach (var item in DBHistorico.ListarAsync(query, string.Empty, string.Empty, connection).WithCancellation(token).ConfigureAwait(false))
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

    public async Task<IEnumerable<HistoricoResponse>> Filter(Filters.FilterHistorico filtro, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            throw new Exception("Historico: URI inválida");
        }

        return await Task.Run(() =>
        {
            using var scope = Configuracoes.CreateConnectionScope(uri);
            var oCnn = scope.Connection;
            if (oCnn == null)
            {
                return[];
            }

            var result = new List<HistoricoResponse>();
            var cWhere = filtro == null ? string.Empty : WFiltro(filtro!);
            var list = DBHistorico.Listar("", cWhere, "", Configuracoes.ConnectionByUri(uri));
            if (list != null)
            {
                foreach (var item in list)
                    result.Add(reader.Read(item)!);
            }

            return result;
        });
    }

    public async Task<HistoricoResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("Historico: URI inválida");
            }
        }

        if (id.IsEmptyIDNumber())
        {
            return new HistoricoResponse();
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
            var result = await _cache.GetOrCreateAsync($"{uri}-Historico-GetById-{id}-{keyCache}", async cancel => await GetDataByIdAsync(id, uri, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"Historico - {uri}-: GetById - {ex.Message}");
        }
    }

    private async Task<HistoricoResponse?> GetDataByIdAsync(int id, string uri, CancellationToken token)
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

    public async Task<HistoricoResponse?> AddAndUpdate([FromBody] Models.Historico regHistorico, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
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

            using var scope = Configuracoes.CreateConnectionScopeRw(uri);
            var oCnn = scope.Connection;
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regHistorico, this, processosReader, precatoriaReader, apensoReader, faseReader, statusandamentoReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception($"Historico: {validade}");
            }

            var saved = writer.Write(regHistorico, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
            return reader.Read(saved.ID, oCnn);
        });
    }

    public async Task<HistoricoResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("Historico: URI inválida");
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

            var historico = reader.Read(id, oCnn);
            if (historico != null)
            {
                new DBHistorico().DeletarItem(historico.Id, oCnn, null);
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

    private static string WFiltro(Filters.FilterHistorico filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var cWhere = filtro.ExtraID == -2147483648 ? string.Empty : DBHistoricoDicInfo.ExtraIDSql(filtro.ExtraID);
        cWhere += filtro.IDNE == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBHistoricoDicInfo.IDNESql(filtro.IDNE);
        cWhere += filtro.ExtraGUID.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBHistoricoDicInfo.ExtraGUIDSql(filtro.ExtraGUID);
        cWhere += filtro.LiminarOrigem == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBHistoricoDicInfo.LiminarOrigemSql(filtro.LiminarOrigem);
        cWhere += filtro.Processo == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBHistoricoDicInfo.ProcessoSql(filtro.Processo);
        cWhere += filtro.Precatoria == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBHistoricoDicInfo.PrecatoriaSql(filtro.Precatoria);
        cWhere += filtro.Apenso == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBHistoricoDicInfo.ApensoSql(filtro.Apenso);
        cWhere += filtro.IDInstProcesso == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBHistoricoDicInfo.IDInstProcessoSql(filtro.IDInstProcesso);
        cWhere += filtro.Fase == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBHistoricoDicInfo.FaseSql(filtro.Fase);
        cWhere += filtro.Observacao.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBHistoricoDicInfo.ObservacaoSql(filtro.Observacao);
        cWhere += filtro.SAD == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBHistoricoDicInfo.SADSql(filtro.SAD);
        cWhere += filtro.StatusAndamento == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBHistoricoDicInfo.StatusAndamentoSql(filtro.StatusAndamento);
        cWhere += filtro.GUID.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBHistoricoDicInfo.GUIDSql(filtro.GUID);
        return cWhere;
    }
}