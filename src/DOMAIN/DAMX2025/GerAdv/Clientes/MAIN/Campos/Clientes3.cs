namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBClientes
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFEmpresa, pFldFIcone, pFldFNomeMae, pFldFRGDataExp, pFldFInativo, pFldFQuemIndicou, pFldFSendEMail, pFldFNome, pFldFAdv, pFldFIDRep, pFldFJuridica, pFldFNomeFantasia, pFldFTipo, pFldFInscEst, pFldFQualificacao, pFldFIdade, pFldFCNPJ, pFldFRG, pFldFTipoCaptacao, pFldFObservacao, pFldFFax, pFldFFone, pFldFData, pFldFHomePage, pFldFEMail, pFldFObito, pFldFNomePai, pFldFRGOExpeditor, pFldFRegimeTributacao, pFldFEnquadramentoEmpresa, pFldFReportECBOnly, pFldFProBono, pFldFCNH, pFldFPessoaContato;
    [XmlIgnore]
    private protected int m_FEmpresa, m_FAdv, m_FIDRep, m_FIdade, m_FRegimeTributacao, m_FEnquadramentoEmpresa;
    [XmlIgnore]
    private protected string? m_FIcone, m_FNomeMae, m_FQuemIndicou, m_FNomeFantasia, m_FInscEst, m_FQualificacao, m_FCNPJ, m_FRG, m_FObservacao, m_FFax, m_FFone, m_FHomePage, m_FEMail, m_FNomePai, m_FRGOExpeditor, m_FCNH, m_FPessoaContato;
    [XmlIgnore]
    private protected DateTime? m_FRGDataExp, m_FData;
    [XmlIgnore]
    private protected bool m_FInativo, m_FSendEMail, m_FJuridica, m_FTipo, m_FTipoCaptacao, m_FObito, m_FReportECBOnly, m_FProBono;
    public int FEmpresa
    {
        get => m_FEmpresa;
        set
        {
            pFldFEmpresa = pFldFEmpresa || value != m_FEmpresa;
            if (pFldFEmpresa)
                m_FEmpresa = value;
        }
    }

    public string? FIcone
    {
        get => m_FIcone ?? string.Empty;
        set
        {
            pFldFIcone = pFldFIcone || !(m_FIcone ?? string.Empty).Equals(value);
            if (pFldFIcone)
                m_FIcone = value.trim().Length > 255 ? value.trim().substring(0, 255) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public string? FNomeMae
    {
        get => m_FNomeMae ?? string.Empty;
        set
        {
            pFldFNomeMae = pFldFNomeMae || !(m_FNomeMae ?? string.Empty).Equals(value);
            if (pFldFNomeMae)
                m_FNomeMae = value.trim().Length > 80 ? value.trim().substring(0, 80) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlIgnore]
    public DateTime MRGDataExp => Convert.ToDateTime(m_FRGDataExp);

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

    public bool FInativo
    {
        get => m_FInativo;
        set
        {
            pFldFInativo = pFldFInativo || value != m_FInativo;
            if (pFldFInativo)
                m_FInativo = value;
        }
    }

    public string? FQuemIndicou
    {
        get => m_FQuemIndicou ?? string.Empty;
        set
        {
            pFldFQuemIndicou = pFldFQuemIndicou || !(m_FQuemIndicou ?? string.Empty).Equals(value);
            if (pFldFQuemIndicou)
                m_FQuemIndicou = value.trim().Length > 80 ? value.trim().substring(0, 80) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public bool FSendEMail
    {
        get => m_FSendEMail;
        set
        {
            pFldFSendEMail = pFldFSendEMail || value != m_FSendEMail;
            if (pFldFSendEMail)
                m_FSendEMail = value;
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

    public string? FNomeFantasia
    {
        get => m_FNomeFantasia ?? string.Empty;
        set
        {
            pFldFNomeFantasia = pFldFNomeFantasia || !(m_FNomeFantasia ?? string.Empty).Equals(value);
            if (pFldFNomeFantasia)
                m_FNomeFantasia = value.trim().Length > 80 ? value.trim().substring(0, 80) : value.trim(); // ABC_FIND_CODE123
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
                m_FRG = value.trim().Length > 50 ? value.trim().substring(0, 50) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public bool FTipoCaptacao
    {
        get => m_FTipoCaptacao;
        set
        {
            pFldFTipoCaptacao = pFldFTipoCaptacao || value != m_FTipoCaptacao;
            if (pFldFTipoCaptacao)
                m_FTipoCaptacao = value;
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

    [XmlIgnore]
    public DateTime MData => Convert.ToDateTime(m_FData);

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

    public string? FHomePage
    {
        get => m_FHomePage ?? string.Empty;
        set
        {
            pFldFHomePage = pFldFHomePage || !(m_FHomePage ?? string.Empty).Equals(value);
            if (pFldFHomePage)
                m_FHomePage = value.trim().Length > 60 ? value.trim().substring(0, 60) : value.trim(); // ABC_FIND_CODE123
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

    public bool FObito
    {
        get => m_FObito;
        set
        {
            pFldFObito = pFldFObito || value != m_FObito;
            if (pFldFObito)
                m_FObito = value;
        }
    }

    public string? FNomePai
    {
        get => m_FNomePai ?? string.Empty;
        set
        {
            pFldFNomePai = pFldFNomePai || !(m_FNomePai ?? string.Empty).Equals(value);
            if (pFldFNomePai)
                m_FNomePai = value.trim().Length > 80 ? value.trim().substring(0, 80) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public string? FRGOExpeditor
    {
        get => m_FRGOExpeditor ?? string.Empty;
        set
        {
            pFldFRGOExpeditor = pFldFRGOExpeditor || !(m_FRGOExpeditor ?? string.Empty).Equals(value);
            if (pFldFRGOExpeditor)
                m_FRGOExpeditor = value.trim().Length > 30 ? value.trim().substring(0, 30) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public int FRegimeTributacao
    {
        get => m_FRegimeTributacao;
        set
        {
            pFldFRegimeTributacao = pFldFRegimeTributacao || value != m_FRegimeTributacao;
            if (pFldFRegimeTributacao)
                m_FRegimeTributacao = value;
        }
    }

    public int FEnquadramentoEmpresa
    {
        get => m_FEnquadramentoEmpresa;
        set
        {
            pFldFEnquadramentoEmpresa = pFldFEnquadramentoEmpresa || value != m_FEnquadramentoEmpresa;
            if (pFldFEnquadramentoEmpresa)
                m_FEnquadramentoEmpresa = value;
        }
    }

    public bool FReportECBOnly
    {
        get => m_FReportECBOnly;
        set
        {
            pFldFReportECBOnly = pFldFReportECBOnly || value != m_FReportECBOnly;
            if (pFldFReportECBOnly)
                m_FReportECBOnly = value;
        }
    }

    public bool FProBono
    {
        get => m_FProBono;
        set
        {
            pFldFProBono = pFldFProBono || value != m_FProBono;
            if (pFldFProBono)
                m_FProBono = value;
        }
    }

    public string? FCNH
    {
        get => m_FCNH ?? string.Empty;
        set
        {
            pFldFCNH = pFldFCNH || !(m_FCNH ?? string.Empty).Equals(value);
            if (pFldFCNH)
                m_FCNH = value.trim().Length > 100 ? value.trim().substring(0, 100) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public string? FPessoaContato
    {
        get => m_FPessoaContato ?? string.Empty;
        set
        {
            pFldFPessoaContato = pFldFPessoaContato || !(m_FPessoaContato ?? string.Empty).Equals(value);
            if (pFldFPessoaContato)
                m_FPessoaContato = value.trim().Length > 120 ? value.trim().substring(0, 120) : value.trim(); // ABC_FIND_CODE123
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