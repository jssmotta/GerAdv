#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IPenhoraValidation
{
    Task<string> ValidateReg(Models.Penhora reg, IPenhoraService service, IProcessosReader processosReader, IPenhoraStatusReader penhorastatusReader, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class PenhoraValidation : IPenhoraValidation
{
    public async Task<string> ValidateReg(Models.Penhora reg, IPenhoraService service, IProcessosReader processosReader, IPenhoraStatusReader penhorastatusReader, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        // Processos
        if (!reg.Processo.IsEmptyIDNumber())
        {
            var regProcessos = processosReader.Read(reg.Processo, oCnn);
            if (regProcessos == null || regProcessos.Id != reg.Processo)
            {
                return $"Processos não encontrado ({regProcessos?.Id}).";
            }
        }

        // PenhoraStatus
        if (!reg.PenhoraStatus.IsEmptyIDNumber())
        {
            var regPenhoraStatus = penhorastatusReader.Read(reg.PenhoraStatus, oCnn);
            if (regPenhoraStatus == null || regPenhoraStatus.Id != reg.PenhoraStatus)
            {
                return $"Penhora Status não encontrado ({regPenhoraStatus?.Id}).";
            }
        }

        return string.Empty;
    }
}