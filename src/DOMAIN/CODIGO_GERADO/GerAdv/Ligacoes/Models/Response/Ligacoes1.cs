#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models.Response;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class LigacoesResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - ligCliente  
    /// </summary>
    [JsonPropertyName("cliente")]
    public int Cliente { get; set; }

    /// <summary>
    /// Sem descrição - ligRamal  
    /// </summary>
    [JsonPropertyName("ramal")]
    public int Ramal { get; set; }

    /// <summary>
    /// Sem descrição - ligProcesso  
    /// </summary>
    [JsonPropertyName("processo")]
    public int Processo { get; set; }

    /// <summary>
    /// Sem descrição - ligAssunto - tamanho máximo: 200 
    /// </summary>
    [JsonPropertyName("assunto")]
    public string Assunto { get; set; } = "";

    /// <summary>
    /// Sem descrição - ligAgeClienteAvisado  
    /// </summary>
    [JsonPropertyName("ageclienteavisado")]
    public int AgeClienteAvisado { get; set; }

    /// <summary>
    /// Sem descrição - ligCelular  
    /// </summary>
    [JsonPropertyName("celular")]
    public bool Celular { get; set; }

    /// <summary>
    /// Sem descrição - ligContato - tamanho máximo: 200 
    /// </summary>
    [JsonPropertyName("contato")]
    public string Contato { get; set; } = "";

    /// <summary>
    /// Sem descrição - ligDataRealizada  
    /// </summary>
    [JsonPropertyName("datarealizada")]
    public string DataRealizada { get; set; } = "";

    /// <summary>
    /// Sem descrição - ligQuemID  
    /// </summary>
    [JsonPropertyName("quemid")]
    public int QuemID { get; set; }

    /// <summary>
    /// Sem descrição - ligTelefonista  
    /// </summary>
    [JsonPropertyName("telefonista")]
    public int Telefonista { get; set; }

    /// <summary>
    /// Sem descrição - ligUltimoAviso  
    /// </summary>
    [JsonPropertyName("ultimoaviso")]
    public string UltimoAviso { get; set; } = "";

    /// <summary>
    /// Sem descrição - ligHoraFinal  
    /// </summary>
    [JsonPropertyName("horafinal")]
    public string HoraFinal { get; set; } = "";

    /// <summary>
    /// Sem descrição - ligNome - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("nome")]
    public string Nome { get; set; } = "";

    /// <summary>
    /// Sem descrição - ligQuemCodigo  
    /// </summary>
    [JsonPropertyName("quemcodigo")]
    public int QuemCodigo { get; set; }

    /// <summary>
    /// Sem descrição - ligSolicitante  
    /// </summary>
    [JsonPropertyName("solicitante")]
    public int Solicitante { get; set; }

    /// <summary>
    /// Sem descrição - ligPara - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("para")]
    public string Para { get; set; } = "";

    /// <summary>
    /// Fone - ligFone  
    /// </summary>
    [JsonPropertyName("fone")]
    public string Fone { get; set; } = "";

    /// <summary>
    /// Sem descrição - ligParticular  
    /// </summary>
    [JsonPropertyName("particular")]
    public bool Particular { get; set; }

    /// <summary>
    /// Sem descrição - ligRealizada  
    /// </summary>
    [JsonPropertyName("realizada")]
    public bool Realizada { get; set; }

    /// <summary>
    /// Sem descrição - ligStatus  
    /// </summary>
    [JsonPropertyName("status")]
    public string Status { get; set; } = "";

    /// <summary>
    /// Sem descrição - ligData  
    /// </summary>
    [JsonPropertyName("data")]
    public string Data { get; set; } = "";

    /// <summary>
    /// Sem descrição - ligHora  
    /// </summary>
    [JsonPropertyName("hora")]
    public string Hora { get; set; } = "";

    /// <summary>
    /// Sem descrição - ligUrgente  
    /// </summary>
    [JsonPropertyName("urgente")]
    public bool Urgente { get; set; }

    /// <summary>
    /// Sem descrição - ligLigarPara - tamanho máximo: 255 
    /// </summary>
    [JsonPropertyName("ligarpara")]
    public string LigarPara { get; set; } = "";

    /// <summary>
    /// Sem descrição - ligStartScreen  
    /// </summary>
    [JsonPropertyName("startscreen")]
    public bool StartScreen { get; set; }

    /// <summary>
    /// Sem descrição - ligEmotion  
    /// </summary>
    [JsonPropertyName("emotion")]
    public int Emotion { get; set; }

    /// <summary>
    /// Negritar - ligBold  
    /// </summary>
    [JsonPropertyName("bold")]
    public bool Bold { get; set; }

    /// <summary>
    /// GUId - ligGUID - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("guid")]
    public string GUID { get; set; } = "";

    [JsonPropertyName("auditor")]
    public Auditor? Auditor { get; set; }
}