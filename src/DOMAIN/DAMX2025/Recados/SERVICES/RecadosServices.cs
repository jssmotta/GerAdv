// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBRecados
{
    [XmlIgnore]
    public DateTime FHoraWithHora
    {
        set
        {
            pFldFHora = true;
            m_FHora = value;
        }
    }

    [XmlIgnore]
    public string MHoraDataX_DataHora => $"{m_FHora:dd/MM/yyyy HH:mm:ss}";

    [XmlIgnore]
    public string MHoraX_Hora => $"{m_FHora:HH:mm:ss}";

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
    public DateTime FRetornoDataWithHora
    {
        set
        {
            pFldFRetornoData = true;
            m_FRetornoData = value;
        }
    }

    [XmlIgnore]
    public string MRetornoDataDataX_DataHora => $"{m_FRetornoData:dd/MM/yyyy HH:mm:ss}";

    [XmlIgnore]
    public string MRetornoDataX_Hora => $"{m_FRetornoData:HH:mm:ss}";
#if (forWeb)
[XmlIgnore]
public string TRClick => DevourerOne.TableTrClick(ID, "RECADOSINC");
#endif
}