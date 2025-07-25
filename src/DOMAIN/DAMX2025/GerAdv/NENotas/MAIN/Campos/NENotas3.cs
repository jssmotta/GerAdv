namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBNENotas
{
    [XmlIgnore]
    private protected bool pFldFApenso, pFldFPrecatoria, pFldFInstancia, pFldFMovPro, pFldFNome, pFldFNotaExpedida, pFldFRevisada, pFldFProcesso, pFldFPalavraChave, pFldFData, pFldFNotaPublicada;
    [XmlIgnore]
    private protected int m_FApenso, m_FPrecatoria, m_FInstancia, m_FProcesso, m_FPalavraChave;
    [XmlIgnore]
    private protected string? m_FNome, m_FNotaPublicada;
    [XmlIgnore]
    private protected DateTime? m_FData;
    [XmlIgnore]
    private protected bool m_FMovPro, m_FNotaExpedida, m_FRevisada;
    public int FApenso
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FApenso;
        set
        {
            pFldFApenso = pFldFApenso || value != m_FApenso;
            if (pFldFApenso)
                m_FApenso = value;
        }
    }

    public int FPrecatoria
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FPrecatoria;
        set
        {
            pFldFPrecatoria = pFldFPrecatoria || value != m_FPrecatoria;
            if (pFldFPrecatoria)
                m_FPrecatoria = value;
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

    public bool FMovPro
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FMovPro;
        set
        {
            pFldFMovPro = pFldFMovPro || value != m_FMovPro;
            if (pFldFMovPro)
                m_FMovPro = value;
        }
    }

    [StringLength(20, ErrorMessage = "A propriedade FNome da tabela NENotas deve ter no máximo 20 caracteres.")]
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
                m_FNome = trimmed.Length > 20 ? trimmed.AsSpan(0, 20).ToString() : trimmed;
            }
        }
    }

    public bool FNotaExpedida
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FNotaExpedida;
        set
        {
            pFldFNotaExpedida = pFldFNotaExpedida || value != m_FNotaExpedida;
            if (pFldFNotaExpedida)
                m_FNotaExpedida = value;
        }
    }

    public bool FRevisada
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FRevisada;
        set
        {
            pFldFRevisada = pFldFRevisada || value != m_FRevisada;
            if (pFldFRevisada)
                m_FRevisada = value;
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

    public int FPalavraChave
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FPalavraChave;
        set
        {
            pFldFPalavraChave = pFldFPalavraChave || value != m_FPalavraChave;
            if (pFldFPalavraChave)
                m_FPalavraChave = value;
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

    public string? FNotaPublicada
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FNotaPublicada ?? string.Empty;
        set
        {
            pFldFNotaPublicada = pFldFNotaPublicada || !(m_FNotaPublicada ?? string.Empty).Equals(value);
            if (pFldFNotaPublicada)
                m_FNotaPublicada = value.trim().FixAbc() ?? string.Empty;
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