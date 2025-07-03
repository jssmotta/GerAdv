#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProcessOutputEngineValidation
{
    Task<string> ValidateReg(Models.ProcessOutputEngine reg, IProcessOutputEngineService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, IProcessOutputEngineService service, IProcessOutputRequestService processoutputrequestService, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class ProcessOutputEngineValidation : IProcessOutputEngineValidation
{
    public async Task<string> CanDelete(int id, IProcessOutputEngineService service, IProcessOutputRequestService processoutputrequestService, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        var processoutputrequestExists = await processoutputrequestService.Filter(new Filters.FilterProcessOutputRequest { ProcessOutputEngine = id }, uri);
        if (processoutputrequestExists != null && processoutputrequestExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Process Output Request associados a ele.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.ProcessOutputEngine reg, IProcessOutputEngineService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        if (await IsDuplicado(reg, service, uri))
            return $"Process Output Engine '{reg.Nome}' Campo e/ou Database e/ou Tabela e/ou Valor";
        return string.Empty;
    }

    private async Task<bool> IsDuplicado(Models.ProcessOutputEngine reg, IProcessOutputEngineService service, string uri)
    {
        var existingProcessOutputEngine = (await service.Filter(new Filters.FilterProcessOutputEngine { Campo = reg.Campo, Database = reg.Database, Tabela = reg.Tabela, Valor = reg.Valor }, uri)).FirstOrDefault(); // TRACK 10042025
        return existingProcessOutputEngine != null && existingProcessOutputEngine.Id > 0 && existingProcessOutputEngine.Id != reg.Id;
    }
}