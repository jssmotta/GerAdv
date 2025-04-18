#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ISituacaoReader
{
    SituacaoResponse? Read(int id, SqlConnection oCnn);
    SituacaoResponse? Read(string where, SqlConnection oCnn);
    SituacaoResponse? Read(Entity.DBSituacao dbRec);
    Task<string> ReadStringAuditor(int id, string uri, SqlConnection oCnn);
    SituacaoResponse? Read(DBSituacao dbRec);
}

public partial class Situacao : ISituacaoReader
{
    public SituacaoResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBSituacao(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public SituacaoResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBSituacao(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public SituacaoResponse? Read(Entity.DBSituacao dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var situacao = new SituacaoResponse
        {
            Id = dbRec.ID,
            Parte_Int = dbRec.FParte_Int ?? string.Empty,
            Parte_Opo = dbRec.FParte_Opo ?? string.Empty,
            Top = dbRec.FTop,
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
        situacao.Auditor = auditor;
        return situacao;
    }

    public SituacaoResponse? Read(DBSituacao dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var situacao = new SituacaoResponse
        {
            Id = dbRec.ID,
            Parte_Int = dbRec.FParte_Int ?? string.Empty,
            Parte_Opo = dbRec.FParte_Opo ?? string.Empty,
            Top = dbRec.FTop,
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
        situacao.Auditor = auditor;
        return situacao;
    }
}