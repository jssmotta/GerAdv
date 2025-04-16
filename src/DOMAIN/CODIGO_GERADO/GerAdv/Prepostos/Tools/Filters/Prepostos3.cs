﻿#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Filters;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class FilterPrepostos
{
    [JsonPropertyName("operator")]
    public string Operator { get; set; } = TSql.And;

    [JsonPropertyName("nome")]
    public string Nome { get; set; } = string.Empty;

    [JsonPropertyName("funcao")]
    public int Funcao { get; set; } = -2147483648;

    [JsonPropertyName("setor")]
    public int Setor { get; set; } = -2147483648;

    [JsonPropertyName("dtnasc")]
    public string DtNasc { get; set; } = string.Empty;

    [JsonPropertyName("qualificacao")]
    public string Qualificacao { get; set; } = string.Empty;

    [JsonPropertyName("idade")]
    public int Idade { get; set; } = -2147483648;

    [JsonPropertyName("cpf")]
    public string CPF { get; set; } = string.Empty;

    [JsonPropertyName("rg")]
    public string RG { get; set; } = string.Empty;

    [JsonPropertyName("periodo_ini")]
    public string Periodo_Ini { get; set; } = string.Empty;

    [JsonPropertyName("periodo_fim")]
    public string Periodo_Fim { get; set; } = string.Empty;

    [JsonPropertyName("registro")]
    public string Registro { get; set; } = string.Empty;

    [JsonPropertyName("ctpsnumero")]
    public string CTPSNumero { get; set; } = string.Empty;

    [JsonPropertyName("ctpsserie")]
    public string CTPSSerie { get; set; } = string.Empty;

    [JsonPropertyName("ctpsdtemissao")]
    public string CTPSDtEmissao { get; set; } = string.Empty;

    [JsonPropertyName("pis")]
    public string PIS { get; set; } = string.Empty;

    [JsonPropertyName("observacao")]
    public string Observacao { get; set; } = string.Empty;

    [JsonPropertyName("endereco")]
    public string Endereco { get; set; } = string.Empty;

    [JsonPropertyName("bairro")]
    public string Bairro { get; set; } = string.Empty;

    [JsonPropertyName("cidade")]
    public int Cidade { get; set; } = -2147483648;

    [JsonPropertyName("cep")]
    public string CEP { get; set; } = string.Empty;

    [JsonPropertyName("fone")]
    public string Fone { get; set; } = string.Empty;

    [JsonPropertyName("fax")]
    public string Fax { get; set; } = string.Empty;

    [JsonPropertyName("email")]
    public string EMail { get; set; } = string.Empty;

    [JsonPropertyName("pai")]
    public string Pai { get; set; } = string.Empty;

    [JsonPropertyName("mae")]
    public string Mae { get; set; } = string.Empty;

    [JsonPropertyName("class")]
    public string Class { get; set; } = string.Empty;
}