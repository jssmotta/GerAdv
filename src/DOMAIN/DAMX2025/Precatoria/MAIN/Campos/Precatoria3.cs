namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBPrecatoria
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFDtDist, pFldFProcesso, pFldFPrecatoria, pFldFDeprecante, pFldFDeprecado, pFldFOBS, pFldFBold;
    [XmlIgnore]
    private protected int m_FProcesso;
    [XmlIgnore]
    private protected string? m_FPrecatoria, m_FDeprecante, m_FDeprecado, m_FOBS;
    [XmlIgnore]
    private protected DateTime? m_FDtDist;
    [XmlIgnore]
    private protected bool m_FBold;
    [XmlIgnore]
    public DateTime MDtDist => Convert.ToDateTime(m_FDtDist);

    [XmlAttribute]
    public string? FDtDist
    {
        get => $"{m_FDtDist:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FDtDist:dd/MM/yyyy}";
        set
        {
            var(setUpNow, changed, data) = DevourerOne.DateUp7(pFldFDtDist, m_FDtDist, value);
            if (!setUpNow)
                return;
            pFldFDtDist = changed;
            m_FDtDist = data;
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
    public string? FPrecatoria
    {
        get => m_FPrecatoria ?? string.Empty;
        set
        {
            pFldFPrecatoria = pFldFPrecatoria || !(m_FPrecatoria ?? string.Empty).Equals(value);
            if (pFldFPrecatoria)
                m_FPrecatoria = value.trim().Length > 25 ? value.trim().substring(0, 25) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlAttribute]
    public string? FDeprecante
    {
        get => m_FDeprecante ?? string.Empty;
        set
        {
            pFldFDeprecante = pFldFDeprecante || !(m_FDeprecante ?? string.Empty).Equals(value);
            if (pFldFDeprecante)
                m_FDeprecante = value.trim().Length > 60 ? value.trim().substring(0, 60) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlAttribute]
    public string? FDeprecado
    {
        get => m_FDeprecado ?? string.Empty;
        set
        {
            pFldFDeprecado = pFldFDeprecado || !(m_FDeprecado ?? string.Empty).Equals(value);
            if (pFldFDeprecado)
                m_FDeprecado = value.trim().Length > 60 ? value.trim().substring(0, 60) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlAttribute]
    public string? FOBS
    {
        get => m_FOBS ?? string.Empty;
        set
        {
            pFldFOBS = pFldFOBS || !(m_FOBS ?? string.Empty).Equals(value);
            if (pFldFOBS)
                m_FOBS = value.trim().FixAbc() ?? string.Empty;
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
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public int GetID() => ID;
}