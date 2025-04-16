#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProObservacoesWhere
{
    ProObservacoesResponse Read(string where, SqlConnection oCnn);
}

public partial class ProObservacoes : IProObservacoesWhere
{
    public ProObservacoesResponse Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProObservacoes(sqlWhere: where, oCnn: oCnn);
        var proobservacoes = new ProObservacoesResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Nome = dbRec.FNome ?? string.Empty,
            Observacoes = dbRec.FObservacoes ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            proobservacoes.Data = dbRec.FData;
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
        proobservacoes.Auditor = auditor;
        return proobservacoes;
    }
}