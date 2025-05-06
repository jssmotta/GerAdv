#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ISMSAliceValidation
{
    Task<string> ValidateReg(Models.SMSAlice reg, ISMSAliceService service, IOperadorReader operadorReader, ITipoEMailReader tipoemailReader, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class SMSAliceValidation : ISMSAliceValidation
{
    public async Task<string> ValidateReg(Models.SMSAlice reg, ISMSAliceService service, IOperadorReader operadorReader, ITipoEMailReader tipoemailReader, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        if (await IsDuplicado(reg, service, uri))
            return $"SMSAlice '{reg.Nome}' já cadastrado.";
        // Operador
        if (!reg.Operador.IsEmptyIDNumber())
        {
            var regOperador = operadorReader.Read(reg.Operador, oCnn);
            if (regOperador == null || regOperador.Id != reg.Operador)
            {
                return $"Operador não encontrado ({regOperador?.Id}).";
            }
        }

        // TipoEMail
        if (!reg.TipoEMail.IsEmptyIDNumber())
        {
            var regTipoEMail = tipoemailReader.Read(reg.TipoEMail, oCnn);
            if (regTipoEMail == null || regTipoEMail.Id != reg.TipoEMail)
            {
                return $"Tipo E Mail não encontrado ({regTipoEMail?.Id}).";
            }
        }

        return string.Empty;
    }

    private async Task<bool> IsDuplicado(Models.SMSAlice reg, ISMSAliceService service, string uri)
    {
        var existingSMSAlice = (await service.Filter(new Filters.FilterSMSAlice { Nome = reg.Nome, Operador = reg.Operador }, uri)).FirstOrDefault(); // TRACK 10042025
        return existingSMSAlice != null && existingSMSAlice.Id > 0 && existingSMSAlice.Id != reg.Id;
    }
}