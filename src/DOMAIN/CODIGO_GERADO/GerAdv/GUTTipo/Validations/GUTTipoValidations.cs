#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IGUTTipoValidation
{
    Task<string> ValidateReg(Models.GUTTipo reg, IGUTTipoService service, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class GUTTipoValidation : IGUTTipoValidation
{
    public async Task<string> ValidateReg(Models.GUTTipo reg, IGUTTipoService service, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        return string.Empty;
    }
}