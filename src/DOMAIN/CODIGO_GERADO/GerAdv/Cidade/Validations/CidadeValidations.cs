#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ICidadeValidation
{
    Task<string> ValidateReg(Models.Cidade reg, ICidadeService service, IUFReader ufReader, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class CidadeValidation : ICidadeValidation
{
    public async Task<string> ValidateReg(Models.Cidade reg, ICidadeService service, IUFReader ufReader, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        // UF
        if (reg.UF.IsEmptyIDNumber())
        {
            var regUF = ufReader.Read(reg.UF, oCnn);
            if (regUF == null || regUF.Id != reg.UF)
            {
                return $"UF não encontrado ({regUF?.Id}).";
            }
        }

        return string.Empty;
    }
}