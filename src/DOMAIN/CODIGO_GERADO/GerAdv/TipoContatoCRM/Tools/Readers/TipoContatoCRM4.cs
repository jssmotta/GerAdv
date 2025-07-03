#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoContatoCRMReader
{
    TipoContatoCRMResponse? Read(int id, MsiSqlConnection oCnn);
    TipoContatoCRMResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    TipoContatoCRMResponse? Read(Entity.DBTipoContatoCRM dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    TipoContatoCRMResponse? Read(DBTipoContatoCRM dbRec);
    TipoContatoCRMResponseAll? ReadAll(DBTipoContatoCRM dbRec, DataRow dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class TipoContatoCRM : ITipoContatoCRMReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery(cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    static string BuildSqlQuery(string whereClause, string orderClause, int max, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) tccCodigo, tccNome FROM {"TipoContatoCRM".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}tccNome");
        }

        return query.ToString();
    }

    public TipoContatoCRMResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTipoContatoCRM(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public TipoContatoCRMResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTipoContatoCRM(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public TipoContatoCRMResponse? Read(Entity.DBTipoContatoCRM dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tipocontatocrm = new TipoContatoCRMResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return tipocontatocrm;
    }

    public TipoContatoCRMResponse? Read(DBTipoContatoCRM dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tipocontatocrm = new TipoContatoCRMResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return tipocontatocrm;
    }

    public TipoContatoCRMResponseAll? ReadAll(DBTipoContatoCRM dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tipocontatocrm = new TipoContatoCRMResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return tipocontatocrm;
    }
}