#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models.Response;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class AnexamentoRegistrosResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - axrCliente  
    /// </summary>
    [JsonPropertyName("cliente")]
    public int Cliente { get; set; }

    /// <summary>
    /// Sem descrição - axrGUIDReg - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("guidreg")]
    public string GUIDReg { get; set; } = "";

    /// <summary>
    /// Sem descrição - axrCodigoReg  
    /// </summary>
    [JsonPropertyName("codigoreg")]
    public int CodigoReg { get; set; }

    /// <summary>
    /// Sem descrição - axrIDReg  
    /// </summary>
    [JsonPropertyName("idreg")]
    public int IDReg { get; set; }

    /// <summary>
    /// Sem descrição - axrData  
    /// </summary>
    [JsonPropertyName("data")]
    public string Data { get; set; } = "";

    /// <summary>
    /// GUId - axrGUID - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("guid")]
    public string GUID { get; set; } = "";

    [JsonPropertyName("auditor")]
    public Auditor? Auditor { get; set; }
}