#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoModeloDocumentoWhere
{
    TipoModeloDocumentoResponse Read(string where, SqlConnection oCnn);
}

public partial class TipoModeloDocumento : ITipoModeloDocumentoWhere
{
    public TipoModeloDocumentoResponse Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTipoModeloDocumento(sqlWhere: where, oCnn: oCnn);
        var tipomodelodocumento = new TipoModeloDocumentoResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
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
        tipomodelodocumento.Auditor = auditor;
        return tipomodelodocumento;
    }
}