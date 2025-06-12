#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class Apenso
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - apeProcesso  
    /// </summary>
    [JsonPropertyName("processo")]
    public int Processo { get; set; }

    /// <summary>
    /// Sem descrição - apeApenso - tamanho máximo: 25 
    /// </summary>
    [JsonPropertyName("apensox")]
    public string ApensoX { get; set; } = "";

    /// <summary>
    /// Sem descrição - apeAcao - tamanho máximo: 25 
    /// </summary>
    [JsonPropertyName("acao")]
    public string Acao { get; set; } = "";

    /// <summary>
    /// Sem descrição - apeDtDist  
    /// </summary>
    [JsonPropertyName("dtdist")]
    public string DtDist { get; set; } = "";

    /// <summary>
    /// Sem descrição - apeOBS  
    /// </summary>
    [JsonPropertyName("obs")]
    public string OBS { get; set; } = "";

    /// <summary>
    /// Sem descrição - apeValorCausa  
    /// </summary>
    [JsonPropertyName("valorcausa")]
    public decimal ValorCausa { get; set; }
}

[Serializable]
public partial class ApensoAll
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - apeProcesso  
    /// </summary>
    [JsonPropertyName("processo")]
    public int Processo { get; set; }

    /// <summary>
    /// Sem descrição - apeApenso - tamanho máximo: 25 
    /// </summary>
    [JsonPropertyName("apensox")]
    public string ApensoX { get; set; } = "";

    /// <summary>
    /// Sem descrição - apeAcao - tamanho máximo: 25 
    /// </summary>
    [JsonPropertyName("acao")]
    public string Acao { get; set; } = "";

    /// <summary>
    /// Sem descrição - apeDtDist  
    /// </summary>
    [JsonPropertyName("dtdist")]
    public string DtDist { get; set; } = "";

    /// <summary>
    /// Sem descrição - apeOBS  
    /// </summary>
    [JsonPropertyName("obs")]
    public string OBS { get; set; } = "";

    /// <summary>
    /// Sem descrição - apeValorCausa  
    /// </summary>
    [JsonPropertyName("valorcausa")]
    public decimal ValorCausa { get; set; }

    [JsonPropertyName("nropastaprocessos")]
    public string NroPastaProcessos { get; set; } = string.Empty;
}