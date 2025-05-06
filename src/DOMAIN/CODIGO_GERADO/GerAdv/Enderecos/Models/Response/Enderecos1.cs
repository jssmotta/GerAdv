#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models.Response;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class EnderecosResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Cidade - endCidade  
    /// </summary>
    [JsonPropertyName("cidade")]
    public int Cidade { get; set; }

    /// <summary>
    /// Sem descrição - endTopIndex  
    /// </summary>
    [JsonPropertyName("topindex")]
    public bool TopIndex { get; set; }

    /// <summary>
    /// Sem descrição - endDescricao - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("descricao")]
    public string Descricao { get; set; } = "";

    /// <summary>
    /// Sem descrição - endContato  
    /// </summary>
    [JsonPropertyName("contato")]
    public string Contato { get; set; } = "";

    /// <summary>
    /// Sem descrição - endDtNasc  
    /// </summary>
    [JsonPropertyName("dtnasc")]
    public string DtNasc { get; set; } = "";

    /// <summary>
    /// Endereço - endEndereco - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("endereco")]
    public string Endereco { get; set; } = "";

    /// <summary>
    /// Bairro - endBairro - tamanho máximo: 30 
    /// </summary>
    [JsonPropertyName("bairro")]
    public string Bairro { get; set; } = "";

    /// <summary>
    /// Sem descrição - endPrivativo  
    /// </summary>
    [JsonPropertyName("privativo")]
    public bool Privativo { get; set; }

    /// <summary>
    /// Sem descrição - endAddContato  
    /// </summary>
    [JsonPropertyName("addcontato")]
    public bool AddContato { get; set; }

    /// <summary>
    /// CEP - endCEP - tamanho máximo: 10 
    /// </summary>
    [JsonPropertyName("cep")]
    public string CEP { get; set; } = "";

    /// <summary>
    /// Sem descrição - endOAB - tamanho máximo: 20 
    /// </summary>
    [JsonPropertyName("oab")]
    public string OAB { get; set; } = "";

    /// <summary>
    /// Sem descrição - endOBS  
    /// </summary>
    [JsonPropertyName("obs")]
    public string OBS { get; set; } = "";

    /// <summary>
    /// Fone - endFone  
    /// </summary>
    [JsonPropertyName("fone")]
    public string Fone { get; set; } = "";

    /// <summary>
    /// Fax - endFax  
    /// </summary>
    [JsonPropertyName("fax")]
    public string Fax { get; set; } = "";

    /// <summary>
    /// Sem descrição - endTratamento - tamanho máximo: 20 
    /// </summary>
    [JsonPropertyName("tratamento")]
    public string Tratamento { get; set; } = "";

    /// <summary>
    /// Sem descrição - endSite - tamanho máximo: 200 
    /// </summary>
    [JsonPropertyName("site")]
    public string Site { get; set; } = "";

    /// <summary>
    /// Sem descrição - endEMail - tamanho máximo: 255 
    /// </summary>
    [JsonPropertyName("email")]
    public string EMail { get; set; } = "";

    /// <summary>
    /// Sem descrição - endQuem  
    /// </summary>
    [JsonPropertyName("quem")]
    public int Quem { get; set; }

    /// <summary>
    /// Sem descrição - endQuemIndicou - tamanho máximo: 150 
    /// </summary>
    [JsonPropertyName("quemindicou")]
    public string QuemIndicou { get; set; } = "";

    /// <summary>
    /// Sem descrição - endReportECBOnly  
    /// </summary>
    [JsonPropertyName("reportecbonly")]
    public bool ReportECBOnly { get; set; }

    /// <summary>
    /// Criar etiqueta - endEtiqueta  
    /// </summary>
    [JsonPropertyName("etiqueta")]
    public bool Etiqueta { get; set; }

    /// <summary>
    /// Aniversário - endAni  
    /// </summary>
    [JsonPropertyName("ani")]
    public bool Ani { get; set; }

    /// <summary>
    /// Negritar - endBold  
    /// </summary>
    [JsonPropertyName("bold")]
    public bool Bold { get; set; }

    /// <summary>
    /// GUId - endGUID - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("guid")]
    public string GUID { get; set; } = "";

    [JsonPropertyName("auditor")]
    public Auditor? Auditor { get; set; }
}