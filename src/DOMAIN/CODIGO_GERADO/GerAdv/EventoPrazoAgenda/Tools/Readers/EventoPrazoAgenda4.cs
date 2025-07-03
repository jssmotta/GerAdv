#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IEventoPrazoAgendaReader
{
    EventoPrazoAgendaResponse? Read(int id, MsiSqlConnection oCnn);
    EventoPrazoAgendaResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    EventoPrazoAgendaResponse? Read(Entity.DBEventoPrazoAgenda dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    EventoPrazoAgendaResponse? Read(DBEventoPrazoAgenda dbRec);
    EventoPrazoAgendaResponseAll? ReadAll(DBEventoPrazoAgenda dbRec, DataRow dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class EventoPrazoAgenda : IEventoPrazoAgendaReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery(cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    static string BuildSqlQuery(string whereClause, string orderClause, int max, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) epaCodigo, epaNome FROM {"EventoPrazoAgenda".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}epaNome");
        }

        return query.ToString();
    }

    public EventoPrazoAgendaResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBEventoPrazoAgenda(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public EventoPrazoAgendaResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBEventoPrazoAgenda(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public EventoPrazoAgendaResponse? Read(Entity.DBEventoPrazoAgenda dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var eventoprazoagenda = new EventoPrazoAgendaResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Bold = dbRec.FBold,
        };
        return eventoprazoagenda;
    }

    public EventoPrazoAgendaResponse? Read(DBEventoPrazoAgenda dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var eventoprazoagenda = new EventoPrazoAgendaResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Bold = dbRec.FBold,
        };
        return eventoprazoagenda;
    }

    public EventoPrazoAgendaResponseAll? ReadAll(DBEventoPrazoAgenda dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var eventoprazoagenda = new EventoPrazoAgendaResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Bold = dbRec.FBold,
        };
        return eventoprazoagenda;
    }
}