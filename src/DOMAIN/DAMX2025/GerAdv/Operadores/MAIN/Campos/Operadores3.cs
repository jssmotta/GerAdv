namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBOperadores
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
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
        get => m_FGrupo;
        set
        {
            pFldFGrupo = pFldFGrupo || value != m_FGrupo;
            if (pFldFGrupo)
                m_FGrupo = value;
        }
    }

    public string? FNome
    {
        get => m_FNome ?? string.Empty;
        set
        {
            pFldFNome = pFldFNome || !(m_FNome ?? string.Empty).Equals(value);
            if (pFldFNome)
                m_FNome = value.trim().Length > 50 ? value.trim().substring(0, 50) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public string? FEMail
    {
        get => m_FEMail ?? string.Empty;
        set
        {
            pFldFEMail = pFldFEMail || !(m_FEMail ?? string.Empty).Equals(value);
            if (pFldFEMail)
                m_FEMail = value.trim().Length > 150 ? value.trim().substring(0, 150) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public string? FSenha
    {
        get => m_FSenha ?? string.Empty;
        set
        {
            pFldFSenha = pFldFSenha || !(m_FSenha ?? string.Empty).Equals(value);
            if (pFldFSenha)
                m_FSenha = value.trim().Length > 10 ? value.trim().substring(0, 10) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public bool FAtivado
    {
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
        get => m_FAtualizarSenha;
        set
        {
            pFldFAtualizarSenha = pFldFAtualizarSenha || value != m_FAtualizarSenha;
            if (pFldFAtualizarSenha)
                m_FAtualizarSenha = value;
        }
    }

    public string? FSenha256
    {
        get => m_FSenha256 ?? string.Empty;
        set
        {
            pFldFSenha256 = pFldFSenha256 || !(m_FSenha256 ?? string.Empty).Equals(value);
            if (pFldFSenha256)
                m_FSenha256 = value.trim().Length > 4000 ? value.trim().substring(0, 4000) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public string? FSuporteSenha256
    {
        get => m_FSuporteSenha256 ?? string.Empty;
        set
        {
            pFldFSuporteSenha256 = pFldFSuporteSenha256 || !(m_FSuporteSenha256 ?? string.Empty).Equals(value);
            if (pFldFSuporteSenha256)
                m_FSuporteSenha256 = value.trim().Length > 4000 ? value.trim().substring(0, 4000) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlIgnore]
    public DateTime MSuporteMaxAge => Convert.ToDateTime(m_FSuporteMaxAge);

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