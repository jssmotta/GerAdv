#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IGUTTipoValidation
{
    Task<string> ValidateReg(Models.GUTTipo reg, IGUTTipoService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, IGUTTipoService service, IGUTMatrizService gutmatrizService, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class GUTTipoValidation : IGUTTipoValidation
{
    public async Task<string> CanDelete(int id, IGUTTipoService service, IGUTMatrizService gutmatrizService, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        var gutmatrizExists = await gutmatrizService.Filter(new Filters.FilterGUTMatriz { GUTTipo = id }, uri);
        if (gutmatrizExists != null && gutmatrizExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela G U T Matriz associados a ele.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.GUTTipo reg, IGUTTipoService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        return string.Empty;
    }
}