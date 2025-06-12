#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class Recados
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - recProcesso  
    /// </summary>
    [JsonPropertyName("processo")]
    public int Processo { get; set; }

    /// <summary>
    /// Sem descrição - recCliente  
    /// </summary>
    [JsonPropertyName("cliente")]
    public int Cliente { get; set; }

    /// <summary>
    /// Sem descrição - recHistorico  
    /// </summary>
    [JsonPropertyName("historico")]
    public int Historico { get; set; }

    /// <summary>
    /// Sem descrição - recContatoCRM  
    /// </summary>
    [JsonPropertyName("contatocrm")]
    public int ContatoCRM { get; set; }

    /// <summary>
    /// Sem descrição - recLigacoes  
    /// </summary>
    [JsonPropertyName("ligacoes")]
    public int Ligacoes { get; set; }

    /// <summary>
    /// Sem descrição - recAgenda  
    /// </summary>
    [JsonPropertyName("agenda")]
    public int Agenda { get; set; }

    /// <summary>
    /// Sem descrição - recClienteNome - tamanho máximo: 255 
    /// </summary>
    [JsonPropertyName("clientenome")]
    public string ClienteNome { get; set; } = "";

    /// <summary>
    /// Sem descrição - recDe - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("de")]
    public string De { get; set; } = "";

    /// <summary>
    /// Sem descrição - recPara - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("para")]
    public string Para { get; set; } = "";

    /// <summary>
    /// Sem descrição - recAssunto - tamanho máximo: 255 
    /// </summary>
    [JsonPropertyName("assunto")]
    public string Assunto { get; set; } = "";

    /// <summary>
    /// Sem descrição - recConcluido  
    /// </summary>
    [JsonPropertyName("concluido")]
    public bool Concluido { get; set; }

    /// <summary>
    /// Sem descrição - recRecado  
    /// </summary>
    [JsonPropertyName("recado")]
    public string Recado { get; set; } = "";

    /// <summary>
    /// Sem descrição - recUrgente  
    /// </summary>
    [JsonPropertyName("urgente")]
    public bool Urgente { get; set; }

    /// <summary>
    /// Sem descrição - recImportante  
    /// </summary>
    [JsonPropertyName("importante")]
    public bool Importante { get; set; }

    /// <summary>
    /// Sem descrição - recHora  
    /// </summary>
    [JsonPropertyName("hora")]
    public string Hora { get; set; } = "";

    /// <summary>
    /// Sem descrição - recData  
    /// </summary>
    [JsonPropertyName("data")]
    public string Data { get; set; } = "";

    /// <summary>
    /// Sem descrição - recVoltara  
    /// </summary>
    [JsonPropertyName("voltara")]
    public bool Voltara { get; set; }

    /// <summary>
    /// Sem descrição - recPessoal  
    /// </summary>
    [JsonPropertyName("pessoal")]
    public bool Pessoal { get; set; }

    /// <summary>
    /// Sem descrição - recRetornar  
    /// </summary>
    [JsonPropertyName("retornar")]
    public bool Retornar { get; set; }

    /// <summary>
    /// Sem descrição - recRetornoData  
    /// </summary>
    [JsonPropertyName("retornodata")]
    public string RetornoData { get; set; } = "";

    /// <summary>
    /// Sem descrição - recEmotion  
    /// </summary>
    [JsonPropertyName("emotion")]
    public int Emotion { get; set; }

    /// <summary>
    /// Sem descrição - recInternetID  
    /// </summary>
    [JsonPropertyName("internetid")]
    public int InternetID { get; set; }

    /// <summary>
    /// Sem descrição - recUploaded  
    /// </summary>
    [JsonPropertyName("uploaded")]
    public bool Uploaded { get; set; }

    /// <summary>
    /// Sem descrição - recNatureza  
    /// </summary>
    [JsonPropertyName("natureza")]
    public int Natureza { get; set; }

    /// <summary>
    /// Sem descrição - recBIU  
    /// </summary>
    [JsonPropertyName("biu")]
    public bool BIU { get; set; }

    /// <summary>
    /// Sem descrição - recAguardarRetorno  
    /// </summary>
    [JsonPropertyName("aguardarretorno")]
    public bool AguardarRetorno { get; set; }

    /// <summary>
    /// Sem descrição - recAguardarRetornoPara - tamanho máximo: 255 
    /// </summary>
    [JsonPropertyName("aguardarretornopara")]
    public string AguardarRetornoPara { get; set; } = "";

    /// <summary>
    /// Sem descrição - recAguardarRetornoOK  
    /// </summary>
    [JsonPropertyName("aguardarretornook")]
    public bool AguardarRetornoOK { get; set; }

    /// <summary>
    /// Sem descrição - recParaID  
    /// </summary>
    [JsonPropertyName("paraid")]
    public int ParaID { get; set; }

    /// <summary>
    /// Sem descrição - recNaoPublicavel  
    /// </summary>
    [JsonPropertyName("naopublicavel")]
    public bool NaoPublicavel { get; set; }

    /// <summary>
    /// Sem descrição - recIsContatoCRM  
    /// </summary>
    [JsonPropertyName("iscontatocrm")]
    public bool IsContatoCRM { get; set; }

    /// <summary>
    /// Sem descrição - recMasterID  
    /// </summary>
    [JsonPropertyName("masterid")]
    public int MasterID { get; set; }

    /// <summary>
    /// Sem descrição - recListaPara  
    /// </summary>
    [JsonPropertyName("listapara")]
    public string ListaPara { get; set; } = "";

    /// <summary>
    /// Sem descrição - recTyped  
    /// </summary>
    [JsonPropertyName("typed")]
    public bool Typed { get; set; }

    /// <summary>
    /// Sem descrição - recAssuntoRecado  
    /// </summary>
    [JsonPropertyName("assuntorecado")]
    public int AssuntoRecado { get; set; }

    /// <summary>
    /// GUId - recGUID - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("guid")]
    public string GUID { get; set; } = "";
}

[Serializable]
public partial class RecadosAll
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - recProcesso  
    /// </summary>
    [JsonPropertyName("processo")]
    public int Processo { get; set; }

    /// <summary>
    /// Sem descrição - recCliente  
    /// </summary>
    [JsonPropertyName("cliente")]
    public int Cliente { get; set; }

    /// <summary>
    /// Sem descrição - recHistorico  
    /// </summary>
    [JsonPropertyName("historico")]
    public int Historico { get; set; }

    /// <summary>
    /// Sem descrição - recContatoCRM  
    /// </summary>
    [JsonPropertyName("contatocrm")]
    public int ContatoCRM { get; set; }

    /// <summary>
    /// Sem descrição - recLigacoes  
    /// </summary>
    [JsonPropertyName("ligacoes")]
    public int Ligacoes { get; set; }

    /// <summary>
    /// Sem descrição - recAgenda  
    /// </summary>
    [JsonPropertyName("agenda")]
    public int Agenda { get; set; }

    /// <summary>
    /// Sem descrição - recClienteNome - tamanho máximo: 255 
    /// </summary>
    [JsonPropertyName("clientenome")]
    public string ClienteNome { get; set; } = "";

    /// <summary>
    /// Sem descrição - recDe - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("de")]
    public string De { get; set; } = "";

    /// <summary>
    /// Sem descrição - recPara - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("para")]
    public string Para { get; set; } = "";

    /// <summary>
    /// Sem descrição - recAssunto - tamanho máximo: 255 
    /// </summary>
    [JsonPropertyName("assunto")]
    public string Assunto { get; set; } = "";

    /// <summary>
    /// Sem descrição - recConcluido  
    /// </summary>
    [JsonPropertyName("concluido")]
    public bool Concluido { get; set; }

    /// <summary>
    /// Sem descrição - recRecado  
    /// </summary>
    [JsonPropertyName("recado")]
    public string Recado { get; set; } = "";

    /// <summary>
    /// Sem descrição - recUrgente  
    /// </summary>
    [JsonPropertyName("urgente")]
    public bool Urgente { get; set; }

    /// <summary>
    /// Sem descrição - recImportante  
    /// </summary>
    [JsonPropertyName("importante")]
    public bool Importante { get; set; }

    /// <summary>
    /// Sem descrição - recHora  
    /// </summary>
    [JsonPropertyName("hora")]
    public string Hora { get; set; } = "";

    /// <summary>
    /// Sem descrição - recData  
    /// </summary>
    [JsonPropertyName("data")]
    public string Data { get; set; } = "";

    /// <summary>
    /// Sem descrição - recVoltara  
    /// </summary>
    [JsonPropertyName("voltara")]
    public bool Voltara { get; set; }

    /// <summary>
    /// Sem descrição - recPessoal  
    /// </summary>
    [JsonPropertyName("pessoal")]
    public bool Pessoal { get; set; }

    /// <summary>
    /// Sem descrição - recRetornar  
    /// </summary>
    [JsonPropertyName("retornar")]
    public bool Retornar { get; set; }

    /// <summary>
    /// Sem descrição - recRetornoData  
    /// </summary>
    [JsonPropertyName("retornodata")]
    public string RetornoData { get; set; } = "";

    /// <summary>
    /// Sem descrição - recEmotion  
    /// </summary>
    [JsonPropertyName("emotion")]
    public int Emotion { get; set; }

    /// <summary>
    /// Sem descrição - recInternetID  
    /// </summary>
    [JsonPropertyName("internetid")]
    public int InternetID { get; set; }

    /// <summary>
    /// Sem descrição - recUploaded  
    /// </summary>
    [JsonPropertyName("uploaded")]
    public bool Uploaded { get; set; }

    /// <summary>
    /// Sem descrição - recNatureza  
    /// </summary>
    [JsonPropertyName("natureza")]
    public int Natureza { get; set; }

    /// <summary>
    /// Sem descrição - recBIU  
    /// </summary>
    [JsonPropertyName("biu")]
    public bool BIU { get; set; }

    /// <summary>
    /// Sem descrição - recAguardarRetorno  
    /// </summary>
    [JsonPropertyName("aguardarretorno")]
    public bool AguardarRetorno { get; set; }

    /// <summary>
    /// Sem descrição - recAguardarRetornoPara - tamanho máximo: 255 
    /// </summary>
    [JsonPropertyName("aguardarretornopara")]
    public string AguardarRetornoPara { get; set; } = "";

    /// <summary>
    /// Sem descrição - recAguardarRetornoOK  
    /// </summary>
    [JsonPropertyName("aguardarretornook")]
    public bool AguardarRetornoOK { get; set; }

    /// <summary>
    /// Sem descrição - recParaID  
    /// </summary>
    [JsonPropertyName("paraid")]
    public int ParaID { get; set; }

    /// <summary>
    /// Sem descrição - recNaoPublicavel  
    /// </summary>
    [JsonPropertyName("naopublicavel")]
    public bool NaoPublicavel { get; set; }

    /// <summary>
    /// Sem descrição - recIsContatoCRM  
    /// </summary>
    [JsonPropertyName("iscontatocrm")]
    public bool IsContatoCRM { get; set; }

    /// <summary>
    /// Sem descrição - recMasterID  
    /// </summary>
    [JsonPropertyName("masterid")]
    public int MasterID { get; set; }

    /// <summary>
    /// Sem descrição - recListaPara  
    /// </summary>
    [JsonPropertyName("listapara")]
    public string ListaPara { get; set; } = "";

    /// <summary>
    /// Sem descrição - recTyped  
    /// </summary>
    [JsonPropertyName("typed")]
    public bool Typed { get; set; }

    /// <summary>
    /// Sem descrição - recAssuntoRecado  
    /// </summary>
    [JsonPropertyName("assuntorecado")]
    public int AssuntoRecado { get; set; }

    /// <summary>
    /// GUId - recGUID - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("guid")]
    public string GUID { get; set; } = "";

    [JsonPropertyName("nropastaprocessos")]
    public string NroPastaProcessos { get; set; } = string.Empty;

    [JsonPropertyName("nomeclientes")]
    public string NomeClientes { get; set; } = string.Empty;

    [JsonPropertyName("nomeligacoes")]
    public string NomeLigacoes { get; set; } = string.Empty;
}