// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBApenso
{
    [XmlIgnore]
    public DateTime FDtDistWithHora
    {
        set
        {
            pFldFDtDist = true;
            m_FDtDist = value;
        }
    }

    [XmlIgnore]
    public string MDtDistDataX_DataHora => $"{m_FDtDist:dd/MM/yyyy HH:mm:ss}";

    [XmlIgnore]
    public string MDtDistX_Hora => $"{m_FDtDist:HH:mm:ss}";

    [XmlIgnore]
    public string MValorCausaStr { get => m_FValorCausa.ToString("0.00"); set => FValorCausa = DevourerOne.ConvertString2Decimal(value); }
#if (forWeb)
[XmlIgnore]
public string TRClick => DevourerOne.TableTrClick(ID, "APENSOINC");
#endif
}