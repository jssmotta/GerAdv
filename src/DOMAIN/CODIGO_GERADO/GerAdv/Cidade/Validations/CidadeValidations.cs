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
        var advogadosExists0 = await advogadosService.Filter(new Filters.FilterAdvogados { Cidade = id }, uri);
        if (advogadosExists0 != null && advogadosExists0.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Advogados associados a ele.";
        var agendaExists1 = await agendaService.Filter(new Filters.FilterAgenda { Cidade = id }, uri);
        if (agendaExists1 != null && agendaExists1.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Agenda associados a ele.";
        var agendafinanceiroExists2 = await agendafinanceiroService.Filter(new Filters.FilterAgendaFinanceiro { Cidade = id }, uri);
        if (agendafinanceiroExists2 != null && agendafinanceiroExists2.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Agenda Financeiro associados a ele.";
        var bensmateriaisExists3 = await bensmateriaisService.Filter(new Filters.FilterBensMateriais { Cidade = id }, uri);
        if (bensmateriaisExists3 != null && bensmateriaisExists3.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Bens Materiais associados a ele.";
        var clientesExists4 = await clientesService.Filter(new Filters.FilterClientes { Cidade = id }, uri);
        if (clientesExists4 != null && clientesExists4.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Clientes associados a ele.";
        var clientessociosExists5 = await clientessociosService.Filter(new Filters.FilterClientesSocios { Cidade = id }, uri);
        if (clientessociosExists5 != null && clientessociosExists5.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Clientes Socios associados a ele.";
        var colaboradoresExists6 = await colaboradoresService.Filter(new Filters.FilterColaboradores { Cidade = id }, uri);
        if (colaboradoresExists6 != null && colaboradoresExists6.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Colaboradores associados a ele.";
        var divisaotribunalExists7 = await divisaotribunalService.Filter(new Filters.FilterDivisaoTribunal { Cidade = id }, uri);
        if (divisaotribunalExists7 != null && divisaotribunalExists7.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Divisao Tribunal associados a ele.";
        var enderecosExists8 = await enderecosService.Filter(new Filters.FilterEnderecos { Cidade = id }, uri);
        if (enderecosExists8 != null && enderecosExists8.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Endereços associados a ele.";
        var enderecosistemaExists9 = await enderecosistemaService.Filter(new Filters.FilterEnderecoSistema { Cidade = id }, uri);
        if (enderecosistemaExists9 != null && enderecosistemaExists9.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Endereco Sistema associados a ele.";
        var escritoriosExists10 = await escritoriosService.Filter(new Filters.FilterEscritorios { Cidade = id }, uri);
        if (escritoriosExists10 != null && escritoriosExists10.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Escritorios associados a ele.";
        var fornecedoresExists11 = await fornecedoresService.Filter(new Filters.FilterFornecedores { Cidade = id }, uri);
        if (fornecedoresExists11 != null && fornecedoresExists11.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Fornecedores associados a ele.";
        var foroExists12 = await foroService.Filter(new Filters.FilterForo { Cidade = id }, uri);
        if (foroExists12 != null && foroExists12.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Foro associados a ele.";
        var funcionariosExists13 = await funcionariosService.Filter(new Filters.FilterFuncionarios { Cidade = id }, uri);
        if (funcionariosExists13 != null && funcionariosExists13.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Colaborador associados a ele.";
        var oponentesExists14 = await oponentesService.Filter(new Filters.FilterOponentes { Cidade = id }, uri);
        if (oponentesExists14 != null && oponentesExists14.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Oponentes associados a ele.";
        var oponentesreplegalExists15 = await oponentesreplegalService.Filter(new Filters.FilterOponentesRepLegal { Cidade = id }, uri);
        if (oponentesreplegalExists15 != null && oponentesreplegalExists15.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Oponentes Rep Legal associados a ele.";
        var outraspartesclienteExists16 = await outraspartesclienteService.Filter(new Filters.FilterOutrasPartesCliente { Cidade = id }, uri);
        if (outraspartesclienteExists16 != null && outraspartesclienteExists16.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Outras Partes Cliente associados a ele.";
        var poderjudiciarioassociadoExists17 = await poderjudiciarioassociadoService.Filter(new Filters.FilterPoderJudiciarioAssociado { Cidade = id }, uri);
        if (poderjudiciarioassociadoExists17 != null && poderjudiciarioassociadoExists17.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Poder Judiciario Associado associados a ele.";
        var preclientesExists18 = await preclientesService.Filter(new Filters.FilterPreClientes { Cidade = id }, uri);
        if (preclientesExists18 != null && preclientesExists18.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Pre Clientes associados a ele.";
        var prepostosExists19 = await prepostosService.Filter(new Filters.FilterPrepostos { Cidade = id }, uri);
        if (prepostosExists19 != null && prepostosExists19.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Prepostos associados a ele.";
        var processosExists20 = await processosService.Filter(new Filters.FilterProcessos { Cidade = id }, uri);
        if (processosExists20 != null && processosExists20.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Processos associados a ele.";
        var terceirosExists21 = await terceirosService.Filter(new Filters.FilterTerceiros { Cidade = id }, uri);
        if (terceirosExists21 != null && terceirosExists21.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Terceiros associados a ele.";
        var tribenderecosExists22 = await tribenderecosService.Filter(new Filters.FilterTribEnderecos { Cidade = id }, uri);
        if (tribenderecosExists22 != null && tribenderecosExists22.Any())
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