#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IEMPClassRiscosReader
{
    EMPClassRiscosResponse? Read(int id, SqlConnection oCnn);
    EMPClassRiscosResponse? Read(string where, SqlConnection oCnn);
    EMPClassRiscosResponse? Read(Entity.DBEMPClassRiscos dbRec);
    Task<string> ReadStringAuditor(int id, string uri, SqlConnection oCnn);
    EMPClassRiscosResponse? Read(DBEMPClassRiscos dbRec);
}

public partial class EMPClassRiscos : IEMPClassRiscosReader
{
    public EMPClassRiscosResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBEMPClassRiscos(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public EMPClassRiscosResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBEMPClassRiscos(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public EMPClassRiscosResponse? Read(Entity.DBEMPClassRiscos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var empclassriscos = new EMPClassRiscosResponse
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
        empclassriscos.Auditor = auditor;
        return empclassriscos;
    }

    public EMPClassRiscosResponse? Read(DBEMPClassRiscos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var empclassriscos = new EMPClassRiscosResponse
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
        empclassriscos.Auditor = auditor;
        return empclassriscos;
    }
}