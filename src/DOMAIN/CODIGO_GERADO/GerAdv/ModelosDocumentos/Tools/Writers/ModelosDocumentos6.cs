#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IModelosDocumentosWriter
{
    Entity.DBModelosDocumentos Write(Models.ModelosDocumentos modelosdocumentos, int auditorQuem, SqlConnection oCnn);
}

public class ModelosDocumentos : IModelosDocumentosWriter
{
    public Entity.DBModelosDocumentos Write(Models.ModelosDocumentos modelosdocumentos, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = modelosdocumentos.Id.IsEmptyIDNumber() ? new Entity.DBModelosDocumentos() : new Entity.DBModelosDocumentos(modelosdocumentos.Id, oCnn);
        dbRec.FNome = modelosdocumentos.Nome;
        dbRec.FRemuneracao = modelosdocumentos.Remuneracao;
        dbRec.FAssinatura = modelosdocumentos.Assinatura;
        dbRec.FHeader = modelosdocumentos.Header;
        dbRec.FFooter = modelosdocumentos.Footer;
        dbRec.FExtra1 = modelosdocumentos.Extra1;
        dbRec.FExtra2 = modelosdocumentos.Extra2;
        dbRec.FExtra3 = modelosdocumentos.Extra3;
        dbRec.FOutorgante = modelosdocumentos.Outorgante;
        dbRec.FOutorgados = modelosdocumentos.Outorgados;
        dbRec.FPoderes = modelosdocumentos.Poderes;
        dbRec.FObjeto = modelosdocumentos.Objeto;
        dbRec.FTitulo = modelosdocumentos.Titulo;
        dbRec.FTestemunhas = modelosdocumentos.Testemunhas;
        dbRec.FTipoModeloDocumento = modelosdocumentos.TipoModeloDocumento;
        dbRec.FCSS = modelosdocumentos.CSS;
        dbRec.FGUID = modelosdocumentos.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}