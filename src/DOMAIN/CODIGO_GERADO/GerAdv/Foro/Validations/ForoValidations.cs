#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IForoValidation
{
    Task<string> ValidateReg(Models.Foro reg, IForoService service, ICidadeReader cidadeReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, IForoService service, IAgendaRecordsService agendarecordsService, IDivisaoTribunalService divisaotribunalService, IInstanciaService instanciaService, IPoderJudiciarioAssociadoService poderjudiciarioassociadoService, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class ForoValidation : IForoValidation
{
    public async Task<string> CanDelete(int id, IForoService service, IAgendaRecordsService agendarecordsService, IDivisaoTribunalService divisaotribunalService, IInstanciaService instanciaService, IPoderJudiciarioAssociadoService poderjudiciarioassociadoService, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        var agendarecordsExists0 = await agendarecordsService.Filter(new Filters.FilterAgendaRecords { Foro = id }, uri);
        if (agendarecordsExists0 != null && agendarecordsExists0.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Agenda Records associados a ele.";
        var divisaotribunalExists1 = await divisaotribunalService.Filter(new Filters.FilterDivisaoTribunal { Foro = id }, uri);
        if (divisaotribunalExists1 != null && divisaotribunalExists1.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Divisao Tribunal associados a ele.";
        var instanciaExists2 = await instanciaService.Filter(new Filters.FilterInstancia { Foro = id }, uri);
        if (instanciaExists2 != null && instanciaExists2.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Instancia associados a ele.";
        var poderjudiciarioassociadoExists3 = await poderjudiciarioassociadoService.Filter(new Filters.FilterPoderJudiciarioAssociado { Foro = id }, uri);
        if (poderjudiciarioassociadoExists3 != null && poderjudiciarioassociadoExists3.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Poder Judiciario Associado associados a ele.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.Foro reg, IForoService service, ICidadeReader cidadeReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        // Cidade
        if (!reg.Cidade.IsEmptyIDNumber())
        {
            var regCidade = cidadeReader.Read(reg.Cidade, oCnn);
            if (regCidade == null || regCidade.Id != reg.Cidade)
            {
                return $"Cidade não encontrado ({regCidade?.Id}).";
            }
        }

        return string.Empty;
    }
}