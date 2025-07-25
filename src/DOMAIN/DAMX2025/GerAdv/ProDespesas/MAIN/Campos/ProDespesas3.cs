namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBProDespesas
{
    [XmlIgnore]
    private protected bool pFldFLigacaoID, pFldFCliente, pFldFCorrigido, pFldFData, pFldFValorOriginal, pFldFProcesso, pFldFQuitado, pFldFDataCorrecao, pFldFValor, pFldFTipo, pFldFHistorico, pFldFLivroCaixa;
    [XmlIgnore]
    private protected int m_FLigacaoID, m_FCliente, m_FProcesso, m_FQuitado;
    [XmlIgnore]
    private protected string? m_FHistorico;
    [XmlIgnore]
    private protected DateTime? m_FData, m_FDataCorrecao;
    [XmlIgnore]
    private protected bool m_FCorrigido, m_FTipo, m_FLivroCaixa;
    [XmlIgnore]
    private protected decimal m_FValorOriginal, m_FValor;
    public int FLigacaoID
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FLigacaoID;
        set
        {
            pFldFLigacaoID = pFldFLigacaoID || value != m_FLigacaoID;
            if (pFldFLigacaoID)
                m_FLigacaoID = value;
        }
    }

    public int FCliente
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FCliente;
        set
        {
            pFldFCliente = pFldFCliente || value != m_FCliente;
            if (pFldFCliente)
                m_FCliente = value;
        }
    }

    public bool FCorrigido
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FCorrigido;
        set
        {
            pFldFCorrigido = pFldFCorrigido || value != m_FCorrigido;
            if (pFldFCorrigido)
                m_FCorrigido = value;
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

    public decimal FValorOriginal
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FValorOriginal;
        set
        {
            if (value == m_FValorOriginal)
                return;
            pFldFValorOriginal = true;
            m_FValorOriginal = value;
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

    public int FQuitado
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FQuitado;
        set
        {
            pFldFQuitado = pFldFQuitado || value != m_FQuitado;
            if (pFldFQuitado)
                m_FQuitado = value;
        }
    }

    public string? FDataCorrecao
    {
        get => $"{m_FDataCorrecao:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FDataCorrecao:dd/MM/yyyy}";
        set
        {
            var(setUpNow, changed, data) = DevourerOne.DateUp7(pFldFDataCorrecao, m_FDataCorrecao, value);
            if (!setUpNow)
                return;
            pFldFDataCorrecao = changed;
            m_FDataCorrecao = data;
        }
    }

    public decimal FValor
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FValor;
        set
        {
            if (value == m_FValor)
                return;
            pFldFValor = true;
            m_FValor = value;
        }
    }

    public bool FTipo
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

    [StringLength(100, ErrorMessage = "A propriedade FHistorico da tabela ProDespesas deve ter no máximo 100 caracteres.")]
    public string? FHistorico
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FHistorico ?? string.Empty;
        set
        {
            pFldFHistorico = pFldFHistorico || !(m_FHistorico ?? string.Empty).Equals(value);
            if (pFldFHistorico)
            {
                var trimmed = value?.Trim() ?? string.Empty;
                m_FHistorico = trimmed.Length > 100 ? trimmed.AsSpan(0, 100).ToString() : trimmed;
            }
        }
    }

    public bool FLivroCaixa
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FLivroCaixa;
        set
        {
            pFldFLivroCaixa = pFldFLivroCaixa || value != m_FLivroCaixa;
            if (pFldFLivroCaixa)
                m_FLivroCaixa = value;
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