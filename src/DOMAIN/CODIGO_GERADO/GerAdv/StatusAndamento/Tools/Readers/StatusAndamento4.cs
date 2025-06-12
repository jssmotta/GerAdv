#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IStatusAndamentoReader
{
    StatusAndamentoResponse? Read(int id, MsiSqlConnection oCnn);
    StatusAndamentoResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    StatusAndamentoResponse? Read(Entity.DBStatusAndamento dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    StatusAndamentoResponse? Read(DBStatusAndamento dbRec);
    StatusAndamentoResponseAll? ReadAll(DBStatusAndamento dbRec, DataRow dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class StatusAndamento : IStatusAndamentoReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery(cWhere, order), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    static string BuildSqlQuery(string whereClause, string orderClause, int max = 200, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) sanCodigo, sanNome FROM {"StatusAndamento".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}sanNome");
        }

        return query.ToString();
    }

    public StatusAndamentoResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBStatusAndamento(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public StatusAndamentoResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBStatusAndamento(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public StatusAndamentoResponse? Read(Entity.DBStatusAndamento dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var statusandamento = new StatusAndamentoResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Icone = dbRec.FIcone,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return statusandamento;
    }

    public StatusAndamentoResponse? Read(DBStatusAndamento dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var statusandamento = new StatusAndamentoResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Icone = dbRec.FIcone,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return statusandamento;
    }

    public StatusAndamentoResponseAll? ReadAll(DBStatusAndamento dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var statusandamento = new StatusAndamentoResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Icone = dbRec.FIcone,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return statusandamento;
    }
}