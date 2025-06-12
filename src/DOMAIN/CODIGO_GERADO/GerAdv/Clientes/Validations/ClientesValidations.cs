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
        var agendaExists = await agendaService.Filter(new Filters.FilterAgenda { Cliente = id }, uri);
        if (agendaExists != null && agendaExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Agenda associados a ele.";
        var agendafinanceiroExists = await agendafinanceiroService.Filter(new Filters.FilterAgendaFinanceiro { Cliente = id }, uri);
        if (agendafinanceiroExists != null && agendafinanceiroExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Agenda Financeiro associados a ele.";
        var agendarepetirExists = await agendarepetirService.Filter(new Filters.FilterAgendaRepetir { Cliente = id }, uri);
        if (agendarepetirExists != null && agendarepetirExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Agenda Repetir associados a ele.";
        var anexamentoregistrosExists = await anexamentoregistrosService.Filter(new Filters.FilterAnexamentoRegistros { Cliente = id }, uri);
        if (anexamentoregistrosExists != null && anexamentoregistrosExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Anexamento Registros associados a ele.";
        var clientessociosExists = await clientessociosService.Filter(new Filters.FilterClientesSocios { Cliente = id }, uri);
        if (clientessociosExists != null && clientessociosExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Clientes Socios associados a ele.";
        var colaboradoresExists = await colaboradoresService.Filter(new Filters.FilterColaboradores { Cliente = id }, uri);
        if (colaboradoresExists != null && colaboradoresExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Colaboradores associados a ele.";
        var contacorrenteExists = await contacorrenteService.Filter(new Filters.FilterContaCorrente { Cliente = id }, uri);
        if (contacorrenteExists != null && contacorrenteExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Conta Corrente associados a ele.";
        var contatocrmExists = await contatocrmService.Filter(new Filters.FilterContatoCRM { Cliente = id }, uri);
        if (contatocrmExists != null && contatocrmExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Contato C R M associados a ele.";
        var contratosExists = await contratosService.Filter(new Filters.FilterContratos { Cliente = id }, uri);
        if (contratosExists != null && contratosExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Contratos associados a ele.";
        var dadosprocuracaoExists = await dadosprocuracaoService.Filter(new Filters.FilterDadosProcuracao { Cliente = id }, uri);
        if (dadosprocuracaoExists != null && dadosprocuracaoExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Dados Procuracao associados a ele.";
        var diario2Exists = await diario2Service.Filter(new Filters.FilterDiario2 { Cliente = id }, uri);
        if (diario2Exists != null && diario2Exists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Diario2 associados a ele.";
        var gruposempresasExists = await gruposempresasService.Filter(new Filters.FilterGruposEmpresas { Cliente = id }, uri);
        if (gruposempresasExists != null && gruposempresasExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Grupos Empresas associados a ele.";
        var gruposempresascliExists = await gruposempresascliService.Filter(new Filters.FilterGruposEmpresasCli { Cliente = id }, uri);
        if (gruposempresascliExists != null && gruposempresascliExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Grupos Empresas Cli associados a ele.";
        var honorariosdadoscontratoExists = await honorariosdadoscontratoService.Filter(new Filters.FilterHonorariosDadosContrato { Cliente = id }, uri);
        if (honorariosdadoscontratoExists != null && honorariosdadoscontratoExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Honorarios Dados Contrato associados a ele.";
        var horastrabExists = await horastrabService.Filter(new Filters.FilterHorasTrab { Cliente = id }, uri);
        if (horastrabExists != null && horastrabExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Horas Trab associados a ele.";
        var ligacoesExists = await ligacoesService.Filter(new Filters.FilterLigacoes { Cliente = id }, uri);
        if (ligacoesExists != null && ligacoesExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Ligacoes associados a ele.";
        var livrocaixaclientesExists = await livrocaixaclientesService.Filter(new Filters.FilterLivroCaixaClientes { Cliente = id }, uri);
        if (livrocaixaclientesExists != null && livrocaixaclientesExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Livro Caixa Clientes associados a ele.";
        var operadoresExists = await operadoresService.Filter(new Filters.FilterOperadores { Cliente = id }, uri);
        if (operadoresExists != null && operadoresExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Operadores associados a ele.";
        var preclientesExists = await preclientesService.Filter(new Filters.FilterPreClientes { IDRep = id }, uri);
        if (preclientesExists != null && preclientesExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Pre Clientes associados a ele.";
        var processosExists = await processosService.Filter(new Filters.FilterProcessos { Cliente = id }, uri);
        if (processosExists != null && processosExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Processos associados a ele.";
        var prodespesasExists = await prodespesasService.Filter(new Filters.FilterProDespesas { Cliente = id }, uri);
        if (prodespesasExists != null && prodespesasExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Pro Despesas associados a ele.";
        var recadosExists = await recadosService.Filter(new Filters.FilterRecados { Cliente = id }, uri);
        if (recadosExists != null && recadosExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Recados associados a ele.";
        var reuniaoExists = await reuniaoService.Filter(new Filters.FilterReuniao { Cliente = id }, uri);
        if (reuniaoExists != null && reuniaoExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Reuniao associados a ele.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.Clientes reg, IClientesService service, ICidadeReader cidadeReader, IRegimeTributacaoReader regimetributacaoReader, IEnquadramentoEmpresaReader enquadramentoempresaReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        if (await IsDuplicado(reg, service, uri))
            return $"Clientes '{reg.Nome}' já cadastrado.";
        if (!string.IsNullOrWhiteSpace(reg.CPF) && await IsCpfDuplicado(reg, service, uri))
            return $"'Clientes' com cpf '{reg.CPF.MaskCpf()}' já cadastrado.";
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
        var existingClientes = (await service.Filter(new Filters.FilterClientes { CNPJ = reg.CNPJ }, uri)).FirstOrDefault();
        return existingClientes != null && existingClientes.Id > 0 && existingClientes.Id != reg.Id;
    }

    private async Task<bool> IsCpfDuplicado(Models.Clientes reg, IClientesService service, string uri)
    {
        if (reg.CPF.Length == 0)
            return false;
        var existingClientes = (await service.Filter(new Filters.FilterClientes { CPF = reg.CPF }, uri)).FirstOrDefault();
        return existingClientes != null && existingClientes.Id > 0 && existingClientes.Id != reg.Id;
    }
}