#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class GruposEmpresasCli
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - gecGrupo  
    /// </summary>
    [JsonPropertyName("grupo")]
    public int Grupo { get; set; }

    /// <summary>
    /// Sem descrição - gecCliente  
    /// </summary>
    [JsonPropertyName("cliente")]
    public int Cliente { get; set; }

    /// <summary>
    /// Sem descrição - gecOculto  
    /// </summary>
    [JsonPropertyName("oculto")]
    public bool Oculto { get; set; }
}

[Serializable]
public partial class GruposEmpresasCliAll
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - gecGrupo  
    /// </summary>
    [JsonPropertyName("grupo")]
    public int Grupo { get; set; }

    /// <summary>
    /// Sem descrição - gecCliente  
    /// </summary>
    [JsonPropertyName("cliente")]
    public int Cliente { get; set; }

    /// <summary>
    /// Sem descrição - gecOculto  
    /// </summary>
    [JsonPropertyName("oculto")]
    public bool Oculto { get; set; }

    [JsonPropertyName("descricaogruposempresas")]
    public string DescricaoGruposEmpresas { get; set; } = string.Empty;

    [JsonPropertyName("nomeclientes")]
    public string NomeClientes { get; set; } = string.Empty;
}