#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IRitoValidation
{
    Task<string> ValidateReg(Models.Rito reg, IRitoService service, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class RitoValidation : IRitoValidation
{
    public async Task<string> ValidateReg(Models.Rito reg, IRitoService service, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Descricao))
            return "Descricao é obrigatório";
        if (await IsDuplicado(reg, service, uri))
            return $"Rito '{reg.Descricao}' já cadastrado.";
        return string.Empty;
    }

    private async Task<bool> IsDuplicado(Models.Rito reg, IRitoService service, string uri)
    {
        var existingRito = (await service.Filter(new Filters.FilterRito { Descricao = reg.Descricao }, uri)).FirstOrDefault(); // TRACK 10042025
        return existingRito != null && existingRito.Id > 0 && existingRito.Id != reg.Id;
    }
}