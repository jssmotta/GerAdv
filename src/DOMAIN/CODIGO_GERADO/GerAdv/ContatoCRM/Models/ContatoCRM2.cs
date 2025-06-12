#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class ContatoCRM
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - ctcOperador  
    /// </summary>
    [JsonPropertyName("operador")]
    public int Operador { get; set; }

    /// <summary>
    /// Sem descrição - ctcCliente  
    /// </summary>
    [JsonPropertyName("cliente")]
    public int Cliente { get; set; }

    /// <summary>
    /// Sem descrição - ctcProcesso  
    /// </summary>
    [JsonPropertyName("processo")]
    public int Processo { get; set; }

    /// <summary>
    /// Sem descrição - ctcTipoContatoCRM  
    /// </summary>
    [JsonPropertyName("tipocontatocrm")]
    public int TipoContatoCRM { get; set; }

    /// <summary>
    /// Sem descrição - ctcAgeClienteAvisado  
    /// </summary>
    [JsonPropertyName("ageclienteavisado")]
    public int AgeClienteAvisado { get; set; }

    /// <summary>
    /// Sem descrição - ctcDocsViaRecebimento  
    /// </summary>
    [JsonPropertyName("docsviarecebimento")]
    public int DocsViaRecebimento { get; set; }

    /// <summary>
    /// Sem descrição - ctcNaoPublicavel  
    /// </summary>
    [JsonPropertyName("naopublicavel")]
    public bool NaoPublicavel { get; set; }

    /// <summary>
    /// Sem descrição - ctcNotificar  
    /// </summary>
    [JsonPropertyName("notificar")]
    public bool Notificar { get; set; }

    /// <summary>
    /// Sem descrição - ctcOcultar  
    /// </summary>
    [JsonPropertyName("ocultar")]
    public bool Ocultar { get; set; }

    /// <summary>
    /// Sem descrição - ctcAssunto - tamanho máximo: 255 
    /// </summary>
    [JsonPropertyName("assunto")]
    public string Assunto { get; set; } = "";

    /// <summary>
    /// Sem descrição - ctcIsDocsRecebidos  
    /// </summary>
    [JsonPropertyName("isdocsrecebidos")]
    public bool IsDocsRecebidos { get; set; }

    /// <summary>
    /// Sem descrição - ctcQuemNotificou  
    /// </summary>
    [JsonPropertyName("quemnotificou")]
    public int QuemNotificou { get; set; }

    /// <summary>
    /// Sem descrição - ctcDataNotificou  
    /// </summary>
    [JsonPropertyName("datanotificou")]
    public string DataNotificou { get; set; } = "";

    /// <summary>
    /// Sem descrição - ctcHoraNotificou  
    /// </summary>
    [JsonPropertyName("horanotificou")]
    public string HoraNotificou { get; set; } = "";

    /// <summary>
    /// Sem descrição - ctcObjetoNotificou  
    /// </summary>
    [JsonPropertyName("objetonotificou")]
    public int ObjetoNotificou { get; set; }

    /// <summary>
    /// Sem descrição - ctcPessoaContato - tamanho máximo: 255 
    /// </summary>
    [JsonPropertyName("pessoacontato")]
    public string PessoaContato { get; set; } = "";

    /// <summary>
    /// Sem descrição - ctcData  
    /// </summary>
    [JsonPropertyName("data")]
    public string Data { get; set; } = "";

    /// <summary>
    /// Sem descrição - ctcTempo  
    /// </summary>
    [JsonPropertyName("tempo")]
    public decimal Tempo { get; set; }

    /// <summary>
    /// Sem descrição - ctcHoraInicial  
    /// </summary>
    [JsonPropertyName("horainicial")]
    public string HoraInicial { get; set; } = "";

    /// <summary>
    /// Sem descrição - ctcHoraFinal  
    /// </summary>
    [JsonPropertyName("horafinal")]
    public string HoraFinal { get; set; } = "";

    /// <summary>
    /// Sem descrição - ctcImportante  
    /// </summary>
    [JsonPropertyName("importante")]
    public bool Importante { get; set; }

    /// <summary>
    /// Sem descrição - ctcUrgente  
    /// </summary>
    [JsonPropertyName("urgente")]
    public bool Urgente { get; set; }

    /// <summary>
    /// Sem descrição - ctcGerarHoraTrabalhada  
    /// </summary>
    [JsonPropertyName("gerarhoratrabalhada")]
    public bool GerarHoraTrabalhada { get; set; }

    /// <summary>
    /// Sem descrição - ctcExibirNoTopo  
    /// </summary>
    [JsonPropertyName("exibirnotopo")]
    public bool ExibirNoTopo { get; set; }

    /// <summary>
    /// Sem descrição - ctcContato  
    /// </summary>
    [JsonPropertyName("contato")]
    public string Contato { get; set; } = "";

    /// <summary>
    /// Sem descrição - ctcEmocao  
    /// </summary>
    [JsonPropertyName("emocao")]
    public int Emocao { get; set; }

    /// <summary>
    /// Sem descrição - ctcContinuar  
    /// </summary>
    [JsonPropertyName("continuar")]
    public bool Continuar { get; set; }

    /// <summary>
    /// Negritar - ctcBold  
    /// </summary>
    [JsonPropertyName("bold")]
    public bool Bold { get; set; }

    /// <summary>
    /// GUId - ctcGUID - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("guid")]
    public string GUID { get; set; } = "";
}

[Serializable]
public partial class ContatoCRMAll
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - ctcOperador  
    /// </summary>
    [JsonPropertyName("operador")]
    public int Operador { get; set; }

    /// <summary>
    /// Sem descrição - ctcCliente  
    /// </summary>
    [JsonPropertyName("cliente")]
    public int Cliente { get; set; }

    /// <summary>
    /// Sem descrição - ctcProcesso  
    /// </summary>
    [JsonPropertyName("processo")]
    public int Processo { get; set; }

    /// <summary>
    /// Sem descrição - ctcTipoContatoCRM  
    /// </summary>
    [JsonPropertyName("tipocontatocrm")]
    public int TipoContatoCRM { get; set; }

    /// <summary>
    /// Sem descrição - ctcAgeClienteAvisado  
    /// </summary>
    [JsonPropertyName("ageclienteavisado")]
    public int AgeClienteAvisado { get; set; }

    /// <summary>
    /// Sem descrição - ctcDocsViaRecebimento  
    /// </summary>
    [JsonPropertyName("docsviarecebimento")]
    public int DocsViaRecebimento { get; set; }

    /// <summary>
    /// Sem descrição - ctcNaoPublicavel  
    /// </summary>
    [JsonPropertyName("naopublicavel")]
    public bool NaoPublicavel { get; set; }

    /// <summary>
    /// Sem descrição - ctcNotificar  
    /// </summary>
    [JsonPropertyName("notificar")]
    public bool Notificar { get; set; }

    /// <summary>
    /// Sem descrição - ctcOcultar  
    /// </summary>
    [JsonPropertyName("ocultar")]
    public bool Ocultar { get; set; }

    /// <summary>
    /// Sem descrição - ctcAssunto - tamanho máximo: 255 
    /// </summary>
    [JsonPropertyName("assunto")]
    public string Assunto { get; set; } = "";

    /// <summary>
    /// Sem descrição - ctcIsDocsRecebidos  
    /// </summary>
    [JsonPropertyName("isdocsrecebidos")]
    public bool IsDocsRecebidos { get; set; }

    /// <summary>
    /// Sem descrição - ctcQuemNotificou  
    /// </summary>
    [JsonPropertyName("quemnotificou")]
    public int QuemNotificou { get; set; }

    /// <summary>
    /// Sem descrição - ctcDataNotificou  
    /// </summary>
    [JsonPropertyName("datanotificou")]
    public string DataNotificou { get; set; } = "";

    /// <summary>
    /// Sem descrição - ctcHoraNotificou  
    /// </summary>
    [JsonPropertyName("horanotificou")]
    public string HoraNotificou { get; set; } = "";

    /// <summary>
    /// Sem descrição - ctcObjetoNotificou  
    /// </summary>
    [JsonPropertyName("objetonotificou")]
    public int ObjetoNotificou { get; set; }

    /// <summary>
    /// Sem descrição - ctcPessoaContato - tamanho máximo: 255 
    /// </summary>
    [JsonPropertyName("pessoacontato")]
    public string PessoaContato { get; set; } = "";

    /// <summary>
    /// Sem descrição - ctcData  
    /// </summary>
    [JsonPropertyName("data")]
    public string Data { get; set; } = "";

    /// <summary>
    /// Sem descrição - ctcTempo  
    /// </summary>
    [JsonPropertyName("tempo")]
    public decimal Tempo { get; set; }

    /// <summary>
    /// Sem descrição - ctcHoraInicial  
    /// </summary>
    [JsonPropertyName("horainicial")]
    public string HoraInicial { get; set; } = "";

    /// <summary>
    /// Sem descrição - ctcHoraFinal  
    /// </summary>
    [JsonPropertyName("horafinal")]
    public string HoraFinal { get; set; } = "";

    /// <summary>
    /// Sem descrição - ctcImportante  
    /// </summary>
    [JsonPropertyName("importante")]
    public bool Importante { get; set; }

    /// <summary>
    /// Sem descrição - ctcUrgente  
    /// </summary>
    [JsonPropertyName("urgente")]
    public bool Urgente { get; set; }

    /// <summary>
    /// Sem descrição - ctcGerarHoraTrabalhada  
    /// </summary>
    [JsonPropertyName("gerarhoratrabalhada")]
    public bool GerarHoraTrabalhada { get; set; }

    /// <summary>
    /// Sem descrição - ctcExibirNoTopo  
    /// </summary>
    [JsonPropertyName("exibirnotopo")]
    public bool ExibirNoTopo { get; set; }

    /// <summary>
    /// Sem descrição - ctcContato  
    /// </summary>
    [JsonPropertyName("contato")]
    public string Contato { get; set; } = "";

    /// <summary>
    /// Sem descrição - ctcEmocao  
    /// </summary>
    [JsonPropertyName("emocao")]
    public int Emocao { get; set; }

    /// <summary>
    /// Sem descrição - ctcContinuar  
    /// </summary>
    [JsonPropertyName("continuar")]
    public bool Continuar { get; set; }

    /// <summary>
    /// Negritar - ctcBold  
    /// </summary>
    [JsonPropertyName("bold")]
    public bool Bold { get; set; }

    /// <summary>
    /// GUId - ctcGUID - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("guid")]
    public string GUID { get; set; } = "";

    [JsonPropertyName("nomeoperador")]
    public string NomeOperador { get; set; } = string.Empty;

    [JsonPropertyName("nomeclientes")]
    public string NomeClientes { get; set; } = string.Empty;

    [JsonPropertyName("nropastaprocessos")]
    public string NroPastaProcessos { get; set; } = string.Empty;

    [JsonPropertyName("nometipocontatocrm")]
    public string NomeTipoContatoCRM { get; set; } = string.Empty;
}