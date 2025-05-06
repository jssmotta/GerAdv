namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBGUTAtividadesMatriz
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFGUTMatriz, pFldFGUTAtividade;
    [XmlIgnore]
    private protected int m_FGUTMatriz, m_FGUTAtividade;
    [XmlAttribute]
    public int FGUTMatriz
    {
        get => m_FGUTMatriz;
        set
        {
            pFldFGUTMatriz = pFldFGUTMatriz || value != m_FGUTMatriz;
            if (pFldFGUTMatriz)
                m_FGUTMatriz = value;
        }
    }

    [XmlAttribute]
    public int FGUTAtividade
    {
        get => m_FGUTAtividade;
        set
        {
            pFldFGUTAtividade = pFldFGUTAtividade || value != m_FGUTAtividade;
            if (pFldFGUTAtividade)
                m_FGUTAtividade = value;
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