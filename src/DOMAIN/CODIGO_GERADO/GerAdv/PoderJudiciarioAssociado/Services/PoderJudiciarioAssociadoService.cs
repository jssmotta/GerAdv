﻿#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class PoderJudiciarioAssociadoService(IOptions<AppSettings> appSettings, IPoderJudiciarioAssociadoReader reader, IPoderJudiciarioAssociadoValidation validation, IPoderJudiciarioAssociadoWriter writer, IJusticaReader justicaReader, IAreaReader areaReader, ITribunalReader tribunalReader, IForoReader foroReader, IHttpContextAccessor httpContextAccessor, HybridCache cache) : IPoderJudiciarioAssociadoService, IDisposable
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly string _uris = appSettings.Value.ValidUris;
    private readonly HybridCache _cache = cache;
    private bool _disposed;
    public async Task<IEnumerable<PoderJudiciarioAssociadoResponse>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("PoderJudiciarioAssociado: URI inválida");
            }
        }

        var cacheKey = $"{uri}-PoderJudiciarioAssociado-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<PoderJudiciarioAssociadoResponse>> GetDataAllAsync(int max, string uri, CancellationToken token)
    {
        var query = $@"SELECT DISTINCT TOP {max} 
                   {DBPoderJudiciarioAssociado.SensivelCamposSqlX} 
                   FROM {DBPoderJudiciarioAssociado.PTabelaNome} (NOLOCK)
                   ORDER BY {DBPoderJudiciarioAssociadoDicInfo.CampoNome}
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var connection = Configuracoes.ConnectionByUri(uri);
        var lista = new List<DBPoderJudiciarioAssociado>(max);
        await foreach (var item in DBPoderJudiciarioAssociado.ListarAsync(query, string.Empty, string.Empty, connection).WithCancellation(token).ConfigureAwait(false))
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

    public async Task<IEnumerable<PoderJudiciarioAssociadoResponse>> Filter(Filters.FilterPoderJudiciarioAssociado filtro, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            throw new Exception("PoderJudiciarioAssociado: URI inválida");
        }

        return await Task.Run(() =>
        {
            using var scope = Configuracoes.CreateConnectionScope(uri);
            var oCnn = scope.Connection;
            if (oCnn == null)
            {
                return[];
            }

            var result = new List<PoderJudiciarioAssociadoResponse>();
            var cWhere = filtro == null ? string.Empty : WFiltro(filtro!);
            var list = DBPoderJudiciarioAssociado.Listar("", cWhere, "", Configuracoes.ConnectionByUri(uri));
            if (list != null)
            {
                foreach (var item in list)
                    result.Add(reader.Read(item)!);
            }

            return result;
        });
    }

    public async Task<PoderJudiciarioAssociadoResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("PoderJudiciarioAssociado: URI inválida");
            }
        }

        if (id.IsEmptyIDNumber())
        {
            return new PoderJudiciarioAssociadoResponse();
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
            var result = await _cache.GetOrCreateAsync($"{uri}-PoderJudiciarioAssociado-GetById-{id}-{keyCache}", async cancel => await GetDataByIdAsync(id, uri, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"PoderJudiciarioAssociado - {uri}-: GetById - {ex.Message}");
        }
    }

    private async Task<PoderJudiciarioAssociadoResponse?> GetDataByIdAsync(int id, string uri, CancellationToken token)
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

    public async Task<PoderJudiciarioAssociadoResponse?> AddAndUpdate([FromBody] Models.PoderJudiciarioAssociado regPoderJudiciarioAssociado, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("PoderJudiciarioAssociado: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regPoderJudiciarioAssociado == null)
            {
                return null;
            }

            using var scope = Configuracoes.CreateConnectionScopeRw(uri);
            var oCnn = scope.Connection;
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regPoderJudiciarioAssociado, this, justicaReader, areaReader, tribunalReader, foroReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception($"PoderJudiciarioAssociado: {validade}");
            }

            var saved = writer.Write(regPoderJudiciarioAssociado, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
            return reader.Read(saved.ID, oCnn);
        });
    }

    public async Task<PoderJudiciarioAssociadoResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("PoderJudiciarioAssociado: URI inválida");
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

            var poderjudiciarioassociado = reader.Read(id, oCnn);
            if (poderjudiciarioassociado != null)
            {
                new DBPoderJudiciarioAssociado().DeletarItem(poderjudiciarioassociado.Id, oCnn, null);
            }

            return poderjudiciarioassociado;
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

    private static string WFiltro(Filters.FilterPoderJudiciarioAssociado filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var cWhere = filtro.Justica == -2147483648 ? string.Empty : DBPoderJudiciarioAssociadoDicInfo.JusticaSql(filtro.Justica);
        cWhere += filtro.JusticaNome.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBPoderJudiciarioAssociadoDicInfo.JusticaNomeSql(filtro.JusticaNome);
        cWhere += filtro.Area == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBPoderJudiciarioAssociadoDicInfo.AreaSql(filtro.Area);
        cWhere += filtro.AreaNome.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBPoderJudiciarioAssociadoDicInfo.AreaNomeSql(filtro.AreaNome);
        cWhere += filtro.Tribunal == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBPoderJudiciarioAssociadoDicInfo.TribunalSql(filtro.Tribunal);
        cWhere += filtro.TribunalNome.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBPoderJudiciarioAssociadoDicInfo.TribunalNomeSql(filtro.TribunalNome);
        cWhere += filtro.Foro == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBPoderJudiciarioAssociadoDicInfo.ForoSql(filtro.Foro);
        cWhere += filtro.ForoNome.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBPoderJudiciarioAssociadoDicInfo.ForoNomeSql(filtro.ForoNome);
        cWhere += filtro.Cidade == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBPoderJudiciarioAssociadoDicInfo.CidadeSql(filtro.Cidade);
        cWhere += filtro.SubDivisaoNome.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBPoderJudiciarioAssociadoDicInfo.SubDivisaoNomeSql(filtro.SubDivisaoNome);
        cWhere += filtro.CidadeNome.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBPoderJudiciarioAssociadoDicInfo.CidadeNomeSql(filtro.CidadeNome);
        cWhere += filtro.SubDivisao == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBPoderJudiciarioAssociadoDicInfo.SubDivisaoSql(filtro.SubDivisao);
        cWhere += filtro.Tipo == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBPoderJudiciarioAssociadoDicInfo.TipoSql(filtro.Tipo);
        cWhere += filtro.GUID.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBPoderJudiciarioAssociadoDicInfo.GUIDSql(filtro.GUID);
        return cWhere;
    }
}