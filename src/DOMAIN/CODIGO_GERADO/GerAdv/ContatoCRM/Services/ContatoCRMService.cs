#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class ContatoCRMService(IOptions<AppSettings> appSettings, IContatoCRMReader reader, IContatoCRMValidation validation, IContatoCRMWriter writer, IOperadorReader operadorReader, IClientesReader clientesReader, IProcessosReader processosReader, ITipoContatoCRMReader tipocontatocrmReader, IContatoCRMOperadorService contatocrmoperadorService, IDocsRecebidosItensService docsrecebidositensService, IRecadosService recadosService, IHttpContextAccessor httpContextAccessor, HybridCache cache, IMemoryCache memory) : IContatoCRMService, IDisposable
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly IOptions<AppSettings> _appSettings = appSettings;
    private readonly HybridCache _cache = cache;
    private readonly IMemoryCache _memoryCache = memory;
    private bool _disposed;
    public async Task<IEnumerable<ContatoCRMResponseAll>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("ContatoCRM: URI inválida");
            }
        }

        var cacheKey = $"{uri}-ContatoCRM-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, string.Empty, [], uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<ContatoCRMResponseAll>> GetDataAllAsync(int max, string where, List<SqlParameter> parameters, string uri, CancellationToken token)
    {
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        if (oCnn == null)
        {
            throw new Exception("Conexão nula.");
        }

        var query = $@"SELECT TOP ({max})
                   {DBContatoCRM.SensivelCamposSqlX}, operNome,cliNome,proNroPasta,tccNome
                   FROM {DBContatoCRM.PTabelaNome.dbo(oCnn)} (NOLOCK)
                   LEFT JOIN {"Operador".dbo(oCnn)} (NOLOCK) ON operCodigo=ctcOperador
LEFT JOIN {"Clientes".dbo(oCnn)} (NOLOCK) ON cliCodigo=ctcCliente
LEFT JOIN {"Processos".dbo(oCnn)} (NOLOCK) ON proCodigo=ctcProcesso
LEFT JOIN {"TipoContatoCRM".dbo(oCnn)} (NOLOCK) ON tccCodigo=ctcTipoContatoCRM
 
                   {where}
                   ORDER BY 
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var lista = new List<ContatoCRMResponseAll>(max);
        var ds = await ConfiguracoesDBT.GetDataTable2Async(query, parameters, oCnn);
        if (ds != null)
            foreach (DataRow item in ds.Rows)
            {
                var dbRec = new DBContatoCRM(item);
                if (dbRec.ID.IsEmptyIDNumber())
                {
                    continue;
                }

                var contatocrm = reader.ReadAll(dbRec, item);
                if (contatocrm != null)
                {
                    lista.Add(contatocrm);
                }
            }

        return lista;
    }

    public async Task<IEnumerable<ContatoCRMResponseAll>> Filter(Filters.FilterContatoCRM filtro, [FromRoute, Required] string uri)
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
        var cacheKey = $"{uri}-ContatoCRM-Filter-{where.GetHashCode()}{parameters.GetHashCode()}{keyCache}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(BaseConsts.PMaxItens, string.IsNullOrEmpty(where) ? string.Empty : TSql.Where + where, parameters, uri, cancel), entryOptions, cancellationToken: new());
    }

    public async Task<ContatoCRMResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (id < 1)
        {
            return new ContatoCRMResponse();
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
            var result = await _cache.GetOrCreateAsync($"{uri}-ContatoCRM-GetById-{id}-{keyCache}", async cancel => await GetDataByIdAsync(id, oCnn, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"ContatoCRM - {uri}-: GetById");
        }
    }

    private async Task<ContatoCRMResponse?> GetDataByIdAsync(int id, MsiSqlConnection oCnn, CancellationToken token) => await Task.Run(() => reader.Read(id, oCnn));
    public async Task<ContatoCRMResponse?> AddAndUpdate([FromBody] Models.ContatoCRM regContatoCRM, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("ContatoCRM: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regContatoCRM == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regContatoCRM, this, operadorReader, clientesReader, processosReader, tipocontatocrmReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception($"ContatoCRM: {validade}");
            }

            var saved = writer.Write(regContatoCRM, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
            return reader.Read(saved.ID, oCnn);
        });
    }

    public async Task<ContatoCRMResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("ContatoCRM: URI inválida");
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

            var deleteValidation = await validation.CanDelete(id, this, contatocrmoperadorService, docsrecebidositensService, recadosService, uri, oCnn);
            if (deleteValidation.Length > 0)
            {
                throw new Exception(deleteValidation);
            }

            var contatocrm = reader.Read(id, oCnn);
            try
            {
                if (contatocrm != null)
                {
                    writer.Delete(contatocrm, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
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

            return contatocrm;
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

    private static (string where, List<SqlParameter> parametros)? WFiltro(Filters.FilterContatoCRM filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var parameters = new List<SqlParameter>();
        if (filtro.AgeClienteAvisado != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBContatoCRMDicInfo.AgeClienteAvisado)}", filtro.AgeClienteAvisado));
        }

        if (filtro.DocsViaRecebimento != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBContatoCRMDicInfo.DocsViaRecebimento)}", filtro.DocsViaRecebimento));
        }

        if (!string.IsNullOrEmpty(filtro.Assunto))
        {
            parameters.Add(new($"@{nameof(DBContatoCRMDicInfo.Assunto)}", filtro.Assunto));
        }

        if (filtro.QuemNotificou != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBContatoCRMDicInfo.QuemNotificou)}", filtro.QuemNotificou));
        }

        if (filtro.Operador != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBContatoCRMDicInfo.Operador)}", filtro.Operador));
        }

        if (filtro.Cliente != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBContatoCRMDicInfo.Cliente)}", filtro.Cliente));
        }

        if (filtro.ObjetoNotificou != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBContatoCRMDicInfo.ObjetoNotificou)}", filtro.ObjetoNotificou));
        }

        if (!string.IsNullOrEmpty(filtro.PessoaContato))
        {
            parameters.Add(new($"@{nameof(DBContatoCRMDicInfo.PessoaContato)}", filtro.PessoaContato));
        }

        if (filtro.Processo != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBContatoCRMDicInfo.Processo)}", filtro.Processo));
        }

        if (filtro.TipoContatoCRM != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBContatoCRMDicInfo.TipoContatoCRM)}", filtro.TipoContatoCRM));
        }

        if (!string.IsNullOrEmpty(filtro.Contato))
        {
            parameters.Add(new($"@{nameof(DBContatoCRMDicInfo.Contato)}", filtro.Contato));
        }

        if (filtro.Emocao != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBContatoCRMDicInfo.Emocao)}", filtro.Emocao));
        }

        if (!string.IsNullOrEmpty(filtro.GUID))
        {
            parameters.Add(new($"@{nameof(DBContatoCRMDicInfo.GUID)}", filtro.GUID));
        }

        var cWhere = filtro.AgeClienteAvisado == int.MinValue ? string.Empty : $"{DBContatoCRMDicInfo.AgeClienteAvisado} = @{nameof(DBContatoCRMDicInfo.AgeClienteAvisado)}";
        cWhere += filtro.DocsViaRecebimento == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBContatoCRMDicInfo.DocsViaRecebimento} = @{nameof(DBContatoCRMDicInfo.DocsViaRecebimento)}";
        cWhere += filtro.Assunto.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBContatoCRMDicInfo.Assunto} = @{nameof(DBContatoCRMDicInfo.Assunto)}";
        cWhere += filtro.QuemNotificou == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBContatoCRMDicInfo.QuemNotificou} = @{nameof(DBContatoCRMDicInfo.QuemNotificou)}";
        cWhere += filtro.Operador == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBContatoCRMDicInfo.Operador} = @{nameof(DBContatoCRMDicInfo.Operador)}";
        cWhere += filtro.Cliente == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBContatoCRMDicInfo.Cliente} = @{nameof(DBContatoCRMDicInfo.Cliente)}";
        cWhere += filtro.ObjetoNotificou == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBContatoCRMDicInfo.ObjetoNotificou} = @{nameof(DBContatoCRMDicInfo.ObjetoNotificou)}";
        cWhere += filtro.PessoaContato.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBContatoCRMDicInfo.PessoaContato} = @{nameof(DBContatoCRMDicInfo.PessoaContato)}";
        cWhere += filtro.Processo == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBContatoCRMDicInfo.Processo} = @{nameof(DBContatoCRMDicInfo.Processo)}";
        cWhere += filtro.TipoContatoCRM == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBContatoCRMDicInfo.TipoContatoCRM} = @{nameof(DBContatoCRMDicInfo.TipoContatoCRM)}";
        cWhere += filtro.Contato.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBContatoCRMDicInfo.Contato} = @{nameof(DBContatoCRMDicInfo.Contato)}";
        cWhere += filtro.Emocao == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBContatoCRMDicInfo.Emocao} = @{nameof(DBContatoCRMDicInfo.Emocao)}";
        cWhere += filtro.GUID.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBContatoCRMDicInfo.GUID} = @{nameof(DBContatoCRMDicInfo.GUID)}";
        return (cWhere, parameters);
    }
}