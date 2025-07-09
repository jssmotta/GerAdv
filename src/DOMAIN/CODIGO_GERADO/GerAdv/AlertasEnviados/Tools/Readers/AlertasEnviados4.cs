#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAlertasEnviadosReader
{
    AlertasEnviadosResponse? Read(int id, MsiSqlConnection oCnn);
    AlertasEnviadosResponse? Read(Entity.DBAlertasEnviados dbRec, MsiSqlConnection oCnn);
    AlertasEnviadosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    AlertasEnviadosResponse? Read(Entity.DBAlertasEnviados dbRec);
    AlertasEnviadosResponse? Read(DBAlertasEnviados dbRec);
    AlertasEnviadosResponseAll? ReadAll(DBAlertasEnviados dbRec, DataRow dr);
    AlertasEnviadosResponseAll? ReadAll(DBAlertasEnviados dbRec, SqlDataReader dr);
    IEnumerable<AlertasEnviadosResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class AlertasEnviados : IAlertasEnviadosReader
{
    public IEnumerable<AlertasEnviadosResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<AlertasEnviadosResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<AlertasEnviadosResponseAll>> ReadLocalAsync()
        {
            var result = new List<AlertasEnviadosResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBAlertasEnviados(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"AlertasEnviados".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}");
        }

        return query.ToString();
    }

    public AlertasEnviadosResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAlertasEnviados(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AlertasEnviadosResponse? Read(Entity.DBAlertasEnviados dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public AlertasEnviadosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAlertasEnviados(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AlertasEnviadosResponse? Read(Entity.DBAlertasEnviados dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var alertasenviados = new AlertasEnviadosResponse
        {
            Id = dbRec.ID,
            Operador = dbRec.FOperador,
            Alerta = dbRec.FAlerta,
            Visualizado = dbRec.FVisualizado,
        };
        if (DateTime.TryParse(dbRec.FDataAlertado, out _))
            alertasenviados.DataAlertado = dbRec.FDataAlertado;
        return alertasenviados;
    }

    public AlertasEnviadosResponse? Read(DBAlertasEnviados dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var alertasenviados = new AlertasEnviadosResponse
        {
            Id = dbRec.ID,
            Operador = dbRec.FOperador,
            Alerta = dbRec.FAlerta,
            Visualizado = dbRec.FVisualizado,
        };
        if (DateTime.TryParse(dbRec.FDataAlertado, out _))
            alertasenviados.DataAlertado = dbRec.FDataAlertado;
        return alertasenviados;
    }

    public AlertasEnviadosResponseAll? ReadAll(DBAlertasEnviados dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var alertasenviados = new AlertasEnviadosResponseAll
        {
            Id = dbRec.ID,
            Operador = dbRec.FOperador,
            Alerta = dbRec.FAlerta,
            Visualizado = dbRec.FVisualizado,
        };
        if (DateTime.TryParse(dbRec.FDataAlertado, out _))
            alertasenviados.DataAlertado = dbRec.FDataAlertado;
        alertasenviados.NomeOperador = dr["operNome"]?.ToString() ?? string.Empty;
        alertasenviados.NomeAlertas = dr["altNome"]?.ToString() ?? string.Empty;
        return alertasenviados;
    }

    public AlertasEnviadosResponseAll? ReadAll(DBAlertasEnviados dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var alertasenviados = new AlertasEnviadosResponseAll
        {
            Id = dbRec.ID,
            Operador = dbRec.FOperador,
            Alerta = dbRec.FAlerta,
            Visualizado = dbRec.FVisualizado,
        };
        if (DateTime.TryParse(dbRec.FDataAlertado, out _))
            alertasenviados.DataAlertado = dbRec.FDataAlertado;
        alertasenviados.NomeOperador = dr["operNome"]?.ToString() ?? string.Empty;
        alertasenviados.NomeAlertas = dr["altNome"]?.ToString() ?? string.Empty;
        return alertasenviados;
    }
}