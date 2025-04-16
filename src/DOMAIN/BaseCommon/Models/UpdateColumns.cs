namespace MenphisSI.BaseCommon;

public class UpdateColumnsRequest
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("columns")]
    public IEnumerable<(string, object)> Columns { get; set; } = [];
}

public class UpdateColumnsResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("colums")]
    public IEnumerable<(string, object)> Columns { get; set; } = [];
}