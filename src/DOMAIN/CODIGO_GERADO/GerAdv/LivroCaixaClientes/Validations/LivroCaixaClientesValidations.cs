#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ILivroCaixaClientesValidation
{
    Task<string> ValidateReg(Models.LivroCaixaClientes reg, ILivroCaixaClientesService service, ILivroCaixaReader livrocaixaReader, IClientesReader clientesReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, ILivroCaixaClientesService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class LivroCaixaClientesValidation : ILivroCaixaClientesValidation
{
    public async Task<string> CanDelete(int id, ILivroCaixaClientesService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.LivroCaixaClientes reg, ILivroCaixaClientesService service, ILivroCaixaReader livrocaixaReader, IClientesReader clientesReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
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