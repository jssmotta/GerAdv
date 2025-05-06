namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBProResumos
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFProcesso, pFldFData, pFldFResumo, pFldFTipoResumo, pFldFBold;
    [XmlIgnore]
    private protected int m_FProcesso, m_FTipoResumo;
    [XmlIgnore]
    private protected string? m_FResumo;
    [XmlIgnore]
    private protected DateTime? m_FData;
    [XmlIgnore]
    private protected bool m_FBold;
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
    public string? FResumo
    {
        get => m_FResumo ?? string.Empty;
        set
        {
            pFldFResumo = pFldFResumo || !(m_FResumo ?? string.Empty).Equals(value);
            if (pFldFResumo)
                m_FResumo = value.trim().FixAbc() ?? string.Empty;
        }
    }

    [XmlAttribute]
    public int FTipoResumo
    {
        get => m_FTipoResumo;
        set
        {
            pFldFTipoResumo = pFldFTipoResumo || value != m_FTipoResumo;
            if (pFldFTipoResumo)
                m_FTipoResumo = value;
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