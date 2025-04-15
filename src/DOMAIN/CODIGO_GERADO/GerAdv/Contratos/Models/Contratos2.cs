#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class Contratos
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - cttProcesso  
    /// </summary>
    [JsonPropertyName("processo")]
    public int Processo { get; set; }

    /// <summary>
    /// Sem descrição - cttCliente  
    /// </summary>
    [JsonPropertyName("cliente")]
    public int Cliente { get; set; }

    /// <summary>
    /// Sem descrição - cttAdvogado  
    /// </summary>
    [JsonPropertyName("advogado")]
    public int Advogado { get; set; }

    /// <summary>
    /// Sem descrição - cttDia  
    /// </summary>
    [JsonPropertyName("dia")]
    public int Dia { get; set; }

    /// <summary>
    /// Sem descrição - cttValor  
    /// </summary>
    [JsonPropertyName("valor")]
    public decimal Valor { get; set; }

    /// <summary>
    /// Sem descrição - cttDataInicio  
    /// </summary>
    [JsonPropertyName("datainicio")]
    public string DataInicio { get; set; } = "";

    /// <summary>
    /// Sem descrição - cttDataTermino  
    /// </summary>
    [JsonPropertyName("datatermino")]
    public string DataTermino { get; set; } = "";

    /// <summary>
    /// Sem descrição - cttOcultarRelatorio  
    /// </summary>
    [JsonPropertyName("ocultarrelatorio")]
    public bool OcultarRelatorio { get; set; }

    /// <summary>
    /// Sem descrição - cttPercEscritorio  
    /// </summary>
    [JsonPropertyName("percescritorio")]
    public decimal PercEscritorio { get; set; }

    /// <summary>
    /// Sem descrição - cttValorConsultoria  
    /// </summary>
    [JsonPropertyName("valorconsultoria")]
    public decimal ValorConsultoria { get; set; }

    /// <summary>
    /// Sem descrição - cttTipoCobranca  
    /// </summary>
    [JsonPropertyName("tipocobranca")]
    public int TipoCobranca { get; set; }

    /// <summary>
    /// Sem descrição - cttProtestar - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("protestar")]
    public string Protestar { get; set; } = "";

    /// <summary>
    /// Sem descrição - cttJuros - tamanho máximo: 5 
    /// </summary>
    [JsonPropertyName("juros")]
    public string Juros { get; set; } = "";

    /// <summary>
    /// Sem descrição - cttValorRealizavel  
    /// </summary>
    [JsonPropertyName("valorrealizavel")]
    public decimal ValorRealizavel { get; set; }

    /// <summary>
    /// Sem descrição - cttDOCUMENTO - tamanho máximo: 15 
    /// </summary>
    [JsonPropertyName("documento")]
    public string DOCUMENTO { get; set; } = "";

    /// <summary>
    /// Sem descrição - cttEMail1 - tamanho máximo: 300 
    /// </summary>
    [JsonPropertyName("email1")]
    public string EMail1 { get; set; } = "";

    /// <summary>
    /// Sem descrição - cttEMail2 - tamanho máximo: 300 
    /// </summary>
    [JsonPropertyName("email2")]
    public string EMail2 { get; set; } = "";

    /// <summary>
    /// Sem descrição - cttEMail3 - tamanho máximo: 300 
    /// </summary>
    [JsonPropertyName("email3")]
    public string EMail3 { get; set; } = "";

    /// <summary>
    /// Sem descrição - cttPessoa1 - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("pessoa1")]
    public string Pessoa1 { get; set; } = "";

    /// <summary>
    /// Sem descrição - cttPessoa2 - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("pessoa2")]
    public string Pessoa2 { get; set; } = "";

    /// <summary>
    /// Sem descrição - cttPessoa3 - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("pessoa3")]
    public string Pessoa3 { get; set; } = "";

    /// <summary>
    /// Sem descrição - cttOBS  
    /// </summary>
    [JsonPropertyName("obs")]
    public string OBS { get; set; } = "";

    /// <summary>
    /// Sem descrição - cttClienteContrato  
    /// </summary>
    [JsonPropertyName("clientecontrato")]
    public int ClienteContrato { get; set; }

    /// <summary>
    /// Sem descrição - cttIdExtrangeiro  
    /// </summary>
    [JsonPropertyName("idextrangeiro")]
    public int IdExtrangeiro { get; set; }

    /// <summary>
    /// Sem descrição - cttChaveContrato - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("chavecontrato")]
    public string ChaveContrato { get; set; } = "";

    /// <summary>
    /// Sem descrição - cttAvulso  
    /// </summary>
    [JsonPropertyName("avulso")]
    public bool Avulso { get; set; }

    /// <summary>
    /// Sem descrição - cttSuspenso  
    /// </summary>
    [JsonPropertyName("suspenso")]
    public bool Suspenso { get; set; }

    /// <summary>
    /// Sem descrição - cttMulta - tamanho máximo: 10 
    /// </summary>
    [JsonPropertyName("multa")]
    public string Multa { get; set; } = "";

    /// <summary>
    /// Negritar - cttBold  
    /// </summary>
    [JsonPropertyName("bold")]
    public bool Bold { get; set; }

    /// <summary>
    /// GUId - cttGUID - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("guid")]
    public string Guid { get; set; } = "";

    [JsonPropertyName("auditor")]
    public Auditor? Auditor { get; set; }
}