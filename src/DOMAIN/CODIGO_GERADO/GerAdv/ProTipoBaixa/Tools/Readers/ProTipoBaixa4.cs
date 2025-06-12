#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProTipoBaixaReader
{
    ProTipoBaixaResponse? Read(int id, MsiSqlConnection oCnn);
    ProTipoBaixaResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ProTipoBaixaResponse? Read(Entity.DBProTipoBaixa dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ProTipoBaixaResponse? Read(DBProTipoBaixa dbRec);
    ProTipoBaixaResponseAll? ReadAll(DBProTipoBaixa dbRec, DataRow dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class ProTipoBaixa : IProTipoBaixaReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery(cWhere, order), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    static string BuildSqlQuery(string whereClause, string orderClause, int max = 200, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) ptxCodigo, ptxNome FROM {"ProTipoBaixa".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}ptxNome");
        }

        return query.ToString();
    }

    public ProTipoBaixaResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProTipoBaixa(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProTipoBaixaResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProTipoBaixa(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProTipoBaixaResponse? Read(Entity.DBProTipoBaixa dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var protipobaixa = new ProTipoBaixaResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return protipobaixa;
    }

    public ProTipoBaixaResponse? Read(DBProTipoBaixa dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var protipobaixa = new ProTipoBaixaResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return protipobaixa;
    }

    public ProTipoBaixaResponseAll? ReadAll(DBProTipoBaixa dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var protipobaixa = new ProTipoBaixaResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return protipobaixa;
    }
}