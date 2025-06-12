#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IPreClientesValidation
{
    Task<string> ValidateReg(Models.PreClientes reg, IPreClientesService service, IClientesReader clientesReader, ICidadeReader cidadeReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, IPreClientesService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class PreClientesValidation : IPreClientesValidation
{
    public async Task<string> CanDelete(int id, IPreClientesService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.PreClientes reg, IPreClientesService service, IClientesReader clientesReader, ICidadeReader cidadeReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        if (!string.IsNullOrWhiteSpace(reg.CPF) && await IsCpfDuplicado(reg, service, uri))
            return $"'Pre Clientes' com cpf '{reg.CPF.MaskCpf()}' já cadastrado.";
        if (!string.IsNullOrWhiteSpace(reg.CNPJ) && await IsCnpjDuplicado(reg, service, uri))
            return $"Pre Clientes com cnpj {reg.CNPJ.MaskCnpj()} já cadastrado.";
        // Clientes
        if (!reg.IDRep.IsEmptyIDNumber())
        {
            var regClientes = clientesReader.Read(reg.IDRep, oCnn);
            if (regClientes == null || regClientes.Id != reg.IDRep)
            {
                return $"Clientes não encontrado ({regClientes?.Id}).";
            }
        }

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

    private async Task<bool> IsCnpjDuplicado(Models.PreClientes reg, IPreClientesService service, string uri)
    {
        if (reg.CNPJ.Length == 0)
            return false;
        var existingPreClientes = (await service.Filter(new Filters.FilterPreClientes { CNPJ = reg.CNPJ }, uri)).FirstOrDefault();
        return existingPreClientes != null && existingPreClientes.Id > 0 && existingPreClientes.Id != reg.Id;
    }

    private async Task<bool> IsCpfDuplicado(Models.PreClientes reg, IPreClientesService service, string uri)
    {
        if (reg.CPF.Length == 0)
            return false;
        var existingPreClientes = (await service.Filter(new Filters.FilterPreClientes { CPF = reg.CPF }, uri)).FirstOrDefault();
        return existingPreClientes != null && existingPreClientes.Id > 0 && existingPreClientes.Id != reg.Id;
    }
}