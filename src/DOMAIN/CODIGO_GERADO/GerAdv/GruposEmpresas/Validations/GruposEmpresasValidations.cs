#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IGruposEmpresasValidation
{
    Task<string> ValidateReg(Models.GruposEmpresas reg, IGruposEmpresasService service, IOponentesReader oponentesReader, IClientesReader clientesReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, IGruposEmpresasService service, IGruposEmpresasCliService gruposempresascliService, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class GruposEmpresasValidation : IGruposEmpresasValidation
{
    public async Task<string> CanDelete(int id, IGruposEmpresasService service, IGruposEmpresasCliService gruposempresascliService, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        var gruposempresascliExists = await gruposempresascliService.Filter(new Filters.FilterGruposEmpresasCli { Grupo = id }, uri);
        if (gruposempresascliExists != null && gruposempresascliExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Grupos Empresas Cli associados a ele.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.GruposEmpresas reg, IGruposEmpresasService service, IOponentesReader oponentesReader, IClientesReader clientesReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Descricao))
            return "Descricao é obrigatório";
        // Oponentes
        if (!reg.Oponente.IsEmptyIDNumber())
        {
            var regOponentes = oponentesReader.Read(reg.Oponente, oCnn);
            if (regOponentes == null || regOponentes.Id != reg.Oponente)
            {
                return $"Oponentes não encontrado ({regOponentes?.Id}).";
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