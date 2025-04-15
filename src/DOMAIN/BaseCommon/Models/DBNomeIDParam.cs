namespace MenphisSI.GerAdv;

public class DBNomeIDParam
{
    [JsonPropertyName("id")]
    public int ID { get; set; }

    [JsonPropertyName("fnome")]
    public string? FNome { get; set; }

    [JsonPropertyName("sql")]
    public string? Sql { get; set; }
}