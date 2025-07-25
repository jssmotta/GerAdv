namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBTribunal
{
    [XmlIgnore]
    private protected bool pFldFNome, pFldFArea, pFldFJustica, pFldFDescricao, pFldFInstancia, pFldFSigla, pFldFWeb, pFldFEtiqueta, pFldFBold;
    [XmlIgnore]
    private protected int m_FArea, m_FJustica, m_FInstancia;
    [XmlIgnore]
    private protected string? m_FNome, m_FDescricao, m_FSigla, m_FWeb;
    [XmlIgnore]
    private protected bool m_FEtiqueta, m_FBold;
    [StringLength(50, ErrorMessage = "A propriedade FNome da tabela Tribunal deve ter no máximo 50 caracteres.")]
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
                m_FNome = trimmed.Length > 50 ? trimmed.AsSpan(0, 50).ToString() : trimmed;
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

    [StringLength(50, ErrorMessage = "A propriedade FDescricao da tabela Tribunal deve ter no máximo 50 caracteres.")]
    public string? FDescricao
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FDescricao ?? string.Empty;
        set
        {
            pFldFDescricao = pFldFDescricao || !(m_FDescricao ?? string.Empty).Equals(value);
            if (pFldFDescricao)
            {
                var trimmed = value?.Trim() ?? string.Empty;
                m_FDescricao = trimmed.Length > 50 ? trimmed.AsSpan(0, 50).ToString() : trimmed;
            }
        }
    }

    public int FInstancia
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FInstancia;
        set
        {
            pFldFInstancia = pFldFInstancia || value != m_FInstancia;
            if (pFldFInstancia)
                m_FInstancia = value;
        }
    }

    [StringLength(20, ErrorMessage = "A propriedade FSigla da tabela Tribunal deve ter no máximo 20 caracteres.")]
    public string? FSigla
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FSigla ?? string.Empty;
        set
        {
            pFldFSigla = pFldFSigla || !(m_FSigla ?? string.Empty).Equals(value);
            if (pFldFSigla)
            {
                var trimmed = value?.Trim() ?? string.Empty;
                m_FSigla = trimmed.Length > 20 ? trimmed.AsSpan(0, 20).ToString() : trimmed;
            }
        }
    }

    [StringLength(255, ErrorMessage = "A propriedade FWeb da tabela Tribunal deve ter no máximo 255 caracteres.")]
    public string? FWeb
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FWeb ?? string.Empty;
        set
        {
            pFldFWeb = pFldFWeb || !(m_FWeb ?? string.Empty).Equals(value);
            if (pFldFWeb)
            {
                var trimmed = value?.Trim() ?? string.Empty;
                m_FWeb = trimmed.Length > 255 ? trimmed.AsSpan(0, 255).ToString() : trimmed;
            }
        }
    }

    public bool FEtiqueta
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FEtiqueta;
        set
        {
            pFldFEtiqueta = pFldFEtiqueta || value != m_FEtiqueta;
            if (pFldFEtiqueta)
                m_FEtiqueta = value;
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