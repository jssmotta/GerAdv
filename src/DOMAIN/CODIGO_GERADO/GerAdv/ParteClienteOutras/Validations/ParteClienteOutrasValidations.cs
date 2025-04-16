#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IParteClienteOutrasValidation
{
    Task<string> ValidateReg(Models.ParteClienteOutras reg, IParteClienteOutrasService service, IOutrasPartesClienteReader outraspartesclienteReader, IProcessosReader processosReader, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class ParteClienteOutrasValidation : IParteClienteOutrasValidation
{
    public async Task<string> ValidateReg(Models.ParteClienteOutras reg, IParteClienteOutrasService service, IOutrasPartesClienteReader outraspartesclienteReader, IProcessosReader processosReader, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        // OutrasPartesCliente
        if (reg.Cliente.IsEmptyIDNumber())
        {
            var regOutrasPartesCliente = outraspartesclienteReader.Read(reg.Cliente, oCnn);
            if (regOutrasPartesCliente == null || regOutrasPartesCliente.Id != reg.Cliente)
            {
                return $"Outras Partes Cliente não encontrado ({regOutrasPartesCliente?.Id}).";
            }
        }

        // Processos
        if (reg.Processo.IsEmptyIDNumber())
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