#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoStatusBiuReader
{
    TipoStatusBiuResponse? Read(int id, MsiSqlConnection oCnn);
    TipoStatusBiuResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    TipoStatusBiuResponse? Read(Entity.DBTipoStatusBiu dbRec);
    TipoStatusBiuResponse? Read(DBTipoStatusBiu dbRec);
    TipoStatusBiuResponseAll? ReadAll(DBTipoStatusBiu dbRec, DataRow dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class TipoStatusBiu : ITipoStatusBiuReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery(cWhere, order), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    static string BuildSqlQuery(string whereClause, string orderClause, int max = 200, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) tsbCodigo, tsbNome FROM {"TipoStatusBiu".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}tsbNome");
        }

        return query.ToString();
    }

    public TipoStatusBiuResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTipoStatusBiu(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public TipoStatusBiuResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTipoStatusBiu(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public TipoStatusBiuResponse? Read(Entity.DBTipoStatusBiu dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tipostatusbiu = new TipoStatusBiuResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
        };
        return tipostatusbiu;
    }

    public TipoStatusBiuResponse? Read(DBTipoStatusBiu dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tipostatusbiu = new TipoStatusBiuResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
        };
        return tipostatusbiu;
    }

    public TipoStatusBiuResponseAll? ReadAll(DBTipoStatusBiu dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tipostatusbiu = new TipoStatusBiuResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
        };
        return tipostatusbiu;
    }
}