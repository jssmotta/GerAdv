namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBPrecatoria
{
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

    [StringLength(25, ErrorMessage = "A propriedade FPrecatoria da tabela Precatoria deve ter no máximo 25 caracteres.")]
    public string? FPrecatoria
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FPrecatoria ?? string.Empty;
        set
        {
            pFldFPrecatoria = pFldFPrecatoria || !(m_FPrecatoria ?? string.Empty).Equals(value);
            if (pFldFPrecatoria)
            {
                var trimmed = value?.Trim() ?? string.Empty;
                m_FPrecatoria = trimmed.Length > 25 ? trimmed.AsSpan(0, 25).ToString() : trimmed;
            }
        }
    }

    [StringLength(60, ErrorMessage = "A propriedade FDeprecante da tabela Precatoria deve ter no máximo 60 caracteres.")]
    public string? FDeprecante
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FDeprecante ?? string.Empty;
        set
        {
            pFldFDeprecante = pFldFDeprecante || !(m_FDeprecante ?? string.Empty).Equals(value);
            if (pFldFDeprecante)
            {
                var trimmed = value?.Trim() ?? string.Empty;
                m_FDeprecante = trimmed.Length > 60 ? trimmed.AsSpan(0, 60).ToString() : trimmed;
            }
        }
    }

    [StringLength(60, ErrorMessage = "A propriedade FDeprecado da tabela Precatoria deve ter no máximo 60 caracteres.")]
    public string? FDeprecado
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FDeprecado ?? string.Empty;
        set
        {
            pFldFDeprecado = pFldFDeprecado || !(m_FDeprecado ?? string.Empty).Equals(value);
            if (pFldFDeprecado)
            {
                var trimmed = value?.Trim() ?? string.Empty;
                m_FDeprecado = trimmed.Length > 60 ? trimmed.AsSpan(0, 60).ToString() : trimmed;
            }
        }
    }

    public string? FOBS
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FOBS ?? string.Empty;
        set
        {
            pFldFOBS = pFldFOBS || !(m_FOBS ?? string.Empty).Equals(value);
            if (pFldFOBS)
                m_FOBS = value.trim().FixAbc() ?? string.Empty;
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