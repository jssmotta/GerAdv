#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class Fornecedores
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - forCidade  
    /// </summary>
    [JsonPropertyName("cidade")]
    public int Cidade { get; set; }

    /// <summary>
    /// Sem descrição - forGrupo  
    /// </summary>
    [JsonPropertyName("grupo")]
    public int Grupo { get; set; }

    /// <summary>
    /// Sem descrição - forNome - tamanho máximo: 80 
    /// </summary>
    [JsonPropertyName("nome")]
    public string Nome { get; set; } = "";

    /// <summary>
    /// Sem descrição - forSubGrupo  
    /// </summary>
    [JsonPropertyName("subgrupo")]
    public int SubGrupo { get; set; }

    /// <summary>
    /// Sem descrição - forTipo  
    /// </summary>
    [JsonPropertyName("tipo")]
    public bool Tipo { get; set; }

    /// <summary>
    /// Sem descrição - forSexo  
    /// </summary>
    [JsonPropertyName("sexo")]
    public bool Sexo { get; set; }

    /// <summary>
    /// CNPJ - forCNPJ - tamanho máximo: 14 
    /// </summary>
    [JsonPropertyName("cnpj")]
    public string CNPJ { get; set; } = "";

    /// <summary>
    /// Inscrição Estadual - forInscEst - tamanho máximo: 15 
    /// </summary>
    [JsonPropertyName("inscest")]
    public string InscEst { get; set; } = "";

    /// <summary>
    /// CPF - forCPF - tamanho máximo: 11 
    /// </summary>
    [JsonPropertyName("cpf")]
    public string CPF { get; set; } = "";

    /// <summary>
    /// Número da Carteira de Identidade - forRG - tamanho máximo: 30 
    /// </summary>
    [JsonPropertyName("rg")]
    public string RG { get; set; } = "";

    /// <summary>
    /// Endereço - forEndereco - tamanho máximo: 80 
    /// </summary>
    [JsonPropertyName("endereco")]
    public string Endereco { get; set; } = "";

    /// <summary>
    /// Bairro - forBairro - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("bairro")]
    public string Bairro { get; set; } = "";

    /// <summary>
    /// CEP - forCEP - tamanho máximo: 10 
    /// </summary>
    [JsonPropertyName("cep")]
    public string CEP { get; set; } = "";

    /// <summary>
    /// Fone - forFone  
    /// </summary>
    [JsonPropertyName("fone")]
    public string Fone { get; set; } = "";

    /// <summary>
    /// Fax - forFax  
    /// </summary>
    [JsonPropertyName("fax")]
    public string Fax { get; set; } = "";

    /// <summary>
    /// Sem descrição - forEmail - tamanho máximo: 150 
    /// </summary>
    [JsonPropertyName("email")]
    public string Email { get; set; } = "";

    /// <summary>
    /// Sem descrição - forSite - tamanho máximo: 150 
    /// </summary>
    [JsonPropertyName("site")]
    public string Site { get; set; } = "";

    /// <summary>
    /// Sem descrição - forObs  
    /// </summary>
    [JsonPropertyName("obs")]
    public string Obs { get; set; } = "";

    /// <summary>
    /// Sem descrição - forProdutos  
    /// </summary>
    [JsonPropertyName("produtos")]
    public string Produtos { get; set; } = "";

    /// <summary>
    /// Sem descrição - forContatos  
    /// </summary>
    [JsonPropertyName("contatos")]
    public string Contatos { get; set; } = "";

    /// <summary>
    /// Criar etiqueta - forEtiqueta  
    /// </summary>
    [JsonPropertyName("etiqueta")]
    public bool Etiqueta { get; set; }

    /// <summary>
    /// Negritar - forBold  
    /// </summary>
    [JsonPropertyName("bold")]
    public bool Bold { get; set; }

    /// <summary>
    /// GUId - forGUID - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("guid")]
    public string GUID { get; set; } = "";
}

[Serializable]
public partial class FornecedoresAll
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - forCidade  
    /// </summary>
    [JsonPropertyName("cidade")]
    public int Cidade { get; set; }

    /// <summary>
    /// Sem descrição - forGrupo  
    /// </summary>
    [JsonPropertyName("grupo")]
    public int Grupo { get; set; }

    /// <summary>
    /// Sem descrição - forNome - tamanho máximo: 80 
    /// </summary>
    [JsonPropertyName("nome")]
    public string Nome { get; set; } = "";

    /// <summary>
    /// Sem descrição - forSubGrupo  
    /// </summary>
    [JsonPropertyName("subgrupo")]
    public int SubGrupo { get; set; }

    /// <summary>
    /// Sem descrição - forTipo  
    /// </summary>
    [JsonPropertyName("tipo")]
    public bool Tipo { get; set; }

    /// <summary>
    /// Sem descrição - forSexo  
    /// </summary>
    [JsonPropertyName("sexo")]
    public bool Sexo { get; set; }

    /// <summary>
    /// CNPJ - forCNPJ - tamanho máximo: 14 
    /// </summary>
    [JsonPropertyName("cnpj")]
    public string CNPJ { get; set; } = "";

    /// <summary>
    /// Inscrição Estadual - forInscEst - tamanho máximo: 15 
    /// </summary>
    [JsonPropertyName("inscest")]
    public string InscEst { get; set; } = "";

    /// <summary>
    /// CPF - forCPF - tamanho máximo: 11 
    /// </summary>
    [JsonPropertyName("cpf")]
    public string CPF { get; set; } = "";

    /// <summary>
    /// Número da Carteira de Identidade - forRG - tamanho máximo: 30 
    /// </summary>
    [JsonPropertyName("rg")]
    public string RG { get; set; } = "";

    /// <summary>
    /// Endereço - forEndereco - tamanho máximo: 80 
    /// </summary>
    [JsonPropertyName("endereco")]
    public string Endereco { get; set; } = "";

    /// <summary>
    /// Bairro - forBairro - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("bairro")]
    public string Bairro { get; set; } = "";

    /// <summary>
    /// CEP - forCEP - tamanho máximo: 10 
    /// </summary>
    [JsonPropertyName("cep")]
    public string CEP { get; set; } = "";

    /// <summary>
    /// Fone - forFone  
    /// </summary>
    [JsonPropertyName("fone")]
    public string Fone { get; set; } = "";

    /// <summary>
    /// Fax - forFax  
    /// </summary>
    [JsonPropertyName("fax")]
    public string Fax { get; set; } = "";

    /// <summary>
    /// Sem descrição - forEmail - tamanho máximo: 150 
    /// </summary>
    [JsonPropertyName("email")]
    public string Email { get; set; } = "";

    /// <summary>
    /// Sem descrição - forSite - tamanho máximo: 150 
    /// </summary>
    [JsonPropertyName("site")]
    public string Site { get; set; } = "";

    /// <summary>
    /// Sem descrição - forObs  
    /// </summary>
    [JsonPropertyName("obs")]
    public string Obs { get; set; } = "";

    /// <summary>
    /// Sem descrição - forProdutos  
    /// </summary>
    [JsonPropertyName("produtos")]
    public string Produtos { get; set; } = "";

    /// <summary>
    /// Sem descrição - forContatos  
    /// </summary>
    [JsonPropertyName("contatos")]
    public string Contatos { get; set; } = "";

    /// <summary>
    /// Criar etiqueta - forEtiqueta  
    /// </summary>
    [JsonPropertyName("etiqueta")]
    public bool Etiqueta { get; set; }

    /// <summary>
    /// Negritar - forBold  
    /// </summary>
    [JsonPropertyName("bold")]
    public bool Bold { get; set; }

    /// <summary>
    /// GUId - forGUID - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("guid")]
    public string GUID { get; set; } = "";

    [JsonPropertyName("nomecidade")]
    public string NomeCidade { get; set; } = string.Empty;
}