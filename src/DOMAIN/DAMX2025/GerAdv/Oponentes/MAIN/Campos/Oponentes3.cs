namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBOponentes
{
    [XmlIgnore]
    private protected bool pFldFEMPFuncao, pFldFCTPSNumero, pFldFSite, pFldFCTPSSerie, pFldFNome, pFldFAdv, pFldFEMPCliente, pFldFIDRep, pFldFPIS, pFldFContato, pFldFCNPJ, pFldFRG, pFldFJuridica, pFldFTipo, pFldFSexo, pFldFCPF, pFldFEndereco, pFldFFone, pFldFFax, pFldFCidade, pFldFBairro, pFldFCEP, pFldFInscEst, pFldFObservacao, pFldFEMail, pFldFClass, pFldFTop, pFldFEtiqueta, pFldFBold;
    [XmlIgnore]
    private protected int m_FEMPFuncao, m_FAdv, m_FEMPCliente, m_FIDRep, m_FCidade;
    [XmlIgnore]
    private protected string? m_FCTPSNumero, m_FSite, m_FCTPSSerie, m_FNome, m_FPIS, m_FContato, m_FCNPJ, m_FRG, m_FCPF, m_FEndereco, m_FFone, m_FFax, m_FBairro, m_FCEP, m_FInscEst, m_FObservacao, m_FEMail, m_FClass;
    [XmlIgnore]
    private protected bool m_FJuridica, m_FTipo, m_FSexo, m_FTop, m_FEtiqueta, m_FBold;
    public int FEMPFuncao
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FEMPFuncao;
        set
        {
            pFldFEMPFuncao = pFldFEMPFuncao || value != m_FEMPFuncao;
            if (pFldFEMPFuncao)
                m_FEMPFuncao = value;
        }
    }

    [StringLength(15, ErrorMessage = "A propriedade FCTPSNumero da tabela Oponentes deve ter no máximo 15 caracteres.")]
    public string? FCTPSNumero
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FCTPSNumero ?? string.Empty;
        set
        {
            pFldFCTPSNumero = pFldFCTPSNumero || !(m_FCTPSNumero ?? string.Empty).Equals(value);
            if (pFldFCTPSNumero)
            {
                var trimmed = value?.Trim() ?? string.Empty;
                m_FCTPSNumero = trimmed.Length > 15 ? trimmed.AsSpan(0, 15).ToString() : trimmed;
            }
        }
    }

    [StringLength(150, ErrorMessage = "A propriedade FSite da tabela Oponentes deve ter no máximo 150 caracteres.")]
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

    [StringLength(10, ErrorMessage = "A propriedade FCTPSSerie da tabela Oponentes deve ter no máximo 10 caracteres.")]
    public string? FCTPSSerie
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FCTPSSerie ?? string.Empty;
        set
        {
            pFldFCTPSSerie = pFldFCTPSSerie || !(m_FCTPSSerie ?? string.Empty).Equals(value);
            if (pFldFCTPSSerie)
            {
                var trimmed = value?.Trim() ?? string.Empty;
                m_FCTPSSerie = trimmed.Length > 10 ? trimmed.AsSpan(0, 10).ToString() : trimmed;
            }
        }
    }

    [StringLength(80, ErrorMessage = "A propriedade FNome da tabela Oponentes deve ter no máximo 80 caracteres.")]
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

    public int FAdv
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FAdv;
        set
        {
            pFldFAdv = pFldFAdv || value != m_FAdv;
            if (pFldFAdv)
                m_FAdv = value;
        }
    }

    public int FEMPCliente
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FEMPCliente;
        set
        {
            pFldFEMPCliente = pFldFEMPCliente || value != m_FEMPCliente;
            if (pFldFEMPCliente)
                m_FEMPCliente = value;
        }
    }

    public int FIDRep
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FIDRep;
        set
        {
            pFldFIDRep = pFldFIDRep || value != m_FIDRep;
            if (pFldFIDRep)
                m_FIDRep = value;
        }
    }

    [StringLength(20, ErrorMessage = "A propriedade FPIS da tabela Oponentes deve ter no máximo 20 caracteres.")]
    public string? FPIS
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FPIS ?? string.Empty;
        set
        {
            pFldFPIS = pFldFPIS || !(m_FPIS ?? string.Empty).Equals(value);
            if (pFldFPIS)
            {
                var trimmed = value?.Trim() ?? string.Empty;
                m_FPIS = trimmed.Length > 20 ? trimmed.AsSpan(0, 20).ToString() : trimmed;
            }
        }
    }

    public string? FContato
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FContato ?? string.Empty;
        set
        {
            pFldFContato = pFldFContato || !(m_FContato ?? string.Empty).Equals(value);
            if (pFldFContato)
                m_FContato = value.trim().FixAbc() ?? string.Empty;
        }
    }

    [StringLength(14, ErrorMessage = "A propriedade FCNPJ da tabela Oponentes deve ter no máximo 14 caracteres.")]
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

    [StringLength(12, ErrorMessage = "A propriedade FRG da tabela Oponentes deve ter no máximo 12 caracteres.")]
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
                m_FRG = trimmed.Length > 12 ? trimmed.AsSpan(0, 12).ToString() : trimmed;
            }
        }
    }

    public bool FJuridica
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FJuridica;
        set
        {
            pFldFJuridica = pFldFJuridica || value != m_FJuridica;
            if (pFldFJuridica)
                m_FJuridica = value;
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

    [StringLength(11, ErrorMessage = "A propriedade FCPF da tabela Oponentes deve ter no máximo 11 caracteres.")]
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

    [StringLength(80, ErrorMessage = "A propriedade FEndereco da tabela Oponentes deve ter no máximo 80 caracteres.")]
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

    public string? FFax
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FFax ?? string.Empty;
        set
        {
            pFldFFax = pFldFFax || !(m_FFax ?? string.Empty).Equals(value);
            if (pFldFFax)
                m_FFax = value.trim().FixAbc() ?? string.Empty;
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

    [StringLength(50, ErrorMessage = "A propriedade FBairro da tabela Oponentes deve ter no máximo 50 caracteres.")]
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

    [StringLength(10, ErrorMessage = "A propriedade FCEP da tabela Oponentes deve ter no máximo 10 caracteres.")]
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

    [StringLength(15, ErrorMessage = "A propriedade FInscEst da tabela Oponentes deve ter no máximo 15 caracteres.")]
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

    [StringLength(100, ErrorMessage = "A propriedade FEMail da tabela Oponentes deve ter no máximo 100 caracteres.")]
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
                m_FEMail = trimmed.Length > 100 ? trimmed.AsSpan(0, 100).ToString() : trimmed;
                if (m_FEMail.IsValidEmail())
                    return;
                throw new ArgumentException("E-mail inválido ou não informado corretamente.", nameof(value));
            }
        }
    }

    [StringLength(1, ErrorMessage = "A propriedade FClass da tabela Oponentes deve ter no máximo 1 caracteres.")]
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