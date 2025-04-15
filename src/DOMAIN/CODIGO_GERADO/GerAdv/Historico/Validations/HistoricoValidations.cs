#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IHistoricoValidation
{
    Task<string> ValidateReg(Models.Historico reg, IHistoricoService service, IProcessosReader processosReader, IPrecatoriaReader precatoriaReader, IApensoReader apensoReader, IFaseReader faseReader, IStatusAndamentoReader statusandamentoReader, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class HistoricoValidation : IHistoricoValidation
{
    public async Task<string> ValidateReg(Models.Historico reg, IHistoricoService service, IProcessosReader processosReader, IPrecatoriaReader precatoriaReader, IApensoReader apensoReader, IFaseReader faseReader, IStatusAndamentoReader statusandamentoReader, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        // Processos
        if (reg.Processo.IsEmptyIDNumber())
        {
            var regProcessos = processosReader.Read(reg.Processo, oCnn);
            if (regProcessos == null || regProcessos.Id != reg.Processo)
            {
                return $"Processos não encontrado ({regProcessos?.Id}).";
            }
        }

        // Precatoria
        if (reg.Precatoria.IsEmptyIDNumber())
        {
            var regPrecatoria = precatoriaReader.Read(reg.Precatoria, oCnn);
            if (regPrecatoria == null || regPrecatoria.Id != reg.Precatoria)
            {
                return $"Precatoria não encontrado ({regPrecatoria?.Id}).";
            }
        }

        // Apenso
        if (reg.Apenso.IsEmptyIDNumber())
        {
            var regApenso = apensoReader.Read(reg.Apenso, oCnn);
            if (regApenso == null || regApenso.Id != reg.Apenso)
            {
                return $"Apenso não encontrado ({regApenso?.Id}).";
            }
        }

        // Fase
        if (reg.Fase.IsEmptyIDNumber())
        {
            var regFase = faseReader.Read(reg.Fase, oCnn);
            if (regFase == null || regFase.Id != reg.Fase)
            {
                return $"Fase não encontrado ({regFase?.Id}).";
            }
        }

        // StatusAndamento
        if (reg.StatusAndamento.IsEmptyIDNumber())
        {
            var regStatusAndamento = statusandamentoReader.Read(reg.StatusAndamento, oCnn);
            if (regStatusAndamento == null || regStatusAndamento.Id != reg.StatusAndamento)
            {
                return $"Status Andamento não encontrado ({regStatusAndamento?.Id}).";
            }
        }

        return string.Empty;
    }
}