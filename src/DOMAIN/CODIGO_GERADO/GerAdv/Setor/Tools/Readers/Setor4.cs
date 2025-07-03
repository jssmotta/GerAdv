#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ISetorReader
{
    SetorResponse? Read(int id, MsiSqlConnection oCnn);
    SetorResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    SetorResponse? Read(Entity.DBSetor dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    SetorResponse? Read(DBSetor dbRec);
    SetorResponseAll? ReadAll(DBSetor dbRec, DataRow dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class Setor : ISetorReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery(cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    static string BuildSqlQuery(string whereClause, string orderClause, int max, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) setCodigo, setDescricao FROM {"Setor".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}setDescricao");
        }

        return query.ToString();
    }

    public SetorResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBSetor(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public SetorResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBSetor(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public SetorResponse? Read(Entity.DBSetor dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var setor = new SetorResponse
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return setor;
    }

    public SetorResponse? Read(DBSetor dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var setor = new SetorResponse
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return setor;
    }

    public SetorResponseAll? ReadAll(DBSetor dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var setor = new SetorResponseAll
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return setor;
    }
}