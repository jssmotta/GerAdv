#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class ProSucumbencia
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - scbProcesso  
    /// </summary>
    [JsonPropertyName("processo")]
    public int Processo { get; set; }

    /// <summary>
    /// Sem descrição - scbInstancia  
    /// </summary>
    [JsonPropertyName("instancia")]
    public int Instancia { get; set; }

    /// <summary>
    /// Sem descrição - scbTipoOrigemSucumbencia  
    /// </summary>
    [JsonPropertyName("tipoorigemsucumbencia")]
    public int TipoOrigemSucumbencia { get; set; }

    /// <summary>
    /// Sem descrição - scbData  
    /// </summary>
    [JsonPropertyName("data")]
    public string Data { get; set; } = "";

    /// <summary>
    /// Sem descrição - scbNome - tamanho máximo: 2048 
    /// </summary>
    [JsonPropertyName("nome")]
    public string Nome { get; set; } = "";

    /// <summary>
    /// Sem descrição - scbValor  
    /// </summary>
    [JsonPropertyName("valor")]
    public decimal Valor { get; set; }

    /// <summary>
    /// Sem descrição - scbPercentual - tamanho máximo: 5 
    /// </summary>
    [JsonPropertyName("percentual")]
    public string Percentual { get; set; } = "";

    /// <summary>
    /// GUId - scbGUID - tamanho máximo: 150 
    /// </summary>
    [JsonPropertyName("guid")]
    public string GUID { get; set; } = "";

    [JsonPropertyName("auditor")]
    public Auditor? Auditor { get; set; }
}