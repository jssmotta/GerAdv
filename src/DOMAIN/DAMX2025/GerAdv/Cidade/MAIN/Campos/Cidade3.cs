namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBCidade
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFDDD, pFldFTop, pFldFComarca, pFldFCapital, pFldFNome, pFldFUF, pFldFSigla;
    [XmlIgnore]
    private protected int m_FUF;
    [XmlIgnore]
    private protected string? m_FDDD, m_FNome, m_FSigla;
    [XmlIgnore]
    private protected bool m_FTop, m_FComarca, m_FCapital;
    public string? FDDD
    {
        get => m_FDDD ?? string.Empty;
        set
        {
            pFldFDDD = pFldFDDD || !(m_FDDD ?? string.Empty).Equals(value);
            if (pFldFDDD)
                m_FDDD = value.trim().Length > 10 ? value.trim().substring(0, 10) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public bool FTop
    {
        get => m_FTop;
        set
        {
            pFldFTop = pFldFTop || value != m_FTop;
            if (pFldFTop)
                m_FTop = value;
        }
    }

    public bool FComarca
    {
        get => m_FComarca;
        set
        {
            pFldFComarca = pFldFComarca || value != m_FComarca;
            if (pFldFComarca)
                m_FComarca = value;
        }
    }

    public bool FCapital
    {
        get => m_FCapital;
        set
        {
            pFldFCapital = pFldFCapital || value != m_FCapital;
            if (pFldFCapital)
                m_FCapital = value;
        }
    }

    public string? FNome
    {
        get => m_FNome ?? string.Empty;
        set
        {
            pFldFNome = pFldFNome || !(m_FNome ?? string.Empty).Equals(value);
            if (pFldFNome)
                m_FNome = value.trim().Length > 40 ? value.trim().substring(0, 40) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public int FUF
    {
        get => m_FUF;
        set
        {
            pFldFUF = pFldFUF || value != m_FUF;
            if (pFldFUF)
                m_FUF = value;
        }
    }

    public string? FSigla
    {
        get => m_FSigla ?? string.Empty;
        set
        {
            pFldFSigla = pFldFSigla || !(m_FSigla ?? string.Empty).Equals(value);
            if (pFldFSigla)
                m_FSigla = value.trim().Length > 10 ? value.trim().substring(0, 10) : value.trim(); // ABC_FIND_CODE123
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