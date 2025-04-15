#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class Prepostos
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - preFuncao  
    /// </summary>
    [JsonPropertyName("funcao")]
    public int Funcao { get; set; }

    /// <summary>
    /// Sem descrição - preSetor  
    /// </summary>
    [JsonPropertyName("setor")]
    public int Setor { get; set; }

    /// <summary>
    /// Cidade - preCidade  
    /// </summary>
    [JsonPropertyName("cidade")]
    public int Cidade { get; set; }

    /// <summary>
    /// Sem descrição - preNome - tamanho máximo: 80 
    /// </summary>
    [JsonPropertyName("nome")]
    public string Nome { get; set; } = "";

    /// <summary>
    /// Sem descrição - preDtNasc  
    /// </summary>
    [JsonPropertyName("dtnasc")]
    public string DtNasc { get; set; } = "";

    /// <summary>
    /// Sem descrição - preQualificacao - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("qualificacao")]
    public string Qualificacao { get; set; } = "";

    /// <summary>
    /// Sem descrição - preSexo  
    /// </summary>
    [JsonPropertyName("sexo")]
    public bool Sexo { get; set; }

    /// <summary>
    /// Sem descrição - preIdade  
    /// </summary>
    [JsonPropertyName("idade")]
    public int Idade { get; set; }

    /// <summary>
    /// CPF - preCPF - tamanho máximo: 11 
    /// </summary>
    [JsonPropertyName("cpf")]
    public string CPF { get; set; } = "";

    /// <summary>
    /// Número da Carteira de Identidade - preRG - tamanho máximo: 30 
    /// </summary>
    [JsonPropertyName("rg")]
    public string RG { get; set; } = "";

    /// <summary>
    /// Sem descrição - prePeriodo_Ini  
    /// </summary>
    [JsonPropertyName("periodo_ini")]
    public string Periodo_Ini { get; set; } = "";

    /// <summary>
    /// Sem descrição - prePeriodo_Fim  
    /// </summary>
    [JsonPropertyName("periodo_fim")]
    public string Periodo_Fim { get; set; } = "";

    /// <summary>
    /// Sem descrição - preRegistro - tamanho máximo: 30 
    /// </summary>
    [JsonPropertyName("registro")]
    public string Registro { get; set; } = "";

    /// <summary>
    /// Sem descrição - preCTPSNumero - tamanho máximo: 15 
    /// </summary>
    [JsonPropertyName("ctpsnumero")]
    public string CTPSNumero { get; set; } = "";

    /// <summary>
    /// Nº de série da carteira de trabalho - preCTPSSerie - tamanho máximo: 10 
    /// </summary>
    [JsonPropertyName("ctpsserie")]
    public string CTPSSerie { get; set; } = "";

    /// <summary>
    /// Sem descrição - preCTPSDtEmissao  
    /// </summary>
    [JsonPropertyName("ctpsdtemissao")]
    public string CTPSDtEmissao { get; set; } = "";

    /// <summary>
    /// Nº do PIS - prePIS - tamanho máximo: 20 
    /// </summary>
    [JsonPropertyName("pis")]
    public string PIS { get; set; } = "";

    /// <summary>
    /// Sem descrição - preSalario  
    /// </summary>
    [JsonPropertyName("salario")]
    public decimal Salario { get; set; }

    /// <summary>
    /// Sem descrição - preLiberaAgenda  
    /// </summary>
    [JsonPropertyName("liberaagenda")]
    public bool LiberaAgenda { get; set; }

    /// <summary>
    /// Sem descrição - preObservacao  
    /// </summary>
    [JsonPropertyName("observacao")]
    public string Observacao { get; set; } = "";

    /// <summary>
    /// Endereço - preEndereco - tamanho máximo: 80 
    /// </summary>
    [JsonPropertyName("endereco")]
    public string Endereco { get; set; } = "";

    /// <summary>
    /// Bairro - preBairro - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("bairro")]
    public string Bairro { get; set; } = "";

    /// <summary>
    /// CEP - preCEP - tamanho máximo: 10 
    /// </summary>
    [JsonPropertyName("cep")]
    public string CEP { get; set; } = "";

    /// <summary>
    /// Fone - preFone  
    /// </summary>
    [JsonPropertyName("fone")]
    public string Fone { get; set; } = "";

    /// <summary>
    /// Fax - preFax  
    /// </summary>
    [JsonPropertyName("fax")]
    public string Fax { get; set; } = "";

    /// <summary>
    /// Sem descrição - preEMail - tamanho máximo: 255 
    /// </summary>
    [JsonPropertyName("email")]
    public string EMail { get; set; } = "";

    /// <summary>
    /// Sem descrição - prePai - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("pai")]
    public string Pai { get; set; } = "";

    /// <summary>
    /// Sem descrição - preMae - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("mae")]
    public string Mae { get; set; } = "";

    /// <summary>
    /// Classificação - preClass - tamanho máximo: 1 
    /// </summary>
    [JsonPropertyName("class")]
    public string Class { get; set; } = "";

    /// <summary>
    /// Criar etiqueta - preEtiqueta  
    /// </summary>
    [JsonPropertyName("etiqueta")]
    public bool Etiqueta { get; set; }

    /// <summary>
    /// Aniversário - preAni  
    /// </summary>
    [JsonPropertyName("ani")]
    public bool Ani { get; set; }

    /// <summary>
    /// Negritar - preBold  
    /// </summary>
    [JsonPropertyName("bold")]
    public bool Bold { get; set; }

    /// <summary>
    /// GUId - preGUID - tamanho máximo: 150 
    /// </summary>
    [JsonPropertyName("guid")]
    public string Guid { get; set; } = "";

    [JsonPropertyName("auditor")]
    public Auditor? Auditor { get; set; }
}