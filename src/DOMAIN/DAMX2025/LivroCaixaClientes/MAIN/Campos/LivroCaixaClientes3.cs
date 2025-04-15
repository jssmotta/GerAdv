namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBLivroCaixaClientes
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFLivroCaixa, pFldFCliente, pFldFLancado;
    [XmlIgnore]
    private protected int m_FLivroCaixa, m_FCliente;
    [XmlIgnore]
    private protected bool m_FLancado;
    public int NFLivroCaixa() => m_FLivroCaixa;
    [XmlAttribute]
    public int FLivroCaixa
    {
        get => m_FLivroCaixa;
        set
        {
            pFldFLivroCaixa = pFldFLivroCaixa || value != m_FLivroCaixa;
            if (pFldFLivroCaixa)
                m_FLivroCaixa = value;
        }
    }

    public int NFCliente() => m_FCliente;
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

    public bool NFLancado() => m_FLancado;
    [XmlAttribute]
    public bool FLancado
    {
        get => m_FLancado;
        set
        {
            pFldFLancado = pFldFLancado || value != m_FLancado;
            if (pFldFLancado)
                m_FLancado = value;
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