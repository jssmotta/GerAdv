
namespace MenphisSI;

[Serializable]
public class TSqlCmd
{
    public TSqlCmd() { Nome = ""; Value = ""; }

    public string Nome;
    public SqlDbType Type;
    public object Value;
}
