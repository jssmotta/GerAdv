// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBAlertas
{
#if (forWeb)
public string FNomeWebSafe => m_FNome?.trim()?.replace(">", string.Empty)?.replace("<", string.Empty) ?? string.Empty;
#endif
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
    public DateTime FDataAteWithHora
    {
        set
        {
            pFldFDataAte = true;
            m_FDataAte = value;
        }
    }

    [XmlIgnore]
    public string MDataAteDataX_DataHora => $"{m_FDataAte:dd/MM/yyyy HH:mm:ss}";

    [XmlIgnore]
    public string MDataAteX_Hora => $"{m_FDataAte:HH:mm:ss}";
#if (forWeb)
[XmlIgnore]
public string TRClick => DevourerOne.TableTrClick(ID, "ALERTASINC");
#endif
}