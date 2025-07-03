#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IViaRecebimentoReader
{
    ViaRecebimentoResponse? Read(int id, MsiSqlConnection oCnn);
    ViaRecebimentoResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ViaRecebimentoResponse? Read(Entity.DBViaRecebimento dbRec);
    ViaRecebimentoResponse? Read(DBViaRecebimento dbRec);
    ViaRecebimentoResponseAll? ReadAll(DBViaRecebimento dbRec, DataRow dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class ViaRecebimento : IViaRecebimentoReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery(cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    static string BuildSqlQuery(string whereClause, string orderClause, int max, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) vrbCodigo, vrbNome FROM {"ViaRecebimento".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}vrbNome");
        }

        return query.ToString();
    }

    public ViaRecebimentoResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBViaRecebimento(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ViaRecebimentoResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBViaRecebimento(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ViaRecebimentoResponse? Read(Entity.DBViaRecebimento dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var viarecebimento = new ViaRecebimentoResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
        };
        return viarecebimento;
    }

    public ViaRecebimentoResponse? Read(DBViaRecebimento dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var viarecebimento = new ViaRecebimentoResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
        };
        return viarecebimento;
    }

    public ViaRecebimentoResponseAll? ReadAll(DBViaRecebimento dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var viarecebimento = new ViaRecebimentoResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
        };
        return viarecebimento;
    }
}