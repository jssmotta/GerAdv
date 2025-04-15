#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IStatusHTrabValidation
{
    Task<string> ValidateReg(Models.StatusHTrab reg, IStatusHTrabService service, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class StatusHTrabValidation : IStatusHTrabValidation
{
    public async Task<string> ValidateReg(Models.StatusHTrab reg, IStatusHTrabService service, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Descricao))
            return "Descricao é obrigatório";
        return string.Empty;
    }
}