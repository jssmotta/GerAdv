// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBLigacoes
{
    [XmlIgnore]
    public DateTime FDataRealizadaWithHora
    {
        set
        {
            pFldFDataRealizada = true;
            m_FDataRealizada = value;
        }
    }

    [XmlIgnore]
    public string MDataRealizadaDataX_DataHora => $"{m_FDataRealizada:dd/MM/yyyy HH:mm:ss}";

    [XmlIgnore]
    public string MDataRealizadaX_Hora => $"{m_FDataRealizada:HH:mm:ss}";

    [XmlIgnore]
    public DateTime FUltimoAvisoWithHora
    {
        set
        {
            pFldFUltimoAviso = true;
            m_FUltimoAviso = value;
        }
    }

    [XmlIgnore]
    public string MUltimoAvisoDataX_DataHora => $"{m_FUltimoAviso:dd/MM/yyyy HH:mm:ss}";

    [XmlIgnore]
    public string MUltimoAvisoX_Hora => $"{m_FUltimoAviso:HH:mm:ss}";

    [XmlIgnore]
    public DateTime FHoraFinalWithHora
    {
        set
        {
            pFldFHoraFinal = true;
            m_FHoraFinal = value;
        }
    }

    [XmlIgnore]
    public string MHoraFinalDataX_DataHora => $"{m_FHoraFinal:dd/MM/yyyy HH:mm:ss}";

    [XmlIgnore]
    public string MHoraFinalX_Hora => $"{m_FHoraFinal:HH:mm:ss}";

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
[XmlIgnore]
public string TRClick => DevourerOne.TableTrClick(ID, "LIGACOESINC");
#endif
}