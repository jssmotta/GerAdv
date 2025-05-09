﻿#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProcessosParadosValidation
{
    Task<string> ValidateReg(Models.ProcessosParados reg, IProcessosParadosService service, IProcessosReader processosReader, IOperadorReader operadorReader, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class ProcessosParadosValidation : IProcessosParadosValidation
{
    public async Task<string> ValidateReg(Models.ProcessosParados reg, IProcessosParadosService service, IProcessosReader processosReader, IOperadorReader operadorReader, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        // Processos
        if (!reg.Processo.IsEmptyIDNumber())
        {
            var regProcessos = processosReader.Read(reg.Processo, oCnn);
            if (regProcessos == null || regProcessos.Id != reg.Processo)
            {
                return $"Processos não encontrado ({regProcessos?.Id}).";
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