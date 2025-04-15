#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IStatusBiuValidation
{
    Task<string> ValidateReg(Models.StatusBiu reg, IStatusBiuService service, ITipoStatusBiuReader tipostatusbiuReader, IOperadorReader operadorReader, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class StatusBiuValidation : IStatusBiuValidation
{
    public async Task<string> ValidateReg(Models.StatusBiu reg, IStatusBiuService service, ITipoStatusBiuReader tipostatusbiuReader, IOperadorReader operadorReader, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        // TipoStatusBiu
        if (reg.TipoStatusBiu.IsEmptyIDNumber())
        {
            var regTipoStatusBiu = tipostatusbiuReader.Read(reg.TipoStatusBiu, oCnn);
            if (regTipoStatusBiu == null || regTipoStatusBiu.Id != reg.TipoStatusBiu)
            {
                return $"Staus  Usuários não encontrado ({regTipoStatusBiu?.Id}).";
            }
        }

        // Operador
        if (reg.Operador.IsEmptyIDNumber())
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