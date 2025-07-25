namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBNECompromissos
{
    [XmlIgnore]
    private protected bool pFldFPalavraChave, pFldFProvisionar, pFldFTipoCompromisso, pFldFTextoCompromisso, pFldFBold;
    [XmlIgnore]
    private protected int m_FPalavraChave, m_FTipoCompromisso;
    [XmlIgnore]
    private protected string? m_FTextoCompromisso;
    [XmlIgnore]
    private protected bool m_FProvisionar, m_FBold;
    public int FPalavraChave
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FPalavraChave;
        set
        {
            pFldFPalavraChave = pFldFPalavraChave || value != m_FPalavraChave;
            if (pFldFPalavraChave)
                m_FPalavraChave = value;
        }
    }

    public bool FProvisionar
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FProvisionar;
        set
        {
            pFldFProvisionar = pFldFProvisionar || value != m_FProvisionar;
            if (pFldFProvisionar)
                m_FProvisionar = value;
        }
    }

    public int FTipoCompromisso
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FTipoCompromisso;
        set
        {
            pFldFTipoCompromisso = pFldFTipoCompromisso || value != m_FTipoCompromisso;
            if (pFldFTipoCompromisso)
                m_FTipoCompromisso = value;
        }
    }

    public string? FTextoCompromisso
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FTextoCompromisso ?? string.Empty;
        set
        {
            pFldFTextoCompromisso = pFldFTextoCompromisso || !(m_FTextoCompromisso ?? string.Empty).Equals(value);
            if (pFldFTextoCompromisso)
                m_FTextoCompromisso = value.trim().FixAbc() ?? string.Empty;
        }
    }

    public bool FBold
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
    public ImmutableArray<DBInfoSystem> IFieldsRaw() => throw new NotImplementedException();
    public ImmutableArray<DBInfoSystem> IPkFields() => throw new NotImplementedException();
    public ImmutableArray<DBInfoSystem> IPkIndicesFields() => throw new NotImplementedException();
#pragma warning disable CA1822 // Mark members as static

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool HasAuditor() => true;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool HasNameId() => false;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int GetID() => ID;
}