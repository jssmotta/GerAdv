#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoEnderecoSistemaValidation
{
    Task<string> ValidateReg(Models.TipoEnderecoSistema reg, ITipoEnderecoSistemaService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, ITipoEnderecoSistemaService service, IEnderecoSistemaService enderecosistemaService, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class TipoEnderecoSistemaValidation : ITipoEnderecoSistemaValidation
{
    public async Task<string> CanDelete(int id, ITipoEnderecoSistemaService service, IEnderecoSistemaService enderecosistemaService, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        var enderecosistemaExists0 = await enderecosistemaService.Filter(new Filters.FilterEnderecoSistema { TipoEnderecoSistema = id }, uri);
        if (enderecosistemaExists0 != null && enderecosistemaExists0.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Endereco Sistema associados a ele.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.TipoEnderecoSistema reg, ITipoEnderecoSistemaService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        if (await IsDuplicado(reg, service, uri))
            return $"Tipo Endereco Sistema '{reg.Nome}'  - Nome";
        return string.Empty;
    }

    private async Task<bool> IsDuplicado(Models.TipoEnderecoSistema reg, ITipoEnderecoSistemaService service, string uri)
    {
        var existingTipoEnderecoSistema = (await service.Filter(new Filters.FilterTipoEnderecoSistema { Nome = reg.Nome }, uri)).FirstOrDefault(); // TRACK 10042025
        return existingTipoEnderecoSistema != null && existingTipoEnderecoSistema.Id > 0 && existingTipoEnderecoSistema.Id != reg.Id;
    }
}