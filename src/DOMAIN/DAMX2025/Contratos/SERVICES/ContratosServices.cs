// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBContratos
{
    [XmlIgnore]
    public string MValorStr { get => m_FValor.ToString("0.00"); set => FValor = DevourerOne.ConvertString2Decimal(value); }

    [XmlIgnore]
    public DateTime FDataInicioWithHora
    {
        set
        {
            pFldFDataInicio = true;
            m_FDataInicio = value;
        }
    }

    [XmlIgnore]
    public string MDataInicioDataX_DataHora => $"{m_FDataInicio:dd/MM/yyyy HH:mm:ss}";

    [XmlIgnore]
    public string MDataInicioX_Hora => $"{m_FDataInicio:HH:mm:ss}";

    [XmlIgnore]
    public DateTime FDataTerminoWithHora
    {
        set
        {
            pFldFDataTermino = true;
            m_FDataTermino = value;
        }
    }

    [XmlIgnore]
    public string MDataTerminoDataX_DataHora => $"{m_FDataTermino:dd/MM/yyyy HH:mm:ss}";

    [XmlIgnore]
    public string MDataTerminoX_Hora => $"{m_FDataTermino:HH:mm:ss}";

    [XmlIgnore]
    public string MPercEscritorioStr { get => m_FPercEscritorio.ToString("0.00"); set => FPercEscritorio = DevourerOne.ConvertString2Decimal(value); }

    [XmlIgnore]
    public string MValorConsultoriaStr { get => m_FValorConsultoria.ToString("0.00"); set => FValorConsultoria = DevourerOne.ConvertString2Decimal(value); }

    [XmlIgnore]
    public string MValorRealizavelStr { get => m_FValorRealizavel.ToString("0.00"); set => FValorRealizavel = DevourerOne.ConvertString2Decimal(value); }
#if (forWeb)
[XmlIgnore]
public string TRClick => DevourerOne.TableTrClick(ID, "CONTRATOSINC");
#endif
}