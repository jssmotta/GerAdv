namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBClientesSocios
{
    [XmlIgnore]
    private protected bool pFldFSomenteRepresentante, pFldFIdade, pFldFIsRepresentanteLegal, pFldFQualificacao, pFldFSexo, pFldFDtNasc, pFldFNome, pFldFSite, pFldFRepresentanteLegal, pFldFCliente, pFldFEndereco, pFldFBairro, pFldFCEP, pFldFCidade, pFldFRG, pFldFCPF, pFldFFone, pFldFParticipacao, pFldFCargo, pFldFEMail, pFldFObs, pFldFCNH, pFldFDataContrato, pFldFCNPJ, pFldFInscEst, pFldFSocioEmpresaAdminNome, pFldFEnderecoSocio, pFldFBairroSocio, pFldFCEPSocio, pFldFCidadeSocio, pFldFRGDataExp, pFldFSocioEmpresaAdminSomente, pFldFTipo, pFldFFax, pFldFClass, pFldFEtiqueta, pFldFAni, pFldFBold;
    [XmlIgnore]
    private protected int m_FIdade, m_FCliente, m_FCidade, m_FCidadeSocio;
    [XmlIgnore]
    private protected string? m_FQualificacao, m_FNome, m_FSite, m_FRepresentanteLegal, m_FEndereco, m_FBairro, m_FCEP, m_FRG, m_FCPF, m_FFone, m_FParticipacao, m_FCargo, m_FEMail, m_FObs, m_FCNH, m_FCNPJ, m_FInscEst, m_FSocioEmpresaAdminNome, m_FEnderecoSocio, m_FBairroSocio, m_FCEPSocio, m_FFax, m_FClass;
    [XmlIgnore]
    private protected DateTime? m_FDtNasc, m_FDataContrato, m_FRGDataExp;
    [XmlIgnore]
    private protected bool m_FSomenteRepresentante, m_FIsRepresentanteLegal, m_FSexo, m_FSocioEmpresaAdminSomente, m_FTipo, m_FEtiqueta, m_FAni, m_FBold;
    public bool FSomenteRepresentante
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FSomenteRepresentante;
        set
        {
            pFldFSomenteRepresentante = pFldFSomenteRepresentante || value != m_FSomenteRepresentante;
            if (pFldFSomenteRepresentante)
                m_FSomenteRepresentante = value;
        }
    }

    public int FIdade
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FIdade;
        set
        {
            pFldFIdade = pFldFIdade || value != m_FIdade;
            if (pFldFIdade)
                m_FIdade = value;
        }
    }

    public bool FIsRepresentanteLegal
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FIsRepresentanteLegal;
        set
        {
            pFldFIsRepresentanteLegal = pFldFIsRepresentanteLegal || value != m_FIsRepresentanteLegal;
            if (pFldFIsRepresentanteLegal)
                m_FIsRepresentanteLegal = value;
        }
    }

    [StringLength(100, ErrorMessage = "A propriedade FQualificacao da tabela ClientesSocios deve ter no máximo 100 caracteres.")]
    public string? FQualificacao
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FQualificacao ?? string.Empty;
        set
        {
            pFldFQualificacao = pFldFQualificacao || !(m_FQualificacao ?? string.Empty).Equals(value);
            if (pFldFQualificacao)
            {
                var trimmed = value?.Trim() ?? string.Empty;
                m_FQualificacao = trimmed.Length > 100 ? trimmed.AsSpan(0, 100).ToString() : trimmed;
            }
        }
    }

    public bool FSexo
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FSexo;
        set
        {
            pFldFSexo = pFldFSexo || value != m_FSexo;
            if (pFldFSexo)
                m_FSexo = value;
        }
    }

    public string? FDtNasc
    {
        get => $"{m_FDtNasc:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FDtNasc:dd/MM/yyyy}";
        set
        {
            var(setUpNow, changed, data) = DevourerOne.DateUp7(pFldFDtNasc, m_FDtNasc, value);
            if (!setUpNow)
                return;
            pFldFDtNasc = changed;
            m_FDtNasc = data;
        }
    }

    [StringLength(50, ErrorMessage = "A propriedade FNome da tabela ClientesSocios deve ter no máximo 50 caracteres.")]
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
                m_FNome = trimmed.Length > 50 ? trimmed.AsSpan(0, 50).ToString() : trimmed;
            }
        }
    }

    [StringLength(150, ErrorMessage = "A propriedade FSite da tabela ClientesSocios deve ter no máximo 150 caracteres.")]
    public string? FSite
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FSite ?? string.Empty;
        set
        {
            pFldFSite = pFldFSite || !(m_FSite ?? string.Empty).Equals(value);
            if (pFldFSite)
            {
                var trimmed = value?.Trim() ?? string.Empty;
                m_FSite = trimmed.Length > 150 ? trimmed.AsSpan(0, 150).ToString() : trimmed;
            }
        }
    }

    [StringLength(50, ErrorMessage = "A propriedade FRepresentanteLegal da tabela ClientesSocios deve ter no máximo 50 caracteres.")]
    public string? FRepresentanteLegal
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FRepresentanteLegal ?? string.Empty;
        set
        {
            pFldFRepresentanteLegal = pFldFRepresentanteLegal || !(m_FRepresentanteLegal ?? string.Empty).Equals(value);
            if (pFldFRepresentanteLegal)
            {
                var trimmed = value?.Trim() ?? string.Empty;
                m_FRepresentanteLegal = trimmed.Length > 50 ? trimmed.AsSpan(0, 50).ToString() : trimmed;
            }
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

    [StringLength(80, ErrorMessage = "A propriedade FEndereco da tabela ClientesSocios deve ter no máximo 80 caracteres.")]
    public string? FEndereco
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FEndereco ?? string.Empty;
        set
        {
            pFldFEndereco = pFldFEndereco || !(m_FEndereco ?? string.Empty).Equals(value);
            if (pFldFEndereco)
            {
                var trimmed = value?.Trim() ?? string.Empty;
                m_FEndereco = trimmed.Length > 80 ? trimmed.AsSpan(0, 80).ToString() : trimmed;
            }
        }
    }

    [StringLength(50, ErrorMessage = "A propriedade FBairro da tabela ClientesSocios deve ter no máximo 50 caracteres.")]
    public string? FBairro
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FBairro ?? string.Empty;
        set
        {
            pFldFBairro = pFldFBairro || !(m_FBairro ?? string.Empty).Equals(value);
            if (pFldFBairro)
            {
                var trimmed = value?.Trim() ?? string.Empty;
                m_FBairro = trimmed.Length > 50 ? trimmed.AsSpan(0, 50).ToString() : trimmed;
            }
        }
    }

    [StringLength(10, ErrorMessage = "A propriedade FCEP da tabela ClientesSocios deve ter no máximo 10 caracteres.")]
    public string? FCEP
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FCEP ?? string.Empty;
        set
        {
            pFldFCEP = pFldFCEP || !(m_FCEP ?? string.Empty).Equals(value);
            if (pFldFCEP)
            {
                var trimmed = value?.Trim() ?? string.Empty;
                m_FCEP = trimmed.Length > 10 ? trimmed.AsSpan(0, 10).ToString() : trimmed;
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

    [StringLength(30, ErrorMessage = "A propriedade FRG da tabela ClientesSocios deve ter no máximo 30 caracteres.")]
    public string? FRG
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FRG ?? string.Empty;
        set
        {
            pFldFRG = pFldFRG || !(m_FRG ?? string.Empty).Equals(value);
            if (pFldFRG)
            {
                var trimmed = value?.Trim() ?? string.Empty;
                m_FRG = trimmed.Length > 30 ? trimmed.AsSpan(0, 30).ToString() : trimmed;
            }
        }
    }

    [StringLength(11, ErrorMessage = "A propriedade FCPF da tabela ClientesSocios deve ter no máximo 11 caracteres.")]
    public string? FCPF
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FCPF ?? string.Empty;
        set
        {
            pFldFCPF = pFldFCPF || !(m_FCPF ?? string.Empty).Equals(value);
            if (pFldFCPF)
            {
                var trimmed = value?.Trim() ?? string.Empty;
                var valueCpf = trimmed.Length > 11 ? trimmed.AsSpan(0, 11).ToString() : trimmed;
                if (valueCpf.IsValidCpf())
                    m_FCPF = valueCpf;
                else
                    throw new ArgumentException("CPF inválido ou não informado corretamente.", nameof(value));
            }
        }
    }

    public string? FFone
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FFone ?? string.Empty;
        set
        {
            pFldFFone = pFldFFone || !(m_FFone ?? string.Empty).Equals(value);
            if (pFldFFone)
                m_FFone = value.trim().FixAbc() ?? string.Empty;
        }
    }

    [StringLength(10, ErrorMessage = "A propriedade FParticipacao da tabela ClientesSocios deve ter no máximo 10 caracteres.")]
    public string? FParticipacao
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FParticipacao ?? string.Empty;
        set
        {
            pFldFParticipacao = pFldFParticipacao || !(m_FParticipacao ?? string.Empty).Equals(value);
            if (pFldFParticipacao)
            {
                var trimmed = value?.Trim() ?? string.Empty;
                m_FParticipacao = trimmed.Length > 10 ? trimmed.AsSpan(0, 10).ToString() : trimmed;
            }
        }
    }

    [StringLength(50, ErrorMessage = "A propriedade FCargo da tabela ClientesSocios deve ter no máximo 50 caracteres.")]
    public string? FCargo
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FCargo ?? string.Empty;
        set
        {
            pFldFCargo = pFldFCargo || !(m_FCargo ?? string.Empty).Equals(value);
            if (pFldFCargo)
            {
                var trimmed = value?.Trim() ?? string.Empty;
                m_FCargo = trimmed.Length > 50 ? trimmed.AsSpan(0, 50).ToString() : trimmed;
            }
        }
    }

    [StringLength(60, ErrorMessage = "A propriedade FEMail da tabela ClientesSocios deve ter no máximo 60 caracteres.")]
    public string? FEMail
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FEMail ?? string.Empty;
        set
        {
            pFldFEMail = pFldFEMail || !(m_FEMail ?? string.Empty).Equals(value);
            if (pFldFEMail)
            {
                var trimmed = value?.Trim() ?? string.Empty;
                m_FEMail = trimmed.Length > 60 ? trimmed.AsSpan(0, 60).ToString() : trimmed;
                if (m_FEMail.IsValidEmail())
                    return;
                throw new ArgumentException("E-mail inválido ou não informado corretamente.", nameof(value));
            }
        }
    }

    public string? FObs
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FObs ?? string.Empty;
        set
        {
            pFldFObs = pFldFObs || !(m_FObs ?? string.Empty).Equals(value);
            if (pFldFObs)
                m_FObs = value.trim().FixAbc() ?? string.Empty;
        }
    }

    [StringLength(100, ErrorMessage = "A propriedade FCNH da tabela ClientesSocios deve ter no máximo 100 caracteres.")]
    public string? FCNH
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FCNH ?? string.Empty;
        set
        {
            pFldFCNH = pFldFCNH || !(m_FCNH ?? string.Empty).Equals(value);
            if (pFldFCNH)
            {
                var trimmed = value?.Trim() ?? string.Empty;
                m_FCNH = trimmed.Length > 100 ? trimmed.AsSpan(0, 100).ToString() : trimmed;
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

    [StringLength(14, ErrorMessage = "A propriedade FCNPJ da tabela ClientesSocios deve ter no máximo 14 caracteres.")]
    public string? FCNPJ
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FCNPJ ?? string.Empty;
        set
        {
            pFldFCNPJ = pFldFCNPJ || !(m_FCNPJ ?? string.Empty).Equals(value);
            if (pFldFCNPJ)
            {
                var trimmed = value?.Trim() ?? string.Empty;
                m_FCNPJ = trimmed.Length > 14 ? trimmed.AsSpan(0, 14).ToString() : trimmed;
            }
        }
    }

    [StringLength(15, ErrorMessage = "A propriedade FInscEst da tabela ClientesSocios deve ter no máximo 15 caracteres.")]
    public string? FInscEst
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FInscEst ?? string.Empty;
        set
        {
            pFldFInscEst = pFldFInscEst || !(m_FInscEst ?? string.Empty).Equals(value);
            if (pFldFInscEst)
            {
                var trimmed = value?.Trim() ?? string.Empty;
                m_FInscEst = trimmed.Length > 15 ? trimmed.AsSpan(0, 15).ToString() : trimmed;
            }
        }
    }

    [StringLength(80, ErrorMessage = "A propriedade FSocioEmpresaAdminNome da tabela ClientesSocios deve ter no máximo 80 caracteres.")]
    public string? FSocioEmpresaAdminNome
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FSocioEmpresaAdminNome ?? string.Empty;
        set
        {
            pFldFSocioEmpresaAdminNome = pFldFSocioEmpresaAdminNome || !(m_FSocioEmpresaAdminNome ?? string.Empty).Equals(value);
            if (pFldFSocioEmpresaAdminNome)
            {
                var trimmed = value?.Trim() ?? string.Empty;
                m_FSocioEmpresaAdminNome = trimmed.Length > 80 ? trimmed.AsSpan(0, 80).ToString() : trimmed;
            }
        }
    }

    [StringLength(80, ErrorMessage = "A propriedade FEnderecoSocio da tabela ClientesSocios deve ter no máximo 80 caracteres.")]
    public string? FEnderecoSocio
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FEnderecoSocio ?? string.Empty;
        set
        {
            pFldFEnderecoSocio = pFldFEnderecoSocio || !(m_FEnderecoSocio ?? string.Empty).Equals(value);
            if (pFldFEnderecoSocio)
            {
                var trimmed = value?.Trim() ?? string.Empty;
                m_FEnderecoSocio = trimmed.Length > 80 ? trimmed.AsSpan(0, 80).ToString() : trimmed;
            }
        }
    }

    [StringLength(50, ErrorMessage = "A propriedade FBairroSocio da tabela ClientesSocios deve ter no máximo 50 caracteres.")]
    public string? FBairroSocio
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FBairroSocio ?? string.Empty;
        set
        {
            pFldFBairroSocio = pFldFBairroSocio || !(m_FBairroSocio ?? string.Empty).Equals(value);
            if (pFldFBairroSocio)
            {
                var trimmed = value?.Trim() ?? string.Empty;
                m_FBairroSocio = trimmed.Length > 50 ? trimmed.AsSpan(0, 50).ToString() : trimmed;
            }
        }
    }

    [StringLength(10, ErrorMessage = "A propriedade FCEPSocio da tabela ClientesSocios deve ter no máximo 10 caracteres.")]
    public string? FCEPSocio
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FCEPSocio ?? string.Empty;
        set
        {
            pFldFCEPSocio = pFldFCEPSocio || !(m_FCEPSocio ?? string.Empty).Equals(value);
            if (pFldFCEPSocio)
            {
                var trimmed = value?.Trim() ?? string.Empty;
                m_FCEPSocio = trimmed.Length > 10 ? trimmed.AsSpan(0, 10).ToString() : trimmed;
            }
        }
    }

    public int FCidadeSocio
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FCidadeSocio;
        set
        {
            pFldFCidadeSocio = pFldFCidadeSocio || value != m_FCidadeSocio;
            if (pFldFCidadeSocio)
                m_FCidadeSocio = value;
        }
    }

    public string? FRGDataExp
    {
        get => $"{m_FRGDataExp:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FRGDataExp:dd/MM/yyyy}";
        set
        {
            var(setUpNow, changed, data) = DevourerOne.DateUp7(pFldFRGDataExp, m_FRGDataExp, value);
            if (!setUpNow)
                return;
            pFldFRGDataExp = changed;
            m_FRGDataExp = data;
        }
    }

    public bool FSocioEmpresaAdminSomente
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FSocioEmpresaAdminSomente;
        set
        {
            pFldFSocioEmpresaAdminSomente = pFldFSocioEmpresaAdminSomente || value != m_FSocioEmpresaAdminSomente;
            if (pFldFSocioEmpresaAdminSomente)
                m_FSocioEmpresaAdminSomente = value;
        }
    }

    public bool FTipo
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FTipo;
        set
        {
            pFldFTipo = pFldFTipo || value != m_FTipo;
            if (pFldFTipo)
                m_FTipo = value;
        }
    }

    [StringLength(2048, ErrorMessage = "A propriedade FFax da tabela ClientesSocios deve ter no máximo 2048 caracteres.")]
    public string? FFax
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FFax ?? string.Empty;
        set
        {
            pFldFFax = pFldFFax || !(m_FFax ?? string.Empty).Equals(value);
            if (pFldFFax)
            {
                var trimmed = value?.Trim() ?? string.Empty;
                m_FFax = trimmed.Length > 2048 ? trimmed.AsSpan(0, 2048).ToString() : trimmed;
            }
        }
    }

    [StringLength(1, ErrorMessage = "A propriedade FClass da tabela ClientesSocios deve ter no máximo 1 caracteres.")]
    public string? FClass
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FClass ?? string.Empty;
        set
        {
            pFldFClass = pFldFClass || !(m_FClass ?? string.Empty).Equals(value);
            if (pFldFClass)
            {
                var trimmed = value?.Trim() ?? string.Empty;
                m_FClass = trimmed.Length > 1 ? trimmed.AsSpan(0, 1).ToString() : trimmed;
            }
        }
    }

    public bool FEtiqueta
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FEtiqueta;
        set
        {
            pFldFEtiqueta = pFldFEtiqueta || value != m_FEtiqueta;
            if (pFldFEtiqueta)
                m_FEtiqueta = value;
        }
    }

    public bool FAni
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FAni;
        set
        {
            pFldFAni = pFldFAni || value != m_FAni;
            if (pFldFAni)
                m_FAni = value;
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