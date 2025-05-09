﻿#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ICargosEscClassValidation
{
    Task<string> ValidateReg(Models.CargosEscClass reg, ICargosEscClassService service, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class CargosEscClassValidation : ICargosEscClassValidation
{
    public async Task<string> ValidateReg(Models.CargosEscClass reg, ICargosEscClassService service, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        if (await IsDuplicado(reg, service, uri))
            return $"CargosEscClass '{reg.Nome}' já cadastrado.";
        return string.Empty;
    }

    private async Task<bool> IsDuplicado(Models.CargosEscClass reg, ICargosEscClassService service, string uri)
    {
        var existingCargosEscClass = (await service.Filter(new Filters.FilterCargosEscClass { Nome = reg.Nome }, uri)).FirstOrDefault(); // TRACK 10042025
        return existingCargosEscClass != null && existingCargosEscClass.Id > 0 && existingCargosEscClass.Id != reg.Id;
    }
}