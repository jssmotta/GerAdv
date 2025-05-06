namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBTerceiros
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFProcesso, pFldFNome, pFldFSituacao, pFldFCidade, pFldFEndereco, pFldFBairro, pFldFCEP, pFldFFone, pFldFFax, pFldFOBS, pFldFEMail, pFldFClass, pFldFVaraForoComarca;
    [XmlIgnore]
    private protected int m_FProcesso, m_FSituacao, m_FCidade;
    [XmlIgnore]
    private protected string? m_FNome, m_FEndereco, m_FBairro, m_FCEP, m_FFone, m_FFax, m_FOBS, m_FEMail, m_FClass, m_FVaraForoComarca;
    [XmlAttribute]
    public int FProcesso
    {
        get => m_FProcesso;
        set
        {
            pFldFProcesso = pFldFProcesso || value != m_FProcesso;
            if (pFldFProcesso)
                m_FProcesso = value;
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
                m_FNome = value.trim().Length > 80 ? value.trim().substring(0, 80) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlAttribute]
    public int FSituacao
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
    public int FCidade
    {
        get => m_FCidade;
        set
        {
            pFldFCidade = pFldFCidade || value != m_FCidade;
            if (pFldFCidade)
                m_FCidade = value;
        }
    }

    [XmlAttribute]
    public string? FEndereco
    {
        get => m_FEndereco ?? string.Empty;
        set
        {
            pFldFEndereco = pFldFEndereco || !(m_FEndereco ?? string.Empty).Equals(value);
            if (pFldFEndereco)
                m_FEndereco = value.trim().Length > 80 ? value.trim().substring(0, 80) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlAttribute]
    public string? FBairro
    {
        get => m_FBairro ?? string.Empty;
        set
        {
            pFldFBairro = pFldFBairro || !(m_FBairro ?? string.Empty).Equals(value);
            if (pFldFBairro)
                m_FBairro = value.trim().Length > 50 ? value.trim().substring(0, 50) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public string CEPMask() => DevourerOne.MaskCep(FCEP);
    [XmlAttribute]
    public string? FCEP
    {
        get => m_FCEP ?? string.Empty;
        set
        {
            pFldFCEP = pFldFCEP || !(m_FCEP ?? string.Empty).Equals(value);
            if (pFldFCEP)
                m_FCEP = value.trim().Length > 10 ? value.trim().substring(0, 10) : value.trim(); // ABC_FIND_CODE123
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
    public string? FOBS
    {
        get => m_FOBS ?? string.Empty;
        set
        {
            pFldFOBS = pFldFOBS || !(m_FOBS ?? string.Empty).Equals(value);
            if (pFldFOBS)
                m_FOBS = value.trim().FixAbc() ?? string.Empty;
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
                m_FEMail = value.trim().Length > 150 ? value.trim().substring(0, 150) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlAttribute]
    public string? FClass
    {
        get => m_FClass ?? string.Empty;
        set
        {
            pFldFClass = pFldFClass || !(m_FClass ?? string.Empty).Equals(value);
            if (pFldFClass)
                m_FClass = value.trim().Length > 1 ? value.trim().substring(0, 1) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlAttribute]
    public string? FVaraForoComarca
    {
        get => m_FVaraForoComarca ?? string.Empty;
        set
        {
            pFldFVaraForoComarca = pFldFVaraForoComarca || !(m_FVaraForoComarca ?? string.Empty).Equals(value);
            if (pFldFVaraForoComarca)
                m_FVaraForoComarca = value.trim().Length > 255 ? value.trim().substring(0, 255) : value.trim(); // ABC_FIND_CODE123
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