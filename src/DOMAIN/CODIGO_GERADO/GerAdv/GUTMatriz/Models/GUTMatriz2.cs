#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class GUTMatriz
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - gutGUTTipo  
    /// </summary>
    [JsonPropertyName("guttipo")]
    public int GUTTipo { get; set; }

    /// <summary>
    /// Sem descrição - gutDescricao - tamanho máximo: 150 
    /// </summary>
    [JsonPropertyName("descricao")]
    public string Descricao { get; set; } = "";

    /// <summary>
    /// Sem descrição - gutValor  
    /// </summary>
    [JsonPropertyName("valor")]
    public int Valor { get; set; }
}