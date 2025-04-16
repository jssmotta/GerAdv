namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBNECompromissos
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFPalavraChave, pFldFProvisionar, pFldFTipoCompromisso, pFldFTextoCompromisso, pFldFBold;
    [XmlIgnore]
    private protected int m_FPalavraChave, m_FTipoCompromisso;
    [XmlIgnore]
    private protected string? m_FTextoCompromisso;
    [XmlIgnore]
    private protected bool m_FProvisionar, m_FBold;
    public int NFPalavraChave() => m_FPalavraChave;
    [XmlAttribute]
    public int FPalavraChave
    {
        get => m_FPalavraChave;
        set
        {
            pFldFPalavraChave = pFldFPalavraChave || value != m_FPalavraChave;
            if (pFldFPalavraChave)
                m_FPalavraChave = value;
        }
    }

    public bool NFProvisionar() => m_FProvisionar;
    [XmlAttribute]
    public bool FProvisionar
    {
        get => m_FProvisionar;
        set
        {
            pFldFProvisionar = pFldFProvisionar || value != m_FProvisionar;
            if (pFldFProvisionar)
                m_FProvisionar = value;
        }
    }

    public int NFTipoCompromisso() => m_FTipoCompromisso;
    [XmlAttribute]
    public int FTipoCompromisso
    {
        get => m_FTipoCompromisso;
        set
        {
            pFldFTipoCompromisso = pFldFTipoCompromisso || value != m_FTipoCompromisso;
            if (pFldFTipoCompromisso)
                m_FTipoCompromisso = value;
        }
    }

    public string NFTextoCompromisso() => m_FTextoCompromisso ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FTextoCompromisso
    {
        get => m_FTextoCompromisso ?? string.Empty;
        set
        {
            pFldFTextoCompromisso = pFldFTextoCompromisso || !(m_FTextoCompromisso ?? string.Empty).Equals(value);
            if (pFldFTextoCompromisso)
                m_FTextoCompromisso = value.trim().FixAbc() ?? string.Empty;
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