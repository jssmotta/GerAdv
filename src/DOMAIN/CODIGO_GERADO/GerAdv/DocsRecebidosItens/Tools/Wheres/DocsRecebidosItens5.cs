#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IDocsRecebidosItensWhere
{
    DocsRecebidosItensResponse Read(string where, SqlConnection oCnn);
}

public partial class DocsRecebidosItens : IDocsRecebidosItensWhere
{
    public DocsRecebidosItensResponse Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBDocsRecebidosItens(sqlWhere: where, oCnn: oCnn);
        var docsrecebidositens = new DocsRecebidosItensResponse
        {
            Id = dbRec.ID,
            ContatoCRM = dbRec.FContatoCRM,
            Nome = dbRec.FNome ?? string.Empty,
            Devolvido = dbRec.FDevolvido,
            SeraDevolvido = dbRec.FSeraDevolvido,
            Observacoes = dbRec.FObservacoes ?? string.Empty,
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
        docsrecebidositens.Auditor = auditor;
        return docsrecebidositens;
    }
}