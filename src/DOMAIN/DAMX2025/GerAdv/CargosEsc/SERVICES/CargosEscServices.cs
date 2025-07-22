// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public partial class DBCargosEsc
{
    [XmlIgnore]
    public string MPercentualStr { get => m_FPercentual.ToString("0.00"); set => FPercentual = DevourerOne.ConvertString2Decimal(value); }
}