#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class PontoVirtual
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - pvtOperador  
    /// </summary>
    [JsonPropertyName("operador")]
    public int Operador { get; set; }

    /// <summary>
    /// Sem descrição - pvtHoraEntrada  
    /// </summary>
    [JsonPropertyName("horaentrada")]
    public string HoraEntrada { get; set; } = "";

    /// <summary>
    /// Sem descrição - pvtHoraSaida  
    /// </summary>
    [JsonPropertyName("horasaida")]
    public string HoraSaida { get; set; } = "";

    /// <summary>
    /// Sem descrição - pvtKey - tamanho máximo: 23 
    /// </summary>
    [JsonPropertyName("key")]
    public string Key { get; set; } = "";
}