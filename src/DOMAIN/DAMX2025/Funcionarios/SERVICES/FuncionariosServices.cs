// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBFuncionarios
{
    [XmlIgnore]
    public string MSalarioStr { get => m_FSalario.ToString("0.00"); set => FSalario = DevourerOne.ConvertString2Decimal(value); }
}