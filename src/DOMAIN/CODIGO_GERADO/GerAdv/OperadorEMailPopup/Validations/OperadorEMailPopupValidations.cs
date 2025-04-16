#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IOperadorEMailPopupValidation
{
    Task<string> ValidateReg(Models.OperadorEMailPopup reg, IOperadorEMailPopupService service, IOperadorReader operadorReader, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class OperadorEMailPopupValidation : IOperadorEMailPopupValidation
{
    public async Task<string> ValidateReg(Models.OperadorEMailPopup reg, IOperadorEMailPopupService service, IOperadorReader operadorReader, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
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