#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ICargosEscClassReader
{
    CargosEscClassResponse? Read(int id, SqlConnection oCnn);
    CargosEscClassResponse? Read(string where, SqlConnection oCnn);
    CargosEscClassResponse? Read(Entity.DBCargosEscClass dbRec);
    Task<string> ReadStringAuditor(int id, string uri, SqlConnection oCnn);
    CargosEscClassResponse? Read(DBCargosEscClass dbRec);
}

public partial class CargosEscClass : ICargosEscClassReader
{
    public CargosEscClassResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBCargosEscClass(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public CargosEscClassResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBCargosEscClass(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public CargosEscClassResponse? Read(Entity.DBCargosEscClass dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var cargosescclass = new CargosEscClassResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
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
        cargosescclass.Auditor = auditor;
        return cargosescclass;
    }

    public CargosEscClassResponse? Read(DBCargosEscClass dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var cargosescclass = new CargosEscClassResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
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
        cargosescclass.Auditor = auditor;
        return cargosescclass;
    }
}