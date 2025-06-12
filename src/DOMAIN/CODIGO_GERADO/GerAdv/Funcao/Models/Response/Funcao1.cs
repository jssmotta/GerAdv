#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models.Response;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class FuncaoResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - funDescricao - tamanho máximo: 40 
    /// </summary>
    [JsonPropertyName("descricao")]
    public string Descricao { get; set; } = "";
}

[Serializable]
public partial class FuncaoResponseAll
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - funDescricao - tamanho máximo: 40 
    /// </summary>
    [JsonPropertyName("descricao")]
    public string Descricao { get; set; } = "";
}