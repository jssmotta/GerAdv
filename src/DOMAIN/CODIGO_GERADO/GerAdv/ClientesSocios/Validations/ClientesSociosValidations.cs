#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IClientesSociosValidation
{
    Task<string> ValidateReg(Models.ClientesSocios reg, IClientesSociosService service, IClientesReader clientesReader, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class ClientesSociosValidation : IClientesSociosValidation
{
    public async Task<string> ValidateReg(Models.ClientesSocios reg, IClientesSociosService service, IClientesReader clientesReader, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        if (await IsDuplicado(reg, service, uri))
            return $"ClientesSocios '{reg.Nome}' já cadastrado.";
        if (!string.IsNullOrWhiteSpace(reg.CPF) && await IsCpfDuplicado(reg, service, uri))
            return $"'Clientes Socios' com cpf '{reg.CPF.MaskCpf()}' já cadastrado.";
        if (!string.IsNullOrWhiteSpace(reg.CNPJ) && await IsCnpjDuplicado(reg, service, uri))
            return $"Clientes Socios com cnpj {reg.CNPJ.MaskCnpj()} já cadastrado.";
        // Clientes
        if (!reg.Cliente.IsEmptyIDNumber())
        {
            var regClientes = clientesReader.Read(reg.Cliente, oCnn);
            if (regClientes == null || regClientes.Id != reg.Cliente)
            {
                return $"Clientes não encontrado ({regClientes?.Id}).";
            }
        }

        return string.Empty;
    }

    private async Task<bool> IsDuplicado(Models.ClientesSocios reg, IClientesSociosService service, string uri)
    {
        var existingClientesSocios = (await service.Filter(new Filters.FilterClientesSocios { Cliente = reg.Cliente, Nome = reg.Nome }, uri)).FirstOrDefault(); // TRACK 10042025
        return existingClientesSocios != null && existingClientesSocios.Id > 0 && existingClientesSocios.Id != reg.Id;
    }

    private async Task<bool> IsCnpjDuplicado(Models.ClientesSocios reg, IClientesSociosService service, string uri)
    {
        var existingClientesSocios = (await service.Filter(new Filters.FilterClientesSocios { CNPJ = reg.CNPJ }, uri)).FirstOrDefault();
        return existingClientesSocios != null && existingClientesSocios.Id > 0 && existingClientesSocios.Id != reg.Id;
    }

    private async Task<bool> IsCpfDuplicado(Models.ClientesSocios reg, IClientesSociosService service, string uri)
    {
        var existingClientesSocios = (await service.Filter(new Filters.FilterClientesSocios { CPF = reg.CPF }, uri)).FirstOrDefault();
        return existingClientesSocios != null && existingClientesSocios.Id > 0 && existingClientesSocios.Id != reg.Id;
    }
}