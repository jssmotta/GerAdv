#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models.Response;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class AgendaResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - ageCidade  
    /// </summary>
    [JsonPropertyName("cidade")]
    public int Cidade { get; set; }

    /// <summary>
    /// Sem descrição - ageAdvogado  
    /// </summary>
    [JsonPropertyName("advogado")]
    public int Advogado { get; set; }

    /// <summary>
    /// Sem descrição - ageFuncionario  
    /// </summary>
    [JsonPropertyName("funcionario")]
    public int Funcionario { get; set; }

    /// <summary>
    /// Sem descrição - ageTipoCompromisso  
    /// </summary>
    [JsonPropertyName("tipocompromisso")]
    public int TipoCompromisso { get; set; }

    /// <summary>
    /// Sem descrição - ageCliente  
    /// </summary>
    [JsonPropertyName("cliente")]
    public int Cliente { get; set; }

    /// <summary>
    /// Sem descrição - ageArea  
    /// </summary>
    [JsonPropertyName("area")]
    public int Area { get; set; }

    /// <summary>
    /// Sem descrição - ageJustica  
    /// </summary>
    [JsonPropertyName("justica")]
    public int Justica { get; set; }

    /// <summary>
    /// Sem descrição - ageProcesso  
    /// </summary>
    [JsonPropertyName("processo")]
    public int Processo { get; set; }

    /// <summary>
    /// Sem descrição - ageUsuario  
    /// </summary>
    [JsonPropertyName("usuario")]
    public int Usuario { get; set; }

    /// <summary>
    /// Sem descrição - agePreposto  
    /// </summary>
    [JsonPropertyName("preposto")]
    public int Preposto { get; set; }

    /// <summary>
    /// Sem descrição - ageIDCOB  
    /// </summary>
    [JsonPropertyName("idcob")]
    public int IDCOB { get; set; }

    /// <summary>
    /// Sem descrição - ageClienteAvisado  
    /// </summary>
    [JsonPropertyName("clienteavisado")]
    public bool ClienteAvisado { get; set; }

    /// <summary>
    /// Sem descrição - ageRevisarP2  
    /// </summary>
    [JsonPropertyName("revisarp2")]
    public bool RevisarP2 { get; set; }

    /// <summary>
    /// Sem descrição - ageIDNE  
    /// </summary>
    [JsonPropertyName("idne")]
    public int IDNE { get; set; }

    /// <summary>
    /// Sem descrição - ageOculto  
    /// </summary>
    [JsonPropertyName("oculto")]
    public int Oculto { get; set; }

    /// <summary>
    /// Sem descrição - ageCartaPrecatoria  
    /// </summary>
    [JsonPropertyName("cartaprecatoria")]
    public int CartaPrecatoria { get; set; }

    /// <summary>
    /// Sem descrição - ageRevisar  
    /// </summary>
    [JsonPropertyName("revisar")]
    public bool Revisar { get; set; }

    /// <summary>
    /// Sem descrição - ageHrFinal  
    /// </summary>
    [JsonPropertyName("hrfinal")]
    public string HrFinal { get; set; } = "";

    /// <summary>
    /// Sem descrição - ageEventoGerador  
    /// </summary>
    [JsonPropertyName("eventogerador")]
    public int EventoGerador { get; set; }

    /// <summary>
    /// Sem descrição - ageEventoData  
    /// </summary>
    [JsonPropertyName("eventodata")]
    public string EventoData { get; set; } = "";

    /// <summary>
    /// Sem descrição - ageData  
    /// </summary>
    [JsonPropertyName("data")]
    public string Data { get; set; } = "";

    /// <summary>
    /// Sem descrição - ageEventoPrazo  
    /// </summary>
    [JsonPropertyName("eventoprazo")]
    public int EventoPrazo { get; set; }

    /// <summary>
    /// Sem descrição - ageHora  
    /// </summary>
    [JsonPropertyName("hora")]
    public string Hora { get; set; } = "";

    /// <summary>
    /// Sem descrição - ageCompromisso  
    /// </summary>
    [JsonPropertyName("compromisso")]
    public string Compromisso { get; set; } = "";

    /// <summary>
    /// Sem descrição - ageLiberado  
    /// </summary>
    [JsonPropertyName("liberado")]
    public bool Liberado { get; set; }

    /// <summary>
    /// Sem descrição - ageImportante  
    /// </summary>
    [JsonPropertyName("importante")]
    public bool Importante { get; set; }

    /// <summary>
    /// Sem descrição - ageConcluido  
    /// </summary>
    [JsonPropertyName("concluido")]
    public bool Concluido { get; set; }

    /// <summary>
    /// Sem descrição - ageIDHistorico  
    /// </summary>
    [JsonPropertyName("idhistorico")]
    public int IDHistorico { get; set; }

    /// <summary>
    /// Sem descrição - ageIDInsProcesso  
    /// </summary>
    [JsonPropertyName("idinsprocesso")]
    public int IDInsProcesso { get; set; }

    /// <summary>
    /// Sem descrição - ageQuemID  
    /// </summary>
    [JsonPropertyName("quemid")]
    public int QuemID { get; set; }

    /// <summary>
    /// Sem descrição - ageQuemCodigo  
    /// </summary>
    [JsonPropertyName("quemcodigo")]
    public int QuemCodigo { get; set; }

    /// <summary>
    /// Sem descrição - ageStatus  
    /// </summary>
    [JsonPropertyName("status")]
    public string Status { get; set; } = "";

    /// <summary>
    /// Sem descrição - ageValor  
    /// </summary>
    [JsonPropertyName("valor")]
    public decimal Valor { get; set; }

    /// <summary>
    /// Sem descrição - ageDecisao - tamanho máximo: 2048 
    /// </summary>
    [JsonPropertyName("decisao")]
    public string Decisao { get; set; } = "";

    /// <summary>
    /// Sem descrição - ageSempre  
    /// </summary>
    [JsonPropertyName("sempre")]
    public int Sempre { get; set; }

    /// <summary>
    /// Sem descrição - agePrazoDias  
    /// </summary>
    [JsonPropertyName("prazodias")]
    public int PrazoDias { get; set; }

    /// <summary>
    /// Sem descrição - ageProtocoloIntegrado  
    /// </summary>
    [JsonPropertyName("protocolointegrado")]
    public int ProtocoloIntegrado { get; set; }

    /// <summary>
    /// Sem descrição - ageDataInicioPrazo  
    /// </summary>
    [JsonPropertyName("datainicioprazo")]
    public string DataInicioPrazo { get; set; } = "";

    /// <summary>
    /// Sem descrição - ageUsuarioCiente  
    /// </summary>
    [JsonPropertyName("usuariociente")]
    public bool UsuarioCiente { get; set; }

    /// <summary>
    /// GUId - ageGUID - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("guid")]
    public string GUID { get; set; } = "";
}

[Serializable]
public partial class AgendaResponseAll
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - ageCidade  
    /// </summary>
    [JsonPropertyName("cidade")]
    public int Cidade { get; set; }

    /// <summary>
    /// Sem descrição - ageAdvogado  
    /// </summary>
    [JsonPropertyName("advogado")]
    public int Advogado { get; set; }

    /// <summary>
    /// Sem descrição - ageFuncionario  
    /// </summary>
    [JsonPropertyName("funcionario")]
    public int Funcionario { get; set; }

    /// <summary>
    /// Sem descrição - ageTipoCompromisso  
    /// </summary>
    [JsonPropertyName("tipocompromisso")]
    public int TipoCompromisso { get; set; }

    /// <summary>
    /// Sem descrição - ageCliente  
    /// </summary>
    [JsonPropertyName("cliente")]
    public int Cliente { get; set; }

    /// <summary>
    /// Sem descrição - ageArea  
    /// </summary>
    [JsonPropertyName("area")]
    public int Area { get; set; }

    /// <summary>
    /// Sem descrição - ageJustica  
    /// </summary>
    [JsonPropertyName("justica")]
    public int Justica { get; set; }

    /// <summary>
    /// Sem descrição - ageProcesso  
    /// </summary>
    [JsonPropertyName("processo")]
    public int Processo { get; set; }

    /// <summary>
    /// Sem descrição - ageUsuario  
    /// </summary>
    [JsonPropertyName("usuario")]
    public int Usuario { get; set; }

    /// <summary>
    /// Sem descrição - agePreposto  
    /// </summary>
    [JsonPropertyName("preposto")]
    public int Preposto { get; set; }

    /// <summary>
    /// Sem descrição - ageIDCOB  
    /// </summary>
    [JsonPropertyName("idcob")]
    public int IDCOB { get; set; }

    /// <summary>
    /// Sem descrição - ageClienteAvisado  
    /// </summary>
    [JsonPropertyName("clienteavisado")]
    public bool ClienteAvisado { get; set; }

    /// <summary>
    /// Sem descrição - ageRevisarP2  
    /// </summary>
    [JsonPropertyName("revisarp2")]
    public bool RevisarP2 { get; set; }

    /// <summary>
    /// Sem descrição - ageIDNE  
    /// </summary>
    [JsonPropertyName("idne")]
    public int IDNE { get; set; }

    /// <summary>
    /// Sem descrição - ageOculto  
    /// </summary>
    [JsonPropertyName("oculto")]
    public int Oculto { get; set; }

    /// <summary>
    /// Sem descrição - ageCartaPrecatoria  
    /// </summary>
    [JsonPropertyName("cartaprecatoria")]
    public int CartaPrecatoria { get; set; }

    /// <summary>
    /// Sem descrição - ageRevisar  
    /// </summary>
    [JsonPropertyName("revisar")]
    public bool Revisar { get; set; }

    /// <summary>
    /// Sem descrição - ageHrFinal  
    /// </summary>
    [JsonPropertyName("hrfinal")]
    public string HrFinal { get; set; } = "";

    /// <summary>
    /// Sem descrição - ageEventoGerador  
    /// </summary>
    [JsonPropertyName("eventogerador")]
    public int EventoGerador { get; set; }

    /// <summary>
    /// Sem descrição - ageEventoData  
    /// </summary>
    [JsonPropertyName("eventodata")]
    public string EventoData { get; set; } = "";

    /// <summary>
    /// Sem descrição - ageData  
    /// </summary>
    [JsonPropertyName("data")]
    public string Data { get; set; } = "";

    /// <summary>
    /// Sem descrição - ageEventoPrazo  
    /// </summary>
    [JsonPropertyName("eventoprazo")]
    public int EventoPrazo { get; set; }

    /// <summary>
    /// Sem descrição - ageHora  
    /// </summary>
    [JsonPropertyName("hora")]
    public string Hora { get; set; } = "";

    /// <summary>
    /// Sem descrição - ageCompromisso  
    /// </summary>
    [JsonPropertyName("compromisso")]
    public string Compromisso { get; set; } = "";

    /// <summary>
    /// Sem descrição - ageLiberado  
    /// </summary>
    [JsonPropertyName("liberado")]
    public bool Liberado { get; set; }

    /// <summary>
    /// Sem descrição - ageImportante  
    /// </summary>
    [JsonPropertyName("importante")]
    public bool Importante { get; set; }

    /// <summary>
    /// Sem descrição - ageConcluido  
    /// </summary>
    [JsonPropertyName("concluido")]
    public bool Concluido { get; set; }

    /// <summary>
    /// Sem descrição - ageIDHistorico  
    /// </summary>
    [JsonPropertyName("idhistorico")]
    public int IDHistorico { get; set; }

    /// <summary>
    /// Sem descrição - ageIDInsProcesso  
    /// </summary>
    [JsonPropertyName("idinsprocesso")]
    public int IDInsProcesso { get; set; }

    /// <summary>
    /// Sem descrição - ageQuemID  
    /// </summary>
    [JsonPropertyName("quemid")]
    public int QuemID { get; set; }

    /// <summary>
    /// Sem descrição - ageQuemCodigo  
    /// </summary>
    [JsonPropertyName("quemcodigo")]
    public int QuemCodigo { get; set; }

    /// <summary>
    /// Sem descrição - ageStatus  
    /// </summary>
    [JsonPropertyName("status")]
    public string Status { get; set; } = "";

    /// <summary>
    /// Sem descrição - ageValor  
    /// </summary>
    [JsonPropertyName("valor")]
    public decimal Valor { get; set; }

    /// <summary>
    /// Sem descrição - ageDecisao - tamanho máximo: 2048 
    /// </summary>
    [JsonPropertyName("decisao")]
    public string Decisao { get; set; } = "";

    /// <summary>
    /// Sem descrição - ageSempre  
    /// </summary>
    [JsonPropertyName("sempre")]
    public int Sempre { get; set; }

    /// <summary>
    /// Sem descrição - agePrazoDias  
    /// </summary>
    [JsonPropertyName("prazodias")]
    public int PrazoDias { get; set; }

    /// <summary>
    /// Sem descrição - ageProtocoloIntegrado  
    /// </summary>
    [JsonPropertyName("protocolointegrado")]
    public int ProtocoloIntegrado { get; set; }

    /// <summary>
    /// Sem descrição - ageDataInicioPrazo  
    /// </summary>
    [JsonPropertyName("datainicioprazo")]
    public string DataInicioPrazo { get; set; } = "";

    /// <summary>
    /// Sem descrição - ageUsuarioCiente  
    /// </summary>
    [JsonPropertyName("usuariociente")]
    public bool UsuarioCiente { get; set; }

    /// <summary>
    /// GUId - ageGUID - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("guid")]
    public string GUID { get; set; } = "";

    [JsonPropertyName("nomecidade")]
    public string NomeCidade { get; set; } = string.Empty;

    [JsonPropertyName("nomeadvogados")]
    public string NomeAdvogados { get; set; } = string.Empty;

    [JsonPropertyName("nomefuncionarios")]
    public string NomeFuncionarios { get; set; } = string.Empty;

    [JsonPropertyName("descricaotipocompromisso")]
    public string DescricaoTipoCompromisso { get; set; } = string.Empty;

    [JsonPropertyName("nomeclientes")]
    public string NomeClientes { get; set; } = string.Empty;

    [JsonPropertyName("descricaoarea")]
    public string DescricaoArea { get; set; } = string.Empty;

    [JsonPropertyName("nomejustica")]
    public string NomeJustica { get; set; } = string.Empty;

    [JsonPropertyName("nropastaprocessos")]
    public string NroPastaProcessos { get; set; } = string.Empty;

    [JsonPropertyName("nomeoperador")]
    public string NomeOperador { get; set; } = string.Empty;

    [JsonPropertyName("nomeprepostos")]
    public string NomePrepostos { get; set; } = string.Empty;
}