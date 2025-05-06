#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IDadosProcuracaoValidation
{
    Task<string> ValidateReg(Models.DadosProcuracao reg, IDadosProcuracaoService service, IClientesReader clientesReader, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class DadosProcuracaoValidation : IDadosProcuracaoValidation
{
    public async Task<string> ValidateReg(Models.DadosProcuracao reg, IDadosProcuracaoService service, IClientesReader clientesReader, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
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
}