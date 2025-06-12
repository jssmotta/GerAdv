#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class TribEnderecos
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - treTribunal  
    /// </summary>
    [JsonPropertyName("tribunal")]
    public int Tribunal { get; set; }

    /// <summary>
    /// Sem descrição - treCidade  
    /// </summary>
    [JsonPropertyName("cidade")]
    public int Cidade { get; set; }

    /// <summary>
    /// Endereço - treEndereco - tamanho máximo: 80 
    /// </summary>
    [JsonPropertyName("endereco")]
    public string Endereco { get; set; } = "";

    /// <summary>
    /// CEP - treCEP - tamanho máximo: 10 
    /// </summary>
    [JsonPropertyName("cep")]
    public string CEP { get; set; } = "";

    /// <summary>
    /// Fone - treFone  
    /// </summary>
    [JsonPropertyName("fone")]
    public string Fone { get; set; } = "";

    /// <summary>
    /// Fax - treFax  
    /// </summary>
    [JsonPropertyName("fax")]
    public string Fax { get; set; } = "";

    /// <summary>
    /// Sem descrição - treOBS  
    /// </summary>
    [JsonPropertyName("obs")]
    public string OBS { get; set; } = "";
}

[Serializable]
public partial class TribEnderecosAll
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - treTribunal  
    /// </summary>
    [JsonPropertyName("tribunal")]
    public int Tribunal { get; set; }

    /// <summary>
    /// Sem descrição - treCidade  
    /// </summary>
    [JsonPropertyName("cidade")]
    public int Cidade { get; set; }

    /// <summary>
    /// Endereço - treEndereco - tamanho máximo: 80 
    /// </summary>
    [JsonPropertyName("endereco")]
    public string Endereco { get; set; } = "";

    /// <summary>
    /// CEP - treCEP - tamanho máximo: 10 
    /// </summary>
    [JsonPropertyName("cep")]
    public string CEP { get; set; } = "";

    /// <summary>
    /// Fone - treFone  
    /// </summary>
    [JsonPropertyName("fone")]
    public string Fone { get; set; } = "";

    /// <summary>
    /// Fax - treFax  
    /// </summary>
    [JsonPropertyName("fax")]
    public string Fax { get; set; } = "";

    /// <summary>
    /// Sem descrição - treOBS  
    /// </summary>
    [JsonPropertyName("obs")]
    public string OBS { get; set; } = "";

    [JsonPropertyName("nometribunal")]
    public string NomeTribunal { get; set; } = string.Empty;

    [JsonPropertyName("nomecidade")]
    public string NomeCidade { get; set; } = string.Empty;
}