#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models.Response;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class DivisaoTribunalResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - divJustica  
    /// </summary>
    [JsonPropertyName("justica")]
    public int Justica { get; set; }

    /// <summary>
    /// Sem descrição - divArea  
    /// </summary>
    [JsonPropertyName("area")]
    public int Area { get; set; }

    /// <summary>
    /// Sem descrição - divCidade  
    /// </summary>
    [JsonPropertyName("cidade")]
    public int Cidade { get; set; }

    /// <summary>
    /// Sem descrição - divForo  
    /// </summary>
    [JsonPropertyName("foro")]
    public int Foro { get; set; }

    /// <summary>
    /// Sem descrição - divTribunal  
    /// </summary>
    [JsonPropertyName("tribunal")]
    public int Tribunal { get; set; }

    /// <summary>
    /// Sem descrição - divNumCodigo  
    /// </summary>
    [JsonPropertyName("numcodigo")]
    public int NumCodigo { get; set; }

    /// <summary>
    /// Sem descrição - divNomeEspecial - tamanho máximo: 255 
    /// </summary>
    [JsonPropertyName("nomeespecial")]
    public string NomeEspecial { get; set; } = "";

    /// <summary>
    /// Sem descrição - divCodigoDiv - tamanho máximo: 5 
    /// </summary>
    [JsonPropertyName("codigodiv")]
    public string CodigoDiv { get; set; } = "";

    /// <summary>
    /// Endereço - divEndereco - tamanho máximo: 40 
    /// </summary>
    [JsonPropertyName("endereco")]
    public string Endereco { get; set; } = "";

    /// <summary>
    /// Fone - divFone  
    /// </summary>
    [JsonPropertyName("fone")]
    public string Fone { get; set; } = "";

    /// <summary>
    /// Fax - divFax  
    /// </summary>
    [JsonPropertyName("fax")]
    public string Fax { get; set; } = "";

    /// <summary>
    /// CEP - divCEP - tamanho máximo: 10 
    /// </summary>
    [JsonPropertyName("cep")]
    public string CEP { get; set; } = "";

    /// <summary>
    /// Sem descrição - divObs  
    /// </summary>
    [JsonPropertyName("obs")]
    public string Obs { get; set; } = "";

    /// <summary>
    /// Sem descrição - divEMail - tamanho máximo: 150 
    /// </summary>
    [JsonPropertyName("email")]
    public string EMail { get; set; } = "";

    /// <summary>
    /// Sem descrição - divAndar - tamanho máximo: 12 
    /// </summary>
    [JsonPropertyName("andar")]
    public string Andar { get; set; } = "";

    /// <summary>
    /// Criar etiqueta - divEtiqueta  
    /// </summary>
    [JsonPropertyName("etiqueta")]
    public bool Etiqueta { get; set; }

    /// <summary>
    /// Negritar - divBold  
    /// </summary>
    [JsonPropertyName("bold")]
    public bool Bold { get; set; }

    /// <summary>
    /// GUId - divGUID - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("guid")]
    public string GUID { get; set; } = "";
}

[Serializable]
public partial class DivisaoTribunalResponseAll
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - divJustica  
    /// </summary>
    [JsonPropertyName("justica")]
    public int Justica { get; set; }

    /// <summary>
    /// Sem descrição - divArea  
    /// </summary>
    [JsonPropertyName("area")]
    public int Area { get; set; }

    /// <summary>
    /// Sem descrição - divCidade  
    /// </summary>
    [JsonPropertyName("cidade")]
    public int Cidade { get; set; }

    /// <summary>
    /// Sem descrição - divForo  
    /// </summary>
    [JsonPropertyName("foro")]
    public int Foro { get; set; }

    /// <summary>
    /// Sem descrição - divTribunal  
    /// </summary>
    [JsonPropertyName("tribunal")]
    public int Tribunal { get; set; }

    /// <summary>
    /// Sem descrição - divNumCodigo  
    /// </summary>
    [JsonPropertyName("numcodigo")]
    public int NumCodigo { get; set; }

    /// <summary>
    /// Sem descrição - divNomeEspecial - tamanho máximo: 255 
    /// </summary>
    [JsonPropertyName("nomeespecial")]
    public string NomeEspecial { get; set; } = "";

    /// <summary>
    /// Sem descrição - divCodigoDiv - tamanho máximo: 5 
    /// </summary>
    [JsonPropertyName("codigodiv")]
    public string CodigoDiv { get; set; } = "";

    /// <summary>
    /// Endereço - divEndereco - tamanho máximo: 40 
    /// </summary>
    [JsonPropertyName("endereco")]
    public string Endereco { get; set; } = "";

    /// <summary>
    /// Fone - divFone  
    /// </summary>
    [JsonPropertyName("fone")]
    public string Fone { get; set; } = "";

    /// <summary>
    /// Fax - divFax  
    /// </summary>
    [JsonPropertyName("fax")]
    public string Fax { get; set; } = "";

    /// <summary>
    /// CEP - divCEP - tamanho máximo: 10 
    /// </summary>
    [JsonPropertyName("cep")]
    public string CEP { get; set; } = "";

    /// <summary>
    /// Sem descrição - divObs  
    /// </summary>
    [JsonPropertyName("obs")]
    public string Obs { get; set; } = "";

    /// <summary>
    /// Sem descrição - divEMail - tamanho máximo: 150 
    /// </summary>
    [JsonPropertyName("email")]
    public string EMail { get; set; } = "";

    /// <summary>
    /// Sem descrição - divAndar - tamanho máximo: 12 
    /// </summary>
    [JsonPropertyName("andar")]
    public string Andar { get; set; } = "";

    /// <summary>
    /// Criar etiqueta - divEtiqueta  
    /// </summary>
    [JsonPropertyName("etiqueta")]
    public bool Etiqueta { get; set; }

    /// <summary>
    /// Negritar - divBold  
    /// </summary>
    [JsonPropertyName("bold")]
    public bool Bold { get; set; }

    /// <summary>
    /// GUId - divGUID - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("guid")]
    public string GUID { get; set; } = "";

    [JsonPropertyName("nomejustica")]
    public string NomeJustica { get; set; } = string.Empty;

    [JsonPropertyName("descricaoarea")]
    public string DescricaoArea { get; set; } = string.Empty;

    [JsonPropertyName("nomecidade")]
    public string NomeCidade { get; set; } = string.Empty;

    [JsonPropertyName("nomeforo")]
    public string NomeForo { get; set; } = string.Empty;

    [JsonPropertyName("nometribunal")]
    public string NomeTribunal { get; set; } = string.Empty;
}