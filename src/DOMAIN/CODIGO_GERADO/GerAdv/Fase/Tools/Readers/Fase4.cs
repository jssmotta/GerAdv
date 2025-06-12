#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IFaseReader
{
    FaseResponse? Read(int id, MsiSqlConnection oCnn);
    FaseResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    FaseResponse? Read(Entity.DBFase dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    FaseResponse? Read(DBFase dbRec);
    FaseResponseAll? ReadAll(DBFase dbRec, DataRow dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class Fase : IFaseReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery(cWhere, order), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    static string BuildSqlQuery(string whereClause, string orderClause, int max = 200, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) fasCodigo, fasDescricao FROM {"Fase".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}fasDescricao");
        }

        return query.ToString();
    }

    public FaseResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBFase(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public FaseResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBFase(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public FaseResponse? Read(Entity.DBFase dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var fase = new FaseResponse
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Justica = dbRec.FJustica,
            Area = dbRec.FArea,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return fase;
    }

    public FaseResponse? Read(DBFase dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var fase = new FaseResponse
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Justica = dbRec.FJustica,
            Area = dbRec.FArea,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return fase;
    }

    public FaseResponseAll? ReadAll(DBFase dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var fase = new FaseResponseAll
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Justica = dbRec.FJustica,
            Area = dbRec.FArea,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        fase.NomeJustica = dr["jusNome"]?.ToString() ?? string.Empty;
        fase.DescricaoArea = dr["areDescricao"]?.ToString() ?? string.Empty;
        return fase;
    }
}