namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBTribunal
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFNome, pFldFArea, pFldFJustica, pFldFDescricao, pFldFInstancia, pFldFSigla, pFldFWeb, pFldFEtiqueta, pFldFBold;
    [XmlIgnore]
    private protected int m_FArea, m_FJustica, m_FInstancia;
    [XmlIgnore]
    private protected string? m_FNome, m_FDescricao, m_FSigla, m_FWeb;
    [XmlIgnore]
    private protected bool m_FEtiqueta, m_FBold;
    public string NFNome() => m_FNome ?? string.Empty; // Nullable Helper String 1.0.6
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

    public int NFArea() => m_FArea;
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

    public int NFJustica() => m_FJustica;
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

    public string NFDescricao() => m_FDescricao ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FDescricao
    {
        get => m_FDescricao ?? string.Empty;
        set
        {
            pFldFDescricao = pFldFDescricao || !(m_FDescricao ?? string.Empty).Equals(value);
            if (pFldFDescricao)
                m_FDescricao = value.trim().Length > 50 ? value.trim().substring(0, 50) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public int NFInstancia() => m_FInstancia;
    [XmlAttribute]
    public int FInstancia
    {
        get => m_FInstancia;
        set
        {
            pFldFInstancia = pFldFInstancia || value != m_FInstancia;
            if (pFldFInstancia)
                m_FInstancia = value;
        }
    }

    public string NFSigla() => m_FSigla ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FSigla
    {
        get => m_FSigla ?? string.Empty;
        set
        {
            pFldFSigla = pFldFSigla || !(m_FSigla ?? string.Empty).Equals(value);
            if (pFldFSigla)
                m_FSigla = value.trim().Length > 20 ? value.trim().substring(0, 20) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public string NFWeb() => m_FWeb ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FWeb
    {
        get => m_FWeb ?? string.Empty;
        set
        {
            pFldFWeb = pFldFWeb || !(m_FWeb ?? string.Empty).Equals(value);
            if (pFldFWeb)
                m_FWeb = value.trim().Length > 255 ? value.trim().substring(0, 255) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public bool NFEtiqueta() => m_FEtiqueta;
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

    public bool NFBold() => m_FBold;
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