#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IBensMateriaisValidation
{
    Task<string> ValidateReg(Models.BensMateriais reg, IBensMateriaisService service, IBensClassificacaoReader bensclassificacaoReader, IFornecedoresReader fornecedoresReader, ICidadeReader cidadeReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, IBensMateriaisService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class BensMateriaisValidation : IBensMateriaisValidation
{
    public async Task<string> CanDelete(int id, IBensMateriaisService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.BensMateriais reg, IBensMateriaisService service, IBensClassificacaoReader bensclassificacaoReader, IFornecedoresReader fornecedoresReader, ICidadeReader cidadeReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        if (await IsDuplicado(reg, service, uri))
            return $"Bens Materiais '{reg.Nome}' Fornecedor e/ou Nome";
        // BensClassificacao
        if (!reg.BensClassificacao.IsEmptyIDNumber())
        {
            var regBensClassificacao = bensclassificacaoReader.Read(reg.BensClassificacao, oCnn);
            if (regBensClassificacao == null || regBensClassificacao.Id != reg.BensClassificacao)
            {
                return $"Bens Classificacao não encontrado ({regBensClassificacao?.Id}).";
            }
        }

        // Fornecedores
        if (!reg.Fornecedor.IsEmptyIDNumber())
        {
            var regFornecedores = fornecedoresReader.Read(reg.Fornecedor, oCnn);
            if (regFornecedores == null || regFornecedores.Id != reg.Fornecedor)
            {
                return $"Fornecedores não encontrado ({regFornecedores?.Id}).";
            }
        }

        // Cidade
        if (!reg.Cidade.IsEmptyIDNumber())
        {
            var regCidade = cidadeReader.Read(reg.Cidade, oCnn);
            if (regCidade == null || regCidade.Id != reg.Cidade)
            {
                return $"Cidade não encontrado ({regCidade?.Id}).";
            }
        }

        return string.Empty;
    }

    private async Task<bool> IsDuplicado(Models.BensMateriais reg, IBensMateriaisService service, string uri)
    {
        var existingBensMateriais = (await service.Filter(new Filters.FilterBensMateriais { Fornecedor = reg.Fornecedor, Nome = reg.Nome }, uri)).FirstOrDefault(); // TRACK 10042025
        return existingBensMateriais != null && existingBensMateriais.Id > 0 && existingBensMateriais.Id != reg.Id;
    }
}