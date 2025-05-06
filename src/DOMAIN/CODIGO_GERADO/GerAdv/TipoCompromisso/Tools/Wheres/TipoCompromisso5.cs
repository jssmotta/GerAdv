#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoCompromissoWhere
{
    TipoCompromissoResponse Read(string where, SqlConnection oCnn);
}

public partial class TipoCompromisso : ITipoCompromissoWhere
{
    public TipoCompromissoResponse Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTipoCompromisso(sqlWhere: where, oCnn: oCnn);
        var tipocompromisso = new TipoCompromissoResponse
        {
            Id = dbRec.ID,
            Icone = dbRec.FIcone,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Financeiro = dbRec.FFinanceiro,
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
        tipocompromisso.Auditor = auditor;
        return tipocompromisso;
    }
}