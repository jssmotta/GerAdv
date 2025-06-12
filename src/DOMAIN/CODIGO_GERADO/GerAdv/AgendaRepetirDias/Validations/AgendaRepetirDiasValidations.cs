#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAgendaRepetirDiasValidation
{
    Task<string> ValidateReg(Models.AgendaRepetirDias reg, IAgendaRepetirDiasService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, IAgendaRepetirDiasService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class AgendaRepetirDiasValidation : IAgendaRepetirDiasValidation
{
    public async Task<string> CanDelete(int id, IAgendaRepetirDiasService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.AgendaRepetirDias reg, IAgendaRepetirDiasService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        return string.Empty;
    }
}