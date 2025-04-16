namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBSituacao
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFParte_Int, pFldFParte_Opo, pFldFTop, pFldFBold;
    [XmlIgnore]
    private protected string? m_FParte_Int, m_FParte_Opo;
    [XmlIgnore]
    private protected bool m_FTop, m_FBold;
    public string NFParte_Int() => m_FParte_Int ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FParte_Int
    {
        get => m_FParte_Int ?? string.Empty;
        set
        {
            pFldFParte_Int = pFldFParte_Int || !(m_FParte_Int ?? string.Empty).Equals(value);
            if (pFldFParte_Int)
                m_FParte_Int = value.trim().Length > 30 ? value.trim().substring(0, 30) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public string NFParte_Opo() => m_FParte_Opo ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FParte_Opo
    {
        get => m_FParte_Opo ?? string.Empty;
        set
        {
            pFldFParte_Opo = pFldFParte_Opo || !(m_FParte_Opo ?? string.Empty).Equals(value);
            if (pFldFParte_Opo)
                m_FParte_Opo = value.trim().Length > 30 ? value.trim().substring(0, 30) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public bool NFTop() => m_FTop;
    [XmlAttribute]
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

    public bool NFBold() => m_FBold;
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