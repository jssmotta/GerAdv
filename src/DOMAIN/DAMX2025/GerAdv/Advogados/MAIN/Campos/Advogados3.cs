namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBAdvogados
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFCargo, pFldFEMailPro, pFldFNome, pFldFRG, pFldFCasa, pFldFNomeMae, pFldFEscritorio, pFldFEstagiario, pFldFOAB, pFldFNomeCompleto, pFldFCTPSSerie, pFldFCTPS, pFldFFone, pFldFFax, pFldFComissao, pFldFDtInicio, pFldFDtFim, pFldFSalario, pFldFSecretaria, pFldFTextoProcuracao, pFldFEMail, pFldFEspecializacao, pFldFPasta, pFldFObservacao, pFldFContaBancaria, pFldFParcTop, pFldFTop;
    [XmlIgnore]
    private protected int m_FCargo, m_FEscritorio, m_FComissao;
    [XmlIgnore]
    private protected string? m_FEMailPro, m_FRG, m_FNomeMae, m_FOAB, m_FNomeCompleto, m_FCTPSSerie, m_FCTPS, m_FFone, m_FFax, m_FSecretaria, m_FTextoProcuracao, m_FEMail, m_FEspecializacao, m_FPasta, m_FObservacao, m_FContaBancaria;
    [XmlIgnore]
    private protected DateTime? m_FDtInicio, m_FDtFim;
    [XmlIgnore]
    private protected bool m_FCasa, m_FEstagiario, m_FParcTop, m_FTop;
    [XmlIgnore]
    private protected decimal m_FSalario;
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

    public string? FNome
    {
        get => sex.m_FNome ?? string.Empty;
        set
        {
            pFldFNome = pFldFNome || !sex.m_FNome.IsEquals(value);
            if (pFldFNome)
                sex.m_FNome = value.trim().FixAbc().Length > 50 ? value.trim().substring(0, 50).FixAbc() : value.trim().FixAbc(); // SEX_ABC_FIND_CODE123
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

    public int FEscritorio
    {
        get => m_FEscritorio;
        set
        {
            pFldFEscritorio = pFldFEscritorio || value != m_FEscritorio;
            if (pFldFEscritorio)
                m_FEscritorio = value;
        }
    }

    public bool FEstagiario
    {
        get => m_FEstagiario;
        set
        {
            pFldFEstagiario = pFldFEstagiario || value != m_FEstagiario;
            if (pFldFEstagiario)
                m_FEstagiario = value;
        }
    }

    public string? FOAB
    {
        get => m_FOAB ?? string.Empty;
        set
        {
            pFldFOAB = pFldFOAB || !(m_FOAB ?? string.Empty).Equals(value);
            if (pFldFOAB)
                m_FOAB = value.trim().Length > 12 ? value.trim().substring(0, 12) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public string? FNomeCompleto
    {
        get => m_FNomeCompleto ?? string.Empty;
        set
        {
            pFldFNomeCompleto = pFldFNomeCompleto || !(m_FNomeCompleto ?? string.Empty).Equals(value);
            if (pFldFNomeCompleto)
                m_FNomeCompleto = value.trim().Length > 50 ? value.trim().substring(0, 50) : value.trim(); // ABC_FIND_CODE123
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

    public string? FCTPS
    {
        get => m_FCTPS ?? string.Empty;
        set
        {
            pFldFCTPS = pFldFCTPS || !(m_FCTPS ?? string.Empty).Equals(value);
            if (pFldFCTPS)
                m_FCTPS = value.trim().Length > 15 ? value.trim().substring(0, 15) : value.trim(); // ABC_FIND_CODE123
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

    public int FComissao
    {
        get => m_FComissao;
        set
        {
            pFldFComissao = pFldFComissao || value != m_FComissao;
            if (pFldFComissao)
                m_FComissao = value;
        }
    }

    [XmlIgnore]
    public DateTime MDtInicio => Convert.ToDateTime(m_FDtInicio);

    public string? FDtInicio
    {
        get => $"{m_FDtInicio:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FDtInicio:dd/MM/yyyy}";
        set
        {
            var(setUpNow, changed, data) = DevourerOne.DateUp7(pFldFDtInicio, m_FDtInicio, value);
            if (!setUpNow)
                return;
            pFldFDtInicio = changed;
            m_FDtInicio = data;
        }
    }

    [XmlIgnore]
    public DateTime MDtFim => Convert.ToDateTime(m_FDtFim);

    public string? FDtFim
    {
        get => $"{m_FDtFim:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FDtFim:dd/MM/yyyy}";
        set
        {
            var(setUpNow, changed, data) = DevourerOne.DateUp7(pFldFDtFim, m_FDtFim, value);
            if (!setUpNow)
                return;
            pFldFDtFim = changed;
            m_FDtFim = data;
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

    public string? FSecretaria
    {
        get => m_FSecretaria ?? string.Empty;
        set
        {
            pFldFSecretaria = pFldFSecretaria || !(m_FSecretaria ?? string.Empty).Equals(value);
            if (pFldFSecretaria)
                m_FSecretaria = value.trim().Length > 20 ? value.trim().substring(0, 20) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public string? FTextoProcuracao
    {
        get => m_FTextoProcuracao ?? string.Empty;
        set
        {
            pFldFTextoProcuracao = pFldFTextoProcuracao || !(m_FTextoProcuracao ?? string.Empty).Equals(value);
            if (pFldFTextoProcuracao)
                m_FTextoProcuracao = value.trim().Length > 200 ? value.trim().substring(0, 200) : value.trim(); // ABC_FIND_CODE123
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

    public string? FEspecializacao
    {
        get => m_FEspecializacao ?? string.Empty;
        set
        {
            pFldFEspecializacao = pFldFEspecializacao || !(m_FEspecializacao ?? string.Empty).Equals(value);
            if (pFldFEspecializacao)
                m_FEspecializacao = value.trim().FixAbc() ?? string.Empty;
        }
    }

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

    public string? FContaBancaria
    {
        get => m_FContaBancaria ?? string.Empty;
        set
        {
            pFldFContaBancaria = pFldFContaBancaria || !(m_FContaBancaria ?? string.Empty).Equals(value);
            if (pFldFContaBancaria)
                m_FContaBancaria = value.trim().FixAbc() ?? string.Empty;
        }
    }

    public bool FParcTop
    {
        get => m_FParcTop;
        set
        {
            pFldFParcTop = pFldFParcTop || value != m_FParcTop;
            if (pFldFParcTop)
                m_FParcTop = value;
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