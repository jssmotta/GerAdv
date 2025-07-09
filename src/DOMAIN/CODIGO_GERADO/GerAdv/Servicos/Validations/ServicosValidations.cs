#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IServicosValidation
{
    Task<string> ValidateReg(Models.Servicos reg, IServicosService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, IServicosService service, IHorasTrabService horastrabService, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class ServicosValidation : IServicosValidation
{
    public async Task<string> CanDelete(int id, IServicosService service, IHorasTrabService horastrabService, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        var horastrabExists0 = await horastrabService.Filter(new Filters.FilterHorasTrab { Servico = id }, uri);
        if (horastrabExists0 != null && horastrabExists0.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Horas Trab associados a ele.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.Servicos reg, IServicosService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Descricao))
            return "Descrição é obrigatório";
        return string.Empty;
    }
}