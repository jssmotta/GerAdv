#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class OperadorEMailPopup
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - oepOperador  
    /// </summary>
    [JsonPropertyName("operador")]
    public int Operador { get; set; }

    /// <summary>
    /// Sem descrição - oepNome - tamanho máximo: 80 
    /// </summary>
    [JsonPropertyName("nome")]
    public string Nome { get; set; } = "";

    /// <summary>
    /// Sem descrição - oepSenha - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("senha")]
    public string Senha { get; set; } = "";

    /// <summary>
    /// Sem descrição - oepSMTP - tamanho máximo: 255 
    /// </summary>
    [JsonPropertyName("smtp")]
    public string SMTP { get; set; } = "";

    /// <summary>
    /// Sem descrição - oepPOP3 - tamanho máximo: 255 
    /// </summary>
    [JsonPropertyName("pop3")]
    public string POP3 { get; set; } = "";

    /// <summary>
    /// Sem descrição - oepAutenticacao  
    /// </summary>
    [JsonPropertyName("autenticacao")]
    public bool Autenticacao { get; set; }

    /// <summary>
    /// Sem descrição - oepDescricao - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("descricao")]
    public string Descricao { get; set; } = "";

    /// <summary>
    /// Sem descrição - oepUsuario - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("usuario")]
    public string Usuario { get; set; } = "";

    /// <summary>
    /// Sem descrição - oepPortaSmtp  
    /// </summary>
    [JsonPropertyName("portasmtp")]
    public int PortaSmtp { get; set; }

    /// <summary>
    /// Sem descrição - oepPortaPop3  
    /// </summary>
    [JsonPropertyName("portapop3")]
    public int PortaPop3 { get; set; }

    /// <summary>
    /// Sem descrição - oepAssinatura  
    /// </summary>
    [JsonPropertyName("assinatura")]
    public string Assinatura { get; set; } = "";

    /// <summary>
    /// Sem descrição - oepSenha256 - tamanho máximo: 4000 
    /// </summary>
    [JsonPropertyName("senha256")]
    public string Senha256 { get; set; } = "";

    /// <summary>
    /// GUId - oepGUID - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("guid")]
    public string GUID { get; set; } = "";

    [JsonPropertyName("auditor")]
    public Auditor? Auditor { get; set; }
}