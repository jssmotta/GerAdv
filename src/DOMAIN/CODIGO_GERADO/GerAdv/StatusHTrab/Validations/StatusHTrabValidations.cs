#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IStatusHTrabValidation
{
    Task<string> ValidateReg(Models.StatusHTrab reg, IStatusHTrabService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, IStatusHTrabService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class StatusHTrabValidation : IStatusHTrabValidation
{
    public async Task<string> CanDelete(int id, IStatusHTrabService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.StatusHTrab reg, IStatusHTrabService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Descricao))
            return "Descrição é obrigatório";
        return string.Empty;
    }
}