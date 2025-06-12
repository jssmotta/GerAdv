#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAgendaFinanceiroValidation
{
    Task<string> ValidateReg(Models.AgendaFinanceiro reg, IAgendaFinanceiroService service, ICidadeReader cidadeReader, IAdvogadosReader advogadosReader, IFuncionariosReader funcionariosReader, ITipoCompromissoReader tipocompromissoReader, IClientesReader clientesReader, IAreaReader areaReader, IJusticaReader justicaReader, IProcessosReader processosReader, IOperadorReader operadorReader, IPrepostosReader prepostosReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, IAgendaFinanceiroService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class AgendaFinanceiroValidation : IAgendaFinanceiroValidation
{
    public async Task<string> CanDelete(int id, IAgendaFinanceiroService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.AgendaFinanceiro reg, IAgendaFinanceiroService service, ICidadeReader cidadeReader, IAdvogadosReader advogadosReader, IFuncionariosReader funcionariosReader, ITipoCompromissoReader tipocompromissoReader, IClientesReader clientesReader, IAreaReader areaReader, IJusticaReader justicaReader, IProcessosReader processosReader, IOperadorReader operadorReader, IPrepostosReader prepostosReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        // Cidade
        if (!reg.Cidade.IsEmptyIDNumber())
        {
            var regCidade = cidadeReader.Read(reg.Cidade, oCnn);
            if (regCidade == null || regCidade.Id != reg.Cidade)
            {
                return $"Cidade não encontrado ({regCidade?.Id}).";
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

        // Funcionarios
        if (!reg.Funcionario.IsEmptyIDNumber())
        {
            var regFuncionarios = funcionariosReader.Read(reg.Funcionario, oCnn);
            if (regFuncionarios == null || regFuncionarios.Id != reg.Funcionario)
            {
                return $"Colaborador não encontrado ({regFuncionarios?.Id}).";
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

        // Area
        if (!reg.Area.IsEmptyIDNumber())
        {
            var regArea = areaReader.Read(reg.Area, oCnn);
            if (regArea == null || regArea.Id != reg.Area)
            {
                return $"Area não encontrado ({regArea?.Id}).";
            }
        }

        // Justica
        if (!reg.Justica.IsEmptyIDNumber())
        {
            var regJustica = justicaReader.Read(reg.Justica, oCnn);
            if (regJustica == null || regJustica.Id != reg.Justica)
            {
                return $"Justica não encontrado ({regJustica?.Id}).";
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

        // Operador
        if (!reg.Usuario.IsEmptyIDNumber())
        {
            var regOperador = operadorReader.Read(reg.Usuario, oCnn);
            if (regOperador == null || regOperador.Id != reg.Usuario)
            {
                return $"Operador não encontrado ({regOperador?.Id}).";
            }
        }

        // Prepostos
        if (!reg.Preposto.IsEmptyIDNumber())
        {
            var regPrepostos = prepostosReader.Read(reg.Preposto, oCnn);
            if (regPrepostos == null || regPrepostos.Id != reg.Preposto)
            {
                return $"Prepostos não encontrado ({regPrepostos?.Id}).";
            }
        }

        return string.Empty;
    }
}