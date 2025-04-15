// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBPontoVirtualAcessos
{
    [XmlIgnore]
    public DateTime FDataHoraWithHora
    {
        set
        {
            pFldFDataHora = true;
            m_FDataHora = value;
        }
    }

    [XmlIgnore]
    public string MDataHoraDataX_DataHora => $"{m_FDataHora:dd/MM/yyyy HH:mm:ss}";

    [XmlIgnore]
    public string MDataHoraX_Hora => $"{m_FDataHora:HH:mm:ss}";
}