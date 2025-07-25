namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBGUTAtividades
{
    [XmlIgnore]
    private protected bool pFldFNome, pFldFObservacao, pFldFGUTGrupo, pFldFGUTPeriodicidade, pFldFOperador, pFldFConcluido, pFldFDataConcluido, pFldFDiasParaIniciar, pFldFMinutosParaRealizar;
    [XmlIgnore]
    private protected int m_FGUTGrupo, m_FGUTPeriodicidade, m_FOperador, m_FDiasParaIniciar, m_FMinutosParaRealizar;
    [XmlIgnore]
    private protected string? m_FNome, m_FObservacao;
    [XmlIgnore]
    private protected DateTime? m_FDataConcluido;
    [XmlIgnore]
    private protected bool m_FConcluido;
    [StringLength(255, ErrorMessage = "A propriedade FNome da tabela GUTAtividades deve ter no máximo 255 caracteres.")]
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

    public string? FObservacao
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FObservacao ?? string.Empty;
        set
        {
            pFldFObservacao = pFldFObservacao || !(m_FObservacao ?? string.Empty).Equals(value);
            if (pFldFObservacao)
                m_FObservacao = value.trim().FixAbc() ?? string.Empty;
        }
    }

    public int FGUTGrupo
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FGUTGrupo;
        set
        {
            pFldFGUTGrupo = pFldFGUTGrupo || value != m_FGUTGrupo;
            if (pFldFGUTGrupo)
                m_FGUTGrupo = value;
        }
    }

    public int FGUTPeriodicidade
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FGUTPeriodicidade;
        set
        {
            pFldFGUTPeriodicidade = pFldFGUTPeriodicidade || value != m_FGUTPeriodicidade;
            if (pFldFGUTPeriodicidade)
                m_FGUTPeriodicidade = value;
        }
    }

    public int FOperador
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FOperador;
        set
        {
            pFldFOperador = pFldFOperador || value != m_FOperador;
            if (pFldFOperador)
                m_FOperador = value;
        }
    }

    public bool FConcluido
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FConcluido;
        set
        {
            pFldFConcluido = pFldFConcluido || value != m_FConcluido;
            if (pFldFConcluido)
                m_FConcluido = value;
        }
    }

    public string? FDataConcluido
    {
        get => $"{m_FDataConcluido:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FDataConcluido:dd/MM/yyyy}";
        set
        {
            var(setUpNow, changed, data) = DevourerOne.DateUp7(pFldFDataConcluido, m_FDataConcluido, value);
            if (!setUpNow)
                return;
            pFldFDataConcluido = changed;
            m_FDataConcluido = data;
        }
    }

    public int FDiasParaIniciar
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FDiasParaIniciar;
        set
        {
            pFldFDiasParaIniciar = pFldFDiasParaIniciar || value != m_FDiasParaIniciar;
            if (pFldFDiasParaIniciar)
                m_FDiasParaIniciar = value;
        }
    }

    public int FMinutosParaRealizar
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FMinutosParaRealizar;
        set
        {
            pFldFMinutosParaRealizar = pFldFMinutosParaRealizar || value != m_FMinutosParaRealizar;
            if (pFldFMinutosParaRealizar)
                m_FMinutosParaRealizar = value;
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