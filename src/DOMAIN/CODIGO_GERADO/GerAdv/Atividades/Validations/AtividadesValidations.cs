#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAtividadesValidation
{
    Task<string> ValidateReg(Models.Atividades reg, IAtividadesService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, IAtividadesService service, IProcessosService processosService, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class AtividadesValidation : IAtividadesValidation
{
    public async Task<string> CanDelete(int id, IAtividadesService service, IProcessosService processosService, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        var processosExists0 = await processosService.Filter(new Filters.FilterProcessos { Atividade = id }, uri);
        if (processosExists0 != null && processosExists0.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Processos associados a ele.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.Atividades reg, IAtividadesService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Descricao))
            return "Descrição é obrigatório";
        if (await IsDuplicado(reg, service, uri))
            return $"Atividades '{reg.Descricao}'  - Descricao";
        return string.Empty;
    }

    private async Task<bool> IsDuplicado(Models.Atividades reg, IAtividadesService service, string uri)
    {
        var existingAtividades = (await service.Filter(new Filters.FilterAtividades { Descricao = reg.Descricao }, uri)).FirstOrDefault(); // TRACK 10042025
        return existingAtividades != null && existingAtividades.Id > 0 && existingAtividades.Id != reg.Id;
    }
}