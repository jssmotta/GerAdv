// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBHonorariosDadosContrato
{
    [XmlIgnore]
    public string MPercSucessoStr { get => m_FPercSucesso.ToString("0.00"); set => FPercSucesso = DevourerOne.ConvertString2Decimal(value); }

    [XmlIgnore]
    public string MValorFixoStr { get => m_FValorFixo.ToString("0.00"); set => FValorFixo = DevourerOne.ConvertString2Decimal(value); }

    [XmlIgnore]
    public DateTime FDataContratoWithHora
    {
        set
        {
            pFldFDataContrato = true;
            m_FDataContrato = value;
        }
    }

    [XmlIgnore]
    public string MDataContratoDataX_DataHora => $"{m_FDataContrato:dd/MM/yyyy HH:mm:ss}";

    [XmlIgnore]
    public string MDataContratoX_Hora => $"{m_FDataContrato:HH:mm:ss}";
#if (forWeb)
[XmlIgnore]
public string TRClick => DevourerOne.TableTrClick(ID, "HONORARIOSDADOSCONTRATOINC");
#endif
}