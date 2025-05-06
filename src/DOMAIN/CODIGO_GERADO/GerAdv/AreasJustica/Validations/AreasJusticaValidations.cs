#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAreasJusticaValidation
{
    Task<string> ValidateReg(Models.AreasJustica reg, IAreasJusticaService service, IAreaReader areaReader, IJusticaReader justicaReader, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class AreasJusticaValidation : IAreasJusticaValidation
{
    public async Task<string> ValidateReg(Models.AreasJustica reg, IAreasJusticaService service, IAreaReader areaReader, IJusticaReader justicaReader, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        // Area
        if (!reg.Area.IsEmptyIDNumber())
        {
            var regArea = areaReader.Read(reg.Area, oCnn);
            if (regArea == null || regArea.Id != reg.Area)
            {
                return $"Area não encontrado ({regArea?.Id}).";
            }
        }

        // Justica
        if (!reg.Justica.IsEmptyIDNumber())
        {
            var regJustica = justicaReader.Read(reg.Justica, oCnn);
            if (regJustica == null || regJustica.Id != reg.Justica)
            {
                return $"Justica não encontrado ({regJustica?.Id}).";
            }
        }

        return string.Empty;
    }
}