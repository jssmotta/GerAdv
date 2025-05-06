namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBPoderJudiciarioAssociado
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFJustica, pFldFJusticaNome, pFldFArea, pFldFAreaNome, pFldFTribunal, pFldFTribunalNome, pFldFForo, pFldFForoNome, pFldFCidade, pFldFSubDivisaoNome, pFldFCidadeNome, pFldFSubDivisao, pFldFTipo;
    [XmlIgnore]
    private protected int m_FJustica, m_FArea, m_FTribunal, m_FForo, m_FCidade, m_FSubDivisao, m_FTipo;
    [XmlIgnore]
    private protected string? m_FJusticaNome, m_FAreaNome, m_FTribunalNome, m_FForoNome, m_FSubDivisaoNome, m_FCidadeNome;
    [XmlAttribute]
    public int FJustica
    {
        get => m_FJustica;
        set
        {
            pFldFJustica = pFldFJustica || value != m_FJustica;
            if (pFldFJustica)
                m_FJustica = value;
        }
    }

    [XmlAttribute]
    public string? FJusticaNome
    {
        get => m_FJusticaNome ?? string.Empty;
        set
        {
            pFldFJusticaNome = pFldFJusticaNome || !(m_FJusticaNome ?? string.Empty).Equals(value);
            if (pFldFJusticaNome)
                m_FJusticaNome = value.trim().Length > 255 ? value.trim().substring(0, 255) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlAttribute]
    public int FArea
    {
        get => m_FArea;
        set
        {
            pFldFArea = pFldFArea || value != m_FArea;
            if (pFldFArea)
                m_FArea = value;
        }
    }

    [XmlAttribute]
    public string? FAreaNome
    {
        get => m_FAreaNome ?? string.Empty;
        set
        {
            pFldFAreaNome = pFldFAreaNome || !(m_FAreaNome ?? string.Empty).Equals(value);
            if (pFldFAreaNome)
                m_FAreaNome = value.trim().Length > 255 ? value.trim().substring(0, 255) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlAttribute]
    public int FTribunal
    {
        get => m_FTribunal;
        set
        {
            pFldFTribunal = pFldFTribunal || value != m_FTribunal;
            if (pFldFTribunal)
                m_FTribunal = value;
        }
    }

    [XmlAttribute]
    public string? FTribunalNome
    {
        get => m_FTribunalNome ?? string.Empty;
        set
        {
            pFldFTribunalNome = pFldFTribunalNome || !(m_FTribunalNome ?? string.Empty).Equals(value);
            if (pFldFTribunalNome)
                m_FTribunalNome = value.trim().Length > 255 ? value.trim().substring(0, 255) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlAttribute]
    public int FForo
    {
        get => m_FForo;
        set
        {
            pFldFForo = pFldFForo || value != m_FForo;
            if (pFldFForo)
                m_FForo = value;
        }
    }

    [XmlAttribute]
    public string? FForoNome
    {
        get => m_FForoNome ?? string.Empty;
        set
        {
            pFldFForoNome = pFldFForoNome || !(m_FForoNome ?? string.Empty).Equals(value);
            if (pFldFForoNome)
                m_FForoNome = value.trim().Length > 255 ? value.trim().substring(0, 255) : value.trim(); // ABC_FIND_CODE123
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
    public string? FSubDivisaoNome
    {
        get => m_FSubDivisaoNome ?? string.Empty;
        set
        {
            pFldFSubDivisaoNome = pFldFSubDivisaoNome || !(m_FSubDivisaoNome ?? string.Empty).Equals(value);
            if (pFldFSubDivisaoNome)
                m_FSubDivisaoNome = value.trim().Length > 255 ? value.trim().substring(0, 255) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlAttribute]
    public string? FCidadeNome
    {
        get => m_FCidadeNome ?? string.Empty;
        set
        {
            pFldFCidadeNome = pFldFCidadeNome || !(m_FCidadeNome ?? string.Empty).Equals(value);
            if (pFldFCidadeNome)
                m_FCidadeNome = value.trim().Length > 255 ? value.trim().substring(0, 255) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlAttribute]
    public int FSubDivisao
    {
        get => m_FSubDivisao;
        set
        {
            pFldFSubDivisao = pFldFSubDivisao || value != m_FSubDivisao;
            if (pFldFSubDivisao)
                m_FSubDivisao = value;
        }
    }

    [XmlAttribute]
    public int FTipo
    {
        get => m_FTipo;
        set
        {
            pFldFTipo = pFldFTipo || value != m_FTipo;
            if (pFldFTipo)
                m_FTipo = value;
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
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public int GetID() => ID;
}