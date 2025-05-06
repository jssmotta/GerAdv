#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITribunalValidation
{
    Task<string> ValidateReg(Models.Tribunal reg, ITribunalService service, IAreaReader areaReader, IJusticaReader justicaReader, IInstanciaReader instanciaReader, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class TribunalValidation : ITribunalValidation
{
    public async Task<string> ValidateReg(Models.Tribunal reg, ITribunalService service, IAreaReader areaReader, IJusticaReader justicaReader, IInstanciaReader instanciaReader, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        if (await IsDuplicado(reg, service, uri))
            return $"Tribunal '{reg.Nome}' já cadastrado.";
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

        // Instancia
        if (!reg.Instancia.IsEmptyIDNumber())
        {
            var regInstancia = instanciaReader.Read(reg.Instancia, oCnn);
            if (regInstancia == null || regInstancia.Id != reg.Instancia)
            {
                return $"Instancia não encontrado ({regInstancia?.Id}).";
            }
        }

        return string.Empty;
    }

    private async Task<bool> IsDuplicado(Models.Tribunal reg, ITribunalService service, string uri)
    {
        var existingTribunal = (await service.Filter(new Filters.FilterTribunal { Area = reg.Area, Descricao = reg.Descricao, Instancia = reg.Instancia, Justica = reg.Justica }, uri)).FirstOrDefault(); // TRACK 10042025
        return existingTribunal != null && existingTribunal.Id > 0 && existingTribunal.Id != reg.Id;
    }
}