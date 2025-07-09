#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class ReuniaoService(IOptions<AppSettings> appSettings, IReuniaoReader reader, IReuniaoValidation validation, IReuniaoWriter writer, IClientesReader clientesReader, IReuniaoPessoasService reuniaopessoasService, IHttpContextAccessor httpContextAccessor, HybridCache cache, IMemoryCache memory) : IReuniaoService, IDisposable
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly IOptions<AppSettings> _appSettings = appSettings;
    private readonly HybridCache _cache = cache;
    private readonly IMemoryCache _memoryCache = memory;
    private bool _disposed;
    public async Task<IEnumerable<ReuniaoResponseAll>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("Reuniao: URI inválida");
            }
        }

        var cacheKey = $"{uri}-Reuniao-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, string.Empty, [], uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<ReuniaoResponseAll>> GetDataAllAsync(int max, string where, List<SqlParameter> parameters, string uri, CancellationToken token)
    {
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        if (oCnn == null)
        {
            throw new Exception("Conexão nula.");
        }

        var query = $@"SELECT TOP ({max})
                   {DBReuniao.SensivelCamposSqlX}, [Clientes].[cliNome]
                   FROM {DBReuniao.PTabelaNome.dbo(oCnn)} (NOLOCK)
                   LEFT JOIN {"Clientes".dbo(oCnn)} (NOLOCK) ON [Clientes].[cliCodigo]=[Reuniao].[renCliente]
 
                   {where}
                   ORDER BY [Reuniao].[]
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var lista = new List<ReuniaoResponseAll>(max);
        var ds = await ConfiguracoesDBT.GetDataTable2Async(query, parameters, oCnn);
        if (ds != null)
            foreach (DataRow item in ds.Rows)
            {
                var dbRec = new DBReuniao(item);
                if (dbRec.ID.IsEmptyIDNumber())
                {
                    continue;
                }

                var reuniao = reader.ReadAll(dbRec, item);
                if (reuniao != null)
                {
                    lista.Add(reuniao);
                }
            }

        return lista;
    }

    public async Task<IEnumerable<ReuniaoResponseAll>> Filter(Filters.FilterReuniao filtro, [FromRoute, Required] string uri)
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
        var cacheKey = $"{uri}-Reuniao-Filter-{where.GetHashCode()}{parameters.GetHashCode()}{keyCache}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(BaseConsts.PMaxItens, string.IsNullOrEmpty(where) ? string.Empty : TSql.Where + where, parameters, uri, cancel), entryOptions, cancellationToken: new());
    }

    public async Task<ReuniaoResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (id < 1)
        {
            return new ReuniaoResponse();
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
            var result = await _cache.GetOrCreateAsync($"{uri}-Reuniao-GetById-{id}-{keyCache}", async cancel => await GetDataByIdAsync(id, oCnn, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"Reuniao - {uri}-: GetById");
        }
    }

    private async Task<ReuniaoResponse?> GetDataByIdAsync(int id, MsiSqlConnection oCnn, CancellationToken token) => await Task.Run(() => reader.Read(id, oCnn));
    public async Task<ReuniaoResponse?> AddAndUpdate([FromBody] Models.Reuniao regReuniao, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("Reuniao: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regReuniao == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regReuniao, this, clientesReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            var saved = writer.Write(regReuniao, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
            return reader.Read(saved, oCnn);
        });
    }

    public async Task<ReuniaoResponse?> Validation([FromBody] Models.Reuniao regReuniao, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("Reuniao: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regReuniao == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regReuniao, this, clientesReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            if (regReuniao.Id.IsEmptyIDNumber())
            {
                return new ReuniaoResponse();
            }

            return reader.Read(regReuniao.Id, oCnn);
        });
    }

    public async Task<ReuniaoResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("Reuniao: URI inválida");
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

            var deleteValidation = await validation.CanDelete(id, this, reuniaopessoasService, uri, oCnn);
            if (deleteValidation.Length > 0)
            {
                throw new Exception(deleteValidation);
            }

            var reuniao = reader.Read(id, oCnn);
            try
            {
                if (reuniao != null)
                {
                    writer.Delete(reuniao, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
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

            return reuniao;
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

    private static (string where, List<SqlParameter> parametros)? WFiltro(Filters.FilterReuniao filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var parameters = new List<SqlParameter>();
        if (filtro.Cliente != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBReuniaoDicInfo.Cliente)}", filtro.Cliente));
        }

        if (filtro.IDAgenda != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBReuniaoDicInfo.IDAgenda)}", filtro.IDAgenda));
        }

        if (!string.IsNullOrEmpty(filtro.Pauta))
        {
            parameters.Add(new($"@{nameof(DBReuniaoDicInfo.Pauta)}", filtro.Pauta));
        }

        if (!string.IsNullOrEmpty(filtro.ATA))
        {
            parameters.Add(new($"@{nameof(DBReuniaoDicInfo.ATA)}", filtro.ATA));
        }

        if (!string.IsNullOrEmpty(filtro.PrincipaisDecisoes))
        {
            parameters.Add(new($"@{nameof(DBReuniaoDicInfo.PrincipaisDecisoes)}", filtro.PrincipaisDecisoes));
        }

        if (!string.IsNullOrEmpty(filtro.GUID))
        {
            parameters.Add(new($"@{nameof(DBReuniaoDicInfo.GUID)}", filtro.GUID));
        }

        var cWhere = filtro.Cliente == int.MinValue ? string.Empty : $"{DBReuniaoDicInfo.Cliente} = @{nameof(DBReuniaoDicInfo.Cliente)}";
        cWhere += filtro.IDAgenda == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBReuniaoDicInfo.IDAgenda} = @{nameof(DBReuniaoDicInfo.IDAgenda)}";
        cWhere += filtro.Pauta.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBReuniaoDicInfo.Pauta} = @{nameof(DBReuniaoDicInfo.Pauta)}";
        cWhere += filtro.ATA.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBReuniaoDicInfo.ATA} = @{nameof(DBReuniaoDicInfo.ATA)}";
        cWhere += filtro.PrincipaisDecisoes.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBReuniaoDicInfo.PrincipaisDecisoes} = @{nameof(DBReuniaoDicInfo.PrincipaisDecisoes)}";
        cWhere += filtro.GUID.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBReuniaoDicInfo.GUID} = @{nameof(DBReuniaoDicInfo.GUID)}";
        return (cWhere, parameters);
    }
}