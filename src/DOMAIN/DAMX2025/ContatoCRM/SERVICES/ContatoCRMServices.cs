// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBContatoCRM
{
    [XmlIgnore]
    public string MTempoStr { get => m_FTempo.ToString("0.00"); set => FTempo = DevourerOne.ConvertString2Decimal(value); }
}