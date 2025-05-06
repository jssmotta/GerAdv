#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IParceriaProcReader
{
    ParceriaProcResponse? Read(int id, SqlConnection oCnn);
    ParceriaProcResponse? Read(string where, SqlConnection oCnn);
    ParceriaProcResponse? Read(Entity.DBParceriaProc dbRec);
    Task<string> ReadStringAuditor(int id, string uri, SqlConnection oCnn);
    ParceriaProcResponse? Read(DBParceriaProc dbRec);
}

public partial class ParceriaProc : IParceriaProcReader
{
    public ParceriaProcResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBParceriaProc(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ParceriaProcResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBParceriaProc(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ParceriaProcResponse? Read(Entity.DBParceriaProc dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var parceriaproc = new ParceriaProcResponse
        {
            Id = dbRec.ID,
            Advogado = dbRec.FAdvogado,
            Processo = dbRec.FProcesso,
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
        parceriaproc.Auditor = auditor;
        return parceriaproc;
    }

    public ParceriaProcResponse? Read(DBParceriaProc dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var parceriaproc = new ParceriaProcResponse
        {
            Id = dbRec.ID,
            Advogado = dbRec.FAdvogado,
            Processo = dbRec.FProcesso,
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
        parceriaproc.Auditor = auditor;
        return parceriaproc;
    }
}