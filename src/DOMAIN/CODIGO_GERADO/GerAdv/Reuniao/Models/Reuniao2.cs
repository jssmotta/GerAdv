#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class Reuniao
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - renCliente  
    /// </summary>
    [JsonPropertyName("cliente")]
    public int Cliente { get; set; }

    /// <summary>
    /// Sem descrição - renIDAgenda  
    /// </summary>
    [JsonPropertyName("idagenda")]
    public int IDAgenda { get; set; }

    /// <summary>
    /// Sem descrição - renData  
    /// </summary>
    [JsonPropertyName("data")]
    public string Data { get; set; } = "";

    /// <summary>
    /// Sem descrição - renPauta  
    /// </summary>
    [JsonPropertyName("pauta")]
    public string Pauta { get; set; } = "";

    /// <summary>
    /// Sem descrição - renATA  
    /// </summary>
    [JsonPropertyName("ata")]
    public string ATA { get; set; } = "";

    /// <summary>
    /// Sem descrição - renHoraInicial  
    /// </summary>
    [JsonPropertyName("horainicial")]
    public string HoraInicial { get; set; } = "";

    /// <summary>
    /// Sem descrição - renHoraFinal  
    /// </summary>
    [JsonPropertyName("horafinal")]
    public string HoraFinal { get; set; } = "";

    /// <summary>
    /// Sem descrição - renExterna  
    /// </summary>
    [JsonPropertyName("externa")]
    public bool Externa { get; set; }

    /// <summary>
    /// Sem descrição - renHoraSaida  
    /// </summary>
    [JsonPropertyName("horasaida")]
    public string HoraSaida { get; set; } = "";

    /// <summary>
    /// Sem descrição - renHoraRetorno  
    /// </summary>
    [JsonPropertyName("horaretorno")]
    public string HoraRetorno { get; set; } = "";

    /// <summary>
    /// Sem descrição - renPrincipaisDecisoes  
    /// </summary>
    [JsonPropertyName("principaisdecisoes")]
    public string PrincipaisDecisoes { get; set; } = "";

    /// <summary>
    /// Negritar - renBold  
    /// </summary>
    [JsonPropertyName("bold")]
    public bool Bold { get; set; }

    /// <summary>
    /// GUId - renGUID - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("guid")]
    public string GUID { get; set; } = "";
}

[Serializable]
public partial class ReuniaoAll
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - renCliente  
    /// </summary>
    [JsonPropertyName("cliente")]
    public int Cliente { get; set; }

    /// <summary>
    /// Sem descrição - renIDAgenda  
    /// </summary>
    [JsonPropertyName("idagenda")]
    public int IDAgenda { get; set; }

    /// <summary>
    /// Sem descrição - renData  
    /// </summary>
    [JsonPropertyName("data")]
    public string Data { get; set; } = "";

    /// <summary>
    /// Sem descrição - renPauta  
    /// </summary>
    [JsonPropertyName("pauta")]
    public string Pauta { get; set; } = "";

    /// <summary>
    /// Sem descrição - renATA  
    /// </summary>
    [JsonPropertyName("ata")]
    public string ATA { get; set; } = "";

    /// <summary>
    /// Sem descrição - renHoraInicial  
    /// </summary>
    [JsonPropertyName("horainicial")]
    public string HoraInicial { get; set; } = "";

    /// <summary>
    /// Sem descrição - renHoraFinal  
    /// </summary>
    [JsonPropertyName("horafinal")]
    public string HoraFinal { get; set; } = "";

    /// <summary>
    /// Sem descrição - renExterna  
    /// </summary>
    [JsonPropertyName("externa")]
    public bool Externa { get; set; }

    /// <summary>
    /// Sem descrição - renHoraSaida  
    /// </summary>
    [JsonPropertyName("horasaida")]
    public string HoraSaida { get; set; } = "";

    /// <summary>
    /// Sem descrição - renHoraRetorno  
    /// </summary>
    [JsonPropertyName("horaretorno")]
    public string HoraRetorno { get; set; } = "";

    /// <summary>
    /// Sem descrição - renPrincipaisDecisoes  
    /// </summary>
    [JsonPropertyName("principaisdecisoes")]
    public string PrincipaisDecisoes { get; set; } = "";

    /// <summary>
    /// Negritar - renBold  
    /// </summary>
    [JsonPropertyName("bold")]
    public bool Bold { get; set; }

    /// <summary>
    /// GUId - renGUID - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("guid")]
    public string GUID { get; set; } = "";

    [JsonPropertyName("nomeclientes")]
    public string NomeClientes { get; set; } = string.Empty;
}