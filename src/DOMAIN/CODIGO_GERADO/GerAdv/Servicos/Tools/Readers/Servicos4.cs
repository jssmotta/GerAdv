#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IServicosReader
{
    ServicosResponse? Read(int id, MsiSqlConnection oCnn);
    ServicosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ServicosResponse? Read(Entity.DBServicos dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ServicosResponse? Read(DBServicos dbRec);
    ServicosResponseAll? ReadAll(DBServicos dbRec, DataRow dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class Servicos : IServicosReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery(cWhere, order), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    static string BuildSqlQuery(string whereClause, string orderClause, int max = 200, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) serCodigo, serDescricao FROM {"Servicos".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}serDescricao");
        }

        return query.ToString();
    }

    public ServicosResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBServicos(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ServicosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBServicos(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ServicosResponse? Read(Entity.DBServicos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var servicos = new ServicosResponse
        {
            Id = dbRec.ID,
            Cobrar = dbRec.FCobrar,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Basico = dbRec.FBasico,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return servicos;
    }

    public ServicosResponse? Read(DBServicos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var servicos = new ServicosResponse
        {
            Id = dbRec.ID,
            Cobrar = dbRec.FCobrar,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Basico = dbRec.FBasico,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return servicos;
    }

    public ServicosResponseAll? ReadAll(DBServicos dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var servicos = new ServicosResponseAll
        {
            Id = dbRec.ID,
            Cobrar = dbRec.FCobrar,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Basico = dbRec.FBasico,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return servicos;
    }
}