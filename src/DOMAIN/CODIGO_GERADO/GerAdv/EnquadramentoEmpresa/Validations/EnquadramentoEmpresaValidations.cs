#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IEnquadramentoEmpresaValidation
{
    Task<string> ValidateReg(Models.EnquadramentoEmpresa reg, IEnquadramentoEmpresaService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, IEnquadramentoEmpresaService service, IClientesService clientesService, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class EnquadramentoEmpresaValidation : IEnquadramentoEmpresaValidation
{
    public async Task<string> CanDelete(int id, IEnquadramentoEmpresaService service, IClientesService clientesService, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        var clientesExists = await clientesService.Filter(new Filters.FilterClientes { EnquadramentoEmpresa = id }, uri);
        if (clientesExists != null && clientesExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Clientes associados a ele.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.EnquadramentoEmpresa reg, IEnquadramentoEmpresaService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        if (await IsDuplicado(reg, service, uri))
            return $"Enquadramento Empresa '{reg.Nome}'  - Nome";
        return string.Empty;
    }

    private async Task<bool> IsDuplicado(Models.EnquadramentoEmpresa reg, IEnquadramentoEmpresaService service, string uri)
    {
        var existingEnquadramentoEmpresa = (await service.Filter(new Filters.FilterEnquadramentoEmpresa { Nome = reg.Nome }, uri)).FirstOrDefault(); // TRACK 10042025
        return existingEnquadramentoEmpresa != null && existingEnquadramentoEmpresa.Id > 0 && existingEnquadramentoEmpresa.Id != reg.Id;
    }
}