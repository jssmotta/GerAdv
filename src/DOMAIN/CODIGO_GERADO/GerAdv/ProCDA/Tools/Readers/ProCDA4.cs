#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProCDAReader
{
    ProCDAResponse? Read(int id, SqlConnection oCnn);
    ProCDAResponse? Read(string where, SqlConnection oCnn);
    ProCDAResponse? Read(Entity.DBProCDA dbRec);
    Task<string> ReadStringAuditor(int id, string uri, SqlConnection oCnn);
    ProCDAResponse? Read(DBProCDA dbRec);
}

public partial class ProCDA : IProCDAReader
{
    public ProCDAResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProCDA(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProCDAResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProCDA(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProCDAResponse? Read(Entity.DBProCDA dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var procda = new ProCDAResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Nome = dbRec.FNome ?? string.Empty,
            NroInterno = dbRec.FNroInterno ?? string.Empty,
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
        procda.Auditor = auditor;
        return procda;
    }

    public ProCDAResponse? Read(DBProCDA dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var procda = new ProCDAResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Nome = dbRec.FNome ?? string.Empty,
            NroInterno = dbRec.FNroInterno ?? string.Empty,
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
        procda.Auditor = auditor;
        return procda;
    }
}