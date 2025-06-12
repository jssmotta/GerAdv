#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoOrigemSucumbenciaReader
{
    TipoOrigemSucumbenciaResponse? Read(int id, MsiSqlConnection oCnn);
    TipoOrigemSucumbenciaResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    TipoOrigemSucumbenciaResponse? Read(Entity.DBTipoOrigemSucumbencia dbRec);
    TipoOrigemSucumbenciaResponse? Read(DBTipoOrigemSucumbencia dbRec);
    TipoOrigemSucumbenciaResponseAll? ReadAll(DBTipoOrigemSucumbencia dbRec, DataRow dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class TipoOrigemSucumbencia : ITipoOrigemSucumbenciaReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery(cWhere, order), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    static string BuildSqlQuery(string whereClause, string orderClause, int max = 200, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) tosCodigo, tosNome FROM {"TipoOrigemSucumbencia".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}tosNome");
        }

        return query.ToString();
    }

    public TipoOrigemSucumbenciaResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTipoOrigemSucumbencia(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public TipoOrigemSucumbenciaResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTipoOrigemSucumbencia(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public TipoOrigemSucumbenciaResponse? Read(Entity.DBTipoOrigemSucumbencia dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tipoorigemsucumbencia = new TipoOrigemSucumbenciaResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
        };
        return tipoorigemsucumbencia;
    }

    public TipoOrigemSucumbenciaResponse? Read(DBTipoOrigemSucumbencia dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tipoorigemsucumbencia = new TipoOrigemSucumbenciaResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
        };
        return tipoorigemsucumbencia;
    }

    public TipoOrigemSucumbenciaResponseAll? ReadAll(DBTipoOrigemSucumbencia dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tipoorigemsucumbencia = new TipoOrigemSucumbenciaResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
        };
        return tipoorigemsucumbencia;
    }
}