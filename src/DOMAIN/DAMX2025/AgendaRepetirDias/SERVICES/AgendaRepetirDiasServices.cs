// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBAgendaRepetirDias
{
    [XmlIgnore]
    public DateTime FHoraFinalWithHora
    {
        set
        {
            pFldFHoraFinal = true;
            m_FHoraFinal = value;
        }
    }

    [XmlIgnore]
    public string MHoraFinalDataX_DataHora => $"{m_FHoraFinal:dd/MM/yyyy HH:mm:ss}";

    [XmlIgnore]
    public string MHoraFinalX_Hora => $"{m_FHoraFinal:HH:mm:ss}";

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
#if (forWeb)
[XmlIgnore]
public string TRClick => DevourerOne.TableTrClick(ID, "AGENDAREPETIRDIASINC");
#endif
}