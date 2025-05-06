#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProCDAWhere
{
    ProCDAResponse Read(string where, SqlConnection oCnn);
}

public partial class ProCDA : IProCDAWhere
{
    public ProCDAResponse Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProCDA(sqlWhere: where, oCnn: oCnn);
        var procda = new ProCDAResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Nome = dbRec.FNome ?? string.Empty,
            NroInterno = dbRec.FNroInterno ?? string.Empty,
            Bold = dbRec.FBold,
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
        procda.Auditor = auditor;
        return procda;
    }
}