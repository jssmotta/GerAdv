#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoValorProcessoValidation
{
    Task<string> ValidateReg(Models.TipoValorProcesso reg, ITipoValorProcessoService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, ITipoValorProcessoService service, IProValoresService provaloresService, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class TipoValorProcessoValidation : ITipoValorProcessoValidation
{
    public async Task<string> CanDelete(int id, ITipoValorProcessoService service, IProValoresService provaloresService, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        var provaloresExists0 = await provaloresService.Filter(new Filters.FilterProValores { TipoValorProcesso = id }, uri);
        if (provaloresExists0 != null && provaloresExists0.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Pro Valores associados a ele.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.TipoValorProcesso reg, ITipoValorProcessoService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Descricao))
            return "Descrição é obrigatório";
        if (await IsDuplicado(reg, service, uri))
            return $"Tipo Valor Processo '{reg.Descricao}'  - Descricao";
        return string.Empty;
    }

    private async Task<bool> IsDuplicado(Models.TipoValorProcesso reg, ITipoValorProcessoService service, string uri)
    {
        var existingTipoValorProcesso = (await service.Filter(new Filters.FilterTipoValorProcesso { Descricao = reg.Descricao }, uri)).FirstOrDefault(); // TRACK 10042025
        return existingTipoValorProcesso != null && existingTipoValorProcesso.Id > 0 && existingTipoValorProcesso.Id != reg.Id;
    }
}