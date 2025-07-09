#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAgendaValidation
{
    Task<string> ValidateReg(Models.Agenda reg, IAgendaService service, ICidadeReader cidadeReader, IAdvogadosReader advogadosReader, IFuncionariosReader funcionariosReader, ITipoCompromissoReader tipocompromissoReader, IClientesReader clientesReader, IAreaReader areaReader, IJusticaReader justicaReader, IProcessosReader processosReader, IOperadorReader operadorReader, IPrepostosReader prepostosReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, IAgendaService service, IAgenda2AgendaService agenda2agendaService, IAgendaRecordsService agendarecordsService, IAgendaStatusService agendastatusService, IAlarmSMSService alarmsmsService, IRecadosService recadosService, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class AgendaValidation : IAgendaValidation
{
    public async Task<string> CanDelete(int id, IAgendaService service, IAgenda2AgendaService agenda2agendaService, IAgendaRecordsService agendarecordsService, IAgendaStatusService agendastatusService, IAlarmSMSService alarmsmsService, IRecadosService recadosService, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        var agenda2agendaExists0 = await agenda2agendaService.Filter(new Filters.FilterAgenda2Agenda { Agenda = id }, uri);
        if (agenda2agendaExists0 != null && agenda2agendaExists0.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Agenda2 Agenda associados a ele.";
        var agendarecordsExists1 = await agendarecordsService.Filter(new Filters.FilterAgendaRecords { Agenda = id }, uri);
        if (agendarecordsExists1 != null && agendarecordsExists1.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Agenda Records associados a ele.";
        var agendastatusExists2 = await agendastatusService.Filter(new Filters.FilterAgendaStatus { Agenda = id }, uri);
        if (agendastatusExists2 != null && agendastatusExists2.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Agenda Status associados a ele.";
        var alarmsmsExists3 = await alarmsmsService.Filter(new Filters.FilterAlarmSMS { Agenda = id }, uri);
        if (alarmsmsExists3 != null && alarmsmsExists3.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Alarm S M S associados a ele.";
        var recadosExists4 = await recadosService.Filter(new Filters.FilterRecados { Agenda = id }, uri);
        if (recadosExists4 != null && recadosExists4.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Recados associados a ele.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.Agenda reg, IAgendaService service, ICidadeReader cidadeReader, IAdvogadosReader advogadosReader, IFuncionariosReader funcionariosReader, ITipoCompromissoReader tipocompromissoReader, IClientesReader clientesReader, IAreaReader areaReader, IJusticaReader justicaReader, IProcessosReader processosReader, IOperadorReader operadorReader, IPrepostosReader prepostosReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
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
                return $"Área não encontrado ({regArea?.Id}).";
            }
        }

        // Justica
        if (!reg.Justica.IsEmptyIDNumber())
        {
            var regJustica = justicaReader.Read(reg.Justica, oCnn);
            if (regJustica == null || regJustica.Id != reg.Justica)
            {
                return $"Justiça não encontrado ({regJustica?.Id}).";
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