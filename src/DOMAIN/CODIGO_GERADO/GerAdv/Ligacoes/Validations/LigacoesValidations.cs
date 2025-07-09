#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ILigacoesValidation
{
    Task<string> ValidateReg(Models.Ligacoes reg, ILigacoesService service, IClientesReader clientesReader, IRamalReader ramalReader, IProcessosReader processosReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, ILigacoesService service, IRecadosService recadosService, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class LigacoesValidation : ILigacoesValidation
{
    public async Task<string> CanDelete(int id, ILigacoesService service, IRecadosService recadosService, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        var recadosExists0 = await recadosService.Filter(new Filters.FilterRecados { Ligacoes = id }, uri);
        if (recadosExists0 != null && recadosExists0.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Recados associados a ele.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.Ligacoes reg, ILigacoesService service, IClientesReader clientesReader, IRamalReader ramalReader, IProcessosReader processosReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        // Clientes
        if (!reg.Cliente.IsEmptyIDNumber())
        {
            var regClientes = clientesReader.Read(reg.Cliente, oCnn);
            if (regClientes == null || regClientes.Id != reg.Cliente)
            {
                return $"Clientes não encontrado ({regClientes?.Id}).";
            }
        }

        // Ramal
        if (!reg.Ramal.IsEmptyIDNumber())
        {
            var regRamal = ramalReader.Read(reg.Ramal, oCnn);
            if (regRamal == null || regRamal.Id != reg.Ramal)
            {
                return $"Ramal não encontrado ({regRamal?.Id}).";
            }
        }

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
}