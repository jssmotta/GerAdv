﻿#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IContaCorrenteValidation
{
    Task<string> ValidateReg(Models.ContaCorrente reg, IContaCorrenteService service, IProcessosReader processosReader, IClientesReader clientesReader, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class ContaCorrenteValidation : IContaCorrenteValidation
{
    public async Task<string> ValidateReg(Models.ContaCorrente reg, IContaCorrenteService service, IProcessosReader processosReader, IClientesReader clientesReader, [FromRoute, Required] string uri, SqlConnection oCnn)
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

        // Clientes
        if (!reg.Cliente.IsEmptyIDNumber())
        {
            var regClientes = clientesReader.Read(reg.Cliente, oCnn);
            if (regClientes == null || regClientes.Id != reg.Cliente)
            {
                return $"Clientes não encontrado ({regClientes?.Id}).";
            }
        }

        return string.Empty;
    }
}