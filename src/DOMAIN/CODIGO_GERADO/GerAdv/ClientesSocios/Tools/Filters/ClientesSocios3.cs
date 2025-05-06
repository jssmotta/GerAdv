#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Filters;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class FilterClientesSocios
{
    [JsonPropertyName("operator")]
    public string Operator { get; set; } = TSql.And;

    [JsonPropertyName("idade")]
    public int Idade { get; set; } = -2147483648;

    [JsonPropertyName("qualificacao")]
    public string Qualificacao { get; set; } = string.Empty;

    [JsonPropertyName("dtnasc")]
    public string DtNasc { get; set; } = string.Empty;

    [JsonPropertyName("nome")]
    public string Nome { get; set; } = string.Empty;

    [JsonPropertyName("site")]
    public string Site { get; set; } = string.Empty;

    [JsonPropertyName("representantelegal")]
    public string RepresentanteLegal { get; set; } = string.Empty;

    [JsonPropertyName("cliente")]
    public int Cliente { get; set; } = -2147483648;

    [JsonPropertyName("endereco")]
    public string Endereco { get; set; } = string.Empty;

    [JsonPropertyName("bairro")]
    public string Bairro { get; set; } = string.Empty;

    [JsonPropertyName("cep")]
    public string CEP { get; set; } = string.Empty;

    [JsonPropertyName("cidade")]
    public int Cidade { get; set; } = -2147483648;

    [JsonPropertyName("rg")]
    public string RG { get; set; } = string.Empty;

    [JsonPropertyName("cpf")]
    public string CPF { get; set; } = string.Empty;

    [JsonPropertyName("fone")]
    public string Fone { get; set; } = string.Empty;

    [JsonPropertyName("participacao")]
    public string Participacao { get; set; } = string.Empty;

    [JsonPropertyName("cargo")]
    public string Cargo { get; set; } = string.Empty;

    [JsonPropertyName("email")]
    public string EMail { get; set; } = string.Empty;

    [JsonPropertyName("obs")]
    public string Obs { get; set; } = string.Empty;

    [JsonPropertyName("cnh")]
    public string CNH { get; set; } = string.Empty;

    [JsonPropertyName("datacontrato")]
    public string DataContrato { get; set; } = string.Empty;

    [JsonPropertyName("cnpj")]
    public string CNPJ { get; set; } = string.Empty;

    [JsonPropertyName("inscest")]
    public string InscEst { get; set; } = string.Empty;

    [JsonPropertyName("socioempresaadminnome")]
    public string SocioEmpresaAdminNome { get; set; } = string.Empty;

    [JsonPropertyName("enderecosocio")]
    public string EnderecoSocio { get; set; } = string.Empty;

    [JsonPropertyName("bairrosocio")]
    public string BairroSocio { get; set; } = string.Empty;

    [JsonPropertyName("cepsocio")]
    public string CEPSocio { get; set; } = string.Empty;

    [JsonPropertyName("cidadesocio")]
    public int CidadeSocio { get; set; } = -2147483648;

    [JsonPropertyName("rgdataexp")]
    public string RGDataExp { get; set; } = string.Empty;

    [JsonPropertyName("fax")]
    public string Fax { get; set; } = string.Empty;

    [JsonPropertyName("class")]
    public string Class { get; set; } = string.Empty;

    [JsonPropertyName("guid")]
    public string GUID { get; set; } = string.Empty;
}