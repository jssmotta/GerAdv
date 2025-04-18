﻿#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProObservacoesValidation
{
    Task<string> ValidateReg(Models.ProObservacoes reg, IProObservacoesService service, IProcessosReader processosReader, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class ProObservacoesValidation : IProObservacoesValidation
{
    public async Task<string> ValidateReg(Models.ProObservacoes reg, IProObservacoesService service, IProcessosReader processosReader, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        // Processos
        if (!reg.Processo.IsEmptyIDNumber())
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