#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IRamalReader
{
    RamalResponse? Read(int id, SqlConnection oCnn);
    RamalResponse? Read(string where, SqlConnection oCnn);
    RamalResponse? Read(Entity.DBRamal dbRec);
    RamalResponse? Read(DBRamal dbRec);
}

public partial class Ramal : IRamalReader
{
    public RamalResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBRamal(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public RamalResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBRamal(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public RamalResponse? Read(Entity.DBRamal dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var ramal = new RamalResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Obs = dbRec.FObs ?? string.Empty,
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
        ramal.Auditor = auditor;
        return ramal;
    }

    public RamalResponse? Read(DBRamal dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var ramal = new RamalResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Obs = dbRec.FObs ?? string.Empty,
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
        ramal.Auditor = auditor;
        return ramal;
    }
}