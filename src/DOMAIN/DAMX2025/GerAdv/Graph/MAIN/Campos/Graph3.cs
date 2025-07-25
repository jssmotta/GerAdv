namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBGraph
{
    [XmlIgnore]
    private protected bool pFldFTabela, pFldFTabelaId, pFldFImagem;
    [XmlIgnore]
    private protected int m_FTabelaId;
    [XmlIgnore]
    private protected string? m_FTabela;
    [XmlIgnore]
    private protected byte[]? m_FImagem;
    [StringLength(80, ErrorMessage = "A propriedade FTabela da tabela Graph deve ter no máximo 80 caracteres.")]
    public string? FTabela
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FTabela ?? string.Empty;
        set
        {
            pFldFTabela = pFldFTabela || !(m_FTabela ?? string.Empty).Equals(value);
            if (pFldFTabela)
            {
                var trimmed = value?.Trim() ?? string.Empty;
                m_FTabela = trimmed.Length > 80 ? trimmed.AsSpan(0, 80).ToString() : trimmed;
            }
        }
    }

    public int FTabelaId
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FTabelaId;
        set
        {
            pFldFTabelaId = pFldFTabelaId || value != m_FTabelaId;
            if (pFldFTabelaId)
                m_FTabelaId = value;
        }
    }

    public byte[] FImagem
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FImagem ?? [0];
        set
        {
            pFldFImagem = value != m_FImagem;
            m_FImagem = value;
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