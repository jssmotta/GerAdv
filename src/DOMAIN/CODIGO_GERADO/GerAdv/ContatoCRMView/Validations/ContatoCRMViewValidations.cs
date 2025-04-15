#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IContatoCRMViewValidation
{
    Task<string> ValidateReg(Models.ContatoCRMView reg, IContatoCRMViewService service, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class ContatoCRMViewValidation : IContatoCRMViewValidation
{
    public async Task<string> ValidateReg(Models.ContatoCRMView reg, IContatoCRMViewService service, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        return string.Empty;
    }
}