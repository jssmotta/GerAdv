#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IEventoPrazoAgendaWhere
{
    EventoPrazoAgendaResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
}

public partial class EventoPrazoAgenda : IEventoPrazoAgendaWhere
{
    public EventoPrazoAgendaResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBEventoPrazoAgenda(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        var eventoprazoagenda = new EventoPrazoAgendaResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Bold = dbRec.FBold,
        };
        return eventoprazoagenda;
    }
}