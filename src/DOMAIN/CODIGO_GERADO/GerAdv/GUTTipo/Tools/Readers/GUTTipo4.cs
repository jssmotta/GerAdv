#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IGUTTipoReader
{
    GUTTipoResponse? Read(int id, SqlConnection oCnn);
    GUTTipoResponse? Read(string where, SqlConnection oCnn);
    GUTTipoResponse? Read(Entity.DBGUTTipo dbRec);
    GUTTipoResponse? Read(DBGUTTipo dbRec);
}

public partial class GUTTipo : IGUTTipoReader
{
    public GUTTipoResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBGUTTipo(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public GUTTipoResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBGUTTipo(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public GUTTipoResponse? Read(Entity.DBGUTTipo dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var guttipo = new GUTTipoResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Ordem = dbRec.FOrdem,
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
        guttipo.Auditor = auditor;
        return guttipo;
    }

    public GUTTipoResponse? Read(DBGUTTipo dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var guttipo = new GUTTipoResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Ordem = dbRec.FOrdem,
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
        guttipo.Auditor = auditor;
        return guttipo;
    }
}