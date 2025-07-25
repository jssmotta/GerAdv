namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBProValores
{
    [XmlIgnore]
    private protected bool pFldFProcesso, pFldFTipoValorProcesso, pFldFIndice, pFldFIgnorar, pFldFData, pFldFValorOriginal, pFldFPercMulta, pFldFValorMulta, pFldFPercJuros, pFldFValorOriginalCorrigidoIndice, pFldFValorMultaCorrigido, pFldFValorJurosCorrigido, pFldFValorFinal, pFldFDataUltimaCorrecao;
    [XmlIgnore]
    private protected int m_FProcesso, m_FTipoValorProcesso;
    [XmlIgnore]
    private protected string? m_FIndice;
    [XmlIgnore]
    private protected DateTime? m_FData, m_FDataUltimaCorrecao;
    [XmlIgnore]
    private protected bool m_FIgnorar;
    [XmlIgnore]
    private protected decimal m_FValorOriginal, m_FPercMulta, m_FValorMulta, m_FPercJuros, m_FValorOriginalCorrigidoIndice, m_FValorMultaCorrigido, m_FValorJurosCorrigido, m_FValorFinal;
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

    public int FTipoValorProcesso
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FTipoValorProcesso;
        set
        {
            pFldFTipoValorProcesso = pFldFTipoValorProcesso || value != m_FTipoValorProcesso;
            if (pFldFTipoValorProcesso)
                m_FTipoValorProcesso = value;
        }
    }

    [StringLength(20, ErrorMessage = "A propriedade FIndice da tabela ProValores deve ter no máximo 20 caracteres.")]
    public string? FIndice
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FIndice ?? string.Empty;
        set
        {
            pFldFIndice = pFldFIndice || !(m_FIndice ?? string.Empty).Equals(value);
            if (pFldFIndice)
            {
                var trimmed = value?.Trim() ?? string.Empty;
                m_FIndice = trimmed.Length > 20 ? trimmed.AsSpan(0, 20).ToString() : trimmed;
            }
        }
    }

    public bool FIgnorar
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FIgnorar;
        set
        {
            pFldFIgnorar = pFldFIgnorar || value != m_FIgnorar;
            if (pFldFIgnorar)
                m_FIgnorar = value;
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

    public decimal FPercMulta
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FPercMulta;
        set
        {
            if (value == m_FPercMulta)
                return;
            pFldFPercMulta = true;
            m_FPercMulta = value;
        }
    }

    public decimal FValorMulta
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FValorMulta;
        set
        {
            if (value == m_FValorMulta)
                return;
            pFldFValorMulta = true;
            m_FValorMulta = value;
        }
    }

    public decimal FPercJuros
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FPercJuros;
        set
        {
            if (value == m_FPercJuros)
                return;
            pFldFPercJuros = true;
            m_FPercJuros = value;
        }
    }

    public decimal FValorOriginalCorrigidoIndice
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FValorOriginalCorrigidoIndice;
        set
        {
            if (value == m_FValorOriginalCorrigidoIndice)
                return;
            pFldFValorOriginalCorrigidoIndice = true;
            m_FValorOriginalCorrigidoIndice = value;
        }
    }

    public decimal FValorMultaCorrigido
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FValorMultaCorrigido;
        set
        {
            if (value == m_FValorMultaCorrigido)
                return;
            pFldFValorMultaCorrigido = true;
            m_FValorMultaCorrigido = value;
        }
    }

    public decimal FValorJurosCorrigido
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FValorJurosCorrigido;
        set
        {
            if (value == m_FValorJurosCorrigido)
                return;
            pFldFValorJurosCorrigido = true;
            m_FValorJurosCorrigido = value;
        }
    }

    public decimal FValorFinal
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FValorFinal;
        set
        {
            if (value == m_FValorFinal)
                return;
            pFldFValorFinal = true;
            m_FValorFinal = value;
        }
    }

    public string? FDataUltimaCorrecao
    {
        get => $"{m_FDataUltimaCorrecao:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FDataUltimaCorrecao:dd/MM/yyyy}";
        set
        {
            var(setUpNow, changed, data) = DevourerOne.DateUp7(pFldFDataUltimaCorrecao, m_FDataUltimaCorrecao, value);
            if (!setUpNow)
                return;
            pFldFDataUltimaCorrecao = changed;
            m_FDataUltimaCorrecao = data;
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