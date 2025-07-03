#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class RecadosService(IOptions<AppSettings> appSettings, IRecadosReader reader, IRecadosValidation validation, IRecadosWriter writer, IProcessosReader processosReader, IClientesReader clientesReader, IHistoricoReader historicoReader, IContatoCRMReader contatocrmReader, ILigacoesReader ligacoesReader, IAgendaReader agendaReader, IAlarmSMSService alarmsmsService, IHttpContextAccessor httpContextAccessor, HybridCache cache, IMemoryCache memory) : IRecadosService, IDisposable
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly IOptions<AppSettings> _appSettings = appSettings;
    private readonly HybridCache _cache = cache;
    private readonly IMemoryCache _memoryCache = memory;
    private bool _disposed;
    public async Task<IEnumerable<RecadosResponseAll>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("Recados: URI inválida");
            }
        }

        var cacheKey = $"{uri}-Recados-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, string.Empty, [], uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<RecadosResponseAll>> GetDataAllAsync(int max, string where, List<SqlParameter> parameters, string uri, CancellationToken token)
    {
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        if (oCnn == null)
        {
            throw new Exception("Conexão nula.");
        }

        var query = $@"SELECT TOP ({max})
                   {DBRecados.SensivelCamposSqlX}, [Processos].[proNroPasta],[Clientes].[cliNome],[Historico].[],[ContatoCRM].[],[Ligacoes].[ligNome],[Agenda].[]
                   FROM {DBRecados.PTabelaNome.dbo(oCnn)} (NOLOCK)
                   LEFT JOIN {"Processos".dbo(oCnn)} (NOLOCK) ON [Processos].[proCodigo]=[Recados].[recProcesso]
LEFT JOIN {"Clientes".dbo(oCnn)} (NOLOCK) ON [Clientes].[cliCodigo]=[Recados].[recCliente]
LEFT JOIN {"Historico".dbo(oCnn)} (NOLOCK) ON [Historico].[hisCodigo]=[Recados].[recHistorico]
LEFT JOIN {"ContatoCRM".dbo(oCnn)} (NOLOCK) ON [ContatoCRM].[ctcCodigo]=[Recados].[recContatoCRM]
LEFT JOIN {"Ligacoes".dbo(oCnn)} (NOLOCK) ON [Ligacoes].[ligCodigo]=[Recados].[recLigacoes]
LEFT JOIN {"Agenda".dbo(oCnn)} (NOLOCK) ON [Agenda].[ageCodigo]=[Recados].[recAgenda]
 
                   {where}
                   ORDER BY [Recados].[]
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var lista = new List<RecadosResponseAll>(max);
        var ds = await ConfiguracoesDBT.GetDataTable2Async(query, parameters, oCnn);
        if (ds != null)
            foreach (DataRow item in ds.Rows)
            {
                var dbRec = new DBRecados(item);
                if (dbRec.ID.IsEmptyIDNumber())
                {
                    continue;
                }

                var recados = reader.ReadAll(dbRec, item);
                if (recados != null)
                {
                    lista.Add(recados);
                }
            }

        return lista;
    }

    public async Task<IEnumerable<RecadosResponseAll>> Filter(Filters.FilterRecados filtro, [FromRoute, Required] string uri)
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
        var cacheKey = $"{uri}-Recados-Filter-{where.GetHashCode()}{parameters.GetHashCode()}{keyCache}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(BaseConsts.PMaxItens, string.IsNullOrEmpty(where) ? string.Empty : TSql.Where + where, parameters, uri, cancel), entryOptions, cancellationToken: new());
    }

    public async Task<RecadosResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (id < 1)
        {
            return new RecadosResponse();
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
            var result = await _cache.GetOrCreateAsync($"{uri}-Recados-GetById-{id}-{keyCache}", async cancel => await GetDataByIdAsync(id, oCnn, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"Recados - {uri}-: GetById");
        }
    }

    private async Task<RecadosResponse?> GetDataByIdAsync(int id, MsiSqlConnection oCnn, CancellationToken token) => await Task.Run(() => reader.Read(id, oCnn));
    public async Task<RecadosResponse?> AddAndUpdate([FromBody] Models.Recados regRecados, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("Recados: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regRecados == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regRecados, this, processosReader, clientesReader, historicoReader, contatocrmReader, ligacoesReader, agendaReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            var saved = writer.Write(regRecados, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
            return reader.Read(saved.ID, oCnn);
        });
    }

    public async Task<RecadosResponse?> Validation([FromBody] Models.Recados regRecados, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("Recados: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regRecados == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regRecados, this, processosReader, clientesReader, historicoReader, contatocrmReader, ligacoesReader, agendaReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            if (regRecados.Id.IsEmptyIDNumber())
            {
                return new RecadosResponse();
            }

            return reader.Read(regRecados.Id, oCnn);
        });
    }

    public async Task<RecadosResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("Recados: URI inválida");
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

            var deleteValidation = await validation.CanDelete(id, this, alarmsmsService, uri, oCnn);
            if (deleteValidation.Length > 0)
            {
                throw new Exception(deleteValidation);
            }

            var recados = reader.Read(id, oCnn);
            try
            {
                if (recados != null)
                {
                    writer.Delete(recados, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
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

            return recados;
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

    private static (string where, List<SqlParameter> parametros)? WFiltro(Filters.FilterRecados filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var parameters = new List<SqlParameter>();
        if (!string.IsNullOrEmpty(filtro.ClienteNome))
        {
            parameters.Add(new($"@{nameof(DBRecadosDicInfo.ClienteNome)}", filtro.ClienteNome));
        }

        if (!string.IsNullOrEmpty(filtro.De))
        {
            parameters.Add(new($"@{nameof(DBRecadosDicInfo.De)}", filtro.De));
        }

        if (!string.IsNullOrEmpty(filtro.Para))
        {
            parameters.Add(new($"@{nameof(DBRecadosDicInfo.Para)}", filtro.Para));
        }

        if (!string.IsNullOrEmpty(filtro.Assunto))
        {
            parameters.Add(new($"@{nameof(DBRecadosDicInfo.Assunto)}", filtro.Assunto));
        }

        if (filtro.Processo != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBRecadosDicInfo.Processo)}", filtro.Processo));
        }

        if (filtro.Cliente != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBRecadosDicInfo.Cliente)}", filtro.Cliente));
        }

        if (!string.IsNullOrEmpty(filtro.Recado))
        {
            parameters.Add(new($"@{nameof(DBRecadosDicInfo.Recado)}", filtro.Recado));
        }

        if (filtro.Emotion != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBRecadosDicInfo.Emotion)}", filtro.Emotion));
        }

        if (filtro.InternetID != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBRecadosDicInfo.InternetID)}", filtro.InternetID));
        }

        if (filtro.Natureza != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBRecadosDicInfo.Natureza)}", filtro.Natureza));
        }

        if (!string.IsNullOrEmpty(filtro.AguardarRetornoPara))
        {
            parameters.Add(new($"@{nameof(DBRecadosDicInfo.AguardarRetornoPara)}", filtro.AguardarRetornoPara));
        }

        if (filtro.ParaID != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBRecadosDicInfo.ParaID)}", filtro.ParaID));
        }

        if (filtro.MasterID != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBRecadosDicInfo.MasterID)}", filtro.MasterID));
        }

        if (!string.IsNullOrEmpty(filtro.ListaPara))
        {
            parameters.Add(new($"@{nameof(DBRecadosDicInfo.ListaPara)}", filtro.ListaPara));
        }

        if (filtro.AssuntoRecado != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBRecadosDicInfo.AssuntoRecado)}", filtro.AssuntoRecado));
        }

        if (filtro.Historico != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBRecadosDicInfo.Historico)}", filtro.Historico));
        }

        if (filtro.ContatoCRM != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBRecadosDicInfo.ContatoCRM)}", filtro.ContatoCRM));
        }

        if (filtro.Ligacoes != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBRecadosDicInfo.Ligacoes)}", filtro.Ligacoes));
        }

        if (filtro.Agenda != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBRecadosDicInfo.Agenda)}", filtro.Agenda));
        }

        if (!string.IsNullOrEmpty(filtro.GUID))
        {
            parameters.Add(new($"@{nameof(DBRecadosDicInfo.GUID)}", filtro.GUID));
        }

        var cWhere = filtro.ClienteNome.IsEmpty() ? string.Empty : $"{DBRecadosDicInfo.ClienteNome} = @{nameof(DBRecadosDicInfo.ClienteNome)}";
        cWhere += filtro.De.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBRecadosDicInfo.De} = @{nameof(DBRecadosDicInfo.De)}";
        cWhere += filtro.Para.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBRecadosDicInfo.Para} = @{nameof(DBRecadosDicInfo.Para)}";
        cWhere += filtro.Assunto.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBRecadosDicInfo.Assunto} = @{nameof(DBRecadosDicInfo.Assunto)}";
        cWhere += filtro.Processo == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBRecadosDicInfo.Processo} = @{nameof(DBRecadosDicInfo.Processo)}";
        cWhere += filtro.Cliente == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBRecadosDicInfo.Cliente} = @{nameof(DBRecadosDicInfo.Cliente)}";
        cWhere += filtro.Recado.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBRecadosDicInfo.Recado} = @{nameof(DBRecadosDicInfo.Recado)}";
        cWhere += filtro.Emotion == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBRecadosDicInfo.Emotion} = @{nameof(DBRecadosDicInfo.Emotion)}";
        cWhere += filtro.InternetID == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBRecadosDicInfo.InternetID} = @{nameof(DBRecadosDicInfo.InternetID)}";
        cWhere += filtro.Natureza == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBRecadosDicInfo.Natureza} = @{nameof(DBRecadosDicInfo.Natureza)}";
        cWhere += filtro.AguardarRetornoPara.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBRecadosDicInfo.AguardarRetornoPara} = @{nameof(DBRecadosDicInfo.AguardarRetornoPara)}";
        cWhere += filtro.ParaID == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBRecadosDicInfo.ParaID} = @{nameof(DBRecadosDicInfo.ParaID)}";
        cWhere += filtro.MasterID == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBRecadosDicInfo.MasterID} = @{nameof(DBRecadosDicInfo.MasterID)}";
        cWhere += filtro.ListaPara.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBRecadosDicInfo.ListaPara} = @{nameof(DBRecadosDicInfo.ListaPara)}";
        cWhere += filtro.AssuntoRecado == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBRecadosDicInfo.AssuntoRecado} = @{nameof(DBRecadosDicInfo.AssuntoRecado)}";
        cWhere += filtro.Historico == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBRecadosDicInfo.Historico} = @{nameof(DBRecadosDicInfo.Historico)}";
        cWhere += filtro.ContatoCRM == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBRecadosDicInfo.ContatoCRM} = @{nameof(DBRecadosDicInfo.ContatoCRM)}";
        cWhere += filtro.Ligacoes == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBRecadosDicInfo.Ligacoes} = @{nameof(DBRecadosDicInfo.Ligacoes)}";
        cWhere += filtro.Agenda == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBRecadosDicInfo.Agenda} = @{nameof(DBRecadosDicInfo.Agenda)}";
        cWhere += filtro.GUID.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBRecadosDicInfo.GUID} = @{nameof(DBRecadosDicInfo.GUID)}";
        return (cWhere, parameters);
    }
}