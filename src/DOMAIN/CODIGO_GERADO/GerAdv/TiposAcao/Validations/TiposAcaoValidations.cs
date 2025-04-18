#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITiposAcaoValidation
{
    Task<string> ValidateReg(Models.TiposAcao reg, ITiposAcaoService service, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class TiposAcaoValidation : ITiposAcaoValidation
{
    public async Task<string> ValidateReg(Models.TiposAcao reg, ITiposAcaoService service, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        if (await IsDuplicado(reg, service, uri))
            return $"TiposAcao '{reg.Nome}' já cadastrado.";
        return string.Empty;
    }

    private async Task<bool> IsDuplicado(Models.TiposAcao reg, ITiposAcaoService service, string uri)
    {
        var existingTiposAcao = (await service.Filter(new Filters.FilterTiposAcao { Nome = reg.Nome }, uri)).FirstOrDefault(); // TRACK 10042025
        return existingTiposAcao != null && existingTiposAcao.Id > 0 && existingTiposAcao.Id != reg.Id;
    }
}