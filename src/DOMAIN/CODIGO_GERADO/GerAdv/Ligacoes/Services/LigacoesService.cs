#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class LigacoesService(IOptions<AppSettings> appSettings, ILigacoesReader reader, ILigacoesValidation validation, ILigacoesWriter writer, IClientesReader clientesReader, IRamalReader ramalReader, IProcessosReader processosReader, IRecadosService recadosService, IHttpContextAccessor httpContextAccessor, HybridCache cache, IMemoryCache memory) : ILigacoesService, IDisposable
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly IOptions<AppSettings> _appSettings = appSettings;
    private readonly HybridCache _cache = cache;
    private readonly IMemoryCache _memoryCache = memory;
    private bool _disposed;
    public async Task<IEnumerable<LigacoesResponseAll>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("Ligacoes: URI inválida");
            }
        }

        var cacheKey = $"{uri}-Ligacoes-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, string.Empty, [], uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<LigacoesResponseAll>> GetDataAllAsync(int max, string where, List<SqlParameter> parameters, string uri, CancellationToken token)
    {
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        if (oCnn == null)
        {
            throw new Exception("Conexão nula.");
        }

        var query = $@"SELECT TOP ({max})
                   {DBLigacoes.SensivelCamposSqlX}, cliNome,ramNome,proNroPasta
                   FROM {DBLigacoes.PTabelaNome.dbo(oCnn)} (NOLOCK)
                   LEFT JOIN {"Clientes".dbo(oCnn)} (NOLOCK) ON cliCodigo=ligCliente
LEFT JOIN {"Ramal".dbo(oCnn)} (NOLOCK) ON ramCodigo=ligRamal
LEFT JOIN {"Processos".dbo(oCnn)} (NOLOCK) ON proCodigo=ligProcesso
 
                   {where}
                   ORDER BY ligNome
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var lista = new List<LigacoesResponseAll>(max);
        var ds = await ConfiguracoesDBT.GetDataTable2Async(query, parameters, oCnn);
        if (ds != null)
            foreach (DataRow item in ds.Rows)
            {
                var dbRec = new DBLigacoes(item);
                if (dbRec.ID.IsEmptyIDNumber())
                {
                    continue;
                }

                var ligacoes = reader.ReadAll(dbRec, item);
                if (ligacoes != null)
                {
                    lista.Add(ligacoes);
                }
            }

        return lista;
    }

    public async Task<IEnumerable<LigacoesResponseAll>> Filter(Filters.FilterLigacoes filtro, [FromRoute, Required] string uri)
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
        var cacheKey = $"{uri}-Ligacoes-Filter-{where.GetHashCode()}{parameters.GetHashCode()}{keyCache}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(BaseConsts.PMaxItens, string.IsNullOrEmpty(where) ? string.Empty : TSql.Where + where, parameters, uri, cancel), entryOptions, cancellationToken: new());
    }

    public async Task<LigacoesResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (id < 1)
        {
            return new LigacoesResponse();
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
            var result = await _cache.GetOrCreateAsync($"{uri}-Ligacoes-GetById-{id}-{keyCache}", async cancel => await GetDataByIdAsync(id, oCnn, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"Ligacoes - {uri}-: GetById");
        }
    }

    private async Task<LigacoesResponse?> GetDataByIdAsync(int id, MsiSqlConnection oCnn, CancellationToken token) => await Task.Run(() => reader.Read(id, oCnn));
    public async Task<LigacoesResponse?> AddAndUpdate([FromBody] Models.Ligacoes regLigacoes, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("Ligacoes: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regLigacoes == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regLigacoes, this, clientesReader, ramalReader, processosReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception($"Ligacoes: {validade}");
            }

            var saved = writer.Write(regLigacoes, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
            return reader.Read(saved.ID, oCnn);
        });
    }

    public async Task<LigacoesResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("Ligacoes: URI inválida");
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

            var deleteValidation = await validation.CanDelete(id, this, recadosService, uri, oCnn);
            if (deleteValidation.Length > 0)
            {
                throw new Exception(deleteValidation);
            }

            var ligacoes = reader.Read(id, oCnn);
            try
            {
                if (ligacoes != null)
                {
                    writer.Delete(ligacoes, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
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

            return ligacoes;
        });
    }

    public async Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterLigacoes? filtro, [FromRoute, Required] string uri, CancellationToken token)
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
        var cacheKey = $"{uri}-Ligacoes-{max}-{where.GetHashCode()}-GetListN-{keyCache}";
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
            foreach (var item in reader.ListarN(max, uri, where, parameters, DBLigacoesDicInfo.CampoNome))
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

    private static (string where, List<SqlParameter> parametros)? WFiltro(Filters.FilterLigacoes filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var parameters = new List<SqlParameter>();
        if (!string.IsNullOrEmpty(filtro.Assunto))
        {
            parameters.Add(new($"@{nameof(DBLigacoesDicInfo.Assunto)}", filtro.Assunto));
        }

        if (filtro.AgeClienteAvisado != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBLigacoesDicInfo.AgeClienteAvisado)}", filtro.AgeClienteAvisado));
        }

        if (filtro.Cliente != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBLigacoesDicInfo.Cliente)}", filtro.Cliente));
        }

        if (!string.IsNullOrEmpty(filtro.Contato))
        {
            parameters.Add(new($"@{nameof(DBLigacoesDicInfo.Contato)}", filtro.Contato));
        }

        if (filtro.QuemID != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBLigacoesDicInfo.QuemID)}", filtro.QuemID));
        }

        if (filtro.Telefonista != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBLigacoesDicInfo.Telefonista)}", filtro.Telefonista));
        }

        if (!string.IsNullOrEmpty(filtro.Nome))
        {
            parameters.Add(new($"@{nameof(DBLigacoesDicInfo.Nome)}", filtro.Nome));
        }

        if (filtro.QuemCodigo != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBLigacoesDicInfo.QuemCodigo)}", filtro.QuemCodigo));
        }

        if (filtro.Solicitante != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBLigacoesDicInfo.Solicitante)}", filtro.Solicitante));
        }

        if (!string.IsNullOrEmpty(filtro.Para))
        {
            parameters.Add(new($"@{nameof(DBLigacoesDicInfo.Para)}", filtro.Para));
        }

        if (!string.IsNullOrEmpty(filtro.Fone))
        {
            parameters.Add(new($"@{nameof(DBLigacoesDicInfo.Fone)}", filtro.Fone));
        }

        if (filtro.Ramal != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBLigacoesDicInfo.Ramal)}", filtro.Ramal));
        }

        if (!string.IsNullOrEmpty(filtro.Status))
        {
            parameters.Add(new($"@{nameof(DBLigacoesDicInfo.Status)}", filtro.Status));
        }

        if (!string.IsNullOrEmpty(filtro.LigarPara))
        {
            parameters.Add(new($"@{nameof(DBLigacoesDicInfo.LigarPara)}", filtro.LigarPara));
        }

        if (filtro.Processo != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBLigacoesDicInfo.Processo)}", filtro.Processo));
        }

        if (filtro.Emotion != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBLigacoesDicInfo.Emotion)}", filtro.Emotion));
        }

        if (!string.IsNullOrEmpty(filtro.GUID))
        {
            parameters.Add(new($"@{nameof(DBLigacoesDicInfo.GUID)}", filtro.GUID));
        }

        var cWhere = filtro.Assunto.IsEmpty() ? string.Empty : $"{DBLigacoesDicInfo.Assunto} = @{nameof(DBLigacoesDicInfo.Assunto)}";
        cWhere += filtro.AgeClienteAvisado == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBLigacoesDicInfo.AgeClienteAvisado} = @{nameof(DBLigacoesDicInfo.AgeClienteAvisado)}";
        cWhere += filtro.Cliente == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBLigacoesDicInfo.Cliente} = @{nameof(DBLigacoesDicInfo.Cliente)}";
        cWhere += filtro.Contato.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBLigacoesDicInfo.Contato} = @{nameof(DBLigacoesDicInfo.Contato)}";
        cWhere += filtro.QuemID == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBLigacoesDicInfo.QuemID} = @{nameof(DBLigacoesDicInfo.QuemID)}";
        cWhere += filtro.Telefonista == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBLigacoesDicInfo.Telefonista} = @{nameof(DBLigacoesDicInfo.Telefonista)}";
        cWhere += filtro.Nome.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBLigacoesDicInfo.Nome} = @{nameof(DBLigacoesDicInfo.Nome)}";
        cWhere += filtro.QuemCodigo == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBLigacoesDicInfo.QuemCodigo} = @{nameof(DBLigacoesDicInfo.QuemCodigo)}";
        cWhere += filtro.Solicitante == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBLigacoesDicInfo.Solicitante} = @{nameof(DBLigacoesDicInfo.Solicitante)}";
        cWhere += filtro.Para.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBLigacoesDicInfo.Para} = @{nameof(DBLigacoesDicInfo.Para)}";
        cWhere += filtro.Fone.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBLigacoesDicInfo.Fone} = @{nameof(DBLigacoesDicInfo.Fone)}";
        cWhere += filtro.Ramal == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBLigacoesDicInfo.Ramal} = @{nameof(DBLigacoesDicInfo.Ramal)}";
        cWhere += filtro.Status.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBLigacoesDicInfo.Status} = @{nameof(DBLigacoesDicInfo.Status)}";
        cWhere += filtro.LigarPara.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBLigacoesDicInfo.LigarPara} = @{nameof(DBLigacoesDicInfo.LigarPara)}";
        cWhere += filtro.Processo == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBLigacoesDicInfo.Processo} = @{nameof(DBLigacoesDicInfo.Processo)}";
        cWhere += filtro.Emotion == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBLigacoesDicInfo.Emotion} = @{nameof(DBLigacoesDicInfo.Emotion)}";
        cWhere += filtro.GUID.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBLigacoesDicInfo.GUID} = @{nameof(DBLigacoesDicInfo.GUID)}";
        return (cWhere, parameters);
    }
}