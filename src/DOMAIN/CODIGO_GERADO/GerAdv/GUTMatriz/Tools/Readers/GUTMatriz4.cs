#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IGUTMatrizReader
{
    GUTMatrizResponse? Read(int id, MsiSqlConnection oCnn);
    GUTMatrizResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    GUTMatrizResponse? Read(Entity.DBGUTMatriz dbRec);
    GUTMatrizResponse? Read(DBGUTMatriz dbRec);
    GUTMatrizResponseAll? ReadAll(DBGUTMatriz dbRec, DataRow dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class GUTMatriz : IGUTMatrizReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery(cWhere, order), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    static string BuildSqlQuery(string whereClause, string orderClause, int max = 200, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) gutCodigo, gutDescricao FROM {"GUTMatriz".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}gutDescricao");
        }

        return query.ToString();
    }

    public GUTMatrizResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBGUTMatriz(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public GUTMatrizResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBGUTMatriz(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public GUTMatrizResponse? Read(Entity.DBGUTMatriz dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var gutmatriz = new GUTMatrizResponse
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
            GUTTipo = dbRec.FGUTTipo,
            Valor = dbRec.FValor,
        };
        return gutmatriz;
    }

    public GUTMatrizResponse? Read(DBGUTMatriz dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var gutmatriz = new GUTMatrizResponse
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
            GUTTipo = dbRec.FGUTTipo,
            Valor = dbRec.FValor,
        };
        return gutmatriz;
    }

    public GUTMatrizResponseAll? ReadAll(DBGUTMatriz dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var gutmatriz = new GUTMatrizResponseAll
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
            GUTTipo = dbRec.FGUTTipo,
            Valor = dbRec.FValor,
        };
        gutmatriz.NomeGUTTipo = dr["gttNome"]?.ToString() ?? string.Empty;
        return gutmatriz;
    }
}