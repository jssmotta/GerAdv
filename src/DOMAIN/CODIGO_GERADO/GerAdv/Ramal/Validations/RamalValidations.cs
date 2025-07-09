#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IRamalValidation
{
    Task<string> ValidateReg(Models.Ramal reg, IRamalService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, IRamalService service, ILigacoesService ligacoesService, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class RamalValidation : IRamalValidation
{
    public async Task<string> CanDelete(int id, IRamalService service, ILigacoesService ligacoesService, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        var ligacoesExists0 = await ligacoesService.Filter(new Filters.FilterLigacoes { Ramal = id }, uri);
        if (ligacoesExists0 != null && ligacoesExists0.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Ligacoes associados a ele.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.Ramal reg, IRamalService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        return string.Empty;
    }
}