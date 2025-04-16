#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class HorasTrabService(IOptions<AppSettings> appSettings, IHorasTrabReader reader, IHorasTrabValidation validation, IHorasTrabWriter writer, IClientesReader clientesReader, IProcessosReader processosReader, IAdvogadosReader advogadosReader, IFuncionariosReader funcionariosReader, IServicosReader servicosReader, IHttpContextAccessor httpContextAccessor, HybridCache cache) : IHorasTrabService, IDisposable
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly string _uris = appSettings.Value.ValidUris;
    private readonly HybridCache _cache = cache;
    private bool _disposed;
    public async Task<IEnumerable<HorasTrabResponse>> GetAll(int max, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        max = Math.Min(Math.Max(max, 1), BaseConsts.PMaxItens);
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("HorasTrab: URI inválida");
            }
        }

        var cacheKey = $"{uri}-HorasTrab-GetAll-{max}";
        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache),
            LocalCacheExpiration = TimeSpan.FromMinutes(BaseConsts.PMaxMinutesCache)
        };
        return await _cache.GetOrCreateAsync(cacheKey, async cancel => await GetDataAllAsync(max, uri, cancel), entryOptions, cancellationToken: token);
    }

    private async Task<IEnumerable<HorasTrabResponse>> GetDataAllAsync(int max, string uri, CancellationToken token)
    {
        var query = $@"SELECT DISTINCT TOP {max} 
                   {DBHorasTrab.SensivelCamposSqlX} 
                   FROM {DBHorasTrab.PTabelaNome} (NOLOCK)
                   ORDER BY {DBHorasTrabDicInfo.CampoNome}
                   OPTION (OPTIMIZE FOR UNKNOWN)";
        var connection = Configuracoes.ConnectionByUri(uri);
        var lista = new List<DBHorasTrab>(max);
        await foreach (var item in DBHorasTrab.ListarAsync(query, string.Empty, string.Empty, connection).WithCancellation(token).ConfigureAwait(false))
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

    public async Task<IEnumerable<HorasTrabResponse>> Filter(Filters.FilterHorasTrab filtro, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            throw new Exception("HorasTrab: URI inválida");
        }

        return await Task.Run(() =>
        {
            using var scope = Configuracoes.CreateConnectionScope(uri);
            var oCnn = scope.Connection;
            if (oCnn == null)
            {
                return[];
            }

            var result = new List<HorasTrabResponse>();
            var cWhere = filtro == null ? string.Empty : WFiltro(filtro!);
            var list = DBHorasTrab.Listar("", cWhere, "", Configuracoes.ConnectionByUri(uri));
            if (list != null)
            {
                foreach (var item in list)
                    result.Add(reader.Read(item)!);
            }

            return result;
        });
    }

    public async Task<HorasTrabResponse?> GetById([FromQuery] int id, [FromRoute, Required] string uri, CancellationToken token)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("HorasTrab: URI inválida");
            }
        }

        var entryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromSeconds(BaseConsts.PMaxSecondsCacheId),
            LocalCacheExpiration = TimeSpan.FromSeconds(BaseConsts.PMaxSecondsCacheId)
        };
        try
        {
            var result = await _cache.GetOrCreateAsync($"{uri}-HorasTrab-GetById-{id}", async cancel => await GetDataByIdAsync(id, uri, cancel), entryOptions, cancellationToken: token);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception($"HorasTrab - {uri}-: GetById - {ex.Message}");
        }
    }

    private async Task<HorasTrabResponse?> GetDataByIdAsync(int id, string uri, CancellationToken token)
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

    public async Task<HorasTrabResponse?> AddAndUpdate([FromBody] Models.HorasTrab regHorasTrab, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("HorasTrab: URI inválida");
            }
        }

        return await Task.Run(async () =>
        {
            if (regHorasTrab == null)
            {
                return null;
            }

            using var scope = Configuracoes.CreateConnectionScopeRw(uri);
            var oCnn = scope.Connection;
            if (oCnn == null)
            {
                return null;
            }

            var validade = await validation.ValidateReg(regHorasTrab, this, clientesReader, processosReader, advogadosReader, funcionariosReader, servicosReader, uri, oCnn);
            if (validade.Length > 0)
            {
                throw new Exception($"HorasTrab: {validade}");
            }

            var saved = writer.Write(regHorasTrab, UserTools.GetAuthenticatedUserId(_httpContextAccessor), oCnn);
            return reader.Read(saved.ID, oCnn);
        });
    }

    public async Task<HorasTrabResponse?> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        if (!Uris.ValidaUri(uri, _uris))
        {
            {
                throw new Exception("HorasTrab: URI inválida");
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

            var horastrab = reader.Read(id, oCnn);
            if (horastrab != null)
            {
                new DBHorasTrab().DeletarItem(horastrab.Id, oCnn, null);
            }

            return horastrab;
        });
    }

    public async Task<GetColumnsResponse?> GetColumns([FromBody] GetColumns parameters, [FromRoute, Required] string uri)
    {
        ThrowIfDisposed();
        return !Uris.ValidaUri(uri, _uris) ? throw new Exception("HorasTrab: URI inválida") : await Task.Run(() =>
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

            using var dbRec = new DBHorasTrab(parameters?.Id ?? throw new Exception("Id == null"), oCnn);
            var campos = new List<ColumnValueItem>();
            foreach (var column in parameters?.Columns!)
                if (column != null && column.Length > 0)
                {
                    var value = dbRec.GetValueByNameField($"{DBHorasTrabDicInfo.TablePrefix}{char.ToUpper(column[0])}{column[1..]}");
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
        return !Uris.ValidaUri(uri, _uris) ? throw new Exception("HorasTrab: URI inválida") : await Task.Run(() =>
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

            using var dbRec = new DBHorasTrab(parameters?.Id ?? throw new Exception("Id is null"), oCnn);
            foreach (var(column, value)in parameters?.Columns!)
                dbRec.SetValueByNameField($"{DBHorasTrabDicInfo.TablePrefix}{char.ToUpper(column[0])}{column[1..]}", value);
            dbRec.AuditorQuem = UserTools.GetAuthenticatedUserId(_httpContextAccessor);
            return dbRec.Update(oCnn) == 0;
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

    private static string WFiltro(Filters.FilterHorasTrab filtro)
    {
        if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
        {
            filtro.Operator = TSql.And;
        }

        var cWhere = filtro.IDContatoCRM == -2147483648 ? string.Empty : DBHorasTrabDicInfo.IDContatoCRMSql(filtro.IDContatoCRM);
        cWhere += filtro.IDAgenda == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBHorasTrabDicInfo.IDAgendaSql(filtro.IDAgenda);
        cWhere += filtro.Cliente == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBHorasTrabDicInfo.ClienteSql(filtro.Cliente);
        cWhere += filtro.Status == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBHorasTrabDicInfo.StatusSql(filtro.Status);
        cWhere += filtro.Processo == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBHorasTrabDicInfo.ProcessoSql(filtro.Processo);
        cWhere += filtro.Advogado == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBHorasTrabDicInfo.AdvogadoSql(filtro.Advogado);
        cWhere += filtro.Funcionario == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBHorasTrabDicInfo.FuncionarioSql(filtro.Funcionario);
        cWhere += filtro.HrIni.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBHorasTrabDicInfo.HrIniSql(filtro.HrIni);
        cWhere += filtro.HrFim.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBHorasTrabDicInfo.HrFimSql(filtro.HrFim);
        cWhere += filtro.OBS.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBHorasTrabDicInfo.OBSSql(filtro.OBS);
        cWhere += filtro.Anexo.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBHorasTrabDicInfo.AnexoSql(filtro.Anexo);
        cWhere += filtro.AnexoComp.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBHorasTrabDicInfo.AnexoCompSql(filtro.AnexoComp);
        cWhere += filtro.AnexoUNC.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBHorasTrabDicInfo.AnexoUNCSql(filtro.AnexoUNC);
        cWhere += filtro.Servico == -2147483648 ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBHorasTrabDicInfo.ServicoSql(filtro.Servico);
        return cWhere;
    }
}