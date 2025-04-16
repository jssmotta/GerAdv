#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IContratosValidation
{
    Task<string> ValidateReg(Models.Contratos reg, IContratosService service, IProcessosReader processosReader, IClientesReader clientesReader, IAdvogadosReader advogadosReader, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class ContratosValidation : IContratosValidation
{
    public async Task<string> ValidateReg(Models.Contratos reg, IContratosService service, IProcessosReader processosReader, IClientesReader clientesReader, IAdvogadosReader advogadosReader, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        // Processos
        if (reg.Processo.IsEmptyIDNumber())
        {
            var regProcessos = processosReader.Read(reg.Processo, oCnn);
            if (regProcessos == null || regProcessos.Id != reg.Processo)
            {
                return $"Processos não encontrado ({regProcessos?.Id}).";
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

        // Advogados
        if (reg.Advogado.IsEmptyIDNumber())
        {
            var regAdvogados = advogadosReader.Read(reg.Advogado, oCnn);
            if (regAdvogados == null || regAdvogados.Id != reg.Advogado)
            {
                return $"Advogados não encontrado ({regAdvogados?.Id}).";
            }
        }

        return string.Empty;
    }
}