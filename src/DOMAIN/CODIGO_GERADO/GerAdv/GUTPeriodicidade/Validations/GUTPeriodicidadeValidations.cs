#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IGUTPeriodicidadeValidation
{
    Task<string> ValidateReg(Models.GUTPeriodicidade reg, IGUTPeriodicidadeService service, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class GUTPeriodicidadeValidation : IGUTPeriodicidadeValidation
{
    public async Task<string> ValidateReg(Models.GUTPeriodicidade reg, IGUTPeriodicidadeService service, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        return string.Empty;
    }
}