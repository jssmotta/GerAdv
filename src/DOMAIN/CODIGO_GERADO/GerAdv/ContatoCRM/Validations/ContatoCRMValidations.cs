#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IContatoCRMValidation
{
    Task<string> ValidateReg(Models.ContatoCRM reg, IContatoCRMService service, IOperadorReader operadorReader, IClientesReader clientesReader, IProcessosReader processosReader, ITipoContatoCRMReader tipocontatocrmReader, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class ContatoCRMValidation : IContatoCRMValidation
{
    public async Task<string> ValidateReg(Models.ContatoCRM reg, IContatoCRMService service, IOperadorReader operadorReader, IClientesReader clientesReader, IProcessosReader processosReader, ITipoContatoCRMReader tipocontatocrmReader, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        // Operador
        if (!reg.Operador.IsEmptyIDNumber())
        {
            var regOperador = operadorReader.Read(reg.Operador, oCnn);
            if (regOperador == null || regOperador.Id != reg.Operador)
            {
                return $"Operador não encontrado ({regOperador?.Id}).";
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

        // Processos
        if (!reg.Processo.IsEmptyIDNumber())
        {
            var regProcessos = processosReader.Read(reg.Processo, oCnn);
            if (regProcessos == null || regProcessos.Id != reg.Processo)
            {
                return $"Processos não encontrado ({regProcessos?.Id}).";
            }
        }

        // TipoContatoCRM
        if (!reg.TipoContatoCRM.IsEmptyIDNumber())
        {
            var regTipoContatoCRM = tipocontatocrmReader.Read(reg.TipoContatoCRM, oCnn);
            if (regTipoContatoCRM == null || regTipoContatoCRM.Id != reg.TipoContatoCRM)
            {
                return $"Tipo Contato C R M não encontrado ({regTipoContatoCRM?.Id}).";
            }
        }

        return string.Empty;
    }
}