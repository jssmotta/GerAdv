#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models.Response;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class OponentesResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Cidade - opoCidade  
    /// </summary>
    [JsonPropertyName("cidade")]
    public int Cidade { get; set; }

    /// <summary>
    /// Sem descrição - opoEMPFuncao  
    /// </summary>
    [JsonPropertyName("empfuncao")]
    public int EMPFuncao { get; set; }

    /// <summary>
    /// Sem descrição - opoCTPSNumero - tamanho máximo: 15 
    /// </summary>
    [JsonPropertyName("ctpsnumero")]
    public string CTPSNumero { get; set; } = "";

    /// <summary>
    /// Sem descrição - opoSite - tamanho máximo: 150 
    /// </summary>
    [JsonPropertyName("site")]
    public string Site { get; set; } = "";

    /// <summary>
    /// Nº de série da carteira de trabalho - opoCTPSSerie - tamanho máximo: 10 
    /// </summary>
    [JsonPropertyName("ctpsserie")]
    public string CTPSSerie { get; set; } = "";

    /// <summary>
    /// Sem descrição - opoNome - tamanho máximo: 80 
    /// </summary>
    [JsonPropertyName("nome")]
    public string Nome { get; set; } = "";

    /// <summary>
    /// Sem descrição - opoAdv  
    /// </summary>
    [JsonPropertyName("adv")]
    public int Adv { get; set; }

    /// <summary>
    /// Sem descrição - opoEMPCliente  
    /// </summary>
    [JsonPropertyName("empcliente")]
    public int EMPCliente { get; set; }

    /// <summary>
    /// Sem descrição - opoIDRep  
    /// </summary>
    [JsonPropertyName("idrep")]
    public int IDRep { get; set; }

    /// <summary>
    /// Nº do PIS - opoPIS - tamanho máximo: 20 
    /// </summary>
    [JsonPropertyName("pis")]
    public string PIS { get; set; } = "";

    /// <summary>
    /// Sem descrição - opoContato  
    /// </summary>
    [JsonPropertyName("contato")]
    public string Contato { get; set; } = "";

    /// <summary>
    /// CNPJ - opoCNPJ - tamanho máximo: 14 
    /// </summary>
    [JsonPropertyName("cnpj")]
    public string CNPJ { get; set; } = "";

    /// <summary>
    /// Número da Carteira de Identidade - opoRG - tamanho máximo: 12 
    /// </summary>
    [JsonPropertyName("rg")]
    public string RG { get; set; } = "";

    /// <summary>
    /// Sem descrição - opoJuridica  
    /// </summary>
    [JsonPropertyName("juridica")]
    public bool Juridica { get; set; }

    /// <summary>
    /// Sem descrição - opoTipo  
    /// </summary>
    [JsonPropertyName("tipo")]
    public bool Tipo { get; set; }

    /// <summary>
    /// Sem descrição - opoSexo  
    /// </summary>
    [JsonPropertyName("sexo")]
    public bool Sexo { get; set; }

    /// <summary>
    /// CPF - opoCPF - tamanho máximo: 11 
    /// </summary>
    [JsonPropertyName("cpf")]
    public string CPF { get; set; } = "";

    /// <summary>
    /// Endereço - opoEndereco - tamanho máximo: 80 
    /// </summary>
    [JsonPropertyName("endereco")]
    public string Endereco { get; set; } = "";

    /// <summary>
    /// Fone - opoFone  
    /// </summary>
    [JsonPropertyName("fone")]
    public string Fone { get; set; } = "";

    /// <summary>
    /// Fax - opoFax  
    /// </summary>
    [JsonPropertyName("fax")]
    public string Fax { get; set; } = "";

    /// <summary>
    /// Bairro - opoBairro - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("bairro")]
    public string Bairro { get; set; } = "";

    /// <summary>
    /// CEP - opoCEP - tamanho máximo: 10 
    /// </summary>
    [JsonPropertyName("cep")]
    public string CEP { get; set; } = "";

    /// <summary>
    /// Inscrição Estadual - opoInscEst - tamanho máximo: 15 
    /// </summary>
    [JsonPropertyName("inscest")]
    public string InscEst { get; set; } = "";

    /// <summary>
    /// Sem descrição - opoObservacao  
    /// </summary>
    [JsonPropertyName("observacao")]
    public string Observacao { get; set; } = "";

    /// <summary>
    /// Sem descrição - opoEMail - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("email")]
    public string EMail { get; set; } = "";

    /// <summary>
    /// Classificação - opoClass - tamanho máximo: 1 
    /// </summary>
    [JsonPropertyName("class")]
    public string Class { get; set; } = "";

    /// <summary>
    /// Sem descrição - opoTop  
    /// </summary>
    [JsonPropertyName("top")]
    public bool Top { get; set; }

    /// <summary>
    /// Criar etiqueta - opoEtiqueta  
    /// </summary>
    [JsonPropertyName("etiqueta")]
    public bool Etiqueta { get; set; }

    /// <summary>
    /// Negritar - opoBold  
    /// </summary>
    [JsonPropertyName("bold")]
    public bool Bold { get; set; }

    /// <summary>
    /// GUId - opoGUID - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("guid")]
    public string Guid { get; set; } = "";

    [JsonPropertyName("auditor")]
    public Auditor? Auditor { get; set; }
}