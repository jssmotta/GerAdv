#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAlarmSMSValidation
{
    Task<string> ValidateReg(Models.AlarmSMS reg, IAlarmSMSService service, IOperadorReader operadorReader, IAgendaReader agendaReader, IRecadosReader recadosReader, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class AlarmSMSValidation : IAlarmSMSValidation
{
    public async Task<string> ValidateReg(Models.AlarmSMS reg, IAlarmSMSService service, IOperadorReader operadorReader, IAgendaReader agendaReader, IRecadosReader recadosReader, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Descricao))
            return "Descricao é obrigatório";
        // Operador
        if (reg.Operador.IsEmptyIDNumber())
        {
            var regOperador = operadorReader.Read(reg.Operador, oCnn);
            if (regOperador == null || regOperador.Id != reg.Operador)
            {
                return $"Operador não encontrado ({regOperador?.Id}).";
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

        // Recados
        if (reg.Recado.IsEmptyIDNumber())
        {
            var regRecados = recadosReader.Read(reg.Recado, oCnn);
            if (regRecados == null || regRecados.Id != reg.Recado)
            {
                return $"Recados não encontrado ({regRecados?.Id}).";
            }
        }

        return string.Empty;
    }
}