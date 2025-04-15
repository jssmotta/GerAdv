#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IOperadorValidation
{
    Task<string> ValidateReg(Models.Operador reg, IOperadorService service, IStatusBiuReader statusbiuReader, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class OperadorValidation : IOperadorValidation
{
    public async Task<string> ValidateReg(Models.Operador reg, IOperadorService service, IStatusBiuReader statusbiuReader, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        // StatusBiu
        if (reg.StatusId.IsEmptyIDNumber())
        {
            var regStatusBiu = statusbiuReader.Read(reg.StatusId, oCnn);
            if (regStatusBiu == null || regStatusBiu.Id != reg.StatusId)
            {
                return $"Status Biu não encontrado ({regStatusBiu?.Id}).";
            }
        }

        return string.Empty;
    }
}