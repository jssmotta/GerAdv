namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBAgenda2Agenda
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFMaster, pFldFAgenda;
    [XmlIgnore]
    private protected int m_FMaster, m_FAgenda;
    [XmlAttribute]
    public int FMaster
    {
        get => m_FMaster;
        set
        {
            pFldFMaster = pFldFMaster || value != m_FMaster;
            if (pFldFMaster)
                m_FMaster = value;
        }
    }

    [XmlAttribute]
    public int FAgenda
    {
        get => m_FAgenda;
        set
        {
            pFldFAgenda = pFldFAgenda || value != m_FAgenda;
            if (pFldFAgenda)
                m_FAgenda = value;
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