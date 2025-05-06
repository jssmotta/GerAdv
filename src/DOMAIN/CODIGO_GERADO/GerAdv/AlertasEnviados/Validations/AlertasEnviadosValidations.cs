#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAlertasEnviadosValidation
{
    Task<string> ValidateReg(Models.AlertasEnviados reg, IAlertasEnviadosService service, IOperadorReader operadorReader, IAlertasReader alertasReader, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class AlertasEnviadosValidation : IAlertasEnviadosValidation
{
    public async Task<string> ValidateReg(Models.AlertasEnviados reg, IAlertasEnviadosService service, IOperadorReader operadorReader, IAlertasReader alertasReader, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        // Operador
        if (!reg.Operador.IsEmptyIDNumber())
        {
            var regOperador = operadorReader.Read(reg.Operador, oCnn);
            if (regOperador == null || regOperador.Id != reg.Operador)
            {
                return $"Operador não encontrado ({regOperador?.Id}).";
            }
        }

        // Alertas
        if (!reg.Alerta.IsEmptyIDNumber())
        {
            var regAlertas = alertasReader.Read(reg.Alerta, oCnn);
            if (regAlertas == null || regAlertas.Id != reg.Alerta)
            {
                return $"Alertas não encontrado ({regAlertas?.Id}).";
            }
        }

        return string.Empty;
    }
}