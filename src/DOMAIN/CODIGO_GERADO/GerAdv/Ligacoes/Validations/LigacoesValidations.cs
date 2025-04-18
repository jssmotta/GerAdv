#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ILigacoesValidation
{
    Task<string> ValidateReg(Models.Ligacoes reg, ILigacoesService service, IClientesReader clientesReader, IRamalReader ramalReader, IProcessosReader processosReader, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class LigacoesValidation : ILigacoesValidation
{
    public async Task<string> ValidateReg(Models.Ligacoes reg, ILigacoesService service, IClientesReader clientesReader, IRamalReader ramalReader, IProcessosReader processosReader, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        // Clientes
        if (!reg.Cliente.IsEmptyIDNumber())
        {
            var regClientes = clientesReader.Read(reg.Cliente, oCnn);
            if (regClientes == null || regClientes.Id != reg.Cliente)
            {
                return $"Clientes não encontrado ({regClientes?.Id}).";
            }
        }

        // Ramal
        if (!reg.Ramal.IsEmptyIDNumber())
        {
            var regRamal = ramalReader.Read(reg.Ramal, oCnn);
            if (regRamal == null || regRamal.Id != reg.Ramal)
            {
                return $"Ramal não encontrado ({regRamal?.Id}).";
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
}