#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ICargosEscReader
{
    CargosEscResponse? Read(int id, MsiSqlConnection oCnn);
    CargosEscResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    CargosEscResponse? Read(Entity.DBCargosEsc dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    CargosEscResponse? Read(DBCargosEsc dbRec);
    CargosEscResponseAll? ReadAll(DBCargosEsc dbRec, DataRow dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class CargosEsc : ICargosEscReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery(cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    static string BuildSqlQuery(string whereClause, string orderClause, int max, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) cgeCodigo, cgeNome FROM {"CargosEsc".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}cgeNome");
        }

        return query.ToString();
    }

    public CargosEscResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBCargosEsc(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public CargosEscResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBCargosEsc(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public CargosEscResponse? Read(Entity.DBCargosEsc dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var cargosesc = new CargosEscResponse
        {
            Id = dbRec.ID,
            Percentual = dbRec.FPercentual,
            Nome = dbRec.FNome ?? string.Empty,
            Classificacao = dbRec.FClassificacao,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return cargosesc;
    }

    public CargosEscResponse? Read(DBCargosEsc dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var cargosesc = new CargosEscResponse
        {
            Id = dbRec.ID,
            Percentual = dbRec.FPercentual,
            Nome = dbRec.FNome ?? string.Empty,
            Classificacao = dbRec.FClassificacao,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return cargosesc;
    }

    public CargosEscResponseAll? ReadAll(DBCargosEsc dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var cargosesc = new CargosEscResponseAll
        {
            Id = dbRec.ID,
            Percentual = dbRec.FPercentual,
            Nome = dbRec.FNome ?? string.Empty,
            Classificacao = dbRec.FClassificacao,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return cargosesc;
    }
}