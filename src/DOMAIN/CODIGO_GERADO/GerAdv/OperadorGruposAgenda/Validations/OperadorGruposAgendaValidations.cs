#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IOperadorGruposAgendaValidation
{
    Task<string> ValidateReg(Models.OperadorGruposAgenda reg, IOperadorGruposAgendaService service, IOperadorReader operadorReader, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class OperadorGruposAgendaValidation : IOperadorGruposAgendaValidation
{
    public async Task<string> ValidateReg(Models.OperadorGruposAgenda reg, IOperadorGruposAgendaService service, IOperadorReader operadorReader, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        if (await IsDuplicado(reg, service, uri))
            return $"OperadorGruposAgenda '{reg.Nome}' já cadastrado.";
        // Operador
        if (!reg.Operador.IsEmptyIDNumber())
        {
            var regOperador = operadorReader.Read(reg.Operador, oCnn);
            if (regOperador == null || regOperador.Id != reg.Operador)
            {
                return $"Operador não encontrado ({regOperador?.Id}).";
            }
        }

        return string.Empty;
    }

    private async Task<bool> IsDuplicado(Models.OperadorGruposAgenda reg, IOperadorGruposAgendaService service, string uri)
    {
        var existingOperadorGruposAgenda = (await service.Filter(new Filters.FilterOperadorGruposAgenda { Nome = reg.Nome }, uri)).FirstOrDefault(); // TRACK 10042025
        return existingOperadorGruposAgenda != null && existingOperadorGruposAgenda.Id > 0 && existingOperadorGruposAgenda.Id != reg.Id;
    }
}