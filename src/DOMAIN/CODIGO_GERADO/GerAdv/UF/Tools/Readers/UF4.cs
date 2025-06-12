#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IUFReader
{
    UFResponse? Read(int id, MsiSqlConnection oCnn);
    UFResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    UFResponse? Read(Entity.DBUF dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    UFResponse? Read(DBUF dbRec);
    UFResponseAll? ReadAll(DBUF dbRec, DataRow dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class UF : IUFReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery(cWhere, order), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    static string BuildSqlQuery(string whereClause, string orderClause, int max = 200, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) ufCodigo, ufID FROM {"UF".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}ufID");
        }

        return query.ToString();
    }

    public UFResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBUF(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public UFResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBUF(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public UFResponse? Read(Entity.DBUF dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var uf = new UFResponse
        {
            Id = dbRec.ID,
            DDD = dbRec.FDDD ?? string.Empty,
            IdUF = dbRec.FID ?? string.Empty,
            Pais = dbRec.FPais,
            Top = dbRec.FTop,
            Descricao = dbRec.FDescricao ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return uf;
    }

    public UFResponse? Read(DBUF dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var uf = new UFResponse
        {
            Id = dbRec.ID,
            DDD = dbRec.FDDD ?? string.Empty,
            IdUF = dbRec.FID ?? string.Empty,
            Pais = dbRec.FPais,
            Top = dbRec.FTop,
            Descricao = dbRec.FDescricao ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return uf;
    }

    public UFResponseAll? ReadAll(DBUF dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var uf = new UFResponseAll
        {
            Id = dbRec.ID,
            DDD = dbRec.FDDD ?? string.Empty,
            IdUF = dbRec.FID ?? string.Empty,
            Pais = dbRec.FPais,
            Top = dbRec.FTop,
            Descricao = dbRec.FDescricao ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        uf.NomePaises = dr["paiNome"]?.ToString() ?? string.Empty;
        return uf;
    }
}