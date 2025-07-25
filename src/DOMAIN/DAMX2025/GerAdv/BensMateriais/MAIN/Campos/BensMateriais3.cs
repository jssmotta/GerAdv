namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBBensMateriais
{
    [XmlIgnore]
    private protected bool pFldFNome, pFldFBensClassificacao, pFldFDataCompra, pFldFDataFimDaGarantia, pFldFNFNRO, pFldFFornecedor, pFldFValorBem, pFldFNroSerieProduto, pFldFComprador, pFldFCidade, pFldFGarantiaLoja, pFldFDataTerminoDaGarantiaDaLoja, pFldFObservacoes, pFldFNomeVendedor, pFldFBold;
    [XmlIgnore]
    private protected int m_FBensClassificacao, m_FFornecedor, m_FCidade;
    [XmlIgnore]
    private protected string? m_FNome, m_FNFNRO, m_FNroSerieProduto, m_FComprador, m_FObservacoes, m_FNomeVendedor;
    [XmlIgnore]
    private protected DateTime? m_FDataCompra, m_FDataFimDaGarantia, m_FDataTerminoDaGarantiaDaLoja;
    [XmlIgnore]
    private protected bool m_FGarantiaLoja, m_FBold;
    [XmlIgnore]
    private protected decimal m_FValorBem;
    [StringLength(80, ErrorMessage = "A propriedade FNome da tabela BensMateriais deve ter no máximo 80 caracteres.")]
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
                m_FNome = trimmed.Length > 80 ? trimmed.AsSpan(0, 80).ToString() : trimmed;
            }
        }
    }

    public int FBensClassificacao
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FBensClassificacao;
        set
        {
            pFldFBensClassificacao = pFldFBensClassificacao || value != m_FBensClassificacao;
            if (pFldFBensClassificacao)
                m_FBensClassificacao = value;
        }
    }

    public string? FDataCompra
    {
        get => $"{m_FDataCompra:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FDataCompra:dd/MM/yyyy}";
        set
        {
            var(setUpNow, changed, data) = DevourerOne.DateUp7(pFldFDataCompra, m_FDataCompra, value);
            if (!setUpNow)
                return;
            pFldFDataCompra = changed;
            m_FDataCompra = data;
        }
    }

    public string? FDataFimDaGarantia
    {
        get => $"{m_FDataFimDaGarantia:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FDataFimDaGarantia:dd/MM/yyyy}";
        set
        {
            var(setUpNow, changed, data) = DevourerOne.DateUp7(pFldFDataFimDaGarantia, m_FDataFimDaGarantia, value);
            if (!setUpNow)
                return;
            pFldFDataFimDaGarantia = changed;
            m_FDataFimDaGarantia = data;
        }
    }

    [StringLength(255, ErrorMessage = "A propriedade FNFNRO da tabela BensMateriais deve ter no máximo 255 caracteres.")]
    public string? FNFNRO
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FNFNRO ?? string.Empty;
        set
        {
            pFldFNFNRO = pFldFNFNRO || !(m_FNFNRO ?? string.Empty).Equals(value);
            if (pFldFNFNRO)
            {
                var trimmed = value?.Trim() ?? string.Empty;
                m_FNFNRO = trimmed.Length > 255 ? trimmed.AsSpan(0, 255).ToString() : trimmed;
            }
        }
    }

    public int FFornecedor
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FFornecedor;
        set
        {
            pFldFFornecedor = pFldFFornecedor || value != m_FFornecedor;
            if (pFldFFornecedor)
                m_FFornecedor = value;
        }
    }

    public decimal FValorBem
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FValorBem;
        set
        {
            if (value == m_FValorBem)
                return;
            pFldFValorBem = true;
            m_FValorBem = value;
        }
    }

    [StringLength(100, ErrorMessage = "A propriedade FNroSerieProduto da tabela BensMateriais deve ter no máximo 100 caracteres.")]
    public string? FNroSerieProduto
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FNroSerieProduto ?? string.Empty;
        set
        {
            pFldFNroSerieProduto = pFldFNroSerieProduto || !(m_FNroSerieProduto ?? string.Empty).Equals(value);
            if (pFldFNroSerieProduto)
            {
                var trimmed = value?.Trim() ?? string.Empty;
                m_FNroSerieProduto = trimmed.Length > 100 ? trimmed.AsSpan(0, 100).ToString() : trimmed;
            }
        }
    }

    [StringLength(100, ErrorMessage = "A propriedade FComprador da tabela BensMateriais deve ter no máximo 100 caracteres.")]
    public string? FComprador
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FComprador ?? string.Empty;
        set
        {
            pFldFComprador = pFldFComprador || !(m_FComprador ?? string.Empty).Equals(value);
            if (pFldFComprador)
            {
                var trimmed = value?.Trim() ?? string.Empty;
                m_FComprador = trimmed.Length > 100 ? trimmed.AsSpan(0, 100).ToString() : trimmed;
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

    public bool FGarantiaLoja
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FGarantiaLoja;
        set
        {
            pFldFGarantiaLoja = pFldFGarantiaLoja || value != m_FGarantiaLoja;
            if (pFldFGarantiaLoja)
                m_FGarantiaLoja = value;
        }
    }

    public string? FDataTerminoDaGarantiaDaLoja
    {
        get => $"{m_FDataTerminoDaGarantiaDaLoja:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FDataTerminoDaGarantiaDaLoja:dd/MM/yyyy}";
        set
        {
            var(setUpNow, changed, data) = DevourerOne.DateUp7(pFldFDataTerminoDaGarantiaDaLoja, m_FDataTerminoDaGarantiaDaLoja, value);
            if (!setUpNow)
                return;
            pFldFDataTerminoDaGarantiaDaLoja = changed;
            m_FDataTerminoDaGarantiaDaLoja = data;
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

    [StringLength(255, ErrorMessage = "A propriedade FNomeVendedor da tabela BensMateriais deve ter no máximo 255 caracteres.")]
    public string? FNomeVendedor
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FNomeVendedor ?? string.Empty;
        set
        {
            pFldFNomeVendedor = pFldFNomeVendedor || !(m_FNomeVendedor ?? string.Empty).Equals(value);
            if (pFldFNomeVendedor)
            {
                var trimmed = value?.Trim() ?? string.Empty;
                m_FNomeVendedor = trimmed.Length > 255 ? trimmed.AsSpan(0, 255).ToString() : trimmed;
            }
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