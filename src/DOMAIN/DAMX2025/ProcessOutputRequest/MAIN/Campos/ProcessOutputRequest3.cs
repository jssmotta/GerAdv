namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBProcessOutputRequest
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFProcessOutputEngine, pFldFOperador, pFldFProcesso, pFldFUltimoIdTabelaExo;
    [XmlIgnore]
    private protected int m_FProcessOutputEngine, m_FOperador, m_FProcesso, m_FUltimoIdTabelaExo;
    [XmlAttribute]
    public int FProcessOutputEngine
    {
        get => m_FProcessOutputEngine;
        set
        {
            pFldFProcessOutputEngine = pFldFProcessOutputEngine || value != m_FProcessOutputEngine;
            if (pFldFProcessOutputEngine)
                m_FProcessOutputEngine = value;
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

    [XmlAttribute]
    public int FProcesso
    {
        get => m_FProcesso;
        set
        {
            pFldFProcesso = pFldFProcesso || value != m_FProcesso;
            if (pFldFProcesso)
                m_FProcesso = value;
        }
    }

    [XmlAttribute]
    public int FUltimoIdTabelaExo
    {
        get => m_FUltimoIdTabelaExo;
        set
        {
            pFldFUltimoIdTabelaExo = pFldFUltimoIdTabelaExo || value != m_FUltimoIdTabelaExo;
            if (pFldFUltimoIdTabelaExo)
                m_FUltimoIdTabelaExo = value;
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