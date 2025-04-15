namespace MenphisSI.BaseCommon;

public class Auditor
{
    public int? QuemCad { get; internal set; }
    public int? QuemAtu { get; internal set; }
    public DateTime? DtCad { get; internal set; }
    public DateTime? DtAtu { get; internal set; }
    public bool Visto { get; internal set; }
}