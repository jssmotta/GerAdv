﻿#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class GUTAtividadesMatriz
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - amgGUTMatriz  
    /// </summary>
    [JsonPropertyName("gutmatriz")]
    public int GUTMatriz { get; set; }

    /// <summary>
    /// Sem descrição - amgGUTAtividade  
    /// </summary>
    [JsonPropertyName("gutatividade")]
    public int GUTAtividade { get; set; }

    /// <summary>
    /// GUId - amgGUID - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("guid")]
    public string GUID { get; set; } = "";

    [JsonPropertyName("auditor")]
    public Auditor? Auditor { get; set; }
}