#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoStatusBiuValidation
{
    Task<string> ValidateReg(Models.TipoStatusBiu reg, ITipoStatusBiuService service, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class TipoStatusBiuValidation : ITipoStatusBiuValidation
{
    public async Task<string> ValidateReg(Models.TipoStatusBiu reg, ITipoStatusBiuService service, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        if (await IsDuplicado(reg, service, uri))
            return $"TipoStatusBiu '{reg.Nome}' já cadastrado.";
        return string.Empty;
    }

    private async Task<bool> IsDuplicado(Models.TipoStatusBiu reg, ITipoStatusBiuService service, string uri)
    {
        var existingTipoStatusBiu = (await service.Filter(new Filters.FilterTipoStatusBiu { Nome = reg.Nome }, uri)).FirstOrDefault(); // TRACK 10042025
        return existingTipoStatusBiu != null && existingTipoStatusBiu.Id > 0 && existingTipoStatusBiu.Id != reg.Id;
    }
}