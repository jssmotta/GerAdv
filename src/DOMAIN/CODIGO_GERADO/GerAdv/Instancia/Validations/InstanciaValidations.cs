#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IInstanciaValidation
{
    Task<string> ValidateReg(Models.Instancia reg, IInstanciaService service, IProcessosReader processosReader, IAcaoReader acaoReader, IForoReader foroReader, ITipoRecursoReader tiporecursoReader, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class InstanciaValidation : IInstanciaValidation
{
    public async Task<string> ValidateReg(Models.Instancia reg, IInstanciaService service, IProcessosReader processosReader, IAcaoReader acaoReader, IForoReader foroReader, ITipoRecursoReader tiporecursoReader, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.NroProcesso))
            return "NroProcesso é obrigatório";
        // Processos
        if (reg.Processo.IsEmptyIDNumber())
        {
            var regProcessos = processosReader.Read(reg.Processo, oCnn);
            if (regProcessos == null || regProcessos.Id != reg.Processo)
            {
                return $"Processos não encontrado ({regProcessos?.Id}).";
            }
        }

        // Acao
        if (reg.Acao.IsEmptyIDNumber())
        {
            var regAcao = acaoReader.Read(reg.Acao, oCnn);
            if (regAcao == null || regAcao.Id != reg.Acao)
            {
                return $"Acao não encontrado ({regAcao?.Id}).";
            }
        }

        // Foro
        if (reg.Foro.IsEmptyIDNumber())
        {
            var regForo = foroReader.Read(reg.Foro, oCnn);
            if (regForo == null || regForo.Id != reg.Foro)
            {
                return $"Foro não encontrado ({regForo?.Id}).";
            }
        }

        // TipoRecurso
        if (reg.TipoRecurso.IsEmptyIDNumber())
        {
            var regTipoRecurso = tiporecursoReader.Read(reg.TipoRecurso, oCnn);
            if (regTipoRecurso == null || regTipoRecurso.Id != reg.TipoRecurso)
            {
                return $"Tipo Recurso não encontrado ({regTipoRecurso?.Id}).";
            }
        }

        return string.Empty;
    }
}