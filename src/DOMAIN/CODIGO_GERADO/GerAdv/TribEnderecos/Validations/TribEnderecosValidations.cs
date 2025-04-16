#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITribEnderecosValidation
{
    Task<string> ValidateReg(Models.TribEnderecos reg, ITribEnderecosService service, ITribunalReader tribunalReader, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class TribEnderecosValidation : ITribEnderecosValidation
{
    public async Task<string> ValidateReg(Models.TribEnderecos reg, ITribEnderecosService service, ITribunalReader tribunalReader, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        // Tribunal
        if (reg.Tribunal.IsEmptyIDNumber())
        {
            var regTribunal = tribunalReader.Read(reg.Tribunal, oCnn);
            if (regTribunal == null || regTribunal.Id != reg.Tribunal)
            {
                return $"Tribunal não encontrado ({regTribunal?.Id}).";
            }
        }

        return string.Empty;
    }
}