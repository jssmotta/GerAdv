#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class Historico
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - hisProcesso  
    /// </summary>
    [JsonPropertyName("processo")]
    public int Processo { get; set; }

    /// <summary>
    /// Sem descrição - hisPrecatoria  
    /// </summary>
    [JsonPropertyName("precatoria")]
    public int Precatoria { get; set; }

    /// <summary>
    /// Sem descrição - hisApenso  
    /// </summary>
    [JsonPropertyName("apenso")]
    public int Apenso { get; set; }

    /// <summary>
    /// Sem descrição - hisFase  
    /// </summary>
    [JsonPropertyName("fase")]
    public int Fase { get; set; }

    /// <summary>
    /// Sem descrição - hisStatusAndamento  
    /// </summary>
    [JsonPropertyName("statusandamento")]
    public int StatusAndamento { get; set; }

    /// <summary>
    /// Sem descrição - hisExtraID  
    /// </summary>
    [JsonPropertyName("extraid")]
    public int ExtraID { get; set; }

    /// <summary>
    /// Sem descrição - hisIDNE  
    /// </summary>
    [JsonPropertyName("idne")]
    public int IDNE { get; set; }

    /// <summary>
    /// Sem descrição - hisExtraGUID - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("guid")]
    public string GUID { get; set; } = "";

    /// <summary>
    /// Sem descrição - hisLiminarOrigem  
    /// </summary>
    [JsonPropertyName("liminarorigem")]
    public int LiminarOrigem { get; set; }

    /// <summary>
    /// Sem descrição - hisNaoPublicavel  
    /// </summary>
    [JsonPropertyName("naopublicavel")]
    public bool NaoPublicavel { get; set; }

    /// <summary>
    /// Sem descrição - hisIDInstProcesso  
    /// </summary>
    [JsonPropertyName("idinstprocesso")]
    public int IDInstProcesso { get; set; }

    /// <summary>
    /// Sem descrição - hisData  
    /// </summary>
    [JsonPropertyName("data")]
    public string Data { get; set; } = "";

    /// <summary>
    /// Sem descrição - hisObservacao  
    /// </summary>
    [JsonPropertyName("observacao")]
    public string Observacao { get; set; } = "";

    /// <summary>
    /// Sem descrição - hisAgendado  
    /// </summary>
    [JsonPropertyName("agendado")]
    public bool Agendado { get; set; }

    /// <summary>
    /// Sem descrição - hisConcluido  
    /// </summary>
    [JsonPropertyName("concluido")]
    public bool Concluido { get; set; }

    /// <summary>
    /// Sem descrição - hisMesmaAgenda  
    /// </summary>
    [JsonPropertyName("mesmaagenda")]
    public bool MesmaAgenda { get; set; }

    /// <summary>
    /// Sem descrição - hisSAD  
    /// </summary>
    [JsonPropertyName("sad")]
    public int SAD { get; set; }

    /// <summary>
    /// Sem descrição - hisResumido  
    /// </summary>
    [JsonPropertyName("resumido")]
    public bool Resumido { get; set; }

    /// <summary>
    /// Sem descrição - hisTop  
    /// </summary>
    [JsonPropertyName("top")]
    public bool Top { get; set; }

    /// <summary>
    /// GUId - hisGUID - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("guid")]
    public string GUID { get; set; } = "";

    [JsonPropertyName("auditor")]
    public Auditor? Auditor { get; set; }
}