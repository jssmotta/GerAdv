namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBContatoCRMOperador
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFContatoCRM, pFldFCargoEsc, pFldFOperador;
    [XmlIgnore]
    private protected int m_FContatoCRM, m_FCargoEsc, m_FOperador;
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

    [XmlAttribute]
    public int FCargoEsc
    {
        get => m_FCargoEsc;
        set
        {
            pFldFCargoEsc = pFldFCargoEsc || value != m_FCargoEsc;
            if (pFldFCargoEsc)
                m_FCargoEsc = value;
        }
    }

    [XmlAttribute]
    public int FOperador
    {
        get => m_FOperador;
        set
        {
            pFldFOperador = pFldFOperador || value != m_FOperador;
            if (pFldFOperador)
                m_FOperador = value;
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