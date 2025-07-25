namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBHonorariosDadosContrato
{
    [XmlIgnore]
    private protected bool pFldFCliente, pFldFFixo, pFldFVariavel, pFldFPercSucesso, pFldFProcesso, pFldFArquivoContrato, pFldFTextoContrato, pFldFValorFixo, pFldFObservacao, pFldFDataContrato;
    [XmlIgnore]
    private protected int m_FCliente, m_FProcesso;
    [XmlIgnore]
    private protected string? m_FArquivoContrato, m_FTextoContrato, m_FObservacao;
    [XmlIgnore]
    private protected DateTime? m_FDataContrato;
    [XmlIgnore]
    private protected bool m_FFixo, m_FVariavel;
    [XmlIgnore]
    private protected decimal m_FPercSucesso, m_FValorFixo;
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

    public bool FFixo
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FFixo;
        set
        {
            pFldFFixo = pFldFFixo || value != m_FFixo;
            if (pFldFFixo)
                m_FFixo = value;
        }
    }

    public bool FVariavel
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FVariavel;
        set
        {
            pFldFVariavel = pFldFVariavel || value != m_FVariavel;
            if (pFldFVariavel)
                m_FVariavel = value;
        }
    }

    public decimal FPercSucesso
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FPercSucesso;
        set
        {
            if (value == m_FPercSucesso)
                return;
            pFldFPercSucesso = true;
            m_FPercSucesso = value;
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

    [StringLength(2048, ErrorMessage = "A propriedade FArquivoContrato da tabela HonorariosDadosContrato deve ter no máximo 2048 caracteres.")]
    public string? FArquivoContrato
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FArquivoContrato ?? string.Empty;
        set
        {
            pFldFArquivoContrato = pFldFArquivoContrato || !(m_FArquivoContrato ?? string.Empty).Equals(value);
            if (pFldFArquivoContrato)
            {
                var trimmed = value?.Trim() ?? string.Empty;
                m_FArquivoContrato = trimmed.Length > 2048 ? trimmed.AsSpan(0, 2048).ToString() : trimmed;
            }
        }
    }

    public string? FTextoContrato
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FTextoContrato ?? string.Empty;
        set
        {
            pFldFTextoContrato = pFldFTextoContrato || !(m_FTextoContrato ?? string.Empty).Equals(value);
            if (pFldFTextoContrato)
                m_FTextoContrato = value.trim().FixAbc() ?? string.Empty;
        }
    }

    public decimal FValorFixo
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FValorFixo;
        set
        {
            if (value == m_FValorFixo)
                return;
            pFldFValorFixo = true;
            m_FValorFixo = value;
        }
    }

    [StringLength(2048, ErrorMessage = "A propriedade FObservacao da tabela HonorariosDadosContrato deve ter no máximo 2048 caracteres.")]
    public string? FObservacao
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FObservacao ?? string.Empty;
        set
        {
            pFldFObservacao = pFldFObservacao || !(m_FObservacao ?? string.Empty).Equals(value);
            if (pFldFObservacao)
            {
                var trimmed = value?.Trim() ?? string.Empty;
                m_FObservacao = trimmed.Length > 2048 ? trimmed.AsSpan(0, 2048).ToString() : trimmed;
            }
        }
    }

    public string? FDataContrato
    {
        get => $"{m_FDataContrato:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FDataContrato:dd/MM/yyyy}";
        set
        {
            var(setUpNow, changed, data) = DevourerOne.DateUp7(pFldFDataContrato, m_FDataContrato, value);
            if (!setUpNow)
                return;
            pFldFDataContrato = changed;
            m_FDataContrato = data;
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