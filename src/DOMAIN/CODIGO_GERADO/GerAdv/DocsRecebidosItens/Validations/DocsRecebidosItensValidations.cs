#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IDocsRecebidosItensValidation
{
    Task<string> ValidateReg(Models.DocsRecebidosItens reg, IDocsRecebidosItensService service, IContatoCRMReader contatocrmReader, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class DocsRecebidosItensValidation : IDocsRecebidosItensValidation
{
    public async Task<string> ValidateReg(Models.DocsRecebidosItens reg, IDocsRecebidosItensService service, IContatoCRMReader contatocrmReader, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        // ContatoCRM
        if (!reg.ContatoCRM.IsEmptyIDNumber())
        {
            var regContatoCRM = contatocrmReader.Read(reg.ContatoCRM, oCnn);
            if (regContatoCRM == null || regContatoCRM.Id != reg.ContatoCRM)
            {
                return $"Contato C R M não encontrado ({regContatoCRM?.Id}).";
            }
        }

        return string.Empty;
    }
}