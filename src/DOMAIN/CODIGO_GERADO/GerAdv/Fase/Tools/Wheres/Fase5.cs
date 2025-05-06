#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IFaseWhere
{
    FaseResponse Read(string where, SqlConnection oCnn);
}

public partial class Fase : IFaseWhere
{
    public FaseResponse Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBFase(sqlWhere: where, oCnn: oCnn);
        var fase = new FaseResponse
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Justica = dbRec.FJustica,
            Area = dbRec.FArea,
            GUID = dbRec.FGUID ?? string.Empty,
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
        fase.Auditor = auditor;
        return fase;
    }
}