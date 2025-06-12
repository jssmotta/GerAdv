#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoEnderecoReader
{
    TipoEnderecoResponse? Read(int id, MsiSqlConnection oCnn);
    TipoEnderecoResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    TipoEnderecoResponse? Read(Entity.DBTipoEndereco dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    TipoEnderecoResponse? Read(DBTipoEndereco dbRec);
    TipoEnderecoResponseAll? ReadAll(DBTipoEndereco dbRec, DataRow dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class TipoEndereco : ITipoEnderecoReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery(cWhere, order), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    static string BuildSqlQuery(string whereClause, string orderClause, int max = 200, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) tipCodigo, tipDescricao FROM {"TipoEndereco".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}tipDescricao");
        }

        return query.ToString();
    }

    public TipoEnderecoResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTipoEndereco(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public TipoEnderecoResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTipoEndereco(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public TipoEnderecoResponse? Read(Entity.DBTipoEndereco dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tipoendereco = new TipoEnderecoResponse
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return tipoendereco;
    }

    public TipoEnderecoResponse? Read(DBTipoEndereco dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tipoendereco = new TipoEnderecoResponse
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return tipoendereco;
    }

    public TipoEnderecoResponseAll? ReadAll(DBTipoEndereco dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tipoendereco = new TipoEnderecoResponseAll
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return tipoendereco;
    }
}