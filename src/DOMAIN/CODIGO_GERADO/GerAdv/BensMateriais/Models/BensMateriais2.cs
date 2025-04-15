#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class BensMateriais
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - bmtBensClassificacao  
    /// </summary>
    [JsonPropertyName("bensclassificacao")]
    public int BensClassificacao { get; set; }

    /// <summary>
    /// Sem descrição - bmtFornecedor  
    /// </summary>
    [JsonPropertyName("fornecedor")]
    public int Fornecedor { get; set; }

    /// <summary>
    /// Cidade - bmtCidade  
    /// </summary>
    [JsonPropertyName("cidade")]
    public int Cidade { get; set; }

    /// <summary>
    /// Sem descrição - bmtNome - tamanho máximo: 80 
    /// </summary>
    [JsonPropertyName("nome")]
    public string Nome { get; set; } = "";

    /// <summary>
    /// Sem descrição - bmtDataCompra  
    /// </summary>
    [JsonPropertyName("datacompra")]
    public string DataCompra { get; set; } = "";

    /// <summary>
    /// Sem descrição - bmtDataFimDaGarantia  
    /// </summary>
    [JsonPropertyName("datafimdagarantia")]
    public string DataFimDaGarantia { get; set; } = "";

    /// <summary>
    /// Sem descrição - bmtNFNRO - tamanho máximo: 255 
    /// </summary>
    [JsonPropertyName("nfnro")]
    public string NFNRO { get; set; } = "";

    /// <summary>
    /// Sem descrição - bmtValorBem  
    /// </summary>
    [JsonPropertyName("valorbem")]
    public decimal ValorBem { get; set; }

    /// <summary>
    /// Sem descrição - bmtNroSerieProduto - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("nroserieproduto")]
    public string NroSerieProduto { get; set; } = "";

    /// <summary>
    /// Sem descrição - bmtComprador - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("comprador")]
    public string Comprador { get; set; } = "";

    /// <summary>
    /// Sem descrição - bmtGarantiaLoja  
    /// </summary>
    [JsonPropertyName("garantialoja")]
    public bool GarantiaLoja { get; set; }

    /// <summary>
    /// Sem descrição - bmtDataTerminoDaGarantiaDaLoja  
    /// </summary>
    [JsonPropertyName("dataterminodagarantiadaloja")]
    public string DataTerminoDaGarantiaDaLoja { get; set; } = "";

    /// <summary>
    /// Sem descrição - bmtObservacoes  
    /// </summary>
    [JsonPropertyName("observacoes")]
    public string Observacoes { get; set; } = "";

    /// <summary>
    /// Sem descrição - bmtNomeVendedor - tamanho máximo: 255 
    /// </summary>
    [JsonPropertyName("nomevendedor")]
    public string NomeVendedor { get; set; } = "";

    /// <summary>
    /// Negritar - bmtBold  
    /// </summary>
    [JsonPropertyName("bold")]
    public bool Bold { get; set; }

    /// <summary>
    /// GUId - bmtGUID - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("guid")]
    public string Guid { get; set; } = "";

    [JsonPropertyName("auditor")]
    public Auditor? Auditor { get; set; }
}