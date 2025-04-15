#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoCompromissoValidation
{
    Task<string> ValidateReg(Models.TipoCompromisso reg, ITipoCompromissoService service, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class TipoCompromissoValidation : ITipoCompromissoValidation
{
    public async Task<string> ValidateReg(Models.TipoCompromisso reg, ITipoCompromissoService service, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Descricao))
            return "Descricao é obrigatório";
        return string.Empty;
    }
}