#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IOperadorGruposReader
{
    OperadorGruposResponse? Read(int id, MsiSqlConnection oCnn);
    OperadorGruposResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    OperadorGruposResponse? Read(Entity.DBOperadorGrupos dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    OperadorGruposResponse? Read(DBOperadorGrupos dbRec);
    OperadorGruposResponseAll? ReadAll(DBOperadorGrupos dbRec, DataRow dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class OperadorGrupos : IOperadorGruposReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery(cWhere, order), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    static string BuildSqlQuery(string whereClause, string orderClause, int max = 200, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) opgCodigo, opgNome FROM {"OperadorGrupos".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}opgNome");
        }

        return query.ToString();
    }

    public OperadorGruposResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBOperadorGrupos(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public OperadorGruposResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBOperadorGrupos(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public OperadorGruposResponse? Read(Entity.DBOperadorGrupos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var operadorgrupos = new OperadorGruposResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
        };
        return operadorgrupos;
    }

    public OperadorGruposResponse? Read(DBOperadorGrupos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var operadorgrupos = new OperadorGruposResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
        };
        return operadorgrupos;
    }

    public OperadorGruposResponseAll? ReadAll(DBOperadorGrupos dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var operadorgrupos = new OperadorGruposResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
        };
        return operadorgrupos;
    }
}