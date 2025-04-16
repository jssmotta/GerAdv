#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ICargosReader
{
    CargosResponse? Read(int id, SqlConnection oCnn);
    CargosResponse? Read(string where, SqlConnection oCnn);
    CargosResponse? Read(Entity.DBCargos dbRec);
    CargosResponse? Read(DBCargos dbRec);
}

public partial class Cargos : ICargosReader
{
    public CargosResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBCargos(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public CargosResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBCargos(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public CargosResponse? Read(Entity.DBCargos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var cargos = new CargosResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
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
        cargos.Auditor = auditor;
        return cargos;
    }

    public CargosResponse? Read(DBCargos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var cargos = new CargosResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
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
        cargos.Auditor = auditor;
        return cargos;
    }
}