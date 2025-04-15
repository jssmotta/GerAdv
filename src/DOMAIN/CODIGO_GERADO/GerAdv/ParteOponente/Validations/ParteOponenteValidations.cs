#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IParteOponenteValidation
{
    Task<string> ValidateReg(Models.ParteOponente reg, IParteOponenteService service, IOponentesReader oponentesReader, IProcessosReader processosReader, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class ParteOponenteValidation : IParteOponenteValidation
{
    public async Task<string> ValidateReg(Models.ParteOponente reg, IParteOponenteService service, IOponentesReader oponentesReader, IProcessosReader processosReader, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        // Oponentes
        if (reg.Oponente.IsEmptyIDNumber())
        {
            var regOponentes = oponentesReader.Read(reg.Oponente, oCnn);
            if (regOponentes == null || regOponentes.Id != reg.Oponente)
            {
                return $"Oponentes não encontrado ({regOponentes?.Id}).";
            }
        }

        // Processos
        if (reg.Processo.IsEmptyIDNumber())
        {
            var regProcessos = processosReader.Read(reg.Processo, oCnn);
            if (regProcessos == null || regProcessos.Id != reg.Processo)
            {
                return $"Processos não encontrado ({regProcessos?.Id}).";
            }
        }

        return string.Empty;
    }
}