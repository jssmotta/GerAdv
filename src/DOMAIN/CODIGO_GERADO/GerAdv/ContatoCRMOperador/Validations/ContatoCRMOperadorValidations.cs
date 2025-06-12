#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IContatoCRMOperadorValidation
{
    Task<string> ValidateReg(Models.ContatoCRMOperador reg, IContatoCRMOperadorService service, IContatoCRMReader contatocrmReader, IOperadorReader operadorReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, IContatoCRMOperadorService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class ContatoCRMOperadorValidation : IContatoCRMOperadorValidation
{
    public async Task<string> CanDelete(int id, IContatoCRMOperadorService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.ContatoCRMOperador reg, IContatoCRMOperadorService service, IContatoCRMReader contatocrmReader, IOperadorReader operadorReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        // ContatoCRM
        if (!reg.ContatoCRM.IsEmptyIDNumber())
        {
            var regContatoCRM = contatocrmReader.Read(reg.ContatoCRM, oCnn);
            if (regContatoCRM == null || regContatoCRM.Id != reg.ContatoCRM)
            {
                return $"Contato C R M não encontrado ({regContatoCRM?.Id}).";
            }
        }

        // Operador
        if (!reg.Operador.IsEmptyIDNumber())
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