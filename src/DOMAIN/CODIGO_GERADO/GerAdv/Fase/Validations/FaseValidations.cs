#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IFaseValidation
{
    Task<string> ValidateReg(Models.Fase reg, IFaseService service, IJusticaReader justicaReader, IAreaReader areaReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, IFaseService service, IHistoricoService historicoService, IProDepositosService prodepositosService, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class FaseValidation : IFaseValidation
{
    public async Task<string> CanDelete(int id, IFaseService service, IHistoricoService historicoService, IProDepositosService prodepositosService, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        var historicoExists = await historicoService.Filter(new Filters.FilterHistorico { Fase = id }, uri);
        if (historicoExists != null && historicoExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Historico associados a ele.";
        var prodepositosExists = await prodepositosService.Filter(new Filters.FilterProDepositos { Fase = id }, uri);
        if (prodepositosExists != null && prodepositosExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Pro Depositos associados a ele.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.Fase reg, IFaseService service, IJusticaReader justicaReader, IAreaReader areaReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Descricao))
            return "Descricao é obrigatório";
        // Justica
        if (!reg.Justica.IsEmptyIDNumber())
        {
            var regJustica = justicaReader.Read(reg.Justica, oCnn);
            if (regJustica == null || regJustica.Id != reg.Justica)
            {
                return $"Justica não encontrado ({regJustica?.Id}).";
            }
        }

        // Area
        if (!reg.Area.IsEmptyIDNumber())
        {
            var regArea = areaReader.Read(reg.Area, oCnn);
            if (regArea == null || regArea.Id != reg.Area)
            {
                return $"Area não encontrado ({regArea?.Id}).";
            }
        }

        return string.Empty;
    }
}