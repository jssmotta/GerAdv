#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class AgendaRecordsService(IOptions<AppSettings> appSettings, IAgendaRecordsReader reader, IAgendaRecordsValidation validation, IAgendaRecordsWriter writer, IAgendaReader agendaReader, IClientesSociosReader clientessociosReader, IColaboradoresReader colaboradoresReader, IForoReader foroReader, HybridCache cache, IMemoryCache memory) : IAgendaRecordsService, IDisposable
{
    private readonly IOptions<AppSettings> _appSettings = appSettings;
    private readonly HybridCache _cache = cache;
    private readonly IMemoryCache _memoryCache = memory;
    private bool _disposed;
    public async Task<IEnumerable<AgendaRecordsResponseAll>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("AgendaRecords: URI inválida");
            }
        }

        var cacheKey = $"{uri}-AgendaRecords-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, string.Empty, [], uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<AgendaRecordsResponseAll>> GetDataAllAsync(int max, string where, List<SqlParameter> parameters, string uri, CancellationToken token)
    {
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        if (oCnn == null)
        {
            throw new Exception("Conexão nula.");
        }

        var query = $@"SELECT TOP ({max})
                   {DBAgendaRecords.SensivelCamposSqlX}, [Agenda].[],[ClientesSocios].[cscNome],[Colaboradores].[colNome],[Foro].[forNome]
                   FROM {DBAgendaRecords.PTabelaNome.dbo(oCnn)} (NOLOCK)
                   LEFT JOIN {"Agenda".dbo(oCnn)} (NOLOCK) ON [Agenda].[ageCodigo]=[AgendaRecords].[ragAgenda]
LEFT JOIN {"ClientesSocios".dbo(oCnn)} (NOLOCK) ON [ClientesSocios].[cscCodigo]=[AgendaRecords].[ragClientesSocios]
LEFT JOIN {"Colaboradores".dbo(oCnn)} (NOLOCK) ON [Colaboradores].[colCodigo]=[AgendaRecords].[ragColaborador]
LEFT JOIN {"Foro".dbo(oCnn)} (NOLOCK) ON [Foro].[forCodigo]=[AgendaRecords].[ragForo]
 
                   {where}
                   ORDER BY [AgendaRecords].[]
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var lista = new List<AgendaRecordsResponseAll>(max);
        var ds = await ConfiguracoesDBT.GetDataTable2Async(query, parameters, oCnn);
        if (ds != null)
            foreach (DataRow item in ds.Rows)
            {
                var dbRec = new DBAgendaRecords(item);
                if (dbRec.ID.IsEmptyIDNumber())
                {
                    continue;
                }

                var agendarecords = reader.ReadAll(dbRec, item);
                if (agendarecords != null)
                {
                    lista.Add(agendarecords);
                }
            }

        return lista;
    }

    public async Task<IEnumerable<AgendaRecordsResponseAll>> Filter(Filters.FilterAgendaRecords filtro, [FromRoute, Required] string uri)
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
        var cacheKey = $"{uri}-AgendaRecords-Filter-{where.GetHashCode()}{parameters.GetHashCode()}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(BaseConsts.PMaxItens, string.IsNullOrEmpty(where) ? string.Empty : TSql.Where + where, parameters, uri, cancel), entryOptions, cancellationToken: new());
    }

    public async Task<AgendaRecordsResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (id < 1)
        {
            return new AgendaRecordsResponse();
        }

        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxSecondsCacheId)
        };
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        try
        {
            var result = await _cache.GetOrCreateAsync($"{uri}-AgendaRecords-GetById-{id}", async cancel => await GetDataByIdAsync(id, oCnn, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"AgendaRecords - {uri}-: GetById");
        }
    }

    private async Task<AgendaRecordsResponse?> GetDataByIdAsync(int id, MsiSqlConnection oCnn, CancellationToken token) => await Task.Run(() => reader.Read(id, oCnn));
    public async Task<AgendaRecordsResponse?> AddAndUpdate([FromBody] Models.AgendaRecords regAgendaRecords, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("AgendaRecords: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regAgendaRecords == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regAgendaRecords, this, agendaReader, clientessociosReader, colaboradoresReader, foroReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            var saved = writer.Write(regAgendaRecords, oCnn);
            return reader.Read(saved, oCnn);
        });
    }

    public async Task<AgendaRecordsResponse?> Validation([FromBody] Models.AgendaRecords regAgendaRecords, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("AgendaRecords: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regAgendaRecords == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regAgendaRecords, this, agendaReader, clientessociosReader, colaboradoresReader, foroReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            if (regAgendaRecords.Id.IsEmptyIDNumber())
            {
                return new AgendaRecordsResponse();
            }

            return reader.Read(regAgendaRecords.Id, oCnn);
        });
    }

    public async Task<AgendaRecordsResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("AgendaRecords: URI inválida");
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

            var agendarecords = reader.Read(id, oCnn);
            try
            {
                if (agendarecords != null)
                {
                    writer.Delete(agendarecords, 0, oCnn);
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

            return agendarecords;
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

    private static (string where, List<SqlParameter> parametros)? WFiltro(Filters.FilterAgendaRecords filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var parameters = new List<SqlParameter>();
        if (filtro.Agenda != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaRecordsDicInfo.Agenda)}", filtro.Agenda));
        }

        if (filtro.Julgador != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaRecordsDicInfo.Julgador)}", filtro.Julgador));
        }

        if (filtro.ClientesSocios != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaRecordsDicInfo.ClientesSocios)}", filtro.ClientesSocios));
        }

        if (filtro.Perito != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaRecordsDicInfo.Perito)}", filtro.Perito));
        }

        if (filtro.Colaborador != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaRecordsDicInfo.Colaborador)}", filtro.Colaborador));
        }

        if (filtro.Foro != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaRecordsDicInfo.Foro)}", filtro.Foro));
        }

        if (filtro.CrmAviso1 != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaRecordsDicInfo.CrmAviso1)}", filtro.CrmAviso1));
        }

        if (filtro.CrmAviso2 != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaRecordsDicInfo.CrmAviso2)}", filtro.CrmAviso2));
        }

        if (filtro.CrmAviso3 != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAgendaRecordsDicInfo.CrmAviso3)}", filtro.CrmAviso3));
        }

        var cWhere = filtro.Agenda == int.MinValue ? string.Empty : $"{DBAgendaRecordsDicInfo.Agenda} = @{nameof(DBAgendaRecordsDicInfo.Agenda)}";
        cWhere += filtro.Julgador == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaRecordsDicInfo.Julgador} = @{nameof(DBAgendaRecordsDicInfo.Julgador)}";
        cWhere += filtro.ClientesSocios == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaRecordsDicInfo.ClientesSocios} = @{nameof(DBAgendaRecordsDicInfo.ClientesSocios)}";
        cWhere += filtro.Perito == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaRecordsDicInfo.Perito} = @{nameof(DBAgendaRecordsDicInfo.Perito)}";
        cWhere += filtro.Colaborador == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaRecordsDicInfo.Colaborador} = @{nameof(DBAgendaRecordsDicInfo.Colaborador)}";
        cWhere += filtro.Foro == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaRecordsDicInfo.Foro} = @{nameof(DBAgendaRecordsDicInfo.Foro)}";
        cWhere += filtro.CrmAviso1 == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaRecordsDicInfo.CrmAviso1} = @{nameof(DBAgendaRecordsDicInfo.CrmAviso1)}";
        cWhere += filtro.CrmAviso2 == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaRecordsDicInfo.CrmAviso2} = @{nameof(DBAgendaRecordsDicInfo.CrmAviso2)}";
        cWhere += filtro.CrmAviso3 == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAgendaRecordsDicInfo.CrmAviso3} = @{nameof(DBAgendaRecordsDicInfo.CrmAviso3)}";
        return (cWhere, parameters);
    }
}