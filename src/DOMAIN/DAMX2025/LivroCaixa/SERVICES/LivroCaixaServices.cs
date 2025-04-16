// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBLivroCaixa
{
    [XmlIgnore]
    public DateTime FDataWithHora
    {
        set
        {
            pFldFData = true;
            m_FData = value;
        }
    }

    [XmlIgnore]
    public string MDataDataX_DataHora => $"{m_FData:dd/MM/yyyy HH:mm:ss}";

    [XmlIgnore]
    public string MDataX_Hora => $"{m_FData:HH:mm:ss}";

    [XmlIgnore]
    public string MValorStr { get => m_FValor.ToString("0.00"); set => FValor = DevourerOne.ConvertString2Decimal(value); }
#if (forWeb)
[XmlIgnore]
public string TRClick => DevourerOne.TableTrClick(ID, "LIVROCAIXAINC");
#endif
}