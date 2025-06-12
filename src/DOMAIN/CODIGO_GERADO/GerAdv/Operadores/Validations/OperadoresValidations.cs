#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IOperadoresValidation
{
    Task<string> ValidateReg(Models.Operadores reg, IOperadoresService service, IClientesReader clientesReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, IOperadoresService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class OperadoresValidation : IOperadoresValidation
{
    public async Task<string> CanDelete(int id, IOperadoresService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.Operadores reg, IOperadoresService service, IClientesReader clientesReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        if (await IsDuplicado(reg, service, uri))
            return $"Operadores '{reg.Nome}' já cadastrado.";
        // Clientes
        if (!reg.Cliente.IsEmptyIDNumber())
        {
            var regClientes = clientesReader.Read(reg.Cliente, oCnn);
            if (regClientes == null || regClientes.Id != reg.Cliente)
            {
                return $"Clientes não encontrado ({regClientes?.Id}).";
            }
        }

        return string.Empty;
    }

    private async Task<bool> IsDuplicado(Models.Operadores reg, IOperadoresService service, string uri)
    {
        var existingOperadores = (await service.Filter(new Filters.FilterOperadores { Nome = reg.Nome }, uri)).FirstOrDefault(); // TRACK 10042025
        return existingOperadores != null && existingOperadores.Id > 0 && existingOperadores.Id != reg.Id;
    }
}