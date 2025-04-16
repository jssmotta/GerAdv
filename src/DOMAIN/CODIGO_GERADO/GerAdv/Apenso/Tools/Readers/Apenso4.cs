#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IApensoReader
{
    ApensoResponse? Read(int id, SqlConnection oCnn);
    ApensoResponse? Read(string where, SqlConnection oCnn);
    ApensoResponse? Read(Entity.DBApenso dbRec);
    ApensoResponse? Read(DBApenso dbRec);
}

public partial class Apenso : IApensoReader
{
    public ApensoResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBApenso(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ApensoResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBApenso(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ApensoResponse? Read(Entity.DBApenso dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var apenso = new ApensoResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            ApensoX = dbRec.FApenso ?? string.Empty,
            Acao = dbRec.FAcao ?? string.Empty,
            OBS = dbRec.FOBS ?? string.Empty,
            ValorCausa = dbRec.FValorCausa,
        };
        if (DateTime.TryParse(dbRec.FDtDist, out _))
            apenso.DtDist = dbRec.FDtDist;
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
        apenso.Auditor = auditor;
        return apenso;
    }

    public ApensoResponse? Read(DBApenso dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var apenso = new ApensoResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            ApensoX = dbRec.FApenso ?? string.Empty,
            Acao = dbRec.FAcao ?? string.Empty,
            OBS = dbRec.FOBS ?? string.Empty,
            ValorCausa = dbRec.FValorCausa,
        };
        if (DateTime.TryParse(dbRec.FDtDist, out _))
            apenso.DtDist = dbRec.FDtDist;
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
        apenso.Auditor = auditor;
        return apenso;
    }
}