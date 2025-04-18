#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ILivroCaixaClientesValidation
{
    Task<string> ValidateReg(Models.LivroCaixaClientes reg, ILivroCaixaClientesService service, ILivroCaixaReader livrocaixaReader, IClientesReader clientesReader, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class LivroCaixaClientesValidation : ILivroCaixaClientesValidation
{
    public async Task<string> ValidateReg(Models.LivroCaixaClientes reg, ILivroCaixaClientesService service, ILivroCaixaReader livrocaixaReader, IClientesReader clientesReader, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        // LivroCaixa
        if (!reg.LivroCaixa.IsEmptyIDNumber())
        {
            var regLivroCaixa = livrocaixaReader.Read(reg.LivroCaixa, oCnn);
            if (regLivroCaixa == null || regLivroCaixa.Id != reg.LivroCaixa)
            {
                return $"Livro Caixa não encontrado ({regLivroCaixa?.Id}).";
            }
        }

        // Clientes
        if (!reg.Cliente.IsEmptyIDNumber())
        {
            var regClientes = clientesReader.Read(reg.Cliente, oCnn);
            if (regClientes == null || regClientes.Id != reg.Cliente)
            {
                return $"Clientes não encontrado ({regClientes?.Id}).";
            }
        }

        return string.Empty;
    }
}