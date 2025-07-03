#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ICidadeValidation
{
    Task<string> ValidateReg(Models.Cidade reg, ICidadeService service, IUFReader ufReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, ICidadeService service, IAdvogadosService advogadosService, IAgendaService agendaService, IAgendaFinanceiroService agendafinanceiroService, IBensMateriaisService bensmateriaisService, IClientesService clientesService, IClientesSociosService clientessociosService, IColaboradoresService colaboradoresService, IDivisaoTribunalService divisaotribunalService, IEnderecosService enderecosService, IEnderecoSistemaService enderecosistemaService, IEscritoriosService escritoriosService, IFornecedoresService fornecedoresService, IForoService foroService, IFuncionariosService funcionariosService, IOponentesService oponentesService, IOponentesRepLegalService oponentesreplegalService, IOutrasPartesClienteService outraspartesclienteService, IPoderJudiciarioAssociadoService poderjudiciarioassociadoService, IPreClientesService preclientesService, IPrepostosService prepostosService, IProcessosService processosService, ITerceirosService terceirosService, ITribEnderecosService tribenderecosService, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class CidadeValidation : ICidadeValidation
{
    public async Task<string> CanDelete(int id, ICidadeService service, IAdvogadosService advogadosService, IAgendaService agendaService, IAgendaFinanceiroService agendafinanceiroService, IBensMateriaisService bensmateriaisService, IClientesService clientesService, IClientesSociosService clientessociosService, IColaboradoresService colaboradoresService, IDivisaoTribunalService divisaotribunalService, IEnderecosService enderecosService, IEnderecoSistemaService enderecosistemaService, IEscritoriosService escritoriosService, IFornecedoresService fornecedoresService, IForoService foroService, IFuncionariosService funcionariosService, IOponentesService oponentesService, IOponentesRepLegalService oponentesreplegalService, IOutrasPartesClienteService outraspartesclienteService, IPoderJudiciarioAssociadoService poderjudiciarioassociadoService, IPreClientesService preclientesService, IPrepostosService prepostosService, IProcessosService processosService, ITerceirosService terceirosService, ITribEnderecosService tribenderecosService, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        var advogadosExists = await advogadosService.Filter(new Filters.FilterAdvogados { Cidade = id }, uri);
        if (advogadosExists != null && advogadosExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Advogados associados a ele.";
        var agendaExists = await agendaService.Filter(new Filters.FilterAgenda { Cidade = id }, uri);
        if (agendaExists != null && agendaExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Agenda associados a ele.";
        var agendafinanceiroExists = await agendafinanceiroService.Filter(new Filters.FilterAgendaFinanceiro { Cidade = id }, uri);
        if (agendafinanceiroExists != null && agendafinanceiroExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Agenda Financeiro associados a ele.";
        var bensmateriaisExists = await bensmateriaisService.Filter(new Filters.FilterBensMateriais { Cidade = id }, uri);
        if (bensmateriaisExists != null && bensmateriaisExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Bens Materiais associados a ele.";
        var clientesExists = await clientesService.Filter(new Filters.FilterClientes { Cidade = id }, uri);
        if (clientesExists != null && clientesExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Clientes associados a ele.";
        var clientessociosExists = await clientessociosService.Filter(new Filters.FilterClientesSocios { Cidade = id }, uri);
        if (clientessociosExists != null && clientessociosExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Clientes Socios associados a ele.";
        var colaboradoresExists = await colaboradoresService.Filter(new Filters.FilterColaboradores { Cidade = id }, uri);
        if (colaboradoresExists != null && colaboradoresExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Colaboradores associados a ele.";
        var divisaotribunalExists = await divisaotribunalService.Filter(new Filters.FilterDivisaoTribunal { Cidade = id }, uri);
        if (divisaotribunalExists != null && divisaotribunalExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Divisao Tribunal associados a ele.";
        var enderecosExists = await enderecosService.Filter(new Filters.FilterEnderecos { Cidade = id }, uri);
        if (enderecosExists != null && enderecosExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Endereços associados a ele.";
        var enderecosistemaExists = await enderecosistemaService.Filter(new Filters.FilterEnderecoSistema { Cidade = id }, uri);
        if (enderecosistemaExists != null && enderecosistemaExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Endereco Sistema associados a ele.";
        var escritoriosExists = await escritoriosService.Filter(new Filters.FilterEscritorios { Cidade = id }, uri);
        if (escritoriosExists != null && escritoriosExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Escritorios associados a ele.";
        var fornecedoresExists = await fornecedoresService.Filter(new Filters.FilterFornecedores { Cidade = id }, uri);
        if (fornecedoresExists != null && fornecedoresExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Fornecedores associados a ele.";
        var foroExists = await foroService.Filter(new Filters.FilterForo { Cidade = id }, uri);
        if (foroExists != null && foroExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Foro associados a ele.";
        var funcionariosExists = await funcionariosService.Filter(new Filters.FilterFuncionarios { Cidade = id }, uri);
        if (funcionariosExists != null && funcionariosExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Colaborador associados a ele.";
        var oponentesExists = await oponentesService.Filter(new Filters.FilterOponentes { Cidade = id }, uri);
        if (oponentesExists != null && oponentesExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Oponentes associados a ele.";
        var oponentesreplegalExists = await oponentesreplegalService.Filter(new Filters.FilterOponentesRepLegal { Cidade = id }, uri);
        if (oponentesreplegalExists != null && oponentesreplegalExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Oponentes Rep Legal associados a ele.";
        var outraspartesclienteExists = await outraspartesclienteService.Filter(new Filters.FilterOutrasPartesCliente { Cidade = id }, uri);
        if (outraspartesclienteExists != null && outraspartesclienteExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Outras Partes Cliente associados a ele.";
        var poderjudiciarioassociadoExists = await poderjudiciarioassociadoService.Filter(new Filters.FilterPoderJudiciarioAssociado { Cidade = id }, uri);
        if (poderjudiciarioassociadoExists != null && poderjudiciarioassociadoExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Poder Judiciario Associado associados a ele.";
        var preclientesExists = await preclientesService.Filter(new Filters.FilterPreClientes { Cidade = id }, uri);
        if (preclientesExists != null && preclientesExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Pre Clientes associados a ele.";
        var prepostosExists = await prepostosService.Filter(new Filters.FilterPrepostos { Cidade = id }, uri);
        if (prepostosExists != null && prepostosExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Prepostos associados a ele.";
        var processosExists = await processosService.Filter(new Filters.FilterProcessos { Cidade = id }, uri);
        if (processosExists != null && processosExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Processos associados a ele.";
        var terceirosExists = await terceirosService.Filter(new Filters.FilterTerceiros { Cidade = id }, uri);
        if (terceirosExists != null && terceirosExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Terceiros associados a ele.";
        var tribenderecosExists = await tribenderecosService.Filter(new Filters.FilterTribEnderecos { Cidade = id }, uri);
        if (tribenderecosExists != null && tribenderecosExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Trib Endereços associados a ele.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.Cidade reg, ICidadeService service, IUFReader ufReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        if (await IsDuplicado(reg, service, uri))
            return $"Cidade '{reg.Nome}' Nome e/ou UF";
        // UF
        if (!reg.UF.IsEmptyIDNumber())
        {
            var regUF = ufReader.Read(reg.UF, oCnn);
            if (regUF == null || regUF.Id != reg.UF)
            {
                return $"UF não encontrado ({regUF?.Id}).";
            }
        }

        return string.Empty;
    }

    private async Task<bool> IsDuplicado(Models.Cidade reg, ICidadeService service, string uri)
    {
        var existingCidade = (await service.Filter(new Filters.FilterCidade { Nome = reg.Nome, UF = reg.UF }, uri)).FirstOrDefault(); // TRACK 10042025
        return existingCidade != null && existingCidade.Id > 0 && existingCidade.Id != reg.Id;
    }
}