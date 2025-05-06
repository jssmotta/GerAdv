namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBAndComp
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFAndamento, pFldFCompromisso;
    [XmlIgnore]
    private protected int m_FAndamento, m_FCompromisso;
    [XmlAttribute]
    public int FAndamento
    {
        get => m_FAndamento;
        set
        {
            pFldFAndamento = pFldFAndamento || value != m_FAndamento;
            if (pFldFAndamento)
                m_FAndamento = value;
        }
    }

    [XmlAttribute]
    public int FCompromisso
    {
        get => m_FCompromisso;
        set
        {
            pFldFCompromisso = pFldFCompromisso || value != m_FCompromisso;
            if (pFldFCompromisso)
                m_FCompromisso = value;
        }
    }

    public int IQuemCad() => 0;
    public int IQuemAtu() => 0;
    public string IDtCadDataX_DataHora() => string.Empty;
    public string IDtAtuDataX_DataHora() => string.Empty;
    [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
    public void SetAuditor(int usuarioId)
    {
    }

    public string ITabelaName() => PTabelaNome;
    public string ICampoCodigo() => CampoCodigo;
    public string ICampoNome() => CampoNome;
    public string IPrefixo() => PTabelaPrefixo;
    public List<DBInfoSystem> IFieldsRaw() => throw new NotImplementedException();
    public List<DBInfoSystem> IPkFields() => throw new NotImplementedException();
    public List<DBInfoSystem> IPkIndicesFields() => throw new NotImplementedException();
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => false;
    public bool HasPersonSex() => false;
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public int GetID() => ID;
}