#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IHistoricoValidation
{
    Task<string> ValidateReg(Models.Historico reg, IHistoricoService service, IProcessosReader processosReader, IPrecatoriaReader precatoriaReader, IApensoReader apensoReader, IFaseReader faseReader, IStatusAndamentoReader statusandamentoReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, IHistoricoService service, IProcessosObsReportService processosobsreportService, IRecadosService recadosService, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class HistoricoValidation : IHistoricoValidation
{
    public async Task<string> CanDelete(int id, IHistoricoService service, IProcessosObsReportService processosobsreportService, IRecadosService recadosService, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        var processosobsreportExists0 = await processosobsreportService.Filter(new Filters.FilterProcessosObsReport { Historico = id }, uri);
        if (processosobsreportExists0 != null && processosobsreportExists0.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Processos Obs Report associados a ele.";
        var recadosExists1 = await recadosService.Filter(new Filters.FilterRecados { Historico = id }, uri);
        if (recadosExists1 != null && recadosExists1.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Recados associados a ele.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.Historico reg, IHistoricoService service, IProcessosReader processosReader, IPrecatoriaReader precatoriaReader, IApensoReader apensoReader, IFaseReader faseReader, IStatusAndamentoReader statusandamentoReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
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

        // Precatoria
        if (!reg.Precatoria.IsEmptyIDNumber())
        {
            var regPrecatoria = precatoriaReader.Read(reg.Precatoria, oCnn);
            if (regPrecatoria == null || regPrecatoria.Id != reg.Precatoria)
            {
                return $"Precatoria não encontrado ({regPrecatoria?.Id}).";
            }
        }

        // Apenso
        if (!reg.Apenso.IsEmptyIDNumber())
        {
            var regApenso = apensoReader.Read(reg.Apenso, oCnn);
            if (regApenso == null || regApenso.Id != reg.Apenso)
            {
                return $"Apenso não encontrado ({regApenso?.Id}).";
            }
        }

        // Fase
        if (!reg.Fase.IsEmptyIDNumber())
        {
            var regFase = faseReader.Read(reg.Fase, oCnn);
            if (regFase == null || regFase.Id != reg.Fase)
            {
                return $"Fase não encontrado ({regFase?.Id}).";
            }
        }

        // StatusAndamento
        if (!reg.StatusAndamento.IsEmptyIDNumber())
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