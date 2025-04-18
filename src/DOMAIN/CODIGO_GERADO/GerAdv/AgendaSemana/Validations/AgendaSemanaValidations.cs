#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAgendaSemanaValidation
{
    Task<string> ValidateReg(Models.AgendaSemana reg, IAgendaSemanaService service, IFuncionariosReader funcionariosReader, IAdvogadosReader advogadosReader, ITipoCompromissoReader tipocompromissoReader, IClientesReader clientesReader, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class AgendaSemanaValidation : IAgendaSemanaValidation
{
    public async Task<string> ValidateReg(Models.AgendaSemana reg, IAgendaSemanaService service, IFuncionariosReader funcionariosReader, IAdvogadosReader advogadosReader, ITipoCompromissoReader tipocompromissoReader, IClientesReader clientesReader, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        // Funcionarios
        if (!reg.Funcionario.IsEmptyIDNumber())
        {
            var regFuncionarios = funcionariosReader.Read(reg.Funcionario, oCnn);
            if (regFuncionarios == null || regFuncionarios.Id != reg.Funcionario)
            {
                return $"Colaborador não encontrado ({regFuncionarios?.Id}).";
            }
        }

        // Advogados
        if (!reg.Advogado.IsEmptyIDNumber())
        {
            var regAdvogados = advogadosReader.Read(reg.Advogado, oCnn);
            if (regAdvogados == null || regAdvogados.Id != reg.Advogado)
            {
                return $"Advogados não encontrado ({regAdvogados?.Id}).";
            }
        }

        // TipoCompromisso
        if (!reg.TipoCompromisso.IsEmptyIDNumber())
        {
            var regTipoCompromisso = tipocompromissoReader.Read(reg.TipoCompromisso, oCnn);
            if (regTipoCompromisso == null || regTipoCompromisso.Id != reg.TipoCompromisso)
            {
                return $"Tipo Compromisso não encontrado ({regTipoCompromisso?.Id}).";
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