#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IServicosValidation
{
    Task<string> ValidateReg(Models.Servicos reg, IServicosService service, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class ServicosValidation : IServicosValidation
{
    public async Task<string> ValidateReg(Models.Servicos reg, IServicosService service, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Descricao))
            return "Descricao é obrigatório";
        return string.Empty;
    }
}