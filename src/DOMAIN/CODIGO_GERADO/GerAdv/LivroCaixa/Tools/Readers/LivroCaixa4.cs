#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ILivroCaixaReader
{
    LivroCaixaResponse? Read(int id, SqlConnection oCnn);
    LivroCaixaResponse? Read(string where, SqlConnection oCnn);
    LivroCaixaResponse? Read(Entity.DBLivroCaixa dbRec);
    LivroCaixaResponse? Read(DBLivroCaixa dbRec);
}

public partial class LivroCaixa : ILivroCaixaReader
{
    public LivroCaixaResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBLivroCaixa(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public LivroCaixaResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBLivroCaixa(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public LivroCaixaResponse? Read(Entity.DBLivroCaixa dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var livrocaixa = new LivroCaixaResponse
        {
            Id = dbRec.ID,
            IDDes = dbRec.FIDDes,
            Pessoal = dbRec.FPessoal,
            Ajuste = dbRec.FAjuste,
            IDHon = dbRec.FIDHon,
            IDHonParc = dbRec.FIDHonParc,
            IDHonSuc = dbRec.FIDHonSuc,
            Processo = dbRec.FProcesso,
            Valor = dbRec.FValor,
            Tipo = dbRec.FTipo,
            Historico = dbRec.FHistorico ?? string.Empty,
            Grupo = dbRec.FGrupo,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            livrocaixa.Data = dbRec.FData;
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
        livrocaixa.Auditor = auditor;
        return livrocaixa;
    }

    public LivroCaixaResponse? Read(DBLivroCaixa dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var livrocaixa = new LivroCaixaResponse
        {
            Id = dbRec.ID,
            IDDes = dbRec.FIDDes,
            Pessoal = dbRec.FPessoal,
            Ajuste = dbRec.FAjuste,
            IDHon = dbRec.FIDHon,
            IDHonParc = dbRec.FIDHonParc,
            IDHonSuc = dbRec.FIDHonSuc,
            Processo = dbRec.FProcesso,
            Valor = dbRec.FValor,
            Tipo = dbRec.FTipo,
            Historico = dbRec.FHistorico ?? string.Empty,
            Grupo = dbRec.FGrupo,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            livrocaixa.Data = dbRec.FData;
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
        livrocaixa.Auditor = auditor;
        return livrocaixa;
    }
}