#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class Funcionarios
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - funCargo  
    /// </summary>
    [JsonPropertyName("cargo")]
    public int Cargo { get; set; }

    /// <summary>
    /// Sem descrição - funFuncao  
    /// </summary>
    [JsonPropertyName("funcao")]
    public int Funcao { get; set; }

    /// <summary>
    /// Sem descrição - funCidade  
    /// </summary>
    [JsonPropertyName("cidade")]
    public int Cidade { get; set; }

    /// <summary>
    /// Sem descrição - funEMailPro - tamanho máximo: 255 
    /// </summary>
    [JsonPropertyName("emailpro")]
    public string EMailPro { get; set; } = "";

    /// <summary>
    /// Sem descrição - funNome - tamanho máximo: 60 
    /// </summary>
    [JsonPropertyName("nome")]
    public string Nome { get; set; } = "";

    /// <summary>
    /// Sem descrição - funSexo  
    /// </summary>
    [JsonPropertyName("sexo")]
    public bool Sexo { get; set; }

    /// <summary>
    /// Sem descrição - funRegistro - tamanho máximo: 20 
    /// </summary>
    [JsonPropertyName("registro")]
    public string Registro { get; set; } = "";

    /// <summary>
    /// CPF - funCPF - tamanho máximo: 11 
    /// </summary>
    [JsonPropertyName("cpf")]
    public string CPF { get; set; } = "";

    /// <summary>
    /// Número da Carteira de Identidade - funRG - tamanho máximo: 30 
    /// </summary>
    [JsonPropertyName("rg")]
    public string RG { get; set; } = "";

    /// <summary>
    /// Sem descrição - funTipo  
    /// </summary>
    [JsonPropertyName("tipo")]
    public bool Tipo { get; set; }

    /// <summary>
    /// Sem descrição - funObservacao  
    /// </summary>
    [JsonPropertyName("observacao")]
    public string Observacao { get; set; } = "";

    /// <summary>
    /// Endereço - funEndereco - tamanho máximo: 80 
    /// </summary>
    [JsonPropertyName("endereco")]
    public string Endereco { get; set; } = "";

    /// <summary>
    /// Bairro - funBairro - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("bairro")]
    public string Bairro { get; set; } = "";

    /// <summary>
    /// CEP - funCEP - tamanho máximo: 10 
    /// </summary>
    [JsonPropertyName("cep")]
    public string CEP { get; set; } = "";

    /// <summary>
    /// Sem descrição - funContato  
    /// </summary>
    [JsonPropertyName("contato")]
    public string Contato { get; set; } = "";

    /// <summary>
    /// Fax - funFax  
    /// </summary>
    [JsonPropertyName("fax")]
    public string Fax { get; set; } = "";

    /// <summary>
    /// Fone - funFone  
    /// </summary>
    [JsonPropertyName("fone")]
    public string Fone { get; set; } = "";

    /// <summary>
    /// Sem descrição - funEMail - tamanho máximo: 60 
    /// </summary>
    [JsonPropertyName("email")]
    public string EMail { get; set; } = "";

    /// <summary>
    /// Sem descrição - funPeriodo_Ini  
    /// </summary>
    [JsonPropertyName("periodo_ini")]
    public string Periodo_Ini { get; set; } = "";

    /// <summary>
    /// Sem descrição - funPeriodo_Fim  
    /// </summary>
    [JsonPropertyName("periodo_fim")]
    public string Periodo_Fim { get; set; } = "";

    /// <summary>
    /// Sem descrição - funCTPSNumero - tamanho máximo: 15 
    /// </summary>
    [JsonPropertyName("ctpsnumero")]
    public string CTPSNumero { get; set; } = "";

    /// <summary>
    /// Nº de série da carteira de trabalho - funCTPSSerie - tamanho máximo: 10 
    /// </summary>
    [JsonPropertyName("ctpsserie")]
    public string CTPSSerie { get; set; } = "";

    /// <summary>
    /// Nº do PIS - funPIS - tamanho máximo: 20 
    /// </summary>
    [JsonPropertyName("pis")]
    public string PIS { get; set; } = "";

    /// <summary>
    /// Sem descrição - funSalario  
    /// </summary>
    [JsonPropertyName("salario")]
    public decimal Salario { get; set; }

    /// <summary>
    /// Sem descrição - funCTPSDtEmissao  
    /// </summary>
    [JsonPropertyName("ctpsdtemissao")]
    public string CTPSDtEmissao { get; set; } = "";

    /// <summary>
    /// Sem descrição - funDtNasc  
    /// </summary>
    [JsonPropertyName("dtnasc")]
    public string DtNasc { get; set; } = "";

    /// <summary>
    /// Sem descrição - funData  
    /// </summary>
    [JsonPropertyName("data")]
    public string Data { get; set; } = "";

    /// <summary>
    /// Sem descrição - funLiberaAgenda  
    /// </summary>
    [JsonPropertyName("liberaagenda")]
    public bool LiberaAgenda { get; set; }

    /// <summary>
    /// Sem descrição - funPasta - tamanho máximo: 200 
    /// </summary>
    [JsonPropertyName("pasta")]
    public string Pasta { get; set; } = "";

    /// <summary>
    /// Classificação - funClass - tamanho máximo: 1 
    /// </summary>
    [JsonPropertyName("class")]
    public string Class { get; set; } = "";

    /// <summary>
    /// Criar etiqueta - funEtiqueta  
    /// </summary>
    [JsonPropertyName("etiqueta")]
    public bool Etiqueta { get; set; }

    /// <summary>
    /// Aniversário - funAni  
    /// </summary>
    [JsonPropertyName("ani")]
    public bool Ani { get; set; }

    /// <summary>
    /// Negritar - funBold  
    /// </summary>
    [JsonPropertyName("bold")]
    public bool Bold { get; set; }

    /// <summary>
    /// GUId - funGUID - tamanho máximo: 150 
    /// </summary>
    [JsonPropertyName("guid")]
    public string GUID { get; set; } = "";
}

[Serializable]
public partial class FuncionariosAll
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - funCargo  
    /// </summary>
    [JsonPropertyName("cargo")]
    public int Cargo { get; set; }

    /// <summary>
    /// Sem descrição - funFuncao  
    /// </summary>
    [JsonPropertyName("funcao")]
    public int Funcao { get; set; }

    /// <summary>
    /// Sem descrição - funCidade  
    /// </summary>
    [JsonPropertyName("cidade")]
    public int Cidade { get; set; }

    /// <summary>
    /// Sem descrição - funEMailPro - tamanho máximo: 255 
    /// </summary>
    [JsonPropertyName("emailpro")]
    public string EMailPro { get; set; } = "";

    /// <summary>
    /// Sem descrição - funNome - tamanho máximo: 60 
    /// </summary>
    [JsonPropertyName("nome")]
    public string Nome { get; set; } = "";

    /// <summary>
    /// Sem descrição - funSexo  
    /// </summary>
    [JsonPropertyName("sexo")]
    public bool Sexo { get; set; }

    /// <summary>
    /// Sem descrição - funRegistro - tamanho máximo: 20 
    /// </summary>
    [JsonPropertyName("registro")]
    public string Registro { get; set; } = "";

    /// <summary>
    /// CPF - funCPF - tamanho máximo: 11 
    /// </summary>
    [JsonPropertyName("cpf")]
    public string CPF { get; set; } = "";

    /// <summary>
    /// Número da Carteira de Identidade - funRG - tamanho máximo: 30 
    /// </summary>
    [JsonPropertyName("rg")]
    public string RG { get; set; } = "";

    /// <summary>
    /// Sem descrição - funTipo  
    /// </summary>
    [JsonPropertyName("tipo")]
    public bool Tipo { get; set; }

    /// <summary>
    /// Sem descrição - funObservacao  
    /// </summary>
    [JsonPropertyName("observacao")]
    public string Observacao { get; set; } = "";

    /// <summary>
    /// Endereço - funEndereco - tamanho máximo: 80 
    /// </summary>
    [JsonPropertyName("endereco")]
    public string Endereco { get; set; } = "";

    /// <summary>
    /// Bairro - funBairro - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("bairro")]
    public string Bairro { get; set; } = "";

    /// <summary>
    /// CEP - funCEP - tamanho máximo: 10 
    /// </summary>
    [JsonPropertyName("cep")]
    public string CEP { get; set; } = "";

    /// <summary>
    /// Sem descrição - funContato  
    /// </summary>
    [JsonPropertyName("contato")]
    public string Contato { get; set; } = "";

    /// <summary>
    /// Fax - funFax  
    /// </summary>
    [JsonPropertyName("fax")]
    public string Fax { get; set; } = "";

    /// <summary>
    /// Fone - funFone  
    /// </summary>
    [JsonPropertyName("fone")]
    public string Fone { get; set; } = "";

    /// <summary>
    /// Sem descrição - funEMail - tamanho máximo: 60 
    /// </summary>
    [JsonPropertyName("email")]
    public string EMail { get; set; } = "";

    /// <summary>
    /// Sem descrição - funPeriodo_Ini  
    /// </summary>
    [JsonPropertyName("periodo_ini")]
    public string Periodo_Ini { get; set; } = "";

    /// <summary>
    /// Sem descrição - funPeriodo_Fim  
    /// </summary>
    [JsonPropertyName("periodo_fim")]
    public string Periodo_Fim { get; set; } = "";

    /// <summary>
    /// Sem descrição - funCTPSNumero - tamanho máximo: 15 
    /// </summary>
    [JsonPropertyName("ctpsnumero")]
    public string CTPSNumero { get; set; } = "";

    /// <summary>
    /// Nº de série da carteira de trabalho - funCTPSSerie - tamanho máximo: 10 
    /// </summary>
    [JsonPropertyName("ctpsserie")]
    public string CTPSSerie { get; set; } = "";

    /// <summary>
    /// Nº do PIS - funPIS - tamanho máximo: 20 
    /// </summary>
    [JsonPropertyName("pis")]
    public string PIS { get; set; } = "";

    /// <summary>
    /// Sem descrição - funSalario  
    /// </summary>
    [JsonPropertyName("salario")]
    public decimal Salario { get; set; }

    /// <summary>
    /// Sem descrição - funCTPSDtEmissao  
    /// </summary>
    [JsonPropertyName("ctpsdtemissao")]
    public string CTPSDtEmissao { get; set; } = "";

    /// <summary>
    /// Sem descrição - funDtNasc  
    /// </summary>
    [JsonPropertyName("dtnasc")]
    public string DtNasc { get; set; } = "";

    /// <summary>
    /// Sem descrição - funData  
    /// </summary>
    [JsonPropertyName("data")]
    public string Data { get; set; } = "";

    /// <summary>
    /// Sem descrição - funLiberaAgenda  
    /// </summary>
    [JsonPropertyName("liberaagenda")]
    public bool LiberaAgenda { get; set; }

    /// <summary>
    /// Sem descrição - funPasta - tamanho máximo: 200 
    /// </summary>
    [JsonPropertyName("pasta")]
    public string Pasta { get; set; } = "";

    /// <summary>
    /// Classificação - funClass - tamanho máximo: 1 
    /// </summary>
    [JsonPropertyName("class")]
    public string Class { get; set; } = "";

    /// <summary>
    /// Criar etiqueta - funEtiqueta  
    /// </summary>
    [JsonPropertyName("etiqueta")]
    public bool Etiqueta { get; set; }

    /// <summary>
    /// Aniversário - funAni  
    /// </summary>
    [JsonPropertyName("ani")]
    public bool Ani { get; set; }

    /// <summary>
    /// Negritar - funBold  
    /// </summary>
    [JsonPropertyName("bold")]
    public bool Bold { get; set; }

    /// <summary>
    /// GUId - funGUID - tamanho máximo: 150 
    /// </summary>
    [JsonPropertyName("guid")]
    public string GUID { get; set; } = "";

    [JsonPropertyName("nomecargos")]
    public string NomeCargos { get; set; } = string.Empty;

    [JsonPropertyName("nomecidade")]
    public string NomeCidade { get; set; } = string.Empty;
}