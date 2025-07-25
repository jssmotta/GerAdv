namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBProSucumbencia
{
    [XmlIgnore]
    private protected bool pFldFProcesso, pFldFInstancia, pFldFData, pFldFNome, pFldFTipoOrigemSucumbencia, pFldFValor, pFldFPercentual;
    [XmlIgnore]
    private protected int m_FProcesso, m_FInstancia, m_FTipoOrigemSucumbencia;
    [XmlIgnore]
    private protected string? m_FNome, m_FPercentual;
    [XmlIgnore]
    private protected DateTime? m_FData;
    [XmlIgnore]
    private protected decimal m_FValor;
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

    [StringLength(2048, ErrorMessage = "A propriedade FNome da tabela ProSucumbencia deve ter no máximo 2048 caracteres.")]
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
                m_FNome = trimmed.Length > 2048 ? trimmed.AsSpan(0, 2048).ToString() : trimmed;
            }
        }
    }

    public int FTipoOrigemSucumbencia
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FTipoOrigemSucumbencia;
        set
        {
            pFldFTipoOrigemSucumbencia = pFldFTipoOrigemSucumbencia || value != m_FTipoOrigemSucumbencia;
            if (pFldFTipoOrigemSucumbencia)
                m_FTipoOrigemSucumbencia = value;
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

    [StringLength(5, ErrorMessage = "A propriedade FPercentual da tabela ProSucumbencia deve ter no máximo 5 caracteres.")]
    public string? FPercentual
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FPercentual ?? string.Empty;
        set
        {
            pFldFPercentual = pFldFPercentual || !(m_FPercentual ?? string.Empty).Equals(value);
            if (pFldFPercentual)
            {
                var trimmed = value?.Trim() ?? string.Empty;
                m_FPercentual = trimmed.Length > 5 ? trimmed.AsSpan(0, 5).ToString() : trimmed;
            }
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