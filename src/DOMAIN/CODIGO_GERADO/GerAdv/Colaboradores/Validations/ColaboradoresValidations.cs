#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IColaboradoresValidation
{
    Task<string> ValidateReg(Models.Colaboradores reg, IColaboradoresService service, ICargosReader cargosReader, IClientesReader clientesReader, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class ColaboradoresValidation : IColaboradoresValidation
{
    public async Task<string> ValidateReg(Models.Colaboradores reg, IColaboradoresService service, ICargosReader cargosReader, IClientesReader clientesReader, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        if (await IsDuplicado(reg, service, uri))
            return $"Colaboradores '{reg.Nome}' já cadastrado.";
        if (!string.IsNullOrWhiteSpace(reg.CPF) && await IsCpfDuplicado(reg, service, uri))
            return $"'Colaboradores' com cpf '{reg.CPF.MaskCpf()}' já cadastrado.";
        // Cargos
        if (reg.Cargo.IsEmptyIDNumber())
        {
            var regCargos = cargosReader.Read(reg.Cargo, oCnn);
            if (regCargos == null || regCargos.Id != reg.Cargo)
            {
                return $"Cargos não encontrado ({regCargos?.Id}).";
            }
        }

        // Clientes
        if (reg.Cliente.IsEmptyIDNumber())
        {
            var regClientes = clientesReader.Read(reg.Cliente, oCnn);
            if (regClientes == null || regClientes.Id != reg.Cliente)
            {
                return $"Clientes não encontrado ({regClientes?.Id}).";
            }
        }

        return string.Empty;
    }

    private async Task<bool> IsDuplicado(Models.Colaboradores reg, IColaboradoresService service, string uri)
    {
        var existingColaboradores = (await service.Filter(new Filters.FilterColaboradores { Cliente = reg.Cliente, Nome = reg.Nome }, uri)).FirstOrDefault(); // TRACK 10042025
        return existingColaboradores != null && existingColaboradores.Id > 0 && existingColaboradores.Id != reg.Id;
    }

    private async Task<bool> IsCpfDuplicado(Models.Colaboradores reg, IColaboradoresService service, string uri)
    {
        var existingColaboradores = (await service.Filter(new Filters.FilterColaboradores { CPF = reg.CPF }, uri)).FirstOrDefault();
        return existingColaboradores != null && existingColaboradores.Id > 0 && existingColaboradores.Id != reg.Id;
    }
}