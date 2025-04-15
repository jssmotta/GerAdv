#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class ProDespesas
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - desCliente  
    /// </summary>
    [JsonPropertyName("cliente")]
    public int Cliente { get; set; }

    /// <summary>
    /// Sem descrição - desProcesso  
    /// </summary>
    [JsonPropertyName("processo")]
    public int Processo { get; set; }

    /// <summary>
    /// Sem descrição - desLigacaoID  
    /// </summary>
    [JsonPropertyName("ligacaoid")]
    public int LigacaoID { get; set; }

    /// <summary>
    /// Sem descrição - desCorrigido  
    /// </summary>
    [JsonPropertyName("corrigido")]
    public bool Corrigido { get; set; }

    /// <summary>
    /// Sem descrição - desData  
    /// </summary>
    [JsonPropertyName("data")]
    public string Data { get; set; } = "";

    /// <summary>
    /// Sem descrição - desValorOriginal  
    /// </summary>
    [JsonPropertyName("valororiginal")]
    public decimal ValorOriginal { get; set; }

    /// <summary>
    /// Sem descrição - desQuitado  
    /// </summary>
    [JsonPropertyName("quitado")]
    public int Quitado { get; set; }

    /// <summary>
    /// Sem descrição - desDataCorrecao  
    /// </summary>
    [JsonPropertyName("datacorrecao")]
    public string DataCorrecao { get; set; } = "";

    /// <summary>
    /// Sem descrição - desValor  
    /// </summary>
    [JsonPropertyName("valor")]
    public decimal Valor { get; set; }

    /// <summary>
    /// Sem descrição - desTipo  
    /// </summary>
    [JsonPropertyName("tipo")]
    public bool Tipo { get; set; }

    /// <summary>
    /// Sem descrição - desHistorico - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("historico")]
    public string Historico { get; set; } = "";

    /// <summary>
    /// Sem descrição - desLivroCaixa  
    /// </summary>
    [JsonPropertyName("livrocaixa")]
    public bool LivroCaixa { get; set; }

    /// <summary>
    /// GUId - desGUID - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("guid")]
    public string Guid { get; set; } = "";

    [JsonPropertyName("auditor")]
    public Auditor? Auditor { get; set; }
}