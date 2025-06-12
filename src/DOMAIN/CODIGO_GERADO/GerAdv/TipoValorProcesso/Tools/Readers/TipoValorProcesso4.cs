#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoValorProcessoReader
{
    TipoValorProcessoResponse? Read(int id, MsiSqlConnection oCnn);
    TipoValorProcessoResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    TipoValorProcessoResponse? Read(Entity.DBTipoValorProcesso dbRec);
    TipoValorProcessoResponse? Read(DBTipoValorProcesso dbRec);
    TipoValorProcessoResponseAll? ReadAll(DBTipoValorProcesso dbRec, DataRow dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class TipoValorProcesso : ITipoValorProcessoReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery(cWhere, order), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    static string BuildSqlQuery(string whereClause, string orderClause, int max = 200, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) ptvCodigo, ptvDescricao FROM {"TipoValorProcesso".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}ptvDescricao");
        }

        return query.ToString();
    }

    public TipoValorProcessoResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTipoValorProcesso(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public TipoValorProcessoResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTipoValorProcesso(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public TipoValorProcessoResponse? Read(Entity.DBTipoValorProcesso dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tipovalorprocesso = new TipoValorProcessoResponse
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return tipovalorprocesso;
    }

    public TipoValorProcessoResponse? Read(DBTipoValorProcesso dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tipovalorprocesso = new TipoValorProcessoResponse
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return tipovalorprocesso;
    }

    public TipoValorProcessoResponseAll? ReadAll(DBTipoValorProcesso dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tipovalorprocesso = new TipoValorProcessoResponseAll
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return tipovalorprocesso;
    }
}