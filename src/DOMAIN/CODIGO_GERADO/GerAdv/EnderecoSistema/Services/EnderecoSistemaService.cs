#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class EnderecoSistemaService(IOptions<AppSettings> appSettings, IEnderecoSistemaReader reader, IEnderecoSistemaValidation validation, IEnderecoSistemaWriter writer, ITipoEnderecoSistemaReader tipoenderecosistemaReader, IProcessosReader processosReader, IHttpContextAccessor httpContextAccessor, HybridCache cache) : IEnderecoSistemaService, IDisposable
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly string _uris = appSettings.Value.ValidUris;
    private readonly HybridCache _cache = cache;
    private bool _disposed;
    public async Task<IEnumerable<EnderecoSistemaResponse>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("EnderecoSistema: URI inválida");
            }
        }

        var cacheKey = $"{uri}-EnderecoSistema-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<EnderecoSistemaResponse>> GetDataAllAsync(int max, string uri, CancellationToken token)
    {
        var query = $@"SELECT DISTINCT TOP {max} 
                   {DBEnderecoSistema.SensivelCamposSqlX} 
                   FROM {DBEnderecoSistema.PTabelaNome} (NOLOCK)
                   ORDER BY {DBEnderecoSistemaDicInfo.CampoNome}
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var connection = Configuracoes.ConnectionByUri(uri);
        var lista = new List<DBEnderecoSistema>(max);
        await foreach (var item in DBEnderecoSistema.ListarAsync(query, string.Empty, string.Empty, connection).WithCancellation(token).ConfigureAwait(false))
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

    public async Task<IEnumerable<EnderecoSistemaResponse>> Filter(Filters.FilterEnderecoSistema filtro, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            throw new Exception("EnderecoSistema: URI inválida");
        }

        return await Task.Run(() =>
        {
            using var scope = Configuracoes.CreateConnectionScope(uri);
            var oCnn = scope.Connection;
            if (oCnn == null)
            {
                return[];
            }

            var result = new List<EnderecoSistemaResponse>();
            var cWhere = filtro == null ? string.Empty : WFiltro(filtro!);
            var list = DBEnderecoSistema.Listar("", cWhere, "", Configuracoes.ConnectionByUri(uri));
            if (list != null)
            {
                foreach (var item in list)
                    result.Add(reader.Read(item)!);
            }

            return result;
        });
    }

    public async Task<EnderecoSistemaResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("EnderecoSistema: URI inválida");
            }
        }

        if (id.IsEmptyIDNumber())
        {
            return new EnderecoSistemaResponse();
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
            var result = await _cache.GetOrCreateAsync($"{uri}-EnderecoSistema-GetById-{id}-{keyCache}", async cancel => await GetDataByIdAsync(id, uri, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"EnderecoSistema - {uri}-: GetById - {ex.Message}");
        }
    }

    private async Task<EnderecoSistemaResponse?> GetDataByIdAsync(int id, string uri, CancellationToken token)
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

    public async Task<EnderecoSistemaResponse?> AddAndUpdate([FromBody] Models.EnderecoSistema regEnderecoSistema, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("EnderecoSistema: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regEnderecoSistema == null)
            {
                return null;
            }

            using var scope = Configuracoes.CreateConnectionScopeRw(uri);
            var oCnn = scope.Connection;
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regEnderecoSistema, this, tipoenderecosistemaReader, processosReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception($"EnderecoSistema: {validade}");
            }

            var saved = writer.Write(regEnderecoSistema, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
            return reader.Read(saved.ID, oCnn);
        });
    }

    public async Task<EnderecoSistemaResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("EnderecoSistema: URI inválida");
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

            var enderecosistema = reader.Read(id, oCnn);
            if (enderecosistema != null)
            {
                new DBEnderecoSistema().DeletarItem(enderecosistema.Id, oCnn, null);
            }

            return enderecosistema;
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

    private static string WFiltro(Filters.FilterEnderecoSistema filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var cWhere = filtro.Cadastro == -2147483648 ? string.Empty : DBEnderecoSistemaDicInfo.CadastroSql(filtro.Cadastro);
        cWhere += filtro.CadastroExCod == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBEnderecoSistemaDicInfo.CadastroExCodSql(filtro.CadastroExCod);
        cWhere += filtro.TipoEnderecoSistema == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBEnderecoSistemaDicInfo.TipoEnderecoSistemaSql(filtro.TipoEnderecoSistema);
        cWhere += filtro.Processo == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBEnderecoSistemaDicInfo.ProcessoSql(filtro.Processo);
        cWhere += filtro.Motivo.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBEnderecoSistemaDicInfo.MotivoSql(filtro.Motivo);
        cWhere += filtro.ContatoNoLocal.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBEnderecoSistemaDicInfo.ContatoNoLocalSql(filtro.ContatoNoLocal);
        cWhere += filtro.Cidade == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBEnderecoSistemaDicInfo.CidadeSql(filtro.Cidade);
        cWhere += filtro.Endereco.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBEnderecoSistemaDicInfo.EnderecoSql(filtro.Endereco);
        cWhere += filtro.Bairro.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBEnderecoSistemaDicInfo.BairroSql(filtro.Bairro);
        cWhere += filtro.CEP.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBEnderecoSistemaDicInfo.CEPSql(filtro.CEP);
        cWhere += filtro.Fone.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBEnderecoSistemaDicInfo.FoneSql(filtro.Fone);
        cWhere += filtro.Fax.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBEnderecoSistemaDicInfo.FaxSql(filtro.Fax);
        cWhere += filtro.Observacao.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBEnderecoSistemaDicInfo.ObservacaoSql(filtro.Observacao);
        cWhere += filtro.GUID.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBEnderecoSistemaDicInfo.GUIDSql(filtro.GUID);
        return cWhere;
    }
}