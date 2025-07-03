#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IStatusBiuReader
{
    StatusBiuResponse? Read(int id, MsiSqlConnection oCnn);
    StatusBiuResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    StatusBiuResponse? Read(Entity.DBStatusBiu dbRec);
    StatusBiuResponse? Read(DBStatusBiu dbRec);
    StatusBiuResponseAll? ReadAll(DBStatusBiu dbRec, DataRow dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class StatusBiu : IStatusBiuReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery(cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    static string BuildSqlQuery(string whereClause, string orderClause, int max, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) stbCodigo, stbNome FROM {"StatusBiu".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}stbNome");
        }

        return query.ToString();
    }

    public StatusBiuResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBStatusBiu(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public StatusBiuResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBStatusBiu(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public StatusBiuResponse? Read(Entity.DBStatusBiu dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var statusbiu = new StatusBiuResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            TipoStatusBiu = dbRec.FTipoStatusBiu,
            Operador = dbRec.FOperador,
            Icone = dbRec.FIcone,
        };
        return statusbiu;
    }

    public StatusBiuResponse? Read(DBStatusBiu dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var statusbiu = new StatusBiuResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            TipoStatusBiu = dbRec.FTipoStatusBiu,
            Operador = dbRec.FOperador,
            Icone = dbRec.FIcone,
        };
        return statusbiu;
    }

    public StatusBiuResponseAll? ReadAll(DBStatusBiu dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var statusbiu = new StatusBiuResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            TipoStatusBiu = dbRec.FTipoStatusBiu,
            Operador = dbRec.FOperador,
            Icone = dbRec.FIcone,
        };
        statusbiu.NomeTipoStatusBiu = dr["tsbNome"]?.ToString() ?? string.Empty;
        statusbiu.NomeOperador = dr["operNome"]?.ToString() ?? string.Empty;
        return statusbiu;
    }
}