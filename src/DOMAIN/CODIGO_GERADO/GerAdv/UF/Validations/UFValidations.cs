#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IUFValidation
{
    Task<string> ValidateReg(Models.UF reg, IUFService service, IPaisesReader paisesReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, IUFService service, ICidadeService cidadeService, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class UFValidation : IUFValidation
{
    public async Task<string> CanDelete(int id, IUFService service, ICidadeService cidadeService, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        var cidadeExists0 = await cidadeService.Filter(new Filters.FilterCidade { UF = id }, uri);
        if (cidadeExists0 != null && cidadeExists0.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Cidade associados a ele.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.UF reg, IUFService service, IPaisesReader paisesReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.IdUF))
            return "ID é obrigatório";
        if (await IsDuplicado(reg, service, uri))
            return $"UF '{reg.IdUF}' ID e/ou Pais";
        // Paises
        if (!reg.Pais.IsEmptyIDNumber())
        {
            var regPaises = paisesReader.Read(reg.Pais, oCnn);
            if (regPaises == null || regPaises.Id != reg.Pais)
            {
                return $"Paises não encontrado ({regPaises?.Id}).";
            }
        }

        return string.Empty;
    }

    private async Task<bool> IsDuplicado(Models.UF reg, IUFService service, string uri)
    {
        var existingUF = (await service.Filter(new Filters.FilterUF { IdUF = reg.IdUF, Pais = reg.Pais }, uri)).FirstOrDefault(); // TRACK 10042025
        return existingUF != null && existingUF.Id > 0 && existingUF.Id != reg.Id;
    }
}