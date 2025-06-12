#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IPontoVirtualAcessosValidation
{
    Task<string> ValidateReg(Models.PontoVirtualAcessos reg, IPontoVirtualAcessosService service, IOperadorReader operadorReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, IPontoVirtualAcessosService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class PontoVirtualAcessosValidation : IPontoVirtualAcessosValidation
{
    public async Task<string> CanDelete(int id, IPontoVirtualAcessosService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.PontoVirtualAcessos reg, IPontoVirtualAcessosService service, IOperadorReader operadorReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
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