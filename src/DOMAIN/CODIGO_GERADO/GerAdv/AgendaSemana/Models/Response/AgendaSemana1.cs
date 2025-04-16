#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models.Response;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class AgendaSemanaResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - xxxFuncionario  
    /// </summary>
    [JsonPropertyName("funcionario")]
    public int Funcionario { get; set; }

    /// <summary>
    /// Sem descrição - xxxAdvogado  
    /// </summary>
    [JsonPropertyName("advogado")]
    public int Advogado { get; set; }

    /// <summary>
    /// Sem descrição - xxxTipoCompromisso  
    /// </summary>
    [JsonPropertyName("tipocompromisso")]
    public int TipoCompromisso { get; set; }

    /// <summary>
    /// Sem descrição - xxxCliente  
    /// </summary>
    [JsonPropertyName("cliente")]
    public int Cliente { get; set; }

    /// <summary>
    /// Sem descrição - xxxParaNome - tamanho máximo: 60 
    /// </summary>
    [JsonPropertyName("paranome")]
    public string ParaNome { get; set; } = "";

    /// <summary>
    /// Sem descrição - xxxData  
    /// </summary>
    [JsonPropertyName("data")]
    public string Data { get; set; } = "";

    /// <summary>
    /// Sem descrição - xxxHora  
    /// </summary>
    [JsonPropertyName("hora")]
    public string Hora { get; set; } = "";

    /// <summary>
    /// Sem descrição - xxxCompromisso  
    /// </summary>
    [JsonPropertyName("compromisso")]
    public string Compromisso { get; set; } = "";

    /// <summary>
    /// Sem descrição - xxxConcluido  
    /// </summary>
    [JsonPropertyName("concluido")]
    public bool Concluido { get; set; }

    /// <summary>
    /// Sem descrição - xxxLiberado  
    /// </summary>
    [JsonPropertyName("liberado")]
    public bool Liberado { get; set; }

    /// <summary>
    /// Sem descrição - xxxImportante  
    /// </summary>
    [JsonPropertyName("importante")]
    public bool Importante { get; set; }

    /// <summary>
    /// Sem descrição - xxxHoraFinal  
    /// </summary>
    [JsonPropertyName("horafinal")]
    public string HoraFinal { get; set; } = "";

    /// <summary>
    /// Sem descrição - xxxNome - tamanho máximo: 80 
    /// </summary>
    [JsonPropertyName("nome")]
    public string Nome { get; set; } = "";

    /// <summary>
    /// Sem descrição - xxxNomeCliente - tamanho máximo: 80 
    /// </summary>
    [JsonPropertyName("nomecliente")]
    public string NomeCliente { get; set; } = "";

    /// <summary>
    /// Sem descrição - xxxTipo - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("tipo")]
    public string Tipo { get; set; } = "";
}