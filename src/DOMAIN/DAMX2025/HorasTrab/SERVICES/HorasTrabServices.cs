// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBHorasTrab
{
    [XmlIgnore]
    public string MTempoStr { get => m_FTempo.ToString("0.00"); set => FTempo = DevourerOne.ConvertString2Decimal(value); }

    [XmlIgnore]
    public string MValorStr { get => m_FValor.ToString("0.00"); set => FValor = DevourerOne.ConvertString2Decimal(value); }
}