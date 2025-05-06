#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IOperadorGruposAgendaOperadoresValidation
{
    Task<string> ValidateReg(Models.OperadorGruposAgendaOperadores reg, IOperadorGruposAgendaOperadoresService service, IOperadorGruposAgendaReader operadorgruposagendaReader, IOperadorReader operadorReader, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class OperadorGruposAgendaOperadoresValidation : IOperadorGruposAgendaOperadoresValidation
{
    public async Task<string> ValidateReg(Models.OperadorGruposAgendaOperadores reg, IOperadorGruposAgendaOperadoresService service, IOperadorGruposAgendaReader operadorgruposagendaReader, IOperadorReader operadorReader, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        // OperadorGruposAgenda
        if (!reg.OperadorGruposAgenda.IsEmptyIDNumber())
        {
            var regOperadorGruposAgenda = operadorgruposagendaReader.Read(reg.OperadorGruposAgenda, oCnn);
            if (regOperadorGruposAgenda == null || regOperadorGruposAgenda.Id != reg.OperadorGruposAgenda)
            {
                return $"Operador Grupos Agenda não encontrado ({regOperadorGruposAgenda?.Id}).";
            }
        }

        // Operador
        if (!reg.Operador.IsEmptyIDNumber())
        {
            var regOperador = operadorReader.Read(reg.Operador, oCnn);
            if (regOperador == null || regOperador.Id != reg.Operador)
            {
                return $"Operador não encontrado ({regOperador?.Id}).";
            }
        }

        return string.Empty;
    }
}