#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAuditor4KReader
{
    Auditor4KResponse? Read(int id, MsiSqlConnection oCnn);
    Auditor4KResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    Auditor4KResponse? Read(Entity.DBAuditor4K dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    Auditor4KResponse? Read(DBAuditor4K dbRec);
    Auditor4KResponseAll? ReadAll(DBAuditor4K dbRec, DataRow dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class Auditor4K : IAuditor4KReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery(cWhere, order), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    static string BuildSqlQuery(string whereClause, string orderClause, int max = 200, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) audCodigo, audNome FROM {"Auditor4K".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}audNome");
        }

        return query.ToString();
    }

    public Auditor4KResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAuditor4K(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public Auditor4KResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAuditor4K(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public Auditor4KResponse? Read(Entity.DBAuditor4K dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var auditor4k = new Auditor4KResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return auditor4k;
    }

    public Auditor4KResponse? Read(DBAuditor4K dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var auditor4k = new Auditor4KResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return auditor4k;
    }

    public Auditor4KResponseAll? ReadAll(DBAuditor4K dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var auditor4k = new Auditor4KResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return auditor4k;
    }
}