#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IModelosDocumentosValidation
{
    Task<string> ValidateReg(Models.ModelosDocumentos reg, IModelosDocumentosService service, ITipoModeloDocumentoReader tipomodelodocumentoReader, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class ModelosDocumentosValidation : IModelosDocumentosValidation
{
    public async Task<string> ValidateReg(Models.ModelosDocumentos reg, IModelosDocumentosService service, ITipoModeloDocumentoReader tipomodelodocumentoReader, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        if (await IsDuplicado(reg, service, uri))
            return $"ModelosDocumentos '{reg.Nome}' já cadastrado.";
        // TipoModeloDocumento
        if (!reg.TipoModeloDocumento.IsEmptyIDNumber())
        {
            var regTipoModeloDocumento = tipomodelodocumentoReader.Read(reg.TipoModeloDocumento, oCnn);
            if (regTipoModeloDocumento == null || regTipoModeloDocumento.Id != reg.TipoModeloDocumento)
            {
                return $"Tipo Modelo Documento não encontrado ({regTipoModeloDocumento?.Id}).";
            }
        }

        return string.Empty;
    }

    private async Task<bool> IsDuplicado(Models.ModelosDocumentos reg, IModelosDocumentosService service, string uri)
    {
        var existingModelosDocumentos = (await service.Filter(new Filters.FilterModelosDocumentos { Nome = reg.Nome }, uri)).FirstOrDefault(); // TRACK 10042025
        return existingModelosDocumentos != null && existingModelosDocumentos.Id > 0 && existingModelosDocumentos.Id != reg.Id;
    }
}