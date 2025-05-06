namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBPenhora
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFProcesso, pFldFNome, pFldFDescricao, pFldFDataPenhora, pFldFPenhoraStatus, pFldFMaster;
    [XmlIgnore]
    private protected int m_FProcesso, m_FPenhoraStatus, m_FMaster;
    [XmlIgnore]
    private protected string? m_FNome, m_FDescricao;
    [XmlIgnore]
    private protected DateTime? m_FDataPenhora;
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

    [XmlAttribute]
    public string? FDescricao
    {
        get => m_FDescricao ?? string.Empty;
        set
        {
            pFldFDescricao = pFldFDescricao || !(m_FDescricao ?? string.Empty).Equals(value);
            if (pFldFDescricao)
                m_FDescricao = value.trim().FixAbc() ?? string.Empty;
        }
    }

    [XmlIgnore]
    public DateTime MDataPenhora => Convert.ToDateTime(m_FDataPenhora);

    [XmlAttribute]
    public string? FDataPenhora
    {
        get => $"{m_FDataPenhora:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FDataPenhora:dd/MM/yyyy}";
        set
        {
            var(setUpNow, changed, data) = DevourerOne.DateUp7(pFldFDataPenhora, m_FDataPenhora, value);
            if (!setUpNow)
                return;
            pFldFDataPenhora = changed;
            m_FDataPenhora = data;
        }
    }

    [XmlAttribute]
    public int FPenhoraStatus
    {
        get => m_FPenhoraStatus;
        set
        {
            pFldFPenhoraStatus = pFldFPenhoraStatus || value != m_FPenhoraStatus;
            if (pFldFPenhoraStatus)
                m_FPenhoraStatus = value;
        }
    }

    [XmlAttribute]
    public int FMaster
    {
        get => m_FMaster;
        set
        {
            pFldFMaster = pFldFMaster || value != m_FMaster;
            if (pFldFMaster)
                m_FMaster = value;
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