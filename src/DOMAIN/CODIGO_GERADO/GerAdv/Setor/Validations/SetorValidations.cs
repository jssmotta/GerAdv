#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ISetorValidation
{
    Task<string> ValidateReg(Models.Setor reg, ISetorService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, ISetorService service, IPrepostosService prepostosService, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class SetorValidation : ISetorValidation
{
    public async Task<string> CanDelete(int id, ISetorService service, IPrepostosService prepostosService, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        var prepostosExists0 = await prepostosService.Filter(new Filters.FilterPrepostos { Setor = id }, uri);
        if (prepostosExists0 != null && prepostosExists0.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Prepostos associados a ele.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.Setor reg, ISetorService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Descricao))
            return "Descrição é obrigatório";
        if (await IsDuplicado(reg, service, uri))
            return $"Setor '{reg.Descricao}'  - Descricao";
        return string.Empty;
    }

    private async Task<bool> IsDuplicado(Models.Setor reg, ISetorService service, string uri)
    {
        var existingSetor = (await service.Filter(new Filters.FilterSetor { Descricao = reg.Descricao }, uri)).FirstOrDefault(); // TRACK 10042025
        return existingSetor != null && existingSetor.Id > 0 && existingSetor.Id != reg.Id;
    }
}