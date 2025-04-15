namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBProDespesas
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFLigacaoID, pFldFCliente, pFldFCorrigido, pFldFData, pFldFValorOriginal, pFldFProcesso, pFldFQuitado, pFldFDataCorrecao, pFldFValor, pFldFTipo, pFldFHistorico, pFldFLivroCaixa;
    [XmlIgnore]
    private protected int m_FLigacaoID, m_FCliente, m_FProcesso, m_FQuitado;
    [XmlIgnore]
    private protected string? m_FHistorico;
    [XmlIgnore]
    private protected DateTime? m_FData, m_FDataCorrecao;
    [XmlIgnore]
    private protected bool m_FCorrigido, m_FTipo, m_FLivroCaixa;
    [XmlIgnore]
    private protected decimal m_FValorOriginal, m_FValor;
    public int NFLigacaoID() => m_FLigacaoID;
    [XmlAttribute]
    public int FLigacaoID
    {
        get => m_FLigacaoID;
        set
        {
            pFldFLigacaoID = pFldFLigacaoID || value != m_FLigacaoID;
            if (pFldFLigacaoID)
                m_FLigacaoID = value;
        }
    }

    public int NFCliente() => m_FCliente;
    [XmlAttribute]
    public int FCliente
    {
        get => m_FCliente;
        set
        {
            pFldFCliente = pFldFCliente || value != m_FCliente;
            if (pFldFCliente)
                m_FCliente = value;
        }
    }

    public bool NFCorrigido() => m_FCorrigido;
    [XmlAttribute]
    public bool FCorrigido
    {
        get => m_FCorrigido;
        set
        {
            pFldFCorrigido = pFldFCorrigido || value != m_FCorrigido;
            if (pFldFCorrigido)
                m_FCorrigido = value;
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

    public int NFQuitado() => m_FQuitado;
    [XmlAttribute]
    public int FQuitado
    {
        get => m_FQuitado;
        set
        {
            pFldFQuitado = pFldFQuitado || value != m_FQuitado;
            if (pFldFQuitado)
                m_FQuitado = value;
        }
    }

    public string NFDataCorrecao() => $"{m_FDataCorrecao:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FDataCorrecao:dd/MM/yyyy}";
    [XmlIgnore]
    public DateTime MDataCorrecao => Convert.ToDateTime(m_FDataCorrecao);

    [XmlAttribute]
    public string? FDataCorrecao
    {
        get => $"{m_FDataCorrecao:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FDataCorrecao:dd/MM/yyyy}";
        set
        {
            var(setUpNow, changed, data) = DevourerOne.DateUp7(pFldFDataCorrecao, m_FDataCorrecao, value);
            if (!setUpNow)
                return;
            pFldFDataCorrecao = changed;
            m_FDataCorrecao = data;
        }
    }

    public decimal NFValor() => m_FValor;
    [XmlAttribute]
    public decimal FValor
    {
        get => m_FValor;
        set
        {
            if (value == m_FValor)
                return;
            pFldFValor = true;
            m_FValor = value;
        }
    }

    public bool NFTipo() => m_FTipo;
    [XmlAttribute]
    public bool FTipo
    {
        get => m_FTipo;
        set
        {
            pFldFTipo = pFldFTipo || value != m_FTipo;
            if (pFldFTipo)
                m_FTipo = value;
        }
    }

    public string NFHistorico() => m_FHistorico ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FHistorico
    {
        get => m_FHistorico ?? string.Empty;
        set
        {
            pFldFHistorico = pFldFHistorico || !(m_FHistorico ?? string.Empty).Equals(value);
            if (pFldFHistorico)
                m_FHistorico = value.trim().Length > 100 ? value.trim().substring(0, 100) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public bool NFLivroCaixa() => m_FLivroCaixa;
    [XmlAttribute]
    public bool FLivroCaixa
    {
        get => m_FLivroCaixa;
        set
        {
            pFldFLivroCaixa = pFldFLivroCaixa || value != m_FLivroCaixa;
            if (pFldFLivroCaixa)
                m_FLivroCaixa = value;
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