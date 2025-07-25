namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBDocsRecebidosItens
{
    [XmlIgnore]
    private protected bool pFldFContatoCRM, pFldFNome, pFldFDevolvido, pFldFSeraDevolvido, pFldFObservacoes, pFldFBold;
    [XmlIgnore]
    private protected int m_FContatoCRM;
    [XmlIgnore]
    private protected string? m_FNome, m_FObservacoes;
    [XmlIgnore]
    private protected bool m_FDevolvido, m_FSeraDevolvido, m_FBold;
    public int FContatoCRM
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FContatoCRM;
        set
        {
            pFldFContatoCRM = pFldFContatoCRM || value != m_FContatoCRM;
            if (pFldFContatoCRM)
                m_FContatoCRM = value;
        }
    }

    [StringLength(255, ErrorMessage = "A propriedade FNome da tabela DocsRecebidosItens deve ter no máximo 255 caracteres.")]
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

    public bool FDevolvido
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FDevolvido;
        set
        {
            pFldFDevolvido = pFldFDevolvido || value != m_FDevolvido;
            if (pFldFDevolvido)
                m_FDevolvido = value;
        }
    }

    public bool FSeraDevolvido
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FSeraDevolvido;
        set
        {
            pFldFSeraDevolvido = pFldFSeraDevolvido || value != m_FSeraDevolvido;
            if (pFldFSeraDevolvido)
                m_FSeraDevolvido = value;
        }
    }

    public string? FObservacoes
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FObservacoes ?? string.Empty;
        set
        {
            pFldFObservacoes = pFldFObservacoes || !(m_FObservacoes ?? string.Empty).Equals(value);
            if (pFldFObservacoes)
                m_FObservacoes = value.trim().FixAbc() ?? string.Empty;
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