#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class PontoVirtualAcessos
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - pvaOperador  
    /// </summary>
    [JsonPropertyName("operador")]
    public int Operador { get; set; }

    /// <summary>
    /// Sem descrição - pvaDataHora  
    /// </summary>
    [JsonPropertyName("datahora")]
    public string DataHora { get; set; } = "";

    /// <summary>
    /// Sem descrição - pvaTipo  
    /// </summary>
    [JsonPropertyName("tipo")]
    public bool Tipo { get; set; }

    /// <summary>
    /// Sem descrição - pvaOrigem - tamanho máximo: 150 
    /// </summary>
    [JsonPropertyName("origem")]
    public string Origem { get; set; } = "";
}