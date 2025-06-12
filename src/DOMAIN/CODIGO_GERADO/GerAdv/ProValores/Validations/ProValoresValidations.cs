#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProValoresValidation
{
    Task<string> ValidateReg(Models.ProValores reg, IProValoresService service, IProcessosReader processosReader, ITipoValorProcessoReader tipovalorprocessoReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, IProValoresService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class ProValoresValidation : IProValoresValidation
{
    public async Task<string> CanDelete(int id, IProValoresService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.ProValores reg, IProValoresService service, IProcessosReader processosReader, ITipoValorProcessoReader tipovalorprocessoReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
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