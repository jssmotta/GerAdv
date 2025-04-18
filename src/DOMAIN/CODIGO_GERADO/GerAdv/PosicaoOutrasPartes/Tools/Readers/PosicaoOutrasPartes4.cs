#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IPosicaoOutrasPartesReader
{
    PosicaoOutrasPartesResponse? Read(int id, SqlConnection oCnn);
    PosicaoOutrasPartesResponse? Read(string where, SqlConnection oCnn);
    PosicaoOutrasPartesResponse? Read(Entity.DBPosicaoOutrasPartes dbRec);
    Task<string> ReadStringAuditor(int id, string uri, SqlConnection oCnn);
    PosicaoOutrasPartesResponse? Read(DBPosicaoOutrasPartes dbRec);
}

public partial class PosicaoOutrasPartes : IPosicaoOutrasPartesReader
{
    public PosicaoOutrasPartesResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBPosicaoOutrasPartes(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public PosicaoOutrasPartesResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBPosicaoOutrasPartes(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public PosicaoOutrasPartesResponse? Read(Entity.DBPosicaoOutrasPartes dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var posicaooutraspartes = new PosicaoOutrasPartesResponse
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
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
        posicaooutraspartes.Auditor = auditor;
        return posicaooutraspartes;
    }

    public PosicaoOutrasPartesResponse? Read(DBPosicaoOutrasPartes dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var posicaooutraspartes = new PosicaoOutrasPartesResponse
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
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
        posicaooutraspartes.Auditor = auditor;
        return posicaooutraspartes;
    }
}