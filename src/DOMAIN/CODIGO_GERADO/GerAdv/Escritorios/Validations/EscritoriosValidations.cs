#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IEscritoriosValidation
{
    Task<string> ValidateReg(Models.Escritorios reg, IEscritoriosService service, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class EscritoriosValidation : IEscritoriosValidation
{
    public async Task<string> ValidateReg(Models.Escritorios reg, IEscritoriosService service, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        if (await IsDuplicado(reg, service, uri))
            return $"Escritorios '{reg.Nome}' já cadastrado.";
        if (!string.IsNullOrWhiteSpace(reg.CNPJ) && await IsCnpjDuplicado(reg, service, uri))
            return $"Escritorios com cnpj {reg.CNPJ.MaskCnpj()} já cadastrado.";
        return string.Empty;
    }

    private async Task<bool> IsDuplicado(Models.Escritorios reg, IEscritoriosService service, string uri)
    {
        var existingEscritorios = (await service.Filter(new Filters.FilterEscritorios { Nome = reg.Nome }, uri)).FirstOrDefault(); // TRACK 10042025
        return existingEscritorios != null && existingEscritorios.Id > 0 && existingEscritorios.Id != reg.Id;
    }

    private async Task<bool> IsCnpjDuplicado(Models.Escritorios reg, IEscritoriosService service, string uri)
    {
        var existingEscritorios = (await service.Filter(new Filters.FilterEscritorios { CNPJ = reg.CNPJ }, uri)).FirstOrDefault();
        return existingEscritorios != null && existingEscritorios.Id > 0 && existingEscritorios.Id != reg.Id;
    }
}