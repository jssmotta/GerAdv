// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBGUTPeriodicidadeStatus
{
    [XmlIgnore]
    public DateTime FDataRealizadoWithHora
    {
        set
        {
            pFldFDataRealizado = true;
            m_FDataRealizado = value;
        }
    }

    [XmlIgnore]
    public string MDataRealizadoDataX_DataHora => $"{m_FDataRealizado:dd/MM/yyyy HH:mm:ss}";

    [XmlIgnore]
    public string MDataRealizadoX_Hora => $"{m_FDataRealizado:HH:mm:ss}";
#if (forWeb)
[XmlIgnore]
public string TRClick => DevourerOne.TableTrClick(ID, "GUTPERIODICIDADESTATUSINC");
#endif
}