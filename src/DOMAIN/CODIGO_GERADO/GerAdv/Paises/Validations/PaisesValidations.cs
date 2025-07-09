#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IPaisesValidation
{
    Task<string> ValidateReg(Models.Paises reg, IPaisesService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, IPaisesService service, IUFService ufService, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class PaisesValidation : IPaisesValidation
{
    public async Task<string> CanDelete(int id, IPaisesService service, IUFService ufService, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        var ufExists0 = await ufService.Filter(new Filters.FilterUF { Pais = id }, uri);
        if (ufExists0 != null && ufExists0.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela UF associados a ele.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.Paises reg, IPaisesService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        if (await IsDuplicado(reg, service, uri))
            return $"Paises '{reg.Nome}'  - Nome";
        return string.Empty;
    }

    private async Task<bool> IsDuplicado(Models.Paises reg, IPaisesService service, string uri)
    {
        var existingPaises = (await service.Filter(new Filters.FilterPaises { Nome = reg.Nome }, uri)).FirstOrDefault(); // TRACK 10042025
        return existingPaises != null && existingPaises.Id > 0 && existingPaises.Id != reg.Id;
    }
}