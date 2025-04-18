#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IFaseReader
{
    FaseResponse? Read(int id, SqlConnection oCnn);
    FaseResponse? Read(string where, SqlConnection oCnn);
    FaseResponse? Read(Entity.DBFase dbRec);
    Task<string> ReadStringAuditor(int id, string uri, SqlConnection oCnn);
    FaseResponse? Read(DBFase dbRec);
}

public partial class Fase : IFaseReader
{
    public FaseResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBFase(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public FaseResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBFase(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public FaseResponse? Read(Entity.DBFase dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var fase = new FaseResponse
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Justica = dbRec.FJustica,
            Area = dbRec.FArea,
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
        fase.Auditor = auditor;
        return fase;
    }

    public FaseResponse? Read(DBFase dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var fase = new FaseResponse
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Justica = dbRec.FJustica,
            Area = dbRec.FArea,
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
        fase.Auditor = auditor;
        return fase;
    }
}