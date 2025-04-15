#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoEnderecoSistemaValidation
{
    Task<string> ValidateReg(Models.TipoEnderecoSistema reg, ITipoEnderecoSistemaService service, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class TipoEnderecoSistemaValidation : ITipoEnderecoSistemaValidation
{
    public async Task<string> ValidateReg(Models.TipoEnderecoSistema reg, ITipoEnderecoSistemaService service, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        if (await IsDuplicado(reg, service, uri))
            return $"TipoEnderecoSistema '{reg.Nome}' já cadastrado.";
        return string.Empty;
    }

    private async Task<bool> IsDuplicado(Models.TipoEnderecoSistema reg, ITipoEnderecoSistemaService service, string uri)
    {
        var existingTipoEnderecoSistema = (await service.Filter(new Filters.FilterTipoEnderecoSistema { Nome = reg.Nome }, uri)).FirstOrDefault(); // TRACK 10042025
        return existingTipoEnderecoSistema != null && existingTipoEnderecoSistema.Id > 0 && existingTipoEnderecoSistema.Id != reg.Id;
    }
}