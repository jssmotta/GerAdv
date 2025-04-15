// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBGUTAtividades
{
    [XmlIgnore]
    public DateTime FDataConcluidoWithHora
    {
        set
        {
            pFldFDataConcluido = true;
            m_FDataConcluido = value;
        }
    }

    [XmlIgnore]
    public string MDataConcluidoDataX_DataHora => $"{m_FDataConcluido:dd/MM/yyyy HH:mm:ss}";

    [XmlIgnore]
    public string MDataConcluidoX_Hora => $"{m_FDataConcluido:HH:mm:ss}";
}