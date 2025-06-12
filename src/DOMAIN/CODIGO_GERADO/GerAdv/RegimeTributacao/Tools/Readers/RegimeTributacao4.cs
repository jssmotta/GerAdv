#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IRegimeTributacaoReader
{
    RegimeTributacaoResponse? Read(int id, MsiSqlConnection oCnn);
    RegimeTributacaoResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    RegimeTributacaoResponse? Read(Entity.DBRegimeTributacao dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    RegimeTributacaoResponse? Read(DBRegimeTributacao dbRec);
    RegimeTributacaoResponseAll? ReadAll(DBRegimeTributacao dbRec, DataRow dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class RegimeTributacao : IRegimeTributacaoReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery(cWhere, order), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    static string BuildSqlQuery(string whereClause, string orderClause, int max = 200, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) rdtCodigo, rdtNome FROM {"RegimeTributacao".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}rdtNome");
        }

        return query.ToString();
    }

    public RegimeTributacaoResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBRegimeTributacao(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public RegimeTributacaoResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBRegimeTributacao(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public RegimeTributacaoResponse? Read(Entity.DBRegimeTributacao dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var regimetributacao = new RegimeTributacaoResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return regimetributacao;
    }

    public RegimeTributacaoResponse? Read(DBRegimeTributacao dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var regimetributacao = new RegimeTributacaoResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return regimetributacao;
    }

    public RegimeTributacaoResponseAll? ReadAll(DBRegimeTributacao dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var regimetributacao = new RegimeTributacaoResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return regimetributacao;
    }
}