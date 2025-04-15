// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBAgendaFinanceiro
{
    [XmlIgnore]
    public DateTime FHrFinalWithHora
    {
        set
        {
            pFldFHrFinal = true;
            m_FHrFinal = value;
        }
    }

    [XmlIgnore]
    public string MHrFinalDataX_DataHora => $"{m_FHrFinal:dd/MM/yyyy HH:mm:ss}";

    [XmlIgnore]
    public string MHrFinalX_Hora => $"{m_FHrFinal:HH:mm:ss}";

    [XmlIgnore]
    public DateTime FEventoDataWithHora
    {
        set
        {
            pFldFEventoData = true;
            m_FEventoData = value;
        }
    }

    [XmlIgnore]
    public string MEventoDataDataX_DataHora => $"{m_FEventoData:dd/MM/yyyy HH:mm:ss}";

    [XmlIgnore]
    public string MEventoDataX_Hora => $"{m_FEventoData:HH:mm:ss}";

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

    [XmlIgnore]
    public DateTime FDDiasWithHora
    {
        set
        {
            pFldFDDias = true;
            m_FDDias = value;
        }
    }

    [XmlIgnore]
    public string MDDiasDataX_DataHora => $"{m_FDDias:dd/MM/yyyy HH:mm:ss}";

    [XmlIgnore]
    public string MDDiasX_Hora => $"{m_FDDias:HH:mm:ss}";

    [XmlIgnore]
    public string MValorStr { get => m_FValor.ToString("0.00"); set => FValor = DevourerOne.ConvertString2Decimal(value); }

    [XmlIgnore]
    public DateTime FDataInicioPrazoWithHora
    {
        set
        {
            pFldFDataInicioPrazo = true;
            m_FDataInicioPrazo = value;
        }
    }

    [XmlIgnore]
    public string MDataInicioPrazoDataX_DataHora => $"{m_FDataInicioPrazo:dd/MM/yyyy HH:mm:ss}";

    [XmlIgnore]
    public string MDataInicioPrazoX_Hora => $"{m_FDataInicioPrazo:HH:mm:ss}";
#if (forWeb)
[XmlIgnore]
public string TRClick => DevourerOne.TableTrClick(ID, "AGENDAFINANCEIROINC");
#endif
}