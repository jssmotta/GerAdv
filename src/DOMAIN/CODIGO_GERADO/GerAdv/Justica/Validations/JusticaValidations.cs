#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IJusticaValidation
{
    Task<string> ValidateReg(Models.Justica reg, IJusticaService service, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class JusticaValidation : IJusticaValidation
{
    public async Task<string> ValidateReg(Models.Justica reg, IJusticaService service, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        if (await IsDuplicado(reg, service, uri))
            return $"Justica '{reg.Nome}' já cadastrado.";
        return string.Empty;
    }

    private async Task<bool> IsDuplicado(Models.Justica reg, IJusticaService service, string uri)
    {
        var existingJustica = (await service.Filter(new Filters.FilterJustica { Nome = reg.Nome }, uri)).FirstOrDefault(); // TRACK 10042025
        return existingJustica != null && existingJustica.Id > 0 && existingJustica.Id != reg.Id;
    }
}