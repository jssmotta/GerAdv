#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoCompromissoValidation
{
    Task<string> ValidateReg(Models.TipoCompromisso reg, ITipoCompromissoService service, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class TipoCompromissoValidation : ITipoCompromissoValidation
{
    public async Task<string> ValidateReg(Models.TipoCompromisso reg, ITipoCompromissoService service, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Descricao))
            return "Descricao é obrigatório";
        if (await IsDuplicado(reg, service, uri))
            return $"TipoCompromisso '{reg.Descricao}' já cadastrado.";
        return string.Empty;
    }

    private async Task<bool> IsDuplicado(Models.TipoCompromisso reg, ITipoCompromissoService service, string uri)
    {
        var existingTipoCompromisso = (await service.Filter(new Filters.FilterTipoCompromisso { Descricao = reg.Descricao }, uri)).FirstOrDefault(); // TRACK 10042025
        return existingTipoCompromisso != null && existingTipoCompromisso.Id > 0 && existingTipoCompromisso.Id != reg.Id;
    }
}