#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IGUTAtividadesMatrizValidation
{
    Task<string> ValidateReg(Models.GUTAtividadesMatriz reg, IGUTAtividadesMatrizService service, IGUTMatrizReader gutmatrizReader, IGUTAtividadesReader gutatividadesReader, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class GUTAtividadesMatrizValidation : IGUTAtividadesMatrizValidation
{
    public async Task<string> ValidateReg(Models.GUTAtividadesMatriz reg, IGUTAtividadesMatrizService service, IGUTMatrizReader gutmatrizReader, IGUTAtividadesReader gutatividadesReader, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        // GUTMatriz
        if (!reg.GUTMatriz.IsEmptyIDNumber())
        {
            var regGUTMatriz = gutmatrizReader.Read(reg.GUTMatriz, oCnn);
            if (regGUTMatriz == null || regGUTMatriz.Id != reg.GUTMatriz)
            {
                return $"G U T Matriz não encontrado ({regGUTMatriz?.Id}).";
            }
        }

        // GUTAtividades
        if (!reg.GUTAtividade.IsEmptyIDNumber())
        {
            var regGUTAtividades = gutatividadesReader.Read(reg.GUTAtividade, oCnn);
            if (regGUTAtividades == null || regGUTAtividades.Id != reg.GUTAtividade)
            {
                return $"G U T Atividades não encontrado ({regGUTAtividades?.Id}).";
            }
        }

        return string.Empty;
    }
}