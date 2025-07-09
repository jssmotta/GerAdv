#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IOutrasPartesClienteValidation
{
    Task<string> ValidateReg(Models.OutrasPartesCliente reg, IOutrasPartesClienteService service, ICidadeReader cidadeReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, IOutrasPartesClienteService service, IParteClienteOutrasService parteclienteoutrasService, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class OutrasPartesClienteValidation : IOutrasPartesClienteValidation
{
    public async Task<string> CanDelete(int id, IOutrasPartesClienteService service, IParteClienteOutrasService parteclienteoutrasService, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        var parteclienteoutrasExists0 = await parteclienteoutrasService.Filter(new Filters.FilterParteClienteOutras { Cliente = id }, uri);
        if (parteclienteoutrasExists0 != null && parteclienteoutrasExists0.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Parte Cliente Outras associados a ele.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.OutrasPartesCliente reg, IOutrasPartesClienteService service, ICidadeReader cidadeReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        if (!string.IsNullOrWhiteSpace(reg.CPF))
        {
            var testaCpf = await IsCpfDuplicado(reg, service, uri);
            if (testaCpf.Item1 && testaCpf.Item2 != null)
            {
                return $"Outras Partes Cliente ({testaCpf.Item2.Nome}) com cpf '{reg.CPF.MaskCpf()}' já cadastrado.";
            }
            else if (testaCpf.Item1)
            {
                return $"Outras Partes Cliente com cpf '{reg.CPF.MaskCpf()}' já cadastrado.";
            }
        }

        if (!string.IsNullOrWhiteSpace(reg.CNPJ) && await IsCnpjDuplicado(reg, service, uri))
            return $"Outras Partes Cliente com cnpj {reg.CNPJ.MaskCnpj()} já cadastrado.";
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

    private async Task<bool> IsCnpjDuplicado(Models.OutrasPartesCliente reg, IOutrasPartesClienteService service, string uri)
    {
        if (reg.CNPJ.Length == 0)
            return false;
        var existingOutrasPartesCliente = (await service.Filter(new Filters.FilterOutrasPartesCliente { CNPJ = reg.CNPJ.ClearInputCnpj() }, uri)).FirstOrDefault();
        return existingOutrasPartesCliente != null && existingOutrasPartesCliente.Id > 0 && existingOutrasPartesCliente.Id != reg.Id;
    }

    private async Task<(bool, OutrasPartesClienteResponseAll? )> IsCpfDuplicado(Models.OutrasPartesCliente reg, IOutrasPartesClienteService service, string uri)
    {
        if (reg.CPF.Length == 0)
            return (false, null);
        var existingOutrasPartesCliente = (await service.Filter(new Filters.FilterOutrasPartesCliente { CPF = reg.CPF.ClearInputCpf() }, uri)).FirstOrDefault();
        return (existingOutrasPartesCliente != null && existingOutrasPartesCliente.Id > 0 && existingOutrasPartesCliente.Id != reg.Id, existingOutrasPartesCliente);
    }
}