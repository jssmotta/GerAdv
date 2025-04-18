#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoEnderecoValidation
{
    Task<string> ValidateReg(Models.TipoEndereco reg, ITipoEnderecoService service, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class TipoEnderecoValidation : ITipoEnderecoValidation
{
    public async Task<string> ValidateReg(Models.TipoEndereco reg, ITipoEnderecoService service, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Descricao))
            return "Descricao é obrigatório";
        if (await IsDuplicado(reg, service, uri))
            return $"TipoEndereco '{reg.Descricao}' já cadastrado.";
        return string.Empty;
    }

    private async Task<bool> IsDuplicado(Models.TipoEndereco reg, ITipoEnderecoService service, string uri)
    {
        var existingTipoEndereco = (await service.Filter(new Filters.FilterTipoEndereco { Descricao = reg.Descricao }, uri)).FirstOrDefault(); // TRACK 10042025
        return existingTipoEndereco != null && existingTipoEndereco.Id > 0 && existingTipoEndereco.Id != reg.Id;
    }
}