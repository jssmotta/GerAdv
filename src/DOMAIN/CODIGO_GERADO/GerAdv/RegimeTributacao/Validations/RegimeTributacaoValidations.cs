#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IRegimeTributacaoValidation
{
    Task<string> ValidateReg(Models.RegimeTributacao reg, IRegimeTributacaoService service, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class RegimeTributacaoValidation : IRegimeTributacaoValidation
{
    public async Task<string> ValidateReg(Models.RegimeTributacao reg, IRegimeTributacaoService service, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        if (await IsDuplicado(reg, service, uri))
            return $"RegimeTributacao '{reg.Nome}' já cadastrado.";
        return string.Empty;
    }

    private async Task<bool> IsDuplicado(Models.RegimeTributacao reg, IRegimeTributacaoService service, string uri)
    {
        var existingRegimeTributacao = (await service.Filter(new Filters.FilterRegimeTributacao { Nome = reg.Nome }, uri)).FirstOrDefault(); // TRACK 10042025
        return existingRegimeTributacao != null && existingRegimeTributacao.Id > 0 && existingRegimeTributacao.Id != reg.Id;
    }
}