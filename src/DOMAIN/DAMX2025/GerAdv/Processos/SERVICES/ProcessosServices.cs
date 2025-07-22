// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public partial class DBProcessos
{
    [XmlIgnore]
    public string MValorProvisionadoStr { get => m_FValorProvisionado.ToString("0.00"); set => FValorProvisionado = DevourerOne.ConvertString2Decimal(value); }

    [XmlIgnore]
    public string MValorCacheCalculoStr { get => m_FValorCacheCalculo.ToString("0.00"); set => FValorCacheCalculo = DevourerOne.ConvertString2Decimal(value); }

    [XmlIgnore]
    public string MValorCacheCalculoProvStr { get => m_FValorCacheCalculoProv.ToString("0.00"); set => FValorCacheCalculoProv = DevourerOne.ConvertString2Decimal(value); }

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
    public string MHonorarioValorStr { get => m_FHonorarioValor.ToString("0.00"); set => FHonorarioValor = DevourerOne.ConvertString2Decimal(value); }

    [XmlIgnore]
    public string MHonorarioPercentualStr { get => m_FHonorarioPercentual.ToString("0.00"); set => FHonorarioPercentual = DevourerOne.ConvertString2Decimal(value); }

    [XmlIgnore]
    public string MHonorarioSucumbenciaStr { get => m_FHonorarioSucumbencia.ToString("0.00"); set => FHonorarioSucumbencia = DevourerOne.ConvertString2Decimal(value); }

    [XmlIgnore]
    public string MValorCondenacaoStr { get => m_FValorCondenacao.ToString("0.00"); set => FValorCondenacao = DevourerOne.ConvertString2Decimal(value); }

    [XmlIgnore]
    public string MValorCondenacaoCalculadoStr { get => m_FValorCondenacaoCalculado.ToString("0.00"); set => FValorCondenacaoCalculado = DevourerOne.ConvertString2Decimal(value); }
}