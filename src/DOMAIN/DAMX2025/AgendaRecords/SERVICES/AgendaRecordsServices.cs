// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBAgendaRecords
{
    [XmlIgnore]
    public DateTime FDataAviso1WithHora
    {
        set
        {
            pFldFDataAviso1 = true;
            m_FDataAviso1 = value;
        }
    }

    [XmlIgnore]
    public string MDataAviso1DataX_DataHora => $"{m_FDataAviso1:dd/MM/yyyy HH:mm:ss}";

    [XmlIgnore]
    public string MDataAviso1X_Hora => $"{m_FDataAviso1:HH:mm:ss}";

    [XmlIgnore]
    public DateTime FDataAviso2WithHora
    {
        set
        {
            pFldFDataAviso2 = true;
            m_FDataAviso2 = value;
        }
    }

    [XmlIgnore]
    public string MDataAviso2DataX_DataHora => $"{m_FDataAviso2:dd/MM/yyyy HH:mm:ss}";

    [XmlIgnore]
    public string MDataAviso2X_Hora => $"{m_FDataAviso2:HH:mm:ss}";

    [XmlIgnore]
    public DateTime FDataAviso3WithHora
    {
        set
        {
            pFldFDataAviso3 = true;
            m_FDataAviso3 = value;
        }
    }

    [XmlIgnore]
    public string MDataAviso3DataX_DataHora => $"{m_FDataAviso3:dd/MM/yyyy HH:mm:ss}";

    [XmlIgnore]
    public string MDataAviso3X_Hora => $"{m_FDataAviso3:HH:mm:ss}";
#if (forWeb)
[XmlIgnore]
public string TRClick => DevourerOne.TableTrClick(ID, "AGENDARECORDSINC");
#endif
}