namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBProPartes
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFParte, pFldFProcesso;
    [XmlIgnore]
    private protected int m_FParte, m_FProcesso;
    public int NFParte() => m_FParte;
    [XmlAttribute]
    public int FParte
    {
        get => m_FParte;
        set
        {
            pFldFParte = pFldFParte || value != m_FParte;
            if (pFldFParte)
                m_FParte = value;
        }
    }

    public int NFProcesso() => m_FProcesso;
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