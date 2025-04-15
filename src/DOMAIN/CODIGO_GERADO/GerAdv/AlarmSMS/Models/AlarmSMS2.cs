#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class AlarmSMS
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - alrOperador  
    /// </summary>
    [JsonPropertyName("operador")]
    public int Operador { get; set; }

    /// <summary>
    /// Sem descrição - alrAgenda  
    /// </summary>
    [JsonPropertyName("agenda")]
    public int Agenda { get; set; }

    /// <summary>
    /// Sem descrição - alrRecado  
    /// </summary>
    [JsonPropertyName("recado")]
    public int Recado { get; set; }

    /// <summary>
    /// Sem descrição - alrDescricao  
    /// </summary>
    [JsonPropertyName("descricao")]
    public string Descricao { get; set; } = "";

    /// <summary>
    /// Sem descrição - alrHora  
    /// </summary>
    [JsonPropertyName("hora")]
    public int Hora { get; set; }

    /// <summary>
    /// Sem descrição - alrMinuto  
    /// </summary>
    [JsonPropertyName("minuto")]
    public int Minuto { get; set; }

    /// <summary>
    /// Sem descrição - alrD1  
    /// </summary>
    [JsonPropertyName("d1")]
    public bool D1 { get; set; }

    /// <summary>
    /// Sem descrição - alrD2  
    /// </summary>
    [JsonPropertyName("d2")]
    public bool D2 { get; set; }

    /// <summary>
    /// Sem descrição - alrD3  
    /// </summary>
    [JsonPropertyName("d3")]
    public bool D3 { get; set; }

    /// <summary>
    /// Sem descrição - alrD4  
    /// </summary>
    [JsonPropertyName("d4")]
    public bool D4 { get; set; }

    /// <summary>
    /// Sem descrição - alrD5  
    /// </summary>
    [JsonPropertyName("d5")]
    public bool D5 { get; set; }

    /// <summary>
    /// Sem descrição - alrD6  
    /// </summary>
    [JsonPropertyName("d6")]
    public bool D6 { get; set; }

    /// <summary>
    /// Sem descrição - alrD7  
    /// </summary>
    [JsonPropertyName("d7")]
    public bool D7 { get; set; }

    /// <summary>
    /// Sem descrição - alrEMail - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("email")]
    public string EMail { get; set; } = "";

    /// <summary>
    /// Sem descrição - alrDesativar  
    /// </summary>
    [JsonPropertyName("desativar")]
    public bool Desativar { get; set; }

    /// <summary>
    /// Sem descrição - alrToday  
    /// </summary>
    [JsonPropertyName("today")]
    public string Today { get; set; } = "";

    /// <summary>
    /// Sem descrição - alrExcetoDiasFelizes  
    /// </summary>
    [JsonPropertyName("excetodiasfelizes")]
    public bool ExcetoDiasFelizes { get; set; }

    /// <summary>
    /// Sem descrição - alrDesktop  
    /// </summary>
    [JsonPropertyName("desktop")]
    public bool Desktop { get; set; }

    /// <summary>
    /// Sem descrição - alrAlertarDataHora  
    /// </summary>
    [JsonPropertyName("alertardatahora")]
    public string AlertarDataHora { get; set; } = "";

    /// <summary>
    /// Sem descrição - alrEmocao  
    /// </summary>
    [JsonPropertyName("emocao")]
    public int Emocao { get; set; }

    /// <summary>
    /// GUId - alrGUID - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("guid")]
    public string Guid { get; set; } = "";

    [JsonPropertyName("auditor")]
    public Auditor? Auditor { get; set; }
}