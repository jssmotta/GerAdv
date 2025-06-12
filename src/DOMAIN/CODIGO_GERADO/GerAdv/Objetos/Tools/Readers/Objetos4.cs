#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IObjetosReader
{
    ObjetosResponse? Read(int id, MsiSqlConnection oCnn);
    ObjetosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ObjetosResponse? Read(Entity.DBObjetos dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ObjetosResponse? Read(DBObjetos dbRec);
    ObjetosResponseAll? ReadAll(DBObjetos dbRec, DataRow dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class Objetos : IObjetosReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery(cWhere, order), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    static string BuildSqlQuery(string whereClause, string orderClause, int max = 200, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) ojtCodigo, ojtNome FROM {"Objetos".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}ojtNome");
        }

        return query.ToString();
    }

    public ObjetosResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBObjetos(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ObjetosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBObjetos(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ObjetosResponse? Read(Entity.DBObjetos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var objetos = new ObjetosResponse
        {
            Id = dbRec.ID,
            Justica = dbRec.FJustica,
            Area = dbRec.FArea,
            Nome = dbRec.FNome ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return objetos;
    }

    public ObjetosResponse? Read(DBObjetos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var objetos = new ObjetosResponse
        {
            Id = dbRec.ID,
            Justica = dbRec.FJustica,
            Area = dbRec.FArea,
            Nome = dbRec.FNome ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return objetos;
    }

    public ObjetosResponseAll? ReadAll(DBObjetos dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var objetos = new ObjetosResponseAll
        {
            Id = dbRec.ID,
            Justica = dbRec.FJustica,
            Area = dbRec.FArea,
            Nome = dbRec.FNome ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        objetos.NomeJustica = dr["jusNome"]?.ToString() ?? string.Empty;
        objetos.DescricaoArea = dr["areDescricao"]?.ToString() ?? string.Empty;
        return objetos;
    }
}