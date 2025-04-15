#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IEndTitValidation
{
    Task<string> ValidateReg(Models.EndTit reg, IEndTitService service, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class EndTitValidation : IEndTitValidation
{
    public async Task<string> ValidateReg(Models.EndTit reg, IEndTitService service, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        return string.Empty;
    }
}