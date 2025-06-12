#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoRecursoValidation
{
    Task<string> ValidateReg(Models.TipoRecurso reg, ITipoRecursoService service, IJusticaReader justicaReader, IAreaReader areaReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, ITipoRecursoService service, IInstanciaService instanciaService, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class TipoRecursoValidation : ITipoRecursoValidation
{
    public async Task<string> CanDelete(int id, ITipoRecursoService service, IInstanciaService instanciaService, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        var instanciaExists = await instanciaService.Filter(new Filters.FilterInstancia { TipoRecurso = id }, uri);
        if (instanciaExists != null && instanciaExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Instancia associados a ele.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.TipoRecurso reg, ITipoRecursoService service, IJusticaReader justicaReader, IAreaReader areaReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Descricao))
            return "Descricao é obrigatório";
        if (await IsDuplicado(reg, service, uri))
            return $"TipoRecurso '{reg.Descricao}' já cadastrado.";
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

    private async Task<bool> IsDuplicado(Models.TipoRecurso reg, ITipoRecursoService service, string uri)
    {
        var existingTipoRecurso = (await service.Filter(new Filters.FilterTipoRecurso { Area = reg.Area, Descricao = reg.Descricao, Justica = reg.Justica }, uri)).FirstOrDefault(); // TRACK 10042025
        return existingTipoRecurso != null && existingTipoRecurso.Id > 0 && existingTipoRecurso.Id != reg.Id;
    }
}