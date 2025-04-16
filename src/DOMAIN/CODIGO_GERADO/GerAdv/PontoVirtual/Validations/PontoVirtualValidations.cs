#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IPontoVirtualValidation
{
    Task<string> ValidateReg(Models.PontoVirtual reg, IPontoVirtualService service, IOperadorReader operadorReader, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class PontoVirtualValidation : IPontoVirtualValidation
{
    public async Task<string> ValidateReg(Models.PontoVirtual reg, IPontoVirtualService service, IOperadorReader operadorReader, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        // Operador
        if (reg.Operador.IsEmptyIDNumber())
        {
            var regOperador = operadorReader.Read(reg.Operador, oCnn);
            if (regOperador == null || regOperador.Id != reg.Operador)
            {
                return $"Operador não encontrado ({regOperador?.Id}).";
            }
        }

        return string.Empty;
    }
}