namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBOponentes
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFEMPFuncao, pFldFCTPSNumero, pFldFSite, pFldFCTPSSerie, pFldFNome, pFldFAdv, pFldFEMPCliente, pFldFIDRep, pFldFPIS, pFldFContato, pFldFCNPJ, pFldFRG, pFldFJuridica, pFldFTipo, pFldFFone, pFldFFax, pFldFInscEst, pFldFObservacao, pFldFEMail, pFldFTop;
    [XmlIgnore]
    private protected int m_FEMPFuncao, m_FAdv, m_FEMPCliente, m_FIDRep;
    [XmlIgnore]
    private protected string? m_FCTPSNumero, m_FSite, m_FCTPSSerie, m_FPIS, m_FContato, m_FCNPJ, m_FRG, m_FFone, m_FFax, m_FInscEst, m_FObservacao, m_FEMail;
    [XmlIgnore]
    private protected bool m_FJuridica, m_FTipo, m_FTop;
    public int FEMPFuncao
    {
        get => m_FEMPFuncao;
        set
        {
            pFldFEMPFuncao = pFldFEMPFuncao || value != m_FEMPFuncao;
            if (pFldFEMPFuncao)
                m_FEMPFuncao = value;
        }
    }

    public string? FCTPSNumero
    {
        get => m_FCTPSNumero ?? string.Empty;
        set
        {
            pFldFCTPSNumero = pFldFCTPSNumero || !(m_FCTPSNumero ?? string.Empty).Equals(value);
            if (pFldFCTPSNumero)
                m_FCTPSNumero = value.trim().Length > 15 ? value.trim().substring(0, 15) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public string? FSite
    {
        get => m_FSite ?? string.Empty;
        set
        {
            pFldFSite = pFldFSite || !(m_FSite ?? string.Empty).Equals(value);
            if (pFldFSite)
                m_FSite = value.trim().Length > 150 ? value.trim().substring(0, 150) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public string? FCTPSSerie
    {
        get => m_FCTPSSerie ?? string.Empty;
        set
        {
            pFldFCTPSSerie = pFldFCTPSSerie || !(m_FCTPSSerie ?? string.Empty).Equals(value);
            if (pFldFCTPSSerie)
                m_FCTPSSerie = value.trim().Length > 10 ? value.trim().substring(0, 10) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public string? FNome
    {
        get => sex.m_FNome ?? string.Empty;
        set
        {
            pFldFNome = pFldFNome || !sex.m_FNome.IsEquals(value);
            if (pFldFNome)
                sex.m_FNome = value.trim().FixAbc().Length > 80 ? value.trim().substring(0, 80).FixAbc() : value.trim().FixAbc(); // SEX_ABC_FIND_CODE123
        }
    }

    public int FAdv
    {
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
        get => m_FIDRep;
        set
        {
            pFldFIDRep = pFldFIDRep || value != m_FIDRep;
            if (pFldFIDRep)
                m_FIDRep = value;
        }
    }

    public string? FPIS
    {
        get => m_FPIS ?? string.Empty;
        set
        {
            pFldFPIS = pFldFPIS || !(m_FPIS ?? string.Empty).Equals(value);
            if (pFldFPIS)
                m_FPIS = value.trim().Length > 20 ? value.trim().substring(0, 20) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public string? FContato
    {
        get => m_FContato ?? string.Empty;
        set
        {
            pFldFContato = pFldFContato || !(m_FContato ?? string.Empty).Equals(value);
            if (pFldFContato)
                m_FContato = value.trim().FixAbc() ?? string.Empty;
        }
    }

    public string? FCNPJ
    {
        get => m_FCNPJ ?? string.Empty;
        set
        {
            pFldFCNPJ = pFldFCNPJ || !(m_FCNPJ ?? string.Empty).Equals(value);
            if (pFldFCNPJ)
                m_FCNPJ = value.trim().Length > 14 ? value.trim().substring(0, 14) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public string? FRG
    {
        get => m_FRG ?? string.Empty;
        set
        {
            pFldFRG = pFldFRG || !(m_FRG ?? string.Empty).Equals(value);
            if (pFldFRG)
                m_FRG = value.trim().Length > 12 ? value.trim().substring(0, 12) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public bool FJuridica
    {
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
        get => m_FTipo;
        set
        {
            pFldFTipo = pFldFTipo || value != m_FTipo;
            if (pFldFTipo)
                m_FTipo = value;
        }
    }

    public string? FFone
    {
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
        get => m_FFax ?? string.Empty;
        set
        {
            pFldFFax = pFldFFax || !(m_FFax ?? string.Empty).Equals(value);
            if (pFldFFax)
                m_FFax = value.trim().FixAbc() ?? string.Empty;
        }
    }

    public string? FInscEst
    {
        get => m_FInscEst ?? string.Empty;
        set
        {
            pFldFInscEst = pFldFInscEst || !(m_FInscEst ?? string.Empty).Equals(value);
            if (pFldFInscEst)
                m_FInscEst = value.trim().Length > 15 ? value.trim().substring(0, 15) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public string? FObservacao
    {
        get => m_FObservacao ?? string.Empty;
        set
        {
            pFldFObservacao = pFldFObservacao || !(m_FObservacao ?? string.Empty).Equals(value);
            if (pFldFObservacao)
                m_FObservacao = value.trim().FixAbc() ?? string.Empty;
        }
    }

    public string? FEMail
    {
        get => m_FEMail ?? string.Empty;
        set
        {
            pFldFEMail = pFldFEMail || !(m_FEMail ?? string.Empty).Equals(value);
            if (pFldFEMail)
                m_FEMail = value.trim().Length > 100 ? value.trim().substring(0, 100) : value.trim(); // ABC_FIND_CODE123
        }
    }

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