namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBApenso
{
    [XmlIgnore]
    private protected bool pFldFProcesso, pFldFApenso, pFldFAcao, pFldFDtDist, pFldFOBS, pFldFValorCausa;
    [XmlIgnore]
    private protected int m_FProcesso;
    [XmlIgnore]
    private protected string? m_FApenso, m_FAcao, m_FOBS;
    [XmlIgnore]
    private protected DateTime? m_FDtDist;
    [XmlIgnore]
    private protected decimal m_FValorCausa;
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

    [StringLength(25, ErrorMessage = "A propriedade FApenso da tabela Apenso deve ter no máximo 25 caracteres.")]
    public string? FApenso
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FApenso ?? string.Empty;
        set
        {
            pFldFApenso = pFldFApenso || !(m_FApenso ?? string.Empty).Equals(value);
            if (pFldFApenso)
            {
                var trimmed = value?.Trim() ?? string.Empty;
                m_FApenso = trimmed.Length > 25 ? trimmed.AsSpan(0, 25).ToString() : trimmed;
            }
        }
    }

    [StringLength(25, ErrorMessage = "A propriedade FAcao da tabela Apenso deve ter no máximo 25 caracteres.")]
    public string? FAcao
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FAcao ?? string.Empty;
        set
        {
            pFldFAcao = pFldFAcao || !(m_FAcao ?? string.Empty).Equals(value);
            if (pFldFAcao)
            {
                var trimmed = value?.Trim() ?? string.Empty;
                m_FAcao = trimmed.Length > 25 ? trimmed.AsSpan(0, 25).ToString() : trimmed;
            }
        }
    }

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

    public decimal FValorCausa
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FValorCausa;
        set
        {
            if (value == m_FValorCausa)
                return;
            pFldFValorCausa = true;
            m_FValorCausa = value;
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