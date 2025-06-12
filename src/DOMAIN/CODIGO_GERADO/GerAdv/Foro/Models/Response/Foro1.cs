#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models.Response;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class ForoResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - forCidade  
    /// </summary>
    [JsonPropertyName("cidade")]
    public int Cidade { get; set; }

    /// <summary>
    /// Sem descrição - forEMail - tamanho máximo: 150 
    /// </summary>
    [JsonPropertyName("email")]
    public string EMail { get; set; } = "";

    /// <summary>
    /// Sem descrição - forNome - tamanho máximo: 40 
    /// </summary>
    [JsonPropertyName("nome")]
    public string Nome { get; set; } = "";

    /// <summary>
    /// Sem descrição - forUnico  
    /// </summary>
    [JsonPropertyName("unico")]
    public bool Unico { get; set; }

    /// <summary>
    /// Sem descrição - forSite - tamanho máximo: 150 
    /// </summary>
    [JsonPropertyName("site")]
    public string Site { get; set; } = "";

    /// <summary>
    /// Endereço - forEndereco - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("endereco")]
    public string Endereco { get; set; } = "";

    /// <summary>
    /// Bairro - forBairro - tamanho máximo: 255 
    /// </summary>
    [JsonPropertyName("bairro")]
    public string Bairro { get; set; } = "";

    /// <summary>
    /// Fone - forFone  
    /// </summary>
    [JsonPropertyName("fone")]
    public string Fone { get; set; } = "";

    /// <summary>
    /// Fax - forFax  
    /// </summary>
    [JsonPropertyName("fax")]
    public string Fax { get; set; } = "";

    /// <summary>
    /// CEP - forCEP - tamanho máximo: 10 
    /// </summary>
    [JsonPropertyName("cep")]
    public string CEP { get; set; } = "";

    /// <summary>
    /// Sem descrição - forOBS  
    /// </summary>
    [JsonPropertyName("obs")]
    public string OBS { get; set; } = "";

    /// <summary>
    /// Sem descrição - forUnicoConfirmado  
    /// </summary>
    [JsonPropertyName("unicoconfirmado")]
    public bool UnicoConfirmado { get; set; }

    /// <summary>
    /// Sem descrição - forWeb - tamanho máximo: 255 
    /// </summary>
    [JsonPropertyName("web")]
    public string Web { get; set; } = "";

    /// <summary>
    /// Criar etiqueta - forEtiqueta  
    /// </summary>
    [JsonPropertyName("etiqueta")]
    public bool Etiqueta { get; set; }

    /// <summary>
    /// Negritar - forBold  
    /// </summary>
    [JsonPropertyName("bold")]
    public bool Bold { get; set; }
}

[Serializable]
public partial class ForoResponseAll
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - forCidade  
    /// </summary>
    [JsonPropertyName("cidade")]
    public int Cidade { get; set; }

    /// <summary>
    /// Sem descrição - forEMail - tamanho máximo: 150 
    /// </summary>
    [JsonPropertyName("email")]
    public string EMail { get; set; } = "";

    /// <summary>
    /// Sem descrição - forNome - tamanho máximo: 40 
    /// </summary>
    [JsonPropertyName("nome")]
    public string Nome { get; set; } = "";

    /// <summary>
    /// Sem descrição - forUnico  
    /// </summary>
    [JsonPropertyName("unico")]
    public bool Unico { get; set; }

    /// <summary>
    /// Sem descrição - forSite - tamanho máximo: 150 
    /// </summary>
    [JsonPropertyName("site")]
    public string Site { get; set; } = "";

    /// <summary>
    /// Endereço - forEndereco - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("endereco")]
    public string Endereco { get; set; } = "";

    /// <summary>
    /// Bairro - forBairro - tamanho máximo: 255 
    /// </summary>
    [JsonPropertyName("bairro")]
    public string Bairro { get; set; } = "";

    /// <summary>
    /// Fone - forFone  
    /// </summary>
    [JsonPropertyName("fone")]
    public string Fone { get; set; } = "";

    /// <summary>
    /// Fax - forFax  
    /// </summary>
    [JsonPropertyName("fax")]
    public string Fax { get; set; } = "";

    /// <summary>
    /// CEP - forCEP - tamanho máximo: 10 
    /// </summary>
    [JsonPropertyName("cep")]
    public string CEP { get; set; } = "";

    /// <summary>
    /// Sem descrição - forOBS  
    /// </summary>
    [JsonPropertyName("obs")]
    public string OBS { get; set; } = "";

    /// <summary>
    /// Sem descrição - forUnicoConfirmado  
    /// </summary>
    [JsonPropertyName("unicoconfirmado")]
    public bool UnicoConfirmado { get; set; }

    /// <summary>
    /// Sem descrição - forWeb - tamanho máximo: 255 
    /// </summary>
    [JsonPropertyName("web")]
    public string Web { get; set; } = "";

    /// <summary>
    /// Criar etiqueta - forEtiqueta  
    /// </summary>
    [JsonPropertyName("etiqueta")]
    public bool Etiqueta { get; set; }

    /// <summary>
    /// Negritar - forBold  
    /// </summary>
    [JsonPropertyName("bold")]
    public bool Bold { get; set; }

    [JsonPropertyName("nomecidade")]
    public string NomeCidade { get; set; } = string.Empty;
}