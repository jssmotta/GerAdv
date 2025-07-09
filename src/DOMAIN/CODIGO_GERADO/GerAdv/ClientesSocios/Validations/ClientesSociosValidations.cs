#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IClientesSociosValidation
{
    Task<string> ValidateReg(Models.ClientesSocios reg, IClientesSociosService service, IClientesReader clientesReader, ICidadeReader cidadeReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, IClientesSociosService service, IAgendaRecordsService agendarecordsService, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class ClientesSociosValidation : IClientesSociosValidation
{
    public async Task<string> CanDelete(int id, IClientesSociosService service, IAgendaRecordsService agendarecordsService, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        var agendarecordsExists0 = await agendarecordsService.Filter(new Filters.FilterAgendaRecords { ClientesSocios = id }, uri);
        if (agendarecordsExists0 != null && agendarecordsExists0.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Agenda Records associados a ele.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.ClientesSocios reg, IClientesSociosService service, IClientesReader clientesReader, ICidadeReader cidadeReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        if (await IsDuplicado(reg, service, uri))
            return $"Clientes Socios '{reg.Nome}' Cliente e/ou Nome";
        if (!string.IsNullOrWhiteSpace(reg.CPF))
        {
            var testaCpf = await IsCpfDuplicado(reg, service, uri);
            if (testaCpf.Item1 && testaCpf.Item2 != null)
            {
                return $"Clientes Socios ({testaCpf.Item2.Nome}) com cpf '{reg.CPF.MaskCpf()}' já cadastrado.";
            }
            else if (testaCpf.Item1)
            {
                return $"Clientes Socios com cpf '{reg.CPF.MaskCpf()}' já cadastrado.";
            }
        }

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

    private async Task<bool> IsDuplicado(Models.ClientesSocios reg, IClientesSociosService service, string uri)
    {
        var existingClientesSocios = (await service.Filter(new Filters.FilterClientesSocios { Cliente = reg.Cliente, Nome = reg.Nome }, uri)).FirstOrDefault(); // TRACK 10042025
        return existingClientesSocios != null && existingClientesSocios.Id > 0 && existingClientesSocios.Id != reg.Id;
    }

    private async Task<bool> IsCnpjDuplicado(Models.ClientesSocios reg, IClientesSociosService service, string uri)
    {
        if (reg.CNPJ.Length == 0)
            return false;
        var existingClientesSocios = (await service.Filter(new Filters.FilterClientesSocios { CNPJ = reg.CNPJ.ClearInputCnpj() }, uri)).FirstOrDefault();
        return existingClientesSocios != null && existingClientesSocios.Id > 0 && existingClientesSocios.Id != reg.Id;
    }

    private async Task<(bool, ClientesSociosResponseAll? )> IsCpfDuplicado(Models.ClientesSocios reg, IClientesSociosService service, string uri)
    {
        if (reg.CPF.Length == 0)
            return (false, null);
        var existingClientesSocios = (await service.Filter(new Filters.FilterClientesSocios { CPF = reg.CPF.ClearInputCpf() }, uri)).FirstOrDefault();
        return (existingClientesSocios != null && existingClientesSocios.Id > 0 && existingClientesSocios.Id != reg.Id, existingClientesSocios);
    }
}