#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class OutrasPartesCliente
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Cidade - opcCidade  
    /// </summary>
    [JsonPropertyName("cidade")]
    public int Cidade { get; set; }

    /// <summary>
    /// Sem descrição - opcNome - tamanho máximo: 80 
    /// </summary>
    [JsonPropertyName("nome")]
    public string Nome { get; set; } = "";

    /// <summary>
    /// Sem descrição - opcTerceirizado  
    /// </summary>
    [JsonPropertyName("terceirizado")]
    public bool Terceirizado { get; set; }

    /// <summary>
    /// Sem descrição - opcClientePrincipal  
    /// </summary>
    [JsonPropertyName("clienteprincipal")]
    public int ClientePrincipal { get; set; }

    /// <summary>
    /// Sem descrição - opcTipo  
    /// </summary>
    [JsonPropertyName("tipo")]
    public bool Tipo { get; set; }

    /// <summary>
    /// Sem descrição - opcSexo  
    /// </summary>
    [JsonPropertyName("sexo")]
    public bool Sexo { get; set; }

    /// <summary>
    /// Sem descrição - opcDtNasc  
    /// </summary>
    [JsonPropertyName("dtnasc")]
    public string DtNasc { get; set; } = "";

    /// <summary>
    /// CPF - opcCPF - tamanho máximo: 11 
    /// </summary>
    [JsonPropertyName("cpf")]
    public string CPF { get; set; } = "";

    /// <summary>
    /// Número da Carteira de Identidade - opcRG - tamanho máximo: 30 
    /// </summary>
    [JsonPropertyName("rg")]
    public string RG { get; set; } = "";

    /// <summary>
    /// CNPJ - opcCNPJ - tamanho máximo: 14 
    /// </summary>
    [JsonPropertyName("cnpj")]
    public string CNPJ { get; set; } = "";

    /// <summary>
    /// Inscrição Estadual - opcInscEst - tamanho máximo: 15 
    /// </summary>
    [JsonPropertyName("inscest")]
    public string InscEst { get; set; } = "";

    /// <summary>
    /// Sem descrição - opcNomeFantasia - tamanho máximo: 255 
    /// </summary>
    [JsonPropertyName("nomefantasia")]
    public string NomeFantasia { get; set; } = "";

    /// <summary>
    /// Endereço - opcEndereco - tamanho máximo: 80 
    /// </summary>
    [JsonPropertyName("endereco")]
    public string Endereco { get; set; } = "";

    /// <summary>
    /// CEP - opcCEP - tamanho máximo: 10 
    /// </summary>
    [JsonPropertyName("cep")]
    public string CEP { get; set; } = "";

    /// <summary>
    /// Bairro - opcBairro - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("bairro")]
    public string Bairro { get; set; } = "";

    /// <summary>
    /// Fone - opcFone  
    /// </summary>
    [JsonPropertyName("fone")]
    public string Fone { get; set; } = "";

    /// <summary>
    /// Fax - opcFax  
    /// </summary>
    [JsonPropertyName("fax")]
    public string Fax { get; set; } = "";

    /// <summary>
    /// Sem descrição - opcEMail - tamanho máximo: 150 
    /// </summary>
    [JsonPropertyName("email")]
    public string EMail { get; set; } = "";

    /// <summary>
    /// Sem descrição - opcSite - tamanho máximo: 150 
    /// </summary>
    [JsonPropertyName("site")]
    public string Site { get; set; } = "";

    /// <summary>
    /// Classificação - opcClass - tamanho máximo: 1 
    /// </summary>
    [JsonPropertyName("class")]
    public string Class { get; set; } = "";

    /// <summary>
    /// Criar etiqueta - opcEtiqueta  
    /// </summary>
    [JsonPropertyName("etiqueta")]
    public bool Etiqueta { get; set; }

    /// <summary>
    /// Aniversário - opcAni  
    /// </summary>
    [JsonPropertyName("ani")]
    public bool Ani { get; set; }

    /// <summary>
    /// Negritar - opcBold  
    /// </summary>
    [JsonPropertyName("bold")]
    public bool Bold { get; set; }

    /// <summary>
    /// GUId - opcGUID - tamanho máximo: 150 
    /// </summary>
    [JsonPropertyName("guid")]
    public string Guid { get; set; } = "";

    [JsonPropertyName("auditor")]
    public Auditor? Auditor { get; set; }
}