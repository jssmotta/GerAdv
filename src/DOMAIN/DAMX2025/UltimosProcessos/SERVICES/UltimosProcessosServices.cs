// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBUltimosProcessos
{
    [XmlIgnore]
    public DateTime FQuandoWithHora
    {
        set
        {
            pFldFQuando = true;
            m_FQuando = value;
        }
    }

    [XmlIgnore]
    public string MQuandoDataX_DataHora => $"{m_FQuando:dd/MM/yyyy HH:mm:ss}";

    [XmlIgnore]
    public string MQuandoX_Hora => $"{m_FQuando:HH:mm:ss}";
#if (forWeb)
[XmlIgnore]
public string TRClick => DevourerOne.TableTrClick(ID, "ULTIMOSPROCESSOSINC");
#endif
}