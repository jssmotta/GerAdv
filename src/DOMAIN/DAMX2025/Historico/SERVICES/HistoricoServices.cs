// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBHistorico
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
#if (forWeb)
[XmlIgnore]
public string TRClick => DevourerOne.TableTrClick(ID, "HISTORICOINC");
#endif
}