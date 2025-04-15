#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAgendaStatusValidation
{
    Task<string> ValidateReg(Models.AgendaStatus reg, IAgendaStatusService service, IAgendaReader agendaReader, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class AgendaStatusValidation : IAgendaStatusValidation
{
    public async Task<string> ValidateReg(Models.AgendaStatus reg, IAgendaStatusService service, IAgendaReader agendaReader, [FromRoute, Required] string uri, SqlConnection oCnn)
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

        return string.Empty;
    }
}