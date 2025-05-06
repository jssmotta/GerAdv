#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class AndamentosMD
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - amdProcesso  
    /// </summary>
    [JsonPropertyName("processo")]
    public int Processo { get; set; }

    /// <summary>
    /// Sem descrição - amdNome - tamanho máximo: 255 
    /// </summary>
    [JsonPropertyName("nome")]
    public string Nome { get; set; } = "";

    /// <summary>
    /// Sem descrição - amdAndamento  
    /// </summary>
    [JsonPropertyName("andamento")]
    public int Andamento { get; set; }

    /// <summary>
    /// Sem descrição - amdPathFull  
    /// </summary>
    [JsonPropertyName("pathfull")]
    public string PathFull { get; set; } = "";

    /// <summary>
    /// Sem descrição - amdUNC  
    /// </summary>
    [JsonPropertyName("unc")]
    public string UNC { get; set; } = "";

    /// <summary>
    /// GUId - amdGUID - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("guid")]
    public string GUID { get; set; } = "";

    [JsonPropertyName("auditor")]
    public Auditor? Auditor { get; set; }
}