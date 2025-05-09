﻿#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class NECompromissos
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - ncpTipoCompromisso  
    /// </summary>
    [JsonPropertyName("tipocompromisso")]
    public int TipoCompromisso { get; set; }

    /// <summary>
    /// Sem descrição - ncpPalavraChave  
    /// </summary>
    [JsonPropertyName("palavrachave")]
    public int PalavraChave { get; set; }

    /// <summary>
    /// Sem descrição - ncpProvisionar  
    /// </summary>
    [JsonPropertyName("provisionar")]
    public bool Provisionar { get; set; }

    /// <summary>
    /// Sem descrição - ncpTextoCompromisso  
    /// </summary>
    [JsonPropertyName("textocompromisso")]
    public string TextoCompromisso { get; set; } = "";

    /// <summary>
    /// Negritar - ncpBold  
    /// </summary>
    [JsonPropertyName("bold")]
    public bool Bold { get; set; }

    [JsonPropertyName("auditor")]
    public Auditor? Auditor { get; set; }
}