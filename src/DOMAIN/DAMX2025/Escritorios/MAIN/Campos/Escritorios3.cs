namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBEscritorios
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFCNPJ, pFldFCasa, pFldFParceria, pFldFNome, pFldFOAB, pFldFEndereco, pFldFCidade, pFldFBairro, pFldFCEP, pFldFFone, pFldFFax, pFldFSite, pFldFEMail, pFldFOBS, pFldFAdvResponsavel, pFldFSecretaria, pFldFInscEst, pFldFCorrespondente, pFldFTop, pFldFEtiqueta, pFldFBold;
    [XmlIgnore]
    private protected int m_FCidade;
    [XmlIgnore]
    private protected string? m_FCNPJ, m_FNome, m_FOAB, m_FEndereco, m_FBairro, m_FCEP, m_FFone, m_FFax, m_FSite, m_FEMail, m_FOBS, m_FAdvResponsavel, m_FSecretaria, m_FInscEst;
    [XmlIgnore]
    private protected bool m_FCasa, m_FParceria, m_FCorrespondente, m_FTop, m_FEtiqueta, m_FBold;
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

    [XmlAttribute]
    public bool FParceria
    {
        get => m_FParceria;
        set
        {
            pFldFParceria = pFldFParceria || value != m_FParceria;
            if (pFldFParceria)
                m_FParceria = value;
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
                m_FNome = value.trim().Length > 50 ? value.trim().substring(0, 50) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlAttribute]
    public string? FOAB
    {
        get => m_FOAB ?? string.Empty;
        set
        {
            pFldFOAB = pFldFOAB || !(m_FOAB ?? string.Empty).Equals(value);
            if (pFldFOAB)
                m_FOAB = value.trim().Length > 15 ? value.trim().substring(0, 15) : value.trim(); // ABC_FIND_CODE123
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
                m_FEndereco = value.trim().Length > 50 ? value.trim().substring(0, 50) : value.trim(); // ABC_FIND_CODE123
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
    public string? FBairro
    {
        get => m_FBairro ?? string.Empty;
        set
        {
            pFldFBairro = pFldFBairro || !(m_FBairro ?? string.Empty).Equals(value);
            if (pFldFBairro)
                m_FBairro = value.trim().Length > 30 ? value.trim().substring(0, 30) : value.trim(); // ABC_FIND_CODE123
        }
    }

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
    public string? FSite
    {
        get => m_FSite ?? string.Empty;
        set
        {
            pFldFSite = pFldFSite || !(m_FSite ?? string.Empty).Equals(value);
            if (pFldFSite)
                m_FSite = value.trim().Length > 200 ? value.trim().substring(0, 200) : value.trim(); // ABC_FIND_CODE123
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
                m_FEMail = value.trim().Length > 100 ? value.trim().substring(0, 100) : value.trim(); // ABC_FIND_CODE123
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
    public string? FAdvResponsavel
    {
        get => m_FAdvResponsavel ?? string.Empty;
        set
        {
            pFldFAdvResponsavel = pFldFAdvResponsavel || !(m_FAdvResponsavel ?? string.Empty).Equals(value);
            if (pFldFAdvResponsavel)
                m_FAdvResponsavel = value.trim().Length > 80 ? value.trim().substring(0, 80) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlAttribute]
    public string? FSecretaria
    {
        get => m_FSecretaria ?? string.Empty;
        set
        {
            pFldFSecretaria = pFldFSecretaria || !(m_FSecretaria ?? string.Empty).Equals(value);
            if (pFldFSecretaria)
                m_FSecretaria = value.trim().Length > 80 ? value.trim().substring(0, 80) : value.trim(); // ABC_FIND_CODE123
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
    public bool FCorrespondente
    {
        get => m_FCorrespondente;
        set
        {
            pFldFCorrespondente = pFldFCorrespondente || value != m_FCorrespondente;
            if (pFldFCorrespondente)
                m_FCorrespondente = value;
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
    public bool FEtiqueta
    {
        get => m_FEtiqueta;
        set
        {
            pFldFEtiqueta = pFldFEtiqueta || value != m_FEtiqueta;
            if (pFldFEtiqueta)
                m_FEtiqueta = value;
        }
    }

    [XmlAttribute]
    public bool FBold
    {
        get => m_FBold;
        set
        {
            pFldFBold = pFldFBold || value != m_FBold;
            if (pFldFBold)
                m_FBold = value;
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