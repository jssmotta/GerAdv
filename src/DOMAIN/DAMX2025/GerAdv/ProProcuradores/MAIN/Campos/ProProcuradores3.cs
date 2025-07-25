namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBProProcuradores
{
    [XmlIgnore]
    private protected bool pFldFAdvogado, pFldFNome, pFldFProcesso, pFldFData, pFldFSubstabelecimento, pFldFProcuracao, pFldFBold;
    [XmlIgnore]
    private protected int m_FAdvogado, m_FProcesso;
    [XmlIgnore]
    private protected string? m_FNome;
    [XmlIgnore]
    private protected DateTime? m_FData;
    [XmlIgnore]
    private protected bool m_FSubstabelecimento, m_FProcuracao, m_FBold;
    public int FAdvogado
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FAdvogado;
        set
        {
            pFldFAdvogado = pFldFAdvogado || value != m_FAdvogado;
            if (pFldFAdvogado)
                m_FAdvogado = value;
        }
    }

    [StringLength(255, ErrorMessage = "A propriedade FNome da tabela ProProcuradores deve ter no máximo 255 caracteres.")]
    public string? FNome
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FNome ?? string.Empty;
        set
        {
            pFldFNome = pFldFNome || !(m_FNome ?? string.Empty).Equals(value);
            if (pFldFNome)
            {
                var trimmed = value?.Trim() ?? string.Empty;
                m_FNome = trimmed.Length > 255 ? trimmed.AsSpan(0, 255).ToString() : trimmed;
            }
        }
    }

    public int FProcesso
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FProcesso;
        set
        {
            pFldFProcesso = pFldFProcesso || value != m_FProcesso;
            if (pFldFProcesso)
                m_FProcesso = value;
        }
    }

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

    public bool FSubstabelecimento
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FSubstabelecimento;
        set
        {
            pFldFSubstabelecimento = pFldFSubstabelecimento || value != m_FSubstabelecimento;
            if (pFldFSubstabelecimento)
                m_FSubstabelecimento = value;
        }
    }

    public bool FProcuracao
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FProcuracao;
        set
        {
            pFldFProcuracao = pFldFProcuracao || value != m_FProcuracao;
            if (pFldFProcuracao)
                m_FProcuracao = value;
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
    public bool HasNameId() => true;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int GetID() => ID;
}