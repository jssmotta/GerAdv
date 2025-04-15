#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models.Response;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class GUTAtividadesResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - agtGUTPeriodicidade  
    /// </summary>
    [JsonPropertyName("gutperiodicidade")]
    public int GUTPeriodicidade { get; set; }

    /// <summary>
    /// Sem descrição - agtOperador  
    /// </summary>
    [JsonPropertyName("operador")]
    public int Operador { get; set; }

    /// <summary>
    /// Sem descrição - agtNome - tamanho máximo: 255 
    /// </summary>
    [JsonPropertyName("nome")]
    public string Nome { get; set; } = "";

    /// <summary>
    /// Sem descrição - agtObservacao  
    /// </summary>
    [JsonPropertyName("observacao")]
    public string Observacao { get; set; } = "";

    /// <summary>
    /// Sem descrição - agtGUTGrupo  
    /// </summary>
    [JsonPropertyName("gutgrupo")]
    public int GUTGrupo { get; set; }

    /// <summary>
    /// Sem descrição - agtConcluido  
    /// </summary>
    [JsonPropertyName("concluido")]
    public bool Concluido { get; set; }

    /// <summary>
    /// Sem descrição - agtDataConcluido  
    /// </summary>
    [JsonPropertyName("dataconcluido")]
    public string DataConcluido { get; set; } = "";

    /// <summary>
    /// Sem descrição - agtDiasParaIniciar  
    /// </summary>
    [JsonPropertyName("diasparainiciar")]
    public int DiasParaIniciar { get; set; }

    /// <summary>
    /// Sem descrição - agtMinutosParaRealizar  
    /// </summary>
    [JsonPropertyName("minutospararealizar")]
    public int MinutosParaRealizar { get; set; }

    /// <summary>
    /// GUId - agtGUID - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("guid")]
    public string Guid { get; set; } = "";

    [JsonPropertyName("auditor")]
    public Auditor? Auditor { get; set; }
}