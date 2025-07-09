#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IStatusBiuValidation
{
    Task<string> ValidateReg(Models.StatusBiu reg, IStatusBiuService service, ITipoStatusBiuReader tipostatusbiuReader, IOperadorReader operadorReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, IStatusBiuService service, IOperadorService operadorService, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class StatusBiuValidation : IStatusBiuValidation
{
    public async Task<string> CanDelete(int id, IStatusBiuService service, IOperadorService operadorService, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        var operadorExists0 = await operadorService.Filter(new Filters.FilterOperador { StatusId = id }, uri);
        if (operadorExists0 != null && operadorExists0.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Operador associados a ele.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.StatusBiu reg, IStatusBiuService service, ITipoStatusBiuReader tipostatusbiuReader, IOperadorReader operadorReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        // TipoStatusBiu
        if (!reg.TipoStatusBiu.IsEmptyIDNumber())
        {
            var regTipoStatusBiu = tipostatusbiuReader.Read(reg.TipoStatusBiu, oCnn);
            if (regTipoStatusBiu == null || regTipoStatusBiu.Id != reg.TipoStatusBiu)
            {
                return $"Staus  Usuários não encontrado ({regTipoStatusBiu?.Id}).";
            }
        }

        // Operador
        if (!reg.Operador.IsEmptyIDNumber())
        {
            var regOperador = operadorReader.Read(reg.Operador, oCnn);
            if (regOperador == null || regOperador.Id != reg.Operador)
            {
                return $"Operador não encontrado ({regOperador?.Id}).";
            }
        }

        return string.Empty;
    }
}