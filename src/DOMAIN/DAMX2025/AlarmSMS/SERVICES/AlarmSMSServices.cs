// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBAlarmSMS
{
#if (forWeb)
public string FDescricaoWebSafe => 
m_FDescricao?.trim()?.replace(">", string.Empty)?.replace("<", string.Empty) ?? string.Empty;
#endif
    [XmlIgnore]
    public DateTime FTodayWithHora
    {
        set
        {
            pFldFToday = true;
            m_FToday = value;
        }
    }

    [XmlIgnore]
    public string MTodayDataX_DataHora => $"{m_FToday:dd/MM/yyyy HH:mm:ss}";

    [XmlIgnore]
    public string MTodayX_Hora => $"{m_FToday:HH:mm:ss}";

    [XmlIgnore]
    public DateTime FAlertarDataHoraWithHora
    {
        set
        {
            pFldFAlertarDataHora = true;
            m_FAlertarDataHora = value;
        }
    }

    [XmlIgnore]
    public string MAlertarDataHoraDataX_DataHora => $"{m_FAlertarDataHora:dd/MM/yyyy HH:mm:ss}";

    [XmlIgnore]
    public string MAlertarDataHoraX_Hora => $"{m_FAlertarDataHora:HH:mm:ss}";
#if (forTheWeb)

public string LinhaEmail => string.Empty; // DevourerOne.LinhaEmailContato(FNome, FEmail, string.Empty, string.Empty); 

#endif
}