﻿#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class LivroCaixaClientesService(IOptions<AppSettings> appSettings, ILivroCaixaClientesReader reader, ILivroCaixaClientesValidation validation, ILivroCaixaClientesWriter writer, ILivroCaixaReader livrocaixaReader, IClientesReader clientesReader, IHttpContextAccessor httpContextAccessor, HybridCache cache) : ILivroCaixaClientesService, IDisposable
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly string _uris = appSettings.Value.ValidUris;
    private readonly HybridCache _cache = cache;
    private bool _disposed;
    public async Task<IEnumerable<LivroCaixaClientesResponse>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("LivroCaixaClientes: URI inválida");
            }
        }

        var cacheKey = $"{uri}-LivroCaixaClientes-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<LivroCaixaClientesResponse>> GetDataAllAsync(int max, string uri, CancellationToken token)
    {
        var query = $@"SELECT DISTINCT TOP {max} 
                   {DBLivroCaixaClientes.SensivelCamposSqlX} 
                   FROM {DBLivroCaixaClientes.PTabelaNome} (NOLOCK)
                   ORDER BY {DBLivroCaixaClientesDicInfo.CampoNome}
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var connection = Configuracoes.ConnectionByUri(uri);
        var lista = new List<DBLivroCaixaClientes>(max);
        await foreach (var item in DBLivroCaixaClientes.ListarAsync(query, string.Empty, string.Empty, connection).WithCancellation(token).ConfigureAwait(false))
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

    public async Task<IEnumerable<LivroCaixaClientesResponse>> Filter(Filters.FilterLivroCaixaClientes filtro, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            throw new Exception("LivroCaixaClientes: URI inválida");
        }

        return await Task.Run(() =>
        {
            using var scope = Configuracoes.CreateConnectionScope(uri);
            var oCnn = scope.Connection;
            if (oCnn == null)
            {
                return[];
            }

            var result = new List<LivroCaixaClientesResponse>();
            var cWhere = filtro == null ? string.Empty : WFiltro(filtro!);
            var list = DBLivroCaixaClientes.Listar("", cWhere, "", Configuracoes.ConnectionByUri(uri));
            if (list != null)
            {
                foreach (var item in list)
                    result.Add(reader.Read(item)!);
            }

            return result;
        });
    }

    public async Task<LivroCaixaClientesResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("LivroCaixaClientes: URI inválida");
            }
        }

        if (id.IsEmptyIDNumber())
        {
            return new LivroCaixaClientesResponse();
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
            var result = await _cache.GetOrCreateAsync($"{uri}-LivroCaixaClientes-GetById-{id}-{keyCache}", async cancel => await GetDataByIdAsync(id, uri, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"LivroCaixaClientes - {uri}-: GetById - {ex.Message}");
        }
    }

    private async Task<LivroCaixaClientesResponse?> GetDataByIdAsync(int id, string uri, CancellationToken token)
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

    public async Task<LivroCaixaClientesResponse?> AddAndUpdate([FromBody] Models.LivroCaixaClientes regLivroCaixaClientes, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("LivroCaixaClientes: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regLivroCaixaClientes == null)
            {
                return null;
            }

            using var scope = Configuracoes.CreateConnectionScopeRw(uri);
            var oCnn = scope.Connection;
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regLivroCaixaClientes, this, livrocaixaReader, clientesReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception($"LivroCaixaClientes: {validade}");
            }

            var saved = writer.Write(regLivroCaixaClientes, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
            return reader.Read(saved.ID, oCnn);
        });
    }

    public async Task<LivroCaixaClientesResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("LivroCaixaClientes: URI inválida");
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

            var livrocaixaclientes = reader.Read(id, oCnn);
            if (livrocaixaclientes != null)
            {
                new DBLivroCaixaClientes().DeletarItem(livrocaixaclientes.Id, oCnn, null);
            }

            return livrocaixaclientes;
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

    private static string WFiltro(Filters.FilterLivroCaixaClientes filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var cWhere = filtro.LivroCaixa == -2147483648 ? string.Empty : DBLivroCaixaClientesDicInfo.LivroCaixaSql(filtro.LivroCaixa);
        cWhere += filtro.Cliente == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBLivroCaixaClientesDicInfo.ClienteSql(filtro.Cliente);
        return cWhere;
    }
}