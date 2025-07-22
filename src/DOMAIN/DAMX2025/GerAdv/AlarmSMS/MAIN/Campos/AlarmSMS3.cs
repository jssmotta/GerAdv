namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBAlarmSMS
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFDescricao, pFldFHora, pFldFMinuto, pFldFD1, pFldFD2, pFldFD3, pFldFD4, pFldFD5, pFldFD6, pFldFD7, pFldFEMail, pFldFDesativar, pFldFToday, pFldFExcetoDiasFelizes, pFldFDesktop, pFldFAlertarDataHora, pFldFOperador, pFldFGuidExo, pFldFAgenda, pFldFRecado, pFldFEmocao;
    [XmlIgnore]
    private protected int m_FHora, m_FMinuto, m_FOperador, m_FAgenda, m_FRecado, m_FEmocao;
    [XmlIgnore]
    private protected string? m_FDescricao, m_FEMail, m_FGuidExo;
    [XmlIgnore]
    private protected DateTime? m_FToday, m_FAlertarDataHora;
    [XmlIgnore]
    private protected bool m_FD1, m_FD2, m_FD3, m_FD4, m_FD5, m_FD6, m_FD7, m_FDesativar, m_FExcetoDiasFelizes, m_FDesktop;
    public string? FDescricao
    {
        get => m_FDescricao ?? string.Empty;
        set
        {
            pFldFDescricao = pFldFDescricao || !(m_FDescricao ?? string.Empty).Equals(value);
            if (pFldFDescricao)
                m_FDescricao = value.trim().FixAbc() ?? string.Empty;
        }
    }

    public int FHora
    {
        get => m_FHora;
        set
        {
            pFldFHora = pFldFHora || value != m_FHora;
            if (pFldFHora)
                m_FHora = value;
        }
    }

    public int FMinuto
    {
        get => m_FMinuto;
        set
        {
            pFldFMinuto = pFldFMinuto || value != m_FMinuto;
            if (pFldFMinuto)
                m_FMinuto = value;
        }
    }

    public bool FD1
    {
        get => m_FD1;
        set
        {
            pFldFD1 = pFldFD1 || value != m_FD1;
            if (pFldFD1)
                m_FD1 = value;
        }
    }

    public bool FD2
    {
        get => m_FD2;
        set
        {
            pFldFD2 = pFldFD2 || value != m_FD2;
            if (pFldFD2)
                m_FD2 = value;
        }
    }

    public bool FD3
    {
        get => m_FD3;
        set
        {
            pFldFD3 = pFldFD3 || value != m_FD3;
            if (pFldFD3)
                m_FD3 = value;
        }
    }

    public bool FD4
    {
        get => m_FD4;
        set
        {
            pFldFD4 = pFldFD4 || value != m_FD4;
            if (pFldFD4)
                m_FD4 = value;
        }
    }

    public bool FD5
    {
        get => m_FD5;
        set
        {
            pFldFD5 = pFldFD5 || value != m_FD5;
            if (pFldFD5)
                m_FD5 = value;
        }
    }

    public bool FD6
    {
        get => m_FD6;
        set
        {
            pFldFD6 = pFldFD6 || value != m_FD6;
            if (pFldFD6)
                m_FD6 = value;
        }
    }

    public bool FD7
    {
        get => m_FD7;
        set
        {
            pFldFD7 = pFldFD7 || value != m_FD7;
            if (pFldFD7)
                m_FD7 = value;
        }
    }

    public string? FEMail
    {
        get => m_FEMail ?? string.Empty;
        set
        {
            pFldFEMail = pFldFEMail || !(m_FEMail ?? string.Empty).Equals(value);
            if (pFldFEMail)
                m_FEMail = value.trim().Length > 50 ? value.trim().substring(0, 50) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public bool FDesativar
    {
        get => m_FDesativar;
        set
        {
            pFldFDesativar = pFldFDesativar || value != m_FDesativar;
            if (pFldFDesativar)
                m_FDesativar = value;
        }
    }

    [XmlIgnore]
    public DateTime MToday => Convert.ToDateTime(m_FToday);

    public string? FToday
    {
        get => $"{m_FToday:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FToday:dd/MM/yyyy}";
        set
        {
            var(setUpNow, changed, data) = DevourerOne.DateUp7(pFldFToday, m_FToday, value);
            if (!setUpNow)
                return;
            pFldFToday = changed;
            m_FToday = data;
        }
    }

    public bool FExcetoDiasFelizes
    {
        get => m_FExcetoDiasFelizes;
        set
        {
            pFldFExcetoDiasFelizes = pFldFExcetoDiasFelizes || value != m_FExcetoDiasFelizes;
            if (pFldFExcetoDiasFelizes)
                m_FExcetoDiasFelizes = value;
        }
    }

    public bool FDesktop
    {
        get => m_FDesktop;
        set
        {
            pFldFDesktop = pFldFDesktop || value != m_FDesktop;
            if (pFldFDesktop)
                m_FDesktop = value;
        }
    }

    [XmlIgnore]
    public DateTime MAlertarDataHora => Convert.ToDateTime(m_FAlertarDataHora);

    public string? FAlertarDataHora
    {
        get => $"{m_FAlertarDataHora:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FAlertarDataHora:dd/MM/yyyy}";
        set
        {
            var(setUpNow, changed, data) = DevourerOne.DateUp7(pFldFAlertarDataHora, m_FAlertarDataHora, value);
            if (!setUpNow)
                return;
            pFldFAlertarDataHora = changed;
            m_FAlertarDataHora = data;
        }
    }

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

    public string? FGuidExo
    {
        get => m_FGuidExo ?? string.Empty;
        set
        {
            pFldFGuidExo = pFldFGuidExo || !(m_FGuidExo ?? string.Empty).Equals(value);
            if (pFldFGuidExo)
                m_FGuidExo = value.trim().Length > 100 ? value.trim().substring(0, 100) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public int FAgenda
    {
        get => m_FAgenda;
        set
        {
            pFldFAgenda = pFldFAgenda || value != m_FAgenda;
            if (pFldFAgenda)
                m_FAgenda = value;
        }
    }

    public int FRecado
    {
        get => m_FRecado;
        set
        {
            pFldFRecado = pFldFRecado || value != m_FRecado;
            if (pFldFRecado)
                m_FRecado = value;
        }
    }

    public int FEmocao
    {
        get => m_FEmocao;
        set
        {
            pFldFEmocao = pFldFEmocao || value != m_FEmocao;
            if (pFldFEmocao)
                m_FEmocao = value;
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