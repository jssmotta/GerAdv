#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IGUTPeriodicidadeStatusValidation
{
    Task<string> ValidateReg(Models.GUTPeriodicidadeStatus reg, IGUTPeriodicidadeStatusService service, IGUTAtividadesReader gutatividadesReader, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class GUTPeriodicidadeStatusValidation : IGUTPeriodicidadeStatusValidation
{
    public async Task<string> ValidateReg(Models.GUTPeriodicidadeStatus reg, IGUTPeriodicidadeStatusService service, IGUTAtividadesReader gutatividadesReader, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
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