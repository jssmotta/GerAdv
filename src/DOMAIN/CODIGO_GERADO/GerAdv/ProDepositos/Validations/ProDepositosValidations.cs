#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProDepositosValidation
{
    Task<string> ValidateReg(Models.ProDepositos reg, IProDepositosService service, IProcessosReader processosReader, IFaseReader faseReader, ITipoProDespositoReader tipoprodespositoReader, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class ProDepositosValidation : IProDepositosValidation
{
    public async Task<string> ValidateReg(Models.ProDepositos reg, IProDepositosService service, IProcessosReader processosReader, IFaseReader faseReader, ITipoProDespositoReader tipoprodespositoReader, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        // Processos
        if (reg.Processo.IsEmptyIDNumber())
        {
            var regProcessos = processosReader.Read(reg.Processo, oCnn);
            if (regProcessos == null || regProcessos.Id != reg.Processo)
            {
                return $"Processos não encontrado ({regProcessos?.Id}).";
            }
        }

        // Fase
        if (reg.Fase.IsEmptyIDNumber())
        {
            var regFase = faseReader.Read(reg.Fase, oCnn);
            if (regFase == null || regFase.Id != reg.Fase)
            {
                return $"Fase não encontrado ({regFase?.Id}).";
            }
        }

        // TipoProDesposito
        if (reg.TipoProDesposito.IsEmptyIDNumber())
        {
            var regTipoProDesposito = tipoprodespositoReader.Read(reg.TipoProDesposito, oCnn);
            if (regTipoProDesposito == null || regTipoProDesposito.Id != reg.TipoProDesposito)
            {
                return $"Tipo Pro Desposito não encontrado ({regTipoProDesposito?.Id}).";
            }
        }

        return string.Empty;
    }
}