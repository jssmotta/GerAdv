#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class ClientesSocios
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - cscCliente  
    /// </summary>
    [JsonPropertyName("cliente")]
    public int Cliente { get; set; }

    /// <summary>
    /// Cidade - cscCidade  
    /// </summary>
    [JsonPropertyName("cidade")]
    public int Cidade { get; set; }

    /// <summary>
    /// Cidade - cscCidadeSocio  
    /// </summary>
    [JsonPropertyName("cidadesocio")]
    public int CidadeSocio { get; set; }

    /// <summary>
    /// Sem descrição - cscSomenteRepresentante  
    /// </summary>
    [JsonPropertyName("somenterepresentante")]
    public bool SomenteRepresentante { get; set; }

    /// <summary>
    /// Sem descrição - cscIdade  
    /// </summary>
    [JsonPropertyName("idade")]
    public int Idade { get; set; }

    /// <summary>
    /// Sem descrição - cscIsRepresentanteLegal  
    /// </summary>
    [JsonPropertyName("isrepresentantelegal")]
    public bool IsRepresentanteLegal { get; set; }

    /// <summary>
    /// Sem descrição - cscQualificacao - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("qualificacao")]
    public string Qualificacao { get; set; } = "";

    /// <summary>
    /// Sem descrição - cscSexo  
    /// </summary>
    [JsonPropertyName("sexo")]
    public bool Sexo { get; set; }

    /// <summary>
    /// Sem descrição - cscDtNasc  
    /// </summary>
    [JsonPropertyName("dtnasc")]
    public string DtNasc { get; set; } = "";

    /// <summary>
    /// Sem descrição - cscNome - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("nome")]
    public string Nome { get; set; } = "";

    /// <summary>
    /// Sem descrição - cscSite - tamanho máximo: 150 
    /// </summary>
    [JsonPropertyName("site")]
    public string Site { get; set; } = "";

    /// <summary>
    /// Sem descrição - cscRepresentanteLegal - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("representantelegal")]
    public string RepresentanteLegal { get; set; } = "";

    /// <summary>
    /// Endereço - cscEndereco - tamanho máximo: 80 
    /// </summary>
    [JsonPropertyName("endereco")]
    public string Endereco { get; set; } = "";

    /// <summary>
    /// Bairro - cscBairro - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("bairro")]
    public string Bairro { get; set; } = "";

    /// <summary>
    /// CEP - cscCEP - tamanho máximo: 10 
    /// </summary>
    [JsonPropertyName("cep")]
    public string CEP { get; set; } = "";

    /// <summary>
    /// Número da Carteira de Identidade - cscRG - tamanho máximo: 30 
    /// </summary>
    [JsonPropertyName("rg")]
    public string RG { get; set; } = "";

    /// <summary>
    /// CPF - cscCPF - tamanho máximo: 11 
    /// </summary>
    [JsonPropertyName("cpf")]
    public string CPF { get; set; } = "";

    /// <summary>
    /// Fone - cscFone  
    /// </summary>
    [JsonPropertyName("fone")]
    public string Fone { get; set; } = "";

    /// <summary>
    /// Sem descrição - cscParticipacao - tamanho máximo: 10 
    /// </summary>
    [JsonPropertyName("participacao")]
    public string Participacao { get; set; } = "";

    /// <summary>
    /// Sem descrição - cscCargo - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("cargo")]
    public string Cargo { get; set; } = "";

    /// <summary>
    /// Sem descrição - cscEMail - tamanho máximo: 60 
    /// </summary>
    [JsonPropertyName("email")]
    public string EMail { get; set; } = "";

    /// <summary>
    /// Sem descrição - cscObs  
    /// </summary>
    [JsonPropertyName("obs")]
    public string Obs { get; set; } = "";

    /// <summary>
    /// CNH - cscCNH - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("cnh")]
    public string CNH { get; set; } = "";

    /// <summary>
    /// Sem descrição - cscDataContrato  
    /// </summary>
    [JsonPropertyName("datacontrato")]
    public string DataContrato { get; set; } = "";

    /// <summary>
    /// CNPJ - cscCNPJ - tamanho máximo: 14 
    /// </summary>
    [JsonPropertyName("cnpj")]
    public string CNPJ { get; set; } = "";

    /// <summary>
    /// Inscrição Estadual - cscInscEst - tamanho máximo: 15 
    /// </summary>
    [JsonPropertyName("inscest")]
    public string InscEst { get; set; } = "";

    /// <summary>
    /// Sem descrição - cscSocioEmpresaAdminNome - tamanho máximo: 80 
    /// </summary>
    [JsonPropertyName("socioempresaadminnome")]
    public string SocioEmpresaAdminNome { get; set; } = "";

    /// <summary>
    /// Sem descrição - cscEnderecoSocio - tamanho máximo: 80 
    /// </summary>
    [JsonPropertyName("enderecosocio")]
    public string EnderecoSocio { get; set; } = "";

    /// <summary>
    /// Sem descrição - cscBairroSocio - tamanho máximo: 50 
    /// </summary>
    [JsonPropertyName("bairrosocio")]
    public string BairroSocio { get; set; } = "";

    /// <summary>
    /// Sem descrição - cscCEPSocio - tamanho máximo: 10 
    /// </summary>
    [JsonPropertyName("cepsocio")]
    public string CEPSocio { get; set; } = "";

    /// <summary>
    /// Sem descrição - cscRGDataExp  
    /// </summary>
    [JsonPropertyName("rgdataexp")]
    public string RGDataExp { get; set; } = "";

    /// <summary>
    /// Sem descrição - cscSocioEmpresaAdminSomente  
    /// </summary>
    [JsonPropertyName("socioempresaadminsomente")]
    public bool SocioEmpresaAdminSomente { get; set; }

    /// <summary>
    /// Sem descrição - cscTipo  
    /// </summary>
    [JsonPropertyName("tipo")]
    public bool Tipo { get; set; }

    /// <summary>
    /// Fax - cscFax - tamanho máximo: 2048 
    /// </summary>
    [JsonPropertyName("fax")]
    public string Fax { get; set; } = "";

    /// <summary>
    /// Classificação - cscClass - tamanho máximo: 1 
    /// </summary>
    [JsonPropertyName("class")]
    public string Class { get; set; } = "";

    /// <summary>
    /// Criar etiqueta - cscEtiqueta  
    /// </summary>
    [JsonPropertyName("etiqueta")]
    public bool Etiqueta { get; set; }

    /// <summary>
    /// Aniversário - cscAni  
    /// </summary>
    [JsonPropertyName("ani")]
    public bool Ani { get; set; }

    /// <summary>
    /// Negritar - cscBold  
    /// </summary>
    [JsonPropertyName("bold")]
    public bool Bold { get; set; }

    /// <summary>
    /// GUId - cscGUID - tamanho máximo: 150 
    /// </summary>
    [JsonPropertyName("guid")]
    public string Guid { get; set; } = "";

    [JsonPropertyName("auditor")]
    public Auditor? Auditor { get; set; }
}