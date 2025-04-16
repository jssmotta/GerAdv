#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoModeloDocumentoValidation
{
    Task<string> ValidateReg(Models.TipoModeloDocumento reg, ITipoModeloDocumentoService service, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class TipoModeloDocumentoValidation : ITipoModeloDocumentoValidation
{
    public async Task<string> ValidateReg(Models.TipoModeloDocumento reg, ITipoModeloDocumentoService service, [FromRoute, Required] string uri, SqlConnection oCnn)
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