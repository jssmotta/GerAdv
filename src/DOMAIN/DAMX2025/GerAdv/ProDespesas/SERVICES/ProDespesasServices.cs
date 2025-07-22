// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public partial class DBProDespesas
{
    [XmlIgnore]
    public string MValorOriginalStr { get => m_FValorOriginal.ToString("0.00"); set => FValorOriginal = DevourerOne.ConvertString2Decimal(value); }

    [XmlIgnore]
    public string MValorStr { get => m_FValor.ToString("0.00"); set => FValor = DevourerOne.ConvertString2Decimal(value); }
}