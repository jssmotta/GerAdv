// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public partial class DBApenso
{
    [XmlIgnore]
    public string MValorCausaStr { get => m_FValorCausa.ToString("0.00"); set => FValorCausa = DevourerOne.ConvertString2Decimal(value); }
}