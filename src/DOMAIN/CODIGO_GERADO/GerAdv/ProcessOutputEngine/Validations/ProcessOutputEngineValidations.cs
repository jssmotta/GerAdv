#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProcessOutputEngineValidation
{
    Task<string> ValidateReg(Models.ProcessOutputEngine reg, IProcessOutputEngineService service, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class ProcessOutputEngineValidation : IProcessOutputEngineValidation
{
    public async Task<string> ValidateReg(Models.ProcessOutputEngine reg, IProcessOutputEngineService service, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        if (await IsDuplicado(reg, service, uri))
            return $"ProcessOutputEngine '{reg.Nome}' já cadastrado.";
        return string.Empty;
    }

    private async Task<bool> IsDuplicado(Models.ProcessOutputEngine reg, IProcessOutputEngineService service, string uri)
    {
        var existingProcessOutputEngine = (await service.Filter(new Filters.FilterProcessOutputEngine { Campo = reg.Campo, Database = reg.Database, Tabela = reg.Tabela, Valor = reg.Valor }, uri)).FirstOrDefault(); // TRACK 10042025
        return existingProcessOutputEngine != null && existingProcessOutputEngine.Id > 0 && existingProcessOutputEngine.Id != reg.Id;
    }
}