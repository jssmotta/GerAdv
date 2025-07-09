#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ICargosValidation
{
    Task<string> ValidateReg(Models.Cargos reg, ICargosService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, ICargosService service, IAdvogadosService advogadosService, IColaboradoresService colaboradoresService, IFuncionariosService funcionariosService, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class CargosValidation : ICargosValidation
{
    public async Task<string> CanDelete(int id, ICargosService service, IAdvogadosService advogadosService, IColaboradoresService colaboradoresService, IFuncionariosService funcionariosService, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        var advogadosExists0 = await advogadosService.Filter(new Filters.FilterAdvogados { Cargo = id }, uri);
        if (advogadosExists0 != null && advogadosExists0.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Advogados associados a ele.";
        var colaboradoresExists1 = await colaboradoresService.Filter(new Filters.FilterColaboradores { Cargo = id }, uri);
        if (colaboradoresExists1 != null && colaboradoresExists1.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Colaboradores associados a ele.";
        var funcionariosExists2 = await funcionariosService.Filter(new Filters.FilterFuncionarios { Cargo = id }, uri);
        if (funcionariosExists2 != null && funcionariosExists2.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Colaborador associados a ele.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.Cargos reg, ICargosService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        if (await IsDuplicado(reg, service, uri))
            return $"Cargo '{reg.Nome}'  - Nome";
        return string.Empty;
    }

    private async Task<bool> IsDuplicado(Models.Cargos reg, ICargosService service, string uri)
    {
        var existingCargos = (await service.Filter(new Filters.FilterCargos { Nome = reg.Nome }, uri)).FirstOrDefault(); // TRACK 10042025
        return existingCargos != null && existingCargos.Id > 0 && existingCargos.Id != reg.Id;
    }
}