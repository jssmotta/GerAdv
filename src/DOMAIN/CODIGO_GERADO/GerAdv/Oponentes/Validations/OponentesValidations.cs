#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IOponentesValidation
{
    Task<string> ValidateReg(Models.Oponentes reg, IOponentesService service, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class OponentesValidation : IOponentesValidation
{
    public async Task<string> ValidateReg(Models.Oponentes reg, IOponentesService service, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        if (!string.IsNullOrWhiteSpace(reg.CPF) && await IsCpfDuplicado(reg, service, uri))
            return $"'Oponentes' com cpf '{reg.CPF.MaskCpf()}' já cadastrado.";
        if (!string.IsNullOrWhiteSpace(reg.CNPJ) && await IsCnpjDuplicado(reg, service, uri))
            return $"Oponentes com cnpj {reg.CNPJ.MaskCnpj()} já cadastrado.";
        return string.Empty;
    }

    private async Task<bool> IsCnpjDuplicado(Models.Oponentes reg, IOponentesService service, string uri)
    {
        var existingOponentes = (await service.Filter(new Filters.FilterOponentes { CNPJ = reg.CNPJ }, uri)).FirstOrDefault();
        return existingOponentes != null && existingOponentes.Id > 0 && existingOponentes.Id != reg.Id;
    }

    private async Task<bool> IsCpfDuplicado(Models.Oponentes reg, IOponentesService service, string uri)
    {
        var existingOponentes = (await service.Filter(new Filters.FilterOponentes { CPF = reg.CPF }, uri)).FirstOrDefault();
        return existingOponentes != null && existingOponentes.Id > 0 && existingOponentes.Id != reg.Id;
    }
}