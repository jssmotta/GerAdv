namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBFornecedores
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFGrupo, pFldFNome, pFldFSubGrupo, pFldFTipo, pFldFCNPJ, pFldFInscEst, pFldFRG, pFldFFone, pFldFFax, pFldFEmail, pFldFSite, pFldFObs, pFldFProdutos, pFldFContatos;
    [XmlIgnore]
    private protected int m_FGrupo, m_FSubGrupo;
    [XmlIgnore]
    private protected string? m_FCNPJ, m_FInscEst, m_FRG, m_FFone, m_FFax, m_FEmail, m_FSite, m_FObs, m_FProdutos, m_FContatos;
    [XmlIgnore]
    private protected bool m_FTipo;
    public int NFGrupo() => m_FGrupo;
    [XmlAttribute]
    public int FGrupo
    {
        get => m_FGrupo;
        set
        {
            pFldFGrupo = pFldFGrupo || value != m_FGrupo;
            if (pFldFGrupo)
                m_FGrupo = value;
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
                sex.m_FNome = value.trim().FixAbc().Length > 80 ? value.trim().substring(0, 80).FixAbc() : value.trim().FixAbc(); // SEX_ABC_FIND_CODE123
        }
    }

    public int NFSubGrupo() => m_FSubGrupo;
    [XmlAttribute]
    public int FSubGrupo
    {
        get => m_FSubGrupo;
        set
        {
            pFldFSubGrupo = pFldFSubGrupo || value != m_FSubGrupo;
            if (pFldFSubGrupo)
                m_FSubGrupo = value;
        }
    }

    public bool NFTipo() => m_FTipo;
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

    public string MaskCNPJ => DevourerOne.MaskCnpj(FCNPJ);

    public string NFCNPJ() => m_FCNPJ ?? string.Empty; // Nullable Helper String 1.0.6
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

    public string NFInscEst() => m_FInscEst ?? string.Empty; // Nullable Helper String 1.0.6
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

    public string NFRG() => m_FRG ?? string.Empty; // Nullable Helper String 1.0.6
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

    public string NFFone() => m_FFone ?? string.Empty; // Nullable Helper String 1.0.6
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

    public string NFFax() => m_FFax ?? string.Empty; // Nullable Helper String 1.0.6
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

    public string NFEmail() => m_FEmail ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FEmail
    {
        get => m_FEmail ?? string.Empty;
        set
        {
            pFldFEmail = pFldFEmail || !(m_FEmail ?? string.Empty).Equals(value);
            if (pFldFEmail)
                m_FEmail = value.trim().Length > 150 ? value.trim().substring(0, 150) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public string NFSite() => m_FSite ?? string.Empty; // Nullable Helper String 1.0.6
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

    public string NFObs() => m_FObs ?? string.Empty; // Nullable Helper String 1.0.6
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

    public string NFProdutos() => m_FProdutos ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FProdutos
    {
        get => m_FProdutos ?? string.Empty;
        set
        {
            pFldFProdutos = pFldFProdutos || !(m_FProdutos ?? string.Empty).Equals(value);
            if (pFldFProdutos)
                m_FProdutos = value.trim().FixAbc() ?? string.Empty;
        }
    }

    public string NFContatos() => m_FContatos ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FContatos
    {
        get => m_FContatos ?? string.Empty;
        set
        {
            pFldFContatos = pFldFContatos || !(m_FContatos ?? string.Empty).Equals(value);
            if (pFldFContatos)
                m_FContatos = value.trim().FixAbc() ?? string.Empty;
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