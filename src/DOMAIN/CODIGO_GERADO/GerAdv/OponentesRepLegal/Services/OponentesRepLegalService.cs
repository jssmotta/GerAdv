#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class OponentesRepLegalService(IOptions<AppSettings> appSettings, IOponentesRepLegalReader reader, IOponentesRepLegalValidation validation, IOponentesRepLegalWriter writer, IOponentesReader oponentesReader, ICidadeReader cidadeReader, IHttpContextAccessor httpContextAccessor, HybridCache cache, IMemoryCache memory) : IOponentesRepLegalService, IDisposable
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly IOptions<AppSettings> _appSettings = appSettings;
    private readonly HybridCache _cache = cache;
    private readonly IMemoryCache _memoryCache = memory;
    private bool _disposed;
    public async Task<IEnumerable<OponentesRepLegalResponseAll>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("OponentesRepLegal: URI inválida");
            }
        }

        var cacheKey = $"{uri}-OponentesRepLegal-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, string.Empty, [], uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<OponentesRepLegalResponseAll>> GetDataAllAsync(int max, string where, List<SqlParameter> parameters, string uri, CancellationToken token)
    {
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        if (oCnn == null)
        {
            throw new Exception("Conexão nula.");
        }

        var query = $@"SELECT TOP ({max})
                   {DBOponentesRepLegal.SensivelCamposSqlX}, [Oponentes].[opoNome],[Cidade].[cidNome]
                   FROM {DBOponentesRepLegal.PTabelaNome.dbo(oCnn)} (NOLOCK)
                   LEFT JOIN {"Oponentes".dbo(oCnn)} (NOLOCK) ON [Oponentes].[opoCodigo]=[OponentesRepLegal].[oprOponente]
LEFT JOIN {"Cidade".dbo(oCnn)} (NOLOCK) ON [Cidade].[cidCodigo]=[OponentesRepLegal].[oprCidade]
 
                   {where}
                   ORDER BY [OponentesRepLegal].[oprNome]
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var lista = new List<OponentesRepLegalResponseAll>(max);
        var ds = await ConfiguracoesDBT.GetDataTable2Async(query, parameters, oCnn);
        if (ds != null)
            foreach (DataRow item in ds.Rows)
            {
                var dbRec = new DBOponentesRepLegal(item);
                if (dbRec.ID.IsEmptyIDNumber())
                {
                    continue;
                }

                var oponentesreplegal = reader.ReadAll(dbRec, item);
                if (oponentesreplegal != null)
                {
                    lista.Add(oponentesreplegal);
                }
            }

        return lista;
    }

    public async Task<IEnumerable<OponentesRepLegalResponseAll>> Filter(Filters.FilterOponentesRepLegal filtro, [FromRoute, Required] string uri)
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
        var cacheKey = $"{uri}-OponentesRepLegal-Filter-{where.GetHashCode()}{parameters.GetHashCode()}{keyCache}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(BaseConsts.PMaxItens, string.IsNullOrEmpty(where) ? string.Empty : TSql.Where + where, parameters, uri, cancel), entryOptions, cancellationToken: new());
    }

    public async Task<OponentesRepLegalResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (id < 1)
        {
            return new OponentesRepLegalResponse();
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
            var result = await _cache.GetOrCreateAsync($"{uri}-OponentesRepLegal-GetById-{id}-{keyCache}", async cancel => await GetDataByIdAsync(id, oCnn, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"OponentesRepLegal - {uri}-: GetById");
        }
    }

    private async Task<OponentesRepLegalResponse?> GetDataByIdAsync(int id, MsiSqlConnection oCnn, CancellationToken token) => await Task.Run(() => reader.Read(id, oCnn));
    public async Task<OponentesRepLegalResponse?> AddAndUpdate([FromBody] Models.OponentesRepLegal regOponentesRepLegal, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("OponentesRepLegal: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regOponentesRepLegal == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regOponentesRepLegal, this, oponentesReader, cidadeReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            var saved = writer.Write(regOponentesRepLegal, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
            return reader.Read(saved.ID, oCnn);
        });
    }

    public async Task<OponentesRepLegalResponse?> Validation([FromBody] Models.OponentesRepLegal regOponentesRepLegal, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("OponentesRepLegal: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regOponentesRepLegal == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regOponentesRepLegal, this, oponentesReader, cidadeReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            if (regOponentesRepLegal.Id.IsEmptyIDNumber())
            {
                return new OponentesRepLegalResponse();
            }

            return reader.Read(regOponentesRepLegal.Id, oCnn);
        });
    }

    public async Task<OponentesRepLegalResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("OponentesRepLegal: URI inválida");
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

            var oponentesreplegal = reader.Read(id, oCnn);
            try
            {
                if (oponentesreplegal != null)
                {
                    writer.Delete(oponentesreplegal, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
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

            return oponentesreplegal;
        });
    }

    public async Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterOponentesRepLegal? filtro, [FromRoute, Required] string uri, CancellationToken token)
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
        var cacheKey = $"{uri}-OponentesRepLegal-{max}-{where.GetHashCode()}-GetListN-{keyCache}";
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
            foreach (var item in reader.ListarN(max, uri, where, parameters, DBOponentesRepLegalDicInfo.CampoNome))
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

    private static (string where, List<SqlParameter> parametros)? WFiltro(Filters.FilterOponentesRepLegal filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var parameters = new List<SqlParameter>();
        if (!string.IsNullOrEmpty(filtro.Nome))
        {
            parameters.Add(new($"@{nameof(DBOponentesRepLegalDicInfo.Nome)}", filtro.Nome));
        }

        if (!string.IsNullOrEmpty(filtro.Fone))
        {
            parameters.Add(new($"@{nameof(DBOponentesRepLegalDicInfo.Fone)}", filtro.Fone));
        }

        if (filtro.Oponente != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBOponentesRepLegalDicInfo.Oponente)}", filtro.Oponente));
        }

        if (!string.IsNullOrEmpty(filtro.CPF))
        {
            parameters.Add(new($"@{nameof(DBOponentesRepLegalDicInfo.CPF)}", filtro.CPF));
        }

        if (!string.IsNullOrEmpty(filtro.RG))
        {
            parameters.Add(new($"@{nameof(DBOponentesRepLegalDicInfo.RG)}", filtro.RG));
        }

        if (!string.IsNullOrEmpty(filtro.Endereco))
        {
            parameters.Add(new($"@{nameof(DBOponentesRepLegalDicInfo.Endereco)}", filtro.Endereco));
        }

        if (!string.IsNullOrEmpty(filtro.Bairro))
        {
            parameters.Add(new($"@{nameof(DBOponentesRepLegalDicInfo.Bairro)}", filtro.Bairro));
        }

        if (!string.IsNullOrEmpty(filtro.CEP))
        {
            parameters.Add(new($"@{nameof(DBOponentesRepLegalDicInfo.CEP)}", filtro.CEP));
        }

        if (filtro.Cidade != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBOponentesRepLegalDicInfo.Cidade)}", filtro.Cidade));
        }

        if (!string.IsNullOrEmpty(filtro.Fax))
        {
            parameters.Add(new($"@{nameof(DBOponentesRepLegalDicInfo.Fax)}", filtro.Fax));
        }

        if (!string.IsNullOrEmpty(filtro.EMail))
        {
            parameters.Add(new($"@{nameof(DBOponentesRepLegalDicInfo.EMail)}", filtro.EMail));
        }

        if (!string.IsNullOrEmpty(filtro.Site))
        {
            parameters.Add(new($"@{nameof(DBOponentesRepLegalDicInfo.Site)}", filtro.Site));
        }

        if (!string.IsNullOrEmpty(filtro.Observacao))
        {
            parameters.Add(new($"@{nameof(DBOponentesRepLegalDicInfo.Observacao)}", filtro.Observacao));
        }

        var cWhere = filtro.Nome.IsEmpty() ? string.Empty : $"{DBOponentesRepLegalDicInfo.Nome} = @{nameof(DBOponentesRepLegalDicInfo.Nome)}";
        cWhere += filtro.Fone.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOponentesRepLegalDicInfo.Fone} = @{nameof(DBOponentesRepLegalDicInfo.Fone)}";
        cWhere += filtro.Oponente == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOponentesRepLegalDicInfo.Oponente} = @{nameof(DBOponentesRepLegalDicInfo.Oponente)}";
        cWhere += filtro.CPF.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOponentesRepLegalDicInfo.CPF} = @{nameof(DBOponentesRepLegalDicInfo.CPF)}";
        cWhere += filtro.RG.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOponentesRepLegalDicInfo.RG} = @{nameof(DBOponentesRepLegalDicInfo.RG)}";
        cWhere += filtro.Endereco.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOponentesRepLegalDicInfo.Endereco} = @{nameof(DBOponentesRepLegalDicInfo.Endereco)}";
        cWhere += filtro.Bairro.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOponentesRepLegalDicInfo.Bairro} = @{nameof(DBOponentesRepLegalDicInfo.Bairro)}";
        cWhere += filtro.CEP.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOponentesRepLegalDicInfo.CEP} = @{nameof(DBOponentesRepLegalDicInfo.CEP)}";
        cWhere += filtro.Cidade == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOponentesRepLegalDicInfo.Cidade} = @{nameof(DBOponentesRepLegalDicInfo.Cidade)}";
        cWhere += filtro.Fax.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOponentesRepLegalDicInfo.Fax} = @{nameof(DBOponentesRepLegalDicInfo.Fax)}";
        cWhere += filtro.EMail.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOponentesRepLegalDicInfo.EMail} = @{nameof(DBOponentesRepLegalDicInfo.EMail)}";
        cWhere += filtro.Site.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOponentesRepLegalDicInfo.Site} = @{nameof(DBOponentesRepLegalDicInfo.Site)}";
        cWhere += filtro.Observacao.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOponentesRepLegalDicInfo.Observacao} = @{nameof(DBOponentesRepLegalDicInfo.Observacao)}";
        return (cWhere, parameters);
    }
}