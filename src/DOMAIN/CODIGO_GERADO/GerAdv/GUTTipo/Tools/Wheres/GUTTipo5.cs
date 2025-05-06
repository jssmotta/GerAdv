#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IGUTTipoWhere
{
    GUTTipoResponse Read(string where, SqlConnection oCnn);
}

public partial class GUTTipo : IGUTTipoWhere
{
    public GUTTipoResponse Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBGUTTipo(sqlWhere: where, oCnn: oCnn);
        var guttipo = new GUTTipoResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Ordem = dbRec.FOrdem,
            GUID = dbRec.FGUID ?? string.Empty,
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