#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models.Response;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class LivroCaixaResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - livProcesso  
    /// </summary>
    [JsonPropertyName("processo")]
    public int Processo { get; set; }

    /// <summary>
    /// Sem descrição - livIDDes  
    /// </summary>
    [JsonPropertyName("iddes")]
    public int IDDes { get; set; }

    /// <summary>
    /// Sem descrição - livPessoal  
    /// </summary>
    [JsonPropertyName("pessoal")]
    public int Pessoal { get; set; }

    /// <summary>
    /// Sem descrição - livAjuste  
    /// </summary>
    [JsonPropertyName("ajuste")]
    public bool Ajuste { get; set; }

    /// <summary>
    /// Sem descrição - livIDHon  
    /// </summary>
    [JsonPropertyName("idhon")]
    public int IDHon { get; set; }

    /// <summary>
    /// Sem descrição - livIDHonParc  
    /// </summary>
    [JsonPropertyName("idhonparc")]
    public int IDHonParc { get; set; }

    /// <summary>
    /// Sem descrição - livIDHonSuc  
    /// </summary>
    [JsonPropertyName("idhonsuc")]
    public bool IDHonSuc { get; set; }

    /// <summary>
    /// Sem descrição - livData  
    /// </summary>
    [JsonPropertyName("data")]
    public string Data { get; set; } = "";

    /// <summary>
    /// Sem descrição - livValor  
    /// </summary>
    [JsonPropertyName("valor")]
    public decimal Valor { get; set; }

    /// <summary>
    /// Sem descrição - livTipo  
    /// </summary>
    [JsonPropertyName("tipo")]
    public bool Tipo { get; set; }

    /// <summary>
    /// Sem descrição - livHistorico - tamanho máximo: 255 
    /// </summary>
    [JsonPropertyName("historico")]
    public string Historico { get; set; } = "";

    /// <summary>
    /// Sem descrição - livGrupo  
    /// </summary>
    [JsonPropertyName("grupo")]
    public int Grupo { get; set; }
}

[Serializable]
public partial class LivroCaixaResponseAll
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - livProcesso  
    /// </summary>
    [JsonPropertyName("processo")]
    public int Processo { get; set; }

    /// <summary>
    /// Sem descrição - livIDDes  
    /// </summary>
    [JsonPropertyName("iddes")]
    public int IDDes { get; set; }

    /// <summary>
    /// Sem descrição - livPessoal  
    /// </summary>
    [JsonPropertyName("pessoal")]
    public int Pessoal { get; set; }

    /// <summary>
    /// Sem descrição - livAjuste  
    /// </summary>
    [JsonPropertyName("ajuste")]
    public bool Ajuste { get; set; }

    /// <summary>
    /// Sem descrição - livIDHon  
    /// </summary>
    [JsonPropertyName("idhon")]
    public int IDHon { get; set; }

    /// <summary>
    /// Sem descrição - livIDHonParc  
    /// </summary>
    [JsonPropertyName("idhonparc")]
    public int IDHonParc { get; set; }

    /// <summary>
    /// Sem descrição - livIDHonSuc  
    /// </summary>
    [JsonPropertyName("idhonsuc")]
    public bool IDHonSuc { get; set; }

    /// <summary>
    /// Sem descrição - livData  
    /// </summary>
    [JsonPropertyName("data")]
    public string Data { get; set; } = "";

    /// <summary>
    /// Sem descrição - livValor  
    /// </summary>
    [JsonPropertyName("valor")]
    public decimal Valor { get; set; }

    /// <summary>
    /// Sem descrição - livTipo  
    /// </summary>
    [JsonPropertyName("tipo")]
    public bool Tipo { get; set; }

    /// <summary>
    /// Sem descrição - livHistorico - tamanho máximo: 255 
    /// </summary>
    [JsonPropertyName("historico")]
    public string Historico { get; set; } = "";

    /// <summary>
    /// Sem descrição - livGrupo  
    /// </summary>
    [JsonPropertyName("grupo")]
    public int Grupo { get; set; }

    [JsonPropertyName("nropastaprocessos")]
    public string NroPastaProcessos { get; set; } = string.Empty;
}