namespace Domain.BaseCommon.Models;
[Serializable]
public class Error500
{
    public bool success { get; set; } = false;
    public string data { get; set; } = "";
    public string message { get; set; } = "";
}

