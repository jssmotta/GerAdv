// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBProDespesas
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
    public string MValorOriginalStr { get => m_FValorOriginal.ToString("0.00"); set => FValorOriginal = DevourerOne.ConvertString2Decimal(value); }

    [XmlIgnore]
    public DateTime FDataCorrecaoWithHora
    {
        set
        {
            pFldFDataCorrecao = true;
            m_FDataCorrecao = value;
        }
    }

    [XmlIgnore]
    public string MDataCorrecaoDataX_DataHora => $"{m_FDataCorrecao:dd/MM/yyyy HH:mm:ss}";

    [XmlIgnore]
    public string MDataCorrecaoX_Hora => $"{m_FDataCorrecao:HH:mm:ss}";

    [XmlIgnore]
    public string MValorStr { get => m_FValor.ToString("0.00"); set => FValor = DevourerOne.ConvertString2Decimal(value); }
#if (forWeb)
[XmlIgnore]
public string TRClick => DevourerOne.TableTrClick(ID, "PRODESPESASINC");
#endif
}