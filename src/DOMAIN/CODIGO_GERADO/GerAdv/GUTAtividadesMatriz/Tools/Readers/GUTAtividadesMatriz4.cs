#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IGUTAtividadesMatrizReader
{
    GUTAtividadesMatrizResponse? Read(int id, SqlConnection oCnn);
    GUTAtividadesMatrizResponse? Read(string where, SqlConnection oCnn);
    GUTAtividadesMatrizResponse? Read(Entity.DBGUTAtividadesMatriz dbRec);
    GUTAtividadesMatrizResponse? Read(DBGUTAtividadesMatriz dbRec);
}

public partial class GUTAtividadesMatriz : IGUTAtividadesMatrizReader
{
    public GUTAtividadesMatrizResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBGUTAtividadesMatriz(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public GUTAtividadesMatrizResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBGUTAtividadesMatriz(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public GUTAtividadesMatrizResponse? Read(Entity.DBGUTAtividadesMatriz dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var gutatividadesmatriz = new GUTAtividadesMatrizResponse
        {
            Id = dbRec.ID,
            GUTMatriz = dbRec.FGUTMatriz,
            GUTAtividade = dbRec.FGUTAtividade,
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
        gutatividadesmatriz.Auditor = auditor;
        return gutatividadesmatriz;
    }

    public GUTAtividadesMatrizResponse? Read(DBGUTAtividadesMatriz dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var gutatividadesmatriz = new GUTAtividadesMatrizResponse
        {
            Id = dbRec.ID,
            GUTMatriz = dbRec.FGUTMatriz,
            GUTAtividade = dbRec.FGUTAtividade,
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
        gutatividadesmatriz.Auditor = auditor;
        return gutatividadesmatriz;
    }
}