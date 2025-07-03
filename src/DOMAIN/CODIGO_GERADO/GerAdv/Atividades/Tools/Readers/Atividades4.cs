#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAtividadesReader
{
    AtividadesResponse? Read(int id, MsiSqlConnection oCnn);
    AtividadesResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    AtividadesResponse? Read(Entity.DBAtividades dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    AtividadesResponse? Read(DBAtividades dbRec);
    AtividadesResponseAll? ReadAll(DBAtividades dbRec, DataRow dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class Atividades : IAtividadesReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery(cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    static string BuildSqlQuery(string whereClause, string orderClause, int max, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) atvCodigo, atvDescricao FROM {"Atividades".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}atvDescricao");
        }

        return query.ToString();
    }

    public AtividadesResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAtividades(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AtividadesResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAtividades(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AtividadesResponse? Read(Entity.DBAtividades dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var atividades = new AtividadesResponse
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return atividades;
    }

    public AtividadesResponse? Read(DBAtividades dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var atividades = new AtividadesResponse
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return atividades;
    }

    public AtividadesResponseAll? ReadAll(DBAtividades dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var atividades = new AtividadesResponseAll
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return atividades;
    }
}