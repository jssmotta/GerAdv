#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoOrigemSucumbenciaValidation
{
    Task<string> ValidateReg(Models.TipoOrigemSucumbencia reg, ITipoOrigemSucumbenciaService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, ITipoOrigemSucumbenciaService service, IProSucumbenciaService prosucumbenciaService, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class TipoOrigemSucumbenciaValidation : ITipoOrigemSucumbenciaValidation
{
    public async Task<string> CanDelete(int id, ITipoOrigemSucumbenciaService service, IProSucumbenciaService prosucumbenciaService, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        var prosucumbenciaExists = await prosucumbenciaService.Filter(new Filters.FilterProSucumbencia { TipoOrigemSucumbencia = id }, uri);
        if (prosucumbenciaExists != null && prosucumbenciaExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Pro Sucumbencia associados a ele.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.TipoOrigemSucumbencia reg, ITipoOrigemSucumbenciaService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        if (await IsDuplicado(reg, service, uri))
            return $"TipoOrigemSucumbencia '{reg.Nome}' já cadastrado.";
        return string.Empty;
    }

    private async Task<bool> IsDuplicado(Models.TipoOrigemSucumbencia reg, ITipoOrigemSucumbenciaService service, string uri)
    {
        var existingTipoOrigemSucumbencia = (await service.Filter(new Filters.FilterTipoOrigemSucumbencia { Nome = reg.Nome }, uri)).FirstOrDefault(); // TRACK 10042025
        return existingTipoOrigemSucumbencia != null && existingTipoOrigemSucumbencia.Id > 0 && existingTipoOrigemSucumbencia.Id != reg.Id;
    }
}