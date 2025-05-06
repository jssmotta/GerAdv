#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoModeloDocumentoWriter
{
    Entity.DBTipoModeloDocumento Write(Models.TipoModeloDocumento tipomodelodocumento, int auditorQuem, SqlConnection oCnn);
}

public class TipoModeloDocumento : ITipoModeloDocumentoWriter
{
    public Entity.DBTipoModeloDocumento Write(Models.TipoModeloDocumento tipomodelodocumento, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = tipomodelodocumento.Id.IsEmptyIDNumber() ? new Entity.DBTipoModeloDocumento() : new Entity.DBTipoModeloDocumento(tipomodelodocumento.Id, oCnn);
        dbRec.FNome = tipomodelodocumento.Nome;
        dbRec.FGUID = tipomodelodocumento.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}