#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoEMailValidation
{
    Task<string> ValidateReg(Models.TipoEMail reg, ITipoEMailService service, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class TipoEMailValidation : ITipoEMailValidation
{
    public async Task<string> ValidateReg(Models.TipoEMail reg, ITipoEMailService service, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        if (await IsDuplicado(reg, service, uri))
            return $"TipoEMail '{reg.Nome}' já cadastrado.";
        return string.Empty;
    }

    private async Task<bool> IsDuplicado(Models.TipoEMail reg, ITipoEMailService service, string uri)
    {
        var existingTipoEMail = (await service.Filter(new Filters.FilterTipoEMail { Nome = reg.Nome }, uri)).FirstOrDefault(); // TRACK 10042025
        return existingTipoEMail != null && existingTipoEMail.Id > 0 && existingTipoEMail.Id != reg.Id;
    }
}