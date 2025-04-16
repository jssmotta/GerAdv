#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAtividadesValidation
{
    Task<string> ValidateReg(Models.Atividades reg, IAtividadesService service, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class AtividadesValidation : IAtividadesValidation
{
    public async Task<string> ValidateReg(Models.Atividades reg, IAtividadesService service, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Descricao))
            return "Descricao é obrigatório";
        if (await IsDuplicado(reg, service, uri))
            return $"Atividades '{reg.Descricao}' já cadastrado.";
        return string.Empty;
    }

    private async Task<bool> IsDuplicado(Models.Atividades reg, IAtividadesService service, string uri)
    {
        var existingAtividades = (await service.Filter(new Filters.FilterAtividades { Descricao = reg.Descricao }, uri)).FirstOrDefault(); // TRACK 10042025
        return existingAtividades != null && existingAtividades.Id > 0 && existingAtividades.Id != reg.Id;
    }
}