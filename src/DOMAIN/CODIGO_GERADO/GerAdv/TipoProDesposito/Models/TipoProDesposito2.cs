#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class TipoProDesposito
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - tpdNome - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("nome")]
    public string Nome { get; set; } = "";
}