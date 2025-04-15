// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBDiario2
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
public string FNomeWebSafe => m_FNome?.trim()?.replace(">", string.Empty)?.replace("<", string.Empty) ?? string.Empty;
#endif
#if (forWeb)
[XmlIgnore]
public string TRClick => DevourerOne.TableTrClick(ID, "DIARIO2INC");
#endif
}