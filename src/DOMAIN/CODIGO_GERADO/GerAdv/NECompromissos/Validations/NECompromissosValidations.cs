#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface INECompromissosValidation
{
    Task<string> ValidateReg(Models.NECompromissos reg, INECompromissosService service, ITipoCompromissoReader tipocompromissoReader, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class NECompromissosValidation : INECompromissosValidation
{
    public async Task<string> ValidateReg(Models.NECompromissos reg, INECompromissosService service, ITipoCompromissoReader tipocompromissoReader, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        // TipoCompromisso
        if (reg.TipoCompromisso.IsEmptyIDNumber())
        {
            var regTipoCompromisso = tipocompromissoReader.Read(reg.TipoCompromisso, oCnn);
            if (regTipoCompromisso == null || regTipoCompromisso.Id != reg.TipoCompromisso)
            {
                return $"Tipo Compromisso não encontrado ({regTipoCompromisso?.Id}).";
            }
        }

        return string.Empty;
    }
}