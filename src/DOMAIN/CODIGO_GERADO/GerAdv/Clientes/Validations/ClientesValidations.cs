#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IClientesValidation
{
    Task<string> ValidateReg(Models.Clientes reg, IClientesService service, ICidadeReader cidadeReader, IRegimeTributacaoReader regimetributacaoReader, IEnquadramentoEmpresaReader enquadramentoempresaReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, IClientesService service, IAgendaService agendaService, IAgendaFinanceiroService agendafinanceiroService, IAgendaRepetirService agendarepetirService, IAnexamentoRegistrosService anexamentoregistrosService, IClientesSociosService clientessociosService, IColaboradoresService colaboradoresService, IContaCorrenteService contacorrenteService, IContatoCRMService contatocrmService, IContratosService contratosService, IDadosProcuracaoService dadosprocuracaoService, IDiario2Service diario2Service, IGruposEmpresasService gruposempresasService, IGruposEmpresasCliService gruposempresascliService, IHonorariosDadosContratoService honorariosdadoscontratoService, IHorasTrabService horastrabService, ILigacoesService ligacoesService, ILivroCaixaClientesService livrocaixaclientesService, IOperadoresService operadoresService, IPreClientesService preclientesService, IProcessosService processosService, IProDespesasService prodespesasService, IRecadosService recadosService, IReuniaoService reuniaoService, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class ClientesValidation : IClientesValidation
{
    public async Task<string> CanDelete(int id, IClientesService service, IAgendaService agendaService, IAgendaFinanceiroService agendafinanceiroService, IAgendaRepetirService agendarepetirService, IAnexamentoRegistrosService anexamentoregistrosService, IClientesSociosService clientessociosService, IColaboradoresService colaboradoresService, IContaCorrenteService contacorrenteService, IContatoCRMService contatocrmService, IContratosService contratosService, IDadosProcuracaoService dadosprocuracaoService, IDiario2Service diario2Service, IGruposEmpresasService gruposempresasService, IGruposEmpresasCliService gruposempresascliService, IHonorariosDadosContratoService honorariosdadoscontratoService, IHorasTrabService horastrabService, ILigacoesService ligacoesService, ILivroCaixaClientesService livrocaixaclientesService, IOperadoresService operadoresService, IPreClientesService preclientesService, IProcessosService processosService, IProDespesasService prodespesasService, IRecadosService recadosService, IReuniaoService reuniaoService, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        var agendaExists0 = await agendaService.Filter(new Filters.FilterAgenda { Cliente = id }, uri);
        if (agendaExists0 != null && agendaExists0.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Agenda associados a ele.";
        var agendafinanceiroExists1 = await agendafinanceiroService.Filter(new Filters.FilterAgendaFinanceiro { Cliente = id }, uri);
        if (agendafinanceiroExists1 != null && agendafinanceiroExists1.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Agenda Financeiro associados a ele.";
        var agendarepetirExists2 = await agendarepetirService.Filter(new Filters.FilterAgendaRepetir { Cliente = id }, uri);
        if (agendarepetirExists2 != null && agendarepetirExists2.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Agenda Repetir associados a ele.";
        var anexamentoregistrosExists3 = await anexamentoregistrosService.Filter(new Filters.FilterAnexamentoRegistros { Cliente = id }, uri);
        if (anexamentoregistrosExists3 != null && anexamentoregistrosExists3.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Anexamento Registros associados a ele.";
        var clientessociosExists4 = await clientessociosService.Filter(new Filters.FilterClientesSocios { Cliente = id }, uri);
        if (clientessociosExists4 != null && clientessociosExists4.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Clientes Socios associados a ele.";
        var colaboradoresExists5 = await colaboradoresService.Filter(new Filters.FilterColaboradores { Cliente = id }, uri);
        if (colaboradoresExists5 != null && colaboradoresExists5.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Colaboradores associados a ele.";
        var contacorrenteExists6 = await contacorrenteService.Filter(new Filters.FilterContaCorrente { Cliente = id }, uri);
        if (contacorrenteExists6 != null && contacorrenteExists6.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Conta Corrente associados a ele.";
        var contatocrmExists7 = await contatocrmService.Filter(new Filters.FilterContatoCRM { Cliente = id }, uri);
        if (contatocrmExists7 != null && contatocrmExists7.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Contato C R M associados a ele.";
        var contratosExists8 = await contratosService.Filter(new Filters.FilterContratos { Cliente = id }, uri);
        if (contratosExists8 != null && contratosExists8.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Contratos associados a ele.";
        var dadosprocuracaoExists9 = await dadosprocuracaoService.Filter(new Filters.FilterDadosProcuracao { Cliente = id }, uri);
        if (dadosprocuracaoExists9 != null && dadosprocuracaoExists9.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Dados Procuracao associados a ele.";
        var diario2Exists10 = await diario2Service.Filter(new Filters.FilterDiario2 { Cliente = id }, uri);
        if (diario2Exists10 != null && diario2Exists10.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Diario2 associados a ele.";
        var gruposempresasExists11 = await gruposempresasService.Filter(new Filters.FilterGruposEmpresas { Cliente = id }, uri);
        if (gruposempresasExists11 != null && gruposempresasExists11.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Grupos Empresas associados a ele.";
        var gruposempresascliExists12 = await gruposempresascliService.Filter(new Filters.FilterGruposEmpresasCli { Cliente = id }, uri);
        if (gruposempresascliExists12 != null && gruposempresascliExists12.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Grupos Empresas Cli associados a ele.";
        var honorariosdadoscontratoExists13 = await honorariosdadoscontratoService.Filter(new Filters.FilterHonorariosDadosContrato { Cliente = id }, uri);
        if (honorariosdadoscontratoExists13 != null && honorariosdadoscontratoExists13.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Honorarios Dados Contrato associados a ele.";
        var horastrabExists14 = await horastrabService.Filter(new Filters.FilterHorasTrab { Cliente = id }, uri);
        if (horastrabExists14 != null && horastrabExists14.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Horas Trab associados a ele.";
        var ligacoesExists15 = await ligacoesService.Filter(new Filters.FilterLigacoes { Cliente = id }, uri);
        if (ligacoesExists15 != null && ligacoesExists15.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Ligacoes associados a ele.";
        var livrocaixaclientesExists16 = await livrocaixaclientesService.Filter(new Filters.FilterLivroCaixaClientes { Cliente = id }, uri);
        if (livrocaixaclientesExists16 != null && livrocaixaclientesExists16.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Livro Caixa Clientes associados a ele.";
        var operadoresExists17 = await operadoresService.Filter(new Filters.FilterOperadores { Cliente = id }, uri);
        if (operadoresExists17 != null && operadoresExists17.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Operadores associados a ele.";
        var preclientesExists18 = await preclientesService.Filter(new Filters.FilterPreClientes { IDRep = id }, uri);
        if (preclientesExists18 != null && preclientesExists18.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Pre Clientes associados a ele.";
        var processosExists19 = await processosService.Filter(new Filters.FilterProcessos { Cliente = id }, uri);
        if (processosExists19 != null && processosExists19.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Processos associados a ele.";
        var prodespesasExists20 = await prodespesasService.Filter(new Filters.FilterProDespesas { Cliente = id }, uri);
        if (prodespesasExists20 != null && prodespesasExists20.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Pro Despesas associados a ele.";
        var recadosExists21 = await recadosService.Filter(new Filters.FilterRecados { Cliente = id }, uri);
        if (recadosExists21 != null && recadosExists21.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Recados associados a ele.";
        var reuniaoExists22 = await reuniaoService.Filter(new Filters.FilterReuniao { Cliente = id }, uri);
        if (reuniaoExists22 != null && reuniaoExists22.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Reunião associados a ele.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.Clientes reg, IClientesService service, ICidadeReader cidadeReader, IRegimeTributacaoReader regimetributacaoReader, IEnquadramentoEmpresaReader enquadramentoempresaReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        if (await IsDuplicado(reg, service, uri))
            return $"Clientes '{reg.Nome}'  - Nome";
        if (!string.IsNullOrWhiteSpace(reg.CPF))
        {
            var testaCpf = await IsCpfDuplicado(reg, service, uri);
            if (testaCpf.Item1 && testaCpf.Item2 != null)
            {
                return $"Clientes ({testaCpf.Item2.Nome}) com cpf '{reg.CPF.MaskCpf()}' já cadastrado.";
            }
            else if (testaCpf.Item1)
            {
                return $"Clientes com cpf '{reg.CPF.MaskCpf()}' já cadastrado.";
            }
        }

        if (!string.IsNullOrWhiteSpace(reg.CNPJ) && await IsCnpjDuplicado(reg, service, uri))
            return $"Clientes com cnpj {reg.CNPJ.MaskCnpj()} já cadastrado.";
        // Cidade
        if (!reg.Cidade.IsEmptyIDNumber())
        {
            var regCidade = cidadeReader.Read(reg.Cidade, oCnn);
            if (regCidade == null || regCidade.Id != reg.Cidade)
            {
                return $"Cidade não encontrado ({regCidade?.Id}).";
            }
        }

        // RegimeTributacao
        if (!reg.RegimeTributacao.IsEmptyIDNumber())
        {
            var regRegimeTributacao = regimetributacaoReader.Read(reg.RegimeTributacao, oCnn);
            if (regRegimeTributacao == null || regRegimeTributacao.Id != reg.RegimeTributacao)
            {
                return $"Regime Tributacao não encontrado ({regRegimeTributacao?.Id}).";
            }
        }

        // EnquadramentoEmpresa
        if (!reg.EnquadramentoEmpresa.IsEmptyIDNumber())
        {
            var regEnquadramentoEmpresa = enquadramentoempresaReader.Read(reg.EnquadramentoEmpresa, oCnn);
            if (regEnquadramentoEmpresa == null || regEnquadramentoEmpresa.Id != reg.EnquadramentoEmpresa)
            {
                return $"Enquadramento Empresa não encontrado ({regEnquadramentoEmpresa?.Id}).";
            }
        }

        return string.Empty;
    }

    private async Task<bool> IsDuplicado(Models.Clientes reg, IClientesService service, string uri)
    {
        var existingClientes = (await service.Filter(new Filters.FilterClientes { Nome = reg.Nome }, uri)).FirstOrDefault(); // TRACK 10042025
        return existingClientes != null && existingClientes.Id > 0 && existingClientes.Id != reg.Id;
    }

    private async Task<bool> IsCnpjDuplicado(Models.Clientes reg, IClientesService service, string uri)
    {
        if (reg.CNPJ.Length == 0)
            return false;
        var existingClientes = (await service.Filter(new Filters.FilterClientes { CNPJ = reg.CNPJ.ClearInputCnpj() }, uri)).FirstOrDefault();
        return existingClientes != null && existingClientes.Id > 0 && existingClientes.Id != reg.Id;
    }

    private async Task<(bool, ClientesResponseAll? )> IsCpfDuplicado(Models.Clientes reg, IClientesService service, string uri)
    {
        if (reg.CPF.Length == 0)
            return (false, null);
        var existingClientes = (await service.Filter(new Filters.FilterClientes { CPF = reg.CPF.ClearInputCpf() }, uri)).FirstOrDefault();
        return (existingClientes != null && existingClientes.Id > 0 && existingClientes.Id != reg.Id, existingClientes);
    }
}