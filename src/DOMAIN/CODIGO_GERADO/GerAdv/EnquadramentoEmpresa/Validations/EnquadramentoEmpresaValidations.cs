#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IEnquadramentoEmpresaValidation
{
    Task<string> ValidateReg(Models.EnquadramentoEmpresa reg, IEnquadramentoEmpresaService service, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class EnquadramentoEmpresaValidation : IEnquadramentoEmpresaValidation
{
    public async Task<string> ValidateReg(Models.EnquadramentoEmpresa reg, IEnquadramentoEmpresaService service, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        if (await IsDuplicado(reg, service, uri))
            return $"EnquadramentoEmpresa '{reg.Nome}' já cadastrado.";
        return string.Empty;
    }

    private async Task<bool> IsDuplicado(Models.EnquadramentoEmpresa reg, IEnquadramentoEmpresaService service, string uri)
    {
        var existingEnquadramentoEmpresa = (await service.Filter(new Filters.FilterEnquadramentoEmpresa { Nome = reg.Nome }, uri)).FirstOrDefault(); // TRACK 10042025
        return existingEnquadramentoEmpresa != null && existingEnquadramentoEmpresa.Id > 0 && existingEnquadramentoEmpresa.Id != reg.Id;
    }
}