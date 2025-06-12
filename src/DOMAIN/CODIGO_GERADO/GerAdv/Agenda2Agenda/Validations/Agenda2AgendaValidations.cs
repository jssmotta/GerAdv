#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAgenda2AgendaValidation
{
    Task<string> ValidateReg(Models.Agenda2Agenda reg, IAgenda2AgendaService service, IAgendaReader agendaReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, IAgenda2AgendaService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class Agenda2AgendaValidation : IAgenda2AgendaValidation
{
    public async Task<string> CanDelete(int id, IAgenda2AgendaService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.Agenda2Agenda reg, IAgenda2AgendaService service, IAgendaReader agendaReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        // Agenda
        if (!reg.Agenda.IsEmptyIDNumber())
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