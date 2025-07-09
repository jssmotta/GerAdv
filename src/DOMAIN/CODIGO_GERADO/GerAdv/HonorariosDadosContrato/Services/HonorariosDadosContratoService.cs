#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class HonorariosDadosContratoService(IOptions<AppSettings> appSettings, IHonorariosDadosContratoReader reader, IHonorariosDadosContratoValidation validation, IHonorariosDadosContratoWriter writer, IClientesReader clientesReader, IProcessosReader processosReader, IHttpContextAccessor httpContextAccessor, HybridCache cache, IMemoryCache memory) : IHonorariosDadosContratoService, IDisposable
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly IOptions<AppSettings> _appSettings = appSettings;
    private readonly HybridCache _cache = cache;
    private readonly IMemoryCache _memoryCache = memory;
    private bool _disposed;
    public async Task<IEnumerable<HonorariosDadosContratoResponseAll>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("HonorariosDadosContrato: URI inválida");
            }
        }

        var cacheKey = $"{uri}-HonorariosDadosContrato-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, string.Empty, [], uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<HonorariosDadosContratoResponseAll>> GetDataAllAsync(int max, string where, List<SqlParameter> parameters, string uri, CancellationToken token)
    {
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        if (oCnn == null)
        {
            throw new Exception("Conexão nula.");
        }

        var query = $@"SELECT TOP ({max})
                   {DBHonorariosDadosContrato.SensivelCamposSqlX}, [Clientes].[cliNome],[Processos].[proNroPasta]
                   FROM {DBHonorariosDadosContrato.PTabelaNome.dbo(oCnn)} (NOLOCK)
                   LEFT JOIN {"Clientes".dbo(oCnn)} (NOLOCK) ON [Clientes].[cliCodigo]=[HonorariosDadosContrato].[hdcCliente]
LEFT JOIN {"Processos".dbo(oCnn)} (NOLOCK) ON [Processos].[proCodigo]=[HonorariosDadosContrato].[hdcProcesso]
 
                   {where}
                   ORDER BY [HonorariosDadosContrato].[]
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var lista = new List<HonorariosDadosContratoResponseAll>(max);
        var ds = await ConfiguracoesDBT.GetDataTable2Async(query, parameters, oCnn);
        if (ds != null)
            foreach (DataRow item in ds.Rows)
            {
                var dbRec = new DBHonorariosDadosContrato(item);
                if (dbRec.ID.IsEmptyIDNumber())
                {
                    continue;
                }

                var honorariosdadoscontrato = reader.ReadAll(dbRec, item);
                if (honorariosdadoscontrato != null)
                {
                    lista.Add(honorariosdadoscontrato);
                }
            }

        return lista;
    }

    public async Task<IEnumerable<HonorariosDadosContratoResponseAll>> Filter(Filters.FilterHonorariosDadosContrato filtro, [FromRoute, Required] string uri)
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
        var cacheKey = $"{uri}-HonorariosDadosContrato-Filter-{where.GetHashCode()}{parameters.GetHashCode()}{keyCache}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(BaseConsts.PMaxItens, string.IsNullOrEmpty(where) ? string.Empty : TSql.Where + where, parameters, uri, cancel), entryOptions, cancellationToken: new());
    }

    public async Task<HonorariosDadosContratoResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (id < 1)
        {
            return new HonorariosDadosContratoResponse();
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
            var result = await _cache.GetOrCreateAsync($"{uri}-HonorariosDadosContrato-GetById-{id}-{keyCache}", async cancel => await GetDataByIdAsync(id, oCnn, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"HonorariosDadosContrato - {uri}-: GetById");
        }
    }

    private async Task<HonorariosDadosContratoResponse?> GetDataByIdAsync(int id, MsiSqlConnection oCnn, CancellationToken token) => await Task.Run(() => reader.Read(id, oCnn));
    public async Task<HonorariosDadosContratoResponse?> AddAndUpdate([FromBody] Models.HonorariosDadosContrato regHonorariosDadosContrato, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("HonorariosDadosContrato: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regHonorariosDadosContrato == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regHonorariosDadosContrato, this, clientesReader, processosReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            var saved = writer.Write(regHonorariosDadosContrato, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
            return reader.Read(saved, oCnn);
        });
    }

    public async Task<HonorariosDadosContratoResponse?> Validation([FromBody] Models.HonorariosDadosContrato regHonorariosDadosContrato, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("HonorariosDadosContrato: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regHonorariosDadosContrato == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regHonorariosDadosContrato, this, clientesReader, processosReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            if (regHonorariosDadosContrato.Id.IsEmptyIDNumber())
            {
                return new HonorariosDadosContratoResponse();
            }

            return reader.Read(regHonorariosDadosContrato.Id, oCnn);
        });
    }

    public async Task<HonorariosDadosContratoResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("HonorariosDadosContrato: URI inválida");
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

            var honorariosdadoscontrato = reader.Read(id, oCnn);
            try
            {
                if (honorariosdadoscontrato != null)
                {
                    writer.Delete(honorariosdadoscontrato, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
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

            return honorariosdadoscontrato;
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

    private static (string where, List<SqlParameter> parametros)? WFiltro(Filters.FilterHonorariosDadosContrato filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var parameters = new List<SqlParameter>();
        if (filtro.Cliente != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBHonorariosDadosContratoDicInfo.Cliente)}", filtro.Cliente));
        }

        if (filtro.Processo != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBHonorariosDadosContratoDicInfo.Processo)}", filtro.Processo));
        }

        if (!string.IsNullOrEmpty(filtro.ArquivoContrato))
        {
            parameters.Add(new($"@{nameof(DBHonorariosDadosContratoDicInfo.ArquivoContrato)}", filtro.ArquivoContrato));
        }

        if (!string.IsNullOrEmpty(filtro.TextoContrato))
        {
            parameters.Add(new($"@{nameof(DBHonorariosDadosContratoDicInfo.TextoContrato)}", filtro.TextoContrato));
        }

        if (!string.IsNullOrEmpty(filtro.Observacao))
        {
            parameters.Add(new($"@{nameof(DBHonorariosDadosContratoDicInfo.Observacao)}", filtro.Observacao));
        }

        if (!string.IsNullOrEmpty(filtro.GUID))
        {
            parameters.Add(new($"@{nameof(DBHonorariosDadosContratoDicInfo.GUID)}", filtro.GUID));
        }

        var cWhere = filtro.Cliente == int.MinValue ? string.Empty : $"{DBHonorariosDadosContratoDicInfo.Cliente} = @{nameof(DBHonorariosDadosContratoDicInfo.Cliente)}";
        cWhere += filtro.Processo == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBHonorariosDadosContratoDicInfo.Processo} = @{nameof(DBHonorariosDadosContratoDicInfo.Processo)}";
        cWhere += filtro.ArquivoContrato.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBHonorariosDadosContratoDicInfo.ArquivoContrato} = @{nameof(DBHonorariosDadosContratoDicInfo.ArquivoContrato)}";
        cWhere += filtro.TextoContrato.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBHonorariosDadosContratoDicInfo.TextoContrato} = @{nameof(DBHonorariosDadosContratoDicInfo.TextoContrato)}";
        cWhere += filtro.Observacao.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBHonorariosDadosContratoDicInfo.Observacao} = @{nameof(DBHonorariosDadosContratoDicInfo.Observacao)}";
        cWhere += filtro.GUID.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBHonorariosDadosContratoDicInfo.GUID} = @{nameof(DBHonorariosDadosContratoDicInfo.GUID)}";
        return (cWhere, parameters);
    }
}