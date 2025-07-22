namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBOperadorEMailPopup
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFOperador, pFldFNome, pFldFSenha, pFldFSMTP, pFldFPOP3, pFldFAutenticacao, pFldFDescricao, pFldFUsuario, pFldFPortaSmtp, pFldFPortaPop3, pFldFAssinatura, pFldFSenha256;
    [XmlIgnore]
    private protected int m_FOperador, m_FPortaSmtp, m_FPortaPop3;
    [XmlIgnore]
    private protected string? m_FNome, m_FSenha, m_FSMTP, m_FPOP3, m_FDescricao, m_FUsuario, m_FAssinatura, m_FSenha256;
    [XmlIgnore]
    private protected bool m_FAutenticacao;
    public int FOperador
    {
        get => m_FOperador;
        set
        {
            pFldFOperador = pFldFOperador || value != m_FOperador;
            if (pFldFOperador)
                m_FOperador = value;
        }
    }

    public string? FNome
    {
        get => m_FNome ?? string.Empty;
        set
        {
            pFldFNome = pFldFNome || !(m_FNome ?? string.Empty).Equals(value);
            if (pFldFNome)
                m_FNome = value.trim().Length > 80 ? value.trim().substring(0, 80) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public string? FSenha
    {
        get => m_FSenha ?? string.Empty;
        set
        {
            pFldFSenha = pFldFSenha || !(m_FSenha ?? string.Empty).Equals(value);
            if (pFldFSenha)
                m_FSenha = value.trim().Length > 50 ? value.trim().substring(0, 50) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public string? FSMTP
    {
        get => m_FSMTP ?? string.Empty;
        set
        {
            pFldFSMTP = pFldFSMTP || !(m_FSMTP ?? string.Empty).Equals(value);
            if (pFldFSMTP)
                m_FSMTP = value.trim().Length > 255 ? value.trim().substring(0, 255) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public string? FPOP3
    {
        get => m_FPOP3 ?? string.Empty;
        set
        {
            pFldFPOP3 = pFldFPOP3 || !(m_FPOP3 ?? string.Empty).Equals(value);
            if (pFldFPOP3)
                m_FPOP3 = value.trim().Length > 255 ? value.trim().substring(0, 255) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public bool FAutenticacao
    {
        get => m_FAutenticacao;
        set
        {
            pFldFAutenticacao = pFldFAutenticacao || value != m_FAutenticacao;
            if (pFldFAutenticacao)
                m_FAutenticacao = value;
        }
    }

    public string? FDescricao
    {
        get => m_FDescricao ?? string.Empty;
        set
        {
            pFldFDescricao = pFldFDescricao || !(m_FDescricao ?? string.Empty).Equals(value);
            if (pFldFDescricao)
                m_FDescricao = value.trim().Length > 100 ? value.trim().substring(0, 100) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public string? FUsuario
    {
        get => m_FUsuario ?? string.Empty;
        set
        {
            pFldFUsuario = pFldFUsuario || !(m_FUsuario ?? string.Empty).Equals(value);
            if (pFldFUsuario)
                m_FUsuario = value.trim().Length > 50 ? value.trim().substring(0, 50) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public int FPortaSmtp
    {
        get => m_FPortaSmtp;
        set
        {
            pFldFPortaSmtp = pFldFPortaSmtp || value != m_FPortaSmtp;
            if (pFldFPortaSmtp)
                m_FPortaSmtp = value;
        }
    }

    public int FPortaPop3
    {
        get => m_FPortaPop3;
        set
        {
            pFldFPortaPop3 = pFldFPortaPop3 || value != m_FPortaPop3;
            if (pFldFPortaPop3)
                m_FPortaPop3 = value;
        }
    }

    public string? FAssinatura
    {
        get => m_FAssinatura ?? string.Empty;
        set
        {
            pFldFAssinatura = pFldFAssinatura || !(m_FAssinatura ?? string.Empty).Equals(value);
            if (pFldFAssinatura)
                m_FAssinatura = value.trim().FixAbc() ?? string.Empty;
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