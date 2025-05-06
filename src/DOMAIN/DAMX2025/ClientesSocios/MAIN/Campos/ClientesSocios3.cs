namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBClientesSocios
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFSomenteRepresentante, pFldFIdade, pFldFIsRepresentanteLegal, pFldFQualificacao, pFldFNome, pFldFSite, pFldFRepresentanteLegal, pFldFCliente, pFldFRG, pFldFFone, pFldFParticipacao, pFldFCargo, pFldFEMail, pFldFObs, pFldFCNH, pFldFDataContrato, pFldFCNPJ, pFldFInscEst, pFldFSocioEmpresaAdminNome, pFldFEnderecoSocio, pFldFBairroSocio, pFldFCEPSocio, pFldFCidadeSocio, pFldFRGDataExp, pFldFSocioEmpresaAdminSomente, pFldFTipo, pFldFFax;
    [XmlIgnore]
    private protected int m_FIdade, m_FCliente, m_FCidadeSocio;
    [XmlIgnore]
    private protected string? m_FQualificacao, m_FSite, m_FRepresentanteLegal, m_FRG, m_FFone, m_FParticipacao, m_FCargo, m_FEMail, m_FObs, m_FCNH, m_FCNPJ, m_FInscEst, m_FSocioEmpresaAdminNome, m_FEnderecoSocio, m_FBairroSocio, m_FCEPSocio, m_FFax;
    [XmlIgnore]
    private protected DateTime? m_FDataContrato, m_FRGDataExp;
    [XmlIgnore]
    private protected bool m_FSomenteRepresentante, m_FIsRepresentanteLegal, m_FSocioEmpresaAdminSomente, m_FTipo;
    [XmlAttribute]
    public bool FSomenteRepresentante
    {
        get => m_FSomenteRepresentante;
        set
        {
            pFldFSomenteRepresentante = pFldFSomenteRepresentante || value != m_FSomenteRepresentante;
            if (pFldFSomenteRepresentante)
                m_FSomenteRepresentante = value;
        }
    }

    [XmlAttribute]
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

    [XmlAttribute]
    public bool FIsRepresentanteLegal
    {
        get => m_FIsRepresentanteLegal;
        set
        {
            pFldFIsRepresentanteLegal = pFldFIsRepresentanteLegal || value != m_FIsRepresentanteLegal;
            if (pFldFIsRepresentanteLegal)
                m_FIsRepresentanteLegal = value;
        }
    }

    [XmlAttribute]
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

    [XmlAttribute]
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

    [XmlAttribute]
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

    [XmlAttribute]
    public string? FRepresentanteLegal
    {
        get => m_FRepresentanteLegal ?? string.Empty;
        set
        {
            pFldFRepresentanteLegal = pFldFRepresentanteLegal || !(m_FRepresentanteLegal ?? string.Empty).Equals(value);
            if (pFldFRepresentanteLegal)
                m_FRepresentanteLegal = value.trim().Length > 50 ? value.trim().substring(0, 50) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlAttribute]
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
    public string? FParticipacao
    {
        get => m_FParticipacao ?? string.Empty;
        set
        {
            pFldFParticipacao = pFldFParticipacao || !(m_FParticipacao ?? string.Empty).Equals(value);
            if (pFldFParticipacao)
                m_FParticipacao = value.trim().Length > 10 ? value.trim().substring(0, 10) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlAttribute]
    public string? FCargo
    {
        get => m_FCargo ?? string.Empty;
        set
        {
            pFldFCargo = pFldFCargo || !(m_FCargo ?? string.Empty).Equals(value);
            if (pFldFCargo)
                m_FCargo = value.trim().Length > 50 ? value.trim().substring(0, 50) : value.trim(); // ABC_FIND_CODE123
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

    [XmlAttribute]
    public string? FObs
    {
        get => m_FObs ?? string.Empty;
        set
        {
            pFldFObs = pFldFObs || !(m_FObs ?? string.Empty).Equals(value);
            if (pFldFObs)
                m_FObs = value.trim().FixAbc() ?? string.Empty;
        }
    }

    [XmlAttribute]
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

    [XmlIgnore]
    public DateTime MDataContrato => Convert.ToDateTime(m_FDataContrato);

    [XmlAttribute]
    public string? FDataContrato
    {
        get => $"{m_FDataContrato:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FDataContrato:dd/MM/yyyy}";
        set
        {
            var(setUpNow, changed, data) = DevourerOne.DateUp7(pFldFDataContrato, m_FDataContrato, value);
            if (!setUpNow)
                return;
            pFldFDataContrato = changed;
            m_FDataContrato = data;
        }
    }

    public string MaskCNPJ => DevourerOne.MaskCnpj(FCNPJ);

    [XmlAttribute]
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

    [XmlAttribute]
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

    [XmlAttribute]
    public string? FSocioEmpresaAdminNome
    {
        get => m_FSocioEmpresaAdminNome ?? string.Empty;
        set
        {
            pFldFSocioEmpresaAdminNome = pFldFSocioEmpresaAdminNome || !(m_FSocioEmpresaAdminNome ?? string.Empty).Equals(value);
            if (pFldFSocioEmpresaAdminNome)
                m_FSocioEmpresaAdminNome = value.trim().Length > 80 ? value.trim().substring(0, 80) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlAttribute]
    public string? FEnderecoSocio
    {
        get => m_FEnderecoSocio ?? string.Empty;
        set
        {
            pFldFEnderecoSocio = pFldFEnderecoSocio || !(m_FEnderecoSocio ?? string.Empty).Equals(value);
            if (pFldFEnderecoSocio)
                m_FEnderecoSocio = value.trim().Length > 80 ? value.trim().substring(0, 80) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlAttribute]
    public string? FBairroSocio
    {
        get => m_FBairroSocio ?? string.Empty;
        set
        {
            pFldFBairroSocio = pFldFBairroSocio || !(m_FBairroSocio ?? string.Empty).Equals(value);
            if (pFldFBairroSocio)
                m_FBairroSocio = value.trim().Length > 50 ? value.trim().substring(0, 50) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlAttribute]
    public string? FCEPSocio
    {
        get => m_FCEPSocio ?? string.Empty;
        set
        {
            pFldFCEPSocio = pFldFCEPSocio || !(m_FCEPSocio ?? string.Empty).Equals(value);
            if (pFldFCEPSocio)
                m_FCEPSocio = value.trim().Length > 10 ? value.trim().substring(0, 10) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlAttribute]
    public int FCidadeSocio
    {
        get => m_FCidadeSocio;
        set
        {
            pFldFCidadeSocio = pFldFCidadeSocio || value != m_FCidadeSocio;
            if (pFldFCidadeSocio)
                m_FCidadeSocio = value;
        }
    }

    [XmlIgnore]
    public DateTime MRGDataExp => Convert.ToDateTime(m_FRGDataExp);

    [XmlAttribute]
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

    [XmlAttribute]
    public bool FSocioEmpresaAdminSomente
    {
        get => m_FSocioEmpresaAdminSomente;
        set
        {
            pFldFSocioEmpresaAdminSomente = pFldFSocioEmpresaAdminSomente || value != m_FSocioEmpresaAdminSomente;
            if (pFldFSocioEmpresaAdminSomente)
                m_FSocioEmpresaAdminSomente = value;
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
    public string? FFax
    {
        get => m_FFax ?? string.Empty;
        set
        {
            pFldFFax = pFldFFax || !(m_FFax ?? string.Empty).Equals(value);
            if (pFldFFax)
                m_FFax = value.trim().Length > 2048 ? value.trim().substring(0, 2048) : value.trim(); // ABC_FIND_CODE123
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