namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBAndamentosMD
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFNome, pFldFProcesso, pFldFAndamento, pFldFPathFull, pFldFUNC;
    [XmlIgnore]
    private protected int m_FProcesso, m_FAndamento;
    [XmlIgnore]
    private protected string? m_FNome, m_FPathFull, m_FUNC;
    public string NFNome() => m_FNome ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FNome
    {
        get => m_FNome ?? string.Empty;
        set
        {
            pFldFNome = pFldFNome || !(m_FNome ?? string.Empty).Equals(value);
            if (pFldFNome)
                m_FNome = value.trim().Length > 255 ? value.trim().substring(0, 255) : value.trim(); // ABC_FIND_CODE123
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

    public int NFAndamento() => m_FAndamento;
    [XmlAttribute]
    public int FAndamento
    {
        get => m_FAndamento;
        set
        {
            pFldFAndamento = pFldFAndamento || value != m_FAndamento;
            if (pFldFAndamento)
                m_FAndamento = value;
        }
    }

    public string NFPathFull() => m_FPathFull ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FPathFull
    {
        get => m_FPathFull ?? string.Empty;
        set
        {
            pFldFPathFull = pFldFPathFull || !(m_FPathFull ?? string.Empty).Equals(value);
            if (pFldFPathFull)
                m_FPathFull = value.trim().FixAbc() ?? string.Empty;
        }
    }

    public string NFUNC() => m_FUNC ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FUNC
    {
        get => m_FUNC ?? string.Empty;
        set
        {
            pFldFUNC = pFldFUNC || !(m_FUNC ?? string.Empty).Equals(value);
            if (pFldFUNC)
                m_FUNC = value.trim().FixAbc() ?? string.Empty;
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