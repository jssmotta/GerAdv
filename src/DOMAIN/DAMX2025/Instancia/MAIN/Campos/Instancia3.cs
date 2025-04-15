namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBInstancia
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
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
    public string NFLiminarPedida() => m_FLiminarPedida ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FLiminarPedida
    {
        get => m_FLiminarPedida ?? string.Empty;
        set
        {
            pFldFLiminarPedida = pFldFLiminarPedida || !(m_FLiminarPedida ?? string.Empty).Equals(value);
            if (pFldFLiminarPedida)
                m_FLiminarPedida = value.trim().FixAbc() ?? string.Empty;
        }
    }

    public string NFObjeto() => m_FObjeto ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FObjeto
    {
        get => m_FObjeto ?? string.Empty;
        set
        {
            pFldFObjeto = pFldFObjeto || !(m_FObjeto ?? string.Empty).Equals(value);
            if (pFldFObjeto)
                m_FObjeto = value.trim().Length > 255 ? value.trim().substring(0, 255) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public int NFStatusResultado() => m_FStatusResultado;
    [XmlAttribute]
    public int FStatusResultado
    {
        get => m_FStatusResultado;
        set
        {
            pFldFStatusResultado = pFldFStatusResultado || value != m_FStatusResultado;
            if (pFldFStatusResultado)
                m_FStatusResultado = value;
        }
    }

    public bool NFLiminarPendente() => m_FLiminarPendente;
    [XmlAttribute]
    public bool FLiminarPendente
    {
        get => m_FLiminarPendente;
        set
        {
            pFldFLiminarPendente = pFldFLiminarPendente || value != m_FLiminarPendente;
            if (pFldFLiminarPendente)
                m_FLiminarPendente = value;
        }
    }

    public bool NFInterpusemosRecurso() => m_FInterpusemosRecurso;
    [XmlAttribute]
    public bool FInterpusemosRecurso
    {
        get => m_FInterpusemosRecurso;
        set
        {
            pFldFInterpusemosRecurso = pFldFInterpusemosRecurso || value != m_FInterpusemosRecurso;
            if (pFldFInterpusemosRecurso)
                m_FInterpusemosRecurso = value;
        }
    }

    public bool NFLiminarConcedida() => m_FLiminarConcedida;
    [XmlAttribute]
    public bool FLiminarConcedida
    {
        get => m_FLiminarConcedida;
        set
        {
            pFldFLiminarConcedida = pFldFLiminarConcedida || value != m_FLiminarConcedida;
            if (pFldFLiminarConcedida)
                m_FLiminarConcedida = value;
        }
    }

    public bool NFLiminarNegada() => m_FLiminarNegada;
    [XmlAttribute]
    public bool FLiminarNegada
    {
        get => m_FLiminarNegada;
        set
        {
            pFldFLiminarNegada = pFldFLiminarNegada || value != m_FLiminarNegada;
            if (pFldFLiminarNegada)
                m_FLiminarNegada = value;
        }
    }

    public int NFProcesso() => m_FProcesso;
    [XmlAttribute]
    public int FProcesso
    {
        get => m_FProcesso;
        set
        {
            pFldFProcesso = pFldFProcesso || value != m_FProcesso;
            if (pFldFProcesso)
                m_FProcesso = value;
        }
    }

    public string NFData() => $"{m_FData:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FData:dd/MM/yyyy}";
    [XmlIgnore]
    public DateTime MData => Convert.ToDateTime(m_FData);

    [XmlAttribute]
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

    public bool NFLiminarParcial() => m_FLiminarParcial;
    [XmlAttribute]
    public bool FLiminarParcial
    {
        get => m_FLiminarParcial;
        set
        {
            pFldFLiminarParcial = pFldFLiminarParcial || value != m_FLiminarParcial;
            if (pFldFLiminarParcial)
                m_FLiminarParcial = value;
        }
    }

    public string NFLiminarResultado() => m_FLiminarResultado ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FLiminarResultado
    {
        get => m_FLiminarResultado ?? string.Empty;
        set
        {
            pFldFLiminarResultado = pFldFLiminarResultado || !(m_FLiminarResultado ?? string.Empty).Equals(value);
            if (pFldFLiminarResultado)
                m_FLiminarResultado = value.trim().FixAbc() ?? string.Empty;
        }
    }

    public string NFNroProcesso() => m_FNroProcesso ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FNroProcesso
    {
        get => m_FNroProcesso ?? string.Empty;
        set
        {
            pFldFNroProcesso = pFldFNroProcesso || !(m_FNroProcesso ?? string.Empty).Equals(value);
            if (pFldFNroProcesso)
                m_FNroProcesso = value.trim().Length > 25 ? value.trim().substring(0, 25) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public int NFDivisao() => m_FDivisao;
    [XmlAttribute]
    public int FDivisao
    {
        get => m_FDivisao;
        set
        {
            pFldFDivisao = pFldFDivisao || value != m_FDivisao;
            if (pFldFDivisao)
                m_FDivisao = value;
        }
    }

    public bool NFLiminarCliente() => m_FLiminarCliente;
    [XmlAttribute]
    public bool FLiminarCliente
    {
        get => m_FLiminarCliente;
        set
        {
            pFldFLiminarCliente = pFldFLiminarCliente || value != m_FLiminarCliente;
            if (pFldFLiminarCliente)
                m_FLiminarCliente = value;
        }
    }

    public int NFComarca() => m_FComarca;
    [XmlAttribute]
    public int FComarca
    {
        get => m_FComarca;
        set
        {
            pFldFComarca = pFldFComarca || value != m_FComarca;
            if (pFldFComarca)
                m_FComarca = value;
        }
    }

    public int NFSubDivisao() => m_FSubDivisao;
    [XmlAttribute]
    public int FSubDivisao
    {
        get => m_FSubDivisao;
        set
        {
            pFldFSubDivisao = pFldFSubDivisao || value != m_FSubDivisao;
            if (pFldFSubDivisao)
                m_FSubDivisao = value;
        }
    }

    public bool NFPrincipal() => m_FPrincipal;
    [XmlAttribute]
    public bool FPrincipal
    {
        get => m_FPrincipal;
        set
        {
            pFldFPrincipal = pFldFPrincipal || value != m_FPrincipal;
            if (pFldFPrincipal)
                m_FPrincipal = value;
        }
    }

    public int NFAcao() => m_FAcao;
    [XmlAttribute]
    public int FAcao
    {
        get => m_FAcao;
        set
        {
            pFldFAcao = pFldFAcao || value != m_FAcao;
            if (pFldFAcao)
                m_FAcao = value;
        }
    }

    public int NFForo() => m_FForo;
    [XmlAttribute]
    public int FForo
    {
        get => m_FForo;
        set
        {
            pFldFForo = pFldFForo || value != m_FForo;
            if (pFldFForo)
                m_FForo = value;
        }
    }

    public int NFTipoRecurso() => m_FTipoRecurso;
    [XmlAttribute]
    public int FTipoRecurso
    {
        get => m_FTipoRecurso;
        set
        {
            pFldFTipoRecurso = pFldFTipoRecurso || value != m_FTipoRecurso;
            if (pFldFTipoRecurso)
                m_FTipoRecurso = value;
        }
    }

    public string NFZKey() => m_FZKey ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FZKey
    {
        get => m_FZKey ?? string.Empty;
        set
        {
            pFldFZKey = pFldFZKey || !(m_FZKey ?? string.Empty).Equals(value);
            if (pFldFZKey)
                m_FZKey = value.trim().Length > 25 ? value.trim().substring(0, 25) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public int NFZKeyQuem() => m_FZKeyQuem;
    [XmlAttribute]
    public int FZKeyQuem
    {
        get => m_FZKeyQuem;
        set
        {
            pFldFZKeyQuem = pFldFZKeyQuem || value != m_FZKeyQuem;
            if (pFldFZKeyQuem)
                m_FZKeyQuem = value;
        }
    }

    public string NFZKeyQuando() => $"{m_FZKeyQuando:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FZKeyQuando:dd/MM/yyyy}";
    [XmlIgnore]
    public DateTime MZKeyQuando => Convert.ToDateTime(m_FZKeyQuando);

    [XmlAttribute]
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

    public string NFNroAntigo() => m_FNroAntigo ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FNroAntigo
    {
        get => m_FNroAntigo ?? string.Empty;
        set
        {
            pFldFNroAntigo = pFldFNroAntigo || !(m_FNroAntigo ?? string.Empty).Equals(value);
            if (pFldFNroAntigo)
                m_FNroAntigo = value.trim().Length > 25 ? value.trim().substring(0, 25) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public string NFAccessCode() => m_FAccessCode ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FAccessCode
    {
        get => m_FAccessCode ?? string.Empty;
        set
        {
            pFldFAccessCode = pFldFAccessCode || !(m_FAccessCode ?? string.Empty).Equals(value);
            if (pFldFAccessCode)
                m_FAccessCode = value.trim().Length > 100 ? value.trim().substring(0, 100) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public int NFJulgador() => m_FJulgador;
    [XmlAttribute]
    public int FJulgador
    {
        get => m_FJulgador;
        set
        {
            pFldFJulgador = pFldFJulgador || value != m_FJulgador;
            if (pFldFJulgador)
                m_FJulgador = value;
        }
    }

    public string NFZKeyIA() => m_FZKeyIA ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FZKeyIA
    {
        get => m_FZKeyIA ?? string.Empty;
        set
        {
            pFldFZKeyIA = pFldFZKeyIA || !(m_FZKeyIA ?? string.Empty).Equals(value);
            if (pFldFZKeyIA)
                m_FZKeyIA = value.trim().Length > 25 ? value.trim().substring(0, 25) : value.trim(); // ABC_FIND_CODE123
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
    public List<DBInfoSystem> IFieldsRaw() => throw new NotImplementedException();
    public List<DBInfoSystem> IPkFields() => throw new NotImplementedException();
    public List<DBInfoSystem> IPkIndicesFields() => throw new NotImplementedException();
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public int GetID() => ID;
}