﻿#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models.Response;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class ProProcuradoresResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - papAdvogado  
    /// </summary>
    [JsonPropertyName("advogado")]
    public int Advogado { get; set; }

    /// <summary>
    /// Sem descrição - papProcesso  
    /// </summary>
    [JsonPropertyName("processo")]
    public int Processo { get; set; }

    /// <summary>
    /// Sem descrição - papNome - tamanho máximo: 255 
    /// </summary>
    [JsonPropertyName("nome")]
    public string Nome { get; set; } = "";

    /// <summary>
    /// Sem descrição - papData  
    /// </summary>
    [JsonPropertyName("data")]
    public string Data { get; set; } = "";

    /// <summary>
    /// Sem descrição - papSubstabelecimento  
    /// </summary>
    [JsonPropertyName("substabelecimento")]
    public bool Substabelecimento { get; set; }

    /// <summary>
    /// Sem descrição - papProcuracao  
    /// </summary>
    [JsonPropertyName("procuracao")]
    public bool Procuracao { get; set; }

    /// <summary>
    /// Negritar - papBold  
    /// </summary>
    [JsonPropertyName("bold")]
    public bool Bold { get; set; }

    /// <summary>
    /// GUId - papGUID - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("guid")]
    public string Guid { get; set; } = "";

    [JsonPropertyName("auditor")]
    public Auditor? Auditor { get; set; }
}