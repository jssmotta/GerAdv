#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IGUTMatrizValidation
{
    Task<string> ValidateReg(Models.GUTMatriz reg, IGUTMatrizService service, IGUTTipoReader guttipoReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, IGUTMatrizService service, IGUTAtividadesMatrizService gutatividadesmatrizService, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class GUTMatrizValidation : IGUTMatrizValidation
{
    public async Task<string> CanDelete(int id, IGUTMatrizService service, IGUTAtividadesMatrizService gutatividadesmatrizService, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        var gutatividadesmatrizExists0 = await gutatividadesmatrizService.Filter(new Filters.FilterGUTAtividadesMatriz { GUTMatriz = id }, uri);
        if (gutatividadesmatrizExists0 != null && gutatividadesmatrizExists0.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela G U T Atividades Matriz associados a ele.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.GUTMatriz reg, IGUTMatrizService service, IGUTTipoReader guttipoReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Descricao))
            return "Descricao é obrigatório";
        // GUTTipo
        if (!reg.GUTTipo.IsEmptyIDNumber())
        {
            var regGUTTipo = guttipoReader.Read(reg.GUTTipo, oCnn);
            if (regGUTTipo == null || regGUTTipo.Id != reg.GUTTipo)
            {
                return $"G U T Tipo não encontrado ({regGUTTipo?.Id}).";
            }
        }

        return string.Empty;
    }
}