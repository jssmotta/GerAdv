#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class AgendaRelatorio
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - vqaProcesso  
    /// </summary>
    [JsonPropertyName("processo")]
    public int Processo { get; set; }

    /// <summary>
    /// Sem descrição - vqaData  
    /// </summary>
    [JsonPropertyName("data")]
    public string Data { get; set; } = "";

    /// <summary>
    /// Sem descrição - xxxParaNome - tamanho máximo: 60 
    /// </summary>
    [JsonPropertyName("paranome")]
    public string ParaNome { get; set; } = "";

    /// <summary>
    /// Sem descrição - xxxParaPessoas  
    /// </summary>
    [JsonPropertyName("parapessoas")]
    public string ParaPessoas { get; set; } = "";

    /// <summary>
    /// Sem descrição - xxxBoxAudiencia  
    /// </summary>
    [JsonPropertyName("boxaudiencia")]
    public string BoxAudiencia { get; set; } = "";

    /// <summary>
    /// Sem descrição - xxxBoxAudienciaMobile  
    /// </summary>
    [JsonPropertyName("boxaudienciamobile")]
    public string BoxAudienciaMobile { get; set; } = "";

    /// <summary>
    /// Sem descrição - xxxNomeAdvogado - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("nomeadvogado")]
    public string NomeAdvogado { get; set; } = "";

    /// <summary>
    /// Sem descrição - xxxNomeForo - tamanho máximo: 40 
    /// </summary>
    [JsonPropertyName("nomeforo")]
    public string NomeForo { get; set; } = "";

    /// <summary>
    /// Sem descrição - xxxNomeJustica - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("nomejustica")]
    public string NomeJustica { get; set; } = "";

    /// <summary>
    /// Sem descrição - xxxNomeArea - tamanho máximo: 40 
    /// </summary>
    [JsonPropertyName("nomearea")]
    public string NomeArea { get; set; } = "";
}

[Serializable]
public partial class AgendaRelatorioAll
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - vqaProcesso  
    /// </summary>
    [JsonPropertyName("processo")]
    public int Processo { get; set; }

    /// <summary>
    /// Sem descrição - vqaData  
    /// </summary>
    [JsonPropertyName("data")]
    public string Data { get; set; } = "";

    /// <summary>
    /// Sem descrição - xxxParaNome - tamanho máximo: 60 
    /// </summary>
    [JsonPropertyName("paranome")]
    public string ParaNome { get; set; } = "";

    /// <summary>
    /// Sem descrição - xxxParaPessoas  
    /// </summary>
    [JsonPropertyName("parapessoas")]
    public string ParaPessoas { get; set; } = "";

    /// <summary>
    /// Sem descrição - xxxBoxAudiencia  
    /// </summary>
    [JsonPropertyName("boxaudiencia")]
    public string BoxAudiencia { get; set; } = "";

    /// <summary>
    /// Sem descrição - xxxBoxAudienciaMobile  
    /// </summary>
    [JsonPropertyName("boxaudienciamobile")]
    public string BoxAudienciaMobile { get; set; } = "";

    /// <summary>
    /// Sem descrição - xxxNomeAdvogado - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("nomeadvogado")]
    public string NomeAdvogado { get; set; } = "";

    /// <summary>
    /// Sem descrição - xxxNomeForo - tamanho máximo: 40 
    /// </summary>
    [JsonPropertyName("nomeforo")]
    public string NomeForo { get; set; } = "";

    /// <summary>
    /// Sem descrição - xxxNomeJustica - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("nomejustica")]
    public string NomeJustica { get; set; } = "";

    /// <summary>
    /// Sem descrição - xxxNomeArea - tamanho máximo: 40 
    /// </summary>
    [JsonPropertyName("nomearea")]
    public string NomeArea { get; set; } = "";

    [JsonPropertyName("nropastaprocessos")]
    public string NroPastaProcessos { get; set; } = string.Empty;
}