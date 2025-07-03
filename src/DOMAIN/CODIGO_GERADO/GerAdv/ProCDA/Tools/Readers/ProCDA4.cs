#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProCDAReader
{
    ProCDAResponse? Read(int id, MsiSqlConnection oCnn);
    ProCDAResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ProCDAResponse? Read(Entity.DBProCDA dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ProCDAResponse? Read(DBProCDA dbRec);
    ProCDAResponseAll? ReadAll(DBProCDA dbRec, DataRow dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class ProCDA : IProCDAReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery(cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    static string BuildSqlQuery(string whereClause, string orderClause, int max, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) pcdCodigo, pcdNome FROM {"ProCDA".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}pcdNome");
        }

        return query.ToString();
    }

    public ProCDAResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProCDA(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProCDAResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProCDA(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProCDAResponse? Read(Entity.DBProCDA dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var procda = new ProCDAResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Nome = dbRec.FNome ?? string.Empty,
            NroInterno = dbRec.FNroInterno ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return procda;
    }

    public ProCDAResponse? Read(DBProCDA dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var procda = new ProCDAResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Nome = dbRec.FNome ?? string.Empty,
            NroInterno = dbRec.FNroInterno ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return procda;
    }

    public ProCDAResponseAll? ReadAll(DBProCDA dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var procda = new ProCDAResponseAll
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Nome = dbRec.FNome ?? string.Empty,
            NroInterno = dbRec.FNroInterno ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        procda.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        return procda;
    }
}