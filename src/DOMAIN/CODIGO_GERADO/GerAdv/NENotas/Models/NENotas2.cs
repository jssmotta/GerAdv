#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class NENotas
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - nepApenso  
    /// </summary>
    [JsonPropertyName("apenso")]
    public int Apenso { get; set; }

    /// <summary>
    /// Sem descrição - nepPrecatoria  
    /// </summary>
    [JsonPropertyName("precatoria")]
    public int Precatoria { get; set; }

    /// <summary>
    /// Sem descrição - nepInstancia  
    /// </summary>
    [JsonPropertyName("instancia")]
    public int Instancia { get; set; }

    /// <summary>
    /// Sem descrição - nepProcesso  
    /// </summary>
    [JsonPropertyName("processo")]
    public int Processo { get; set; }

    /// <summary>
    /// Sem descrição - nepMovPro  
    /// </summary>
    [JsonPropertyName("movpro")]
    public bool MovPro { get; set; }

    /// <summary>
    /// Sem descrição - nepNome - tamanho máximo: 20 
    /// </summary>
    [JsonPropertyName("nome")]
    public string Nome { get; set; } = "";

    /// <summary>
    /// Sem descrição - nepNotaExpedida  
    /// </summary>
    [JsonPropertyName("notaexpedida")]
    public bool NotaExpedida { get; set; }

    /// <summary>
    /// Sem descrição - nepRevisada  
    /// </summary>
    [JsonPropertyName("revisada")]
    public bool Revisada { get; set; }

    /// <summary>
    /// Sem descrição - nepPalavraChave  
    /// </summary>
    [JsonPropertyName("palavrachave")]
    public int PalavraChave { get; set; }

    /// <summary>
    /// Sem descrição - nepData  
    /// </summary>
    [JsonPropertyName("data")]
    public string Data { get; set; } = "";

    /// <summary>
    /// Sem descrição - nepNotaPublicada  
    /// </summary>
    [JsonPropertyName("notapublicada")]
    public string NotaPublicada { get; set; } = "";
}

[Serializable]
public partial class NENotasAll
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - nepApenso  
    /// </summary>
    [JsonPropertyName("apenso")]
    public int Apenso { get; set; }

    /// <summary>
    /// Sem descrição - nepPrecatoria  
    /// </summary>
    [JsonPropertyName("precatoria")]
    public int Precatoria { get; set; }

    /// <summary>
    /// Sem descrição - nepInstancia  
    /// </summary>
    [JsonPropertyName("instancia")]
    public int Instancia { get; set; }

    /// <summary>
    /// Sem descrição - nepProcesso  
    /// </summary>
    [JsonPropertyName("processo")]
    public int Processo { get; set; }

    /// <summary>
    /// Sem descrição - nepMovPro  
    /// </summary>
    [JsonPropertyName("movpro")]
    public bool MovPro { get; set; }

    /// <summary>
    /// Sem descrição - nepNome - tamanho máximo: 20 
    /// </summary>
    [JsonPropertyName("nome")]
    public string Nome { get; set; } = "";

    /// <summary>
    /// Sem descrição - nepNotaExpedida  
    /// </summary>
    [JsonPropertyName("notaexpedida")]
    public bool NotaExpedida { get; set; }

    /// <summary>
    /// Sem descrição - nepRevisada  
    /// </summary>
    [JsonPropertyName("revisada")]
    public bool Revisada { get; set; }

    /// <summary>
    /// Sem descrição - nepPalavraChave  
    /// </summary>
    [JsonPropertyName("palavrachave")]
    public int PalavraChave { get; set; }

    /// <summary>
    /// Sem descrição - nepData  
    /// </summary>
    [JsonPropertyName("data")]
    public string Data { get; set; } = "";

    /// <summary>
    /// Sem descrição - nepNotaPublicada  
    /// </summary>
    [JsonPropertyName("notapublicada")]
    public string NotaPublicada { get; set; } = "";

    [JsonPropertyName("nroprocessoinstancia")]
    public string NroProcessoInstancia { get; set; } = string.Empty;

    [JsonPropertyName("nropastaprocessos")]
    public string NroPastaProcessos { get; set; } = string.Empty;
}