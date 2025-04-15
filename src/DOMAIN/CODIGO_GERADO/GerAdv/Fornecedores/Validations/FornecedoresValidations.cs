#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IFornecedoresValidation
{
    Task<string> ValidateReg(Models.Fornecedores reg, IFornecedoresService service, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class FornecedoresValidation : IFornecedoresValidation
{
    public async Task<string> ValidateReg(Models.Fornecedores reg, IFornecedoresService service, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        if (!string.IsNullOrWhiteSpace(reg.CPF) && await IsCpfDuplicado(reg, service, uri))
            return $"'Fornecedores' com cpf '{reg.CPF.MaskCpf()}' já cadastrado.";
        if (!string.IsNullOrWhiteSpace(reg.CNPJ) && await IsCnpjDuplicado(reg, service, uri))
            return $"Fornecedores com cnpj {reg.CNPJ.MaskCnpj()} já cadastrado.";
        return string.Empty;
    }

    private async Task<bool> IsCnpjDuplicado(Models.Fornecedores reg, IFornecedoresService service, string uri)
    {
        var existingFornecedores = (await service.Filter(new Filters.FilterFornecedores { CNPJ = reg.CNPJ }, uri)).FirstOrDefault();
        return existingFornecedores != null && existingFornecedores.Id > 0 && existingFornecedores.Id != reg.Id;
    }

    private async Task<bool> IsCpfDuplicado(Models.Fornecedores reg, IFornecedoresService service, string uri)
    {
        var existingFornecedores = (await service.Filter(new Filters.FilterFornecedores { CPF = reg.CPF }, uri)).FirstOrDefault();
        return existingFornecedores != null && existingFornecedores.Id > 0 && existingFornecedores.Id != reg.Id;
    }
}