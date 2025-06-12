#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProcessosValidation
{
    Task<string> ValidateReg(Models.Processos reg, IProcessosService service, IAdvogadosReader advogadosReader, IJusticaReader justicaReader, IPrepostosReader prepostosReader, IClientesReader clientesReader, IOponentesReader oponentesReader, IAreaReader areaReader, ICidadeReader cidadeReader, ISituacaoReader situacaoReader, IRitoReader ritoReader, IAtividadesReader atividadesReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, IProcessosService service, IAgendaService agendaService, IAgendaFinanceiroService agendafinanceiroService, IAgendaRepetirService agendarepetirService, IAndamentosMDService andamentosmdService, IApensoService apensoService, IApenso2Service apenso2Service, IContaCorrenteService contacorrenteService, IContatoCRMService contatocrmService, IContratosService contratosService, IDocumentosService documentosService, IEnderecoSistemaService enderecosistemaService, IHistoricoService historicoService, IHonorariosDadosContratoService honorariosdadoscontratoService, IHorasTrabService horastrabService, IInstanciaService instanciaService, ILigacoesService ligacoesService, ILivroCaixaService livrocaixaService, INENotasService nenotasService, IParceriaProcService parceriaprocService, IParteClienteOutrasService parteclienteoutrasService, IPenhoraService penhoraService, IPrecatoriaService precatoriaService, IProCDAService procdaService, IProcessosObsReportService processosobsreportService, IProcessosParadosService processosparadosService, IProcessOutputRequestService processoutputrequestService, IProDepositosService prodepositosService, IProDespesasService prodespesasService, IProObservacoesService proobservacoesService, IProPartesService propartesService, IProProcuradoresService proprocuradoresService, IProResumosService proresumosService, IProSucumbenciaService prosucumbenciaService, IProValoresService provaloresService, IRecadosService recadosService, ITerceirosService terceirosService, IUltimosProcessosService ultimosprocessosService, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class ProcessosValidation : IProcessosValidation
{
    public async Task<string> CanDelete(int id, IProcessosService service, IAgendaService agendaService, IAgendaFinanceiroService agendafinanceiroService, IAgendaRepetirService agendarepetirService, IAndamentosMDService andamentosmdService, IApensoService apensoService, IApenso2Service apenso2Service, IContaCorrenteService contacorrenteService, IContatoCRMService contatocrmService, IContratosService contratosService, IDocumentosService documentosService, IEnderecoSistemaService enderecosistemaService, IHistoricoService historicoService, IHonorariosDadosContratoService honorariosdadoscontratoService, IHorasTrabService horastrabService, IInstanciaService instanciaService, ILigacoesService ligacoesService, ILivroCaixaService livrocaixaService, INENotasService nenotasService, IParceriaProcService parceriaprocService, IParteClienteOutrasService parteclienteoutrasService, IPenhoraService penhoraService, IPrecatoriaService precatoriaService, IProCDAService procdaService, IProcessosObsReportService processosobsreportService, IProcessosParadosService processosparadosService, IProcessOutputRequestService processoutputrequestService, IProDepositosService prodepositosService, IProDespesasService prodespesasService, IProObservacoesService proobservacoesService, IProPartesService propartesService, IProProcuradoresService proprocuradoresService, IProResumosService proresumosService, IProSucumbenciaService prosucumbenciaService, IProValoresService provaloresService, IRecadosService recadosService, ITerceirosService terceirosService, IUltimosProcessosService ultimosprocessosService, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        var agendaExists = await agendaService.Filter(new Filters.FilterAgenda { Processo = id }, uri);
        if (agendaExists != null && agendaExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Agenda associados a ele.";
        var agendafinanceiroExists = await agendafinanceiroService.Filter(new Filters.FilterAgendaFinanceiro { Processo = id }, uri);
        if (agendafinanceiroExists != null && agendafinanceiroExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Agenda Financeiro associados a ele.";
        var agendarepetirExists = await agendarepetirService.Filter(new Filters.FilterAgendaRepetir { Processo = id }, uri);
        if (agendarepetirExists != null && agendarepetirExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Agenda Repetir associados a ele.";
        var andamentosmdExists = await andamentosmdService.Filter(new Filters.FilterAndamentosMD { Processo = id }, uri);
        if (andamentosmdExists != null && andamentosmdExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Andamentos M D associados a ele.";
        var apensoExists = await apensoService.Filter(new Filters.FilterApenso { Processo = id }, uri);
        if (apensoExists != null && apensoExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Apenso associados a ele.";
        var apenso2Exists = await apenso2Service.Filter(new Filters.FilterApenso2 { Processo = id }, uri);
        if (apenso2Exists != null && apenso2Exists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Apenso2 associados a ele.";
        var contacorrenteExists = await contacorrenteService.Filter(new Filters.FilterContaCorrente { Processo = id }, uri);
        if (contacorrenteExists != null && contacorrenteExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Conta Corrente associados a ele.";
        var contatocrmExists = await contatocrmService.Filter(new Filters.FilterContatoCRM { Processo = id }, uri);
        if (contatocrmExists != null && contatocrmExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Contato C R M associados a ele.";
        var contratosExists = await contratosService.Filter(new Filters.FilterContratos { Processo = id }, uri);
        if (contratosExists != null && contratosExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Contratos associados a ele.";
        var documentosExists = await documentosService.Filter(new Filters.FilterDocumentos { Processo = id }, uri);
        if (documentosExists != null && documentosExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Documentos associados a ele.";
        var enderecosistemaExists = await enderecosistemaService.Filter(new Filters.FilterEnderecoSistema { Processo = id }, uri);
        if (enderecosistemaExists != null && enderecosistemaExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Endereco Sistema associados a ele.";
        var historicoExists = await historicoService.Filter(new Filters.FilterHistorico { Processo = id }, uri);
        if (historicoExists != null && historicoExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Historico associados a ele.";
        var honorariosdadoscontratoExists = await honorariosdadoscontratoService.Filter(new Filters.FilterHonorariosDadosContrato { Processo = id }, uri);
        if (honorariosdadoscontratoExists != null && honorariosdadoscontratoExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Honorarios Dados Contrato associados a ele.";
        var horastrabExists = await horastrabService.Filter(new Filters.FilterHorasTrab { Processo = id }, uri);
        if (horastrabExists != null && horastrabExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Horas Trab associados a ele.";
        var instanciaExists = await instanciaService.Filter(new Filters.FilterInstancia { Processo = id }, uri);
        if (instanciaExists != null && instanciaExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Instancia associados a ele.";
        var ligacoesExists = await ligacoesService.Filter(new Filters.FilterLigacoes { Processo = id }, uri);
        if (ligacoesExists != null && ligacoesExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Ligacoes associados a ele.";
        var livrocaixaExists = await livrocaixaService.Filter(new Filters.FilterLivroCaixa { Processo = id }, uri);
        if (livrocaixaExists != null && livrocaixaExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Livro Caixa associados a ele.";
        var nenotasExists = await nenotasService.Filter(new Filters.FilterNENotas { Processo = id }, uri);
        if (nenotasExists != null && nenotasExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela N E Notas associados a ele.";
        var parceriaprocExists = await parceriaprocService.Filter(new Filters.FilterParceriaProc { Processo = id }, uri);
        if (parceriaprocExists != null && parceriaprocExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Parceria Proc associados a ele.";
        var parteclienteoutrasExists = await parteclienteoutrasService.Filter(new Filters.FilterParteClienteOutras { Processo = id }, uri);
        if (parteclienteoutrasExists != null && parteclienteoutrasExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Parte Cliente Outras associados a ele.";
        var penhoraExists = await penhoraService.Filter(new Filters.FilterPenhora { Processo = id }, uri);
        if (penhoraExists != null && penhoraExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Penhora associados a ele.";
        var precatoriaExists = await precatoriaService.Filter(new Filters.FilterPrecatoria { Processo = id }, uri);
        if (precatoriaExists != null && precatoriaExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Precatoria associados a ele.";
        var procdaExists = await procdaService.Filter(new Filters.FilterProCDA { Processo = id }, uri);
        if (procdaExists != null && procdaExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Pro C D A associados a ele.";
        var processosobsreportExists = await processosobsreportService.Filter(new Filters.FilterProcessosObsReport { Processo = id }, uri);
        if (processosobsreportExists != null && processosobsreportExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Processos Obs Report associados a ele.";
        var processosparadosExists = await processosparadosService.Filter(new Filters.FilterProcessosParados { Processo = id }, uri);
        if (processosparadosExists != null && processosparadosExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Processos Parados associados a ele.";
        var processoutputrequestExists = await processoutputrequestService.Filter(new Filters.FilterProcessOutputRequest { Processo = id }, uri);
        if (processoutputrequestExists != null && processoutputrequestExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Process Output Request associados a ele.";
        var prodepositosExists = await prodepositosService.Filter(new Filters.FilterProDepositos { Processo = id }, uri);
        if (prodepositosExists != null && prodepositosExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Pro Depositos associados a ele.";
        var prodespesasExists = await prodespesasService.Filter(new Filters.FilterProDespesas { Processo = id }, uri);
        if (prodespesasExists != null && prodespesasExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Pro Despesas associados a ele.";
        var proobservacoesExists = await proobservacoesService.Filter(new Filters.FilterProObservacoes { Processo = id }, uri);
        if (proobservacoesExists != null && proobservacoesExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Pro Observacoes associados a ele.";
        var propartesExists = await propartesService.Filter(new Filters.FilterProPartes { Processo = id }, uri);
        if (propartesExists != null && propartesExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Pro Partes associados a ele.";
        var proprocuradoresExists = await proprocuradoresService.Filter(new Filters.FilterProProcuradores { Processo = id }, uri);
        if (proprocuradoresExists != null && proprocuradoresExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Pro Procuradores associados a ele.";
        var proresumosExists = await proresumosService.Filter(new Filters.FilterProResumos { Processo = id }, uri);
        if (proresumosExists != null && proresumosExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Pro Resumos associados a ele.";
        var prosucumbenciaExists = await prosucumbenciaService.Filter(new Filters.FilterProSucumbencia { Processo = id }, uri);
        if (prosucumbenciaExists != null && prosucumbenciaExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Pro Sucumbencia associados a ele.";
        var provaloresExists = await provaloresService.Filter(new Filters.FilterProValores { Processo = id }, uri);
        if (provaloresExists != null && provaloresExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Pro Valores associados a ele.";
        var recadosExists = await recadosService.Filter(new Filters.FilterRecados { Processo = id }, uri);
        if (recadosExists != null && recadosExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Recados associados a ele.";
        var terceirosExists = await terceirosService.Filter(new Filters.FilterTerceiros { Processo = id }, uri);
        if (terceirosExists != null && terceirosExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Terceiros associados a ele.";
        var ultimosprocessosExists = await ultimosprocessosService.Filter(new Filters.FilterUltimosProcessos { Processo = id }, uri);
        if (ultimosprocessosExists != null && ultimosprocessosExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Ultimos Processos associados a ele.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.Processos reg, IProcessosService service, IAdvogadosReader advogadosReader, IJusticaReader justicaReader, IPrepostosReader prepostosReader, IClientesReader clientesReader, IOponentesReader oponentesReader, IAreaReader areaReader, ICidadeReader cidadeReader, ISituacaoReader situacaoReader, IRitoReader ritoReader, IAtividadesReader atividadesReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.NroPasta))
            return "NroPasta é obrigatório";
        // Advogados
        if (!reg.AdvOpo.IsEmptyIDNumber())
        {
            var regAdvogados = advogadosReader.Read(reg.AdvOpo, oCnn);
            if (regAdvogados == null || regAdvogados.Id != reg.AdvOpo)
            {
                return $"Advogados não encontrado ({regAdvogados?.Id}).";
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

        // Advogados
        if (!reg.Advogado.IsEmptyIDNumber())
        {
            var regAdvogados = advogadosReader.Read(reg.Advogado, oCnn);
            if (regAdvogados == null || regAdvogados.Id != reg.Advogado)
            {
                return $"Advogados não encontrado ({regAdvogados?.Id}).";
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

        // Clientes
        if (!reg.Cliente.IsEmptyIDNumber())
        {
            var regClientes = clientesReader.Read(reg.Cliente, oCnn);
            if (regClientes == null || regClientes.Id != reg.Cliente)
            {
                return $"Clientes não encontrado ({regClientes?.Id}).";
            }
        }

        // Oponentes
        if (!reg.Oponente.IsEmptyIDNumber())
        {
            var regOponentes = oponentesReader.Read(reg.Oponente, oCnn);
            if (regOponentes == null || regOponentes.Id != reg.Oponente)
            {
                return $"Oponentes não encontrado ({regOponentes?.Id}).";
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

        // Cidade
        if (!reg.Cidade.IsEmptyIDNumber())
        {
            var regCidade = cidadeReader.Read(reg.Cidade, oCnn);
            if (regCidade == null || regCidade.Id != reg.Cidade)
            {
                return $"Cidade não encontrado ({regCidade?.Id}).";
            }
        }

        // Situacao
        if (!reg.Situacao.IsEmptyIDNumber())
        {
            var regSituacao = situacaoReader.Read(reg.Situacao, oCnn);
            if (regSituacao == null || regSituacao.Id != reg.Situacao)
            {
                return $"Situacao não encontrado ({regSituacao?.Id}).";
            }
        }

        // Rito
        if (!reg.Rito.IsEmptyIDNumber())
        {
            var regRito = ritoReader.Read(reg.Rito, oCnn);
            if (regRito == null || regRito.Id != reg.Rito)
            {
                return $"Rito não encontrado ({regRito?.Id}).";
            }
        }

        // Atividades
        if (!reg.Atividade.IsEmptyIDNumber())
        {
            var regAtividades = atividadesReader.Read(reg.Atividade, oCnn);
            if (regAtividades == null || regAtividades.Id != reg.Atividade)
            {
                return $"Atividades não encontrado ({regAtividades?.Id}).";
            }
        }

        return string.Empty;
    }
}