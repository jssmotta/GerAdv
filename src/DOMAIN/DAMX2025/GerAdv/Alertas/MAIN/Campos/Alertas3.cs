namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBAlertas
{
    [XmlIgnore]
    private protected bool pFldFNome, pFldFData, pFldFOperador, pFldFDataAte;
    [XmlIgnore]
    private protected int m_FOperador;
    [XmlIgnore]
    private protected string? m_FNome;
    [XmlIgnore]
    private protected DateTime? m_FData, m_FDataAte;
    [StringLength(2048, ErrorMessage = "A propriedade FNome da tabela Alertas deve ter no máximo 2048 caracteres.")]
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

    public string? FDataAte
    {
        get => $"{m_FDataAte:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FDataAte:dd/MM/yyyy}";
        set
        {
            var(setUpNow, changed, data) = DevourerOne.DateUp7(pFldFDataAte, m_FDataAte, value);
            if (!setUpNow)
                return;
            pFldFDataAte = changed;
            m_FDataAte = data;
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