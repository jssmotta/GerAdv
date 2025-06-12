#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IGUTPeriodicidadeReader
{
    GUTPeriodicidadeResponse? Read(int id, MsiSqlConnection oCnn);
    GUTPeriodicidadeResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    GUTPeriodicidadeResponse? Read(Entity.DBGUTPeriodicidade dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    GUTPeriodicidadeResponse? Read(DBGUTPeriodicidade dbRec);
    GUTPeriodicidadeResponseAll? ReadAll(DBGUTPeriodicidade dbRec, DataRow dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class GUTPeriodicidade : IGUTPeriodicidadeReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery(cWhere, order), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    static string BuildSqlQuery(string whereClause, string orderClause, int max = 200, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) pcgCodigo, pcgNome FROM {"GUTPeriodicidade".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}pcgNome");
        }

        return query.ToString();
    }

    public GUTPeriodicidadeResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBGUTPeriodicidade(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public GUTPeriodicidadeResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBGUTPeriodicidade(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public GUTPeriodicidadeResponse? Read(Entity.DBGUTPeriodicidade dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var gutperiodicidade = new GUTPeriodicidadeResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            IntervaloDias = dbRec.FIntervaloDias,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return gutperiodicidade;
    }

    public GUTPeriodicidadeResponse? Read(DBGUTPeriodicidade dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var gutperiodicidade = new GUTPeriodicidadeResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            IntervaloDias = dbRec.FIntervaloDias,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return gutperiodicidade;
    }

    public GUTPeriodicidadeResponseAll? ReadAll(DBGUTPeriodicidade dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var gutperiodicidade = new GUTPeriodicidadeResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            IntervaloDias = dbRec.FIntervaloDias,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return gutperiodicidade;
    }
}