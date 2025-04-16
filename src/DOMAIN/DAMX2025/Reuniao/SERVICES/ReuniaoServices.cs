// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBReuniao
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
    public DateTime FHoraInicialWithHora
    {
        set
        {
            pFldFHoraInicial = true;
            m_FHoraInicial = value;
        }
    }

    [XmlIgnore]
    public string MHoraInicialDataX_DataHora => $"{m_FHoraInicial:dd/MM/yyyy HH:mm:ss}";

    [XmlIgnore]
    public string MHoraInicialX_Hora => $"{m_FHoraInicial:HH:mm:ss}";

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
    public DateTime FHoraSaidaWithHora
    {
        set
        {
            pFldFHoraSaida = true;
            m_FHoraSaida = value;
        }
    }

    [XmlIgnore]
    public string MHoraSaidaDataX_DataHora => $"{m_FHoraSaida:dd/MM/yyyy HH:mm:ss}";

    [XmlIgnore]
    public string MHoraSaidaX_Hora => $"{m_FHoraSaida:HH:mm:ss}";

    [XmlIgnore]
    public DateTime FHoraRetornoWithHora
    {
        set
        {
            pFldFHoraRetorno = true;
            m_FHoraRetorno = value;
        }
    }

    [XmlIgnore]
    public string MHoraRetornoDataX_DataHora => $"{m_FHoraRetorno:dd/MM/yyyy HH:mm:ss}";

    [XmlIgnore]
    public string MHoraRetornoX_Hora => $"{m_FHoraRetorno:HH:mm:ss}";
#if (forWeb)
[XmlIgnore]
public string TRClick => DevourerOne.TableTrClick(ID, "REUNIAOINC");
#endif
}