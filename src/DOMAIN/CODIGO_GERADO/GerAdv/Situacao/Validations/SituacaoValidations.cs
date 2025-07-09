#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ISituacaoValidation
{
    Task<string> ValidateReg(Models.Situacao reg, ISituacaoService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, ISituacaoService service, IProcessosService processosService, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class SituacaoValidation : ISituacaoValidation
{
    public async Task<string> CanDelete(int id, ISituacaoService service, IProcessosService processosService, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        var processosExists0 = await processosService.Filter(new Filters.FilterProcessos { Situacao = id }, uri);
        if (processosExists0 != null && processosExists0.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Processos associados a ele.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.Situacao reg, ISituacaoService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        return string.Empty;
    }
}