#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models.Response;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class DocsRecebidosItensResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - driContatoCRM  
    /// </summary>
    [JsonPropertyName("contatocrm")]
    public int ContatoCRM { get; set; }

    /// <summary>
    /// Sem descrição - driNome - tamanho máximo: 255 
    /// </summary>
    [JsonPropertyName("nome")]
    public string Nome { get; set; } = "";

    /// <summary>
    /// Sem descrição - driDevolvido  
    /// </summary>
    [JsonPropertyName("devolvido")]
    public bool Devolvido { get; set; }

    /// <summary>
    /// Sem descrição - driSeraDevolvido  
    /// </summary>
    [JsonPropertyName("seradevolvido")]
    public bool SeraDevolvido { get; set; }

    /// <summary>
    /// Sem descrição - driObservacoes  
    /// </summary>
    [JsonPropertyName("observacoes")]
    public string Observacoes { get; set; } = "";

    /// <summary>
    /// Negritar - driBold  
    /// </summary>
    [JsonPropertyName("bold")]
    public bool Bold { get; set; }

    /// <summary>
    /// GUId - driGUID - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("guid")]
    public string GUID { get; set; } = "";

    [JsonPropertyName("auditor")]
    public Auditor? Auditor { get; set; }
}