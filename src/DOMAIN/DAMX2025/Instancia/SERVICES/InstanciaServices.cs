// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBInstancia
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
    public DateTime FZKeyQuandoWithHora
    {
        set
        {
            pFldFZKeyQuando = true;
            m_FZKeyQuando = value;
        }
    }

    [XmlIgnore]
    public string MZKeyQuandoDataX_DataHora => $"{m_FZKeyQuando:dd/MM/yyyy HH:mm:ss}";

    [XmlIgnore]
    public string MZKeyQuandoX_Hora => $"{m_FZKeyQuando:HH:mm:ss}";
#if (forWeb)
[XmlIgnore]
public string TRClick => DevourerOne.TableTrClick(ID, "INSTANCIAINC");
#endif
}