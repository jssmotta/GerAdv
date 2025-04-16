#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IPoderJudiciarioAssociadoValidation
{
    Task<string> ValidateReg(Models.PoderJudiciarioAssociado reg, IPoderJudiciarioAssociadoService service, IJusticaReader justicaReader, IAreaReader areaReader, ITribunalReader tribunalReader, IForoReader foroReader, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class PoderJudiciarioAssociadoValidation : IPoderJudiciarioAssociadoValidation
{
    public async Task<string> ValidateReg(Models.PoderJudiciarioAssociado reg, IPoderJudiciarioAssociadoService service, IJusticaReader justicaReader, IAreaReader areaReader, ITribunalReader tribunalReader, IForoReader foroReader, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
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

        // Tribunal
        if (reg.Tribunal.IsEmptyIDNumber())
        {
            var regTribunal = tribunalReader.Read(reg.Tribunal, oCnn);
            if (regTribunal == null || regTribunal.Id != reg.Tribunal)
            {
                return $"Tribunal não encontrado ({regTribunal?.Id}).";
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

        return string.Empty;
    }
}