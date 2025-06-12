#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IBensClassificacaoValidation
{
    Task<string> ValidateReg(Models.BensClassificacao reg, IBensClassificacaoService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, IBensClassificacaoService service, IBensMateriaisService bensmateriaisService, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class BensClassificacaoValidation : IBensClassificacaoValidation
{
    public async Task<string> CanDelete(int id, IBensClassificacaoService service, IBensMateriaisService bensmateriaisService, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        var bensmateriaisExists = await bensmateriaisService.Filter(new Filters.FilterBensMateriais { BensClassificacao = id }, uri);
        if (bensmateriaisExists != null && bensmateriaisExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Bens Materiais associados a ele.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.BensClassificacao reg, IBensClassificacaoService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        if (await IsDuplicado(reg, service, uri))
            return $"BensClassificacao '{reg.Nome}' já cadastrado.";
        return string.Empty;
    }

    private async Task<bool> IsDuplicado(Models.BensClassificacao reg, IBensClassificacaoService service, string uri)
    {
        var existingBensClassificacao = (await service.Filter(new Filters.FilterBensClassificacao { Nome = reg.Nome }, uri)).FirstOrDefault(); // TRACK 10042025
        return existingBensClassificacao != null && existingBensClassificacao.Id > 0 && existingBensClassificacao.Id != reg.Id;
    }
}