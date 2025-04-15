#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IApenso2Reader
{
    Apenso2Response? Read(int id, SqlConnection oCnn);
    Apenso2Response? Read(string where, SqlConnection oCnn);
    Apenso2Response? Read(Entity.DBApenso2 dbRec);
    Apenso2Response? Read(DBApenso2 dbRec);
}

public partial class Apenso2 : IApenso2Reader
{
    public Apenso2Response? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBApenso2(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public Apenso2Response? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBApenso2(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public Apenso2Response? Read(Entity.DBApenso2 dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var apenso2 = new Apenso2Response
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Apensado = dbRec.FApensado,
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
        apenso2.Auditor = auditor;
        return apenso2;
    }

    public Apenso2Response? Read(DBApenso2 dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var apenso2 = new Apenso2Response
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Apensado = dbRec.FApensado,
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
        apenso2.Auditor = auditor;
        return apenso2;
    }
}