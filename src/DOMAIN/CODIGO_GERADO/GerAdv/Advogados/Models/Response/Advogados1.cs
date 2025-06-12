#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models.Response;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class AdvogadosResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - advCargo  
    /// </summary>
    [JsonPropertyName("cargo")]
    public int Cargo { get; set; }

    /// <summary>
    /// Sem descrição - advEscritorio  
    /// </summary>
    [JsonPropertyName("escritorio")]
    public int Escritorio { get; set; }

    /// <summary>
    /// Sem descrição - advCidade  
    /// </summary>
    [JsonPropertyName("cidade")]
    public int Cidade { get; set; }

    /// <summary>
    /// Sem descrição - advEMailPro - tamanho máximo: 255 
    /// </summary>
    [JsonPropertyName("emailpro")]
    public string EMailPro { get; set; } = "";

    /// <summary>
    /// CPF - advCPF - tamanho máximo: 11 
    /// </summary>
    [JsonPropertyName("cpf")]
    public string CPF { get; set; } = "";

    /// <summary>
    /// Sem descrição - advNome - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("nome")]
    public string Nome { get; set; } = "";

    /// <summary>
    /// Número da Carteira de Identidade - advRG - tamanho máximo: 30 
    /// </summary>
    [JsonPropertyName("rg")]
    public string RG { get; set; } = "";

    /// <summary>
    /// Sem descrição - advCasa  
    /// </summary>
    [JsonPropertyName("casa")]
    public bool Casa { get; set; }

    /// <summary>
    /// Sem descrição - advNomeMae - tamanho máximo: 80 
    /// </summary>
    [JsonPropertyName("nomemae")]
    public string NomeMae { get; set; } = "";

    /// <summary>
    /// Sem descrição - advEstagiario  
    /// </summary>
    [JsonPropertyName("estagiario")]
    public bool Estagiario { get; set; }

    /// <summary>
    /// Sem descrição - advOAB - tamanho máximo: 12 
    /// </summary>
    [JsonPropertyName("oab")]
    public string OAB { get; set; } = "";

    /// <summary>
    /// Sem descrição - advNomeCompleto - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("nomecompleto")]
    public string NomeCompleto { get; set; } = "";

    /// <summary>
    /// Endereço - advEndereco - tamanho máximo: 80 
    /// </summary>
    [JsonPropertyName("endereco")]
    public string Endereco { get; set; } = "";

    /// <summary>
    /// CEP - advCEP - tamanho máximo: 10 
    /// </summary>
    [JsonPropertyName("cep")]
    public string CEP { get; set; } = "";

    /// <summary>
    /// Sem descrição - advSexo  
    /// </summary>
    [JsonPropertyName("sexo")]
    public bool Sexo { get; set; }

    /// <summary>
    /// Bairro - advBairro - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("bairro")]
    public string Bairro { get; set; } = "";

    /// <summary>
    /// Nº de série da carteira de trabalho - advCTPSSerie - tamanho máximo: 10 
    /// </summary>
    [JsonPropertyName("ctpsserie")]
    public string CTPSSerie { get; set; } = "";

    /// <summary>
    /// Nº carteira de trabalho - advCTPS - tamanho máximo: 15 
    /// </summary>
    [JsonPropertyName("ctps")]
    public string CTPS { get; set; } = "";

    /// <summary>
    /// Fone - advFone  
    /// </summary>
    [JsonPropertyName("fone")]
    public string Fone { get; set; } = "";

    /// <summary>
    /// Fax - advFax  
    /// </summary>
    [JsonPropertyName("fax")]
    public string Fax { get; set; } = "";

    /// <summary>
    /// Sem descrição - advComissao  
    /// </summary>
    [JsonPropertyName("comissao")]
    public int Comissao { get; set; }

    /// <summary>
    /// Sem descrição - advDtInicio  
    /// </summary>
    [JsonPropertyName("dtinicio")]
    public string DtInicio { get; set; } = "";

    /// <summary>
    /// Sem descrição - advDtFim  
    /// </summary>
    [JsonPropertyName("dtfim")]
    public string DtFim { get; set; } = "";

    /// <summary>
    /// Sem descrição - advDtNasc  
    /// </summary>
    [JsonPropertyName("dtnasc")]
    public string DtNasc { get; set; } = "";

    /// <summary>
    /// Sem descrição - advSalario  
    /// </summary>
    [JsonPropertyName("salario")]
    public decimal Salario { get; set; }

    /// <summary>
    /// Sem descrição - advSecretaria - tamanho máximo: 20 
    /// </summary>
    [JsonPropertyName("secretaria")]
    public string Secretaria { get; set; } = "";

    /// <summary>
    /// Sem descrição - advTextoProcuracao - tamanho máximo: 200 
    /// </summary>
    [JsonPropertyName("textoprocuracao")]
    public string TextoProcuracao { get; set; } = "";

    /// <summary>
    /// Sem descrição - advEMail - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("email")]
    public string EMail { get; set; } = "";

    /// <summary>
    /// Sem descrição - advEspecializacao  
    /// </summary>
    [JsonPropertyName("especializacao")]
    public string Especializacao { get; set; } = "";

    /// <summary>
    /// Sem descrição - advPasta - tamanho máximo: 200 
    /// </summary>
    [JsonPropertyName("pasta")]
    public string Pasta { get; set; } = "";

    /// <summary>
    /// Sem descrição - advObservacao  
    /// </summary>
    [JsonPropertyName("observacao")]
    public string Observacao { get; set; } = "";

    /// <summary>
    /// Sem descrição - advContaBancaria  
    /// </summary>
    [JsonPropertyName("contabancaria")]
    public string ContaBancaria { get; set; } = "";

    /// <summary>
    /// Sem descrição - advParcTop  
    /// </summary>
    [JsonPropertyName("parctop")]
    public bool ParcTop { get; set; }

    /// <summary>
    /// Classificação - advClass - tamanho máximo: 1 
    /// </summary>
    [JsonPropertyName("class")]
    public string Class { get; set; } = "";

    /// <summary>
    /// Sem descrição - advTop  
    /// </summary>
    [JsonPropertyName("top")]
    public bool Top { get; set; }

    /// <summary>
    /// Criar etiqueta - advEtiqueta  
    /// </summary>
    [JsonPropertyName("etiqueta")]
    public bool Etiqueta { get; set; }

    /// <summary>
    /// Aniversário - advAni  
    /// </summary>
    [JsonPropertyName("ani")]
    public bool Ani { get; set; }

    /// <summary>
    /// Negritar - advBold  
    /// </summary>
    [JsonPropertyName("bold")]
    public bool Bold { get; set; }

    /// <summary>
    /// GUId - advGUID - tamanho máximo: 150 
    /// </summary>
    [JsonPropertyName("guid")]
    public string GUID { get; set; } = "";
}

[Serializable]
public partial class AdvogadosResponseAll
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - advCargo  
    /// </summary>
    [JsonPropertyName("cargo")]
    public int Cargo { get; set; }

    /// <summary>
    /// Sem descrição - advEscritorio  
    /// </summary>
    [JsonPropertyName("escritorio")]
    public int Escritorio { get; set; }

    /// <summary>
    /// Sem descrição - advCidade  
    /// </summary>
    [JsonPropertyName("cidade")]
    public int Cidade { get; set; }

    /// <summary>
    /// Sem descrição - advEMailPro - tamanho máximo: 255 
    /// </summary>
    [JsonPropertyName("emailpro")]
    public string EMailPro { get; set; } = "";

    /// <summary>
    /// CPF - advCPF - tamanho máximo: 11 
    /// </summary>
    [JsonPropertyName("cpf")]
    public string CPF { get; set; } = "";

    /// <summary>
    /// Sem descrição - advNome - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("nome")]
    public string Nome { get; set; } = "";

    /// <summary>
    /// Número da Carteira de Identidade - advRG - tamanho máximo: 30 
    /// </summary>
    [JsonPropertyName("rg")]
    public string RG { get; set; } = "";

    /// <summary>
    /// Sem descrição - advCasa  
    /// </summary>
    [JsonPropertyName("casa")]
    public bool Casa { get; set; }

    /// <summary>
    /// Sem descrição - advNomeMae - tamanho máximo: 80 
    /// </summary>
    [JsonPropertyName("nomemae")]
    public string NomeMae { get; set; } = "";

    /// <summary>
    /// Sem descrição - advEstagiario  
    /// </summary>
    [JsonPropertyName("estagiario")]
    public bool Estagiario { get; set; }

    /// <summary>
    /// Sem descrição - advOAB - tamanho máximo: 12 
    /// </summary>
    [JsonPropertyName("oab")]
    public string OAB { get; set; } = "";

    /// <summary>
    /// Sem descrição - advNomeCompleto - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("nomecompleto")]
    public string NomeCompleto { get; set; } = "";

    /// <summary>
    /// Endereço - advEndereco - tamanho máximo: 80 
    /// </summary>
    [JsonPropertyName("endereco")]
    public string Endereco { get; set; } = "";

    /// <summary>
    /// CEP - advCEP - tamanho máximo: 10 
    /// </summary>
    [JsonPropertyName("cep")]
    public string CEP { get; set; } = "";

    /// <summary>
    /// Sem descrição - advSexo  
    /// </summary>
    [JsonPropertyName("sexo")]
    public bool Sexo { get; set; }

    /// <summary>
    /// Bairro - advBairro - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("bairro")]
    public string Bairro { get; set; } = "";

    /// <summary>
    /// Nº de série da carteira de trabalho - advCTPSSerie - tamanho máximo: 10 
    /// </summary>
    [JsonPropertyName("ctpsserie")]
    public string CTPSSerie { get; set; } = "";

    /// <summary>
    /// Nº carteira de trabalho - advCTPS - tamanho máximo: 15 
    /// </summary>
    [JsonPropertyName("ctps")]
    public string CTPS { get; set; } = "";

    /// <summary>
    /// Fone - advFone  
    /// </summary>
    [JsonPropertyName("fone")]
    public string Fone { get; set; } = "";

    /// <summary>
    /// Fax - advFax  
    /// </summary>
    [JsonPropertyName("fax")]
    public string Fax { get; set; } = "";

    /// <summary>
    /// Sem descrição - advComissao  
    /// </summary>
    [JsonPropertyName("comissao")]
    public int Comissao { get; set; }

    /// <summary>
    /// Sem descrição - advDtInicio  
    /// </summary>
    [JsonPropertyName("dtinicio")]
    public string DtInicio { get; set; } = "";

    /// <summary>
    /// Sem descrição - advDtFim  
    /// </summary>
    [JsonPropertyName("dtfim")]
    public string DtFim { get; set; } = "";

    /// <summary>
    /// Sem descrição - advDtNasc  
    /// </summary>
    [JsonPropertyName("dtnasc")]
    public string DtNasc { get; set; } = "";

    /// <summary>
    /// Sem descrição - advSalario  
    /// </summary>
    [JsonPropertyName("salario")]
    public decimal Salario { get; set; }

    /// <summary>
    /// Sem descrição - advSecretaria - tamanho máximo: 20 
    /// </summary>
    [JsonPropertyName("secretaria")]
    public string Secretaria { get; set; } = "";

    /// <summary>
    /// Sem descrição - advTextoProcuracao - tamanho máximo: 200 
    /// </summary>
    [JsonPropertyName("textoprocuracao")]
    public string TextoProcuracao { get; set; } = "";

    /// <summary>
    /// Sem descrição - advEMail - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("email")]
    public string EMail { get; set; } = "";

    /// <summary>
    /// Sem descrição - advEspecializacao  
    /// </summary>
    [JsonPropertyName("especializacao")]
    public string Especializacao { get; set; } = "";

    /// <summary>
    /// Sem descrição - advPasta - tamanho máximo: 200 
    /// </summary>
    [JsonPropertyName("pasta")]
    public string Pasta { get; set; } = "";

    /// <summary>
    /// Sem descrição - advObservacao  
    /// </summary>
    [JsonPropertyName("observacao")]
    public string Observacao { get; set; } = "";

    /// <summary>
    /// Sem descrição - advContaBancaria  
    /// </summary>
    [JsonPropertyName("contabancaria")]
    public string ContaBancaria { get; set; } = "";

    /// <summary>
    /// Sem descrição - advParcTop  
    /// </summary>
    [JsonPropertyName("parctop")]
    public bool ParcTop { get; set; }

    /// <summary>
    /// Classificação - advClass - tamanho máximo: 1 
    /// </summary>
    [JsonPropertyName("class")]
    public string Class { get; set; } = "";

    /// <summary>
    /// Sem descrição - advTop  
    /// </summary>
    [JsonPropertyName("top")]
    public bool Top { get; set; }

    /// <summary>
    /// Criar etiqueta - advEtiqueta  
    /// </summary>
    [JsonPropertyName("etiqueta")]
    public bool Etiqueta { get; set; }

    /// <summary>
    /// Aniversário - advAni  
    /// </summary>
    [JsonPropertyName("ani")]
    public bool Ani { get; set; }

    /// <summary>
    /// Negritar - advBold  
    /// </summary>
    [JsonPropertyName("bold")]
    public bool Bold { get; set; }

    /// <summary>
    /// GUId - advGUID - tamanho máximo: 150 
    /// </summary>
    [JsonPropertyName("guid")]
    public string GUID { get; set; } = "";

    [JsonPropertyName("nomecargos")]
    public string NomeCargos { get; set; } = string.Empty;

    [JsonPropertyName("nomeescritorios")]
    public string NomeEscritorios { get; set; } = string.Empty;

    [JsonPropertyName("nomecidade")]
    public string NomeCidade { get; set; } = string.Empty;
}