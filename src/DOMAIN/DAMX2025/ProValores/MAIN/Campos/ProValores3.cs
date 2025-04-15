namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBProValores
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFProcesso, pFldFTipoValorProcesso, pFldFIndice, pFldFIgnorar, pFldFData, pFldFValorOriginal, pFldFPercMulta, pFldFValorMulta, pFldFPercJuros, pFldFValorOriginalCorrigidoIndice, pFldFValorMultaCorrigido, pFldFValorJurosCorrigido, pFldFValorFinal, pFldFDataUltimaCorrecao;
    [XmlIgnore]
    private protected int m_FProcesso, m_FTipoValorProcesso;
    [XmlIgnore]
    private protected string? m_FIndice;
    [XmlIgnore]
    private protected DateTime? m_FData, m_FDataUltimaCorrecao;
    [XmlIgnore]
    private protected bool m_FIgnorar;
    [XmlIgnore]
    private protected decimal m_FValorOriginal, m_FPercMulta, m_FValorMulta, m_FPercJuros, m_FValorOriginalCorrigidoIndice, m_FValorMultaCorrigido, m_FValorJurosCorrigido, m_FValorFinal;
    public int NFProcesso() => m_FProcesso;
    [XmlAttribute]
    public int FProcesso
    {
        get => m_FProcesso;
        set
        {
            pFldFProcesso = pFldFProcesso || value != m_FProcesso;
            if (pFldFProcesso)
                m_FProcesso = value;
        }
    }

    public int NFTipoValorProcesso() => m_FTipoValorProcesso;
    [XmlAttribute]
    public int FTipoValorProcesso
    {
        get => m_FTipoValorProcesso;
        set
        {
            pFldFTipoValorProcesso = pFldFTipoValorProcesso || value != m_FTipoValorProcesso;
            if (pFldFTipoValorProcesso)
                m_FTipoValorProcesso = value;
        }
    }

    public string NFIndice() => m_FIndice ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FIndice
    {
        get => m_FIndice ?? string.Empty;
        set
        {
            pFldFIndice = pFldFIndice || !(m_FIndice ?? string.Empty).Equals(value);
            if (pFldFIndice)
                m_FIndice = value.trim().Length > 20 ? value.trim().substring(0, 20) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public bool NFIgnorar() => m_FIgnorar;
    [XmlAttribute]
    public bool FIgnorar
    {
        get => m_FIgnorar;
        set
        {
            pFldFIgnorar = pFldFIgnorar || value != m_FIgnorar;
            if (pFldFIgnorar)
                m_FIgnorar = value;
        }
    }

    public string NFData() => $"{m_FData:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FData:dd/MM/yyyy}";
    [XmlIgnore]
    public DateTime MData => Convert.ToDateTime(m_FData);

    [XmlAttribute]
    public string? FData
    {
        get => $"{m_FData:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FData:dd/MM/yyyy}";
        set
        {
            var(setUpNow, changed, data) = DevourerOne.DateUp7(pFldFData, m_FData, value);
            if (!setUpNow)
                return;
            pFldFData = changed;
            m_FData = data;
        }
    }

    public decimal NFValorOriginal() => m_FValorOriginal;
    [XmlAttribute]
    public decimal FValorOriginal
    {
        get => m_FValorOriginal;
        set
        {
            if (value == m_FValorOriginal)
                return;
            pFldFValorOriginal = true;
            m_FValorOriginal = value;
        }
    }

    public decimal NFPercMulta() => m_FPercMulta;
    [XmlAttribute]
    public decimal FPercMulta
    {
        get => m_FPercMulta;
        set
        {
            if (value == m_FPercMulta)
                return;
            pFldFPercMulta = true;
            m_FPercMulta = value;
        }
    }

    public decimal NFValorMulta() => m_FValorMulta;
    [XmlAttribute]
    public decimal FValorMulta
    {
        get => m_FValorMulta;
        set
        {
            if (value == m_FValorMulta)
                return;
            pFldFValorMulta = true;
            m_FValorMulta = value;
        }
    }

    public decimal NFPercJuros() => m_FPercJuros;
    [XmlAttribute]
    public decimal FPercJuros
    {
        get => m_FPercJuros;
        set
        {
            if (value == m_FPercJuros)
                return;
            pFldFPercJuros = true;
            m_FPercJuros = value;
        }
    }

    public decimal NFValorOriginalCorrigidoIndice() => m_FValorOriginalCorrigidoIndice;
    [XmlAttribute]
    public decimal FValorOriginalCorrigidoIndice
    {
        get => m_FValorOriginalCorrigidoIndice;
        set
        {
            if (value == m_FValorOriginalCorrigidoIndice)
                return;
            pFldFValorOriginalCorrigidoIndice = true;
            m_FValorOriginalCorrigidoIndice = value;
        }
    }

    public decimal NFValorMultaCorrigido() => m_FValorMultaCorrigido;
    [XmlAttribute]
    public decimal FValorMultaCorrigido
    {
        get => m_FValorMultaCorrigido;
        set
        {
            if (value == m_FValorMultaCorrigido)
                return;
            pFldFValorMultaCorrigido = true;
            m_FValorMultaCorrigido = value;
        }
    }

    public decimal NFValorJurosCorrigido() => m_FValorJurosCorrigido;
    [XmlAttribute]
    public decimal FValorJurosCorrigido
    {
        get => m_FValorJurosCorrigido;
        set
        {
            if (value == m_FValorJurosCorrigido)
                return;
            pFldFValorJurosCorrigido = true;
            m_FValorJurosCorrigido = value;
        }
    }

    public decimal NFValorFinal() => m_FValorFinal;
    [XmlAttribute]
    public decimal FValorFinal
    {
        get => m_FValorFinal;
        set
        {
            if (value == m_FValorFinal)
                return;
            pFldFValorFinal = true;
            m_FValorFinal = value;
        }
    }

    public string NFDataUltimaCorrecao() => $"{m_FDataUltimaCorrecao:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FDataUltimaCorrecao:dd/MM/yyyy}";
    [XmlIgnore]
    public DateTime MDataUltimaCorrecao => Convert.ToDateTime(m_FDataUltimaCorrecao);

    [XmlAttribute]
    public string? FDataUltimaCorrecao
    {
        get => $"{m_FDataUltimaCorrecao:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FDataUltimaCorrecao:dd/MM/yyyy}";
        set
        {
            var(setUpNow, changed, data) = DevourerOne.DateUp7(pFldFDataUltimaCorrecao, m_FDataUltimaCorrecao, value);
            if (!setUpNow)
                return;
            pFldFDataUltimaCorrecao = changed;
            m_FDataUltimaCorrecao = data;
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
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public int GetID() => ID;
}