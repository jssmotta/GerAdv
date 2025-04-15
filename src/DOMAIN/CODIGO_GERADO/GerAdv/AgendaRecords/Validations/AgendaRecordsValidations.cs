#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAgendaRecordsValidation
{
    Task<string> ValidateReg(Models.AgendaRecords reg, IAgendaRecordsService service, IAgendaReader agendaReader, IClientesSociosReader clientessociosReader, IColaboradoresReader colaboradoresReader, IForoReader foroReader, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class AgendaRecordsValidation : IAgendaRecordsValidation
{
    public async Task<string> ValidateReg(Models.AgendaRecords reg, IAgendaRecordsService service, IAgendaReader agendaReader, IClientesSociosReader clientessociosReader, IColaboradoresReader colaboradoresReader, IForoReader foroReader, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        // Agenda
        if (reg.Agenda.IsEmptyIDNumber())
        {
            var regAgenda = agendaReader.Read(reg.Agenda, oCnn);
            if (regAgenda == null || regAgenda.Id != reg.Agenda)
            {
                return $"Agenda não encontrado ({regAgenda?.Id}).";
            }
        }

        // ClientesSocios
        if (reg.ClientesSocios.IsEmptyIDNumber())
        {
            var regClientesSocios = clientessociosReader.Read(reg.ClientesSocios, oCnn);
            if (regClientesSocios == null || regClientesSocios.Id != reg.ClientesSocios)
            {
                return $"Clientes Socios não encontrado ({regClientesSocios?.Id}).";
            }
        }

        // Colaboradores
        if (reg.Colaborador.IsEmptyIDNumber())
        {
            var regColaboradores = colaboradoresReader.Read(reg.Colaborador, oCnn);
            if (regColaboradores == null || regColaboradores.Id != reg.Colaborador)
            {
                return $"Colaboradores não encontrado ({regColaboradores?.Id}).";
            }
        }

        // Foro
        if (reg.Foro.IsEmptyIDNumber())
        {
            var regForo = foroReader.Read(reg.Foro, oCnn);
            if (regForo == null || regForo.Id != reg.Foro)
            {
                return $"Foro não encontrado ({regForo?.Id}).";
            }
        }

        return string.Empty;
    }
}