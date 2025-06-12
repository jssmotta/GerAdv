#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class ProDepositos
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - pdsProcesso  
    /// </summary>
    [JsonPropertyName("processo")]
    public int Processo { get; set; }

    /// <summary>
    /// Sem descrição - pdsFase  
    /// </summary>
    [JsonPropertyName("fase")]
    public int Fase { get; set; }

    /// <summary>
    /// Sem descrição - pdsTipoProDesposito  
    /// </summary>
    [JsonPropertyName("tipoprodesposito")]
    public int TipoProDesposito { get; set; }

    /// <summary>
    /// Sem descrição - pdsData  
    /// </summary>
    [JsonPropertyName("data")]
    public string Data { get; set; } = "";

    /// <summary>
    /// Sem descrição - pdsValor  
    /// </summary>
    [JsonPropertyName("valor")]
    public decimal Valor { get; set; }
}

[Serializable]
public partial class ProDepositosAll
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - pdsProcesso  
    /// </summary>
    [JsonPropertyName("processo")]
    public int Processo { get; set; }

    /// <summary>
    /// Sem descrição - pdsFase  
    /// </summary>
    [JsonPropertyName("fase")]
    public int Fase { get; set; }

    /// <summary>
    /// Sem descrição - pdsTipoProDesposito  
    /// </summary>
    [JsonPropertyName("tipoprodesposito")]
    public int TipoProDesposito { get; set; }

    /// <summary>
    /// Sem descrição - pdsData  
    /// </summary>
    [JsonPropertyName("data")]
    public string Data { get; set; } = "";

    /// <summary>
    /// Sem descrição - pdsValor  
    /// </summary>
    [JsonPropertyName("valor")]
    public decimal Valor { get; set; }

    [JsonPropertyName("nropastaprocessos")]
    public string NroPastaProcessos { get; set; } = string.Empty;

    [JsonPropertyName("descricaofase")]
    public string DescricaoFase { get; set; } = string.Empty;

    [JsonPropertyName("nometipoprodesposito")]
    public string NomeTipoProDesposito { get; set; } = string.Empty;
}