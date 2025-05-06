namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBBensMateriais
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFNome, pFldFBensClassificacao, pFldFDataCompra, pFldFDataFimDaGarantia, pFldFNFNRO, pFldFFornecedor, pFldFValorBem, pFldFNroSerieProduto, pFldFComprador, pFldFCidade, pFldFGarantiaLoja, pFldFDataTerminoDaGarantiaDaLoja, pFldFObservacoes, pFldFNomeVendedor, pFldFBold;
    [XmlIgnore]
    private protected int m_FBensClassificacao, m_FFornecedor, m_FCidade;
    [XmlIgnore]
    private protected string? m_FNome, m_FNFNRO, m_FNroSerieProduto, m_FComprador, m_FObservacoes, m_FNomeVendedor;
    [XmlIgnore]
    private protected DateTime? m_FDataCompra, m_FDataFimDaGarantia, m_FDataTerminoDaGarantiaDaLoja;
    [XmlIgnore]
    private protected bool m_FGarantiaLoja, m_FBold;
    [XmlIgnore]
    private protected decimal m_FValorBem;
    [XmlAttribute]
    public string? FNome
    {
        get => m_FNome ?? string.Empty;
        set
        {
            pFldFNome = pFldFNome || !(m_FNome ?? string.Empty).Equals(value);
            if (pFldFNome)
                m_FNome = value.trim().Length > 80 ? value.trim().substring(0, 80) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlAttribute]
    public int FBensClassificacao
    {
        get => m_FBensClassificacao;
        set
        {
            pFldFBensClassificacao = pFldFBensClassificacao || value != m_FBensClassificacao;
            if (pFldFBensClassificacao)
                m_FBensClassificacao = value;
        }
    }

    [XmlIgnore]
    public DateTime MDataCompra => Convert.ToDateTime(m_FDataCompra);

    [XmlAttribute]
    public string? FDataCompra
    {
        get => $"{m_FDataCompra:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FDataCompra:dd/MM/yyyy}";
        set
        {
            var(setUpNow, changed, data) = DevourerOne.DateUp7(pFldFDataCompra, m_FDataCompra, value);
            if (!setUpNow)
                return;
            pFldFDataCompra = changed;
            m_FDataCompra = data;
        }
    }

    [XmlIgnore]
    public DateTime MDataFimDaGarantia => Convert.ToDateTime(m_FDataFimDaGarantia);

    [XmlAttribute]
    public string? FDataFimDaGarantia
    {
        get => $"{m_FDataFimDaGarantia:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FDataFimDaGarantia:dd/MM/yyyy}";
        set
        {
            var(setUpNow, changed, data) = DevourerOne.DateUp7(pFldFDataFimDaGarantia, m_FDataFimDaGarantia, value);
            if (!setUpNow)
                return;
            pFldFDataFimDaGarantia = changed;
            m_FDataFimDaGarantia = data;
        }
    }

    [XmlAttribute]
    public string? FNFNRO
    {
        get => m_FNFNRO ?? string.Empty;
        set
        {
            pFldFNFNRO = pFldFNFNRO || !(m_FNFNRO ?? string.Empty).Equals(value);
            if (pFldFNFNRO)
                m_FNFNRO = value.trim().Length > 255 ? value.trim().substring(0, 255) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlAttribute]
    public int FFornecedor
    {
        get => m_FFornecedor;
        set
        {
            pFldFFornecedor = pFldFFornecedor || value != m_FFornecedor;
            if (pFldFFornecedor)
                m_FFornecedor = value;
        }
    }

    [XmlAttribute]
    public decimal FValorBem
    {
        get => m_FValorBem;
        set
        {
            if (value == m_FValorBem)
                return;
            pFldFValorBem = true;
            m_FValorBem = value;
        }
    }

    [XmlAttribute]
    public string? FNroSerieProduto
    {
        get => m_FNroSerieProduto ?? string.Empty;
        set
        {
            pFldFNroSerieProduto = pFldFNroSerieProduto || !(m_FNroSerieProduto ?? string.Empty).Equals(value);
            if (pFldFNroSerieProduto)
                m_FNroSerieProduto = value.trim().Length > 100 ? value.trim().substring(0, 100) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlAttribute]
    public string? FComprador
    {
        get => m_FComprador ?? string.Empty;
        set
        {
            pFldFComprador = pFldFComprador || !(m_FComprador ?? string.Empty).Equals(value);
            if (pFldFComprador)
                m_FComprador = value.trim().Length > 100 ? value.trim().substring(0, 100) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlAttribute]
    public int FCidade
    {
        get => m_FCidade;
        set
        {
            pFldFCidade = pFldFCidade || value != m_FCidade;
            if (pFldFCidade)
                m_FCidade = value;
        }
    }

    [XmlAttribute]
    public bool FGarantiaLoja
    {
        get => m_FGarantiaLoja;
        set
        {
            pFldFGarantiaLoja = pFldFGarantiaLoja || value != m_FGarantiaLoja;
            if (pFldFGarantiaLoja)
                m_FGarantiaLoja = value;
        }
    }

    [XmlIgnore]
    public DateTime MDataTerminoDaGarantiaDaLoja => Convert.ToDateTime(m_FDataTerminoDaGarantiaDaLoja);

    [XmlAttribute]
    public string? FDataTerminoDaGarantiaDaLoja
    {
        get => $"{m_FDataTerminoDaGarantiaDaLoja:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FDataTerminoDaGarantiaDaLoja:dd/MM/yyyy}";
        set
        {
            var(setUpNow, changed, data) = DevourerOne.DateUp7(pFldFDataTerminoDaGarantiaDaLoja, m_FDataTerminoDaGarantiaDaLoja, value);
            if (!setUpNow)
                return;
            pFldFDataTerminoDaGarantiaDaLoja = changed;
            m_FDataTerminoDaGarantiaDaLoja = data;
        }
    }

    [XmlAttribute]
    public string? FObservacoes
    {
        get => m_FObservacoes ?? string.Empty;
        set
        {
            pFldFObservacoes = pFldFObservacoes || !(m_FObservacoes ?? string.Empty).Equals(value);
            if (pFldFObservacoes)
                m_FObservacoes = value.trim().FixAbc() ?? string.Empty;
        }
    }

    [XmlAttribute]
    public string? FNomeVendedor
    {
        get => m_FNomeVendedor ?? string.Empty;
        set
        {
            pFldFNomeVendedor = pFldFNomeVendedor || !(m_FNomeVendedor ?? string.Empty).Equals(value);
            if (pFldFNomeVendedor)
                m_FNomeVendedor = value.trim().Length > 255 ? value.trim().substring(0, 255) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlAttribute]
    public bool FBold
    {
        get => m_FBold;
        set
        {
            pFldFBold = pFldFBold || value != m_FBold;
            if (pFldFBold)
                m_FBold = value;
        }
    }

    public bool IVisto() => m_FVisto;
    public int IQuemCad() => m_FQuemCad;
    public int IQuemAtu() => m_FQuemAtu;
    public DateTime IDtCad() => MDtCad;
    public DateTime IDtAtu() => MDtAtu;
    public string IDtCadDataX_DataHora() => MDtCadDataX_DataHora;
    public string IDtAtuDataX_DataHora() => MDtAtuDataX_DataHora;
    public void SetAuditor(int usuarioId) => AuditorQuem = usuarioId;
    public string IMDtCadDataX_DataHora() => MDtAtuDataX_DataHora;
    public string ITabelaName() => PTabelaNome;
    public string ICampoCodigo() => CampoCodigo;
    public string ICampoNome() => CampoNome;
    public string IPrefixo() => PTabelaPrefixo;
    public List<DBInfoSystem> IFieldsRaw() => throw new NotImplementedException();
    public List<DBInfoSystem> IPkFields() => throw new NotImplementedException();
    public List<DBInfoSystem> IPkIndicesFields() => throw new NotImplementedException();
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public int GetID() => ID;
}