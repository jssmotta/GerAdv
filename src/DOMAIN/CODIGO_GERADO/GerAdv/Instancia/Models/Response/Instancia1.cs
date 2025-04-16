#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models.Response;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class InstanciaResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - insProcesso  
    /// </summary>
    [JsonPropertyName("processo")]
    public int Processo { get; set; }

    /// <summary>
    /// Sem descrição - insAcao  
    /// </summary>
    [JsonPropertyName("acao")]
    public int Acao { get; set; }

    /// <summary>
    /// Sem descrição - insForo  
    /// </summary>
    [JsonPropertyName("foro")]
    public int Foro { get; set; }

    /// <summary>
    /// Sem descrição - insTipoRecurso  
    /// </summary>
    [JsonPropertyName("tiporecurso")]
    public int TipoRecurso { get; set; }

    /// <summary>
    /// Sem descrição - insLiminarPedida  
    /// </summary>
    [JsonPropertyName("liminarpedida")]
    public string LiminarPedida { get; set; } = "";

    /// <summary>
    /// Sem descrição - insObjeto - tamanho máximo: 255 
    /// </summary>
    [JsonPropertyName("objeto")]
    public string Objeto { get; set; } = "";

    /// <summary>
    /// Sem descrição - insStatusResultado  
    /// </summary>
    [JsonPropertyName("statusresultado")]
    public int StatusResultado { get; set; }

    /// <summary>
    /// Sem descrição - insLiminarPendente  
    /// </summary>
    [JsonPropertyName("liminarpendente")]
    public bool LiminarPendente { get; set; }

    /// <summary>
    /// Sem descrição - insInterpusemosRecurso  
    /// </summary>
    [JsonPropertyName("interpusemosrecurso")]
    public bool InterpusemosRecurso { get; set; }

    /// <summary>
    /// Sem descrição - insLiminarConcedida  
    /// </summary>
    [JsonPropertyName("liminarconcedida")]
    public bool LiminarConcedida { get; set; }

    /// <summary>
    /// Sem descrição - insLiminarNegada  
    /// </summary>
    [JsonPropertyName("liminarnegada")]
    public bool LiminarNegada { get; set; }

    /// <summary>
    /// Sem descrição - insData  
    /// </summary>
    [JsonPropertyName("data")]
    public string Data { get; set; } = "";

    /// <summary>
    /// Sem descrição - insLiminarParcial  
    /// </summary>
    [JsonPropertyName("liminarparcial")]
    public bool LiminarParcial { get; set; }

    /// <summary>
    /// Sem descrição - insLiminarResultado  
    /// </summary>
    [JsonPropertyName("liminarresultado")]
    public string LiminarResultado { get; set; } = "";

    /// <summary>
    /// Sem descrição - insNroProcesso - tamanho máximo: 25 
    /// </summary>
    [JsonPropertyName("nroprocesso")]
    public string NroProcesso { get; set; } = "";

    /// <summary>
    /// Sem descrição - insDivisao  
    /// </summary>
    [JsonPropertyName("divisao")]
    public int Divisao { get; set; }

    /// <summary>
    /// Sem descrição - insLiminarCliente  
    /// </summary>
    [JsonPropertyName("liminarcliente")]
    public bool LiminarCliente { get; set; }

    /// <summary>
    /// Sem descrição - insComarca  
    /// </summary>
    [JsonPropertyName("comarca")]
    public int Comarca { get; set; }

    /// <summary>
    /// Sem descrição - insSubDivisao  
    /// </summary>
    [JsonPropertyName("subdivisao")]
    public int SubDivisao { get; set; }

    /// <summary>
    /// Sem descrição - insPrincipal  
    /// </summary>
    [JsonPropertyName("principal")]
    public bool Principal { get; set; }

    /// <summary>
    /// Sem descrição - insZKey - tamanho máximo: 25 
    /// </summary>
    [JsonPropertyName("zkey")]
    public string ZKey { get; set; } = "";

    /// <summary>
    /// Sem descrição - insZKeyQuem  
    /// </summary>
    [JsonPropertyName("zkeyquem")]
    public int ZKeyQuem { get; set; }

    /// <summary>
    /// Sem descrição - insZKeyQuando  
    /// </summary>
    [JsonPropertyName("zkeyquando")]
    public string ZKeyQuando { get; set; } = "";

    /// <summary>
    /// Sem descrição - insNroAntigo - tamanho máximo: 25 
    /// </summary>
    [JsonPropertyName("nroantigo")]
    public string NroAntigo { get; set; } = "";

    /// <summary>
    /// Sem descrição - insAccessCode - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("accesscode")]
    public string AccessCode { get; set; } = "";

    /// <summary>
    /// Sem descrição - insJulgador  
    /// </summary>
    [JsonPropertyName("julgador")]
    public int Julgador { get; set; }

    /// <summary>
    /// Sem descrição - insZKeyIA - tamanho máximo: 25 
    /// </summary>
    [JsonPropertyName("zkeyia")]
    public string ZKeyIA { get; set; } = "";

    /// <summary>
    /// GUId - insGUID - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("guid")]
    public string Guid { get; set; } = "";

    [JsonPropertyName("auditor")]
    public Auditor? Auditor { get; set; }
}