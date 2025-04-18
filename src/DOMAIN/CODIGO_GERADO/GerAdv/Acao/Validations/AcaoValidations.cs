#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAcaoValidation
{
    Task<string> ValidateReg(Models.Acao reg, IAcaoService service, IJusticaReader justicaReader, IAreaReader areaReader, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class AcaoValidation : IAcaoValidation
{
    public async Task<string> ValidateReg(Models.Acao reg, IAcaoService service, IJusticaReader justicaReader, IAreaReader areaReader, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Descricao))
            return "Descricao é obrigatório";
        if (await IsDuplicado(reg, service, uri))
            return $"Acao '{reg.Descricao}' já cadastrado.";
        // Justica
        if (!reg.Justica.IsEmptyIDNumber())
        {
            var regJustica = justicaReader.Read(reg.Justica, oCnn);
            if (regJustica == null || regJustica.Id != reg.Justica)
            {
                return $"Justica não encontrado ({regJustica?.Id}).";
            }
        }

        // Area
        if (!reg.Area.IsEmptyIDNumber())
        {
            var regArea = areaReader.Read(reg.Area, oCnn);
            if (regArea == null || regArea.Id != reg.Area)
            {
                return $"Area não encontrado ({regArea?.Id}).";
            }
        }

        return string.Empty;
    }

    private async Task<bool> IsDuplicado(Models.Acao reg, IAcaoService service, string uri)
    {
        var existingAcao = (await service.Filter(new Filters.FilterAcao { Area = reg.Area, Descricao = reg.Descricao, Justica = reg.Justica }, uri)).FirstOrDefault(); // TRACK 10042025
        return existingAcao != null && existingAcao.Id > 0 && existingAcao.Id != reg.Id;
    }
}