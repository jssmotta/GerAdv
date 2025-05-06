namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBOperador
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFEMail, pFldFPasta, pFldFTelefonista, pFldFMaster, pFldFNome, pFldFNick, pFldFRamal, pFldFCadID, pFldFCadCod, pFldFExcluido, pFldFSituacao, pFldFComputador, pFldFMinhaDescricao, pFldFUltimoLogoff, pFldFEMailNet, pFldFOnlineIP, pFldFOnLine, pFldFSysOp, pFldFStatusId, pFldFStatusMessage, pFldFIsFinanceiro, pFldFTop, pFldFBasico, pFldFExterno, pFldFSenha256, pFldFEMailConfirmado, pFldFDataLimiteReset, pFldFSuporteSenha256, pFldFSuporteMaxAge, pFldFSuporteNomeSolicitante, pFldFSuporteUltimoAcesso, pFldFSuporteIpUltimoAcesso;
    [XmlIgnore]
    private protected int m_FCadID, m_FCadCod, m_FComputador, m_FStatusId;
    [XmlIgnore]
    private protected string? m_FEMail, m_FPasta, m_FNome, m_FNick, m_FRamal, m_FMinhaDescricao, m_FEMailNet, m_FOnlineIP, m_FStatusMessage, m_FSenha256, m_FSuporteSenha256, m_FSuporteNomeSolicitante, m_FSuporteIpUltimoAcesso;
    [XmlIgnore]
    private protected DateTime? m_FUltimoLogoff, m_FDataLimiteReset, m_FSuporteMaxAge, m_FSuporteUltimoAcesso;
    [XmlIgnore]
    private protected bool m_FTelefonista, m_FMaster, m_FExcluido, m_FSituacao, m_FOnLine, m_FSysOp, m_FIsFinanceiro, m_FTop, m_FBasico, m_FExterno, m_FEMailConfirmado;
    [XmlAttribute]
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

    [XmlAttribute]
    public string? FPasta
    {
        get => m_FPasta ?? string.Empty;
        set
        {
            pFldFPasta = pFldFPasta || !(m_FPasta ?? string.Empty).Equals(value);
            if (pFldFPasta)
                m_FPasta = value.trim().FixAbc() ?? string.Empty;
        }
    }

    [XmlAttribute]
    public bool FTelefonista
    {
        get => m_FTelefonista;
        set
        {
            pFldFTelefonista = pFldFTelefonista || value != m_FTelefonista;
            if (pFldFTelefonista)
                m_FTelefonista = value;
        }
    }

    [XmlAttribute]
    public bool FMaster
    {
        get => m_FMaster;
        set
        {
            pFldFMaster = pFldFMaster || value != m_FMaster;
            if (pFldFMaster)
                m_FMaster = value;
        }
    }

    [XmlAttribute]
    public string? FNome
    {
        get => m_FNome ?? string.Empty;
        set
        {
            pFldFNome = pFldFNome || !(m_FNome ?? string.Empty).Equals(value);
            if (pFldFNome)
                m_FNome = value.trim().Length > 40 ? value.trim().substring(0, 40) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlAttribute]
    public string? FNick
    {
        get => m_FNick ?? string.Empty;
        set
        {
            pFldFNick = pFldFNick || !(m_FNick ?? string.Empty).Equals(value);
            if (pFldFNick)
                m_FNick = value.trim().Length > 50 ? value.trim().substring(0, 50) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlAttribute]
    public string? FRamal
    {
        get => m_FRamal ?? string.Empty;
        set
        {
            pFldFRamal = pFldFRamal || !(m_FRamal ?? string.Empty).Equals(value);
            if (pFldFRamal)
                m_FRamal = value.trim().Length > 20 ? value.trim().substring(0, 20) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlAttribute]
    public int FCadID
    {
        get => m_FCadID;
        set
        {
            pFldFCadID = pFldFCadID || value != m_FCadID;
            if (pFldFCadID)
                m_FCadID = value;
        }
    }

    [XmlAttribute]
    public int FCadCod
    {
        get => m_FCadCod;
        set
        {
            pFldFCadCod = pFldFCadCod || value != m_FCadCod;
            if (pFldFCadCod)
                m_FCadCod = value;
        }
    }

    [XmlAttribute]
    public bool FExcluido
    {
        get => m_FExcluido;
        set
        {
            pFldFExcluido = pFldFExcluido || value != m_FExcluido;
            if (pFldFExcluido)
                m_FExcluido = value;
        }
    }

    [XmlAttribute]
    public bool FSituacao
    {
        get => m_FSituacao;
        set
        {
            pFldFSituacao = pFldFSituacao || value != m_FSituacao;
            if (pFldFSituacao)
                m_FSituacao = value;
        }
    }

    [XmlAttribute]
    public int FComputador
    {
        get => m_FComputador;
        set
        {
            pFldFComputador = pFldFComputador || value != m_FComputador;
            if (pFldFComputador)
                m_FComputador = value;
        }
    }

    [XmlAttribute]
    public string? FMinhaDescricao
    {
        get => m_FMinhaDescricao ?? string.Empty;
        set
        {
            pFldFMinhaDescricao = pFldFMinhaDescricao || !(m_FMinhaDescricao ?? string.Empty).Equals(value);
            if (pFldFMinhaDescricao)
                m_FMinhaDescricao = value.trim().Length > 255 ? value.trim().substring(0, 255) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlIgnore]
    public DateTime MUltimoLogoff => Convert.ToDateTime(m_FUltimoLogoff);

    [XmlAttribute]
    public string? FUltimoLogoff
    {
        get => $"{m_FUltimoLogoff:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FUltimoLogoff:dd/MM/yyyy}";
        set
        {
            var(setUpNow, changed, data) = DevourerOne.DateUp7(pFldFUltimoLogoff, m_FUltimoLogoff, value);
            if (!setUpNow)
                return;
            pFldFUltimoLogoff = changed;
            m_FUltimoLogoff = data;
        }
    }

    [XmlAttribute]
    public string? FEMailNet
    {
        get => m_FEMailNet ?? string.Empty;
        set
        {
            pFldFEMailNet = pFldFEMailNet || !(m_FEMailNet ?? string.Empty).Equals(value);
            if (pFldFEMailNet)
                m_FEMailNet = value.trim().Length > 100 ? value.trim().substring(0, 100) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlAttribute]
    public string? FOnlineIP
    {
        get => m_FOnlineIP ?? string.Empty;
        set
        {
            pFldFOnlineIP = pFldFOnlineIP || !(m_FOnlineIP ?? string.Empty).Equals(value);
            if (pFldFOnlineIP)
                m_FOnlineIP = value.trim().Length > 50 ? value.trim().substring(0, 50) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlAttribute]
    public bool FOnLine
    {
        get => m_FOnLine;
        set
        {
            pFldFOnLine = pFldFOnLine || value != m_FOnLine;
            if (pFldFOnLine)
                m_FOnLine = value;
        }
    }

    [XmlAttribute]
    public bool FSysOp
    {
        get => m_FSysOp;
        set
        {
            pFldFSysOp = pFldFSysOp || value != m_FSysOp;
            if (pFldFSysOp)
                m_FSysOp = value;
        }
    }

    [XmlAttribute]
    public int FStatusId
    {
        get => m_FStatusId;
        set
        {
            pFldFStatusId = pFldFStatusId || value != m_FStatusId;
            if (pFldFStatusId)
                m_FStatusId = value;
        }
    }

    [XmlAttribute]
    public string? FStatusMessage
    {
        get => m_FStatusMessage ?? string.Empty;
        set
        {
            pFldFStatusMessage = pFldFStatusMessage || !(m_FStatusMessage ?? string.Empty).Equals(value);
            if (pFldFStatusMessage)
                m_FStatusMessage = value.trim().Length > 1024 ? value.trim().substring(0, 1024) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlAttribute]
    public bool FIsFinanceiro
    {
        get => m_FIsFinanceiro;
        set
        {
            pFldFIsFinanceiro = pFldFIsFinanceiro || value != m_FIsFinanceiro;
            if (pFldFIsFinanceiro)
                m_FIsFinanceiro = value;
        }
    }

    [XmlAttribute]
    public bool FTop
    {
        get => m_FTop;
        set
        {
            pFldFTop = pFldFTop || value != m_FTop;
            if (pFldFTop)
                m_FTop = value;
        }
    }

    [XmlAttribute]
    public bool FBasico
    {
        get => m_FBasico;
        set
        {
            pFldFBasico = pFldFBasico || value != m_FBasico;
            if (pFldFBasico)
                m_FBasico = value;
        }
    }

    [XmlAttribute]
    public bool FExterno
    {
        get => m_FExterno;
        set
        {
            pFldFExterno = pFldFExterno || value != m_FExterno;
            if (pFldFExterno)
                m_FExterno = value;
        }
    }

    [XmlAttribute]
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

    [XmlAttribute]
    public bool FEMailConfirmado
    {
        get => m_FEMailConfirmado;
        set
        {
            pFldFEMailConfirmado = pFldFEMailConfirmado || value != m_FEMailConfirmado;
            if (pFldFEMailConfirmado)
                m_FEMailConfirmado = value;
        }
    }

    [XmlIgnore]
    public DateTime MDataLimiteReset => Convert.ToDateTime(m_FDataLimiteReset);

    [XmlAttribute]
    public string? FDataLimiteReset
    {
        get => $"{m_FDataLimiteReset:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FDataLimiteReset:dd/MM/yyyy}";
        set
        {
            var(setUpNow, changed, data) = DevourerOne.DateUp7(pFldFDataLimiteReset, m_FDataLimiteReset, value);
            if (!setUpNow)
                return;
            pFldFDataLimiteReset = changed;
            m_FDataLimiteReset = data;
        }
    }

    [XmlAttribute]
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

    [XmlAttribute]
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

    [XmlAttribute]
    public string? FSuporteNomeSolicitante
    {
        get => m_FSuporteNomeSolicitante ?? string.Empty;
        set
        {
            pFldFSuporteNomeSolicitante = pFldFSuporteNomeSolicitante || !(m_FSuporteNomeSolicitante ?? string.Empty).Equals(value);
            if (pFldFSuporteNomeSolicitante)
                m_FSuporteNomeSolicitante = value.trim().Length > 100 ? value.trim().substring(0, 100) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlIgnore]
    public DateTime MSuporteUltimoAcesso => Convert.ToDateTime(m_FSuporteUltimoAcesso);

    [XmlAttribute]
    public string? FSuporteUltimoAcesso
    {
        get => $"{m_FSuporteUltimoAcesso:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FSuporteUltimoAcesso:dd/MM/yyyy}";
        set
        {
            var(setUpNow, changed, data) = DevourerOne.DateUp7(pFldFSuporteUltimoAcesso, m_FSuporteUltimoAcesso, value);
            if (!setUpNow)
                return;
            pFldFSuporteUltimoAcesso = changed;
            m_FSuporteUltimoAcesso = data;
        }
    }

    [XmlAttribute]
    public string? FSuporteIpUltimoAcesso
    {
        get => m_FSuporteIpUltimoAcesso ?? string.Empty;
        set
        {
            pFldFSuporteIpUltimoAcesso = pFldFSuporteIpUltimoAcesso || !(m_FSuporteIpUltimoAcesso ?? string.Empty).Equals(value);
            if (pFldFSuporteIpUltimoAcesso)
                m_FSuporteIpUltimoAcesso = value.trim().Length > 80 ? value.trim().substring(0, 80) : value.trim(); // ABC_FIND_CODE123
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
    public bool HasPersonSex() => true;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public int GetID() => ID;
}