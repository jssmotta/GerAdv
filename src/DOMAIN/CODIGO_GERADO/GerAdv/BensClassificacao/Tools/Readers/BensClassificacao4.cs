#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IBensClassificacaoReader
{
    BensClassificacaoResponse? Read(int id, SqlConnection oCnn);
    BensClassificacaoResponse? Read(string where, SqlConnection oCnn);
    BensClassificacaoResponse? Read(Entity.DBBensClassificacao dbRec);
    BensClassificacaoResponse? Read(DBBensClassificacao dbRec);
}

public partial class BensClassificacao : IBensClassificacaoReader
{
    public BensClassificacaoResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBBensClassificacao(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public BensClassificacaoResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBBensClassificacao(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public BensClassificacaoResponse? Read(Entity.DBBensClassificacao dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var bensclassificacao = new BensClassificacaoResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Bold = dbRec.FBold,
            Guid = dbRec.FGUID ?? string.Empty,
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
        bensclassificacao.Auditor = auditor;
        return bensclassificacao;
    }

    public BensClassificacaoResponse? Read(DBBensClassificacao dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var bensclassificacao = new BensClassificacaoResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Bold = dbRec.FBold,
            Guid = dbRec.FGUID ?? string.Empty,
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
        bensclassificacao.Auditor = auditor;
        return bensclassificacao;
    }
}