#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class GUTAtividadesMatrizService(IOptions<AppSettings> appSettings, IGUTAtividadesMatrizReader reader, IGUTAtividadesMatrizValidation validation, IGUTAtividadesMatrizWriter writer, IGUTMatrizReader gutmatrizReader, IGUTAtividadesReader gutatividadesReader, IHttpContextAccessor httpContextAccessor, HybridCache cache) : IGUTAtividadesMatrizService, IDisposable
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly string _uris = appSettings.Value.ValidUris;
    private readonly HybridCache _cache = cache;
    private bool _disposed;
    public async Task<IEnumerable<GUTAtividadesMatrizResponse>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("GUTAtividadesMatriz: URI inválida");
            }
        }

        var cacheKey = $"{uri}-GUTAtividadesMatriz-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<GUTAtividadesMatrizResponse>> GetDataAllAsync(int max, string uri, CancellationToken token)
    {
        var query = $@"SELECT DISTINCT TOP {max} 
                   {DBGUTAtividadesMatriz.SensivelCamposSqlX} 
                   FROM {DBGUTAtividadesMatriz.PTabelaNome} (NOLOCK)
                   ORDER BY {DBGUTAtividadesMatrizDicInfo.CampoNome}
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var connection = Configuracoes.ConnectionByUri(uri);
        var lista = new List<DBGUTAtividadesMatriz>(max);
        await foreach (var item in DBGUTAtividadesMatriz.ListarAsync(query, string.Empty, string.Empty, connection).WithCancellation(token).ConfigureAwait(false))
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

    public async Task<IEnumerable<GUTAtividadesMatrizResponse>> Filter(Filters.FilterGUTAtividadesMatriz filtro, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            throw new Exception("GUTAtividadesMatriz: URI inválida");
        }

        return await Task.Run(() =>
        {
            using var scope = Configuracoes.CreateConnectionScope(uri);
            var oCnn = scope.Connection;
            if (oCnn == null)
            {
                return[];
            }

            var result = new List<GUTAtividadesMatrizResponse>();
            var cWhere = filtro == null ? string.Empty : WFiltro(filtro!);
            var list = DBGUTAtividadesMatriz.Listar("", cWhere, "", Configuracoes.ConnectionByUri(uri));
            if (list != null)
            {
                foreach (var item in list)
                    result.Add(reader.Read(item)!);
            }

            return result;
        });
    }

    public async Task<GUTAtividadesMatrizResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("GUTAtividadesMatriz: URI inválida");
            }
        }

        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxSecondsCacheId)
        };
        try
        {
            var result = await _cache.GetOrCreateAsync($"{uri}-GUTAtividadesMatriz-GetById-{id}", async cancel => await GetDataByIdAsync(id, uri, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"GUTAtividadesMatriz - {uri}-: GetById - {ex.Message}");
        }
    }

    private async Task<GUTAtividadesMatrizResponse?> GetDataByIdAsync(int id, string uri, CancellationToken token)
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

    public async Task<GUTAtividadesMatrizResponse?> AddAndUpdate([FromBody] Models.GUTAtividadesMatriz regGUTAtividadesMatriz, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("GUTAtividadesMatriz: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regGUTAtividadesMatriz == null)
            {
                return null;
            }

            using var scope = Configuracoes.CreateConnectionScopeRw(uri);
            var oCnn = scope.Connection;
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regGUTAtividadesMatriz, this, gutmatrizReader, gutatividadesReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception($"GUTAtividadesMatriz: {validade}");
            }

            var saved = writer.Write(regGUTAtividadesMatriz, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
            return reader.Read(saved.ID, oCnn);
        });
    }

    public async Task<GUTAtividadesMatrizResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("GUTAtividadesMatriz: URI inválida");
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

            var gutatividadesmatriz = reader.Read(id, oCnn);
            if (gutatividadesmatriz != null)
            {
                new DBGUTAtividadesMatriz().DeletarItem(gutatividadesmatriz.Id, oCnn, null);
            }

            return gutatividadesmatriz;
        });
    }

    public async Task<GetColumnsResponse?> GetColumns([FromBody] GetColumns parameters, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        return !Uris.ValidaUri(uri, _uris) ? throw new Exception("GUTAtividadesMatriz: URI inválida") : await Task.Run(() =>
        {
            if (parameters == null || parameters.Id.IsEmptyIDNumber() || parameters.Columns == null || parameters?.Columns?.Count() == 0)
            {
                return null;
            }

            using var scope = Configuracoes.CreateConnectionScope(uri);
            var oCnn = scope.Connection;
            if (oCnn == null)
            {
                return null;
            }

            using var dbRec = new DBGUTAtividadesMatriz(parameters?.Id ?? throw new Exception("Id == null"), oCnn);
            var campos = new List<ColumnValueItem>();
            foreach (var column in parameters?.Columns!)
                if (column != null && column.Length > 0)
                {
                    var value = dbRec.GetValueByNameField($"{DBGUTAtividadesMatrizDicInfo.TablePrefix}{char.ToUpper(column[0])}{column[1..]}");
                    if (value != null)
                        campos.Add(new ColumnValueItem(column, value));
                }

            var result = new GetColumnsResponse
            {
                Id = parameters.Id,
                Columns = campos
            };
            return result;
        });
    }

    public async Task<bool> UpdateColumns([FromBody] UpdateColumnsRequest parameters, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        return !Uris.ValidaUri(uri, _uris) ? throw new Exception("GUTAtividadesMatriz: URI inválida") : await Task.Run(() =>
        {
            if (parameters == null || parameters.Id.IsEmptyIDNumber() || parameters.Columns == null || parameters?.Columns?.Count() == 0)
            {
                return false;
            }

            using var scope = Configuracoes.CreateConnectionScopeRw(uri);
            var oCnn = scope.Connection;
            if (oCnn == null)
            {
                return false;
            }

            using var dbRec = new DBGUTAtividadesMatriz(parameters?.Id ?? throw new Exception("Id is null"), oCnn);
            foreach (var(column, value)in parameters?.Columns!)
                dbRec.SetValueByNameField($"{DBGUTAtividadesMatrizDicInfo.TablePrefix}{char.ToUpper(column[0])}{column[1..]}", value);
            dbRec.AuditorQuem = UserTools.GetAuthenticatedUserId(_httpContextAccessor);
            return dbRec.Update(oCnn) == 0;
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

    private static string WFiltro(Filters.FilterGUTAtividadesMatriz filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var cWhere = filtro.GUTMatriz == -2147483648 ? string.Empty : DBGUTAtividadesMatrizDicInfo.GUTMatrizSql(filtro.GUTMatriz);
        cWhere += filtro.GUTAtividade == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBGUTAtividadesMatrizDicInfo.GUTAtividadeSql(filtro.GUTAtividade);
        return cWhere;
    }
}