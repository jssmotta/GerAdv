#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class DivisaoTribunalService(IOptions<AppSettings> appSettings, IDivisaoTribunalReader reader, IDivisaoTribunalValidation validation, IDivisaoTribunalWriter writer, IJusticaReader justicaReader, IAreaReader areaReader, ICidadeReader cidadeReader, IForoReader foroReader, ITribunalReader tribunalReader, IHttpContextAccessor httpContextAccessor, HybridCache cache, IMemoryCache memory) : IDivisaoTribunalService, IDisposable
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly IOptions<AppSettings> _appSettings = appSettings;
    private readonly HybridCache _cache = cache;
    private readonly IMemoryCache _memoryCache = memory;
    private bool _disposed;
    public async Task<IEnumerable<DivisaoTribunalResponseAll>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("DivisaoTribunal: URI inválida");
            }
        }

        var cacheKey = $"{uri}-DivisaoTribunal-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, string.Empty, [], uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<DivisaoTribunalResponseAll>> GetDataAllAsync(int max, string where, List<SqlParameter> parameters, string uri, CancellationToken token)
    {
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        if (oCnn == null)
        {
            throw new Exception("Conexão nula.");
        }

        var query = $@"SELECT TOP ({max})
                   {DBDivisaoTribunal.SensivelCamposSqlX}, [Justica].[jusNome],[Area].[areDescricao],[Cidade].[cidNome],[Foro].[forNome],[Tribunal].[triNome]
                   FROM {DBDivisaoTribunal.PTabelaNome.dbo(oCnn)} (NOLOCK)
                   LEFT JOIN {"Justica".dbo(oCnn)} (NOLOCK) ON [Justica].[jusCodigo]=[DivisaoTribunal].[divJustica]
LEFT JOIN {"Area".dbo(oCnn)} (NOLOCK) ON [Area].[areCodigo]=[DivisaoTribunal].[divArea]
LEFT JOIN {"Cidade".dbo(oCnn)} (NOLOCK) ON [Cidade].[cidCodigo]=[DivisaoTribunal].[divCidade]
LEFT JOIN {"Foro".dbo(oCnn)} (NOLOCK) ON [Foro].[forCodigo]=[DivisaoTribunal].[divForo]
LEFT JOIN {"Tribunal".dbo(oCnn)} (NOLOCK) ON [Tribunal].[triCodigo]=[DivisaoTribunal].[divTribunal]
 
                   {where}
                   ORDER BY [DivisaoTribunal].[]
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var lista = new List<DivisaoTribunalResponseAll>(max);
        var ds = await ConfiguracoesDBT.GetDataTable2Async(query, parameters, oCnn);
        if (ds != null)
            foreach (DataRow item in ds.Rows)
            {
                var dbRec = new DBDivisaoTribunal(item);
                if (dbRec.ID.IsEmptyIDNumber())
                {
                    continue;
                }

                var divisaotribunal = reader.ReadAll(dbRec, item);
                if (divisaotribunal != null)
                {
                    lista.Add(divisaotribunal);
                }
            }

        return lista;
    }

    public async Task<IEnumerable<DivisaoTribunalResponseAll>> Filter(Filters.FilterDivisaoTribunal filtro, [FromRoute, Required] string uri)
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
        var cacheKey = $"{uri}-DivisaoTribunal-Filter-{where.GetHashCode()}{parameters.GetHashCode()}{keyCache}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(BaseConsts.PMaxItens, string.IsNullOrEmpty(where) ? string.Empty : TSql.Where + where, parameters, uri, cancel), entryOptions, cancellationToken: new());
    }

    public async Task<DivisaoTribunalResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (id < 1)
        {
            return new DivisaoTribunalResponse();
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
            var result = await _cache.GetOrCreateAsync($"{uri}-DivisaoTribunal-GetById-{id}-{keyCache}", async cancel => await GetDataByIdAsync(id, oCnn, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"DivisaoTribunal - {uri}-: GetById");
        }
    }

    private async Task<DivisaoTribunalResponse?> GetDataByIdAsync(int id, MsiSqlConnection oCnn, CancellationToken token) => await Task.Run(() => reader.Read(id, oCnn));
    public async Task<DivisaoTribunalResponse?> AddAndUpdate([FromBody] Models.DivisaoTribunal regDivisaoTribunal, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("DivisaoTribunal: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regDivisaoTribunal == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regDivisaoTribunal, this, justicaReader, areaReader, cidadeReader, foroReader, tribunalReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            var saved = writer.Write(regDivisaoTribunal, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
            return reader.Read(saved.ID, oCnn);
        });
    }

    public async Task<DivisaoTribunalResponse?> Validation([FromBody] Models.DivisaoTribunal regDivisaoTribunal, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("DivisaoTribunal: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regDivisaoTribunal == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regDivisaoTribunal, this, justicaReader, areaReader, cidadeReader, foroReader, tribunalReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            if (regDivisaoTribunal.Id.IsEmptyIDNumber())
            {
                return new DivisaoTribunalResponse();
            }

            return reader.Read(regDivisaoTribunal.Id, oCnn);
        });
    }

    public async Task<DivisaoTribunalResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("DivisaoTribunal: URI inválida");
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

            var divisaotribunal = reader.Read(id, oCnn);
            try
            {
                if (divisaotribunal != null)
                {
                    writer.Delete(divisaotribunal, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
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

            return divisaotribunal;
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

    private static (string where, List<SqlParameter> parametros)? WFiltro(Filters.FilterDivisaoTribunal filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var parameters = new List<SqlParameter>();
        if (filtro.NumCodigo != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBDivisaoTribunalDicInfo.NumCodigo)}", filtro.NumCodigo));
        }

        if (filtro.Justica != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBDivisaoTribunalDicInfo.Justica)}", filtro.Justica));
        }

        if (!string.IsNullOrEmpty(filtro.NomeEspecial))
        {
            parameters.Add(new($"@{nameof(DBDivisaoTribunalDicInfo.NomeEspecial)}", filtro.NomeEspecial));
        }

        if (filtro.Area != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBDivisaoTribunalDicInfo.Area)}", filtro.Area));
        }

        if (filtro.Cidade != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBDivisaoTribunalDicInfo.Cidade)}", filtro.Cidade));
        }

        if (filtro.Foro != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBDivisaoTribunalDicInfo.Foro)}", filtro.Foro));
        }

        if (filtro.Tribunal != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBDivisaoTribunalDicInfo.Tribunal)}", filtro.Tribunal));
        }

        if (!string.IsNullOrEmpty(filtro.CodigoDiv))
        {
            parameters.Add(new($"@{nameof(DBDivisaoTribunalDicInfo.CodigoDiv)}", filtro.CodigoDiv));
        }

        if (!string.IsNullOrEmpty(filtro.Endereco))
        {
            parameters.Add(new($"@{nameof(DBDivisaoTribunalDicInfo.Endereco)}", filtro.Endereco));
        }

        if (!string.IsNullOrEmpty(filtro.Fone))
        {
            parameters.Add(new($"@{nameof(DBDivisaoTribunalDicInfo.Fone)}", filtro.Fone));
        }

        if (!string.IsNullOrEmpty(filtro.Fax))
        {
            parameters.Add(new($"@{nameof(DBDivisaoTribunalDicInfo.Fax)}", filtro.Fax));
        }

        if (!string.IsNullOrEmpty(filtro.CEP))
        {
            parameters.Add(new($"@{nameof(DBDivisaoTribunalDicInfo.CEP)}", filtro.CEP));
        }

        if (!string.IsNullOrEmpty(filtro.Obs))
        {
            parameters.Add(new($"@{nameof(DBDivisaoTribunalDicInfo.Obs)}", filtro.Obs));
        }

        if (!string.IsNullOrEmpty(filtro.EMail))
        {
            parameters.Add(new($"@{nameof(DBDivisaoTribunalDicInfo.EMail)}", filtro.EMail));
        }

        if (!string.IsNullOrEmpty(filtro.Andar))
        {
            parameters.Add(new($"@{nameof(DBDivisaoTribunalDicInfo.Andar)}", filtro.Andar));
        }

        if (!string.IsNullOrEmpty(filtro.GUID))
        {
            parameters.Add(new($"@{nameof(DBDivisaoTribunalDicInfo.GUID)}", filtro.GUID));
        }

        var cWhere = filtro.NumCodigo == int.MinValue ? string.Empty : $"{DBDivisaoTribunalDicInfo.NumCodigo} = @{nameof(DBDivisaoTribunalDicInfo.NumCodigo)}";
        cWhere += filtro.Justica == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBDivisaoTribunalDicInfo.Justica} = @{nameof(DBDivisaoTribunalDicInfo.Justica)}";
        cWhere += filtro.NomeEspecial.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBDivisaoTribunalDicInfo.NomeEspecial} = @{nameof(DBDivisaoTribunalDicInfo.NomeEspecial)}";
        cWhere += filtro.Area == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBDivisaoTribunalDicInfo.Area} = @{nameof(DBDivisaoTribunalDicInfo.Area)}";
        cWhere += filtro.Cidade == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBDivisaoTribunalDicInfo.Cidade} = @{nameof(DBDivisaoTribunalDicInfo.Cidade)}";
        cWhere += filtro.Foro == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBDivisaoTribunalDicInfo.Foro} = @{nameof(DBDivisaoTribunalDicInfo.Foro)}";
        cWhere += filtro.Tribunal == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBDivisaoTribunalDicInfo.Tribunal} = @{nameof(DBDivisaoTribunalDicInfo.Tribunal)}";
        cWhere += filtro.CodigoDiv.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBDivisaoTribunalDicInfo.CodigoDiv} = @{nameof(DBDivisaoTribunalDicInfo.CodigoDiv)}";
        cWhere += filtro.Endereco.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBDivisaoTribunalDicInfo.Endereco} = @{nameof(DBDivisaoTribunalDicInfo.Endereco)}";
        cWhere += filtro.Fone.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBDivisaoTribunalDicInfo.Fone} = @{nameof(DBDivisaoTribunalDicInfo.Fone)}";
        cWhere += filtro.Fax.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBDivisaoTribunalDicInfo.Fax} = @{nameof(DBDivisaoTribunalDicInfo.Fax)}";
        cWhere += filtro.CEP.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBDivisaoTribunalDicInfo.CEP} = @{nameof(DBDivisaoTribunalDicInfo.CEP)}";
        cWhere += filtro.Obs.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBDivisaoTribunalDicInfo.Obs} = @{nameof(DBDivisaoTribunalDicInfo.Obs)}";
        cWhere += filtro.EMail.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBDivisaoTribunalDicInfo.EMail} = @{nameof(DBDivisaoTribunalDicInfo.EMail)}";
        cWhere += filtro.Andar.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBDivisaoTribunalDicInfo.Andar} = @{nameof(DBDivisaoTribunalDicInfo.Andar)}";
        cWhere += filtro.GUID.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBDivisaoTribunalDicInfo.GUID} = @{nameof(DBDivisaoTribunalDicInfo.GUID)}";
        return (cWhere, parameters);
    }
}