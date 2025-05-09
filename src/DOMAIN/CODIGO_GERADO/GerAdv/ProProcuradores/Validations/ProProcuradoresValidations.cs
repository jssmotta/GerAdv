﻿#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProProcuradoresValidation
{
    Task<string> ValidateReg(Models.ProProcuradores reg, IProProcuradoresService service, IAdvogadosReader advogadosReader, IProcessosReader processosReader, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class ProProcuradoresValidation : IProProcuradoresValidation
{
    public async Task<string> ValidateReg(Models.ProProcuradores reg, IProProcuradoresService service, IAdvogadosReader advogadosReader, IProcessosReader processosReader, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        if (await IsDuplicado(reg, service, uri))
            return $"ProProcuradores '{reg.Nome}' já cadastrado.";
        // Advogados
        if (!reg.Advogado.IsEmptyIDNumber())
        {
            var regAdvogados = advogadosReader.Read(reg.Advogado, oCnn);
            if (regAdvogados == null || regAdvogados.Id != reg.Advogado)
            {
                return $"Advogados não encontrado ({regAdvogados?.Id}).";
            }
        }

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

    private async Task<bool> IsDuplicado(Models.ProProcuradores reg, IProProcuradoresService service, string uri)
    {
        var existingProProcuradores = (await service.Filter(new Filters.FilterProProcuradores { Advogado = reg.Advogado, Data = reg.Data, Nome = reg.Nome, Processo = reg.Processo }, uri)).FirstOrDefault(); // TRACK 10042025
        return existingProProcuradores != null && existingProProcuradores.Id > 0 && existingProProcuradores.Id != reg.Id;
    }
}