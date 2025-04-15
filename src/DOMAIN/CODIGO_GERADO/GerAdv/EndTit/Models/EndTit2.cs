#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class EndTit
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Endereço - ettEndereco  
    /// </summary>
    [JsonPropertyName("endereco")]
    public int Endereco { get; set; }

    /// <summary>
    /// Sem descrição - ettTitulo  
    /// </summary>
    [JsonPropertyName("titulo")]
    public int Titulo { get; set; }
}