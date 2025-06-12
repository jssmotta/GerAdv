#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IGruposEmpresasCliValidation
{
    Task<string> ValidateReg(Models.GruposEmpresasCli reg, IGruposEmpresasCliService service, IGruposEmpresasReader gruposempresasReader, IClientesReader clientesReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, IGruposEmpresasCliService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class GruposEmpresasCliValidation : IGruposEmpresasCliValidation
{
    public async Task<string> CanDelete(int id, IGruposEmpresasCliService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.GruposEmpresasCli reg, IGruposEmpresasCliService service, IGruposEmpresasReader gruposempresasReader, IClientesReader clientesReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        // GruposEmpresas
        if (!reg.Grupo.IsEmptyIDNumber())
        {
            var regGruposEmpresas = gruposempresasReader.Read(reg.Grupo, oCnn);
            if (regGruposEmpresas == null || regGruposEmpresas.Id != reg.Grupo)
            {
                return $"Grupos Empresas não encontrado ({regGruposEmpresas?.Id}).";
            }
        }

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
}