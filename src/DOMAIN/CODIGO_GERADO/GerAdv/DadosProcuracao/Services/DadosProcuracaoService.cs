#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class DadosProcuracaoService(IOptions<AppSettings> appSettings, IDadosProcuracaoReader reader, IDadosProcuracaoValidation validation, IDadosProcuracaoWriter writer, IClientesReader clientesReader, IHttpContextAccessor httpContextAccessor, HybridCache cache, IMemoryCache memory) : IDadosProcuracaoService, IDisposable
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly IOptions<AppSettings> _appSettings = appSettings;
    private readonly HybridCache _cache = cache;
    private readonly IMemoryCache _memoryCache = memory;
    private bool _disposed;
    public async Task<IEnumerable<DadosProcuracaoResponseAll>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("DadosProcuracao: URI inválida");
            }
        }

        var cacheKey = $"{uri}-DadosProcuracao-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, string.Empty, [], uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<DadosProcuracaoResponseAll>> GetDataAllAsync(int max, string where, List<SqlParameter> parameters, string uri, CancellationToken token)
    {
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        if (oCnn == null)
        {
            throw new Exception("Conexão nula.");
        }

        var query = $@"SELECT TOP ({max})
                   {DBDadosProcuracao.SensivelCamposSqlX}, [Clientes].[cliNome]
                   FROM {DBDadosProcuracao.PTabelaNome.dbo(oCnn)} (NOLOCK)
                   LEFT JOIN {"Clientes".dbo(oCnn)} (NOLOCK) ON [Clientes].[cliCodigo]=[DadosProcuracao].[prcCliente]
 
                   {where}
                   ORDER BY [DadosProcuracao].[]
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var lista = new List<DadosProcuracaoResponseAll>(max);
        var ds = await ConfiguracoesDBT.GetDataTable2Async(query, parameters, oCnn);
        if (ds != null)
            foreach (DataRow item in ds.Rows)
            {
                var dbRec = new DBDadosProcuracao(item);
                if (dbRec.ID.IsEmptyIDNumber())
                {
                    continue;
                }

                var dadosprocuracao = reader.ReadAll(dbRec, item);
                if (dadosprocuracao != null)
                {
                    lista.Add(dadosprocuracao);
                }
            }

        return lista;
    }

    public async Task<IEnumerable<DadosProcuracaoResponseAll>> Filter(Filters.FilterDadosProcuracao filtro, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        if (oCnn == null)
        {
            throw new Exception("Conexão nula.");
        }

        var filtroResult = filtro == null ? null : WFiltro(filtro!);
        string where = filtroResult?.where ?? string.Empty;
        List<SqlParameter> parameters = filtroResult?.parametros ?? [];
        var keyCache = await reader.ReadStringAuditor(uri, where, parameters, oCnn);
        var cacheKey = $"{uri}-DadosProcuracao-Filter-{where.GetHashCode()}{parameters.GetHashCode()}{keyCache}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(BaseConsts.PMaxItens, string.IsNullOrEmpty(where) ? string.Empty : TSql.Where + where, parameters, uri, cancel), entryOptions, cancellationToken: new());
    }

    public async Task<DadosProcuracaoResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (id < 1)
        {
            return new DadosProcuracaoResponse();
        }

        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxSecondsCacheId)
        };
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        try
        {
            var keyCache = await reader.ReadStringAuditor(id, uri, oCnn);
            var result = await _cache.GetOrCreateAsync($"{uri}-DadosProcuracao-GetById-{id}-{keyCache}", async cancel => await GetDataByIdAsync(id, oCnn, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"DadosProcuracao - {uri}-: GetById");
        }
    }

    private async Task<DadosProcuracaoResponse?> GetDataByIdAsync(int id, MsiSqlConnection oCnn, CancellationToken token) => await Task.Run(() => reader.Read(id, oCnn));
    public async Task<DadosProcuracaoResponse?> AddAndUpdate([FromBody] Models.DadosProcuracao regDadosProcuracao, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("DadosProcuracao: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regDadosProcuracao == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regDadosProcuracao, this, clientesReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            var saved = writer.Write(regDadosProcuracao, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
            return reader.Read(saved, oCnn);
        });
    }

    public async Task<DadosProcuracaoResponse?> Validation([FromBody] Models.DadosProcuracao regDadosProcuracao, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("DadosProcuracao: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regDadosProcuracao == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regDadosProcuracao, this, clientesReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            if (regDadosProcuracao.Id.IsEmptyIDNumber())
            {
                return new DadosProcuracaoResponse();
            }

            return reader.Read(regDadosProcuracao.Id, oCnn);
        });
    }

    public async Task<DadosProcuracaoResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("DadosProcuracao: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (id.IsEmptyIDNumber())
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var deleteValidation = await validation.CanDelete(id, this, uri, oCnn);
            if (deleteValidation.Length > 0)
            {
                throw new Exception(deleteValidation);
            }

            var dadosprocuracao = reader.Read(id, oCnn);
            try
            {
                if (dadosprocuracao != null)
                {
                    writer.Delete(dadosprocuracao, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
                    if (_memoryCache is MemoryCache memCache)
                    {
                        memCache.Compact(1.0);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return dadosprocuracao;
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

    private static (string where, List<SqlParameter> parametros)? WFiltro(Filters.FilterDadosProcuracao filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var parameters = new List<SqlParameter>();
        if (filtro.Cliente != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBDadosProcuracaoDicInfo.Cliente)}", filtro.Cliente));
        }

        if (!string.IsNullOrEmpty(filtro.EstadoCivil))
        {
            parameters.Add(new($"@{nameof(DBDadosProcuracaoDicInfo.EstadoCivil)}", filtro.EstadoCivil));
        }

        if (!string.IsNullOrEmpty(filtro.Nacionalidade))
        {
            parameters.Add(new($"@{nameof(DBDadosProcuracaoDicInfo.Nacionalidade)}", filtro.Nacionalidade));
        }

        if (!string.IsNullOrEmpty(filtro.Profissao))
        {
            parameters.Add(new($"@{nameof(DBDadosProcuracaoDicInfo.Profissao)}", filtro.Profissao));
        }

        if (!string.IsNullOrEmpty(filtro.CTPS))
        {
            parameters.Add(new($"@{nameof(DBDadosProcuracaoDicInfo.CTPS)}", filtro.CTPS));
        }

        if (!string.IsNullOrEmpty(filtro.PisPasep))
        {
            parameters.Add(new($"@{nameof(DBDadosProcuracaoDicInfo.PisPasep)}", filtro.PisPasep));
        }

        if (!string.IsNullOrEmpty(filtro.Remuneracao))
        {
            parameters.Add(new($"@{nameof(DBDadosProcuracaoDicInfo.Remuneracao)}", filtro.Remuneracao));
        }

        if (!string.IsNullOrEmpty(filtro.Objeto))
        {
            parameters.Add(new($"@{nameof(DBDadosProcuracaoDicInfo.Objeto)}", filtro.Objeto));
        }

        if (!string.IsNullOrEmpty(filtro.GUID))
        {
            parameters.Add(new($"@{nameof(DBDadosProcuracaoDicInfo.GUID)}", filtro.GUID));
        }

        var cWhere = filtro.Cliente == int.MinValue ? string.Empty : $"{DBDadosProcuracaoDicInfo.Cliente} = @{nameof(DBDadosProcuracaoDicInfo.Cliente)}";
        cWhere += filtro.EstadoCivil.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBDadosProcuracaoDicInfo.EstadoCivil} = @{nameof(DBDadosProcuracaoDicInfo.EstadoCivil)}";
        cWhere += filtro.Nacionalidade.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBDadosProcuracaoDicInfo.Nacionalidade} = @{nameof(DBDadosProcuracaoDicInfo.Nacionalidade)}";
        cWhere += filtro.Profissao.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBDadosProcuracaoDicInfo.Profissao} = @{nameof(DBDadosProcuracaoDicInfo.Profissao)}";
        cWhere += filtro.CTPS.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBDadosProcuracaoDicInfo.CTPS} = @{nameof(DBDadosProcuracaoDicInfo.CTPS)}";
        cWhere += filtro.PisPasep.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBDadosProcuracaoDicInfo.PisPasep} = @{nameof(DBDadosProcuracaoDicInfo.PisPasep)}";
        cWhere += filtro.Remuneracao.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBDadosProcuracaoDicInfo.Remuneracao} = @{nameof(DBDadosProcuracaoDicInfo.Remuneracao)}";
        cWhere += filtro.Objeto.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBDadosProcuracaoDicInfo.Objeto} = @{nameof(DBDadosProcuracaoDicInfo.Objeto)}";
        cWhere += filtro.GUID.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBDadosProcuracaoDicInfo.GUID} = @{nameof(DBDadosProcuracaoDicInfo.GUID)}";
        return (cWhere, parameters);
    }
}