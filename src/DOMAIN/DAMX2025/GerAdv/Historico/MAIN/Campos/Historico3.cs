namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBHistorico
{
    [XmlIgnore]
    private protected bool pFldFExtraID, pFldFIDNE, pFldFExtraGUID, pFldFLiminarOrigem, pFldFNaoPublicavel, pFldFProcesso, pFldFPrecatoria, pFldFApenso, pFldFIDInstProcesso, pFldFFase, pFldFData, pFldFObservacao, pFldFAgendado, pFldFConcluido, pFldFMesmaAgenda, pFldFSAD, pFldFResumido, pFldFStatusAndamento, pFldFTop;
    [XmlIgnore]
    private protected int m_FExtraID, m_FIDNE, m_FLiminarOrigem, m_FProcesso, m_FPrecatoria, m_FApenso, m_FIDInstProcesso, m_FFase, m_FSAD, m_FStatusAndamento;
    [XmlIgnore]
    private protected string? m_FExtraGUID, m_FObservacao;
    [XmlIgnore]
    private protected DateTime? m_FData;
    [XmlIgnore]
    private protected bool m_FNaoPublicavel, m_FAgendado, m_FConcluido, m_FMesmaAgenda, m_FResumido, m_FTop;
    public int FExtraID
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FExtraID;
        set
        {
            pFldFExtraID = pFldFExtraID || value != m_FExtraID;
            if (pFldFExtraID)
                m_FExtraID = value;
        }
    }

    public int FIDNE
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FIDNE;
        set
        {
            pFldFIDNE = pFldFIDNE || value != m_FIDNE;
            if (pFldFIDNE)
                m_FIDNE = value;
        }
    }

    [StringLength(100, ErrorMessage = "A propriedade FExtraGUID da tabela Historico deve ter no máximo 100 caracteres.")]
    public string? FExtraGUID
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FExtraGUID ?? string.Empty;
        set
        {
            pFldFExtraGUID = pFldFExtraGUID || !(m_FExtraGUID ?? string.Empty).Equals(value);
            if (pFldFExtraGUID)
            {
                var trimmed = value?.Trim() ?? string.Empty;
                m_FExtraGUID = trimmed.Length > 100 ? trimmed.AsSpan(0, 100).ToString() : trimmed;
            }
        }
    }

    public int FLiminarOrigem
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FLiminarOrigem;
        set
        {
            pFldFLiminarOrigem = pFldFLiminarOrigem || value != m_FLiminarOrigem;
            if (pFldFLiminarOrigem)
                m_FLiminarOrigem = value;
        }
    }

    public bool FNaoPublicavel
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FNaoPublicavel;
        set
        {
            pFldFNaoPublicavel = pFldFNaoPublicavel || value != m_FNaoPublicavel;
            if (pFldFNaoPublicavel)
                m_FNaoPublicavel = value;
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

    public int FIDInstProcesso
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FIDInstProcesso;
        set
        {
            pFldFIDInstProcesso = pFldFIDInstProcesso || value != m_FIDInstProcesso;
            if (pFldFIDInstProcesso)
                m_FIDInstProcesso = value;
        }
    }

    public int FFase
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FFase;
        set
        {
            pFldFFase = pFldFFase || value != m_FFase;
            if (pFldFFase)
                m_FFase = value;
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

    public string? FObservacao
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FObservacao ?? string.Empty;
        set
        {
            pFldFObservacao = pFldFObservacao || !(m_FObservacao ?? string.Empty).Equals(value);
            if (pFldFObservacao)
                m_FObservacao = value.trim().FixAbc() ?? string.Empty;
        }
    }

    public bool FAgendado
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FAgendado;
        set
        {
            pFldFAgendado = pFldFAgendado || value != m_FAgendado;
            if (pFldFAgendado)
                m_FAgendado = value;
        }
    }

    public bool FConcluido
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FConcluido;
        set
        {
            pFldFConcluido = pFldFConcluido || value != m_FConcluido;
            if (pFldFConcluido)
                m_FConcluido = value;
        }
    }

    public bool FMesmaAgenda
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FMesmaAgenda;
        set
        {
            pFldFMesmaAgenda = pFldFMesmaAgenda || value != m_FMesmaAgenda;
            if (pFldFMesmaAgenda)
                m_FMesmaAgenda = value;
        }
    }

    public int FSAD
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FSAD;
        set
        {
            pFldFSAD = pFldFSAD || value != m_FSAD;
            if (pFldFSAD)
                m_FSAD = value;
        }
    }

    public bool FResumido
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FResumido;
        set
        {
            pFldFResumido = pFldFResumido || value != m_FResumido;
            if (pFldFResumido)
                m_FResumido = value;
        }
    }

    public int FStatusAndamento
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FStatusAndamento;
        set
        {
            pFldFStatusAndamento = pFldFStatusAndamento || value != m_FStatusAndamento;
            if (pFldFStatusAndamento)
                m_FStatusAndamento = value;
        }
    }

    public bool FTop
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FTop;
        set
        {
            pFldFTop = pFldFTop || value != m_FTop;
            if (pFldFTop)
                m_FTop = value;
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