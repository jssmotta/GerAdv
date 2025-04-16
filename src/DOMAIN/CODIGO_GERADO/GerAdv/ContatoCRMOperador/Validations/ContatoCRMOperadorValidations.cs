#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IContatoCRMOperadorValidation
{
    Task<string> ValidateReg(Models.ContatoCRMOperador reg, IContatoCRMOperadorService service, IContatoCRMReader contatocrmReader, IOperadorReader operadorReader, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class ContatoCRMOperadorValidation : IContatoCRMOperadorValidation
{
    public async Task<string> ValidateReg(Models.ContatoCRMOperador reg, IContatoCRMOperadorService service, IContatoCRMReader contatocrmReader, IOperadorReader operadorReader, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        // ContatoCRM
        if (reg.ContatoCRM.IsEmptyIDNumber())
        {
            var regContatoCRM = contatocrmReader.Read(reg.ContatoCRM, oCnn);
            if (regContatoCRM == null || regContatoCRM.Id != reg.ContatoCRM)
            {
                return $"Contato C R M não encontrado ({regContatoCRM?.Id}).";
            }
        }

        // Operador
        if (reg.Operador.IsEmptyIDNumber())
        {
            var regOperador = operadorReader.Read(reg.Operador, oCnn);
            if (regOperador == null || regOperador.Id != reg.Operador)
            {
                return $"Operador não encontrado ({regOperador?.Id}).";
            }
        }

        return string.Empty;
    }
}