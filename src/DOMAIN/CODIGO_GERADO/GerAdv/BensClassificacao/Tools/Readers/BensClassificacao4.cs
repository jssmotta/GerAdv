#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IBensClassificacaoReader
{
    BensClassificacaoResponse? Read(int id, MsiSqlConnection oCnn);
    BensClassificacaoResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    BensClassificacaoResponse? Read(Entity.DBBensClassificacao dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    BensClassificacaoResponse? Read(DBBensClassificacao dbRec);
    BensClassificacaoResponseAll? ReadAll(DBBensClassificacao dbRec, DataRow dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class BensClassificacao : IBensClassificacaoReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery(cWhere, order), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    static string BuildSqlQuery(string whereClause, string orderClause, int max = 200, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) bcsCodigo, bcsNome FROM {"BensClassificacao".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}bcsNome");
        }

        return query.ToString();
    }

    public BensClassificacaoResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBBensClassificacao(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public BensClassificacaoResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBBensClassificacao(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public BensClassificacaoResponse? Read(Entity.DBBensClassificacao dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var bensclassificacao = new BensClassificacaoResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return bensclassificacao;
    }

    public BensClassificacaoResponse? Read(DBBensClassificacao dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var bensclassificacao = new BensClassificacaoResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return bensclassificacao;
    }

    public BensClassificacaoResponseAll? ReadAll(DBBensClassificacao dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var bensclassificacao = new BensClassificacaoResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return bensclassificacao;
    }
}