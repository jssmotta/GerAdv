namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBInstancia
{
    [XmlIgnore]
    private protected bool pFldFLiminarPedida, pFldFObjeto, pFldFStatusResultado, pFldFLiminarPendente, pFldFInterpusemosRecurso, pFldFLiminarConcedida, pFldFLiminarNegada, pFldFProcesso, pFldFData, pFldFLiminarParcial, pFldFLiminarResultado, pFldFNroProcesso, pFldFDivisao, pFldFLiminarCliente, pFldFComarca, pFldFSubDivisao, pFldFPrincipal, pFldFAcao, pFldFForo, pFldFTipoRecurso, pFldFZKey, pFldFZKeyQuem, pFldFZKeyQuando, pFldFNroAntigo, pFldFAccessCode, pFldFJulgador, pFldFZKeyIA;
    [XmlIgnore]
    private protected int m_FStatusResultado, m_FProcesso, m_FDivisao, m_FComarca, m_FSubDivisao, m_FAcao, m_FForo, m_FTipoRecurso, m_FZKeyQuem, m_FJulgador;
    [XmlIgnore]
    private protected string? m_FLiminarPedida, m_FObjeto, m_FLiminarResultado, m_FNroProcesso, m_FZKey, m_FNroAntigo, m_FAccessCode, m_FZKeyIA;
    [XmlIgnore]
    private protected DateTime? m_FData, m_FZKeyQuando;
    [XmlIgnore]
    private protected bool m_FLiminarPendente, m_FInterpusemosRecurso, m_FLiminarConcedida, m_FLiminarNegada, m_FLiminarParcial, m_FLiminarCliente, m_FPrincipal;
    public string? FLiminarPedida
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FLiminarPedida ?? string.Empty;
        set
        {
            pFldFLiminarPedida = pFldFLiminarPedida || !(m_FLiminarPedida ?? string.Empty).Equals(value);
            if (pFldFLiminarPedida)
                m_FLiminarPedida = value.trim().FixAbc() ?? string.Empty;
        }
    }

    [StringLength(255, ErrorMessage = "A propriedade FObjeto da tabela Instancia deve ter no máximo 255 caracteres.")]
    public string? FObjeto
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FObjeto ?? string.Empty;
        set
        {
            pFldFObjeto = pFldFObjeto || !(m_FObjeto ?? string.Empty).Equals(value);
            if (pFldFObjeto)
            {
                var trimmed = value?.Trim() ?? string.Empty;
                m_FObjeto = trimmed.Length > 255 ? trimmed.AsSpan(0, 255).ToString() : trimmed;
            }
        }
    }

    public int FStatusResultado
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FStatusResultado;
        set
        {
            pFldFStatusResultado = pFldFStatusResultado || value != m_FStatusResultado;
            if (pFldFStatusResultado)
                m_FStatusResultado = value;
        }
    }

    public bool FLiminarPendente
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FLiminarPendente;
        set
        {
            pFldFLiminarPendente = pFldFLiminarPendente || value != m_FLiminarPendente;
            if (pFldFLiminarPendente)
                m_FLiminarPendente = value;
        }
    }

    public bool FInterpusemosRecurso
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FInterpusemosRecurso;
        set
        {
            pFldFInterpusemosRecurso = pFldFInterpusemosRecurso || value != m_FInterpusemosRecurso;
            if (pFldFInterpusemosRecurso)
                m_FInterpusemosRecurso = value;
        }
    }

    public bool FLiminarConcedida
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FLiminarConcedida;
        set
        {
            pFldFLiminarConcedida = pFldFLiminarConcedida || value != m_FLiminarConcedida;
            if (pFldFLiminarConcedida)
                m_FLiminarConcedida = value;
        }
    }

    public bool FLiminarNegada
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FLiminarNegada;
        set
        {
            pFldFLiminarNegada = pFldFLiminarNegada || value != m_FLiminarNegada;
            if (pFldFLiminarNegada)
                m_FLiminarNegada = value;
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

    public bool FLiminarParcial
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FLiminarParcial;
        set
        {
            pFldFLiminarParcial = pFldFLiminarParcial || value != m_FLiminarParcial;
            if (pFldFLiminarParcial)
                m_FLiminarParcial = value;
        }
    }

    public string? FLiminarResultado
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FLiminarResultado ?? string.Empty;
        set
        {
            pFldFLiminarResultado = pFldFLiminarResultado || !(m_FLiminarResultado ?? string.Empty).Equals(value);
            if (pFldFLiminarResultado)
                m_FLiminarResultado = value.trim().FixAbc() ?? string.Empty;
        }
    }

    [StringLength(25, ErrorMessage = "A propriedade FNroProcesso da tabela Instancia deve ter no máximo 25 caracteres.")]
    public string? FNroProcesso
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FNroProcesso ?? string.Empty;
        set
        {
            pFldFNroProcesso = pFldFNroProcesso || !(m_FNroProcesso ?? string.Empty).Equals(value);
            if (pFldFNroProcesso)
            {
                var trimmed = value?.Trim() ?? string.Empty;
                m_FNroProcesso = trimmed.Length > 25 ? trimmed.AsSpan(0, 25).ToString() : trimmed;
            }
        }
    }

    public int FDivisao
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FDivisao;
        set
        {
            pFldFDivisao = pFldFDivisao || value != m_FDivisao;
            if (pFldFDivisao)
                m_FDivisao = value;
        }
    }

    public bool FLiminarCliente
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FLiminarCliente;
        set
        {
            pFldFLiminarCliente = pFldFLiminarCliente || value != m_FLiminarCliente;
            if (pFldFLiminarCliente)
                m_FLiminarCliente = value;
        }
    }

    public int FComarca
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FComarca;
        set
        {
            pFldFComarca = pFldFComarca || value != m_FComarca;
            if (pFldFComarca)
                m_FComarca = value;
        }
    }

    public int FSubDivisao
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FSubDivisao;
        set
        {
            pFldFSubDivisao = pFldFSubDivisao || value != m_FSubDivisao;
            if (pFldFSubDivisao)
                m_FSubDivisao = value;
        }
    }

    public bool FPrincipal
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FPrincipal;
        set
        {
            pFldFPrincipal = pFldFPrincipal || value != m_FPrincipal;
            if (pFldFPrincipal)
                m_FPrincipal = value;
        }
    }

    public int FAcao
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FAcao;
        set
        {
            pFldFAcao = pFldFAcao || value != m_FAcao;
            if (pFldFAcao)
                m_FAcao = value;
        }
    }

    public int FForo
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FForo;
        set
        {
            pFldFForo = pFldFForo || value != m_FForo;
            if (pFldFForo)
                m_FForo = value;
        }
    }

    public int FTipoRecurso
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FTipoRecurso;
        set
        {
            pFldFTipoRecurso = pFldFTipoRecurso || value != m_FTipoRecurso;
            if (pFldFTipoRecurso)
                m_FTipoRecurso = value;
        }
    }

    [StringLength(25, ErrorMessage = "A propriedade FZKey da tabela Instancia deve ter no máximo 25 caracteres.")]
    public string? FZKey
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FZKey ?? string.Empty;
        set
        {
            pFldFZKey = pFldFZKey || !(m_FZKey ?? string.Empty).Equals(value);
            if (pFldFZKey)
            {
                var trimmed = value?.Trim() ?? string.Empty;
                m_FZKey = trimmed.Length > 25 ? trimmed.AsSpan(0, 25).ToString() : trimmed;
            }
        }
    }

    public int FZKeyQuem
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FZKeyQuem;
        set
        {
            pFldFZKeyQuem = pFldFZKeyQuem || value != m_FZKeyQuem;
            if (pFldFZKeyQuem)
                m_FZKeyQuem = value;
        }
    }

    public string? FZKeyQuando
    {
        get => $"{m_FZKeyQuando:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FZKeyQuando:dd/MM/yyyy}";
        set
        {
            var(setUpNow, changed, data) = DevourerOne.DateUp7(pFldFZKeyQuando, m_FZKeyQuando, value);
            if (!setUpNow)
                return;
            pFldFZKeyQuando = changed;
            m_FZKeyQuando = data;
        }
    }

    [StringLength(25, ErrorMessage = "A propriedade FNroAntigo da tabela Instancia deve ter no máximo 25 caracteres.")]
    public string? FNroAntigo
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FNroAntigo ?? string.Empty;
        set
        {
            pFldFNroAntigo = pFldFNroAntigo || !(m_FNroAntigo ?? string.Empty).Equals(value);
            if (pFldFNroAntigo)
            {
                var trimmed = value?.Trim() ?? string.Empty;
                m_FNroAntigo = trimmed.Length > 25 ? trimmed.AsSpan(0, 25).ToString() : trimmed;
            }
        }
    }

    [StringLength(100, ErrorMessage = "A propriedade FAccessCode da tabela Instancia deve ter no máximo 100 caracteres.")]
    public string? FAccessCode
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FAccessCode ?? string.Empty;
        set
        {
            pFldFAccessCode = pFldFAccessCode || !(m_FAccessCode ?? string.Empty).Equals(value);
            if (pFldFAccessCode)
            {
                var trimmed = value?.Trim() ?? string.Empty;
                m_FAccessCode = trimmed.Length > 100 ? trimmed.AsSpan(0, 100).ToString() : trimmed;
            }
        }
    }

    public int FJulgador
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FJulgador;
        set
        {
            pFldFJulgador = pFldFJulgador || value != m_FJulgador;
            if (pFldFJulgador)
                m_FJulgador = value;
        }
    }

    [StringLength(25, ErrorMessage = "A propriedade FZKeyIA da tabela Instancia deve ter no máximo 25 caracteres.")]
    public string? FZKeyIA
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FZKeyIA ?? string.Empty;
        set
        {
            pFldFZKeyIA = pFldFZKeyIA || !(m_FZKeyIA ?? string.Empty).Equals(value);
            if (pFldFZKeyIA)
            {
                var trimmed = value?.Trim() ?? string.Empty;
                m_FZKeyIA = trimmed.Length > 25 ? trimmed.AsSpan(0, 25).ToString() : trimmed;
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