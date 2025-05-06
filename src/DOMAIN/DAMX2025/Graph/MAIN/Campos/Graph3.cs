namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBGraph
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFTabela, pFldFTabelaId, pFldFImagem;
    [XmlIgnore]
    private protected int m_FTabelaId;
    [XmlIgnore]
    private protected string? m_FTabela;
    [XmlIgnore]
    private protected byte[]? m_FImagem;
    [XmlAttribute]
    public string? FTabela
    {
        get => m_FTabela ?? string.Empty;
        set
        {
            pFldFTabela = pFldFTabela || !(m_FTabela ?? string.Empty).Equals(value);
            if (pFldFTabela)
                m_FTabela = value.trim().Length > 80 ? value.trim().substring(0, 80) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlAttribute]
    public int FTabelaId
    {
        get => m_FTabelaId;
        set
        {
            pFldFTabelaId = pFldFTabelaId || value != m_FTabelaId;
            if (pFldFTabelaId)
                m_FTabelaId = value;
        }
    }

    [XmlAttribute]
    public byte[] FImagem
    {
        get => m_FImagem ?? [0];
        set
        {
            pFldFImagem = value != m_FImagem;
            m_FImagem = value;
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