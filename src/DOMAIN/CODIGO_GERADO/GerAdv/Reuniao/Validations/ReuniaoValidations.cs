#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IReuniaoValidation
{
    Task<string> ValidateReg(Models.Reuniao reg, IReuniaoService service, IClientesReader clientesReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, IReuniaoService service, IReuniaoPessoasService reuniaopessoasService, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class ReuniaoValidation : IReuniaoValidation
{
    public async Task<string> CanDelete(int id, IReuniaoService service, IReuniaoPessoasService reuniaopessoasService, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        var reuniaopessoasExists = await reuniaopessoasService.Filter(new Filters.FilterReuniaoPessoas { Reuniao = id }, uri);
        if (reuniaopessoasExists != null && reuniaopessoasExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Reuniao Pessoas associados a ele.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.Reuniao reg, IReuniaoService service, IClientesReader clientesReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
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