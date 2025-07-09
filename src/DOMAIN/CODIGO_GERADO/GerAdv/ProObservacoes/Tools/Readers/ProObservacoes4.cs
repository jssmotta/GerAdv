#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProObservacoesReader
{
    ProObservacoesResponse? Read(int id, MsiSqlConnection oCnn);
    ProObservacoesResponse? Read(Entity.DBProObservacoes dbRec, MsiSqlConnection oCnn);
    ProObservacoesResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ProObservacoesResponse? Read(Entity.DBProObservacoes dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ProObservacoesResponse? Read(DBProObservacoes dbRec);
    ProObservacoesResponseAll? ReadAll(DBProObservacoes dbRec, DataRow dr);
    ProObservacoesResponseAll? ReadAll(DBProObservacoes dbRec, SqlDataReader dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
    IEnumerable<ProObservacoesResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class ProObservacoes : IProObservacoesReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery("{pobCodigo, pobNome}", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    public IEnumerable<ProObservacoesResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<ProObservacoesResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<ProObservacoesResponseAll>> ReadLocalAsync()
        {
            var result = new List<ProObservacoesResponseAll>(max);
            await using var connection = Configuracoes.GetConnectionByUri(uri);
            await using var cmd = new SqlCommand(cmdText: ConfiguracoesDBT.CmdSql(sql), connection: connection?.InnerConnection)
            {
                CommandTimeout = 0
            };
            cmd.Parameters.AddRange([..parameters]);
            await using var reader = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult).ConfigureAwait(false);
            while (await reader.ReadAsync().ConfigureAwait(false))
            {
                if (await reader.IsDBNullAsync(1).ConfigureAwait(false))
                    continue;
                result.Add(ReadAll(new Entity.DBProObservacoes(reader), reader)!);
            }

            return result;
        }
    }

    static string BuildSqlQuery(string campos, string whereClause, string orderClause, int max, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"ProObservacoes".dbo(oCnn)} (NOLOCK) ");
        if (!string.IsNullOrEmpty(whereClause))
        {
            query.Append(!whereClause.ToUpperInvariant().Contains(TSql.Where, StringComparison.OrdinalIgnoreCase) ? TSql.Where : string.Empty).Append(whereClause);
        }

        if (!string.IsNullOrEmpty(orderClause))
        {
            query.Append(!orderClause.ToUpperInvariant().Contains(TSql.OrderBy, StringComparison.OrdinalIgnoreCase) ? TSql.OrderBy : string.Empty).Append(orderClause);
        }
        else
        {
            query.Append($"{TSql.OrderBy}pobNome");
        }

        return query.ToString();
    }

    public ProObservacoesResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProObservacoes(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProObservacoesResponse? Read(Entity.DBProObservacoes dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public ProObservacoesResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProObservacoes(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProObservacoesResponse? Read(Entity.DBProObservacoes dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var proobservacoes = new ProObservacoesResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Nome = dbRec.FNome ?? string.Empty,
            Observacoes = dbRec.FObservacoes ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            proobservacoes.Data = dbRec.FData;
        return proobservacoes;
    }

    public ProObservacoesResponse? Read(DBProObservacoes dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var proobservacoes = new ProObservacoesResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Nome = dbRec.FNome ?? string.Empty,
            Observacoes = dbRec.FObservacoes ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            proobservacoes.Data = dbRec.FData;
        return proobservacoes;
    }

    public ProObservacoesResponseAll? ReadAll(DBProObservacoes dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var proobservacoes = new ProObservacoesResponseAll
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Nome = dbRec.FNome ?? string.Empty,
            Observacoes = dbRec.FObservacoes ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            proobservacoes.Data = dbRec.FData;
        proobservacoes.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        return proobservacoes;
    }

    public ProObservacoesResponseAll? ReadAll(DBProObservacoes dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var proobservacoes = new ProObservacoesResponseAll
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Nome = dbRec.FNome ?? string.Empty,
            Observacoes = dbRec.FObservacoes ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            proobservacoes.Data = dbRec.FData;
        proobservacoes.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        return proobservacoes;
    }
}