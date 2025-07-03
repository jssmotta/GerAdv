#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ICargosEscClassValidation
{
    Task<string> ValidateReg(Models.CargosEscClass reg, ICargosEscClassService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, ICargosEscClassService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class CargosEscClassValidation : ICargosEscClassValidation
{
    public async Task<string> CanDelete(int id, ICargosEscClassService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.CargosEscClass reg, ICargosEscClassService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        if (await IsDuplicado(reg, service, uri))
            return $"Cargos Esc Class '{reg.Nome}'  - Nome";
        return string.Empty;
    }

    private async Task<bool> IsDuplicado(Models.CargosEscClass reg, ICargosEscClassService service, string uri)
    {
        var existingCargosEscClass = (await service.Filter(new Filters.FilterCargosEscClass { Nome = reg.Nome }, uri)).FirstOrDefault(); // TRACK 10042025
        return existingCargosEscClass != null && existingCargosEscClass.Id > 0 && existingCargosEscClass.Id != reg.Id;
    }
}