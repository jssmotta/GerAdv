#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class Agenda2AgendaService(IOptions<AppSettings> appSettings, IAgenda2AgendaReader reader, IAgenda2AgendaValidation validation, IAgenda2AgendaWriter writer, IAgendaReader agendaReader, IHttpContextAccessor httpContextAccessor, HybridCache cache, IMemoryCache memory) : IAgenda2AgendaService, IDisposable
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly IOptions<AppSettings> _appSettings = appSettings;
    private readonly HybridCache _cache = cache;
    private readonly IMemoryCache _memoryCache = memory;
    private bool _disposed;
    public async Task<IEnumerable<Agenda2AgendaResponseAll>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("Agenda2Agenda: URI inválida");
            }
        }

        var cacheKey = $"{uri}-Agenda2Agenda-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, string.Empty, [], uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<Agenda2AgendaResponseAll>> GetDataAllAsync(int max, string where, List<SqlParameter> parameters, string uri, CancellationToken token)
    {
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        if (oCnn == null)
        {
            throw new Exception("Conexão nula.");
        }

        var query = $@"SELECT TOP ({max})
                   {DBAgenda2Agenda.SensivelCamposSqlX}, [Agenda].[]
                   FROM {DBAgenda2Agenda.PTabelaNome.dbo(oCnn)} (NOLOCK)
                   LEFT JOIN {"Agenda".dbo(oCnn)} (NOLOCK) ON [Agenda].[ageCodigo]=[Agenda2Agenda].[ag2Agenda]
 
                   {where}
                   ORDER BY [Agenda2Agenda].[]
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var lista = new List<Agenda2AgendaResponseAll>(max);
        var ds = await ConfiguracoesDBT.GetDataTable2Async(query, parameters, oCnn);
        if (ds != null)
            foreach (DataRow item in ds.Rows)
            {
                var dbRec = new DBAgenda2Agenda(item);
                if (dbRec.ID.IsEmptyIDNumber())
                {
                    continue;
                }

                var agenda2agenda = reader.ReadAll(dbRec, item);
                if (agenda2agenda != null)
                {
                    lista.Add(agenda2agenda);
                }
            }

        return lista;
    }

    public async Task<IEnumerable<Agenda2AgendaResponseAll>> Filter(Filters.FilterAgenda2Agenda filtro, [FromRoute, Required] string uri)
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
        var cacheKey = $"{uri}-Agenda2Agenda-Filter-{where.GetHashCode()}{parameters.GetHashCode()}{keyCache}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(BaseConsts.PMaxItens, string.IsNullOrEmpty(where) ? string.Empty : TSql.Where + where, parameters, uri, cancel), entryOptions, cancellationToken: new());
    }

    public async Task<Agenda2AgendaResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (id < 1)
        {
            return new Agenda2AgendaResponse();
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
            var result = await _cache.GetOrCreateAsync($"{uri}-Agenda2Agenda-GetById-{id}-{keyCache}", async cancel => await GetDataByIdAsync(id, oCnn, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"Agenda2Agenda - {uri}-: GetById");
        }
    }

    private async Task<Agenda2AgendaResponse?> GetDataByIdAsync(int id, MsiSqlConnection oCnn, CancellationToken token) => await Task.Run(() => reader.Read(id, oCnn));
    public async Task<Agenda2AgendaResponse?> AddAndUpdate([FromBody] Models.Agenda2Agenda regAgenda2Agenda, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("Agenda2Agenda: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regAgenda2Agenda == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regAgenda2Agenda, this, agendaReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            var saved = writer.Write(regAgenda2Agenda, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
            return reader.Read(saved, oCnn);
        });
    }

    public async Task<Agenda2AgendaResponse?> Validation([FromBody] Models.Agenda2Agenda regAgenda2Agenda, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("Agenda2Agenda: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regAgenda2Agenda == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regAgenda2Agenda, this, agendaReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            if (regAgenda2Agenda.Id.IsEmptyIDNumber())
            {
                return new Agenda2AgendaResponse();
            }

            return reader.Read(regAgenda2Agenda.Id, oCnn);
        });
    }

    public async Task<Agenda2AgendaResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("Agenda2Agenda: URI inválida");
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

            var agenda2agenda = reader.Read(id, oCnn);
            try
            {
                if (agenda2agenda != null)
                {
                    writer.Delete(agenda2agenda, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
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

            return agenda2agenda;
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

    private static (string where, List<SqlParameter> parametros)? WFiltro(Filters.FilterAgenda2Agenda filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var parameters = new List<SqlParameter>();
        if (filtro.Master != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgenda2AgendaDicInfo.Master)}", filtro.Master));
        }

        if (filtro.Agenda != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgenda2AgendaDicInfo.Agenda)}", filtro.Agenda));
        }

        var cWhere = filtro.Master == int.MinValue ? string.Empty : $"{DBAgenda2AgendaDicInfo.Master} = @{nameof(DBAgenda2AgendaDicInfo.Master)}";
        cWhere += filtro.Agenda == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgenda2AgendaDicInfo.Agenda} = @{nameof(DBAgenda2AgendaDicInfo.Agenda)}";
        return (cWhere, parameters);
    }
}