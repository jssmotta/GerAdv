#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class Operadores
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - operCliente  
    /// </summary>
    [JsonPropertyName("cliente")]
    public int Cliente { get; set; }

    /// <summary>
    /// Sem descrição - operEnviado  
    /// </summary>
    [JsonPropertyName("enviado")]
    public bool Enviado { get; set; }

    /// <summary>
    /// Sem descrição - operCasa  
    /// </summary>
    [JsonPropertyName("casa")]
    public bool Casa { get; set; }

    /// <summary>
    /// Sem descrição - operCasaID  
    /// </summary>
    [JsonPropertyName("casaid")]
    public int CasaID { get; set; }

    /// <summary>
    /// Sem descrição - operCasaCodigo  
    /// </summary>
    [JsonPropertyName("casacodigo")]
    public int CasaCodigo { get; set; }

    /// <summary>
    /// Sem descrição - operIsNovo  
    /// </summary>
    [JsonPropertyName("isnovo")]
    public bool IsNovo { get; set; }

    /// <summary>
    /// Sem descrição - operGrupo  
    /// </summary>
    [JsonPropertyName("grupo")]
    public int Grupo { get; set; }

    /// <summary>
    /// Sem descrição - operNome - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("nome")]
    public string Nome { get; set; } = "";

    /// <summary>
    /// Sem descrição - operEMail - tamanho máximo: 150 
    /// </summary>
    [JsonPropertyName("email")]
    public string EMail { get; set; } = "";

    /// <summary>
    /// Sem descrição - operSenha - tamanho máximo: 10 
    /// </summary>
    [JsonPropertyName("senha")]
    public string Senha { get; set; } = "";

    /// <summary>
    /// Sem descrição - operAtivado  
    /// </summary>
    [JsonPropertyName("ativado")]
    public bool Ativado { get; set; }

    /// <summary>
    /// Sem descrição - operAtualizarSenha  
    /// </summary>
    [JsonPropertyName("atualizarsenha")]
    public bool AtualizarSenha { get; set; }

    /// <summary>
    /// Sem descrição - operSenha256 - tamanho máximo: 4000 
    /// </summary>
    [JsonPropertyName("senha256")]
    public string Senha256 { get; set; } = "";

    /// <summary>
    /// Sem descrição - operSuporteSenha256 - tamanho máximo: 4000 
    /// </summary>
    [JsonPropertyName("suportesenha256")]
    public string SuporteSenha256 { get; set; } = "";

    /// <summary>
    /// Sem descrição - operSuporteMaxAge  
    /// </summary>
    [JsonPropertyName("suportemaxage")]
    public string SuporteMaxAge { get; set; } = "";

    [JsonPropertyName("auditor")]
    public Auditor? Auditor { get; set; }
}