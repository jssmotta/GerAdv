#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IDocumentosWriter
{
    Entity.DBDocumentos Write(Models.Documentos documentos, int auditorQuem, SqlConnection oCnn);
}

public class Documentos : IDocumentosWriter
{
    public Entity.DBDocumentos Write(Models.Documentos documentos, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = documentos.Id.IsEmptyIDNumber() ? new Entity.DBDocumentos() : new Entity.DBDocumentos(documentos.Id, oCnn);
        dbRec.FProcesso = documentos.Processo;
        if (documentos.Data != null)
            dbRec.FData = documentos.Data.ToString();
        dbRec.FObservacao = documentos.Observacao;
        dbRec.FGUID = documentos.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}