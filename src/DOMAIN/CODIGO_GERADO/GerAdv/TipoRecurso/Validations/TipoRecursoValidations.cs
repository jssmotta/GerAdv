#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoRecursoValidation
{
    Task<string> ValidateReg(Models.TipoRecurso reg, ITipoRecursoService service, IJusticaReader justicaReader, IAreaReader areaReader, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class TipoRecursoValidation : ITipoRecursoValidation
{
    public async Task<string> ValidateReg(Models.TipoRecurso reg, ITipoRecursoService service, IJusticaReader justicaReader, IAreaReader areaReader, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Descricao))
            return "Descricao é obrigatório";
        // Justica
        if (reg.Justica.IsEmptyIDNumber())
        {
            var regJustica = justicaReader.Read(reg.Justica, oCnn);
            if (regJustica == null || regJustica.Id != reg.Justica)
            {
                return $"Justica não encontrado ({regJustica?.Id}).";
            }
        }

        // Area
        if (reg.Area.IsEmptyIDNumber())
        {
            var regArea = areaReader.Read(reg.Area, oCnn);
            if (regArea == null || regArea.Id != reg.Area)
            {
                return $"Area não encontrado ({regArea?.Id}).";
            }
        }

        return string.Empty;
    }
}