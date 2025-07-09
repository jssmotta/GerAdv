#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IGUTAtividadesValidation
{
    Task<string> ValidateReg(Models.GUTAtividades reg, IGUTAtividadesService service, IGUTPeriodicidadeReader gutperiodicidadeReader, IOperadorReader operadorReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, IGUTAtividadesService service, IGUTAtividadesMatrizService gutatividadesmatrizService, IGUTPeriodicidadeStatusService gutperiodicidadestatusService, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class GUTAtividadesValidation : IGUTAtividadesValidation
{
    public async Task<string> CanDelete(int id, IGUTAtividadesService service, IGUTAtividadesMatrizService gutatividadesmatrizService, IGUTPeriodicidadeStatusService gutperiodicidadestatusService, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        var gutatividadesmatrizExists0 = await gutatividadesmatrizService.Filter(new Filters.FilterGUTAtividadesMatriz { GUTAtividade = id }, uri);
        if (gutatividadesmatrizExists0 != null && gutatividadesmatrizExists0.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela G U T Atividades Matriz associados a ele.";
        var gutperiodicidadestatusExists1 = await gutperiodicidadestatusService.Filter(new Filters.FilterGUTPeriodicidadeStatus { GUTAtividade = id }, uri);
        if (gutperiodicidadestatusExists1 != null && gutperiodicidadestatusExists1.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela G U T Periodicidade Status associados a ele.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.GUTAtividades reg, IGUTAtividadesService service, IGUTPeriodicidadeReader gutperiodicidadeReader, IOperadorReader operadorReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        // GUTPeriodicidade
        if (!reg.GUTPeriodicidade.IsEmptyIDNumber())
        {
            var regGUTPeriodicidade = gutperiodicidadeReader.Read(reg.GUTPeriodicidade, oCnn);
            if (regGUTPeriodicidade == null || regGUTPeriodicidade.Id != reg.GUTPeriodicidade)
            {
                return $"G U T Periodicidade não encontrado ({regGUTPeriodicidade?.Id}).";
            }
        }

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
}