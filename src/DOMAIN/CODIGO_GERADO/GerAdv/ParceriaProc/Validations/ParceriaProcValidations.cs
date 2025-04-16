#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IParceriaProcValidation
{
    Task<string> ValidateReg(Models.ParceriaProc reg, IParceriaProcService service, IAdvogadosReader advogadosReader, IProcessosReader processosReader, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class ParceriaProcValidation : IParceriaProcValidation
{
    public async Task<string> ValidateReg(Models.ParceriaProc reg, IParceriaProcService service, IAdvogadosReader advogadosReader, IProcessosReader processosReader, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        // Advogados
        if (reg.Advogado.IsEmptyIDNumber())
        {
            var regAdvogados = advogadosReader.Read(reg.Advogado, oCnn);
            if (regAdvogados == null || regAdvogados.Id != reg.Advogado)
            {
                return $"Advogados não encontrado ({regAdvogados?.Id}).";
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