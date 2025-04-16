namespace MenphisSI.BaseCommon;

public class NomeID
{
    [JsonPropertyName("nome")]
    public string Nome { get; set; } = string.Empty;

    [JsonPropertyName("id")]
    public int ID { get; set; }
}