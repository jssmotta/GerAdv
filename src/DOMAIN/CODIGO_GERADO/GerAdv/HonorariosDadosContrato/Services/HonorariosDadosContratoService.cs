#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class HonorariosDadosContratoService(IOptions<AppSettings> appSettings, IHonorariosDadosContratoReader reader, IHonorariosDadosContratoValidation validation, IHonorariosDadosContratoWriter writer, IClientesReader clientesReader, IProcessosReader processosReader, IHttpContextAccessor httpContextAccessor, HybridCache cache) : IHonorariosDadosContratoService, IDisposable
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly string _uris = appSettings.Value.ValidUris;
    private readonly HybridCache _cache = cache;
    private bool _disposed;
    public async Task<IEnumerable<HonorariosDadosContratoResponse>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("HonorariosDadosContrato: URI inválida");
            }
        }

        var cacheKey = $"{uri}-HonorariosDadosContrato-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<HonorariosDadosContratoResponse>> GetDataAllAsync(int max, string uri, CancellationToken token)
    {
        var query = $@"SELECT DISTINCT TOP {max} 
                   {DBHonorariosDadosContrato.SensivelCamposSqlX} 
                   FROM {DBHonorariosDadosContrato.PTabelaNome} (NOLOCK)
                   ORDER BY {DBHonorariosDadosContratoDicInfo.CampoNome}
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var connection = Configuracoes.ConnectionByUri(uri);
        var lista = new List<DBHonorariosDadosContrato>(max);
        await foreach (var item in DBHonorariosDadosContrato.ListarAsync(query, string.Empty, string.Empty, connection).WithCancellation(token).ConfigureAwait(false))
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

    public async Task<IEnumerable<HonorariosDadosContratoResponse>> Filter(Filters.FilterHonorariosDadosContrato filtro, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            throw new Exception("HonorariosDadosContrato: URI inválida");
        }

        return await Task.Run(() =>
        {
            using var scope = Configuracoes.CreateConnectionScope(uri);
            var oCnn = scope.Connection;
            if (oCnn == null)
            {
                return[];
            }

            var result = new List<HonorariosDadosContratoResponse>();
            var cWhere = filtro == null ? string.Empty : WFiltro(filtro!);
            var list = DBHonorariosDadosContrato.Listar("", cWhere, "", Configuracoes.ConnectionByUri(uri));
            if (list != null)
            {
                foreach (var item in list)
                    result.Add(reader.Read(item)!);
            }

            return result;
        });
    }

    public async Task<HonorariosDadosContratoResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("HonorariosDadosContrato: URI inválida");
            }
        }

        if (id.IsEmptyIDNumber())
        {
            return new HonorariosDadosContratoResponse();
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
            var result = await _cache.GetOrCreateAsync($"{uri}-HonorariosDadosContrato-GetById-{id}-{keyCache}", async cancel => await GetDataByIdAsync(id, uri, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"HonorariosDadosContrato - {uri}-: GetById - {ex.Message}");
        }
    }

    private async Task<HonorariosDadosContratoResponse?> GetDataByIdAsync(int id, string uri, CancellationToken token)
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

    public async Task<HonorariosDadosContratoResponse?> AddAndUpdate([FromBody] Models.HonorariosDadosContrato regHonorariosDadosContrato, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("HonorariosDadosContrato: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regHonorariosDadosContrato == null)
            {
                return null;
            }

            using var scope = Configuracoes.CreateConnectionScopeRw(uri);
            var oCnn = scope.Connection;
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regHonorariosDadosContrato, this, clientesReader, processosReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception($"HonorariosDadosContrato: {validade}");
            }

            var saved = writer.Write(regHonorariosDadosContrato, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
            return reader.Read(saved.ID, oCnn);
        });
    }

    public async Task<HonorariosDadosContratoResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("HonorariosDadosContrato: URI inválida");
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

            var honorariosdadoscontrato = reader.Read(id, oCnn);
            if (honorariosdadoscontrato != null)
            {
                new DBHonorariosDadosContrato().DeletarItem(honorariosdadoscontrato.Id, oCnn, null);
            }

            return honorariosdadoscontrato;
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

    private static string WFiltro(Filters.FilterHonorariosDadosContrato filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var cWhere = filtro.Cliente == -2147483648 ? string.Empty : DBHonorariosDadosContratoDicInfo.ClienteSql(filtro.Cliente);
        cWhere += filtro.Processo == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBHonorariosDadosContratoDicInfo.ProcessoSql(filtro.Processo);
        cWhere += filtro.ArquivoContrato.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBHonorariosDadosContratoDicInfo.ArquivoContratoSql(filtro.ArquivoContrato);
        cWhere += filtro.TextoContrato.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBHonorariosDadosContratoDicInfo.TextoContratoSql(filtro.TextoContrato);
        cWhere += filtro.Observacao.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBHonorariosDadosContratoDicInfo.ObservacaoSql(filtro.Observacao);
        cWhere += filtro.GUID.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBHonorariosDadosContratoDicInfo.GUIDSql(filtro.GUID);
        return cWhere;
    }
}