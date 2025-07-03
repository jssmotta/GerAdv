#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class OperadorEMailPopupService(IOptions<AppSettings> appSettings, IOperadorEMailPopupReader reader, IOperadorEMailPopupValidation validation, IOperadorEMailPopupWriter writer, IOperadorReader operadorReader, IHttpContextAccessor httpContextAccessor, HybridCache cache, IMemoryCache memory) : IOperadorEMailPopupService, IDisposable
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly IOptions<AppSettings> _appSettings = appSettings;
    private readonly HybridCache _cache = cache;
    private readonly IMemoryCache _memoryCache = memory;
    private bool _disposed;
    public async Task<IEnumerable<OperadorEMailPopupResponseAll>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("OperadorEMailPopup: URI inválida");
            }
        }

        var cacheKey = $"{uri}-OperadorEMailPopup-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, string.Empty, [], uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<OperadorEMailPopupResponseAll>> GetDataAllAsync(int max, string where, List<SqlParameter> parameters, string uri, CancellationToken token)
    {
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        if (oCnn == null)
        {
            throw new Exception("Conexão nula.");
        }

        var query = $@"SELECT TOP ({max})
                   {DBOperadorEMailPopup.SensivelCamposSqlX}, [Operador].[operNome]
                   FROM {DBOperadorEMailPopup.PTabelaNome.dbo(oCnn)} (NOLOCK)
                   LEFT JOIN {"Operador".dbo(oCnn)} (NOLOCK) ON [Operador].[operCodigo]=[OperadorEMailPopup].[oepOperador]
 
                   {where}
                   ORDER BY [OperadorEMailPopup].[oepNome]
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var lista = new List<OperadorEMailPopupResponseAll>(max);
        var ds = await ConfiguracoesDBT.GetDataTable2Async(query, parameters, oCnn);
        if (ds != null)
            foreach (DataRow item in ds.Rows)
            {
                var dbRec = new DBOperadorEMailPopup(item);
                if (dbRec.ID.IsEmptyIDNumber())
                {
                    continue;
                }

                var operadoremailpopup = reader.ReadAll(dbRec, item);
                if (operadoremailpopup != null)
                {
                    lista.Add(operadoremailpopup);
                }
            }

        return lista;
    }

    public async Task<IEnumerable<OperadorEMailPopupResponseAll>> Filter(Filters.FilterOperadorEMailPopup filtro, [FromRoute, Required] string uri)
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
        var cacheKey = $"{uri}-OperadorEMailPopup-Filter-{where.GetHashCode()}{parameters.GetHashCode()}{keyCache}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(BaseConsts.PMaxItens, string.IsNullOrEmpty(where) ? string.Empty : TSql.Where + where, parameters, uri, cancel), entryOptions, cancellationToken: new());
    }

    public async Task<OperadorEMailPopupResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (id < 1)
        {
            return new OperadorEMailPopupResponse();
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
            var result = await _cache.GetOrCreateAsync($"{uri}-OperadorEMailPopup-GetById-{id}-{keyCache}", async cancel => await GetDataByIdAsync(id, oCnn, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"OperadorEMailPopup - {uri}-: GetById");
        }
    }

    private async Task<OperadorEMailPopupResponse?> GetDataByIdAsync(int id, MsiSqlConnection oCnn, CancellationToken token) => await Task.Run(() => reader.Read(id, oCnn));
    public async Task<OperadorEMailPopupResponse?> AddAndUpdate([FromBody] Models.OperadorEMailPopup regOperadorEMailPopup, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("OperadorEMailPopup: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regOperadorEMailPopup == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regOperadorEMailPopup, this, operadorReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            var saved = writer.Write(regOperadorEMailPopup, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
            return reader.Read(saved.ID, oCnn);
        });
    }

    public async Task<OperadorEMailPopupResponse?> Validation([FromBody] Models.OperadorEMailPopup regOperadorEMailPopup, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("OperadorEMailPopup: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regOperadorEMailPopup == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regOperadorEMailPopup, this, operadorReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            if (regOperadorEMailPopup.Id.IsEmptyIDNumber())
            {
                return new OperadorEMailPopupResponse();
            }

            return reader.Read(regOperadorEMailPopup.Id, oCnn);
        });
    }

    public async Task<OperadorEMailPopupResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("OperadorEMailPopup: URI inválida");
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

            var operadoremailpopup = reader.Read(id, oCnn);
            try
            {
                if (operadoremailpopup != null)
                {
                    writer.Delete(operadoremailpopup, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
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

            return operadoremailpopup;
        });
    }

    public async Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterOperadorEMailPopup? filtro, [FromRoute, Required] string uri, CancellationToken token)
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
        var cacheKey = $"{uri}-OperadorEMailPopup-{max}-{where.GetHashCode()}-GetListN-{keyCache}";
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
            foreach (var item in reader.ListarN(max, uri, where, parameters, DBOperadorEMailPopupDicInfo.CampoNome))
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

    private static (string where, List<SqlParameter> parametros)? WFiltro(Filters.FilterOperadorEMailPopup filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var parameters = new List<SqlParameter>();
        if (filtro.Operador != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBOperadorEMailPopupDicInfo.Operador)}", filtro.Operador));
        }

        if (!string.IsNullOrEmpty(filtro.Nome))
        {
            parameters.Add(new($"@{nameof(DBOperadorEMailPopupDicInfo.Nome)}", filtro.Nome));
        }

        if (!string.IsNullOrEmpty(filtro.Senha))
        {
            parameters.Add(new($"@{nameof(DBOperadorEMailPopupDicInfo.Senha)}", filtro.Senha));
        }

        if (!string.IsNullOrEmpty(filtro.SMTP))
        {
            parameters.Add(new($"@{nameof(DBOperadorEMailPopupDicInfo.SMTP)}", filtro.SMTP));
        }

        if (!string.IsNullOrEmpty(filtro.POP3))
        {
            parameters.Add(new($"@{nameof(DBOperadorEMailPopupDicInfo.POP3)}", filtro.POP3));
        }

        if (!string.IsNullOrEmpty(filtro.Descricao))
        {
            parameters.Add(new($"@{nameof(DBOperadorEMailPopupDicInfo.Descricao)}", filtro.Descricao));
        }

        if (!string.IsNullOrEmpty(filtro.Usuario))
        {
            parameters.Add(new($"@{nameof(DBOperadorEMailPopupDicInfo.Usuario)}", filtro.Usuario));
        }

        if (filtro.PortaSmtp != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBOperadorEMailPopupDicInfo.PortaSmtp)}", filtro.PortaSmtp));
        }

        if (filtro.PortaPop3 != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBOperadorEMailPopupDicInfo.PortaPop3)}", filtro.PortaPop3));
        }

        if (!string.IsNullOrEmpty(filtro.Assinatura))
        {
            parameters.Add(new($"@{nameof(DBOperadorEMailPopupDicInfo.Assinatura)}", filtro.Assinatura));
        }

        if (!string.IsNullOrEmpty(filtro.Senha256))
        {
            parameters.Add(new($"@{nameof(DBOperadorEMailPopupDicInfo.Senha256)}", filtro.Senha256));
        }

        if (!string.IsNullOrEmpty(filtro.GUID))
        {
            parameters.Add(new($"@{nameof(DBOperadorEMailPopupDicInfo.GUID)}", filtro.GUID));
        }

        var cWhere = filtro.Operador == int.MinValue ? string.Empty : $"{DBOperadorEMailPopupDicInfo.Operador} = @{nameof(DBOperadorEMailPopupDicInfo.Operador)}";
        cWhere += filtro.Nome.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOperadorEMailPopupDicInfo.Nome} = @{nameof(DBOperadorEMailPopupDicInfo.Nome)}";
        cWhere += filtro.Senha.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOperadorEMailPopupDicInfo.Senha} = @{nameof(DBOperadorEMailPopupDicInfo.Senha)}";
        cWhere += filtro.SMTP.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOperadorEMailPopupDicInfo.SMTP} = @{nameof(DBOperadorEMailPopupDicInfo.SMTP)}";
        cWhere += filtro.POP3.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOperadorEMailPopupDicInfo.POP3} = @{nameof(DBOperadorEMailPopupDicInfo.POP3)}";
        cWhere += filtro.Descricao.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOperadorEMailPopupDicInfo.Descricao} = @{nameof(DBOperadorEMailPopupDicInfo.Descricao)}";
        cWhere += filtro.Usuario.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOperadorEMailPopupDicInfo.Usuario} = @{nameof(DBOperadorEMailPopupDicInfo.Usuario)}";
        cWhere += filtro.PortaSmtp == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOperadorEMailPopupDicInfo.PortaSmtp} = @{nameof(DBOperadorEMailPopupDicInfo.PortaSmtp)}";
        cWhere += filtro.PortaPop3 == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOperadorEMailPopupDicInfo.PortaPop3} = @{nameof(DBOperadorEMailPopupDicInfo.PortaPop3)}";
        cWhere += filtro.Assinatura.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOperadorEMailPopupDicInfo.Assinatura} = @{nameof(DBOperadorEMailPopupDicInfo.Assinatura)}";
        cWhere += filtro.Senha256.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOperadorEMailPopupDicInfo.Senha256} = @{nameof(DBOperadorEMailPopupDicInfo.Senha256)}";
        cWhere += filtro.GUID.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBOperadorEMailPopupDicInfo.GUID} = @{nameof(DBOperadorEMailPopupDicInfo.GUID)}";
        return (cWhere, parameters);
    }
}