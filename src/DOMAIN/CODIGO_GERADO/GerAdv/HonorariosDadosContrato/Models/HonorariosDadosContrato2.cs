#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class HonorariosDadosContrato
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - hdcCliente  
    /// </summary>
    [JsonPropertyName("cliente")]
    public int Cliente { get; set; }

    /// <summary>
    /// Sem descrição - hdcProcesso  
    /// </summary>
    [JsonPropertyName("processo")]
    public int Processo { get; set; }

    /// <summary>
    /// Sem descrição - hdcFixo  
    /// </summary>
    [JsonPropertyName("fixo")]
    public bool Fixo { get; set; }

    /// <summary>
    /// Sem descrição - hdcVariavel  
    /// </summary>
    [JsonPropertyName("variavel")]
    public bool Variavel { get; set; }

    /// <summary>
    /// Sem descrição - hdcPercSucesso  
    /// </summary>
    [JsonPropertyName("percsucesso")]
    public decimal PercSucesso { get; set; }

    /// <summary>
    /// Sem descrição - hdcArquivoContrato - tamanho máximo: 2048 
    /// </summary>
    [JsonPropertyName("arquivocontrato")]
    public string ArquivoContrato { get; set; } = "";

    /// <summary>
    /// Sem descrição - hdcTextoContrato  
    /// </summary>
    [JsonPropertyName("textocontrato")]
    public string TextoContrato { get; set; } = "";

    /// <summary>
    /// Sem descrição - hdcValorFixo  
    /// </summary>
    [JsonPropertyName("valorfixo")]
    public decimal ValorFixo { get; set; }

    /// <summary>
    /// Sem descrição - hdcObservacao - tamanho máximo: 2048 
    /// </summary>
    [JsonPropertyName("observacao")]
    public string Observacao { get; set; } = "";

    /// <summary>
    /// Sem descrição - hdcDataContrato  
    /// </summary>
    [JsonPropertyName("datacontrato")]
    public string DataContrato { get; set; } = "";

    /// <summary>
    /// GUId - hdcGUID - tamanho máximo: 150 
    /// </summary>
    [JsonPropertyName("guid")]
    public string GUID { get; set; } = "";
}

[Serializable]
public partial class HonorariosDadosContratoAll
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - hdcCliente  
    /// </summary>
    [JsonPropertyName("cliente")]
    public int Cliente { get; set; }

    /// <summary>
    /// Sem descrição - hdcProcesso  
    /// </summary>
    [JsonPropertyName("processo")]
    public int Processo { get; set; }

    /// <summary>
    /// Sem descrição - hdcFixo  
    /// </summary>
    [JsonPropertyName("fixo")]
    public bool Fixo { get; set; }

    /// <summary>
    /// Sem descrição - hdcVariavel  
    /// </summary>
    [JsonPropertyName("variavel")]
    public bool Variavel { get; set; }

    /// <summary>
    /// Sem descrição - hdcPercSucesso  
    /// </summary>
    [JsonPropertyName("percsucesso")]
    public decimal PercSucesso { get; set; }

    /// <summary>
    /// Sem descrição - hdcArquivoContrato - tamanho máximo: 2048 
    /// </summary>
    [JsonPropertyName("arquivocontrato")]
    public string ArquivoContrato { get; set; } = "";

    /// <summary>
    /// Sem descrição - hdcTextoContrato  
    /// </summary>
    [JsonPropertyName("textocontrato")]
    public string TextoContrato { get; set; } = "";

    /// <summary>
    /// Sem descrição - hdcValorFixo  
    /// </summary>
    [JsonPropertyName("valorfixo")]
    public decimal ValorFixo { get; set; }

    /// <summary>
    /// Sem descrição - hdcObservacao - tamanho máximo: 2048 
    /// </summary>
    [JsonPropertyName("observacao")]
    public string Observacao { get; set; } = "";

    /// <summary>
    /// Sem descrição - hdcDataContrato  
    /// </summary>
    [JsonPropertyName("datacontrato")]
    public string DataContrato { get; set; } = "";

    /// <summary>
    /// GUId - hdcGUID - tamanho máximo: 150 
    /// </summary>
    [JsonPropertyName("guid")]
    public string GUID { get; set; } = "";

    [JsonPropertyName("nomeclientes")]
    public string NomeClientes { get; set; } = string.Empty;

    [JsonPropertyName("nropastaprocessos")]
    public string NroPastaProcessos { get; set; } = string.Empty;
}