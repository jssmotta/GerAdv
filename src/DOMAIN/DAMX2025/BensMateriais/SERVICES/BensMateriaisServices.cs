// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBBensMateriais
{
#if (forWeb)
public string FNomeWebSafe => m_FNome?.trim()?.replace(">", string.Empty)?.replace("<", string.Empty) ?? string.Empty;
#endif
    [XmlIgnore]
    public DateTime FDataCompraWithHora
    {
        set
        {
            pFldFDataCompra = true;
            m_FDataCompra = value;
        }
    }

    [XmlIgnore]
    public string MDataCompraDataX_DataHora => $"{m_FDataCompra:dd/MM/yyyy HH:mm:ss}";

    [XmlIgnore]
    public string MDataCompraX_Hora => $"{m_FDataCompra:HH:mm:ss}";

    [XmlIgnore]
    public DateTime FDataFimDaGarantiaWithHora
    {
        set
        {
            pFldFDataFimDaGarantia = true;
            m_FDataFimDaGarantia = value;
        }
    }

    [XmlIgnore]
    public string MDataFimDaGarantiaDataX_DataHora => $"{m_FDataFimDaGarantia:dd/MM/yyyy HH:mm:ss}";

    [XmlIgnore]
    public string MDataFimDaGarantiaX_Hora => $"{m_FDataFimDaGarantia:HH:mm:ss}";

    [XmlIgnore]
    public string MValorBemStr { get => m_FValorBem.ToString("0.00"); set => FValorBem = DevourerOne.ConvertString2Decimal(value); }

    [XmlIgnore]
    public DateTime FDataTerminoDaGarantiaDaLojaWithHora
    {
        set
        {
            pFldFDataTerminoDaGarantiaDaLoja = true;
            m_FDataTerminoDaGarantiaDaLoja = value;
        }
    }

    [XmlIgnore]
    public string MDataTerminoDaGarantiaDaLojaDataX_DataHora => $"{m_FDataTerminoDaGarantiaDaLoja:dd/MM/yyyy HH:mm:ss}";

    [XmlIgnore]
    public string MDataTerminoDaGarantiaDaLojaX_Hora => $"{m_FDataTerminoDaGarantiaDaLoja:HH:mm:ss}";
#if (forWeb)
[XmlIgnore]
public string TRClick => DevourerOne.TableTrClick(ID, "BENSMATERIAISINC");
#endif
}