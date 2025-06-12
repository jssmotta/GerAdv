#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ILivroCaixaValidation
{
    Task<string> ValidateReg(Models.LivroCaixa reg, ILivroCaixaService service, IProcessosReader processosReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, ILivroCaixaService service, ILivroCaixaClientesService livrocaixaclientesService, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class LivroCaixaValidation : ILivroCaixaValidation
{
    public async Task<string> CanDelete(int id, ILivroCaixaService service, ILivroCaixaClientesService livrocaixaclientesService, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        var livrocaixaclientesExists = await livrocaixaclientesService.Filter(new Filters.FilterLivroCaixaClientes { LivroCaixa = id }, uri);
        if (livrocaixaclientesExists != null && livrocaixaclientesExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Livro Caixa Clientes associados a ele.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.LivroCaixa reg, ILivroCaixaService service, IProcessosReader processosReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
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