#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoModeloDocumentoReader
{
    TipoModeloDocumentoResponse? Read(int id, MsiSqlConnection oCnn);
    TipoModeloDocumentoResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    TipoModeloDocumentoResponse? Read(Entity.DBTipoModeloDocumento dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    TipoModeloDocumentoResponse? Read(DBTipoModeloDocumento dbRec);
    TipoModeloDocumentoResponseAll? ReadAll(DBTipoModeloDocumento dbRec, DataRow dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class TipoModeloDocumento : ITipoModeloDocumentoReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery(cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    static string BuildSqlQuery(string whereClause, string orderClause, int max, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) tpdCodigo, tpdNome FROM {"TipoModeloDocumento".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}tpdNome");
        }

        return query.ToString();
    }

    public TipoModeloDocumentoResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTipoModeloDocumento(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public TipoModeloDocumentoResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTipoModeloDocumento(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public TipoModeloDocumentoResponse? Read(Entity.DBTipoModeloDocumento dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tipomodelodocumento = new TipoModeloDocumentoResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return tipomodelodocumento;
    }

    public TipoModeloDocumentoResponse? Read(DBTipoModeloDocumento dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tipomodelodocumento = new TipoModeloDocumentoResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return tipomodelodocumento;
    }

    public TipoModeloDocumentoResponseAll? ReadAll(DBTipoModeloDocumento dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tipomodelodocumento = new TipoModeloDocumentoResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return tipomodelodocumento;
    }
}