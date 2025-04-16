// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBPontoVirtual
{
    [XmlIgnore]
    public DateTime FHoraEntradaWithHora
    {
        set
        {
            pFldFHoraEntrada = true;
            m_FHoraEntrada = value;
        }
    }

    [XmlIgnore]
    public string MHoraEntradaDataX_DataHora => $"{m_FHoraEntrada:dd/MM/yyyy HH:mm:ss}";

    [XmlIgnore]
    public string MHoraEntradaX_Hora => $"{m_FHoraEntrada:HH:mm:ss}";

    [XmlIgnore]
    public DateTime FHoraSaidaWithHora
    {
        set
        {
            pFldFHoraSaida = true;
            m_FHoraSaida = value;
        }
    }

    [XmlIgnore]
    public string MHoraSaidaDataX_DataHora => $"{m_FHoraSaida:dd/MM/yyyy HH:mm:ss}";

    [XmlIgnore]
    public string MHoraSaidaX_Hora => $"{m_FHoraSaida:HH:mm:ss}";
}