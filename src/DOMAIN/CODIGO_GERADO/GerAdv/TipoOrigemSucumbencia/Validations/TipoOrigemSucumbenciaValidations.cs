#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoOrigemSucumbenciaValidation
{
    Task<string> ValidateReg(Models.TipoOrigemSucumbencia reg, ITipoOrigemSucumbenciaService service, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class TipoOrigemSucumbenciaValidation : ITipoOrigemSucumbenciaValidation
{
    public async Task<string> ValidateReg(Models.TipoOrigemSucumbencia reg, ITipoOrigemSucumbenciaService service, [FromRoute, Required] string uri, SqlConnection oCnn)
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