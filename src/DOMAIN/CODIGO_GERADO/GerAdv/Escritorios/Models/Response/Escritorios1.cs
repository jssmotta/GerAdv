#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models.Response;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class EscritoriosResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - escCidade  
    /// </summary>
    [JsonPropertyName("cidade")]
    public int Cidade { get; set; }

    /// <summary>
    /// CNPJ - escCNPJ - tamanho máximo: 14 
    /// </summary>
    [JsonPropertyName("cnpj")]
    public string CNPJ { get; set; } = "";

    /// <summary>
    /// Sem descrição - escCasa  
    /// </summary>
    [JsonPropertyName("casa")]
    public bool Casa { get; set; }

    /// <summary>
    /// Sem descrição - escParceria  
    /// </summary>
    [JsonPropertyName("parceria")]
    public bool Parceria { get; set; }

    /// <summary>
    /// Sem descrição - escNome - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("nome")]
    public string Nome { get; set; } = "";

    /// <summary>
    /// Sem descrição - escOAB - tamanho máximo: 15 
    /// </summary>
    [JsonPropertyName("oab")]
    public string OAB { get; set; } = "";

    /// <summary>
    /// Endereço - escEndereco - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("endereco")]
    public string Endereco { get; set; } = "";

    /// <summary>
    /// Bairro - escBairro - tamanho máximo: 30 
    /// </summary>
    [JsonPropertyName("bairro")]
    public string Bairro { get; set; } = "";

    /// <summary>
    /// CEP - escCEP - tamanho máximo: 10 
    /// </summary>
    [JsonPropertyName("cep")]
    public string CEP { get; set; } = "";

    /// <summary>
    /// Fone - escFone  
    /// </summary>
    [JsonPropertyName("fone")]
    public string Fone { get; set; } = "";

    /// <summary>
    /// Fax - escFax  
    /// </summary>
    [JsonPropertyName("fax")]
    public string Fax { get; set; } = "";

    /// <summary>
    /// Sem descrição - escSite - tamanho máximo: 200 
    /// </summary>
    [JsonPropertyName("site")]
    public string Site { get; set; } = "";

    /// <summary>
    /// Sem descrição - escEMail - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("email")]
    public string EMail { get; set; } = "";

    /// <summary>
    /// Sem descrição - escOBS  
    /// </summary>
    [JsonPropertyName("obs")]
    public string OBS { get; set; } = "";

    /// <summary>
    /// Sem descrição - escAdvResponsavel - tamanho máximo: 80 
    /// </summary>
    [JsonPropertyName("advresponsavel")]
    public string AdvResponsavel { get; set; } = "";

    /// <summary>
    /// Sem descrição - escSecretaria - tamanho máximo: 80 
    /// </summary>
    [JsonPropertyName("secretaria")]
    public string Secretaria { get; set; } = "";

    /// <summary>
    /// Inscrição Estadual - escInscEst - tamanho máximo: 15 
    /// </summary>
    [JsonPropertyName("inscest")]
    public string InscEst { get; set; } = "";

    /// <summary>
    /// Sem descrição - escCorrespondente  
    /// </summary>
    [JsonPropertyName("correspondente")]
    public bool Correspondente { get; set; }

    /// <summary>
    /// Sem descrição - escTop  
    /// </summary>
    [JsonPropertyName("top")]
    public bool Top { get; set; }

    /// <summary>
    /// Criar etiqueta - escEtiqueta  
    /// </summary>
    [JsonPropertyName("etiqueta")]
    public bool Etiqueta { get; set; }

    /// <summary>
    /// Negritar - escBold  
    /// </summary>
    [JsonPropertyName("bold")]
    public bool Bold { get; set; }

    /// <summary>
    /// GUId - escGUID - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("guid")]
    public string GUID { get; set; } = "";
}

[Serializable]
public partial class EscritoriosResponseAll
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - escCidade  
    /// </summary>
    [JsonPropertyName("cidade")]
    public int Cidade { get; set; }

    /// <summary>
    /// CNPJ - escCNPJ - tamanho máximo: 14 
    /// </summary>
    [JsonPropertyName("cnpj")]
    public string CNPJ { get; set; } = "";

    /// <summary>
    /// Sem descrição - escCasa  
    /// </summary>
    [JsonPropertyName("casa")]
    public bool Casa { get; set; }

    /// <summary>
    /// Sem descrição - escParceria  
    /// </summary>
    [JsonPropertyName("parceria")]
    public bool Parceria { get; set; }

    /// <summary>
    /// Sem descrição - escNome - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("nome")]
    public string Nome { get; set; } = "";

    /// <summary>
    /// Sem descrição - escOAB - tamanho máximo: 15 
    /// </summary>
    [JsonPropertyName("oab")]
    public string OAB { get; set; } = "";

    /// <summary>
    /// Endereço - escEndereco - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("endereco")]
    public string Endereco { get; set; } = "";

    /// <summary>
    /// Bairro - escBairro - tamanho máximo: 30 
    /// </summary>
    [JsonPropertyName("bairro")]
    public string Bairro { get; set; } = "";

    /// <summary>
    /// CEP - escCEP - tamanho máximo: 10 
    /// </summary>
    [JsonPropertyName("cep")]
    public string CEP { get; set; } = "";

    /// <summary>
    /// Fone - escFone  
    /// </summary>
    [JsonPropertyName("fone")]
    public string Fone { get; set; } = "";

    /// <summary>
    /// Fax - escFax  
    /// </summary>
    [JsonPropertyName("fax")]
    public string Fax { get; set; } = "";

    /// <summary>
    /// Sem descrição - escSite - tamanho máximo: 200 
    /// </summary>
    [JsonPropertyName("site")]
    public string Site { get; set; } = "";

    /// <summary>
    /// Sem descrição - escEMail - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("email")]
    public string EMail { get; set; } = "";

    /// <summary>
    /// Sem descrição - escOBS  
    /// </summary>
    [JsonPropertyName("obs")]
    public string OBS { get; set; } = "";

    /// <summary>
    /// Sem descrição - escAdvResponsavel - tamanho máximo: 80 
    /// </summary>
    [JsonPropertyName("advresponsavel")]
    public string AdvResponsavel { get; set; } = "";

    /// <summary>
    /// Sem descrição - escSecretaria - tamanho máximo: 80 
    /// </summary>
    [JsonPropertyName("secretaria")]
    public string Secretaria { get; set; } = "";

    /// <summary>
    /// Inscrição Estadual - escInscEst - tamanho máximo: 15 
    /// </summary>
    [JsonPropertyName("inscest")]
    public string InscEst { get; set; } = "";

    /// <summary>
    /// Sem descrição - escCorrespondente  
    /// </summary>
    [JsonPropertyName("correspondente")]
    public bool Correspondente { get; set; }

    /// <summary>
    /// Sem descrição - escTop  
    /// </summary>
    [JsonPropertyName("top")]
    public bool Top { get; set; }

    /// <summary>
    /// Criar etiqueta - escEtiqueta  
    /// </summary>
    [JsonPropertyName("etiqueta")]
    public bool Etiqueta { get; set; }

    /// <summary>
    /// Negritar - escBold  
    /// </summary>
    [JsonPropertyName("bold")]
    public bool Bold { get; set; }

    /// <summary>
    /// GUId - escGUID - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("guid")]
    public string GUID { get; set; } = "";

    [JsonPropertyName("nomecidade")]
    public string NomeCidade { get; set; } = string.Empty;
}