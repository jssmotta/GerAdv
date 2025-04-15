// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBProcessos
{
    [XmlIgnore]
    public string MValorProvisionadoStr { get => m_FValorProvisionado.ToString("0.00"); set => FValorProvisionado = DevourerOne.ConvertString2Decimal(value); }

    [XmlIgnore]
    public string MValorCacheCalculoStr { get => m_FValorCacheCalculo.ToString("0.00"); set => FValorCacheCalculo = DevourerOne.ConvertString2Decimal(value); }

    [XmlIgnore]
    public string MValorCacheCalculoProvStr { get => m_FValorCacheCalculoProv.ToString("0.00"); set => FValorCacheCalculoProv = DevourerOne.ConvertString2Decimal(value); }

    [XmlIgnore]
    public DateTime FDataEntradaWithHora
    {
        set
        {
            pFldFDataEntrada = true;
            m_FDataEntrada = value;
        }
    }

    [XmlIgnore]
    public string MDataEntradaDataX_DataHora => $"{m_FDataEntrada:dd/MM/yyyy HH:mm:ss}";

    [XmlIgnore]
    public string MDataEntradaX_Hora => $"{m_FDataEntrada:HH:mm:ss}";

    [XmlIgnore]
    public string MValorCausaInicialStr { get => m_FValorCausaInicial.ToString("0.00"); set => FValorCausaInicial = DevourerOne.ConvertString2Decimal(value); }

    [XmlIgnore]
    public string MValorCausaDefinitivoStr { get => m_FValorCausaDefinitivo.ToString("0.00"); set => FValorCausaDefinitivo = DevourerOne.ConvertString2Decimal(value); }

    [XmlIgnore]
    public string MPercProbExitoStr { get => m_FPercProbExito.ToString("0.00"); set => FPercProbExito = DevourerOne.ConvertString2Decimal(value); }

    [XmlIgnore]
    public string MPercExitoStr { get => m_FPercExito.ToString("0.00"); set => FPercExito = DevourerOne.ConvertString2Decimal(value); }

    [XmlIgnore]
    public string MValorStr { get => m_FValor.ToString("0.00"); set => FValor = DevourerOne.ConvertString2Decimal(value); }

    [XmlIgnore]
    public DateTime FDtBaixaWithHora
    {
        set
        {
            pFldFDtBaixa = true;
            m_FDtBaixa = value;
        }
    }

    [XmlIgnore]
    public string MDtBaixaDataX_DataHora => $"{m_FDtBaixa:dd/MM/yyyy HH:mm:ss}";

    [XmlIgnore]
    public string MDtBaixaX_Hora => $"{m_FDtBaixa:HH:mm:ss}";

    [XmlIgnore]
    public DateTime FZKeyQuandoWithHora
    {
        set
        {
            pFldFZKeyQuando = true;
            m_FZKeyQuando = value;
        }
    }

    [XmlIgnore]
    public string MZKeyQuandoDataX_DataHora => $"{m_FZKeyQuando:dd/MM/yyyy HH:mm:ss}";

    [XmlIgnore]
    public string MZKeyQuandoX_Hora => $"{m_FZKeyQuando:HH:mm:ss}";

    [XmlIgnore]
    public string MHonorarioValorStr { get => m_FHonorarioValor.ToString("0.00"); set => FHonorarioValor = DevourerOne.ConvertString2Decimal(value); }

    [XmlIgnore]
    public string MHonorarioPercentualStr { get => m_FHonorarioPercentual.ToString("0.00"); set => FHonorarioPercentual = DevourerOne.ConvertString2Decimal(value); }

    [XmlIgnore]
    public string MHonorarioSucumbenciaStr { get => m_FHonorarioSucumbencia.ToString("0.00"); set => FHonorarioSucumbencia = DevourerOne.ConvertString2Decimal(value); }

    [XmlIgnore]
    public string MValorCondenacaoStr { get => m_FValorCondenacao.ToString("0.00"); set => FValorCondenacao = DevourerOne.ConvertString2Decimal(value); }

    [XmlIgnore]
    public string MValorCondenacaoCalculadoStr { get => m_FValorCondenacaoCalculado.ToString("0.00"); set => FValorCondenacaoCalculado = DevourerOne.ConvertString2Decimal(value); }
#if (forWeb)
[XmlIgnore]
public string TRClick => DevourerOne.TableTrClick(ID, "PROCESSOSINC");
#endif
}