#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class Operador
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - operStatusId  
    /// </summary>
    [JsonPropertyName("statusid")]
    public int StatusId { get; set; }

    /// <summary>
    /// Sem descrição - operEMail - tamanho máximo: 150 
    /// </summary>
    [JsonPropertyName("email")]
    public string EMail { get; set; } = "";

    /// <summary>
    /// Sem descrição - operPasta  
    /// </summary>
    [JsonPropertyName("pasta")]
    public string Pasta { get; set; } = "";

    /// <summary>
    /// Sem descrição - operTelefonista  
    /// </summary>
    [JsonPropertyName("telefonista")]
    public bool Telefonista { get; set; }

    /// <summary>
    /// Sem descrição - operMaster  
    /// </summary>
    [JsonPropertyName("master")]
    public bool Master { get; set; }

    /// <summary>
    /// Sem descrição - operNome - tamanho máximo: 40 
    /// </summary>
    [JsonPropertyName("nome")]
    public string Nome { get; set; } = "";

    /// <summary>
    /// Sem descrição - operNick - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("nick")]
    public string Nick { get; set; } = "";

    /// <summary>
    /// Sem descrição - operRamal - tamanho máximo: 20 
    /// </summary>
    [JsonPropertyName("ramal")]
    public string Ramal { get; set; } = "";

    /// <summary>
    /// Sem descrição - operCadID  
    /// </summary>
    [JsonPropertyName("cadid")]
    public int CadID { get; set; }

    /// <summary>
    /// Sem descrição - operCadCod  
    /// </summary>
    [JsonPropertyName("cadcod")]
    public int CadCod { get; set; }

    /// <summary>
    /// Sem descrição - operExcluido  
    /// </summary>
    [JsonPropertyName("excluido")]
    public bool Excluido { get; set; }

    /// <summary>
    /// Sem descrição - operSituacao  
    /// </summary>
    [JsonPropertyName("situacao")]
    public bool Situacao { get; set; }

    /// <summary>
    /// Sem descrição - operComputador  
    /// </summary>
    [JsonPropertyName("computador")]
    public int Computador { get; set; }

    /// <summary>
    /// Sem descrição - operMinhaDescricao - tamanho máximo: 255 
    /// </summary>
    [JsonPropertyName("minhadescricao")]
    public string MinhaDescricao { get; set; } = "";

    /// <summary>
    /// Sem descrição - operUltimoLogoff  
    /// </summary>
    [JsonPropertyName("ultimologoff")]
    public string UltimoLogoff { get; set; } = "";

    /// <summary>
    /// Sem descrição - operEMailNet - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("emailnet")]
    public string EMailNet { get; set; } = "";

    /// <summary>
    /// Sem descrição - operOnlineIP - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("onlineip")]
    public string OnlineIP { get; set; } = "";

    /// <summary>
    /// Sem descrição - operOnLine  
    /// </summary>
    [JsonPropertyName("online")]
    public bool OnLine { get; set; }

    /// <summary>
    /// Sem descrição - operSysOp  
    /// </summary>
    [JsonPropertyName("sysop")]
    public bool SysOp { get; set; }

    /// <summary>
    /// Sem descrição - operStatusMessage - tamanho máximo: 1024 
    /// </summary>
    [JsonPropertyName("statusmessage")]
    public string StatusMessage { get; set; } = "";

    /// <summary>
    /// Sem descrição - operIsFinanceiro  
    /// </summary>
    [JsonPropertyName("isfinanceiro")]
    public bool IsFinanceiro { get; set; }

    /// <summary>
    /// Sem descrição - operTop  
    /// </summary>
    [JsonPropertyName("top")]
    public bool Top { get; set; }

    /// <summary>
    /// Sem descrição - operSexo  
    /// </summary>
    [JsonPropertyName("sexo")]
    public bool Sexo { get; set; }

    /// <summary>
    /// Sem descrição - operBasico  
    /// </summary>
    [JsonPropertyName("basico")]
    public bool Basico { get; set; }

    /// <summary>
    /// Sem descrição - operExterno  
    /// </summary>
    [JsonPropertyName("externo")]
    public bool Externo { get; set; }

    /// <summary>
    /// Sem descrição - operSenha256 - tamanho máximo: 4000 
    /// </summary>
    [JsonPropertyName("senha256")]
    public string Senha256 { get; set; } = "";

    /// <summary>
    /// Sem descrição - operEMailConfirmado  
    /// </summary>
    [JsonPropertyName("emailconfirmado")]
    public bool EMailConfirmado { get; set; }

    /// <summary>
    /// Sem descrição - operDataLimiteReset  
    /// </summary>
    [JsonPropertyName("datalimitereset")]
    public string DataLimiteReset { get; set; } = "";

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

    /// <summary>
    /// Sem descrição - operSuporteNomeSolicitante - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("suportenomesolicitante")]
    public string SuporteNomeSolicitante { get; set; } = "";

    /// <summary>
    /// Sem descrição - operSuporteUltimoAcesso  
    /// </summary>
    [JsonPropertyName("suporteultimoacesso")]
    public string SuporteUltimoAcesso { get; set; } = "";

    /// <summary>
    /// Sem descrição - operSuporteIpUltimoAcesso - tamanho máximo: 80 
    /// </summary>
    [JsonPropertyName("suporteipultimoacesso")]
    public string SuporteIpUltimoAcesso { get; set; } = "";

    /// <summary>
    /// GUId - operGUID - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("guid")]
    public string GUID { get; set; } = "";
}

[Serializable]
public partial class OperadorAll
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - operStatusId  
    /// </summary>
    [JsonPropertyName("statusid")]
    public int StatusId { get; set; }

    /// <summary>
    /// Sem descrição - operEMail - tamanho máximo: 150 
    /// </summary>
    [JsonPropertyName("email")]
    public string EMail { get; set; } = "";

    /// <summary>
    /// Sem descrição - operPasta  
    /// </summary>
    [JsonPropertyName("pasta")]
    public string Pasta { get; set; } = "";

    /// <summary>
    /// Sem descrição - operTelefonista  
    /// </summary>
    [JsonPropertyName("telefonista")]
    public bool Telefonista { get; set; }

    /// <summary>
    /// Sem descrição - operMaster  
    /// </summary>
    [JsonPropertyName("master")]
    public bool Master { get; set; }

    /// <summary>
    /// Sem descrição - operNome - tamanho máximo: 40 
    /// </summary>
    [JsonPropertyName("nome")]
    public string Nome { get; set; } = "";

    /// <summary>
    /// Sem descrição - operNick - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("nick")]
    public string Nick { get; set; } = "";

    /// <summary>
    /// Sem descrição - operRamal - tamanho máximo: 20 
    /// </summary>
    [JsonPropertyName("ramal")]
    public string Ramal { get; set; } = "";

    /// <summary>
    /// Sem descrição - operCadID  
    /// </summary>
    [JsonPropertyName("cadid")]
    public int CadID { get; set; }

    /// <summary>
    /// Sem descrição - operCadCod  
    /// </summary>
    [JsonPropertyName("cadcod")]
    public int CadCod { get; set; }

    /// <summary>
    /// Sem descrição - operExcluido  
    /// </summary>
    [JsonPropertyName("excluido")]
    public bool Excluido { get; set; }

    /// <summary>
    /// Sem descrição - operSituacao  
    /// </summary>
    [JsonPropertyName("situacao")]
    public bool Situacao { get; set; }

    /// <summary>
    /// Sem descrição - operComputador  
    /// </summary>
    [JsonPropertyName("computador")]
    public int Computador { get; set; }

    /// <summary>
    /// Sem descrição - operMinhaDescricao - tamanho máximo: 255 
    /// </summary>
    [JsonPropertyName("minhadescricao")]
    public string MinhaDescricao { get; set; } = "";

    /// <summary>
    /// Sem descrição - operUltimoLogoff  
    /// </summary>
    [JsonPropertyName("ultimologoff")]
    public string UltimoLogoff { get; set; } = "";

    /// <summary>
    /// Sem descrição - operEMailNet - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("emailnet")]
    public string EMailNet { get; set; } = "";

    /// <summary>
    /// Sem descrição - operOnlineIP - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("onlineip")]
    public string OnlineIP { get; set; } = "";

    /// <summary>
    /// Sem descrição - operOnLine  
    /// </summary>
    [JsonPropertyName("online")]
    public bool OnLine { get; set; }

    /// <summary>
    /// Sem descrição - operSysOp  
    /// </summary>
    [JsonPropertyName("sysop")]
    public bool SysOp { get; set; }

    /// <summary>
    /// Sem descrição - operStatusMessage - tamanho máximo: 1024 
    /// </summary>
    [JsonPropertyName("statusmessage")]
    public string StatusMessage { get; set; } = "";

    /// <summary>
    /// Sem descrição - operIsFinanceiro  
    /// </summary>
    [JsonPropertyName("isfinanceiro")]
    public bool IsFinanceiro { get; set; }

    /// <summary>
    /// Sem descrição - operTop  
    /// </summary>
    [JsonPropertyName("top")]
    public bool Top { get; set; }

    /// <summary>
    /// Sem descrição - operSexo  
    /// </summary>
    [JsonPropertyName("sexo")]
    public bool Sexo { get; set; }

    /// <summary>
    /// Sem descrição - operBasico  
    /// </summary>
    [JsonPropertyName("basico")]
    public bool Basico { get; set; }

    /// <summary>
    /// Sem descrição - operExterno  
    /// </summary>
    [JsonPropertyName("externo")]
    public bool Externo { get; set; }

    /// <summary>
    /// Sem descrição - operSenha256 - tamanho máximo: 4000 
    /// </summary>
    [JsonPropertyName("senha256")]
    public string Senha256 { get; set; } = "";

    /// <summary>
    /// Sem descrição - operEMailConfirmado  
    /// </summary>
    [JsonPropertyName("emailconfirmado")]
    public bool EMailConfirmado { get; set; }

    /// <summary>
    /// Sem descrição - operDataLimiteReset  
    /// </summary>
    [JsonPropertyName("datalimitereset")]
    public string DataLimiteReset { get; set; } = "";

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

    /// <summary>
    /// Sem descrição - operSuporteNomeSolicitante - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("suportenomesolicitante")]
    public string SuporteNomeSolicitante { get; set; } = "";

    /// <summary>
    /// Sem descrição - operSuporteUltimoAcesso  
    /// </summary>
    [JsonPropertyName("suporteultimoacesso")]
    public string SuporteUltimoAcesso { get; set; } = "";

    /// <summary>
    /// Sem descrição - operSuporteIpUltimoAcesso - tamanho máximo: 80 
    /// </summary>
    [JsonPropertyName("suporteipultimoacesso")]
    public string SuporteIpUltimoAcesso { get; set; } = "";

    /// <summary>
    /// GUId - operGUID - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("guid")]
    public string GUID { get; set; } = "";

    [JsonPropertyName("nomestatusbiu")]
    public string NomeStatusBiu { get; set; } = string.Empty;
}