#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoValorProcessoValidation
{
    Task<string> ValidateReg(Models.TipoValorProcesso reg, ITipoValorProcessoService service, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class TipoValorProcessoValidation : ITipoValorProcessoValidation
{
    public async Task<string> ValidateReg(Models.TipoValorProcesso reg, ITipoValorProcessoService service, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Descricao))
            return "Descricao é obrigatório";
        if (await IsDuplicado(reg, service, uri))
            return $"TipoValorProcesso '{reg.Descricao}' já cadastrado.";
        return string.Empty;
    }

    private async Task<bool> IsDuplicado(Models.TipoValorProcesso reg, ITipoValorProcessoService service, string uri)
    {
        var existingTipoValorProcesso = (await service.Filter(new Filters.FilterTipoValorProcesso { Descricao = reg.Descricao }, uri)).FirstOrDefault(); // TRACK 10042025
        return existingTipoValorProcesso != null && existingTipoValorProcesso.Id > 0 && existingTipoValorProcesso.Id != reg.Id;
    }
}