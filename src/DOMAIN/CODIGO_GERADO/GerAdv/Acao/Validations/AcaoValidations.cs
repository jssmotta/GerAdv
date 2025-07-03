#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAcaoValidation
{
    Task<string> ValidateReg(Models.Acao reg, IAcaoService service, IJusticaReader justicaReader, IAreaReader areaReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, IAcaoService service, IInstanciaService instanciaService, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class AcaoValidation : IAcaoValidation
{
    public async Task<string> CanDelete(int id, IAcaoService service, IInstanciaService instanciaService, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        var instanciaExists = await instanciaService.Filter(new Filters.FilterInstancia { Acao = id }, uri);
        if (instanciaExists != null && instanciaExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Instancia associados a ele.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.Acao reg, IAcaoService service, IJusticaReader justicaReader, IAreaReader areaReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Descricao))
            return "Descricao é obrigatório";
        if (await IsDuplicado(reg, service, uri))
            return $"Acao '{reg.Descricao}' Area e/ou Descricao e/ou Justica";
        // Justica
        if (!reg.Justica.IsEmptyIDNumber())
        {
            var regJustica = justicaReader.Read(reg.Justica, oCnn);
            if (regJustica == null || regJustica.Id != reg.Justica)
            {
                return $"Justica não encontrado ({regJustica?.Id}).";
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

        return string.Empty;
    }

    private async Task<bool> IsDuplicado(Models.Acao reg, IAcaoService service, string uri)
    {
        var existingAcao = (await service.Filter(new Filters.FilterAcao { Area = reg.Area, Descricao = reg.Descricao, Justica = reg.Justica }, uri)).FirstOrDefault(); // TRACK 10042025
        return existingAcao != null && existingAcao.Id > 0 && existingAcao.Id != reg.Id;
    }
}