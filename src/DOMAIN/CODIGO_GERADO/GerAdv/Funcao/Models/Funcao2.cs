#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class Funcao
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
public partial class FuncaoAll
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - funDescricao - tamanho máximo: 40 
    /// </summary>
    [JsonPropertyName("descricao")]
    public string Descricao { get; set; } = "";
}