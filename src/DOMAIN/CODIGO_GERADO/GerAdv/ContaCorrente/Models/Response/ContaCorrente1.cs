#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models.Response;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class ContaCorrenteResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - ctoProcesso  
    /// </summary>
    [JsonPropertyName("processo")]
    public int Processo { get; set; }

    /// <summary>
    /// Sem descrição - ctoCliente  
    /// </summary>
    [JsonPropertyName("cliente")]
    public int Cliente { get; set; }

    /// <summary>
    /// Sem descrição - ctoCIAcordo  
    /// </summary>
    [JsonPropertyName("ciacordo")]
    public int CIAcordo { get; set; }

    /// <summary>
    /// Sem descrição - ctoQuitado  
    /// </summary>
    [JsonPropertyName("quitado")]
    public bool Quitado { get; set; }

    /// <summary>
    /// Sem descrição - ctoIDContrato  
    /// </summary>
    [JsonPropertyName("idcontrato")]
    public int IDContrato { get; set; }

    /// <summary>
    /// Sem descrição - ctoQuitadoID  
    /// </summary>
    [JsonPropertyName("quitadoid")]
    public int QuitadoID { get; set; }

    /// <summary>
    /// Sem descrição - ctoDebitoID  
    /// </summary>
    [JsonPropertyName("debitoid")]
    public int DebitoID { get; set; }

    /// <summary>
    /// Sem descrição - ctoLivroCaixaID  
    /// </summary>
    [JsonPropertyName("livrocaixaid")]
    public int LivroCaixaID { get; set; }

    /// <summary>
    /// Sem descrição - ctoSucumbencia  
    /// </summary>
    [JsonPropertyName("sucumbencia")]
    public bool Sucumbencia { get; set; }

    /// <summary>
    /// Sem descrição - ctoDistRegra  
    /// </summary>
    [JsonPropertyName("distregra")]
    public bool DistRegra { get; set; }

    /// <summary>
    /// Sem descrição - ctoDtOriginal  
    /// </summary>
    [JsonPropertyName("dtoriginal")]
    public string DtOriginal { get; set; } = "";

    /// <summary>
    /// Sem descrição - ctoParcelaX  
    /// </summary>
    [JsonPropertyName("parcelax")]
    public int ParcelaX { get; set; }

    /// <summary>
    /// Sem descrição - ctoValor  
    /// </summary>
    [JsonPropertyName("valor")]
    public decimal Valor { get; set; }

    /// <summary>
    /// Sem descrição - ctoData  
    /// </summary>
    [JsonPropertyName("data")]
    public string Data { get; set; } = "";

    /// <summary>
    /// Sem descrição - ctoHistorico  
    /// </summary>
    [JsonPropertyName("historico")]
    public string Historico { get; set; } = "";

    /// <summary>
    /// Sem descrição - ctoContrato  
    /// </summary>
    [JsonPropertyName("contrato")]
    public bool Contrato { get; set; }

    /// <summary>
    /// Sem descrição - ctoPago  
    /// </summary>
    [JsonPropertyName("pago")]
    public bool Pago { get; set; }

    /// <summary>
    /// Sem descrição - ctoDistribuir  
    /// </summary>
    [JsonPropertyName("distribuir")]
    public bool Distribuir { get; set; }

    /// <summary>
    /// Sem descrição - ctoLC  
    /// </summary>
    [JsonPropertyName("lc")]
    public bool LC { get; set; }

    /// <summary>
    /// Sem descrição - ctoIDHTrab  
    /// </summary>
    [JsonPropertyName("idhtrab")]
    public int IDHTrab { get; set; }

    /// <summary>
    /// Sem descrição - ctoNroParcelas  
    /// </summary>
    [JsonPropertyName("nroparcelas")]
    public int NroParcelas { get; set; }

    /// <summary>
    /// Sem descrição - ctoValorPrincipal  
    /// </summary>
    [JsonPropertyName("valorprincipal")]
    public decimal ValorPrincipal { get; set; }

    /// <summary>
    /// Sem descrição - ctoParcelaPrincipalID  
    /// </summary>
    [JsonPropertyName("parcelaprincipalid")]
    public int ParcelaPrincipalID { get; set; }

    /// <summary>
    /// Sem descrição - ctoHide  
    /// </summary>
    [JsonPropertyName("hide")]
    public bool Hide { get; set; }

    /// <summary>
    /// Sem descrição - ctoDataPgto  
    /// </summary>
    [JsonPropertyName("datapgto")]
    public string DataPgto { get; set; } = "";

    /// <summary>
    /// GUId - ctoGUID - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("guid")]
    public string GUID { get; set; } = "";

    [JsonPropertyName("auditor")]
    public Auditor? Auditor { get; set; }
}