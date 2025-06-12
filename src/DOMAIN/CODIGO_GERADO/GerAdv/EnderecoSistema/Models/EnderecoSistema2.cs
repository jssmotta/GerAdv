#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class EnderecoSistema
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - estTipoEnderecoSistema  
    /// </summary>
    [JsonPropertyName("tipoenderecosistema")]
    public int TipoEnderecoSistema { get; set; }

    /// <summary>
    /// Sem descrição - estProcesso  
    /// </summary>
    [JsonPropertyName("processo")]
    public int Processo { get; set; }

    /// <summary>
    /// Sem descrição - estCidade  
    /// </summary>
    [JsonPropertyName("cidade")]
    public int Cidade { get; set; }

    /// <summary>
    /// Sem descrição - estCadastro  
    /// </summary>
    [JsonPropertyName("cadastro")]
    public int Cadastro { get; set; }

    /// <summary>
    /// Sem descrição - estCadastroExCod  
    /// </summary>
    [JsonPropertyName("cadastroexcod")]
    public int CadastroExCod { get; set; }

    /// <summary>
    /// Sem descrição - estMotivo - tamanho máximo: 200 
    /// </summary>
    [JsonPropertyName("motivo")]
    public string Motivo { get; set; } = "";

    /// <summary>
    /// Sem descrição - estContatoNoLocal - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("contatonolocal")]
    public string ContatoNoLocal { get; set; } = "";

    /// <summary>
    /// Endereço - estEndereco - tamanho máximo: 150 
    /// </summary>
    [JsonPropertyName("endereco")]
    public string Endereco { get; set; } = "";

    /// <summary>
    /// Bairro - estBairro - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("bairro")]
    public string Bairro { get; set; } = "";

    /// <summary>
    /// CEP - estCEP - tamanho máximo: 10 
    /// </summary>
    [JsonPropertyName("cep")]
    public string CEP { get; set; } = "";

    /// <summary>
    /// Fone - estFone  
    /// </summary>
    [JsonPropertyName("fone")]
    public string Fone { get; set; } = "";

    /// <summary>
    /// Fax - estFax  
    /// </summary>
    [JsonPropertyName("fax")]
    public string Fax { get; set; } = "";

    /// <summary>
    /// Sem descrição - estObservacao  
    /// </summary>
    [JsonPropertyName("observacao")]
    public string Observacao { get; set; } = "";

    /// <summary>
    /// GUId - estGUID - tamanho máximo: 150 
    /// </summary>
    [JsonPropertyName("guid")]
    public string GUID { get; set; } = "";
}

[Serializable]
public partial class EnderecoSistemaAll
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - estTipoEnderecoSistema  
    /// </summary>
    [JsonPropertyName("tipoenderecosistema")]
    public int TipoEnderecoSistema { get; set; }

    /// <summary>
    /// Sem descrição - estProcesso  
    /// </summary>
    [JsonPropertyName("processo")]
    public int Processo { get; set; }

    /// <summary>
    /// Sem descrição - estCidade  
    /// </summary>
    [JsonPropertyName("cidade")]
    public int Cidade { get; set; }

    /// <summary>
    /// Sem descrição - estCadastro  
    /// </summary>
    [JsonPropertyName("cadastro")]
    public int Cadastro { get; set; }

    /// <summary>
    /// Sem descrição - estCadastroExCod  
    /// </summary>
    [JsonPropertyName("cadastroexcod")]
    public int CadastroExCod { get; set; }

    /// <summary>
    /// Sem descrição - estMotivo - tamanho máximo: 200 
    /// </summary>
    [JsonPropertyName("motivo")]
    public string Motivo { get; set; } = "";

    /// <summary>
    /// Sem descrição - estContatoNoLocal - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("contatonolocal")]
    public string ContatoNoLocal { get; set; } = "";

    /// <summary>
    /// Endereço - estEndereco - tamanho máximo: 150 
    /// </summary>
    [JsonPropertyName("endereco")]
    public string Endereco { get; set; } = "";

    /// <summary>
    /// Bairro - estBairro - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("bairro")]
    public string Bairro { get; set; } = "";

    /// <summary>
    /// CEP - estCEP - tamanho máximo: 10 
    /// </summary>
    [JsonPropertyName("cep")]
    public string CEP { get; set; } = "";

    /// <summary>
    /// Fone - estFone  
    /// </summary>
    [JsonPropertyName("fone")]
    public string Fone { get; set; } = "";

    /// <summary>
    /// Fax - estFax  
    /// </summary>
    [JsonPropertyName("fax")]
    public string Fax { get; set; } = "";

    /// <summary>
    /// Sem descrição - estObservacao  
    /// </summary>
    [JsonPropertyName("observacao")]
    public string Observacao { get; set; } = "";

    /// <summary>
    /// GUId - estGUID - tamanho máximo: 150 
    /// </summary>
    [JsonPropertyName("guid")]
    public string GUID { get; set; } = "";

    [JsonPropertyName("nometipoenderecosistema")]
    public string NomeTipoEnderecoSistema { get; set; } = string.Empty;

    [JsonPropertyName("nropastaprocessos")]
    public string NroPastaProcessos { get; set; } = string.Empty;

    [JsonPropertyName("nomecidade")]
    public string NomeCidade { get; set; } = string.Empty;
}