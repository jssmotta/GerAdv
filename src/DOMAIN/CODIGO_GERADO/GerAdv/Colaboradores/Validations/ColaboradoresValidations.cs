#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IColaboradoresValidation
{
    Task<string> ValidateReg(Models.Colaboradores reg, IColaboradoresService service, ICargosReader cargosReader, IClientesReader clientesReader, ICidadeReader cidadeReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, IColaboradoresService service, IAgendaRecordsService agendarecordsService, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class ColaboradoresValidation : IColaboradoresValidation
{
    public async Task<string> CanDelete(int id, IColaboradoresService service, IAgendaRecordsService agendarecordsService, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        var agendarecordsExists = await agendarecordsService.Filter(new Filters.FilterAgendaRecords { Colaborador = id }, uri);
        if (agendarecordsExists != null && agendarecordsExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Agenda Records associados a ele.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.Colaboradores reg, IColaboradoresService service, ICargosReader cargosReader, IClientesReader clientesReader, ICidadeReader cidadeReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        if (await IsDuplicado(reg, service, uri))
            return $"Colaborador '{reg.Nome}' Cliente e/ou Nome";
        if (!string.IsNullOrWhiteSpace(reg.CPF))
        {
            var testaCpf = await IsCpfDuplicado(reg, service, uri);
            if (testaCpf.Item1 && testaCpf.Item2 != null)
            {
                return $"Colaborador ({testaCpf.Item2.Nome}) com cpf '{reg.CPF.MaskCpf()}' já cadastrado.";
            }
            else if (testaCpf.Item1)
            {
                return $"Colaborador com cpf '{reg.CPF.MaskCpf()}' já cadastrado.";
            }
        }

        // Cargos
        if (!reg.Cargo.IsEmptyIDNumber())
        {
            var regCargos = cargosReader.Read(reg.Cargo, oCnn);
            if (regCargos == null || regCargos.Id != reg.Cargo)
            {
                return $"Cargos não encontrado ({regCargos?.Id}).";
            }
        }

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

    private async Task<bool> IsDuplicado(Models.Colaboradores reg, IColaboradoresService service, string uri)
    {
        var existingColaboradores = (await service.Filter(new Filters.FilterColaboradores { Cliente = reg.Cliente, Nome = reg.Nome }, uri)).FirstOrDefault(); // TRACK 10042025
        return existingColaboradores != null && existingColaboradores.Id > 0 && existingColaboradores.Id != reg.Id;
    }

    private async Task<(bool, ColaboradoresResponseAll? )> IsCpfDuplicado(Models.Colaboradores reg, IColaboradoresService service, string uri)
    {
        if (reg.CPF.Length == 0)
            return (false, null);
        var existingColaboradores = (await service.Filter(new Filters.FilterColaboradores { CPF = reg.CPF.ClearInputCpf() }, uri)).FirstOrDefault();
        return (existingColaboradores != null && existingColaboradores.Id > 0 && existingColaboradores.Id != reg.Id, existingColaboradores);
    }
}