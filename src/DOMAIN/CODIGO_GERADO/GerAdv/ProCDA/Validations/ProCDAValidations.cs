#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProCDAValidation
{
    Task<string> ValidateReg(Models.ProCDA reg, IProCDAService service, IProcessosReader processosReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, IProCDAService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class ProCDAValidation : IProCDAValidation
{
    public async Task<string> CanDelete(int id, IProCDAService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.ProCDA reg, IProCDAService service, IProcessosReader processosReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        if (await IsDuplicado(reg, service, uri))
            return $"Pro C D A '{reg.Nome}' Nome e/ou Processo";
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

    private async Task<bool> IsDuplicado(Models.ProCDA reg, IProCDAService service, string uri)
    {
        var existingProCDA = (await service.Filter(new Filters.FilterProCDA { Nome = reg.Nome, Processo = reg.Processo }, uri)).FirstOrDefault(); // TRACK 10042025
        return existingProCDA != null && existingProCDA.Id > 0 && existingProCDA.Id != reg.Id;
    }
}