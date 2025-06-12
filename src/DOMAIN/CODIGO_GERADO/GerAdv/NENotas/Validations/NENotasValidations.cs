#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface INENotasValidation
{
    Task<string> ValidateReg(Models.NENotas reg, INENotasService service, IApensoReader apensoReader, IPrecatoriaReader precatoriaReader, IInstanciaReader instanciaReader, IProcessosReader processosReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, INENotasService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class NENotasValidation : INENotasValidation
{
    public async Task<string> CanDelete(int id, INENotasService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.NENotas reg, INENotasService service, IApensoReader apensoReader, IPrecatoriaReader precatoriaReader, IInstanciaReader instanciaReader, IProcessosReader processosReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        // Apenso
        if (!reg.Apenso.IsEmptyIDNumber())
        {
            var regApenso = apensoReader.Read(reg.Apenso, oCnn);
            if (regApenso == null || regApenso.Id != reg.Apenso)
            {
                return $"Apenso não encontrado ({regApenso?.Id}).";
            }
        }

        // Precatoria
        if (!reg.Precatoria.IsEmptyIDNumber())
        {
            var regPrecatoria = precatoriaReader.Read(reg.Precatoria, oCnn);
            if (regPrecatoria == null || regPrecatoria.Id != reg.Precatoria)
            {
                return $"Precatoria não encontrado ({regPrecatoria?.Id}).";
            }
        }

        // Instancia
        if (!reg.Instancia.IsEmptyIDNumber())
        {
            var regInstancia = instanciaReader.Read(reg.Instancia, oCnn);
            if (regInstancia == null || regInstancia.Id != reg.Instancia)
            {
                return $"Instancia não encontrado ({regInstancia?.Id}).";
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