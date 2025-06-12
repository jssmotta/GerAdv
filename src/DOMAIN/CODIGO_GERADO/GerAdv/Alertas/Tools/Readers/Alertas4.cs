#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAlertasReader
{
    AlertasResponse? Read(int id, MsiSqlConnection oCnn);
    AlertasResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    AlertasResponse? Read(Entity.DBAlertas dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    AlertasResponse? Read(DBAlertas dbRec);
    AlertasResponseAll? ReadAll(DBAlertas dbRec, DataRow dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class Alertas : IAlertasReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery(cWhere, order), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    static string BuildSqlQuery(string whereClause, string orderClause, int max = 200, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) altCodigo, altNome FROM {"Alertas".dbo(oCnn)} (NOLOCK) ");
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
}