#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IOponentesRepLegalValidation
{
    Task<string> ValidateReg(Models.OponentesRepLegal reg, IOponentesRepLegalService service, IOponentesReader oponentesReader, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class OponentesRepLegalValidation : IOponentesRepLegalValidation
{
    public async Task<string> ValidateReg(Models.OponentesRepLegal reg, IOponentesRepLegalService service, IOponentesReader oponentesReader, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        if (!string.IsNullOrWhiteSpace(reg.CPF) && await IsCpfDuplicado(reg, service, uri))
            return $"'Oponentes Rep Legal' com cpf '{reg.CPF.MaskCpf()}' já cadastrado.";
        // Oponentes
        if (reg.Oponente.IsEmptyIDNumber())
        {
            var regOponentes = oponentesReader.Read(reg.Oponente, oCnn);
            if (regOponentes == null || regOponentes.Id != reg.Oponente)
            {
                return $"Oponentes não encontrado ({regOponentes?.Id}).";
            }
        }

        return string.Empty;
    }

    private async Task<bool> IsCpfDuplicado(Models.OponentesRepLegal reg, IOponentesRepLegalService service, string uri)
    {
        var existingOponentesRepLegal = (await service.Filter(new Filters.FilterOponentesRepLegal { CPF = reg.CPF }, uri)).FirstOrDefault();
        return existingOponentesRepLegal != null && existingOponentesRepLegal.Id > 0 && existingOponentesRepLegal.Id != reg.Id;
    }
}