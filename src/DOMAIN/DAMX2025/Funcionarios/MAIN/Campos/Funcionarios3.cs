namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBFuncionarios
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFEMailPro, pFldFCargo, pFldFNome, pFldFFuncao, pFldFRegistro, pFldFRG, pFldFTipo, pFldFObservacao, pFldFContato, pFldFFax, pFldFFone, pFldFEMail, pFldFPeriodo_Ini, pFldFPeriodo_Fim, pFldFCTPSNumero, pFldFCTPSSerie, pFldFPIS, pFldFSalario, pFldFCTPSDtEmissao, pFldFData, pFldFLiberaAgenda, pFldFPasta;
    [XmlIgnore]
    private protected int m_FCargo, m_FFuncao;
    [XmlIgnore]
    private protected string? m_FEMailPro, m_FRegistro, m_FRG, m_FObservacao, m_FContato, m_FFax, m_FFone, m_FEMail, m_FCTPSNumero, m_FCTPSSerie, m_FPIS, m_FPasta;
    [XmlIgnore]
    private protected DateTime? m_FPeriodo_Ini, m_FPeriodo_Fim, m_FCTPSDtEmissao, m_FData;
    [XmlIgnore]
    private protected bool m_FTipo, m_FLiberaAgenda;
    [XmlIgnore]
    private protected decimal m_FSalario;
    [XmlAttribute]
    public string? FEMailPro
    {
        get => m_FEMailPro ?? string.Empty;
        set
        {
            pFldFEMailPro = pFldFEMailPro || !(m_FEMailPro ?? string.Empty).Equals(value);
            if (pFldFEMailPro)
                m_FEMailPro = value.trim().Length > 255 ? value.trim().substring(0, 255) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlAttribute]
    public int FCargo
    {
        get => m_FCargo;
        set
        {
            pFldFCargo = pFldFCargo || value != m_FCargo;
            if (pFldFCargo)
                m_FCargo = value;
        }
    }

    [XmlAttribute]
    public string? FNome
    {
        get => sex.m_FNome ?? string.Empty;
        set
        {
            pFldFNome = pFldFNome || !sex.m_FNome.IsEquals(value);
            if (pFldFNome)
                sex.m_FNome = value.trim().FixAbc().Length > 60 ? value.trim().substring(0, 60).FixAbc() : value.trim().FixAbc(); // SEX_ABC_FIND_CODE123
        }
    }

    [XmlAttribute]
    public int FFuncao
    {
        get => m_FFuncao;
        set
        {
            pFldFFuncao = pFldFFuncao || value != m_FFuncao;
            if (pFldFFuncao)
                m_FFuncao = value;
        }
    }

    [XmlAttribute]
    public string? FRegistro
    {
        get => m_FRegistro ?? string.Empty;
        set
        {
            pFldFRegistro = pFldFRegistro || !(m_FRegistro ?? string.Empty).Equals(value);
            if (pFldFRegistro)
                m_FRegistro = value.trim().Length > 20 ? value.trim().substring(0, 20) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlAttribute]
    public string? FRG
    {
        get => m_FRG ?? string.Empty;
        set
        {
            pFldFRG = pFldFRG || !(m_FRG ?? string.Empty).Equals(value);
            if (pFldFRG)
                m_FRG = value.trim().Length > 30 ? value.trim().substring(0, 30) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlAttribute]
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

    [XmlAttribute]
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

    [XmlAttribute]
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

    [XmlAttribute]
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

    [XmlAttribute]
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

    [XmlAttribute]
    public string? FEMail
    {
        get => m_FEMail ?? string.Empty;
        set
        {
            pFldFEMail = pFldFEMail || !(m_FEMail ?? string.Empty).Equals(value);
            if (pFldFEMail)
                m_FEMail = value.trim().Length > 60 ? value.trim().substring(0, 60) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlIgnore]
    public DateTime MPeriodo_Ini => Convert.ToDateTime(m_FPeriodo_Ini);

    [XmlAttribute]
    public string? FPeriodo_Ini
    {
        get => $"{m_FPeriodo_Ini:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FPeriodo_Ini:dd/MM/yyyy}";
        set
        {
            var(setUpNow, changed, data) = DevourerOne.DateUp7(pFldFPeriodo_Ini, m_FPeriodo_Ini, value);
            if (!setUpNow)
                return;
            pFldFPeriodo_Ini = changed;
            m_FPeriodo_Ini = data;
        }
    }

    [XmlIgnore]
    public DateTime MPeriodo_Fim => Convert.ToDateTime(m_FPeriodo_Fim);

    [XmlAttribute]
    public string? FPeriodo_Fim
    {
        get => $"{m_FPeriodo_Fim:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FPeriodo_Fim:dd/MM/yyyy}";
        set
        {
            var(setUpNow, changed, data) = DevourerOne.DateUp7(pFldFPeriodo_Fim, m_FPeriodo_Fim, value);
            if (!setUpNow)
                return;
            pFldFPeriodo_Fim = changed;
            m_FPeriodo_Fim = data;
        }
    }

    [XmlAttribute]
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

    [XmlAttribute]
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

    [XmlAttribute]
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

    [XmlAttribute]
    public decimal FSalario
    {
        get => m_FSalario;
        set
        {
            if (value == m_FSalario)
                return;
            pFldFSalario = true;
            m_FSalario = value;
        }
    }

    [XmlIgnore]
    public DateTime MCTPSDtEmissao => Convert.ToDateTime(m_FCTPSDtEmissao);

    [XmlAttribute]
    public string? FCTPSDtEmissao
    {
        get => $"{m_FCTPSDtEmissao:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FCTPSDtEmissao:dd/MM/yyyy}";
        set
        {
            var(setUpNow, changed, data) = DevourerOne.DateUp7(pFldFCTPSDtEmissao, m_FCTPSDtEmissao, value);
            if (!setUpNow)
                return;
            pFldFCTPSDtEmissao = changed;
            m_FCTPSDtEmissao = data;
        }
    }

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

    [XmlAttribute]
    public bool FLiberaAgenda
    {
        get => m_FLiberaAgenda;
        set
        {
            pFldFLiberaAgenda = pFldFLiberaAgenda || value != m_FLiberaAgenda;
            if (pFldFLiberaAgenda)
                m_FLiberaAgenda = value;
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
                m_FPasta = value.trim().Length > 200 ? value.trim().substring(0, 200) : value.trim(); // ABC_FIND_CODE123
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