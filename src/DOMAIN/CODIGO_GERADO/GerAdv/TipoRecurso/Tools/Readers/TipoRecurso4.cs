#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoRecursoReader
{
    TipoRecursoResponse? Read(int id, MsiSqlConnection oCnn);
    TipoRecursoResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    TipoRecursoResponse? Read(Entity.DBTipoRecurso dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    TipoRecursoResponse? Read(DBTipoRecurso dbRec);
    TipoRecursoResponseAll? ReadAll(DBTipoRecurso dbRec, DataRow dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class TipoRecurso : ITipoRecursoReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery(cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    static string BuildSqlQuery(string whereClause, string orderClause, int max, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) trcCodigo, trcDescricao FROM {"TipoRecurso".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}trcDescricao");
        }

        return query.ToString();
    }

    public TipoRecursoResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTipoRecurso(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public TipoRecursoResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTipoRecurso(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public TipoRecursoResponse? Read(Entity.DBTipoRecurso dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tiporecurso = new TipoRecursoResponse
        {
            Id = dbRec.ID,
            Justica = dbRec.FJustica,
            Area = dbRec.FArea,
            Descricao = dbRec.FDescricao ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return tiporecurso;
    }

    public TipoRecursoResponse? Read(DBTipoRecurso dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tiporecurso = new TipoRecursoResponse
        {
            Id = dbRec.ID,
            Justica = dbRec.FJustica,
            Area = dbRec.FArea,
            Descricao = dbRec.FDescricao ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return tiporecurso;
    }

    public TipoRecursoResponseAll? ReadAll(DBTipoRecurso dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tiporecurso = new TipoRecursoResponseAll
        {
            Id = dbRec.ID,
            Justica = dbRec.FJustica,
            Area = dbRec.FArea,
            Descricao = dbRec.FDescricao ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        tiporecurso.NomeJustica = dr["jusNome"]?.ToString() ?? string.Empty;
        tiporecurso.DescricaoArea = dr["areDescricao"]?.ToString() ?? string.Empty;
        return tiporecurso;
    }
}