#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IPenhoraWhere
{
    PenhoraResponse Read(string where, SqlConnection oCnn);
}

public partial class Penhora : IPenhoraWhere
{
    public PenhoraResponse Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBPenhora(sqlWhere: where, oCnn: oCnn);
        var penhora = new PenhoraResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Nome = dbRec.FNome ?? string.Empty,
            Descricao = dbRec.FDescricao ?? string.Empty,
            PenhoraStatus = dbRec.FPenhoraStatus,
            Master = dbRec.FMaster,
        };
        if (DateTime.TryParse(dbRec.FDataPenhora, out _))
            penhora.DataPenhora = dbRec.FDataPenhora;
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
        penhora.Auditor = auditor;
        return penhora;
    }
}