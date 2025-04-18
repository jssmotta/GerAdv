#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProValoresValidation
{
    Task<string> ValidateReg(Models.ProValores reg, IProValoresService service, IProcessosReader processosReader, ITipoValorProcessoReader tipovalorprocessoReader, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class ProValoresValidation : IProValoresValidation
{
    public async Task<string> ValidateReg(Models.ProValores reg, IProValoresService service, IProcessosReader processosReader, ITipoValorProcessoReader tipovalorprocessoReader, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        // Processos
        if (!reg.Processo.IsEmptyIDNumber())
        {
            var regProcessos = processosReader.Read(reg.Processo, oCnn);
            if (regProcessos == null || regProcessos.Id != reg.Processo)
            {
                return $"Processos não encontrado ({regProcessos?.Id}).";
            }
        }

        // TipoValorProcesso
        if (!reg.TipoValorProcesso.IsEmptyIDNumber())
        {
            var regTipoValorProcesso = tipovalorprocessoReader.Read(reg.TipoValorProcesso, oCnn);
            if (regTipoValorProcesso == null || regTipoValorProcesso.Id != reg.TipoValorProcesso)
            {
                return $"Tipo Valor Processo não encontrado ({regTipoValorProcesso?.Id}).";
            }
        }

        return string.Empty;
    }
}