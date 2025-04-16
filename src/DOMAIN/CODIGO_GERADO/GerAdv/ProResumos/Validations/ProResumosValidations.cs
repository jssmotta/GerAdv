﻿#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProResumosValidation
{
    Task<string> ValidateReg(Models.ProResumos reg, IProResumosService service, IProcessosReader processosReader, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class ProResumosValidation : IProResumosValidation
{
    public async Task<string> ValidateReg(Models.ProResumos reg, IProResumosService service, IProcessosReader processosReader, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        // Processos
        if (reg.Processo.IsEmptyIDNumber())
        {
            var regProcessos = processosReader.Read(reg.Processo, oCnn);
            if (regProcessos == null || regProcessos.Id != reg.Processo)
            {
                return $"Processos não encontrado ({regProcessos?.Id}).";
            }
        }

        return string.Empty;
    }
}