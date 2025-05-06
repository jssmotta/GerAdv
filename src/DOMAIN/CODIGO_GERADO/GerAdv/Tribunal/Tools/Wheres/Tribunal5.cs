#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITribunalWhere
{
    TribunalResponse Read(string where, SqlConnection oCnn);
}

public partial class Tribunal : ITribunalWhere
{
    public TribunalResponse Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTribunal(sqlWhere: where, oCnn: oCnn);
        var tribunal = new TribunalResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Area = dbRec.FArea,
            Justica = dbRec.FJustica,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Instancia = dbRec.FInstancia,
            Sigla = dbRec.FSigla ?? string.Empty,
            Web = dbRec.FWeb ?? string.Empty,
            Etiqueta = dbRec.FEtiqueta,
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
        tribunal.Auditor = auditor;
        return tribunal;
    }
}