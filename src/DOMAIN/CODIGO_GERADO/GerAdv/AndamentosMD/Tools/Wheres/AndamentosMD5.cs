#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAndamentosMDWhere
{
    AndamentosMDResponse Read(string where, SqlConnection oCnn);
}

public partial class AndamentosMD : IAndamentosMDWhere
{
    public AndamentosMDResponse Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAndamentosMD(sqlWhere: where, oCnn: oCnn);
        var andamentosmd = new AndamentosMDResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Processo = dbRec.FProcesso,
            Andamento = dbRec.FAndamento,
            PathFull = dbRec.FPathFull ?? string.Empty,
            UNC = dbRec.FUNC ?? string.Empty,
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
        andamentosmd.Auditor = auditor;
        return andamentosmd;
    }
}