﻿#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IBensMateriaisValidation
{
    Task<string> ValidateReg(Models.BensMateriais reg, IBensMateriaisService service, IBensClassificacaoReader bensclassificacaoReader, IFornecedoresReader fornecedoresReader, [FromRoute, Required] string uri, SqlConnection oCnn);
}

public class BensMateriaisValidation : IBensMateriaisValidation
{
    public async Task<string> ValidateReg(Models.BensMateriais reg, IBensMateriaisService service, IBensClassificacaoReader bensclassificacaoReader, IFornecedoresReader fornecedoresReader, [FromRoute, Required] string uri, SqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        if (await IsDuplicado(reg, service, uri))
            return $"BensMateriais '{reg.Nome}' já cadastrado.";
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

        return string.Empty;
    }

    private async Task<bool> IsDuplicado(Models.BensMateriais reg, IBensMateriaisService service, string uri)
    {
        var existingBensMateriais = (await service.Filter(new Filters.FilterBensMateriais { Fornecedor = reg.Fornecedor, Nome = reg.Nome }, uri)).FirstOrDefault(); // TRACK 10042025
        return existingBensMateriais != null && existingBensMateriais.Id > 0 && existingBensMateriais.Id != reg.Id;
    }
}