#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class LivroCaixaService(IOptions<AppSettings> appSettings, ILivroCaixaReader reader, ILivroCaixaValidation validation, ILivroCaixaWriter writer, IProcessosReader processosReader, IHttpContextAccessor httpContextAccessor, HybridCache cache) : ILivroCaixaService, IDisposable
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly string _uris = appSettings.Value.ValidUris;
    private readonly HybridCache _cache = cache;
    private bool _disposed;
    public async Task<IEnumerable<LivroCaixaResponse>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("LivroCaixa: URI inválida");
            }
        }

        var cacheKey = $"{uri}-LivroCaixa-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<LivroCaixaResponse>> GetDataAllAsync(int max, string uri, CancellationToken token)
    {
        var query = $@"SELECT DISTINCT TOP {max} 
                   {DBLivroCaixa.SensivelCamposSqlX} 
                   FROM {DBLivroCaixa.PTabelaNome} (NOLOCK)
                   ORDER BY {DBLivroCaixaDicInfo.CampoNome}
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var connection = Configuracoes.ConnectionByUri(uri);
        var lista = new List<DBLivroCaixa>(max);
        await foreach (var item in DBLivroCaixa.ListarAsync(query, string.Empty, string.Empty, connection).WithCancellation(token).ConfigureAwait(false))
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

    public async Task<IEnumerable<LivroCaixaResponse>> Filter(Filters.FilterLivroCaixa filtro, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            throw new Exception("LivroCaixa: URI inválida");
        }

        return await Task.Run(() =>
        {
            using var scope = Configuracoes.CreateConnectionScope(uri);
            var oCnn = scope.Connection;
            if (oCnn == null)
            {
                return[];
            }

            var result = new List<LivroCaixaResponse>();
            var cWhere = filtro == null ? string.Empty : WFiltro(filtro!);
            var list = DBLivroCaixa.Listar("", cWhere, "", Configuracoes.ConnectionByUri(uri));
            if (list != null)
            {
                foreach (var item in list)
                    result.Add(reader.Read(item)!);
            }

            return result;
        });
    }

    public async Task<LivroCaixaResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("LivroCaixa: URI inválida");
            }
        }

        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxSecondsCacheId)
        };
        try
        {
            var result = await _cache.GetOrCreateAsync($"{uri}-LivroCaixa-GetById-{id}", async cancel => await GetDataByIdAsync(id, uri, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"LivroCaixa - {uri}-: GetById - {ex.Message}");
        }
    }

    private async Task<LivroCaixaResponse?> GetDataByIdAsync(int id, string uri, CancellationToken token)
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

    public async Task<LivroCaixaResponse?> AddAndUpdate([FromBody] Models.LivroCaixa regLivroCaixa, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("LivroCaixa: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regLivroCaixa == null)
            {
                return null;
            }

            using var scope = Configuracoes.CreateConnectionScopeRw(uri);
            var oCnn = scope.Connection;
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regLivroCaixa, this, processosReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception($"LivroCaixa: {validade}");
            }

            var saved = writer.Write(regLivroCaixa, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
            return reader.Read(saved.ID, oCnn);
        });
    }

    public async Task<LivroCaixaResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("LivroCaixa: URI inválida");
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

            var livrocaixa = reader.Read(id, oCnn);
            if (livrocaixa != null)
            {
                new DBLivroCaixa().DeletarItem(livrocaixa.Id, oCnn, null);
            }

            return livrocaixa;
        });
    }

    public async Task<GetColumnsResponse?> GetColumns([FromBody] GetColumns parameters, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        return !Uris.ValidaUri(uri, _uris) ? throw new Exception("LivroCaixa: URI inválida") : await Task.Run(() =>
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

            using var dbRec = new DBLivroCaixa(parameters?.Id ?? throw new Exception("Id == null"), oCnn);
            var campos = new List<ColumnValueItem>();
            foreach (var column in parameters?.Columns!)
                if (column != null && column.Length > 0)
                {
                    var value = dbRec.GetValueByNameField($"{DBLivroCaixaDicInfo.TablePrefix}{char.ToUpper(column[0])}{column[1..]}");
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
        return !Uris.ValidaUri(uri, _uris) ? throw new Exception("LivroCaixa: URI inválida") : await Task.Run(() =>
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

            using var dbRec = new DBLivroCaixa(parameters?.Id ?? throw new Exception("Id is null"), oCnn);
            foreach (var(column, value)in parameters?.Columns!)
                dbRec.SetValueByNameField($"{DBLivroCaixaDicInfo.TablePrefix}{char.ToUpper(column[0])}{column[1..]}", value);
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

    private static string WFiltro(Filters.FilterLivroCaixa filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var cWhere = filtro.IDDes == -2147483648 ? string.Empty : DBLivroCaixaDicInfo.IDDesSql(filtro.IDDes);
        cWhere += filtro.Pessoal == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBLivroCaixaDicInfo.PessoalSql(filtro.Pessoal);
        cWhere += filtro.IDHon == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBLivroCaixaDicInfo.IDHonSql(filtro.IDHon);
        cWhere += filtro.IDHonParc == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBLivroCaixaDicInfo.IDHonParcSql(filtro.IDHonParc);
        cWhere += filtro.Processo == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBLivroCaixaDicInfo.ProcessoSql(filtro.Processo);
        cWhere += filtro.Historico.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBLivroCaixaDicInfo.HistoricoSql(filtro.Historico);
        cWhere += filtro.Grupo == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBLivroCaixaDicInfo.GrupoSql(filtro.Grupo);
        return cWhere;
    }
}