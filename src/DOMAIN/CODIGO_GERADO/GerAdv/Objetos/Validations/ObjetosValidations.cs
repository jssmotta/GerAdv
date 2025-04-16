#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IObjetosValidation
{
    Task<string> ValidateReg(Models.Objetos reg, IObjetosService service, IJusticaReader justicaReader, IAreaReader areaReader, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class ObjetosValidation : IObjetosValidation
{
    public async Task<string> ValidateReg(Models.Objetos reg, IObjetosService service, IJusticaReader justicaReader, IAreaReader areaReader, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        if (await IsDuplicado(reg, service, uri))
            return $"Objetos '{reg.Nome}' já cadastrado.";
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

    private async Task<bool> IsDuplicado(Models.Objetos reg, IObjetosService service, string uri)
    {
        var existingObjetos = (await service.Filter(new Filters.FilterObjetos { Area = reg.Area, Justica = reg.Justica, Nome = reg.Nome }, uri)).FirstOrDefault(); // TRACK 10042025
        return existingObjetos != null && existingObjetos.Id > 0 && existingObjetos.Id != reg.Id;
    }
}