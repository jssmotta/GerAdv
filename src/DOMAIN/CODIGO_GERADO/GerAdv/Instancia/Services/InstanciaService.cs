#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class InstanciaService(IOptions<AppSettings> appSettings, IInstanciaReader reader, IInstanciaValidation validation, IInstanciaWriter writer, IProcessosReader processosReader, IAcaoReader acaoReader, IForoReader foroReader, ITipoRecursoReader tiporecursoReader, INENotasService nenotasService, IProSucumbenciaService prosucumbenciaService, ITribunalService tribunalService, IHttpContextAccessor httpContextAccessor, HybridCache cache, IMemoryCache memory) : IInstanciaService, IDisposable
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly IOptions<AppSettings> _appSettings = appSettings;
    private readonly HybridCache _cache = cache;
    private readonly IMemoryCache _memoryCache = memory;
    private bool _disposed;
    public async Task<IEnumerable<InstanciaResponseAll>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("Instancia: URI inválida");
            }
        }

        var cacheKey = $"{uri}-Instancia-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, string.Empty, [], uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<InstanciaResponseAll>> GetDataAllAsync(int max, string where, List<SqlParameter> parameters, string uri, CancellationToken token)
    {
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        if (oCnn == null)
        {
            throw new Exception("Conexão nula.");
        }

        var query = $@"SELECT TOP ({max})
                   {DBInstancia.SensivelCamposSqlX}, [Processos].[proNroPasta],[Acao].[acaDescricao],[Foro].[forNome],[TipoRecurso].[trcDescricao]
                   FROM {DBInstancia.PTabelaNome.dbo(oCnn)} (NOLOCK)
                   LEFT JOIN {"Processos".dbo(oCnn)} (NOLOCK) ON [Processos].[proCodigo]=[Instancia].[insProcesso]
LEFT JOIN {"Acao".dbo(oCnn)} (NOLOCK) ON [Acao].[acaCodigo]=[Instancia].[insAcao]
LEFT JOIN {"Foro".dbo(oCnn)} (NOLOCK) ON [Foro].[forCodigo]=[Instancia].[insForo]
LEFT JOIN {"TipoRecurso".dbo(oCnn)} (NOLOCK) ON [TipoRecurso].[trcCodigo]=[Instancia].[insTipoRecurso]
 
                   {where}
                   ORDER BY [Instancia].[insNroProcesso]
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var lista = new List<InstanciaResponseAll>(max);
        var ds = await ConfiguracoesDBT.GetDataTable2Async(query, parameters, oCnn);
        if (ds != null)
            foreach (DataRow item in ds.Rows)
            {
                var dbRec = new DBInstancia(item);
                if (dbRec.ID.IsEmptyIDNumber())
                {
                    continue;
                }

                var instancia = reader.ReadAll(dbRec, item);
                if (instancia != null)
                {
                    lista.Add(instancia);
                }
            }

        return lista;
    }

    public async Task<IEnumerable<InstanciaResponseAll>> Filter(Filters.FilterInstancia filtro, [FromRoute, Required] string uri)
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
        var cacheKey = $"{uri}-Instancia-Filter-{where.GetHashCode()}{parameters.GetHashCode()}{keyCache}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(BaseConsts.PMaxItens, string.IsNullOrEmpty(where) ? string.Empty : TSql.Where + where, parameters, uri, cancel), entryOptions, cancellationToken: new());
    }

    public async Task<InstanciaResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (id < 1)
        {
            return new InstanciaResponse();
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
            var result = await _cache.GetOrCreateAsync($"{uri}-Instancia-GetById-{id}-{keyCache}", async cancel => await GetDataByIdAsync(id, oCnn, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"Instancia - {uri}-: GetById");
        }
    }

    private async Task<InstanciaResponse?> GetDataByIdAsync(int id, MsiSqlConnection oCnn, CancellationToken token) => await Task.Run(() => reader.Read(id, oCnn));
    public async Task<InstanciaResponse?> AddAndUpdate([FromBody] Models.Instancia regInstancia, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("Instancia: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regInstancia == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regInstancia, this, processosReader, acaoReader, foroReader, tiporecursoReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            var saved = writer.Write(regInstancia, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
            return reader.Read(saved.ID, oCnn);
        });
    }

    public async Task<InstanciaResponse?> Validation([FromBody] Models.Instancia regInstancia, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("Instancia: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regInstancia == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regInstancia, this, processosReader, acaoReader, foroReader, tiporecursoReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            if (regInstancia.Id.IsEmptyIDNumber())
            {
                return new InstanciaResponse();
            }

            return reader.Read(regInstancia.Id, oCnn);
        });
    }

    public async Task<InstanciaResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("Instancia: URI inválida");
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

            var deleteValidation = await validation.CanDelete(id, this, nenotasService, prosucumbenciaService, tribunalService, uri, oCnn);
            if (deleteValidation.Length > 0)
            {
                throw new Exception(deleteValidation);
            }

            var instancia = reader.Read(id, oCnn);
            try
            {
                if (instancia != null)
                {
                    writer.Delete(instancia, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
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

            return instancia;
        });
    }

    public async Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterInstancia? filtro, [FromRoute, Required] string uri, CancellationToken token)
    {
        // Tracking: 20250606-0
        ThrowIfDisposed();
        var filtroResult = filtro == null ? null : WFiltro(filtro!);
        string where = filtroResult?.where ?? string.Empty;
        List<SqlParameter> parameters = filtroResult?.parametros ?? [];
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        if (oCnn == null)
        {
            throw new Exception($"Coneão nula.");
        }

        var keyCache = await reader.ReadStringAuditor(uri, "", [], oCnn);
        var cacheKey = $"{uri}-Instancia-{max}-{where.GetHashCode()}-GetListN-{keyCache}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxSecondsCacheId)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataListNAsync(max, uri, where, parameters, cancel), entryOptions, cancellationToken: token) ?? [];
    }

    private async Task<IEnumerable<NomeID>> GetDataListNAsync(int max, string uri, string where, List<SqlParameter> parameters, CancellationToken token)
    {
        return await Task.Run(() =>
        {
            var result = new List<NomeID>(max);
            foreach (var item in reader.ListarN(max, uri, where, parameters, DBInstanciaDicInfo.CampoNome))
            {
                if (token.IsCancellationRequested)
                    break;
                if (item?.FNome != null)
                {
                    result.Add(new NomeID { Nome = item.FNome, ID = item.ID });
                }
            }

            return result;
        }, token);
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

    private static (string where, List<SqlParameter> parametros)? WFiltro(Filters.FilterInstancia filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var parameters = new List<SqlParameter>();
        if (!string.IsNullOrEmpty(filtro.LiminarPedida))
        {
            parameters.Add(new($"@{nameof(DBInstanciaDicInfo.LiminarPedida)}", filtro.LiminarPedida));
        }

        if (!string.IsNullOrEmpty(filtro.Objeto))
        {
            parameters.Add(new($"@{nameof(DBInstanciaDicInfo.Objeto)}", filtro.Objeto));
        }

        if (filtro.StatusResultado != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBInstanciaDicInfo.StatusResultado)}", filtro.StatusResultado));
        }

        if (filtro.Processo != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBInstanciaDicInfo.Processo)}", filtro.Processo));
        }

        if (!string.IsNullOrEmpty(filtro.LiminarResultado))
        {
            parameters.Add(new($"@{nameof(DBInstanciaDicInfo.LiminarResultado)}", filtro.LiminarResultado));
        }

        if (!string.IsNullOrEmpty(filtro.NroProcesso))
        {
            parameters.Add(new($"@{nameof(DBInstanciaDicInfo.NroProcesso)}", filtro.NroProcesso));
        }

        if (filtro.Divisao != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBInstanciaDicInfo.Divisao)}", filtro.Divisao));
        }

        if (filtro.Comarca != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBInstanciaDicInfo.Comarca)}", filtro.Comarca));
        }

        if (filtro.SubDivisao != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBInstanciaDicInfo.SubDivisao)}", filtro.SubDivisao));
        }

        if (filtro.Acao != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBInstanciaDicInfo.Acao)}", filtro.Acao));
        }

        if (filtro.Foro != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBInstanciaDicInfo.Foro)}", filtro.Foro));
        }

        if (filtro.TipoRecurso != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBInstanciaDicInfo.TipoRecurso)}", filtro.TipoRecurso));
        }

        if (!string.IsNullOrEmpty(filtro.ZKey))
        {
            parameters.Add(new($"@{nameof(DBInstanciaDicInfo.ZKey)}", filtro.ZKey));
        }

        if (filtro.ZKeyQuem != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBInstanciaDicInfo.ZKeyQuem)}", filtro.ZKeyQuem));
        }

        if (!string.IsNullOrEmpty(filtro.NroAntigo))
        {
            parameters.Add(new($"@{nameof(DBInstanciaDicInfo.NroAntigo)}", filtro.NroAntigo));
        }

        if (!string.IsNullOrEmpty(filtro.AccessCode))
        {
            parameters.Add(new($"@{nameof(DBInstanciaDicInfo.AccessCode)}", filtro.AccessCode));
        }

        if (filtro.Julgador != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBInstanciaDicInfo.Julgador)}", filtro.Julgador));
        }

        if (!string.IsNullOrEmpty(filtro.ZKeyIA))
        {
            parameters.Add(new($"@{nameof(DBInstanciaDicInfo.ZKeyIA)}", filtro.ZKeyIA));
        }

        if (!string.IsNullOrEmpty(filtro.GUID))
        {
            parameters.Add(new($"@{nameof(DBInstanciaDicInfo.GUID)}", filtro.GUID));
        }

        var cWhere = filtro.LiminarPedida.IsEmpty() ? string.Empty : $"{DBInstanciaDicInfo.LiminarPedida} = @{nameof(DBInstanciaDicInfo.LiminarPedida)}";
        cWhere += filtro.Objeto.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBInstanciaDicInfo.Objeto} = @{nameof(DBInstanciaDicInfo.Objeto)}";
        cWhere += filtro.StatusResultado == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBInstanciaDicInfo.StatusResultado} = @{nameof(DBInstanciaDicInfo.StatusResultado)}";
        cWhere += filtro.Processo == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBInstanciaDicInfo.Processo} = @{nameof(DBInstanciaDicInfo.Processo)}";
        cWhere += filtro.LiminarResultado.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBInstanciaDicInfo.LiminarResultado} = @{nameof(DBInstanciaDicInfo.LiminarResultado)}";
        cWhere += filtro.NroProcesso.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBInstanciaDicInfo.NroProcesso} = @{nameof(DBInstanciaDicInfo.NroProcesso)}";
        cWhere += filtro.Divisao == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBInstanciaDicInfo.Divisao} = @{nameof(DBInstanciaDicInfo.Divisao)}";
        cWhere += filtro.Comarca == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBInstanciaDicInfo.Comarca} = @{nameof(DBInstanciaDicInfo.Comarca)}";
        cWhere += filtro.SubDivisao == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBInstanciaDicInfo.SubDivisao} = @{nameof(DBInstanciaDicInfo.SubDivisao)}";
        cWhere += filtro.Acao == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBInstanciaDicInfo.Acao} = @{nameof(DBInstanciaDicInfo.Acao)}";
        cWhere += filtro.Foro == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBInstanciaDicInfo.Foro} = @{nameof(DBInstanciaDicInfo.Foro)}";
        cWhere += filtro.TipoRecurso == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBInstanciaDicInfo.TipoRecurso} = @{nameof(DBInstanciaDicInfo.TipoRecurso)}";
        cWhere += filtro.ZKey.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBInstanciaDicInfo.ZKey} = @{nameof(DBInstanciaDicInfo.ZKey)}";
        cWhere += filtro.ZKeyQuem == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBInstanciaDicInfo.ZKeyQuem} = @{nameof(DBInstanciaDicInfo.ZKeyQuem)}";
        cWhere += filtro.NroAntigo.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBInstanciaDicInfo.NroAntigo} = @{nameof(DBInstanciaDicInfo.NroAntigo)}";
        cWhere += filtro.AccessCode.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBInstanciaDicInfo.AccessCode} = @{nameof(DBInstanciaDicInfo.AccessCode)}";
        cWhere += filtro.Julgador == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBInstanciaDicInfo.Julgador} = @{nameof(DBInstanciaDicInfo.Julgador)}";
        cWhere += filtro.ZKeyIA.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBInstanciaDicInfo.ZKeyIA} = @{nameof(DBInstanciaDicInfo.ZKeyIA)}";
        cWhere += filtro.GUID.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBInstanciaDicInfo.GUID} = @{nameof(DBInstanciaDicInfo.GUID)}";
        return (cWhere, parameters);
    }
}