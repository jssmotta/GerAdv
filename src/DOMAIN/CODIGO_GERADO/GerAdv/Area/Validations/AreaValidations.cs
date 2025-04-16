#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAreaValidation
{
    Task<string> ValidateReg(Models.Area reg, IAreaService service, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class AreaValidation : IAreaValidation
{
    public async Task<string> ValidateReg(Models.Area reg, IAreaService service, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Descricao))
            return "Descricao é obrigatório";
        if (await IsDuplicado(reg, service, uri))
            return $"Area '{reg.Descricao}' já cadastrado.";
        return string.Empty;
    }

    private async Task<bool> IsDuplicado(Models.Area reg, IAreaService service, string uri)
    {
        var existingArea = (await service.Filter(new Filters.FilterArea { Descricao = reg.Descricao }, uri)).FirstOrDefault(); // TRACK 10042025
        return existingArea != null && existingArea.Id > 0 && existingArea.Id != reg.Id;
    }
}