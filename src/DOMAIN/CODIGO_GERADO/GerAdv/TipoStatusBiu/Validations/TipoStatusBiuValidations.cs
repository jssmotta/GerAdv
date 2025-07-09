#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoStatusBiuValidation
{
    Task<string> ValidateReg(Models.TipoStatusBiu reg, ITipoStatusBiuService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, ITipoStatusBiuService service, IStatusBiuService statusbiuService, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class TipoStatusBiuValidation : ITipoStatusBiuValidation
{
    public async Task<string> CanDelete(int id, ITipoStatusBiuService service, IStatusBiuService statusbiuService, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        var statusbiuExists0 = await statusbiuService.Filter(new Filters.FilterStatusBiu { TipoStatusBiu = id }, uri);
        if (statusbiuExists0 != null && statusbiuExists0.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Status Biu associados a ele.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.TipoStatusBiu reg, ITipoStatusBiuService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        if (await IsDuplicado(reg, service, uri))
            return $"Staus  Usuários '{reg.Nome}'  - Nome";
        return string.Empty;
    }

    private async Task<bool> IsDuplicado(Models.TipoStatusBiu reg, ITipoStatusBiuService service, string uri)
    {
        var existingTipoStatusBiu = (await service.Filter(new Filters.FilterTipoStatusBiu { Nome = reg.Nome }, uri)).FirstOrDefault(); // TRACK 10042025
        return existingTipoStatusBiu != null && existingTipoStatusBiu.Id > 0 && existingTipoStatusBiu.Id != reg.Id;
    }
}