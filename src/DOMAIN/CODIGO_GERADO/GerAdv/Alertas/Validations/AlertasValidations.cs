#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAlertasValidation
{
    Task<string> ValidateReg(Models.Alertas reg, IAlertasService service, IOperadorReader operadorReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, IAlertasService service, IAlertasEnviadosService alertasenviadosService, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class AlertasValidation : IAlertasValidation
{
    public async Task<string> CanDelete(int id, IAlertasService service, IAlertasEnviadosService alertasenviadosService, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        var alertasenviadosExists0 = await alertasenviadosService.Filter(new Filters.FilterAlertasEnviados { Alerta = id }, uri);
        if (alertasenviadosExists0 != null && alertasenviadosExists0.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Alertas Enviados associados a ele.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.Alertas reg, IAlertasService service, IOperadorReader operadorReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
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