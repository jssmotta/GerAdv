// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBContaCorrente
{
    [XmlIgnore]
    public DateTime FDtOriginalWithHora
    {
        set
        {
            pFldFDtOriginal = true;
            m_FDtOriginal = value;
        }
    }

    [XmlIgnore]
    public string MDtOriginalDataX_DataHora => $"{m_FDtOriginal:dd/MM/yyyy HH:mm:ss}";

    [XmlIgnore]
    public string MDtOriginalX_Hora => $"{m_FDtOriginal:HH:mm:ss}";

    [XmlIgnore]
    public string MValorStr { get => m_FValor.ToString("0.00"); set => FValor = DevourerOne.ConvertString2Decimal(value); }

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
    public string MValorPrincipalStr { get => m_FValorPrincipal.ToString("0.00"); set => FValorPrincipal = DevourerOne.ConvertString2Decimal(value); }

    [XmlIgnore]
    public DateTime FDataPgtoWithHora
    {
        set
        {
            pFldFDataPgto = true;
            m_FDataPgto = value;
        }
    }

    [XmlIgnore]
    public string MDataPgtoDataX_DataHora => $"{m_FDataPgto:dd/MM/yyyy HH:mm:ss}";

    [XmlIgnore]
    public string MDataPgtoX_Hora => $"{m_FDataPgto:HH:mm:ss}";
#if (forWeb)
[XmlIgnore]
public string TRClick => DevourerOne.TableTrClick(ID, "CONTACORRENTEINC");
#endif
}