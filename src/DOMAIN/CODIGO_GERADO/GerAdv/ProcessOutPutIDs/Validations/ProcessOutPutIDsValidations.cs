#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProcessOutPutIDsValidation
{
    Task<string> ValidateReg(Models.ProcessOutPutIDs reg, IProcessOutPutIDsService service, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class ProcessOutPutIDsValidation : IProcessOutPutIDsValidation
{
    public async Task<string> ValidateReg(Models.ProcessOutPutIDs reg, IProcessOutPutIDsService service, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        return string.Empty;
    }
}