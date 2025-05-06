#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IPaisesValidation
{
    Task<string> ValidateReg(Models.Paises reg, IPaisesService service, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class PaisesValidation : IPaisesValidation
{
    public async Task<string> ValidateReg(Models.Paises reg, IPaisesService service, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        if (await IsDuplicado(reg, service, uri))
            return $"Paises '{reg.Nome}' já cadastrado.";
        return string.Empty;
    }

    private async Task<bool> IsDuplicado(Models.Paises reg, IPaisesService service, string uri)
    {
        var existingPaises = (await service.Filter(new Filters.FilterPaises { Nome = reg.Nome }, uri)).FirstOrDefault(); // TRACK 10042025
        return existingPaises != null && existingPaises.Id > 0 && existingPaises.Id != reg.Id;
    }
}