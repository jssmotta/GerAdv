namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBLivroCaixa
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFIDDes, pFldFPessoal, pFldFAjuste, pFldFIDHon, pFldFIDHonParc, pFldFIDHonSuc, pFldFData, pFldFProcesso, pFldFValor, pFldFTipo, pFldFHistorico, pFldFPrevisto, pFldFGrupo;
    [XmlIgnore]
    private protected int m_FIDDes, m_FPessoal, m_FIDHon, m_FIDHonParc, m_FProcesso, m_FGrupo;
    [XmlIgnore]
    private protected string? m_FHistorico;
    [XmlIgnore]
    private protected DateTime? m_FData;
    [XmlIgnore]
    private protected bool m_FAjuste, m_FIDHonSuc, m_FTipo, m_FPrevisto;
    [XmlIgnore]
    private protected decimal m_FValor;
    [XmlAttribute]
    public int FIDDes
    {
        get => m_FIDDes;
        set
        {
            pFldFIDDes = pFldFIDDes || value != m_FIDDes;
            if (pFldFIDDes)
                m_FIDDes = value;
        }
    }

    [XmlAttribute]
    public int FPessoal
    {
        get => m_FPessoal;
        set
        {
            pFldFPessoal = pFldFPessoal || value != m_FPessoal;
            if (pFldFPessoal)
                m_FPessoal = value;
        }
    }

    [XmlAttribute]
    public bool FAjuste
    {
        get => m_FAjuste;
        set
        {
            pFldFAjuste = pFldFAjuste || value != m_FAjuste;
            if (pFldFAjuste)
                m_FAjuste = value;
        }
    }

    [XmlAttribute]
    public int FIDHon
    {
        get => m_FIDHon;
        set
        {
            pFldFIDHon = pFldFIDHon || value != m_FIDHon;
            if (pFldFIDHon)
                m_FIDHon = value;
        }
    }

    [XmlAttribute]
    public int FIDHonParc
    {
        get => m_FIDHonParc;
        set
        {
            pFldFIDHonParc = pFldFIDHonParc || value != m_FIDHonParc;
            if (pFldFIDHonParc)
                m_FIDHonParc = value;
        }
    }

    [XmlAttribute]
    public bool FIDHonSuc
    {
        get => m_FIDHonSuc;
        set
        {
            pFldFIDHonSuc = pFldFIDHonSuc || value != m_FIDHonSuc;
            if (pFldFIDHonSuc)
                m_FIDHonSuc = value;
        }
    }

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

    [XmlAttribute]
    public string? FHistorico
    {
        get => m_FHistorico ?? string.Empty;
        set
        {
            pFldFHistorico = pFldFHistorico || !(m_FHistorico ?? string.Empty).Equals(value);
            if (pFldFHistorico)
                m_FHistorico = value.trim().Length > 255 ? value.trim().substring(0, 255) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlAttribute]
    public bool FPrevisto
    {
        get => m_FPrevisto;
        set
        {
            pFldFPrevisto = pFldFPrevisto || value != m_FPrevisto;
            if (pFldFPrevisto)
                m_FPrevisto = value;
        }
    }

    [XmlAttribute]
    public int FGrupo
    {
        get => m_FGrupo;
        set
        {
            pFldFGrupo = pFldFGrupo || value != m_FGrupo;
            if (pFldFGrupo)
                m_FGrupo = value;
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