#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ISetorValidation
{
    Task<string> ValidateReg(Models.Setor reg, ISetorService service, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class SetorValidation : ISetorValidation
{
    public async Task<string> ValidateReg(Models.Setor reg, ISetorService service, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Descricao))
            return "Descricao é obrigatório";
        if (await IsDuplicado(reg, service, uri))
            return $"Setor '{reg.Descricao}' já cadastrado.";
        return string.Empty;
    }

    private async Task<bool> IsDuplicado(Models.Setor reg, ISetorService service, string uri)
    {
        var existingSetor = (await service.Filter(new Filters.FilterSetor { Descricao = reg.Descricao }, uri)).FirstOrDefault(); // TRACK 10042025
        return existingSetor != null && existingSetor.Id > 0 && existingSetor.Id != reg.Id;
    }
}