#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IStatusAndamentoValidation
{
    Task<string> ValidateReg(Models.StatusAndamento reg, IStatusAndamentoService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, IStatusAndamentoService service, IHistoricoService historicoService, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class StatusAndamentoValidation : IStatusAndamentoValidation
{
    public async Task<string> CanDelete(int id, IStatusAndamentoService service, IHistoricoService historicoService, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        var historicoExists = await historicoService.Filter(new Filters.FilterHistorico { StatusAndamento = id }, uri);
        if (historicoExists != null && historicoExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Historico associados a ele.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.StatusAndamento reg, IStatusAndamentoService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        return string.Empty;
    }
}