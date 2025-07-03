#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface INEPalavrasChavesReader
{
    NEPalavrasChavesResponse? Read(int id, MsiSqlConnection oCnn);
    NEPalavrasChavesResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    NEPalavrasChavesResponse? Read(Entity.DBNEPalavrasChaves dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    NEPalavrasChavesResponse? Read(DBNEPalavrasChaves dbRec);
    NEPalavrasChavesResponseAll? ReadAll(DBNEPalavrasChaves dbRec, DataRow dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class NEPalavrasChaves : INEPalavrasChavesReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery(cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    static string BuildSqlQuery(string whereClause, string orderClause, int max, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) npcCodigo, npcNome FROM {"NEPalavrasChaves".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}npcNome");
        }

        return query.ToString();
    }

    public NEPalavrasChavesResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBNEPalavrasChaves(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public NEPalavrasChavesResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBNEPalavrasChaves(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public NEPalavrasChavesResponse? Read(Entity.DBNEPalavrasChaves dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var nepalavraschaves = new NEPalavrasChavesResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Bold = dbRec.FBold,
        };
        return nepalavraschaves;
    }

    public NEPalavrasChavesResponse? Read(DBNEPalavrasChaves dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var nepalavraschaves = new NEPalavrasChavesResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Bold = dbRec.FBold,
        };
        return nepalavraschaves;
    }

    public NEPalavrasChavesResponseAll? ReadAll(DBNEPalavrasChaves dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var nepalavraschaves = new NEPalavrasChavesResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Bold = dbRec.FBold,
        };
        return nepalavraschaves;
    }
}