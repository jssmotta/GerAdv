// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public partial class DBAgenda
{
    [XmlIgnore]
    public string MValorStr { get => m_FValor.ToString("0.00"); set => FValor = DevourerOne.ConvertString2Decimal(value); }
}