#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoEnderecoSistemaReader
{
    TipoEnderecoSistemaResponse? Read(int id, MsiSqlConnection oCnn);
    TipoEnderecoSistemaResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    TipoEnderecoSistemaResponse? Read(Entity.DBTipoEnderecoSistema dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    TipoEnderecoSistemaResponse? Read(DBTipoEnderecoSistema dbRec);
    TipoEnderecoSistemaResponseAll? ReadAll(DBTipoEnderecoSistema dbRec, DataRow dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class TipoEnderecoSistema : ITipoEnderecoSistemaReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery(cWhere, order), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    static string BuildSqlQuery(string whereClause, string orderClause, int max = 200, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) tesCodigo, tesNome FROM {"TipoEnderecoSistema".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}tesNome");
        }

        return query.ToString();
    }

    public TipoEnderecoSistemaResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTipoEnderecoSistema(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public TipoEnderecoSistemaResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTipoEnderecoSistema(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public TipoEnderecoSistemaResponse? Read(Entity.DBTipoEnderecoSistema dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tipoenderecosistema = new TipoEnderecoSistemaResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return tipoenderecosistema;
    }

    public TipoEnderecoSistemaResponse? Read(DBTipoEnderecoSistema dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tipoenderecosistema = new TipoEnderecoSistemaResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return tipoenderecosistema;
    }

    public TipoEnderecoSistemaResponseAll? ReadAll(DBTipoEnderecoSistema dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tipoenderecosistema = new TipoEnderecoSistemaResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return tipoenderecosistema;
    }
}