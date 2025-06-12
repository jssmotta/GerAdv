#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IModelosDocumentosWhere
{
    ModelosDocumentosResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
}

public partial class ModelosDocumentos : IModelosDocumentosWhere
{
    public ModelosDocumentosResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBModelosDocumentos(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        var modelosdocumentos = new ModelosDocumentosResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Remuneracao = dbRec.FRemuneracao ?? string.Empty,
            Assinatura = dbRec.FAssinatura ?? string.Empty,
            Header = dbRec.FHeader ?? string.Empty,
            Footer = dbRec.FFooter ?? string.Empty,
            Extra1 = dbRec.FExtra1 ?? string.Empty,
            Extra2 = dbRec.FExtra2 ?? string.Empty,
            Extra3 = dbRec.FExtra3 ?? string.Empty,
            Outorgante = dbRec.FOutorgante ?? string.Empty,
            Outorgados = dbRec.FOutorgados ?? string.Empty,
            Poderes = dbRec.FPoderes ?? string.Empty,
            Objeto = dbRec.FObjeto ?? string.Empty,
            Titulo = dbRec.FTitulo ?? string.Empty,
            Testemunhas = dbRec.FTestemunhas ?? string.Empty,
            TipoModeloDocumento = dbRec.FTipoModeloDocumento,
            CSS = dbRec.FCSS ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return modelosdocumentos;
    }
}