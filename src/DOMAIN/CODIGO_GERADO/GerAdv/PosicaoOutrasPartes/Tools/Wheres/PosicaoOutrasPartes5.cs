#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IPosicaoOutrasPartesWhere
{
    PosicaoOutrasPartesResponse Read(string where, SqlConnection oCnn);
}

public partial class PosicaoOutrasPartes : IPosicaoOutrasPartesWhere
{
    public PosicaoOutrasPartesResponse Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBPosicaoOutrasPartes(sqlWhere: where, oCnn: oCnn);
        var posicaooutraspartes = new PosicaoOutrasPartesResponse
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
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
        posicaooutraspartes.Auditor = auditor;
        return posicaooutraspartes;
    }
}