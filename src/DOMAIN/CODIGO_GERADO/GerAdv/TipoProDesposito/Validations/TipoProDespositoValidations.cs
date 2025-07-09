#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoProDespositoValidation
{
    Task<string> ValidateReg(Models.TipoProDesposito reg, ITipoProDespositoService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, ITipoProDespositoService service, IProDepositosService prodepositosService, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class TipoProDespositoValidation : ITipoProDespositoValidation
{
    public async Task<string> CanDelete(int id, ITipoProDespositoService service, IProDepositosService prodepositosService, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        var prodepositosExists0 = await prodepositosService.Filter(new Filters.FilterProDepositos { TipoProDesposito = id }, uri);
        if (prodepositosExists0 != null && prodepositosExists0.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Pro Depositos associados a ele.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.TipoProDesposito reg, ITipoProDespositoService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        return string.Empty;
    }
}