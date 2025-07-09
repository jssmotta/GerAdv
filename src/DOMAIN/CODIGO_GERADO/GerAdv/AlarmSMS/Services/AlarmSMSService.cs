#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class AlarmSMSService(IOptions<AppSettings> appSettings, IAlarmSMSReader reader, IAlarmSMSValidation validation, IAlarmSMSWriter writer, IOperadorReader operadorReader, IAgendaReader agendaReader, IRecadosReader recadosReader, IHttpContextAccessor httpContextAccessor, HybridCache cache, IMemoryCache memory) : IAlarmSMSService, IDisposable
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly IOptions<AppSettings> _appSettings = appSettings;
    private readonly HybridCache _cache = cache;
    private readonly IMemoryCache _memoryCache = memory;
    private bool _disposed;
    public async Task<IEnumerable<AlarmSMSResponseAll>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("AlarmSMS: URI inválida");
            }
        }

        var cacheKey = $"{uri}-AlarmSMS-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, string.Empty, [], uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<AlarmSMSResponseAll>> GetDataAllAsync(int max, string where, List<SqlParameter> parameters, string uri, CancellationToken token)
    {
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        if (oCnn == null)
        {
            throw new Exception("Conexão nula.");
        }

        var query = $@"SELECT TOP ({max})
                   {DBAlarmSMS.SensivelCamposSqlX}, [Operador].[operNome],[Agenda].[],[Recados].[]
                   FROM {DBAlarmSMS.PTabelaNome.dbo(oCnn)} (NOLOCK)
                   LEFT JOIN {"Operador".dbo(oCnn)} (NOLOCK) ON [Operador].[operCodigo]=[AlarmSMS].[alrOperador]
LEFT JOIN {"Agenda".dbo(oCnn)} (NOLOCK) ON [Agenda].[ageCodigo]=[AlarmSMS].[alrAgenda]
LEFT JOIN {"Recados".dbo(oCnn)} (NOLOCK) ON [Recados].[recCodigo]=[AlarmSMS].[alrRecado]
 
                   {where}
                   ORDER BY [AlarmSMS].[alrDescricao]
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var lista = new List<AlarmSMSResponseAll>(max);
        var ds = await ConfiguracoesDBT.GetDataTable2Async(query, parameters, oCnn);
        if (ds != null)
            foreach (DataRow item in ds.Rows)
            {
                var dbRec = new DBAlarmSMS(item);
                if (dbRec.ID.IsEmptyIDNumber())
                {
                    continue;
                }

                var alarmsms = reader.ReadAll(dbRec, item);
                if (alarmsms != null)
                {
                    lista.Add(alarmsms);
                }
            }

        return lista;
    }

    public async Task<IEnumerable<AlarmSMSResponseAll>> Filter(Filters.FilterAlarmSMS filtro, [FromRoute, Required] string uri)
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
        var cacheKey = $"{uri}-AlarmSMS-Filter-{where.GetHashCode()}{parameters.GetHashCode()}{keyCache}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(BaseConsts.PMaxItens, string.IsNullOrEmpty(where) ? string.Empty : TSql.Where + where, parameters, uri, cancel), entryOptions, cancellationToken: new());
    }

    public async Task<AlarmSMSResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (id < 1)
        {
            return new AlarmSMSResponse();
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
            var result = await _cache.GetOrCreateAsync($"{uri}-AlarmSMS-GetById-{id}-{keyCache}", async cancel => await GetDataByIdAsync(id, oCnn, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"AlarmSMS - {uri}-: GetById");
        }
    }

    private async Task<AlarmSMSResponse?> GetDataByIdAsync(int id, MsiSqlConnection oCnn, CancellationToken token) => await Task.Run(() => reader.Read(id, oCnn));
    public async Task<AlarmSMSResponse?> AddAndUpdate([FromBody] Models.AlarmSMS regAlarmSMS, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("AlarmSMS: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regAlarmSMS == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regAlarmSMS, this, operadorReader, agendaReader, recadosReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            var saved = writer.Write(regAlarmSMS, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
            return reader.Read(saved, oCnn);
        });
    }

    public async Task<AlarmSMSResponse?> Validation([FromBody] Models.AlarmSMS regAlarmSMS, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("AlarmSMS: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regAlarmSMS == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regAlarmSMS, this, operadorReader, agendaReader, recadosReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            if (regAlarmSMS.Id.IsEmptyIDNumber())
            {
                return new AlarmSMSResponse();
            }

            return reader.Read(regAlarmSMS.Id, oCnn);
        });
    }

    public async Task<AlarmSMSResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("AlarmSMS: URI inválida");
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

            var alarmsms = reader.Read(id, oCnn);
            try
            {
                if (alarmsms != null)
                {
                    writer.Delete(alarmsms, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
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

            return alarmsms;
        });
    }

    public async Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterAlarmSMS? filtro, [FromRoute, Required] string uri, CancellationToken token)
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
        var cacheKey = $"{uri}-AlarmSMS-{max}-{where.GetHashCode()}-GetListN-{keyCache}";
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
            foreach (var item in reader.ListarN(max, uri, where, parameters, DBAlarmSMSDicInfo.CampoNome))
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

    private static (string where, List<SqlParameter> parametros)? WFiltro(Filters.FilterAlarmSMS filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var parameters = new List<SqlParameter>();
        if (!string.IsNullOrEmpty(filtro.Descricao))
        {
            parameters.Add(new($"@{nameof(DBAlarmSMSDicInfo.Descricao)}", filtro.Descricao));
        }

        if (filtro.Hora != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAlarmSMSDicInfo.Hora)}", filtro.Hora));
        }

        if (filtro.Minuto != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAlarmSMSDicInfo.Minuto)}", filtro.Minuto));
        }

        if (!string.IsNullOrEmpty(filtro.EMail))
        {
            parameters.Add(new($"@{nameof(DBAlarmSMSDicInfo.EMail)}", filtro.EMail));
        }

        if (filtro.Operador != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAlarmSMSDicInfo.Operador)}", filtro.Operador));
        }

        if (!string.IsNullOrEmpty(filtro.GuidExo))
        {
            parameters.Add(new($"@{nameof(DBAlarmSMSDicInfo.GuidExo)}", filtro.GuidExo));
        }

        if (filtro.Agenda != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAlarmSMSDicInfo.Agenda)}", filtro.Agenda));
        }

        if (filtro.Recado != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAlarmSMSDicInfo.Recado)}", filtro.Recado));
        }

        if (filtro.Emocao != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAlarmSMSDicInfo.Emocao)}", filtro.Emocao));
        }

        if (!string.IsNullOrEmpty(filtro.GUID))
        {
            parameters.Add(new($"@{nameof(DBAlarmSMSDicInfo.GUID)}", filtro.GUID));
        }

        var cWhere = filtro.Descricao.IsEmpty() ? string.Empty : $"{DBAlarmSMSDicInfo.Descricao} = @{nameof(DBAlarmSMSDicInfo.Descricao)}";
        cWhere += filtro.Hora == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAlarmSMSDicInfo.Hora} = @{nameof(DBAlarmSMSDicInfo.Hora)}";
        cWhere += filtro.Minuto == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAlarmSMSDicInfo.Minuto} = @{nameof(DBAlarmSMSDicInfo.Minuto)}";
        cWhere += filtro.EMail.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAlarmSMSDicInfo.EMail} = @{nameof(DBAlarmSMSDicInfo.EMail)}";
        cWhere += filtro.Operador == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAlarmSMSDicInfo.Operador} = @{nameof(DBAlarmSMSDicInfo.Operador)}";
        cWhere += filtro.GuidExo.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAlarmSMSDicInfo.GuidExo} = @{nameof(DBAlarmSMSDicInfo.GuidExo)}";
        cWhere += filtro.Agenda == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAlarmSMSDicInfo.Agenda} = @{nameof(DBAlarmSMSDicInfo.Agenda)}";
        cWhere += filtro.Recado == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAlarmSMSDicInfo.Recado} = @{nameof(DBAlarmSMSDicInfo.Recado)}";
        cWhere += filtro.Emocao == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAlarmSMSDicInfo.Emocao} = @{nameof(DBAlarmSMSDicInfo.Emocao)}";
        cWhere += filtro.GUID.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAlarmSMSDicInfo.GUID} = @{nameof(DBAlarmSMSDicInfo.GUID)}";
        return (cWhere, parameters);
    }
}