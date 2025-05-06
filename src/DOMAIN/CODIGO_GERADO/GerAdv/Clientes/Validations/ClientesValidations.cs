#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IClientesValidation
{
    Task<string> ValidateReg(Models.Clientes reg, IClientesService service, IRegimeTributacaoReader regimetributacaoReader, IEnquadramentoEmpresaReader enquadramentoempresaReader, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class ClientesValidation : IClientesValidation
{
    public async Task<string> ValidateReg(Models.Clientes reg, IClientesService service, IRegimeTributacaoReader regimetributacaoReader, IEnquadramentoEmpresaReader enquadramentoempresaReader, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        if (await IsDuplicado(reg, service, uri))
            return $"Clientes '{reg.Nome}' já cadastrado.";
        if (!string.IsNullOrWhiteSpace(reg.CPF) && await IsCpfDuplicado(reg, service, uri))
            return $"'Clientes' com cpf '{reg.CPF.MaskCpf()}' já cadastrado.";
        if (!string.IsNullOrWhiteSpace(reg.CNPJ) && await IsCnpjDuplicado(reg, service, uri))
            return $"Clientes com cnpj {reg.CNPJ.MaskCnpj()} já cadastrado.";
        // RegimeTributacao
        if (!reg.RegimeTributacao.IsEmptyIDNumber())
        {
            var regRegimeTributacao = regimetributacaoReader.Read(reg.RegimeTributacao, oCnn);
            if (regRegimeTributacao == null || regRegimeTributacao.Id != reg.RegimeTributacao)
            {
                return $"Regime Tributacao não encontrado ({regRegimeTributacao?.Id}).";
            }
        }

        // EnquadramentoEmpresa
        if (!reg.EnquadramentoEmpresa.IsEmptyIDNumber())
        {
            var regEnquadramentoEmpresa = enquadramentoempresaReader.Read(reg.EnquadramentoEmpresa, oCnn);
            if (regEnquadramentoEmpresa == null || regEnquadramentoEmpresa.Id != reg.EnquadramentoEmpresa)
            {
                return $"Enquadramento Empresa não encontrado ({regEnquadramentoEmpresa?.Id}).";
            }
        }

        return string.Empty;
    }

    private async Task<bool> IsDuplicado(Models.Clientes reg, IClientesService service, string uri)
    {
        var existingClientes = (await service.Filter(new Filters.FilterClientes { Nome = reg.Nome }, uri)).FirstOrDefault(); // TRACK 10042025
        return existingClientes != null && existingClientes.Id > 0 && existingClientes.Id != reg.Id;
    }

    private async Task<bool> IsCnpjDuplicado(Models.Clientes reg, IClientesService service, string uri)
    {
        var existingClientes = (await service.Filter(new Filters.FilterClientes { CNPJ = reg.CNPJ }, uri)).FirstOrDefault();
        return existingClientes != null && existingClientes.Id > 0 && existingClientes.Id != reg.Id;
    }

    private async Task<bool> IsCpfDuplicado(Models.Clientes reg, IClientesService service, string uri)
    {
        var existingClientes = (await service.Filter(new Filters.FilterClientes { CPF = reg.CPF }, uri)).FirstOrDefault();
        return existingClientes != null && existingClientes.Id > 0 && existingClientes.Id != reg.Id;
    }
}