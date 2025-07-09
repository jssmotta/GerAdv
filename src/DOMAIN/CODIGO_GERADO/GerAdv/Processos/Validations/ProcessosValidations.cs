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
        var agendaExists0 = await agendaService.Filter(new Filters.FilterAgenda { Processo = id }, uri);
        if (agendaExists0 != null && agendaExists0.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Agenda associados a ele.";
        var agendafinanceiroExists1 = await agendafinanceiroService.Filter(new Filters.FilterAgendaFinanceiro { Processo = id }, uri);
        if (agendafinanceiroExists1 != null && agendafinanceiroExists1.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Agenda Financeiro associados a ele.";
        var agendarepetirExists2 = await agendarepetirService.Filter(new Filters.FilterAgendaRepetir { Processo = id }, uri);
        if (agendarepetirExists2 != null && agendarepetirExists2.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Agenda Repetir associados a ele.";
        var andamentosmdExists3 = await andamentosmdService.Filter(new Filters.FilterAndamentosMD { Processo = id }, uri);
        if (andamentosmdExists3 != null && andamentosmdExists3.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Andamentos M D associados a ele.";
        var apensoExists4 = await apensoService.Filter(new Filters.FilterApenso { Processo = id }, uri);
        if (apensoExists4 != null && apensoExists4.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Apenso associados a ele.";
        var apenso2Exists5 = await apenso2Service.Filter(new Filters.FilterApenso2 { Processo = id }, uri);
        if (apenso2Exists5 != null && apenso2Exists5.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Apenso2 associados a ele.";
        var contacorrenteExists6 = await contacorrenteService.Filter(new Filters.FilterContaCorrente { Processo = id }, uri);
        if (contacorrenteExists6 != null && contacorrenteExists6.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Conta Corrente associados a ele.";
        var contatocrmExists7 = await contatocrmService.Filter(new Filters.FilterContatoCRM { Processo = id }, uri);
        if (contatocrmExists7 != null && contatocrmExists7.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Contato C R M associados a ele.";
        var contratosExists8 = await contratosService.Filter(new Filters.FilterContratos { Processo = id }, uri);
        if (contratosExists8 != null && contratosExists8.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Contratos associados a ele.";
        var documentosExists9 = await documentosService.Filter(new Filters.FilterDocumentos { Processo = id }, uri);
        if (documentosExists9 != null && documentosExists9.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Documentos associados a ele.";
        var enderecosistemaExists10 = await enderecosistemaService.Filter(new Filters.FilterEnderecoSistema { Processo = id }, uri);
        if (enderecosistemaExists10 != null && enderecosistemaExists10.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Endereco Sistema associados a ele.";
        var historicoExists11 = await historicoService.Filter(new Filters.FilterHistorico { Processo = id }, uri);
        if (historicoExists11 != null && historicoExists11.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Historico associados a ele.";
        var honorariosdadoscontratoExists12 = await honorariosdadoscontratoService.Filter(new Filters.FilterHonorariosDadosContrato { Processo = id }, uri);
        if (honorariosdadoscontratoExists12 != null && honorariosdadoscontratoExists12.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Honorarios Dados Contrato associados a ele.";
        var horastrabExists13 = await horastrabService.Filter(new Filters.FilterHorasTrab { Processo = id }, uri);
        if (horastrabExists13 != null && horastrabExists13.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Horas Trab associados a ele.";
        var instanciaExists14 = await instanciaService.Filter(new Filters.FilterInstancia { Processo = id }, uri);
        if (instanciaExists14 != null && instanciaExists14.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Instancia associados a ele.";
        var ligacoesExists15 = await ligacoesService.Filter(new Filters.FilterLigacoes { Processo = id }, uri);
        if (ligacoesExists15 != null && ligacoesExists15.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Ligacoes associados a ele.";
        var livrocaixaExists16 = await livrocaixaService.Filter(new Filters.FilterLivroCaixa { Processo = id }, uri);
        if (livrocaixaExists16 != null && livrocaixaExists16.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Livro Caixa associados a ele.";
        var nenotasExists17 = await nenotasService.Filter(new Filters.FilterNENotas { Processo = id }, uri);
        if (nenotasExists17 != null && nenotasExists17.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela N E Notas associados a ele.";
        var parceriaprocExists18 = await parceriaprocService.Filter(new Filters.FilterParceriaProc { Processo = id }, uri);
        if (parceriaprocExists18 != null && parceriaprocExists18.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Parceria Proc associados a ele.";
        var parteclienteoutrasExists19 = await parteclienteoutrasService.Filter(new Filters.FilterParteClienteOutras { Processo = id }, uri);
        if (parteclienteoutrasExists19 != null && parteclienteoutrasExists19.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Parte Cliente Outras associados a ele.";
        var penhoraExists20 = await penhoraService.Filter(new Filters.FilterPenhora { Processo = id }, uri);
        if (penhoraExists20 != null && penhoraExists20.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Penhora associados a ele.";
        var precatoriaExists21 = await precatoriaService.Filter(new Filters.FilterPrecatoria { Processo = id }, uri);
        if (precatoriaExists21 != null && precatoriaExists21.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Precatoria associados a ele.";
        var procdaExists22 = await procdaService.Filter(new Filters.FilterProCDA { Processo = id }, uri);
        if (procdaExists22 != null && procdaExists22.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Pro C D A associados a ele.";
        var processosobsreportExists23 = await processosobsreportService.Filter(new Filters.FilterProcessosObsReport { Processo = id }, uri);
        if (processosobsreportExists23 != null && processosobsreportExists23.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Processos Obs Report associados a ele.";
        var processosparadosExists24 = await processosparadosService.Filter(new Filters.FilterProcessosParados { Processo = id }, uri);
        if (processosparadosExists24 != null && processosparadosExists24.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Processos Parados associados a ele.";
        var processoutputrequestExists25 = await processoutputrequestService.Filter(new Filters.FilterProcessOutputRequest { Processo = id }, uri);
        if (processoutputrequestExists25 != null && processoutputrequestExists25.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Process Output Request associados a ele.";
        var prodepositosExists26 = await prodepositosService.Filter(new Filters.FilterProDepositos { Processo = id }, uri);
        if (prodepositosExists26 != null && prodepositosExists26.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Pro Depositos associados a ele.";
        var prodespesasExists27 = await prodespesasService.Filter(new Filters.FilterProDespesas { Processo = id }, uri);
        if (prodespesasExists27 != null && prodespesasExists27.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Pro Despesas associados a ele.";
        var proobservacoesExists28 = await proobservacoesService.Filter(new Filters.FilterProObservacoes { Processo = id }, uri);
        if (proobservacoesExists28 != null && proobservacoesExists28.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Pro Observacoes associados a ele.";
        var propartesExists29 = await propartesService.Filter(new Filters.FilterProPartes { Processo = id }, uri);
        if (propartesExists29 != null && propartesExists29.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Pro Partes associados a ele.";
        var proprocuradoresExists30 = await proprocuradoresService.Filter(new Filters.FilterProProcuradores { Processo = id }, uri);
        if (proprocuradoresExists30 != null && proprocuradoresExists30.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Pro Procuradores associados a ele.";
        var proresumosExists31 = await proresumosService.Filter(new Filters.FilterProResumos { Processo = id }, uri);
        if (proresumosExists31 != null && proresumosExists31.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Pro Resumos associados a ele.";
        var prosucumbenciaExists32 = await prosucumbenciaService.Filter(new Filters.FilterProSucumbencia { Processo = id }, uri);
        if (prosucumbenciaExists32 != null && prosucumbenciaExists32.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Pro Sucumbencia associados a ele.";
        var provaloresExists33 = await provaloresService.Filter(new Filters.FilterProValores { Processo = id }, uri);
        if (provaloresExists33 != null && provaloresExists33.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Pro Valores associados a ele.";
        var recadosExists34 = await recadosService.Filter(new Filters.FilterRecados { Processo = id }, uri);
        if (recadosExists34 != null && recadosExists34.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Recados associados a ele.";
        var terceirosExists35 = await terceirosService.Filter(new Filters.FilterTerceiros { Processo = id }, uri);
        if (terceirosExists35 != null && terceirosExists35.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Terceiros associados a ele.";
        var ultimosprocessosExists36 = await ultimosprocessosService.Filter(new Filters.FilterUltimosProcessos { Processo = id }, uri);
        if (ultimosprocessosExists36 != null && ultimosprocessosExists36.Any())
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
                return $"Justiça não encontrado ({regJustica?.Id}).";
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
                return $"Área não encontrado ({regArea?.Id}).";
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
                return $"Situação não encontrado ({regSituacao?.Id}).";
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