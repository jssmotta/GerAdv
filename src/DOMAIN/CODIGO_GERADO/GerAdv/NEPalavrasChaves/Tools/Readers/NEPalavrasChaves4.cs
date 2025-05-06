#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface INEPalavrasChavesReader
{
    NEPalavrasChavesResponse? Read(int id, SqlConnection oCnn);
    NEPalavrasChavesResponse? Read(string where, SqlConnection oCnn);
    NEPalavrasChavesResponse? Read(Entity.DBNEPalavrasChaves dbRec);
    Task<string> ReadStringAuditor(int id, string uri, SqlConnection oCnn);
    NEPalavrasChavesResponse? Read(DBNEPalavrasChaves dbRec);
}

public partial class NEPalavrasChaves : INEPalavrasChavesReader
{
    public NEPalavrasChavesResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBNEPalavrasChaves(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public NEPalavrasChavesResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBNEPalavrasChaves(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public NEPalavrasChavesResponse? Read(Entity.DBNEPalavrasChaves dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var nepalavraschaves = new NEPalavrasChavesResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Bold = dbRec.FBold,
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
        nepalavraschaves.Auditor = auditor;
        return nepalavraschaves;
    }

    public NEPalavrasChavesResponse? Read(DBNEPalavrasChaves dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var nepalavraschaves = new NEPalavrasChavesResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Bold = dbRec.FBold,
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
        nepalavraschaves.Auditor = auditor;
        return nepalavraschaves;
    }
}