#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IGUTMatrizValidation
{
    Task<string> ValidateReg(Models.GUTMatriz reg, IGUTMatrizService service, IGUTTipoReader guttipoReader, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class GUTMatrizValidation : IGUTMatrizValidation
{
    public async Task<string> ValidateReg(Models.GUTMatriz reg, IGUTMatrizService service, IGUTTipoReader guttipoReader, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Descricao))
            return "Descricao é obrigatório";
        // GUTTipo
        if (reg.GUTTipo.IsEmptyIDNumber())
        {
            var regGUTTipo = guttipoReader.Read(reg.GUTTipo, oCnn);
            if (regGUTTipo == null || regGUTTipo.Id != reg.GUTTipo)
            {
                return $"G U T Tipo não encontrado ({regGUTTipo?.Id}).";
            }
        }

        return string.Empty;
    }
}