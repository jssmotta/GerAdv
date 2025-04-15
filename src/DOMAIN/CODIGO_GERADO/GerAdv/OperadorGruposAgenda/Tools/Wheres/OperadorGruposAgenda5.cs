#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IOperadorGruposAgendaWhere
{
    OperadorGruposAgendaResponse Read(string where, SqlConnection oCnn);
}

public partial class OperadorGruposAgenda : IOperadorGruposAgendaWhere
{
    public OperadorGruposAgendaResponse Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBOperadorGruposAgenda(sqlWhere: where, oCnn: oCnn);
        var operadorgruposagenda = new OperadorGruposAgendaResponse
        {
            Id = dbRec.ID,
            SQLWhere = dbRec.FSQLWhere ?? string.Empty,
            Nome = dbRec.FNome ?? string.Empty,
            Operador = dbRec.FOperador,
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
        operadorgruposagenda.Auditor = auditor;
        return operadorgruposagenda;
    }
}