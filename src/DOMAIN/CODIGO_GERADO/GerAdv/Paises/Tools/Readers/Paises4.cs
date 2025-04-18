#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IPaisesReader
{
    PaisesResponse? Read(int id, SqlConnection oCnn);
    PaisesResponse? Read(string where, SqlConnection oCnn);
    PaisesResponse? Read(Entity.DBPaises dbRec);
    Task<string> ReadStringAuditor(int id, string uri, SqlConnection oCnn);
    PaisesResponse? Read(DBPaises dbRec);
}

public partial class Paises : IPaisesReader
{
    public PaisesResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBPaises(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public PaisesResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBPaises(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public PaisesResponse? Read(Entity.DBPaises dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var paises = new PaisesResponse
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
        paises.Auditor = auditor;
        return paises;
    }

    public PaisesResponse? Read(DBPaises dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var paises = new PaisesResponse
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
        paises.Auditor = auditor;
        return paises;
    }
}