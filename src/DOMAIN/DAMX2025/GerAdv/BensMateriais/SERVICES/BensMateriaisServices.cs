// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public partial class DBBensMateriais
{
    [XmlIgnore]
    public string MValorBemStr { get => m_FValorBem.ToString("0.00"); set => FValorBem = DevourerOne.ConvertString2Decimal(value); }
}