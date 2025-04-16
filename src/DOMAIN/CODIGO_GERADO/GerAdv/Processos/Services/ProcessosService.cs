#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class ProcessosService(IOptions<AppSettings> appSettings, IProcessosReader reader, IProcessosValidation validation, IProcessosWriter writer, IAdvogadosReader advogadosReader, IJusticaReader justicaReader, IPrepostosReader prepostosReader, IClientesReader clientesReader, IOponentesReader oponentesReader, IAreaReader areaReader, ISituacaoReader situacaoReader, IRitoReader ritoReader, IAtividadesReader atividadesReader, IHttpContextAccessor httpContextAccessor, HybridCache cache) : IProcessosService, IDisposable
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly string _uris = appSettings.Value.ValidUris;
    private readonly HybridCache _cache = cache;
    private bool _disposed;
    public async Task<IEnumerable<ProcessosResponse>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("Processos: URI inválida");
            }
        }

        var cacheKey = $"{uri}-Processos-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<ProcessosResponse>> GetDataAllAsync(int max, string uri, CancellationToken token)
    {
        var query = $@"SELECT DISTINCT TOP {max} 
                   {DBProcessos.SensivelCamposSqlX} 
                   FROM {DBProcessos.PTabelaNome} (NOLOCK)
                   ORDER BY {DBProcessosDicInfo.CampoNome}
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var connection = Configuracoes.ConnectionByUri(uri);
        var lista = new List<DBProcessos>(max);
        await foreach (var item in DBProcessos.ListarAsync(query, string.Empty, string.Empty, connection).WithCancellation(token).ConfigureAwait(false))
        {
            if (item != null)
            {
                lista.Add(item);
                if (lista.Count % 100 == 0)
                    token.ThrowIfCancellationRequested();
            }
        }

        return lista.Count > 0 ? lista.Select(item => reader.Read(item)!).Where(item => item != null).ToList() : [];
    }

    public async Task<IEnumerable<ProcessosResponse>> Filter(Filters.FilterProcessos filtro, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            throw new Exception("Processos: URI inválida");
        }

        return await Task.Run(() =>
        {
            using var scope = Configuracoes.CreateConnectionScope(uri);
            var oCnn = scope.Connection;
            if (oCnn == null)
            {
                return[];
            }

            var result = new List<ProcessosResponse>();
            var cWhere = filtro == null ? string.Empty : WFiltro(filtro!);
            var list = DBProcessos.Listar("", cWhere, "", Configuracoes.ConnectionByUri(uri));
            if (list != null)
            {
                foreach (var item in list)
                    result.Add(reader.Read(item)!);
            }

            return result;
        });
    }

    public async Task<ProcessosResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("Processos: URI inválida");
            }
        }

        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxSecondsCacheId)
        };
        try
        {
            var result = await _cache.GetOrCreateAsync($"{uri}-Processos-GetById-{id}", async cancel => await GetDataByIdAsync(id, uri, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"Processos - {uri}-: GetById - {ex.Message}");
        }
    }

    private async Task<ProcessosResponse?> GetDataByIdAsync(int id, string uri, CancellationToken token)
    {
        return await Task.Run(() =>
        {
            if (id.IsEmptyIDNumber())
            {
                return null;
            }

            using var scope = Configuracoes.CreateConnectionScope(uri);
            var oCnn = scope.Connection;
            return oCnn == null ? null : reader.Read(id, oCnn);
        });
    }

    public async Task<ProcessosResponse?> AddAndUpdate([FromBody] Models.Processos regProcessos, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("Processos: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regProcessos == null)
            {
                return null;
            }

            using var scope = Configuracoes.CreateConnectionScopeRw(uri);
            var oCnn = scope.Connection;
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regProcessos, this, advogadosReader, justicaReader, prepostosReader, clientesReader, oponentesReader, areaReader, situacaoReader, ritoReader, atividadesReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception($"Processos: {validade}");
            }

            var saved = writer.Write(regProcessos, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
            return reader.Read(saved.ID, oCnn);
        });
    }

    public async Task<ProcessosResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("Processos: URI inválida");
            }
        }

        return await Task.Run(() =>
        {
            if (id.IsEmptyIDNumber())
            {
                return null;
            }

            using var scope = Configuracoes.CreateConnectionScopeRw(uri);
            var oCnn = scope.Connection;
            if (oCnn == null)
            {
                return null;
            }

            var processos = reader.Read(id, oCnn);
            if (processos != null)
            {
                new DBProcessos().DeletarItem(processos.Id, oCnn, null);
            }

            return processos;
        });
    }

    public async Task<GetColumnsResponse?> GetColumns([FromBody] GetColumns parameters, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        return !Uris.ValidaUri(uri, _uris) ? throw new Exception("Processos: URI inválida") : await Task.Run(() =>
        {
            if (parameters == null || parameters.Id.IsEmptyIDNumber() || parameters.Columns == null || parameters?.Columns?.Count() == 0)
            {
                return null;
            }

            using var scope = Configuracoes.CreateConnectionScope(uri);
            var oCnn = scope.Connection;
            if (oCnn == null)
            {
                return null;
            }

            using var dbRec = new DBProcessos(parameters?.Id ?? throw new Exception("Id == null"), oCnn);
            var campos = new List<ColumnValueItem>();
            foreach (var column in parameters?.Columns!)
                if (column != null && column.Length > 0)
                {
                    var value = dbRec.GetValueByNameField($"{DBProcessosDicInfo.TablePrefix}{char.ToUpper(column[0])}{column[1..]}");
                    if (value != null)
                        campos.Add(new ColumnValueItem(column, value));
                }

            var result = new GetColumnsResponse
            {
                Id = parameters.Id,
                Columns = campos
            };
            return result;
        });
    }

    public async Task<bool> UpdateColumns([FromBody] UpdateColumnsRequest parameters, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        return !Uris.ValidaUri(uri, _uris) ? throw new Exception("Processos: URI inválida") : await Task.Run(() =>
        {
            if (parameters == null || parameters.Id.IsEmptyIDNumber() || parameters.Columns == null || parameters?.Columns?.Count() == 0)
            {
                return false;
            }

            using var scope = Configuracoes.CreateConnectionScopeRw(uri);
            var oCnn = scope.Connection;
            if (oCnn == null)
            {
                return false;
            }

            using var dbRec = new DBProcessos(parameters?.Id ?? throw new Exception("Id is null"), oCnn);
            foreach (var(column, value)in parameters?.Columns!)
                dbRec.SetValueByNameField($"{DBProcessosDicInfo.TablePrefix}{char.ToUpper(column[0])}{column[1..]}", value);
            dbRec.AuditorQuem = UserTools.GetAuthenticatedUserId(_httpContextAccessor);
            return dbRec.Update(oCnn) == 0;
        });
    }

    public async Task<ProcessosResponse?> GetByName(string name, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("Processos: URI inválida");
            }
        }

        return await Task.Run(() =>
        {
            using var scope = Configuracoes.CreateConnectionScope(uri);
            var oCnn = scope.Connection;
            if (oCnn == null)
            {
                return null;
            }

            var cWhere = $"{DBProcessosDicInfo.CampoNome} like '{name.PreparaParaSql()}'";
            var result = reader.Read(cWhere, oCnn);
            return result ?? new();
        });
    }

    public async Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterProcessos? filtro, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            throw new Exception("Processos: URI inválida");
        }

        var cWhere = filtro == null ? string.Empty : WFiltro(filtro!);
        var cacheKey = $"{uri}-Processos-{max}-{cWhere.GetHashCode()}-GetListN";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxSecondsCacheId)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataListNAsync(max, uri, cWhere, cancel), entryOptions, cancellationToken: token) ?? [];
    }

    private static async Task<IEnumerable<NomeID>> GetDataListNAsync(int max, string uri, string cWhere, CancellationToken token)
    {
        return await Task.Run(() =>
        {
            var result = new List<NomeID>(max);
            foreach (var item in DBProcessos.ListarN(cWhere, DBProcessosDicInfo.CampoNome, Configuracoes.ConnectionByUri(uri), max: max))
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

    private static string WFiltro(Filters.FilterProcessos filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var cWhere = filtro.AdvParc == -2147483648 ? string.Empty : DBProcessosDicInfo.AdvParcSql(filtro.AdvParc);
        cWhere += filtro.TipoBaixa == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBProcessosDicInfo.TipoBaixaSql(filtro.TipoBaixa);
        cWhere += filtro.ClassRisco == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBProcessosDicInfo.ClassRiscoSql(filtro.ClassRisco);
        cWhere += filtro.ObsBCX.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBProcessosDicInfo.ObsBCXSql(filtro.ObsBCX);
        cWhere += filtro.NroExtra.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBProcessosDicInfo.NroExtraSql(filtro.NroExtra);
        cWhere += filtro.AdvOpo == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBProcessosDicInfo.AdvOpoSql(filtro.AdvOpo);
        cWhere += filtro.Justica == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBProcessosDicInfo.JusticaSql(filtro.Justica);
        cWhere += filtro.Advogado == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBProcessosDicInfo.AdvogadoSql(filtro.Advogado);
        cWhere += filtro.NroCaixa.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBProcessosDicInfo.NroCaixaSql(filtro.NroCaixa);
        cWhere += filtro.Preposto == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBProcessosDicInfo.PrepostoSql(filtro.Preposto);
        cWhere += filtro.Cliente == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBProcessosDicInfo.ClienteSql(filtro.Cliente);
        cWhere += filtro.Oponente == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBProcessosDicInfo.OponenteSql(filtro.Oponente);
        cWhere += filtro.Area == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBProcessosDicInfo.AreaSql(filtro.Area);
        cWhere += filtro.Cidade == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBProcessosDicInfo.CidadeSql(filtro.Cidade);
        cWhere += filtro.Situacao == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBProcessosDicInfo.SituacaoSql(filtro.Situacao);
        cWhere += filtro.Rito == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBProcessosDicInfo.RitoSql(filtro.Rito);
        cWhere += filtro.Fato.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBProcessosDicInfo.FatoSql(filtro.Fato);
        cWhere += filtro.NroPasta.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBProcessosDicInfo.NroPastaSql(filtro.NroPasta);
        cWhere += filtro.Atividade == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBProcessosDicInfo.AtividadeSql(filtro.Atividade);
        cWhere += filtro.CaixaMorto.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBProcessosDicInfo.CaixaMortoSql(filtro.CaixaMorto);
        cWhere += filtro.MotivoBaixa.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBProcessosDicInfo.MotivoBaixaSql(filtro.MotivoBaixa);
        cWhere += filtro.OBS.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBProcessosDicInfo.OBSSql(filtro.OBS);
        cWhere += filtro.ZKey.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBProcessosDicInfo.ZKeySql(filtro.ZKey);
        cWhere += filtro.ZKeyQuem == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBProcessosDicInfo.ZKeyQuemSql(filtro.ZKeyQuem);
        cWhere += filtro.Resumo.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBProcessosDicInfo.ResumoSql(filtro.Resumo);
        cWhere += filtro.NroContrato.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBProcessosDicInfo.NroContratoSql(filtro.NroContrato);
        cWhere += filtro.PercProbExitoJustificativa.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBProcessosDicInfo.PercProbExitoJustificativaSql(filtro.PercProbExitoJustificativa);
        cWhere += filtro.FaseAuditoria == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBProcessosDicInfo.FaseAuditoriaSql(filtro.FaseAuditoria);
        cWhere += filtro.ValorCondenacaoProvisorio == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBProcessosDicInfo.ValorCondenacaoProvisorioSql(filtro.ValorCondenacaoProvisorio);
        return cWhere;
    }
}