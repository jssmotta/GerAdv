#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class AgendaRecords
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - ragAgenda  
    /// </summary>
    [JsonPropertyName("agenda")]
    public int Agenda { get; set; }

    /// <summary>
    /// Sem descrição - ragClientesSocios  
    /// </summary>
    [JsonPropertyName("clientessocios")]
    public int ClientesSocios { get; set; }

    /// <summary>
    /// Sem descrição - ragColaborador  
    /// </summary>
    [JsonPropertyName("colaborador")]
    public int Colaborador { get; set; }

    /// <summary>
    /// Sem descrição - ragForo  
    /// </summary>
    [JsonPropertyName("foro")]
    public int Foro { get; set; }

    /// <summary>
    /// Sem descrição - ragJulgador  
    /// </summary>
    [JsonPropertyName("julgador")]
    public int Julgador { get; set; }

    /// <summary>
    /// Sem descrição - ragPerito  
    /// </summary>
    [JsonPropertyName("perito")]
    public int Perito { get; set; }

    /// <summary>
    /// Sem descrição - ragAviso1  
    /// </summary>
    [JsonPropertyName("aviso1")]
    public bool Aviso1 { get; set; }

    /// <summary>
    /// Sem descrição - ragAviso2  
    /// </summary>
    [JsonPropertyName("aviso2")]
    public bool Aviso2 { get; set; }

    /// <summary>
    /// Sem descrição - ragAviso3  
    /// </summary>
    [JsonPropertyName("aviso3")]
    public bool Aviso3 { get; set; }

    /// <summary>
    /// Sem descrição - ragCrmAviso1  
    /// </summary>
    [JsonPropertyName("crmaviso1")]
    public int CrmAviso1 { get; set; }

    /// <summary>
    /// Sem descrição - ragCrmAviso2  
    /// </summary>
    [JsonPropertyName("crmaviso2")]
    public int CrmAviso2 { get; set; }

    /// <summary>
    /// Sem descrição - ragCrmAviso3  
    /// </summary>
    [JsonPropertyName("crmaviso3")]
    public int CrmAviso3 { get; set; }

    /// <summary>
    /// Sem descrição - ragDataAviso1  
    /// </summary>
    [JsonPropertyName("dataaviso1")]
    public string DataAviso1 { get; set; } = "";

    /// <summary>
    /// Sem descrição - ragDataAviso2  
    /// </summary>
    [JsonPropertyName("dataaviso2")]
    public string DataAviso2 { get; set; } = "";

    /// <summary>
    /// Sem descrição - ragDataAviso3  
    /// </summary>
    [JsonPropertyName("dataaviso3")]
    public string DataAviso3 { get; set; } = "";
}