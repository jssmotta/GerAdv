#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ICargosEscClassReader
{
    CargosEscClassResponse? Read(int id, MsiSqlConnection oCnn);
    CargosEscClassResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    CargosEscClassResponse? Read(Entity.DBCargosEscClass dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    CargosEscClassResponse? Read(DBCargosEscClass dbRec);
    CargosEscClassResponseAll? ReadAll(DBCargosEscClass dbRec, DataRow dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class CargosEscClass : ICargosEscClassReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery(cWhere, order), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    static string BuildSqlQuery(string whereClause, string orderClause, int max = 200, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) cecCodigo, cecNome FROM {"CargosEscClass".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}cecNome");
        }

        return query.ToString();
    }

    public CargosEscClassResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBCargosEscClass(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public CargosEscClassResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBCargosEscClass(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public CargosEscClassResponse? Read(Entity.DBCargosEscClass dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var cargosescclass = new CargosEscClassResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return cargosescclass;
    }

    public CargosEscClassResponse? Read(DBCargosEscClass dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var cargosescclass = new CargosEscClassResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return cargosescclass;
    }

    public CargosEscClassResponseAll? ReadAll(DBCargosEscClass dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var cargosescclass = new CargosEscClassResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return cargosescclass;
    }
}