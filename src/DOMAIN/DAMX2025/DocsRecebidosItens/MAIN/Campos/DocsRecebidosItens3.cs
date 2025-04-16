namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBDocsRecebidosItens
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFContatoCRM, pFldFNome, pFldFDevolvido, pFldFSeraDevolvido, pFldFObservacoes, pFldFBold;
    [XmlIgnore]
    private protected int m_FContatoCRM;
    [XmlIgnore]
    private protected string? m_FNome, m_FObservacoes;
    [XmlIgnore]
    private protected bool m_FDevolvido, m_FSeraDevolvido, m_FBold;
    public int NFContatoCRM() => m_FContatoCRM;
    [XmlAttribute]
    public int FContatoCRM
    {
        get => m_FContatoCRM;
        set
        {
            pFldFContatoCRM = pFldFContatoCRM || value != m_FContatoCRM;
            if (pFldFContatoCRM)
                m_FContatoCRM = value;
        }
    }

    public string NFNome() => m_FNome ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FNome
    {
        get => m_FNome ?? string.Empty;
        set
        {
            pFldFNome = pFldFNome || !(m_FNome ?? string.Empty).Equals(value);
            if (pFldFNome)
                m_FNome = value.trim().Length > 255 ? value.trim().substring(0, 255) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public bool NFDevolvido() => m_FDevolvido;
    [XmlAttribute]
    public bool FDevolvido
    {
        get => m_FDevolvido;
        set
        {
            pFldFDevolvido = pFldFDevolvido || value != m_FDevolvido;
            if (pFldFDevolvido)
                m_FDevolvido = value;
        }
    }

    public bool NFSeraDevolvido() => m_FSeraDevolvido;
    [XmlAttribute]
    public bool FSeraDevolvido
    {
        get => m_FSeraDevolvido;
        set
        {
            pFldFSeraDevolvido = pFldFSeraDevolvido || value != m_FSeraDevolvido;
            if (pFldFSeraDevolvido)
                m_FSeraDevolvido = value;
        }
    }

    public string NFObservacoes() => m_FObservacoes ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FObservacoes
    {
        get => m_FObservacoes ?? string.Empty;
        set
        {
            pFldFObservacoes = pFldFObservacoes || !(m_FObservacoes ?? string.Empty).Equals(value);
            if (pFldFObservacoes)
                m_FObservacoes = value.trim().FixAbc() ?? string.Empty;
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