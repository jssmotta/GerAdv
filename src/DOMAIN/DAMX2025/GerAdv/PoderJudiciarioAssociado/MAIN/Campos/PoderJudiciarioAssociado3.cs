namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBPoderJudiciarioAssociado
{
    [XmlIgnore]
    private protected bool pFldFJustica, pFldFJusticaNome, pFldFArea, pFldFAreaNome, pFldFTribunal, pFldFTribunalNome, pFldFForo, pFldFForoNome, pFldFCidade, pFldFSubDivisaoNome, pFldFCidadeNome, pFldFSubDivisao, pFldFTipo;
    [XmlIgnore]
    private protected int m_FJustica, m_FArea, m_FTribunal, m_FForo, m_FCidade, m_FSubDivisao, m_FTipo;
    [XmlIgnore]
    private protected string? m_FJusticaNome, m_FAreaNome, m_FTribunalNome, m_FForoNome, m_FSubDivisaoNome, m_FCidadeNome;
    public int FJustica
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FJustica;
        set
        {
            pFldFJustica = pFldFJustica || value != m_FJustica;
            if (pFldFJustica)
                m_FJustica = value;
        }
    }

    [StringLength(255, ErrorMessage = "A propriedade FJusticaNome da tabela PoderJudiciarioAssociado deve ter no máximo 255 caracteres.")]
    public string? FJusticaNome
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FJusticaNome ?? string.Empty;
        set
        {
            pFldFJusticaNome = pFldFJusticaNome || !(m_FJusticaNome ?? string.Empty).Equals(value);
            if (pFldFJusticaNome)
            {
                var trimmed = value?.Trim() ?? string.Empty;
                m_FJusticaNome = trimmed.Length > 255 ? trimmed.AsSpan(0, 255).ToString() : trimmed;
            }
        }
    }

    public int FArea
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FArea;
        set
        {
            pFldFArea = pFldFArea || value != m_FArea;
            if (pFldFArea)
                m_FArea = value;
        }
    }

    [StringLength(255, ErrorMessage = "A propriedade FAreaNome da tabela PoderJudiciarioAssociado deve ter no máximo 255 caracteres.")]
    public string? FAreaNome
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FAreaNome ?? string.Empty;
        set
        {
            pFldFAreaNome = pFldFAreaNome || !(m_FAreaNome ?? string.Empty).Equals(value);
            if (pFldFAreaNome)
            {
                var trimmed = value?.Trim() ?? string.Empty;
                m_FAreaNome = trimmed.Length > 255 ? trimmed.AsSpan(0, 255).ToString() : trimmed;
            }
        }
    }

    public int FTribunal
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FTribunal;
        set
        {
            pFldFTribunal = pFldFTribunal || value != m_FTribunal;
            if (pFldFTribunal)
                m_FTribunal = value;
        }
    }

    [StringLength(255, ErrorMessage = "A propriedade FTribunalNome da tabela PoderJudiciarioAssociado deve ter no máximo 255 caracteres.")]
    public string? FTribunalNome
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FTribunalNome ?? string.Empty;
        set
        {
            pFldFTribunalNome = pFldFTribunalNome || !(m_FTribunalNome ?? string.Empty).Equals(value);
            if (pFldFTribunalNome)
            {
                var trimmed = value?.Trim() ?? string.Empty;
                m_FTribunalNome = trimmed.Length > 255 ? trimmed.AsSpan(0, 255).ToString() : trimmed;
            }
        }
    }

    public int FForo
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FForo;
        set
        {
            pFldFForo = pFldFForo || value != m_FForo;
            if (pFldFForo)
                m_FForo = value;
        }
    }

    [StringLength(255, ErrorMessage = "A propriedade FForoNome da tabela PoderJudiciarioAssociado deve ter no máximo 255 caracteres.")]
    public string? FForoNome
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FForoNome ?? string.Empty;
        set
        {
            pFldFForoNome = pFldFForoNome || !(m_FForoNome ?? string.Empty).Equals(value);
            if (pFldFForoNome)
            {
                var trimmed = value?.Trim() ?? string.Empty;
                m_FForoNome = trimmed.Length > 255 ? trimmed.AsSpan(0, 255).ToString() : trimmed;
            }
        }
    }

    public int FCidade
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FCidade;
        set
        {
            pFldFCidade = pFldFCidade || value != m_FCidade;
            if (pFldFCidade)
                m_FCidade = value;
        }
    }

    [StringLength(255, ErrorMessage = "A propriedade FSubDivisaoNome da tabela PoderJudiciarioAssociado deve ter no máximo 255 caracteres.")]
    public string? FSubDivisaoNome
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FSubDivisaoNome ?? string.Empty;
        set
        {
            pFldFSubDivisaoNome = pFldFSubDivisaoNome || !(m_FSubDivisaoNome ?? string.Empty).Equals(value);
            if (pFldFSubDivisaoNome)
            {
                var trimmed = value?.Trim() ?? string.Empty;
                m_FSubDivisaoNome = trimmed.Length > 255 ? trimmed.AsSpan(0, 255).ToString() : trimmed;
            }
        }
    }

    [StringLength(255, ErrorMessage = "A propriedade FCidadeNome da tabela PoderJudiciarioAssociado deve ter no máximo 255 caracteres.")]
    public string? FCidadeNome
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FCidadeNome ?? string.Empty;
        set
        {
            pFldFCidadeNome = pFldFCidadeNome || !(m_FCidadeNome ?? string.Empty).Equals(value);
            if (pFldFCidadeNome)
            {
                var trimmed = value?.Trim() ?? string.Empty;
                m_FCidadeNome = trimmed.Length > 255 ? trimmed.AsSpan(0, 255).ToString() : trimmed;
            }
        }
    }

    public int FSubDivisao
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FSubDivisao;
        set
        {
            pFldFSubDivisao = pFldFSubDivisao || value != m_FSubDivisao;
            if (pFldFSubDivisao)
                m_FSubDivisao = value;
        }
    }

    public int FTipo
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FTipo;
        set
        {
            pFldFTipo = pFldFTipo || value != m_FTipo;
            if (pFldFTipo)
                m_FTipo = value;
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