#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IObjetosReader
{
    ObjetosResponse? Read(int id, SqlConnection oCnn);
    ObjetosResponse? Read(string where, SqlConnection oCnn);
    ObjetosResponse? Read(Entity.DBObjetos dbRec);
    Task<string> ReadStringAuditor(int id, string uri, SqlConnection oCnn);
    ObjetosResponse? Read(DBObjetos dbRec);
}

public partial class Objetos : IObjetosReader
{
    public ObjetosResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBObjetos(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ObjetosResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBObjetos(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ObjetosResponse? Read(Entity.DBObjetos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var objetos = new ObjetosResponse
        {
            Id = dbRec.ID,
            Justica = dbRec.FJustica,
            Area = dbRec.FArea,
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
        objetos.Auditor = auditor;
        return objetos;
    }

    public ObjetosResponse? Read(DBObjetos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var objetos = new ObjetosResponse
        {
            Id = dbRec.ID,
            Justica = dbRec.FJustica,
            Area = dbRec.FArea,
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
        objetos.Auditor = auditor;
        return objetos;
    }
}