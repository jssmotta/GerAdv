#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IFornecedoresValidation
{
    Task<string> ValidateReg(Models.Fornecedores reg, IFornecedoresService service, ICidadeReader cidadeReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, IFornecedoresService service, IBensMateriaisService bensmateriaisService, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class FornecedoresValidation : IFornecedoresValidation
{
    public async Task<string> CanDelete(int id, IFornecedoresService service, IBensMateriaisService bensmateriaisService, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        var bensmateriaisExists = await bensmateriaisService.Filter(new Filters.FilterBensMateriais { Fornecedor = id }, uri);
        if (bensmateriaisExists != null && bensmateriaisExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Bens Materiais associados a ele.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.Fornecedores reg, IFornecedoresService service, ICidadeReader cidadeReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        if (!string.IsNullOrWhiteSpace(reg.CPF) && await IsCpfDuplicado(reg, service, uri))
            return $"'Fornecedores' com cpf '{reg.CPF.MaskCpf()}' já cadastrado.";
        if (!string.IsNullOrWhiteSpace(reg.CNPJ) && await IsCnpjDuplicado(reg, service, uri))
            return $"Fornecedores com cnpj {reg.CNPJ.MaskCnpj()} já cadastrado.";
        // Cidade
        if (!reg.Cidade.IsEmptyIDNumber())
        {
            var regCidade = cidadeReader.Read(reg.Cidade, oCnn);
            if (regCidade == null || regCidade.Id != reg.Cidade)
            {
                return $"Cidade não encontrado ({regCidade?.Id}).";
            }
        }

        return string.Empty;
    }

    private async Task<bool> IsCnpjDuplicado(Models.Fornecedores reg, IFornecedoresService service, string uri)
    {
        if (reg.CNPJ.Length == 0)
            return false;
        var existingFornecedores = (await service.Filter(new Filters.FilterFornecedores { CNPJ = reg.CNPJ }, uri)).FirstOrDefault();
        return existingFornecedores != null && existingFornecedores.Id > 0 && existingFornecedores.Id != reg.Id;
    }

    private async Task<bool> IsCpfDuplicado(Models.Fornecedores reg, IFornecedoresService service, string uri)
    {
        if (reg.CPF.Length == 0)
            return false;
        var existingFornecedores = (await service.Filter(new Filters.FilterFornecedores { CPF = reg.CPF }, uri)).FirstOrDefault();
        return existingFornecedores != null && existingFornecedores.Id > 0 && existingFornecedores.Id != reg.Id;
    }
}