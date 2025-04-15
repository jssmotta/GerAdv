#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IJusticaReader
{
    JusticaResponse? Read(int id, SqlConnection oCnn);
    JusticaResponse? Read(string where, SqlConnection oCnn);
    JusticaResponse? Read(Entity.DBJustica dbRec);
    JusticaResponse? Read(DBJustica dbRec);
}

public partial class Justica : IJusticaReader
{
    public JusticaResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBJustica(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public JusticaResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBJustica(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public JusticaResponse? Read(Entity.DBJustica dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var justica = new JusticaResponse
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
        justica.Auditor = auditor;
        return justica;
    }

    public JusticaResponse? Read(DBJustica dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var justica = new JusticaResponse
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
        justica.Auditor = auditor;
        return justica;
    }
}