// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBHonorariosDadosContrato
{
    [XmlIgnore]
    public string MPercSucessoStr { get => m_FPercSucesso.ToString("0.00"); set => FPercSucesso = DevourerOne.ConvertString2Decimal(value); }

    [XmlIgnore]
    public string MValorFixoStr { get => m_FValorFixo.ToString("0.00"); set => FValorFixo = DevourerOne.ConvertString2Decimal(value); }
}