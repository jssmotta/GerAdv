namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBPenhora
{
    [XmlIgnore]
    private protected bool pFldFProcesso, pFldFNome, pFldFDescricao, pFldFDataPenhora, pFldFPenhoraStatus, pFldFMaster;
    [XmlIgnore]
    private protected int m_FProcesso, m_FPenhoraStatus, m_FMaster;
    [XmlIgnore]
    private protected string? m_FNome, m_FDescricao;
    [XmlIgnore]
    private protected DateTime? m_FDataPenhora;
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

    [StringLength(255, ErrorMessage = "A propriedade FNome da tabela Penhora deve ter no máximo 255 caracteres.")]
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

    public string? FDescricao
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FDescricao ?? string.Empty;
        set
        {
            pFldFDescricao = pFldFDescricao || !(m_FDescricao ?? string.Empty).Equals(value);
            if (pFldFDescricao)
                m_FDescricao = value.trim().FixAbc() ?? string.Empty;
        }
    }

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

    public int FPenhoraStatus
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FPenhoraStatus;
        set
        {
            pFldFPenhoraStatus = pFldFPenhoraStatus || value != m_FPenhoraStatus;
            if (pFldFPenhoraStatus)
                m_FPenhoraStatus = value;
        }
    }

    public int FMaster
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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