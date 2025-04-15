#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IRegimeTributacaoWhere
{
    RegimeTributacaoResponse Read(string where, SqlConnection oCnn);
}

public partial class RegimeTributacao : IRegimeTributacaoWhere
{
    public RegimeTributacaoResponse Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBRegimeTributacao(sqlWhere: where, oCnn: oCnn);
        var regimetributacao = new RegimeTributacaoResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
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
        regimetributacao.Auditor = auditor;
        return regimetributacao;
    }
}