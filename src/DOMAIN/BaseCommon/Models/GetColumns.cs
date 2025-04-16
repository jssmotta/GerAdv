namespace MenphisSI.BaseCommon;

public class GetColumns
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("columns")]
    public IEnumerable<string>? Columns{ get; set; }
}

public class GetColumnsResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("columns")]
    public IEnumerable<ColumnValueItem>? Columns { get; set; }
}