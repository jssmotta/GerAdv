#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class AlertasEnviadosService(IOptions<AppSettings> appSettings, IAlertasEnviadosReader reader, IAlertasEnviadosValidation validation, IAlertasEnviadosWriter writer, IOperadorReader operadorReader, IAlertasReader alertasReader, HybridCache cache, IMemoryCache memory) : IAlertasEnviadosService, IDisposable
{
    private readonly IOptions<AppSettings> _appSettings = appSettings;
    private readonly HybridCache _cache = cache;
    private readonly IMemoryCache _memoryCache = memory;
    private bool _disposed;
    public async Task<IEnumerable<AlertasEnviadosResponseAll>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("AlertasEnviados: URI inválida");
            }
        }

        var cacheKey = $"{uri}-AlertasEnviados-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, string.Empty, [], uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<AlertasEnviadosResponseAll>> GetDataAllAsync(int max, string where, List<SqlParameter> parameters, string uri, CancellationToken token)
    {
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        if (oCnn == null)
        {
            throw new Exception("Conexão nula.");
        }

        var query = $@"SELECT TOP ({max})
                   {DBAlertasEnviados.SensivelCamposSqlX}, [Operador].[operNome],[Alertas].[altNome]
                   FROM {DBAlertasEnviados.PTabelaNome.dbo(oCnn)} (NOLOCK)
                   LEFT JOIN {"Operador".dbo(oCnn)} (NOLOCK) ON [Operador].[operCodigo]=[AlertasEnviados].[aloOperador]
LEFT JOIN {"Alertas".dbo(oCnn)} (NOLOCK) ON [Alertas].[altCodigo]=[AlertasEnviados].[aloAlerta]
 
                   {where}
                   ORDER BY [AlertasEnviados].[]
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var lista = new List<AlertasEnviadosResponseAll>(max);
        var ds = await ConfiguracoesDBT.GetDataTable2Async(query, parameters, oCnn);
        if (ds != null)
            foreach (DataRow item in ds.Rows)
            {
                var dbRec = new DBAlertasEnviados(item);
                if (dbRec.ID.IsEmptyIDNumber())
                {
                    continue;
                }

                var alertasenviados = reader.ReadAll(dbRec, item);
                if (alertasenviados != null)
                {
                    lista.Add(alertasenviados);
                }
            }

        return lista;
    }

    public async Task<IEnumerable<AlertasEnviadosResponseAll>> Filter(Filters.FilterAlertasEnviados filtro, [FromRoute, Required] string uri)
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
        var cacheKey = $"{uri}-AlertasEnviados-Filter-{where.GetHashCode()}{parameters.GetHashCode()}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(BaseConsts.PMaxItens, string.IsNullOrEmpty(where) ? string.Empty : TSql.Where + where, parameters, uri, cancel), entryOptions, cancellationToken: new());
    }

    public async Task<AlertasEnviadosResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (id < 1)
        {
            return new AlertasEnviadosResponse();
        }

        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxSecondsCacheId)
        };
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        try
        {
            var result = await _cache.GetOrCreateAsync($"{uri}-AlertasEnviados-GetById-{id}", async cancel => await GetDataByIdAsync(id, oCnn, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"AlertasEnviados - {uri}-: GetById");
        }
    }

    private async Task<AlertasEnviadosResponse?> GetDataByIdAsync(int id, MsiSqlConnection oCnn, CancellationToken token) => await Task.Run(() => reader.Read(id, oCnn));
    public async Task<AlertasEnviadosResponse?> AddAndUpdate([FromBody] Models.AlertasEnviados regAlertasEnviados, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("AlertasEnviados: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regAlertasEnviados == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regAlertasEnviados, this, operadorReader, alertasReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            var saved = writer.Write(regAlertasEnviados, oCnn);
            return reader.Read(saved.ID, oCnn);
        });
    }

    public async Task<AlertasEnviadosResponse?> Validation([FromBody] Models.AlertasEnviados regAlertasEnviados, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("AlertasEnviados: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regAlertasEnviados == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regAlertasEnviados, this, operadorReader, alertasReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            if (regAlertasEnviados.Id.IsEmptyIDNumber())
            {
                return new AlertasEnviadosResponse();
            }

            return reader.Read(regAlertasEnviados.Id, oCnn);
        });
    }

    public async Task<AlertasEnviadosResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("AlertasEnviados: URI inválida");
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

            var alertasenviados = reader.Read(id, oCnn);
            try
            {
                if (alertasenviados != null)
                {
                    writer.Delete(alertasenviados, 0, oCnn);
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

            return alertasenviados;
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

    private static (string where, List<SqlParameter> parametros)? WFiltro(Filters.FilterAlertasEnviados filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var parameters = new List<SqlParameter>();
        if (filtro.Operador != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAlertasEnviadosDicInfo.Operador)}", filtro.Operador));
        }

        if (filtro.Alerta != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBAlertasEnviadosDicInfo.Alerta)}", filtro.Alerta));
        }

        var cWhere = filtro.Operador == int.MinValue ? string.Empty : $"{DBAlertasEnviadosDicInfo.Operador} = @{nameof(DBAlertasEnviadosDicInfo.Operador)}";
        cWhere += filtro.Alerta == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBAlertasEnviadosDicInfo.Alerta} = @{nameof(DBAlertasEnviadosDicInfo.Alerta)}";
        return (cWhere, parameters);
    }
}