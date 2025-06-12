#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models.Response;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class DadosProcuracaoResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - prcCliente  
    /// </summary>
    [JsonPropertyName("cliente")]
    public int Cliente { get; set; }

    /// <summary>
    /// Sem descrição - prcEstadoCivil - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("estadocivil")]
    public string EstadoCivil { get; set; } = "";

    /// <summary>
    /// Sem descrição - prcNacionalidade - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("nacionalidade")]
    public string Nacionalidade { get; set; } = "";

    /// <summary>
    /// Sem descrição - prcProfissao - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("profissao")]
    public string Profissao { get; set; } = "";

    /// <summary>
    /// Nº carteira de trabalho - prcCTPS - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("ctps")]
    public string CTPS { get; set; } = "";

    /// <summary>
    /// Sem descrição - prcPisPasep - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("pispasep")]
    public string PisPasep { get; set; } = "";

    /// <summary>
    /// Sem descrição - prcRemuneracao  
    /// </summary>
    [JsonPropertyName("remuneracao")]
    public string Remuneracao { get; set; } = "";

    /// <summary>
    /// Sem descrição - prcObjeto  
    /// </summary>
    [JsonPropertyName("objeto")]
    public string Objeto { get; set; } = "";

    /// <summary>
    /// GUId - prcGUID - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("guid")]
    public string GUID { get; set; } = "";
}

[Serializable]
public partial class DadosProcuracaoResponseAll
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - prcCliente  
    /// </summary>
    [JsonPropertyName("cliente")]
    public int Cliente { get; set; }

    /// <summary>
    /// Sem descrição - prcEstadoCivil - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("estadocivil")]
    public string EstadoCivil { get; set; } = "";

    /// <summary>
    /// Sem descrição - prcNacionalidade - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("nacionalidade")]
    public string Nacionalidade { get; set; } = "";

    /// <summary>
    /// Sem descrição - prcProfissao - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("profissao")]
    public string Profissao { get; set; } = "";

    /// <summary>
    /// Nº carteira de trabalho - prcCTPS - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("ctps")]
    public string CTPS { get; set; } = "";

    /// <summary>
    /// Sem descrição - prcPisPasep - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("pispasep")]
    public string PisPasep { get; set; } = "";

    /// <summary>
    /// Sem descrição - prcRemuneracao  
    /// </summary>
    [JsonPropertyName("remuneracao")]
    public string Remuneracao { get; set; } = "";

    /// <summary>
    /// Sem descrição - prcObjeto  
    /// </summary>
    [JsonPropertyName("objeto")]
    public string Objeto { get; set; } = "";

    /// <summary>
    /// GUId - prcGUID - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("guid")]
    public string GUID { get; set; } = "";

    [JsonPropertyName("nomeclientes")]
    public string NomeClientes { get; set; } = string.Empty;
}