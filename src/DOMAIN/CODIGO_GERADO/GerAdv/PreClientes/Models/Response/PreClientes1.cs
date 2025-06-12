#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models.Response;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class PreClientesResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - cliIDRep  
    /// </summary>
    [JsonPropertyName("idrep")]
    public int IDRep { get; set; }

    /// <summary>
    /// Sem descrição - cliCidade  
    /// </summary>
    [JsonPropertyName("cidade")]
    public int Cidade { get; set; }

    /// <summary>
    /// Sem descrição - cliInativo  
    /// </summary>
    [JsonPropertyName("inativo")]
    public bool Inativo { get; set; }

    /// <summary>
    /// Sem descrição - cliQuemIndicou - tamanho máximo: 80 
    /// </summary>
    [JsonPropertyName("quemindicou")]
    public string QuemIndicou { get; set; } = "";

    /// <summary>
    /// Sem descrição - cliNome - tamanho máximo: 80 
    /// </summary>
    [JsonPropertyName("nome")]
    public string Nome { get; set; } = "";

    /// <summary>
    /// Sem descrição - cliAdv  
    /// </summary>
    [JsonPropertyName("adv")]
    public int Adv { get; set; }

    /// <summary>
    /// Sem descrição - cliJuridica  
    /// </summary>
    [JsonPropertyName("juridica")]
    public bool Juridica { get; set; }

    /// <summary>
    /// Sem descrição - cliNomeFantasia - tamanho máximo: 80 
    /// </summary>
    [JsonPropertyName("nomefantasia")]
    public string NomeFantasia { get; set; } = "";

    /// <summary>
    /// Classificação - cliClass - tamanho máximo: 1 
    /// </summary>
    [JsonPropertyName("class")]
    public string Class { get; set; } = "";

    /// <summary>
    /// Sem descrição - cliTipo  
    /// </summary>
    [JsonPropertyName("tipo")]
    public bool Tipo { get; set; }

    /// <summary>
    /// Sem descrição - cliDtNasc  
    /// </summary>
    [JsonPropertyName("dtnasc")]
    public string DtNasc { get; set; } = "";

    /// <summary>
    /// Inscrição Estadual - cliInscEst - tamanho máximo: 15 
    /// </summary>
    [JsonPropertyName("inscest")]
    public string InscEst { get; set; } = "";

    /// <summary>
    /// Sem descrição - cliQualificacao - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("qualificacao")]
    public string Qualificacao { get; set; } = "";

    /// <summary>
    /// Sem descrição - cliSexo  
    /// </summary>
    [JsonPropertyName("sexo")]
    public bool Sexo { get; set; }

    /// <summary>
    /// Sem descrição - cliIdade  
    /// </summary>
    [JsonPropertyName("idade")]
    public int Idade { get; set; }

    /// <summary>
    /// CNPJ - cliCNPJ - tamanho máximo: 14 
    /// </summary>
    [JsonPropertyName("cnpj")]
    public string CNPJ { get; set; } = "";

    /// <summary>
    /// CPF - cliCPF - tamanho máximo: 11 
    /// </summary>
    [JsonPropertyName("cpf")]
    public string CPF { get; set; } = "";

    /// <summary>
    /// Número da Carteira de Identidade - cliRG - tamanho máximo: 30 
    /// </summary>
    [JsonPropertyName("rg")]
    public string RG { get; set; } = "";

    /// <summary>
    /// Sem descrição - cliTipoCaptacao  
    /// </summary>
    [JsonPropertyName("tipocaptacao")]
    public bool TipoCaptacao { get; set; }

    /// <summary>
    /// Sem descrição - cliObservacao  
    /// </summary>
    [JsonPropertyName("observacao")]
    public string Observacao { get; set; } = "";

    /// <summary>
    /// Endereço - cliEndereco - tamanho máximo: 80 
    /// </summary>
    [JsonPropertyName("endereco")]
    public string Endereco { get; set; } = "";

    /// <summary>
    /// Bairro - cliBairro - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("bairro")]
    public string Bairro { get; set; } = "";

    /// <summary>
    /// CEP - cliCEP - tamanho máximo: 10 
    /// </summary>
    [JsonPropertyName("cep")]
    public string CEP { get; set; } = "";

    /// <summary>
    /// Fax - cliFax  
    /// </summary>
    [JsonPropertyName("fax")]
    public string Fax { get; set; } = "";

    /// <summary>
    /// Fone - cliFone  
    /// </summary>
    [JsonPropertyName("fone")]
    public string Fone { get; set; } = "";

    /// <summary>
    /// Sem descrição - cliData  
    /// </summary>
    [JsonPropertyName("data")]
    public string Data { get; set; } = "";

    /// <summary>
    /// Sem descrição - cliHomePage - tamanho máximo: 60 
    /// </summary>
    [JsonPropertyName("homepage")]
    public string HomePage { get; set; } = "";

    /// <summary>
    /// Sem descrição - cliEMail - tamanho máximo: 60 
    /// </summary>
    [JsonPropertyName("email")]
    public string EMail { get; set; } = "";

    /// <summary>
    /// Sem descrição - cliAssistido - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("assistido")]
    public string Assistido { get; set; } = "";

    /// <summary>
    /// Sem descrição - cliAssRG - tamanho máximo: 30 
    /// </summary>
    [JsonPropertyName("assrg")]
    public string AssRG { get; set; } = "";

    /// <summary>
    /// Sem descrição - cliAssCPF - tamanho máximo: 12 
    /// </summary>
    [JsonPropertyName("asscpf")]
    public string AssCPF { get; set; } = "";

    /// <summary>
    /// Sem descrição - cliAssEndereco - tamanho máximo: 70 
    /// </summary>
    [JsonPropertyName("assendereco")]
    public string AssEndereco { get; set; } = "";

    /// <summary>
    /// CNH - cliCNH - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("cnh")]
    public string CNH { get; set; } = "";

    /// <summary>
    /// Criar etiqueta - cliEtiqueta  
    /// </summary>
    [JsonPropertyName("etiqueta")]
    public bool Etiqueta { get; set; }

    /// <summary>
    /// Aniversário - cliAni  
    /// </summary>
    [JsonPropertyName("ani")]
    public bool Ani { get; set; }

    /// <summary>
    /// Negritar - cliBold  
    /// </summary>
    [JsonPropertyName("bold")]
    public bool Bold { get; set; }
}

[Serializable]
public partial class PreClientesResponseAll
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - cliIDRep  
    /// </summary>
    [JsonPropertyName("idrep")]
    public int IDRep { get; set; }

    /// <summary>
    /// Sem descrição - cliCidade  
    /// </summary>
    [JsonPropertyName("cidade")]
    public int Cidade { get; set; }

    /// <summary>
    /// Sem descrição - cliInativo  
    /// </summary>
    [JsonPropertyName("inativo")]
    public bool Inativo { get; set; }

    /// <summary>
    /// Sem descrição - cliQuemIndicou - tamanho máximo: 80 
    /// </summary>
    [JsonPropertyName("quemindicou")]
    public string QuemIndicou { get; set; } = "";

    /// <summary>
    /// Sem descrição - cliNome - tamanho máximo: 80 
    /// </summary>
    [JsonPropertyName("nome")]
    public string Nome { get; set; } = "";

    /// <summary>
    /// Sem descrição - cliAdv  
    /// </summary>
    [JsonPropertyName("adv")]
    public int Adv { get; set; }

    /// <summary>
    /// Sem descrição - cliJuridica  
    /// </summary>
    [JsonPropertyName("juridica")]
    public bool Juridica { get; set; }

    /// <summary>
    /// Sem descrição - cliNomeFantasia - tamanho máximo: 80 
    /// </summary>
    [JsonPropertyName("nomefantasia")]
    public string NomeFantasia { get; set; } = "";

    /// <summary>
    /// Classificação - cliClass - tamanho máximo: 1 
    /// </summary>
    [JsonPropertyName("class")]
    public string Class { get; set; } = "";

    /// <summary>
    /// Sem descrição - cliTipo  
    /// </summary>
    [JsonPropertyName("tipo")]
    public bool Tipo { get; set; }

    /// <summary>
    /// Sem descrição - cliDtNasc  
    /// </summary>
    [JsonPropertyName("dtnasc")]
    public string DtNasc { get; set; } = "";

    /// <summary>
    /// Inscrição Estadual - cliInscEst - tamanho máximo: 15 
    /// </summary>
    [JsonPropertyName("inscest")]
    public string InscEst { get; set; } = "";

    /// <summary>
    /// Sem descrição - cliQualificacao - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("qualificacao")]
    public string Qualificacao { get; set; } = "";

    /// <summary>
    /// Sem descrição - cliSexo  
    /// </summary>
    [JsonPropertyName("sexo")]
    public bool Sexo { get; set; }

    /// <summary>
    /// Sem descrição - cliIdade  
    /// </summary>
    [JsonPropertyName("idade")]
    public int Idade { get; set; }

    /// <summary>
    /// CNPJ - cliCNPJ - tamanho máximo: 14 
    /// </summary>
    [JsonPropertyName("cnpj")]
    public string CNPJ { get; set; } = "";

    /// <summary>
    /// CPF - cliCPF - tamanho máximo: 11 
    /// </summary>
    [JsonPropertyName("cpf")]
    public string CPF { get; set; } = "";

    /// <summary>
    /// Número da Carteira de Identidade - cliRG - tamanho máximo: 30 
    /// </summary>
    [JsonPropertyName("rg")]
    public string RG { get; set; } = "";

    /// <summary>
    /// Sem descrição - cliTipoCaptacao  
    /// </summary>
    [JsonPropertyName("tipocaptacao")]
    public bool TipoCaptacao { get; set; }

    /// <summary>
    /// Sem descrição - cliObservacao  
    /// </summary>
    [JsonPropertyName("observacao")]
    public string Observacao { get; set; } = "";

    /// <summary>
    /// Endereço - cliEndereco - tamanho máximo: 80 
    /// </summary>
    [JsonPropertyName("endereco")]
    public string Endereco { get; set; } = "";

    /// <summary>
    /// Bairro - cliBairro - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("bairro")]
    public string Bairro { get; set; } = "";

    /// <summary>
    /// CEP - cliCEP - tamanho máximo: 10 
    /// </summary>
    [JsonPropertyName("cep")]
    public string CEP { get; set; } = "";

    /// <summary>
    /// Fax - cliFax  
    /// </summary>
    [JsonPropertyName("fax")]
    public string Fax { get; set; } = "";

    /// <summary>
    /// Fone - cliFone  
    /// </summary>
    [JsonPropertyName("fone")]
    public string Fone { get; set; } = "";

    /// <summary>
    /// Sem descrição - cliData  
    /// </summary>
    [JsonPropertyName("data")]
    public string Data { get; set; } = "";

    /// <summary>
    /// Sem descrição - cliHomePage - tamanho máximo: 60 
    /// </summary>
    [JsonPropertyName("homepage")]
    public string HomePage { get; set; } = "";

    /// <summary>
    /// Sem descrição - cliEMail - tamanho máximo: 60 
    /// </summary>
    [JsonPropertyName("email")]
    public string EMail { get; set; } = "";

    /// <summary>
    /// Sem descrição - cliAssistido - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("assistido")]
    public string Assistido { get; set; } = "";

    /// <summary>
    /// Sem descrição - cliAssRG - tamanho máximo: 30 
    /// </summary>
    [JsonPropertyName("assrg")]
    public string AssRG { get; set; } = "";

    /// <summary>
    /// Sem descrição - cliAssCPF - tamanho máximo: 12 
    /// </summary>
    [JsonPropertyName("asscpf")]
    public string AssCPF { get; set; } = "";

    /// <summary>
    /// Sem descrição - cliAssEndereco - tamanho máximo: 70 
    /// </summary>
    [JsonPropertyName("assendereco")]
    public string AssEndereco { get; set; } = "";

    /// <summary>
    /// CNH - cliCNH - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("cnh")]
    public string CNH { get; set; } = "";

    /// <summary>
    /// Criar etiqueta - cliEtiqueta  
    /// </summary>
    [JsonPropertyName("etiqueta")]
    public bool Etiqueta { get; set; }

    /// <summary>
    /// Aniversário - cliAni  
    /// </summary>
    [JsonPropertyName("ani")]
    public bool Ani { get; set; }

    /// <summary>
    /// Negritar - cliBold  
    /// </summary>
    [JsonPropertyName("bold")]
    public bool Bold { get; set; }

    [JsonPropertyName("nomeclientes")]
    public string NomeClientes { get; set; } = string.Empty;

    [JsonPropertyName("nomecidade")]
    public string NomeCidade { get; set; } = string.Empty;
}