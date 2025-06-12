#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IEMPClassRiscosReader
{
    EMPClassRiscosResponse? Read(int id, MsiSqlConnection oCnn);
    EMPClassRiscosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    EMPClassRiscosResponse? Read(Entity.DBEMPClassRiscos dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    EMPClassRiscosResponse? Read(DBEMPClassRiscos dbRec);
    EMPClassRiscosResponseAll? ReadAll(DBEMPClassRiscos dbRec, DataRow dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class EMPClassRiscos : IEMPClassRiscosReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery(cWhere, order), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    static string BuildSqlQuery(string whereClause, string orderClause, int max = 200, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) ecrCodigo, ecrNome FROM {"EMPClassRiscos".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}ecrNome");
        }

        return query.ToString();
    }

    public EMPClassRiscosResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBEMPClassRiscos(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public EMPClassRiscosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBEMPClassRiscos(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public EMPClassRiscosResponse? Read(Entity.DBEMPClassRiscos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var empclassriscos = new EMPClassRiscosResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return empclassriscos;
    }

    public EMPClassRiscosResponse? Read(DBEMPClassRiscos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var empclassriscos = new EMPClassRiscosResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return empclassriscos;
    }

    public EMPClassRiscosResponseAll? ReadAll(DBEMPClassRiscos dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var empclassriscos = new EMPClassRiscosResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return empclassriscos;
    }
}