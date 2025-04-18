#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProcessosObsReportValidation
{
    Task<string> ValidateReg(Models.ProcessosObsReport reg, IProcessosObsReportService service, IProcessosReader processosReader, IHistoricoReader historicoReader, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class ProcessosObsReportValidation : IProcessosObsReportValidation
{
    public async Task<string> ValidateReg(Models.ProcessosObsReport reg, IProcessosObsReportService service, IProcessosReader processosReader, IHistoricoReader historicoReader, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        // Processos
        if (!reg.Processo.IsEmptyIDNumber())
        {
            var regProcessos = processosReader.Read(reg.Processo, oCnn);
            if (regProcessos == null || regProcessos.Id != reg.Processo)
            {
                return $"Processos não encontrado ({regProcessos?.Id}).";
            }
        }

        // Historico
        if (!reg.Historico.IsEmptyIDNumber())
        {
            var regHistorico = historicoReader.Read(reg.Historico, oCnn);
            if (regHistorico == null || regHistorico.Id != reg.Historico)
            {
                return $"Historico não encontrado ({regHistorico?.Id}).";
            }
        }

        return string.Empty;
    }
}