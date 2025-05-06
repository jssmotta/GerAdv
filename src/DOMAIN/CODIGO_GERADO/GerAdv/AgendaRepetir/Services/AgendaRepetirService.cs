#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class AgendaRepetirService(IOptions<AppSettings> appSettings, IAgendaRepetirReader reader, IAgendaRepetirValidation validation, IAgendaRepetirWriter writer, IAdvogadosReader advogadosReader, IClientesReader clientesReader, IFuncionariosReader funcionariosReader, IProcessosReader processosReader, IHttpContextAccessor httpContextAccessor, HybridCache cache) : IAgendaRepetirService, IDisposable
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly string _uris = appSettings.Value.ValidUris;
    private readonly HybridCache _cache = cache;
    private bool _disposed;
    public async Task<IEnumerable<AgendaRepetirResponse>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("AgendaRepetir: URI inválida");
            }
        }

        var cacheKey = $"{uri}-AgendaRepetir-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<AgendaRepetirResponse>> GetDataAllAsync(int max, string uri, CancellationToken token)
    {
        var query = $@"SELECT DISTINCT TOP {max} 
                   {DBAgendaRepetir.SensivelCamposSqlX} 
                   FROM {DBAgendaRepetir.PTabelaNome} (NOLOCK)
                   ORDER BY {DBAgendaRepetirDicInfo.CampoNome}
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var connection = Configuracoes.ConnectionByUri(uri);
        var lista = new List<DBAgendaRepetir>(max);
        await foreach (var item in DBAgendaRepetir.ListarAsync(query, string.Empty, string.Empty, connection).WithCancellation(token).ConfigureAwait(false))
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

    public async Task<IEnumerable<AgendaRepetirResponse>> Filter(Filters.FilterAgendaRepetir filtro, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            throw new Exception("AgendaRepetir: URI inválida");
        }

        return await Task.Run(() =>
        {
            using var scope = Configuracoes.CreateConnectionScope(uri);
            var oCnn = scope.Connection;
            if (oCnn == null)
            {
                return[];
            }

            var result = new List<AgendaRepetirResponse>();
            var cWhere = filtro == null ? string.Empty : WFiltro(filtro!);
            var list = DBAgendaRepetir.Listar("", cWhere, "", Configuracoes.ConnectionByUri(uri));
            if (list != null)
            {
                foreach (var item in list)
                    result.Add(reader.Read(item)!);
            }

            return result;
        });
    }

    public async Task<AgendaRepetirResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("AgendaRepetir: URI inválida");
            }
        }

        if (id.IsEmptyIDNumber())
        {
            return new AgendaRepetirResponse();
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
            var result = await _cache.GetOrCreateAsync($"{uri}-AgendaRepetir-GetById-{id}-{keyCache}", async cancel => await GetDataByIdAsync(id, uri, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"AgendaRepetir - {uri}-: GetById - {ex.Message}");
        }
    }

    private async Task<AgendaRepetirResponse?> GetDataByIdAsync(int id, string uri, CancellationToken token)
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

    public async Task<AgendaRepetirResponse?> AddAndUpdate([FromBody] Models.AgendaRepetir regAgendaRepetir, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("AgendaRepetir: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regAgendaRepetir == null)
            {
                return null;
            }

            using var scope = Configuracoes.CreateConnectionScopeRw(uri);
            var oCnn = scope.Connection;
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regAgendaRepetir, this, advogadosReader, clientesReader, funcionariosReader, processosReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception($"AgendaRepetir: {validade}");
            }

            var saved = writer.Write(regAgendaRepetir, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
            return reader.Read(saved.ID, oCnn);
        });
    }

    public async Task<AgendaRepetirResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("AgendaRepetir: URI inválida");
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

            var agendarepetir = reader.Read(id, oCnn);
            if (agendarepetir != null)
            {
                new DBAgendaRepetir().DeletarItem(agendarepetir.Id, oCnn, null);
            }

            return agendarepetir;
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

    private static string WFiltro(Filters.FilterAgendaRepetir filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var cWhere = filtro.Advogado == -2147483648 ? string.Empty : DBAgendaRepetirDicInfo.AdvogadoSql(filtro.Advogado);
        cWhere += filtro.Cliente == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaRepetirDicInfo.ClienteSql(filtro.Cliente);
        cWhere += filtro.Funcionario == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaRepetirDicInfo.FuncionarioSql(filtro.Funcionario);
        cWhere += filtro.Processo == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaRepetirDicInfo.ProcessoSql(filtro.Processo);
        cWhere += filtro.Frequencia == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaRepetirDicInfo.FrequenciaSql(filtro.Frequencia);
        cWhere += filtro.Dia == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaRepetirDicInfo.DiaSql(filtro.Dia);
        cWhere += filtro.Mes == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaRepetirDicInfo.MesSql(filtro.Mes);
        cWhere += filtro.IDQuem == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaRepetirDicInfo.IDQuemSql(filtro.IDQuem);
        cWhere += filtro.IDQuem2 == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaRepetirDicInfo.IDQuem2Sql(filtro.IDQuem2);
        cWhere += filtro.Mensagem.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaRepetirDicInfo.MensagemSql(filtro.Mensagem);
        cWhere += filtro.IDTipo == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaRepetirDicInfo.IDTipoSql(filtro.IDTipo);
        cWhere += filtro.ID1 == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaRepetirDicInfo.ID1Sql(filtro.ID1);
        cWhere += filtro.ID2 == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaRepetirDicInfo.ID2Sql(filtro.ID2);
        cWhere += filtro.ID3 == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaRepetirDicInfo.ID3Sql(filtro.ID3);
        cWhere += filtro.ID4 == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBAgendaRepetirDicInfo.ID4Sql(filtro.ID4);
        return cWhere;
    }
}