namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBPrepostos
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFNome, pFldFFuncao, pFldFSetor, pFldFQualificacao, pFldFIdade, pFldFRG, pFldFPeriodo_Ini, pFldFPeriodo_Fim, pFldFRegistro, pFldFCTPSNumero, pFldFCTPSSerie, pFldFCTPSDtEmissao, pFldFPIS, pFldFSalario, pFldFLiberaAgenda, pFldFObservacao, pFldFFone, pFldFFax, pFldFEMail, pFldFPai, pFldFMae;
    [XmlIgnore]
    private protected int m_FFuncao, m_FSetor, m_FIdade;
    [XmlIgnore]
    private protected string? m_FQualificacao, m_FRG, m_FRegistro, m_FCTPSNumero, m_FCTPSSerie, m_FPIS, m_FObservacao, m_FFone, m_FFax, m_FEMail, m_FPai, m_FMae;
    [XmlIgnore]
    private protected DateTime? m_FPeriodo_Ini, m_FPeriodo_Fim, m_FCTPSDtEmissao;
    [XmlIgnore]
    private protected bool m_FLiberaAgenda;
    [XmlIgnore]
    private protected decimal m_FSalario;
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

    public int FSetor
    {
        get => m_FSetor;
        set
        {
            pFldFSetor = pFldFSetor || value != m_FSetor;
            if (pFldFSetor)
                m_FSetor = value;
        }
    }

    public string? FQualificacao
    {
        get => m_FQualificacao ?? string.Empty;
        set
        {
            pFldFQualificacao = pFldFQualificacao || !(m_FQualificacao ?? string.Empty).Equals(value);
            if (pFldFQualificacao)
                m_FQualificacao = value.trim().Length > 100 ? value.trim().substring(0, 100) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public int FIdade
    {
        get => m_FIdade;
        set
        {
            pFldFIdade = pFldFIdade || value != m_FIdade;
            if (pFldFIdade)
                m_FIdade = value;
        }
    }

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

    [XmlIgnore]
    public DateTime MPeriodo_Ini => Convert.ToDateTime(m_FPeriodo_Ini);

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

    public string? FRegistro
    {
        get => m_FRegistro ?? string.Empty;
        set
        {
            pFldFRegistro = pFldFRegistro || !(m_FRegistro ?? string.Empty).Equals(value);
            if (pFldFRegistro)
                m_FRegistro = value.trim().Length > 30 ? value.trim().substring(0, 30) : value.trim(); // ABC_FIND_CODE123
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

    [XmlIgnore]
    public DateTime MCTPSDtEmissao => Convert.ToDateTime(m_FCTPSDtEmissao);

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

    public string? FEMail
    {
        get => m_FEMail ?? string.Empty;
        set
        {
            pFldFEMail = pFldFEMail || !(m_FEMail ?? string.Empty).Equals(value);
            if (pFldFEMail)
                m_FEMail = value.trim().Length > 255 ? value.trim().substring(0, 255) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public string? FPai
    {
        get => m_FPai ?? string.Empty;
        set
        {
            pFldFPai = pFldFPai || !(m_FPai ?? string.Empty).Equals(value);
            if (pFldFPai)
                m_FPai = value.trim().Length > 50 ? value.trim().substring(0, 50) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public string? FMae
    {
        get => m_FMae ?? string.Empty;
        set
        {
            pFldFMae = pFldFMae || !(m_FMae ?? string.Empty).Equals(value);
            if (pFldFMae)
                m_FMae = value.trim().Length > 50 ? value.trim().substring(0, 50) : value.trim(); // ABC_FIND_CODE123
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