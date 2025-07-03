#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IDocsRecebidosItensReader
{
    DocsRecebidosItensResponse? Read(int id, MsiSqlConnection oCnn);
    DocsRecebidosItensResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    DocsRecebidosItensResponse? Read(Entity.DBDocsRecebidosItens dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    DocsRecebidosItensResponse? Read(DBDocsRecebidosItens dbRec);
    DocsRecebidosItensResponseAll? ReadAll(DBDocsRecebidosItens dbRec, DataRow dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class DocsRecebidosItens : IDocsRecebidosItensReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery(cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    static string BuildSqlQuery(string whereClause, string orderClause, int max, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) driCodigo, driNome FROM {"DocsRecebidosItens".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}driNome");
        }

        return query.ToString();
    }

    public DocsRecebidosItensResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBDocsRecebidosItens(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public DocsRecebidosItensResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBDocsRecebidosItens(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public DocsRecebidosItensResponse? Read(Entity.DBDocsRecebidosItens dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var docsrecebidositens = new DocsRecebidosItensResponse
        {
            Id = dbRec.ID,
            ContatoCRM = dbRec.FContatoCRM,
            Nome = dbRec.FNome ?? string.Empty,
            Devolvido = dbRec.FDevolvido,
            SeraDevolvido = dbRec.FSeraDevolvido,
            Observacoes = dbRec.FObservacoes ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return docsrecebidositens;
    }

    public DocsRecebidosItensResponse? Read(DBDocsRecebidosItens dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var docsrecebidositens = new DocsRecebidosItensResponse
        {
            Id = dbRec.ID,
            ContatoCRM = dbRec.FContatoCRM,
            Nome = dbRec.FNome ?? string.Empty,
            Devolvido = dbRec.FDevolvido,
            SeraDevolvido = dbRec.FSeraDevolvido,
            Observacoes = dbRec.FObservacoes ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return docsrecebidositens;
    }

    public DocsRecebidosItensResponseAll? ReadAll(DBDocsRecebidosItens dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var docsrecebidositens = new DocsRecebidosItensResponseAll
        {
            Id = dbRec.ID,
            ContatoCRM = dbRec.FContatoCRM,
            Nome = dbRec.FNome ?? string.Empty,
            Devolvido = dbRec.FDevolvido,
            SeraDevolvido = dbRec.FSeraDevolvido,
            Observacoes = dbRec.FObservacoes ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return docsrecebidositens;
    }
}