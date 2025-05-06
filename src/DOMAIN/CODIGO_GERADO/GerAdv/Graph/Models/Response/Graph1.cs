#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models.Response;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class GraphResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - gphTabela - tamanho máximo: 80 
    /// </summary>
    [JsonPropertyName("tabela")]
    public string Tabela { get; set; } = "";

    /// <summary>
    /// Sem descrição - gphTabelaId  
    /// </summary>
    [JsonPropertyName("tabelaid")]
    public int TabelaId { get; set; }

    /// <summary>
    /// Sem descrição - gphImagem  
    /// </summary>
    [JsonPropertyName("imagem")]
    public byte[] Imagem { get; set; } = [];

    /// <summary>
    /// GUId - gphGUID - tamanho máximo: 150 
    /// </summary>
    [JsonPropertyName("guid")]
    public string GUID { get; set; } = "";

    [JsonPropertyName("auditor")]
    public Auditor? Auditor { get; set; }
}