namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBUF
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFDDD, pFldFID, pFldFPais, pFldFTop, pFldFDescricao;
    [XmlIgnore]
    private protected int m_FPais;
    [XmlIgnore]
    private protected string? m_FDDD, m_FID, m_FDescricao;
    [XmlIgnore]
    private protected bool m_FTop;
    [XmlAttribute]
    public string? FDDD
    {
        get => m_FDDD ?? string.Empty;
        set
        {
            pFldFDDD = pFldFDDD || !(m_FDDD ?? string.Empty).Equals(value);
            if (pFldFDDD)
                m_FDDD = value.trim().Length > 10 ? value.trim().substring(0, 10) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlAttribute]
    public string? FID
    {
        get => m_FID ?? string.Empty;
        set
        {
            pFldFID = pFldFID || !(m_FID ?? string.Empty).Equals(value);
            if (pFldFID)
                m_FID = value.trim().Length > 4 ? value.trim().substring(0, 4) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlAttribute]
    public int FPais
    {
        get => m_FPais;
        set
        {
            pFldFPais = pFldFPais || value != m_FPais;
            if (pFldFPais)
                m_FPais = value;
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
    public string? FDescricao
    {
        get => m_FDescricao ?? string.Empty;
        set
        {
            pFldFDescricao = pFldFDescricao || !(m_FDescricao ?? string.Empty).Equals(value);
            if (pFldFDescricao)
                m_FDescricao = value.trim().Length > 40 ? value.trim().substring(0, 40) : value.trim(); // ABC_FIND_CODE123
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