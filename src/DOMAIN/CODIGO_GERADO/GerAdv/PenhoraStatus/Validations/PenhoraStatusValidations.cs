#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IPenhoraStatusValidation
{
    Task<string> ValidateReg(Models.PenhoraStatus reg, IPenhoraStatusService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, IPenhoraStatusService service, IPenhoraService penhoraService, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class PenhoraStatusValidation : IPenhoraStatusValidation
{
    public async Task<string> CanDelete(int id, IPenhoraStatusService service, IPenhoraService penhoraService, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        var penhoraExists0 = await penhoraService.Filter(new Filters.FilterPenhora { PenhoraStatus = id }, uri);
        if (penhoraExists0 != null && penhoraExists0.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Penhora associados a ele.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.PenhoraStatus reg, IPenhoraStatusService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        return string.Empty;
    }
}