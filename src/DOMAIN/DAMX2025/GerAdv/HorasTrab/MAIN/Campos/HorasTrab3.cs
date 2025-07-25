namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBHorasTrab
{
    [XmlIgnore]
    private protected bool pFldFIDContatoCRM, pFldFHonorario, pFldFIDAgenda, pFldFData, pFldFCliente, pFldFStatus, pFldFProcesso, pFldFAdvogado, pFldFFuncionario, pFldFHrIni, pFldFHrFim, pFldFTempo, pFldFValor, pFldFOBS, pFldFAnexo, pFldFAnexoComp, pFldFAnexoUNC, pFldFServico;
    [XmlIgnore]
    private protected int m_FIDContatoCRM, m_FIDAgenda, m_FCliente, m_FStatus, m_FProcesso, m_FAdvogado, m_FFuncionario, m_FServico;
    [XmlIgnore]
    private protected string? m_FHrIni, m_FHrFim, m_FOBS, m_FAnexo, m_FAnexoComp, m_FAnexoUNC;
    [XmlIgnore]
    private protected DateTime? m_FData;
    [XmlIgnore]
    private protected bool m_FHonorario;
    [XmlIgnore]
    private protected decimal m_FTempo, m_FValor;
    public int FIDContatoCRM
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FIDContatoCRM;
        set
        {
            pFldFIDContatoCRM = pFldFIDContatoCRM || value != m_FIDContatoCRM;
            if (pFldFIDContatoCRM)
                m_FIDContatoCRM = value;
        }
    }

    public bool FHonorario
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FHonorario;
        set
        {
            pFldFHonorario = pFldFHonorario || value != m_FHonorario;
            if (pFldFHonorario)
                m_FHonorario = value;
        }
    }

    public int FIDAgenda
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FIDAgenda;
        set
        {
            pFldFIDAgenda = pFldFIDAgenda || value != m_FIDAgenda;
            if (pFldFIDAgenda)
                m_FIDAgenda = value;
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

    public int FStatus
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FStatus;
        set
        {
            pFldFStatus = pFldFStatus || value != m_FStatus;
            if (pFldFStatus)
                m_FStatus = value;
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

    public int FAdvogado
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FAdvogado;
        set
        {
            pFldFAdvogado = pFldFAdvogado || value != m_FAdvogado;
            if (pFldFAdvogado)
                m_FAdvogado = value;
        }
    }

    public int FFuncionario
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FFuncionario;
        set
        {
            pFldFFuncionario = pFldFFuncionario || value != m_FFuncionario;
            if (pFldFFuncionario)
                m_FFuncionario = value;
        }
    }

    [StringLength(5, ErrorMessage = "A propriedade FHrIni da tabela HorasTrab deve ter no máximo 5 caracteres.")]
    public string? FHrIni
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FHrIni ?? string.Empty;
        set
        {
            pFldFHrIni = pFldFHrIni || !(m_FHrIni ?? string.Empty).Equals(value);
            if (pFldFHrIni)
            {
                var trimmed = value?.Trim() ?? string.Empty;
                m_FHrIni = trimmed.Length > 5 ? trimmed.AsSpan(0, 5).ToString() : trimmed;
            }
        }
    }

    [StringLength(5, ErrorMessage = "A propriedade FHrFim da tabela HorasTrab deve ter no máximo 5 caracteres.")]
    public string? FHrFim
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FHrFim ?? string.Empty;
        set
        {
            pFldFHrFim = pFldFHrFim || !(m_FHrFim ?? string.Empty).Equals(value);
            if (pFldFHrFim)
            {
                var trimmed = value?.Trim() ?? string.Empty;
                m_FHrFim = trimmed.Length > 5 ? trimmed.AsSpan(0, 5).ToString() : trimmed;
            }
        }
    }

    public decimal FTempo
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FTempo;
        set
        {
            if (value == m_FTempo)
                return;
            pFldFTempo = true;
            m_FTempo = value;
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

    public string? FOBS
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FOBS ?? string.Empty;
        set
        {
            pFldFOBS = pFldFOBS || !(m_FOBS ?? string.Empty).Equals(value);
            if (pFldFOBS)
                m_FOBS = value.trim().FixAbc() ?? string.Empty;
        }
    }

    [StringLength(255, ErrorMessage = "A propriedade FAnexo da tabela HorasTrab deve ter no máximo 255 caracteres.")]
    public string? FAnexo
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FAnexo ?? string.Empty;
        set
        {
            pFldFAnexo = pFldFAnexo || !(m_FAnexo ?? string.Empty).Equals(value);
            if (pFldFAnexo)
            {
                var trimmed = value?.Trim() ?? string.Empty;
                m_FAnexo = trimmed.Length > 255 ? trimmed.AsSpan(0, 255).ToString() : trimmed;
            }
        }
    }

    [StringLength(50, ErrorMessage = "A propriedade FAnexoComp da tabela HorasTrab deve ter no máximo 50 caracteres.")]
    public string? FAnexoComp
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FAnexoComp ?? string.Empty;
        set
        {
            pFldFAnexoComp = pFldFAnexoComp || !(m_FAnexoComp ?? string.Empty).Equals(value);
            if (pFldFAnexoComp)
            {
                var trimmed = value?.Trim() ?? string.Empty;
                m_FAnexoComp = trimmed.Length > 50 ? trimmed.AsSpan(0, 50).ToString() : trimmed;
            }
        }
    }

    [StringLength(255, ErrorMessage = "A propriedade FAnexoUNC da tabela HorasTrab deve ter no máximo 255 caracteres.")]
    public string? FAnexoUNC
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FAnexoUNC ?? string.Empty;
        set
        {
            pFldFAnexoUNC = pFldFAnexoUNC || !(m_FAnexoUNC ?? string.Empty).Equals(value);
            if (pFldFAnexoUNC)
            {
                var trimmed = value?.Trim() ?? string.Empty;
                m_FAnexoUNC = trimmed.Length > 255 ? trimmed.AsSpan(0, 255).ToString() : trimmed;
            }
        }
    }

    public int FServico
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FServico;
        set
        {
            pFldFServico = pFldFServico || value != m_FServico;
            if (pFldFServico)
                m_FServico = value;
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