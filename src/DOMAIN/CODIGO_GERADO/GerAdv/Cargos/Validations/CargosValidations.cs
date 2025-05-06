#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ICargosValidation
{
    Task<string> ValidateReg(Models.Cargos reg, ICargosService service, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class CargosValidation : ICargosValidation
{
    public async Task<string> ValidateReg(Models.Cargos reg, ICargosService service, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        if (await IsDuplicado(reg, service, uri))
            return $"Cargos '{reg.Nome}' já cadastrado.";
        return string.Empty;
    }

    private async Task<bool> IsDuplicado(Models.Cargos reg, ICargosService service, string uri)
    {
        var existingCargos = (await service.Filter(new Filters.FilterCargos { Nome = reg.Nome }, uri)).FirstOrDefault(); // TRACK 10042025
        return existingCargos != null && existingCargos.Id > 0 && existingCargos.Id != reg.Id;
    }
}