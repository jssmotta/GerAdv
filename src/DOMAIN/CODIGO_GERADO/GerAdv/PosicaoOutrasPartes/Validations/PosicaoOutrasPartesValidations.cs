#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IPosicaoOutrasPartesValidation
{
    Task<string> ValidateReg(Models.PosicaoOutrasPartes reg, IPosicaoOutrasPartesService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, IPosicaoOutrasPartesService service, ITerceirosService terceirosService, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class PosicaoOutrasPartesValidation : IPosicaoOutrasPartesValidation
{
    public async Task<string> CanDelete(int id, IPosicaoOutrasPartesService service, ITerceirosService terceirosService, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        var terceirosExists0 = await terceirosService.Filter(new Filters.FilterTerceiros { Situacao = id }, uri);
        if (terceirosExists0 != null && terceirosExists0.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Terceiros associados a ele.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.PosicaoOutrasPartes reg, IPosicaoOutrasPartesService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Descricao))
            return "Descrição é obrigatório";
        return string.Empty;
    }
}