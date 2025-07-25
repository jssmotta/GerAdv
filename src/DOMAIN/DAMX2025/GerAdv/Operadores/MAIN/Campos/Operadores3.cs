namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBOperadores
{
    [XmlIgnore]
    private protected bool pFldFEnviado, pFldFCasa, pFldFCasaID, pFldFCasaCodigo, pFldFIsNovo, pFldFCliente, pFldFGrupo, pFldFNome, pFldFEMail, pFldFSenha, pFldFAtivado, pFldFAtualizarSenha, pFldFSenha256, pFldFSuporteSenha256, pFldFSuporteMaxAge;
    [XmlIgnore]
    private protected int m_FCasaID, m_FCasaCodigo, m_FCliente, m_FGrupo;
    [XmlIgnore]
    private protected string? m_FNome, m_FEMail, m_FSenha, m_FSenha256, m_FSuporteSenha256;
    [XmlIgnore]
    private protected DateTime? m_FSuporteMaxAge;
    [XmlIgnore]
    private protected bool m_FEnviado, m_FCasa, m_FIsNovo, m_FAtivado, m_FAtualizarSenha;
    public bool FEnviado
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FEnviado;
        set
        {
            pFldFEnviado = pFldFEnviado || value != m_FEnviado;
            if (pFldFEnviado)
                m_FEnviado = value;
        }
    }

    public bool FCasa
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FCasa;
        set
        {
            pFldFCasa = pFldFCasa || value != m_FCasa;
            if (pFldFCasa)
                m_FCasa = value;
        }
    }

    public int FCasaID
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FCasaID;
        set
        {
            pFldFCasaID = pFldFCasaID || value != m_FCasaID;
            if (pFldFCasaID)
                m_FCasaID = value;
        }
    }

    public int FCasaCodigo
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FCasaCodigo;
        set
        {
            pFldFCasaCodigo = pFldFCasaCodigo || value != m_FCasaCodigo;
            if (pFldFCasaCodigo)
                m_FCasaCodigo = value;
        }
    }

    public bool FIsNovo
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FIsNovo;
        set
        {
            pFldFIsNovo = pFldFIsNovo || value != m_FIsNovo;
            if (pFldFIsNovo)
                m_FIsNovo = value;
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

    public int FGrupo
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FGrupo;
        set
        {
            pFldFGrupo = pFldFGrupo || value != m_FGrupo;
            if (pFldFGrupo)
                m_FGrupo = value;
        }
    }

    [StringLength(50, ErrorMessage = "A propriedade FNome da tabela Operadores deve ter no máximo 50 caracteres.")]
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

    [StringLength(150, ErrorMessage = "A propriedade FEMail da tabela Operadores deve ter no máximo 150 caracteres.")]
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
                m_FEMail = trimmed.Length > 150 ? trimmed.AsSpan(0, 150).ToString() : trimmed;
                if (m_FEMail.IsValidEmail())
                    return;
                throw new ArgumentException("E-mail inválido ou não informado corretamente.", nameof(value));
            }
        }
    }

    [StringLength(10, ErrorMessage = "A propriedade FSenha da tabela Operadores deve ter no máximo 10 caracteres.")]
    public string? FSenha
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FSenha ?? string.Empty;
        set
        {
            pFldFSenha = pFldFSenha || !(m_FSenha ?? string.Empty).Equals(value);
            if (pFldFSenha)
            {
                var trimmed = value?.Trim() ?? string.Empty;
                m_FSenha = trimmed.Length > 10 ? trimmed.AsSpan(0, 10).ToString() : trimmed;
            }
        }
    }

    public bool FAtivado
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FAtivado;
        set
        {
            pFldFAtivado = pFldFAtivado || value != m_FAtivado;
            if (pFldFAtivado)
                m_FAtivado = value;
        }
    }

    public bool FAtualizarSenha
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FAtualizarSenha;
        set
        {
            pFldFAtualizarSenha = pFldFAtualizarSenha || value != m_FAtualizarSenha;
            if (pFldFAtualizarSenha)
                m_FAtualizarSenha = value;
        }
    }

    [StringLength(4000, ErrorMessage = "A propriedade FSenha256 da tabela Operadores deve ter no máximo 4000 caracteres.")]
    public string? FSenha256
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FSenha256 ?? string.Empty;
        set
        {
            pFldFSenha256 = pFldFSenha256 || !(m_FSenha256 ?? string.Empty).Equals(value);
            if (pFldFSenha256)
            {
                var trimmed = value?.Trim() ?? string.Empty;
                m_FSenha256 = trimmed.Length > 4000 ? trimmed.AsSpan(0, 4000).ToString() : trimmed;
            }
        }
    }

    [StringLength(4000, ErrorMessage = "A propriedade FSuporteSenha256 da tabela Operadores deve ter no máximo 4000 caracteres.")]
    public string? FSuporteSenha256
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_FSuporteSenha256 ?? string.Empty;
        set
        {
            pFldFSuporteSenha256 = pFldFSuporteSenha256 || !(m_FSuporteSenha256 ?? string.Empty).Equals(value);
            if (pFldFSuporteSenha256)
            {
                var trimmed = value?.Trim() ?? string.Empty;
                m_FSuporteSenha256 = trimmed.Length > 4000 ? trimmed.AsSpan(0, 4000).ToString() : trimmed;
            }
        }
    }

    public string? FSuporteMaxAge
    {
        get => $"{m_FSuporteMaxAge:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FSuporteMaxAge:dd/MM/yyyy}";
        set
        {
            var(setUpNow, changed, data) = DevourerOne.DateUp7(pFldFSuporteMaxAge, m_FSuporteMaxAge, value);
            if (!setUpNow)
                return;
            pFldFSuporteMaxAge = changed;
            m_FSuporteMaxAge = data;
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