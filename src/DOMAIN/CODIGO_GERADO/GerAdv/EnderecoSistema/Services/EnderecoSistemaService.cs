#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class EnderecoSistemaService(IOptions<AppSettings> appSettings, IEnderecoSistemaReader reader, IEnderecoSistemaValidation validation, IEnderecoSistemaWriter writer, ITipoEnderecoSistemaReader tipoenderecosistemaReader, IProcessosReader processosReader, ICidadeReader cidadeReader, IHttpContextAccessor httpContextAccessor, HybridCache cache, IMemoryCache memory) : IEnderecoSistemaService, IDisposable
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly IOptions<AppSettings> _appSettings = appSettings;
    private readonly HybridCache _cache = cache;
    private readonly IMemoryCache _memoryCache = memory;
    private bool _disposed;
    public async Task<IEnumerable<EnderecoSistemaResponseAll>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("EnderecoSistema: URI inválida");
            }
        }

        var cacheKey = $"{uri}-EnderecoSistema-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, string.Empty, [], uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<EnderecoSistemaResponseAll>> GetDataAllAsync(int max, string where, List<SqlParameter> parameters, string uri, CancellationToken token)
    {
        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        if (oCnn == null)
        {
            throw new Exception("Conexão nula.");
        }

        var query = $@"SELECT TOP ({max})
                   {DBEnderecoSistema.SensivelCamposSqlX}, [TipoEnderecoSistema].[tesNome],[Processos].[proNroPasta],[Cidade].[cidNome]
                   FROM {DBEnderecoSistema.PTabelaNome.dbo(oCnn)} (NOLOCK)
                   LEFT JOIN {"TipoEnderecoSistema".dbo(oCnn)} (NOLOCK) ON [TipoEnderecoSistema].[tesCodigo]=[EnderecoSistema].[estTipoEnderecoSistema]
LEFT JOIN {"Processos".dbo(oCnn)} (NOLOCK) ON [Processos].[proCodigo]=[EnderecoSistema].[estProcesso]
LEFT JOIN {"Cidade".dbo(oCnn)} (NOLOCK) ON [Cidade].[cidCodigo]=[EnderecoSistema].[estCidade]
 
                   {where}
                   ORDER BY [EnderecoSistema].[]
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var lista = new List<EnderecoSistemaResponseAll>(max);
        var ds = await ConfiguracoesDBT.GetDataTable2Async(query, parameters, oCnn);
        if (ds != null)
            foreach (DataRow item in ds.Rows)
            {
                var dbRec = new DBEnderecoSistema(item);
                if (dbRec.ID.IsEmptyIDNumber())
                {
                    continue;
                }

                var enderecosistema = reader.ReadAll(dbRec, item);
                if (enderecosistema != null)
                {
                    lista.Add(enderecosistema);
                }
            }

        return lista;
    }

    public async Task<IEnumerable<EnderecoSistemaResponseAll>> Filter(Filters.FilterEnderecoSistema filtro, [FromRoute, Required] string uri)
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
        var cacheKey = $"{uri}-EnderecoSistema-Filter-{where.GetHashCode()}{parameters.GetHashCode()}{keyCache}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxGetListSecondsCacheId)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(BaseConsts.PMaxItens, string.IsNullOrEmpty(where) ? string.Empty : TSql.Where + where, parameters, uri, cancel), entryOptions, cancellationToken: new());
    }

    public async Task<EnderecoSistemaResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (id < 1)
        {
            return new EnderecoSistemaResponse();
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
            var result = await _cache.GetOrCreateAsync($"{uri}-EnderecoSistema-GetById-{id}-{keyCache}", async cancel => await GetDataByIdAsync(id, oCnn, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"EnderecoSistema - {uri}-: GetById");
        }
    }

    private async Task<EnderecoSistemaResponse?> GetDataByIdAsync(int id, MsiSqlConnection oCnn, CancellationToken token) => await Task.Run(() => reader.Read(id, oCnn));
    public async Task<EnderecoSistemaResponse?> AddAndUpdate([FromBody] Models.EnderecoSistema regEnderecoSistema, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("EnderecoSistema: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regEnderecoSistema == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regEnderecoSistema, this, tipoenderecosistemaReader, processosReader, cidadeReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            var saved = writer.Write(regEnderecoSistema, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
            return reader.Read(saved.ID, oCnn);
        });
    }

    public async Task<EnderecoSistemaResponse?> Validation([FromBody] Models.EnderecoSistema regEnderecoSistema, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("EnderecoSistema: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regEnderecoSistema == null)
            {
                return null;
            }

            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regEnderecoSistema, this, tipoenderecosistemaReader, processosReader, cidadeReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception(validade);
            }

            if (regEnderecoSistema.Id.IsEmptyIDNumber())
            {
                return new EnderecoSistemaResponse();
            }

            return reader.Read(regEnderecoSistema.Id, oCnn);
        });
    }

    public async Task<EnderecoSistemaResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            {
                throw new Exception("EnderecoSistema: URI inválida");
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

            var enderecosistema = reader.Read(id, oCnn);
            try
            {
                if (enderecosistema != null)
                {
                    writer.Delete(enderecosistema, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
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

            return enderecosistema;
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

    private static (string where, List<SqlParameter> parametros)? WFiltro(Filters.FilterEnderecoSistema filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var parameters = new List<SqlParameter>();
        if (filtro.Cadastro != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBEnderecoSistemaDicInfo.Cadastro)}", filtro.Cadastro));
        }

        if (filtro.CadastroExCod != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBEnderecoSistemaDicInfo.CadastroExCod)}", filtro.CadastroExCod));
        }

        if (filtro.TipoEnderecoSistema != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBEnderecoSistemaDicInfo.TipoEnderecoSistema)}", filtro.TipoEnderecoSistema));
        }

        if (filtro.Processo != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBEnderecoSistemaDicInfo.Processo)}", filtro.Processo));
        }

        if (!string.IsNullOrEmpty(filtro.Motivo))
        {
            parameters.Add(new($"@{nameof(DBEnderecoSistemaDicInfo.Motivo)}", filtro.Motivo));
        }

        if (!string.IsNullOrEmpty(filtro.ContatoNoLocal))
        {
            parameters.Add(new($"@{nameof(DBEnderecoSistemaDicInfo.ContatoNoLocal)}", filtro.ContatoNoLocal));
        }

        if (filtro.Cidade != int.MinValue)
        {
            parameters.Add(new($"@{nameof(DBEnderecoSistemaDicInfo.Cidade)}", filtro.Cidade));
        }

        if (!string.IsNullOrEmpty(filtro.Endereco))
        {
            parameters.Add(new($"@{nameof(DBEnderecoSistemaDicInfo.Endereco)}", filtro.Endereco));
        }

        if (!string.IsNullOrEmpty(filtro.Bairro))
        {
            parameters.Add(new($"@{nameof(DBEnderecoSistemaDicInfo.Bairro)}", filtro.Bairro));
        }

        if (!string.IsNullOrEmpty(filtro.CEP))
        {
            parameters.Add(new($"@{nameof(DBEnderecoSistemaDicInfo.CEP)}", filtro.CEP));
        }

        if (!string.IsNullOrEmpty(filtro.Fone))
        {
            parameters.Add(new($"@{nameof(DBEnderecoSistemaDicInfo.Fone)}", filtro.Fone));
        }

        if (!string.IsNullOrEmpty(filtro.Fax))
        {
            parameters.Add(new($"@{nameof(DBEnderecoSistemaDicInfo.Fax)}", filtro.Fax));
        }

        if (!string.IsNullOrEmpty(filtro.Observacao))
        {
            parameters.Add(new($"@{nameof(DBEnderecoSistemaDicInfo.Observacao)}", filtro.Observacao));
        }

        if (!string.IsNullOrEmpty(filtro.GUID))
        {
            parameters.Add(new($"@{nameof(DBEnderecoSistemaDicInfo.GUID)}", filtro.GUID));
        }

        var cWhere = filtro.Cadastro == int.MinValue ? string.Empty : $"{DBEnderecoSistemaDicInfo.Cadastro} = @{nameof(DBEnderecoSistemaDicInfo.Cadastro)}";
        cWhere += filtro.CadastroExCod == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBEnderecoSistemaDicInfo.CadastroExCod} = @{nameof(DBEnderecoSistemaDicInfo.CadastroExCod)}";
        cWhere += filtro.TipoEnderecoSistema == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBEnderecoSistemaDicInfo.TipoEnderecoSistema} = @{nameof(DBEnderecoSistemaDicInfo.TipoEnderecoSistema)}";
        cWhere += filtro.Processo == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBEnderecoSistemaDicInfo.Processo} = @{nameof(DBEnderecoSistemaDicInfo.Processo)}";
        cWhere += filtro.Motivo.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBEnderecoSistemaDicInfo.Motivo} = @{nameof(DBEnderecoSistemaDicInfo.Motivo)}";
        cWhere += filtro.ContatoNoLocal.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBEnderecoSistemaDicInfo.ContatoNoLocal} = @{nameof(DBEnderecoSistemaDicInfo.ContatoNoLocal)}";
        cWhere += filtro.Cidade == int.MinValue ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBEnderecoSistemaDicInfo.Cidade} = @{nameof(DBEnderecoSistemaDicInfo.Cidade)}";
        cWhere += filtro.Endereco.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBEnderecoSistemaDicInfo.Endereco} = @{nameof(DBEnderecoSistemaDicInfo.Endereco)}";
        cWhere += filtro.Bairro.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBEnderecoSistemaDicInfo.Bairro} = @{nameof(DBEnderecoSistemaDicInfo.Bairro)}";
        cWhere += filtro.CEP.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBEnderecoSistemaDicInfo.CEP} = @{nameof(DBEnderecoSistemaDicInfo.CEP)}";
        cWhere += filtro.Fone.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBEnderecoSistemaDicInfo.Fone} = @{nameof(DBEnderecoSistemaDicInfo.Fone)}";
        cWhere += filtro.Fax.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBEnderecoSistemaDicInfo.Fax} = @{nameof(DBEnderecoSistemaDicInfo.Fax)}";
        cWhere += filtro.Observacao.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBEnderecoSistemaDicInfo.Observacao} = @{nameof(DBEnderecoSistemaDicInfo.Observacao)}";
        cWhere += filtro.GUID.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + $"{DBEnderecoSistemaDicInfo.GUID} = @{nameof(DBEnderecoSistemaDicInfo.GUID)}";
        return (cWhere, parameters);
    }
}