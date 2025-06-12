#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAgendaRepetirValidation
{
    Task<string> ValidateReg(Models.AgendaRepetir reg, IAgendaRepetirService service, IAdvogadosReader advogadosReader, IClientesReader clientesReader, IFuncionariosReader funcionariosReader, IProcessosReader processosReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, IAgendaRepetirService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class AgendaRepetirValidation : IAgendaRepetirValidation
{
    public async Task<string> CanDelete(int id, IAgendaRepetirService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.AgendaRepetir reg, IAgendaRepetirService service, IAdvogadosReader advogadosReader, IClientesReader clientesReader, IFuncionariosReader funcionariosReader, IProcessosReader processosReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        // Advogados
        if (!reg.Advogado.IsEmptyIDNumber())
        {
            var regAdvogados = advogadosReader.Read(reg.Advogado, oCnn);
            if (regAdvogados == null || regAdvogados.Id != reg.Advogado)
            {
                return $"Advogados não encontrado ({regAdvogados?.Id}).";
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

        // Funcionarios
        if (!reg.Funcionario.IsEmptyIDNumber())
        {
            var regFuncionarios = funcionariosReader.Read(reg.Funcionario, oCnn);
            if (regFuncionarios == null || regFuncionarios.Id != reg.Funcionario)
            {
                return $"Colaborador não encontrado ({regFuncionarios?.Id}).";
            }
        }

        // Processos
        if (!reg.Processo.IsEmptyIDNumber())
        {
            var regProcessos = processosReader.Read(reg.Processo, oCnn);
            if (regProcessos == null || regProcessos.Id != reg.Processo)
            {
                return $"Processos não encontrado ({regProcessos?.Id}).";
            }
        }

        return string.Empty;
    }
}