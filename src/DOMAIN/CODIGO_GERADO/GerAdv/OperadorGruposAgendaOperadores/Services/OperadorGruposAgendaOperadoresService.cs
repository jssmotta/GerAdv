﻿#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class OperadorGruposAgendaOperadoresService(IOptions<AppSettings> appSettings, IOperadorGruposAgendaOperadoresReader reader, IOperadorGruposAgendaOperadoresValidation validation, IOperadorGruposAgendaOperadoresWriter writer, IOperadorGruposAgendaReader operadorgruposagendaReader, IOperadorReader operadorReader, IHttpContextAccessor httpContextAccessor, HybridCache cache) : IOperadorGruposAgendaOperadoresService, IDisposable
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly string _uris = appSettings.Value.ValidUris;
    private readonly HybridCache _cache = cache;
    private bool _disposed;
    public async Task<IEnumerable<OperadorGruposAgendaOperadoresResponse>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("OperadorGruposAgendaOperadores: URI inválida");
            }
        }

        var cacheKey = $"{uri}-OperadorGruposAgendaOperadores-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<OperadorGruposAgendaOperadoresResponse>> GetDataAllAsync(int max, string uri, CancellationToken token)
    {
        var query = $@"SELECT DISTINCT TOP {max} 
                   {DBOperadorGruposAgendaOperadores.SensivelCamposSqlX} 
                   FROM {DBOperadorGruposAgendaOperadores.PTabelaNome} (NOLOCK)
                   ORDER BY {DBOperadorGruposAgendaOperadoresDicInfo.CampoNome}
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var connection = Configuracoes.ConnectionByUri(uri);
        var lista = new List<DBOperadorGruposAgendaOperadores>(max);
        await foreach (var item in DBOperadorGruposAgendaOperadores.ListarAsync(query, string.Empty, string.Empty, connection).WithCancellation(token).ConfigureAwait(false))
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

    public async Task<IEnumerable<OperadorGruposAgendaOperadoresResponse>> Filter(Filters.FilterOperadorGruposAgendaOperadores filtro, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            throw new Exception("OperadorGruposAgendaOperadores: URI inválida");
        }

        return await Task.Run(() =>
        {
            using var scope = Configuracoes.CreateConnectionScope(uri);
            var oCnn = scope.Connection;
            if (oCnn == null)
            {
                return[];
            }

            var result = new List<OperadorGruposAgendaOperadoresResponse>();
            var cWhere = filtro == null ? string.Empty : WFiltro(filtro!);
            var list = DBOperadorGruposAgendaOperadores.Listar("", cWhere, "", Configuracoes.ConnectionByUri(uri));
            if (list != null)
            {
                foreach (var item in list)
                    result.Add(reader.Read(item)!);
            }

            return result;
        });
    }

    public async Task<OperadorGruposAgendaOperadoresResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("OperadorGruposAgendaOperadores: URI inválida");
            }
        }

        if (id.IsEmptyIDNumber())
        {
            return new OperadorGruposAgendaOperadoresResponse();
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
            var result = await _cache.GetOrCreateAsync($"{uri}-OperadorGruposAgendaOperadores-GetById-{id}-{keyCache}", async cancel => await GetDataByIdAsync(id, uri, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"OperadorGruposAgendaOperadores - {uri}-: GetById - {ex.Message}");
        }
    }

    private async Task<OperadorGruposAgendaOperadoresResponse?> GetDataByIdAsync(int id, string uri, CancellationToken token)
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

    public async Task<OperadorGruposAgendaOperadoresResponse?> AddAndUpdate([FromBody] Models.OperadorGruposAgendaOperadores regOperadorGruposAgendaOperadores, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("OperadorGruposAgendaOperadores: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regOperadorGruposAgendaOperadores == null)
            {
                return null;
            }

            using var scope = Configuracoes.CreateConnectionScopeRw(uri);
            var oCnn = scope.Connection;
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regOperadorGruposAgendaOperadores, this, operadorgruposagendaReader, operadorReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception($"OperadorGruposAgendaOperadores: {validade}");
            }

            var saved = writer.Write(regOperadorGruposAgendaOperadores, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
            return reader.Read(saved.ID, oCnn);
        });
    }

    public async Task<OperadorGruposAgendaOperadoresResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("OperadorGruposAgendaOperadores: URI inválida");
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

            var operadorgruposagendaoperadores = reader.Read(id, oCnn);
            if (operadorgruposagendaoperadores != null)
            {
                new DBOperadorGruposAgendaOperadores().DeletarItem(operadorgruposagendaoperadores.Id, oCnn, null);
            }

            return operadorgruposagendaoperadores;
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

    private static string WFiltro(Filters.FilterOperadorGruposAgendaOperadores filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var cWhere = filtro.OperadorGruposAgenda == -2147483648 ? string.Empty : DBOperadorGruposAgendaOperadoresDicInfo.OperadorGruposAgendaSql(filtro.OperadorGruposAgenda);
        cWhere += filtro.Operador == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBOperadorGruposAgendaOperadoresDicInfo.OperadorSql(filtro.Operador);
        cWhere += filtro.GUID.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBOperadorGruposAgendaOperadoresDicInfo.GUIDSql(filtro.GUID);
        return cWhere;
    }
}