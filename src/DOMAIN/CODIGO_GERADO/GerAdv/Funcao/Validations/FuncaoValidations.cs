#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IFuncaoValidation
{
    Task<string> ValidateReg(Models.Funcao reg, IFuncaoService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, IFuncaoService service, IFuncionariosService funcionariosService, IPrepostosService prepostosService, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class FuncaoValidation : IFuncaoValidation
{
    public async Task<string> CanDelete(int id, IFuncaoService service, IFuncionariosService funcionariosService, IPrepostosService prepostosService, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        var funcionariosExists0 = await funcionariosService.Filter(new Filters.FilterFuncionarios { Funcao = id }, uri);
        if (funcionariosExists0 != null && funcionariosExists0.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Colaborador associados a ele.";
        var prepostosExists1 = await prepostosService.Filter(new Filters.FilterPrepostos { Funcao = id }, uri);
        if (prepostosExists1 != null && prepostosExists1.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Prepostos associados a ele.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.Funcao reg, IFuncaoService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Descricao))
            return "Descricao é obrigatório";
        return string.Empty;
    }
}