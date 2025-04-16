#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IOutrasPartesClienteValidation
{
    Task<string> ValidateReg(Models.OutrasPartesCliente reg, IOutrasPartesClienteService service, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class OutrasPartesClienteValidation : IOutrasPartesClienteValidation
{
    public async Task<string> ValidateReg(Models.OutrasPartesCliente reg, IOutrasPartesClienteService service, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        if (!string.IsNullOrWhiteSpace(reg.CPF) && await IsCpfDuplicado(reg, service, uri))
            return $"'Outras Partes Cliente' com cpf '{reg.CPF.MaskCpf()}' já cadastrado.";
        if (!string.IsNullOrWhiteSpace(reg.CNPJ) && await IsCnpjDuplicado(reg, service, uri))
            return $"Outras Partes Cliente com cnpj {reg.CNPJ.MaskCnpj()} já cadastrado.";
        return string.Empty;
    }

    private async Task<bool> IsCnpjDuplicado(Models.OutrasPartesCliente reg, IOutrasPartesClienteService service, string uri)
    {
        var existingOutrasPartesCliente = (await service.Filter(new Filters.FilterOutrasPartesCliente { CNPJ = reg.CNPJ }, uri)).FirstOrDefault();
        return existingOutrasPartesCliente != null && existingOutrasPartesCliente.Id > 0 && existingOutrasPartesCliente.Id != reg.Id;
    }

    private async Task<bool> IsCpfDuplicado(Models.OutrasPartesCliente reg, IOutrasPartesClienteService service, string uri)
    {
        var existingOutrasPartesCliente = (await service.Filter(new Filters.FilterOutrasPartesCliente { CPF = reg.CPF }, uri)).FirstOrDefault();
        return existingOutrasPartesCliente != null && existingOutrasPartesCliente.Id > 0 && existingOutrasPartesCliente.Id != reg.Id;
    }
}