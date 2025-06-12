#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoModeloDocumentoValidation
{
    Task<string> ValidateReg(Models.TipoModeloDocumento reg, ITipoModeloDocumentoService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, ITipoModeloDocumentoService service, IModelosDocumentosService modelosdocumentosService, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class TipoModeloDocumentoValidation : ITipoModeloDocumentoValidation
{
    public async Task<string> CanDelete(int id, ITipoModeloDocumentoService service, IModelosDocumentosService modelosdocumentosService, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        var modelosdocumentosExists = await modelosdocumentosService.Filter(new Filters.FilterModelosDocumentos { TipoModeloDocumento = id }, uri);
        if (modelosdocumentosExists != null && modelosdocumentosExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Modelos Documentos associados a ele.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.TipoModeloDocumento reg, ITipoModeloDocumentoService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        if (await IsDuplicado(reg, service, uri))
            return $"TipoModeloDocumento '{reg.Nome}' já cadastrado.";
        return string.Empty;
    }

    private async Task<bool> IsDuplicado(Models.TipoModeloDocumento reg, ITipoModeloDocumentoService service, string uri)
    {
        var existingTipoModeloDocumento = (await service.Filter(new Filters.FilterTipoModeloDocumento { Nome = reg.Nome }, uri)).FirstOrDefault(); // TRACK 10042025
        return existingTipoModeloDocumento != null && existingTipoModeloDocumento.Id > 0 && existingTipoModeloDocumento.Id != reg.Id;
    }
}