#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IEventoPrazoAgendaWhere
{
    EventoPrazoAgendaResponse Read(string where, SqlConnection oCnn);
}

public partial class EventoPrazoAgenda : IEventoPrazoAgendaWhere
{
    public EventoPrazoAgendaResponse Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBEventoPrazoAgenda(sqlWhere: where, oCnn: oCnn);
        var eventoprazoagenda = new EventoPrazoAgendaResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Bold = dbRec.FBold,
        };
        var auditor = new Auditor
        {
            Visto = dbRec.FVisto,
            QuemCad = dbRec.FQuemCad
        };
        if (auditor.QuemAtu > 0)
            auditor.QuemAtu = dbRec.FQuemAtu;
        if (dbRec.FDtCad.NotIsEmpty())
            auditor.DtCad = Convert.ToDateTime(dbRec.FDtCad);
        if (!(dbRec.FDtAtu is { }))
            auditor.DtAtu = Convert.ToDateTime(dbRec.FDtAtu);
        eventoprazoagenda.Auditor = auditor;
        return eventoprazoagenda;
    }
}