#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models.Response;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class ParceriaProcResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - parAdvogado  
    /// </summary>
    [JsonPropertyName("advogado")]
    public int Advogado { get; set; }

    /// <summary>
    /// Sem descrição - parProcesso  
    /// </summary>
    [JsonPropertyName("processo")]
    public int Processo { get; set; }

    /// <summary>
    /// GUId - parGUID - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("guid")]
    public string GUID { get; set; } = "";
}

[Serializable]
public partial class ParceriaProcResponseAll
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - parAdvogado  
    /// </summary>
    [JsonPropertyName("advogado")]
    public int Advogado { get; set; }

    /// <summary>
    /// Sem descrição - parProcesso  
    /// </summary>
    [JsonPropertyName("processo")]
    public int Processo { get; set; }

    /// <summary>
    /// GUId - parGUID - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("guid")]
    public string GUID { get; set; } = "";

    [JsonPropertyName("nomeadvogados")]
    public string NomeAdvogados { get; set; } = string.Empty;

    [JsonPropertyName("nropastaprocessos")]
    public string NroPastaProcessos { get; set; } = string.Empty;
}