#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITribunalValidation
{
    Task<string> ValidateReg(Models.Tribunal reg, ITribunalService service, IAreaReader areaReader, IJusticaReader justicaReader, IInstanciaReader instanciaReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, ITribunalService service, IDivisaoTribunalService divisaotribunalService, IPoderJudiciarioAssociadoService poderjudiciarioassociadoService, ITribEnderecosService tribenderecosService, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class TribunalValidation : ITribunalValidation
{
    public async Task<string> CanDelete(int id, ITribunalService service, IDivisaoTribunalService divisaotribunalService, IPoderJudiciarioAssociadoService poderjudiciarioassociadoService, ITribEnderecosService tribenderecosService, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        var divisaotribunalExists = await divisaotribunalService.Filter(new Filters.FilterDivisaoTribunal { Tribunal = id }, uri);
        if (divisaotribunalExists != null && divisaotribunalExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Divisao Tribunal associados a ele.";
        var poderjudiciarioassociadoExists = await poderjudiciarioassociadoService.Filter(new Filters.FilterPoderJudiciarioAssociado { Tribunal = id }, uri);
        if (poderjudiciarioassociadoExists != null && poderjudiciarioassociadoExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Poder Judiciario Associado associados a ele.";
        var tribenderecosExists = await tribenderecosService.Filter(new Filters.FilterTribEnderecos { Tribunal = id }, uri);
        if (tribenderecosExists != null && tribenderecosExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Trib Endereços associados a ele.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.Tribunal reg, ITribunalService service, IAreaReader areaReader, IJusticaReader justicaReader, IInstanciaReader instanciaReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        if (await IsDuplicado(reg, service, uri))
            return $"Tribunal '{reg.Nome}' já cadastrado.";
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

        // Instancia
        if (!reg.Instancia.IsEmptyIDNumber())
        {
            var regInstancia = instanciaReader.Read(reg.Instancia, oCnn);
            if (regInstancia == null || regInstancia.Id != reg.Instancia)
            {
                return $"Instancia não encontrado ({regInstancia?.Id}).";
            }
        }

        return string.Empty;
    }

    private async Task<bool> IsDuplicado(Models.Tribunal reg, ITribunalService service, string uri)
    {
        var existingTribunal = (await service.Filter(new Filters.FilterTribunal { Area = reg.Area, Descricao = reg.Descricao, Instancia = reg.Instancia, Justica = reg.Justica }, uri)).FirstOrDefault(); // TRACK 10042025
        return existingTribunal != null && existingTribunal.Id > 0 && existingTribunal.Id != reg.Id;
    }
}