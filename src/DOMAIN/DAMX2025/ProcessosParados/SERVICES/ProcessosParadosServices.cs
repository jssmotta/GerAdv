// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBProcessosParados
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

    [XmlIgnore]
    public DateTime FDataHistoricoWithHora
    {
        set
        {
            pFldFDataHistorico = true;
            m_FDataHistorico = value;
        }
    }

    [XmlIgnore]
    public string MDataHistoricoDataX_DataHora => $"{m_FDataHistorico:dd/MM/yyyy HH:mm:ss}";

    [XmlIgnore]
    public string MDataHistoricoX_Hora => $"{m_FDataHistorico:HH:mm:ss}";

    [XmlIgnore]
    public DateTime FDataNENotasWithHora
    {
        set
        {
            pFldFDataNENotas = true;
            m_FDataNENotas = value;
        }
    }

    [XmlIgnore]
    public string MDataNENotasDataX_DataHora => $"{m_FDataNENotas:dd/MM/yyyy HH:mm:ss}";

    [XmlIgnore]
    public string MDataNENotasX_Hora => $"{m_FDataNENotas:HH:mm:ss}";
#if (forWeb)
[XmlIgnore]
public string TRClick => DevourerOne.TableTrClick(ID, "PROCESSOSPARADOSINC");
#endif
}