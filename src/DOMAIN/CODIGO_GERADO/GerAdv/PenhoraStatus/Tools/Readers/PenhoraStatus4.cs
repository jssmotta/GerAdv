#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IPenhoraStatusReader
{
    PenhoraStatusResponse? Read(int id, MsiSqlConnection oCnn);
    PenhoraStatusResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    PenhoraStatusResponse? Read(Entity.DBPenhoraStatus dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    PenhoraStatusResponse? Read(DBPenhoraStatus dbRec);
    PenhoraStatusResponseAll? ReadAll(DBPenhoraStatus dbRec, DataRow dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class PenhoraStatus : IPenhoraStatusReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery(cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    static string BuildSqlQuery(string whereClause, string orderClause, int max, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) phsCodigo, phsNome FROM {"PenhoraStatus".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}phsNome");
        }

        return query.ToString();
    }

    public PenhoraStatusResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBPenhoraStatus(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public PenhoraStatusResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBPenhoraStatus(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public PenhoraStatusResponse? Read(Entity.DBPenhoraStatus dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var penhorastatus = new PenhoraStatusResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return penhorastatus;
    }

    public PenhoraStatusResponse? Read(DBPenhoraStatus dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var penhorastatus = new PenhoraStatusResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return penhorastatus;
    }

    public PenhoraStatusResponseAll? ReadAll(DBPenhoraStatus dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var penhorastatus = new PenhoraStatusResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return penhorastatus;
    }
}