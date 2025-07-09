// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBProValores
{
    [XmlIgnore]
    public string MValorOriginalStr { get => m_FValorOriginal.ToString("0.00"); set => FValorOriginal = DevourerOne.ConvertString2Decimal(value); }

    [XmlIgnore]
    public string MPercMultaStr { get => m_FPercMulta.ToString("0.00"); set => FPercMulta = DevourerOne.ConvertString2Decimal(value); }

    [XmlIgnore]
    public string MValorMultaStr { get => m_FValorMulta.ToString("0.00"); set => FValorMulta = DevourerOne.ConvertString2Decimal(value); }

    [XmlIgnore]
    public string MPercJurosStr { get => m_FPercJuros.ToString("0.00"); set => FPercJuros = DevourerOne.ConvertString2Decimal(value); }

    [XmlIgnore]
    public string MValorOriginalCorrigidoIndiceStr { get => m_FValorOriginalCorrigidoIndice.ToString("0.00"); set => FValorOriginalCorrigidoIndice = DevourerOne.ConvertString2Decimal(value); }

    [XmlIgnore]
    public string MValorMultaCorrigidoStr { get => m_FValorMultaCorrigido.ToString("0.00"); set => FValorMultaCorrigido = DevourerOne.ConvertString2Decimal(value); }

    [XmlIgnore]
    public string MValorJurosCorrigidoStr { get => m_FValorJurosCorrigido.ToString("0.00"); set => FValorJurosCorrigido = DevourerOne.ConvertString2Decimal(value); }

    [XmlIgnore]
    public string MValorFinalStr { get => m_FValorFinal.ToString("0.00"); set => FValorFinal = DevourerOne.ConvertString2Decimal(value); }
}