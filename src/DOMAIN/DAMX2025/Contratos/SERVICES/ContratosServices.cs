// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBContratos
{
    [XmlIgnore]
    public string MValorStr { get => m_FValor.ToString("0.00"); set => FValor = DevourerOne.ConvertString2Decimal(value); }

    [XmlIgnore]
    public string MPercEscritorioStr { get => m_FPercEscritorio.ToString("0.00"); set => FPercEscritorio = DevourerOne.ConvertString2Decimal(value); }

    [XmlIgnore]
    public string MValorConsultoriaStr { get => m_FValorConsultoria.ToString("0.00"); set => FValorConsultoria = DevourerOne.ConvertString2Decimal(value); }

    [XmlIgnore]
    public string MValorRealizavelStr { get => m_FValorRealizavel.ToString("0.00"); set => FValorRealizavel = DevourerOne.ConvertString2Decimal(value); }
}