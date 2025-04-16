// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBAlertasEnviados
{
    [XmlIgnore]
    public DateTime FDataAlertadoWithHora
    {
        set
        {
            pFldFDataAlertado = true;
            m_FDataAlertado = value;
        }
    }

    [XmlIgnore]
    public string MDataAlertadoDataX_DataHora => $"{m_FDataAlertado:dd/MM/yyyy HH:mm:ss}";

    [XmlIgnore]
    public string MDataAlertadoX_Hora => $"{m_FDataAlertado:HH:mm:ss}";
#if (forWeb)
[XmlIgnore]
public string TRClick => DevourerOne.TableTrClick(ID, "ALERTASENVIADOSINC");
#endif
}