// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBContatoCRM
{
    [XmlIgnore]
    public DateTime FDataNotificouWithHora
    {
        set
        {
            pFldFDataNotificou = true;
            m_FDataNotificou = value;
        }
    }

    [XmlIgnore]
    public string MDataNotificouDataX_DataHora => $"{m_FDataNotificou:dd/MM/yyyy HH:mm:ss}";

    [XmlIgnore]
    public string MDataNotificouX_Hora => $"{m_FDataNotificou:HH:mm:ss}";

    [XmlIgnore]
    public DateTime FHoraNotificouWithHora
    {
        set
        {
            pFldFHoraNotificou = true;
            m_FHoraNotificou = value;
        }
    }

    [XmlIgnore]
    public string MHoraNotificouDataX_DataHora => $"{m_FHoraNotificou:dd/MM/yyyy HH:mm:ss}";

    [XmlIgnore]
    public string MHoraNotificouX_Hora => $"{m_FHoraNotificou:HH:mm:ss}";

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
    public string MTempoStr { get => m_FTempo.ToString("0.00"); set => FTempo = DevourerOne.ConvertString2Decimal(value); }

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
#if (forWeb)
[XmlIgnore]
public string TRClick => DevourerOne.TableTrClick(ID, "CONTATOCRMINC");
#endif
}