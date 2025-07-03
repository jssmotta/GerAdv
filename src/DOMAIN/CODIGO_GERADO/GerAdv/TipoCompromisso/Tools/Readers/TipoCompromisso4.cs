#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoCompromissoReader
{
    TipoCompromissoResponse? Read(int id, MsiSqlConnection oCnn);
    TipoCompromissoResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    TipoCompromissoResponse? Read(Entity.DBTipoCompromisso dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    TipoCompromissoResponse? Read(DBTipoCompromisso dbRec);
    TipoCompromissoResponseAll? ReadAll(DBTipoCompromisso dbRec, DataRow dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class TipoCompromisso : ITipoCompromissoReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery(cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    static string BuildSqlQuery(string whereClause, string orderClause, int max, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) tipCodigo, tipDescricao FROM {"TipoCompromisso".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}tipDescricao");
        }

        return query.ToString();
    }

    public TipoCompromissoResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTipoCompromisso(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public TipoCompromissoResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTipoCompromisso(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public TipoCompromissoResponse? Read(Entity.DBTipoCompromisso dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tipocompromisso = new TipoCompromissoResponse
        {
            Id = dbRec.ID,
            Icone = dbRec.FIcone,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Financeiro = dbRec.FFinanceiro,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return tipocompromisso;
    }

    public TipoCompromissoResponse? Read(DBTipoCompromisso dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tipocompromisso = new TipoCompromissoResponse
        {
            Id = dbRec.ID,
            Icone = dbRec.FIcone,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Financeiro = dbRec.FFinanceiro,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return tipocompromisso;
    }

    public TipoCompromissoResponseAll? ReadAll(DBTipoCompromisso dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tipocompromisso = new TipoCompromissoResponseAll
        {
            Id = dbRec.ID,
            Icone = dbRec.FIcone,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Financeiro = dbRec.FFinanceiro,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return tipocompromisso;
    }
}