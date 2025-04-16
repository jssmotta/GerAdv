#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITiposAcaoValidation
{
    Task<string> ValidateReg(Models.TiposAcao reg, ITiposAcaoService service, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class TiposAcaoValidation : ITiposAcaoValidation
{
    public async Task<string> ValidateReg(Models.TiposAcao reg, ITiposAcaoService service, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        return string.Empty;
    }
}