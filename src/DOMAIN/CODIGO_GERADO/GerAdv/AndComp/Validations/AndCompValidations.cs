﻿#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAndCompValidation
{
    Task<string> ValidateReg(Models.AndComp reg, IAndCompService service, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class AndCompValidation : IAndCompValidation
{
    public async Task<string> ValidateReg(Models.AndComp reg, IAndCompService service, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        return string.Empty;
    }
}