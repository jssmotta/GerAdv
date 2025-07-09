#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAlertasReader
{
    AlertasResponse? Read(int id, MsiSqlConnection oCnn);
    AlertasResponse? Read(Entity.DBAlertas dbRec, MsiSqlConnection oCnn);
    AlertasResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    AlertasResponse? Read(Entity.DBAlertas dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    AlertasResponse? Read(DBAlertas dbRec);
    AlertasResponseAll? ReadAll(DBAlertas dbRec, DataRow dr);
    AlertasResponseAll? ReadAll(DBAlertas dbRec, SqlDataReader dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
    IEnumerable<AlertasResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class Alertas : IAlertasReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery("{altCodigo, altNome}", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    public IEnumerable<AlertasResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<AlertasResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<AlertasResponseAll>> ReadLocalAsync()
        {
            var result = new List<AlertasResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBAlertas(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"Alertas".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}altNome");
        }

        return query.ToString();
    }

    public AlertasResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAlertas(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AlertasResponse? Read(Entity.DBAlertas dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public AlertasResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAlertas(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AlertasResponse? Read(Entity.DBAlertas dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var alertas = new AlertasResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Operador = dbRec.FOperador,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            alertas.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FDataAte, out _))
            alertas.DataAte = dbRec.FDataAte;
        return alertas;
    }

    public AlertasResponse? Read(DBAlertas dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var alertas = new AlertasResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Operador = dbRec.FOperador,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            alertas.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FDataAte, out _))
            alertas.DataAte = dbRec.FDataAte;
        return alertas;
    }

    public AlertasResponseAll? ReadAll(DBAlertas dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var alertas = new AlertasResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Operador = dbRec.FOperador,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            alertas.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FDataAte, out _))
            alertas.DataAte = dbRec.FDataAte;
        alertas.NomeOperador = dr["operNome"]?.ToString() ?? string.Empty;
        return alertas;
    }

    public AlertasResponseAll? ReadAll(DBAlertas dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var alertas = new AlertasResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Operador = dbRec.FOperador,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            alertas.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FDataAte, out _))
            alertas.DataAte = dbRec.FDataAte;
        alertas.NomeOperador = dr["operNome"]?.ToString() ?? string.Empty;
        return alertas;
    }
}