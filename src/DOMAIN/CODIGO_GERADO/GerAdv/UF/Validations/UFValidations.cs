#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IUFValidation
{
    Task<string> ValidateReg(Models.UF reg, IUFService service, IPaisesReader paisesReader, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class UFValidation : IUFValidation
{
    public async Task<string> ValidateReg(Models.UF reg, IUFService service, IPaisesReader paisesReader, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.IdUF))
            return "ID é obrigatório";
        if (await IsDuplicado(reg, service, uri))
            return $"UF '{reg.IdUF}' já cadastrado.";
        // Paises
        if (!reg.Pais.IsEmptyIDNumber())
        {
            var regPaises = paisesReader.Read(reg.Pais, oCnn);
            if (regPaises == null || regPaises.Id != reg.Pais)
            {
                return $"Paises não encontrado ({regPaises?.Id}).";
            }
        }

        return string.Empty;
    }

    private async Task<bool> IsDuplicado(Models.UF reg, IUFService service, string uri)
    {
        var existingUF = (await service.Filter(new Filters.FilterUF { IdUF = reg.IdUF, Pais = reg.Pais }, uri)).FirstOrDefault(); // TRACK 10042025
        return existingUF != null && existingUF.Id > 0 && existingUF.Id != reg.Id;
    }
}