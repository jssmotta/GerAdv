#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IOperadorGruposAgendaValidation
{
    Task<string> ValidateReg(Models.OperadorGruposAgenda reg, IOperadorGruposAgendaService service, IOperadorReader operadorReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, IOperadorGruposAgendaService service, IOperadorGruposAgendaOperadoresService operadorgruposagendaoperadoresService, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class OperadorGruposAgendaValidation : IOperadorGruposAgendaValidation
{
    public async Task<string> CanDelete(int id, IOperadorGruposAgendaService service, IOperadorGruposAgendaOperadoresService operadorgruposagendaoperadoresService, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        var operadorgruposagendaoperadoresExists = await operadorgruposagendaoperadoresService.Filter(new Filters.FilterOperadorGruposAgendaOperadores { OperadorGruposAgenda = id }, uri);
        if (operadorgruposagendaoperadoresExists != null && operadorgruposagendaoperadoresExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Operador Grupos Agenda Operadores associados a ele.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.OperadorGruposAgenda reg, IOperadorGruposAgendaService service, IOperadorReader operadorReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        if (await IsDuplicado(reg, service, uri))
            return $"Operador Grupos Agenda '{reg.Nome}'  - Nome";
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