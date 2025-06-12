#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProcessOutputRequestValidation
{
    Task<string> ValidateReg(Models.ProcessOutputRequest reg, IProcessOutputRequestService service, IProcessOutputEngineReader processoutputengineReader, IOperadorReader operadorReader, IProcessosReader processosReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, IProcessOutputRequestService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class ProcessOutputRequestValidation : IProcessOutputRequestValidation
{
    public async Task<string> CanDelete(int id, IProcessOutputRequestService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.ProcessOutputRequest reg, IProcessOutputRequestService service, IProcessOutputEngineReader processoutputengineReader, IOperadorReader operadorReader, IProcessosReader processosReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        // ProcessOutputEngine
        if (!reg.ProcessOutputEngine.IsEmptyIDNumber())
        {
            var regProcessOutputEngine = processoutputengineReader.Read(reg.ProcessOutputEngine, oCnn);
            if (regProcessOutputEngine == null || regProcessOutputEngine.Id != reg.ProcessOutputEngine)
            {
                return $"Process Output Engine não encontrado ({regProcessOutputEngine?.Id}).";
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

        // Processos
        if (!reg.Processo.IsEmptyIDNumber())
        {
            var regProcessos = processosReader.Read(reg.Processo, oCnn);
            if (regProcessos == null || regProcessos.Id != reg.Processo)
            {
                return $"Processos não encontrado ({regProcessos?.Id}).";
            }
        }

        return string.Empty;
    }
}