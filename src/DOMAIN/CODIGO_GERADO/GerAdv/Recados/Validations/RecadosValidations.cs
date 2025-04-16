#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IRecadosValidation
{
    Task<string> ValidateReg(Models.Recados reg, IRecadosService service, IProcessosReader processosReader, IClientesReader clientesReader, IHistoricoReader historicoReader, IContatoCRMReader contatocrmReader, ILigacoesReader ligacoesReader, IAgendaReader agendaReader, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class RecadosValidation : IRecadosValidation
{
    public async Task<string> ValidateReg(Models.Recados reg, IRecadosService service, IProcessosReader processosReader, IClientesReader clientesReader, IHistoricoReader historicoReader, IContatoCRMReader contatocrmReader, ILigacoesReader ligacoesReader, IAgendaReader agendaReader, [FromRoute, Required] string uri, SqlConnection oCnn)
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

        // Clientes
        if (reg.Cliente.IsEmptyIDNumber())
        {
            var regClientes = clientesReader.Read(reg.Cliente, oCnn);
            if (regClientes == null || regClientes.Id != reg.Cliente)
            {
                return $"Clientes não encontrado ({regClientes?.Id}).";
            }
        }

        // Historico
        if (reg.Historico.IsEmptyIDNumber())
        {
            var regHistorico = historicoReader.Read(reg.Historico, oCnn);
            if (regHistorico == null || regHistorico.Id != reg.Historico)
            {
                return $"Historico não encontrado ({regHistorico?.Id}).";
            }
        }

        // ContatoCRM
        if (reg.ContatoCRM.IsEmptyIDNumber())
        {
            var regContatoCRM = contatocrmReader.Read(reg.ContatoCRM, oCnn);
            if (regContatoCRM == null || regContatoCRM.Id != reg.ContatoCRM)
            {
                return $"Contato C R M não encontrado ({regContatoCRM?.Id}).";
            }
        }

        // Ligacoes
        if (reg.Ligacoes.IsEmptyIDNumber())
        {
            var regLigacoes = ligacoesReader.Read(reg.Ligacoes, oCnn);
            if (regLigacoes == null || regLigacoes.Id != reg.Ligacoes)
            {
                return $"Ligacoes não encontrado ({regLigacoes?.Id}).";
            }
        }

        // Agenda
        if (reg.Agenda.IsEmptyIDNumber())
        {
            var regAgenda = agendaReader.Read(reg.Agenda, oCnn);
            if (regAgenda == null || regAgenda.Id != reg.Agenda)
            {
                return $"Agenda não encontrado ({regAgenda?.Id}).";
            }
        }

        return string.Empty;
    }
}