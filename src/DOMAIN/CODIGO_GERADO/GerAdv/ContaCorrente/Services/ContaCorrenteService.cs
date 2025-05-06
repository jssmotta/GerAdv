#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class ContaCorrenteService(IOptions<AppSettings> appSettings, IContaCorrenteReader reader, IContaCorrenteValidation validation, IContaCorrenteWriter writer, IProcessosReader processosReader, IClientesReader clientesReader, IHttpContextAccessor httpContextAccessor, HybridCache cache) : IContaCorrenteService, IDisposable
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly string _uris = appSettings.Value.ValidUris;
    private readonly HybridCache _cache = cache;
    private bool _disposed;
    public async Task<IEnumerable<ContaCorrenteResponse>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("ContaCorrente: URI inválida");
            }
        }

        var cacheKey = $"{uri}-ContaCorrente-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<ContaCorrenteResponse>> GetDataAllAsync(int max, string uri, CancellationToken token)
    {
        var query = $@"SELECT DISTINCT TOP {max} 
                   {DBContaCorrente.SensivelCamposSqlX} 
                   FROM {DBContaCorrente.PTabelaNome} (NOLOCK)
                   ORDER BY {DBContaCorrenteDicInfo.CampoNome}
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var connection = Configuracoes.ConnectionByUri(uri);
        var lista = new List<DBContaCorrente>(max);
        await foreach (var item in DBContaCorrente.ListarAsync(query, string.Empty, string.Empty, connection).WithCancellation(token).ConfigureAwait(false))
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

    public async Task<IEnumerable<ContaCorrenteResponse>> Filter(Filters.FilterContaCorrente filtro, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            throw new Exception("ContaCorrente: URI inválida");
        }

        return await Task.Run(() =>
        {
            using var scope = Configuracoes.CreateConnectionScope(uri);
            var oCnn = scope.Connection;
            if (oCnn == null)
            {
                return[];
            }

            var result = new List<ContaCorrenteResponse>();
            var cWhere = filtro == null ? string.Empty : WFiltro(filtro!);
            var list = DBContaCorrente.Listar("", cWhere, "", Configuracoes.ConnectionByUri(uri));
            if (list != null)
            {
                foreach (var item in list)
                    result.Add(reader.Read(item)!);
            }

            return result;
        });
    }

    public async Task<ContaCorrenteResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("ContaCorrente: URI inválida");
            }
        }

        if (id.IsEmptyIDNumber())
        {
            return new ContaCorrenteResponse();
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
            var result = await _cache.GetOrCreateAsync($"{uri}-ContaCorrente-GetById-{id}-{keyCache}", async cancel => await GetDataByIdAsync(id, uri, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"ContaCorrente - {uri}-: GetById - {ex.Message}");
        }
    }

    private async Task<ContaCorrenteResponse?> GetDataByIdAsync(int id, string uri, CancellationToken token)
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

    public async Task<ContaCorrenteResponse?> AddAndUpdate([FromBody] Models.ContaCorrente regContaCorrente, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("ContaCorrente: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regContaCorrente == null)
            {
                return null;
            }

            using var scope = Configuracoes.CreateConnectionScopeRw(uri);
            var oCnn = scope.Connection;
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regContaCorrente, this, processosReader, clientesReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception($"ContaCorrente: {validade}");
            }

            var saved = writer.Write(regContaCorrente, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
            return reader.Read(saved.ID, oCnn);
        });
    }

    public async Task<ContaCorrenteResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("ContaCorrente: URI inválida");
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

            var contacorrente = reader.Read(id, oCnn);
            if (contacorrente != null)
            {
                new DBContaCorrente().DeletarItem(contacorrente.Id, oCnn, null);
            }

            return contacorrente;
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

    private static string WFiltro(Filters.FilterContaCorrente filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var cWhere = filtro.CIAcordo == -2147483648 ? string.Empty : DBContaCorrenteDicInfo.CIAcordoSql(filtro.CIAcordo);
        cWhere += filtro.IDContrato == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBContaCorrenteDicInfo.IDContratoSql(filtro.IDContrato);
        cWhere += filtro.QuitadoID == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBContaCorrenteDicInfo.QuitadoIDSql(filtro.QuitadoID);
        cWhere += filtro.DebitoID == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBContaCorrenteDicInfo.DebitoIDSql(filtro.DebitoID);
        cWhere += filtro.LivroCaixaID == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBContaCorrenteDicInfo.LivroCaixaIDSql(filtro.LivroCaixaID);
        cWhere += filtro.Processo == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBContaCorrenteDicInfo.ProcessoSql(filtro.Processo);
        cWhere += filtro.ParcelaX == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBContaCorrenteDicInfo.ParcelaXSql(filtro.ParcelaX);
        cWhere += filtro.Cliente == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBContaCorrenteDicInfo.ClienteSql(filtro.Cliente);
        cWhere += filtro.Historico.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBContaCorrenteDicInfo.HistoricoSql(filtro.Historico);
        cWhere += filtro.IDHTrab == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBContaCorrenteDicInfo.IDHTrabSql(filtro.IDHTrab);
        cWhere += filtro.NroParcelas == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBContaCorrenteDicInfo.NroParcelasSql(filtro.NroParcelas);
        cWhere += filtro.ParcelaPrincipalID == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBContaCorrenteDicInfo.ParcelaPrincipalIDSql(filtro.ParcelaPrincipalID);
        cWhere += filtro.GUID.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBContaCorrenteDicInfo.GUIDSql(filtro.GUID);
        return cWhere;
    }
}