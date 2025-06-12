#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models.Response;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class ColaboradoresResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - colCargo  
    /// </summary>
    [JsonPropertyName("cargo")]
    public int Cargo { get; set; }

    /// <summary>
    /// Sem descrição - colCliente  
    /// </summary>
    [JsonPropertyName("cliente")]
    public int Cliente { get; set; }

    /// <summary>
    /// Sem descrição - colCidade  
    /// </summary>
    [JsonPropertyName("cidade")]
    public int Cidade { get; set; }

    /// <summary>
    /// Sem descrição - colSexo  
    /// </summary>
    [JsonPropertyName("sexo")]
    public bool Sexo { get; set; }

    /// <summary>
    /// Sem descrição - colNome - tamanho máximo: 80 
    /// </summary>
    [JsonPropertyName("nome")]
    public string Nome { get; set; } = "";

    /// <summary>
    /// CPF - colCPF - tamanho máximo: 11 
    /// </summary>
    [JsonPropertyName("cpf")]
    public string CPF { get; set; } = "";

    /// <summary>
    /// Número da Carteira de Identidade - colRG - tamanho máximo: 30 
    /// </summary>
    [JsonPropertyName("rg")]
    public string RG { get; set; } = "";

    /// <summary>
    /// Sem descrição - colDtNasc  
    /// </summary>
    [JsonPropertyName("dtnasc")]
    public string DtNasc { get; set; } = "";

    /// <summary>
    /// Sem descrição - colIdade  
    /// </summary>
    [JsonPropertyName("idade")]
    public int Idade { get; set; }

    /// <summary>
    /// Endereço - colEndereco - tamanho máximo: 80 
    /// </summary>
    [JsonPropertyName("endereco")]
    public string Endereco { get; set; } = "";

    /// <summary>
    /// Bairro - colBairro - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("bairro")]
    public string Bairro { get; set; } = "";

    /// <summary>
    /// CEP - colCEP - tamanho máximo: 10 
    /// </summary>
    [JsonPropertyName("cep")]
    public string CEP { get; set; } = "";

    /// <summary>
    /// Fone - colFone  
    /// </summary>
    [JsonPropertyName("fone")]
    public string Fone { get; set; } = "";

    /// <summary>
    /// Sem descrição - colObservacao  
    /// </summary>
    [JsonPropertyName("observacao")]
    public string Observacao { get; set; } = "";

    /// <summary>
    /// Sem descrição - colEMail - tamanho máximo: 150 
    /// </summary>
    [JsonPropertyName("email")]
    public string EMail { get; set; } = "";

    /// <summary>
    /// CNH - colCNH - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("cnh")]
    public string CNH { get; set; } = "";

    /// <summary>
    /// Classificação - colClass - tamanho máximo: 1 
    /// </summary>
    [JsonPropertyName("class")]
    public string Class { get; set; } = "";

    /// <summary>
    /// Criar etiqueta - colEtiqueta  
    /// </summary>
    [JsonPropertyName("etiqueta")]
    public bool Etiqueta { get; set; }

    /// <summary>
    /// Aniversário - colAni  
    /// </summary>
    [JsonPropertyName("ani")]
    public bool Ani { get; set; }

    /// <summary>
    /// Negritar - colBold  
    /// </summary>
    [JsonPropertyName("bold")]
    public bool Bold { get; set; }
}

[Serializable]
public partial class ColaboradoresResponseAll
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - colCargo  
    /// </summary>
    [JsonPropertyName("cargo")]
    public int Cargo { get; set; }

    /// <summary>
    /// Sem descrição - colCliente  
    /// </summary>
    [JsonPropertyName("cliente")]
    public int Cliente { get; set; }

    /// <summary>
    /// Sem descrição - colCidade  
    /// </summary>
    [JsonPropertyName("cidade")]
    public int Cidade { get; set; }

    /// <summary>
    /// Sem descrição - colSexo  
    /// </summary>
    [JsonPropertyName("sexo")]
    public bool Sexo { get; set; }

    /// <summary>
    /// Sem descrição - colNome - tamanho máximo: 80 
    /// </summary>
    [JsonPropertyName("nome")]
    public string Nome { get; set; } = "";

    /// <summary>
    /// CPF - colCPF - tamanho máximo: 11 
    /// </summary>
    [JsonPropertyName("cpf")]
    public string CPF { get; set; } = "";

    /// <summary>
    /// Número da Carteira de Identidade - colRG - tamanho máximo: 30 
    /// </summary>
    [JsonPropertyName("rg")]
    public string RG { get; set; } = "";

    /// <summary>
    /// Sem descrição - colDtNasc  
    /// </summary>
    [JsonPropertyName("dtnasc")]
    public string DtNasc { get; set; } = "";

    /// <summary>
    /// Sem descrição - colIdade  
    /// </summary>
    [JsonPropertyName("idade")]
    public int Idade { get; set; }

    /// <summary>
    /// Endereço - colEndereco - tamanho máximo: 80 
    /// </summary>
    [JsonPropertyName("endereco")]
    public string Endereco { get; set; } = "";

    /// <summary>
    /// Bairro - colBairro - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("bairro")]
    public string Bairro { get; set; } = "";

    /// <summary>
    /// CEP - colCEP - tamanho máximo: 10 
    /// </summary>
    [JsonPropertyName("cep")]
    public string CEP { get; set; } = "";

    /// <summary>
    /// Fone - colFone  
    /// </summary>
    [JsonPropertyName("fone")]
    public string Fone { get; set; } = "";

    /// <summary>
    /// Sem descrição - colObservacao  
    /// </summary>
    [JsonPropertyName("observacao")]
    public string Observacao { get; set; } = "";

    /// <summary>
    /// Sem descrição - colEMail - tamanho máximo: 150 
    /// </summary>
    [JsonPropertyName("email")]
    public string EMail { get; set; } = "";

    /// <summary>
    /// CNH - colCNH - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("cnh")]
    public string CNH { get; set; } = "";

    /// <summary>
    /// Classificação - colClass - tamanho máximo: 1 
    /// </summary>
    [JsonPropertyName("class")]
    public string Class { get; set; } = "";

    /// <summary>
    /// Criar etiqueta - colEtiqueta  
    /// </summary>
    [JsonPropertyName("etiqueta")]
    public bool Etiqueta { get; set; }

    /// <summary>
    /// Aniversário - colAni  
    /// </summary>
    [JsonPropertyName("ani")]
    public bool Ani { get; set; }

    /// <summary>
    /// Negritar - colBold  
    /// </summary>
    [JsonPropertyName("bold")]
    public bool Bold { get; set; }

    [JsonPropertyName("nomecargos")]
    public string NomeCargos { get; set; } = string.Empty;

    [JsonPropertyName("nomeclientes")]
    public string NomeClientes { get; set; } = string.Empty;

    [JsonPropertyName("nomecidade")]
    public string NomeCidade { get; set; } = string.Empty;
}