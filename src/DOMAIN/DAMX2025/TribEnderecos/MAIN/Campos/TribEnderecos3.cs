namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBTribEnderecos
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFTribunal, pFldFCidade, pFldFEndereco, pFldFCEP, pFldFFone, pFldFFax, pFldFOBS;
    [XmlIgnore]
    private protected int m_FTribunal, m_FCidade;
    [XmlIgnore]
    private protected string? m_FEndereco, m_FCEP, m_FFone, m_FFax, m_FOBS;
    [XmlAttribute]
    public int FTribunal
    {
        get => m_FTribunal;
        set
        {
            pFldFTribunal = pFldFTribunal || value != m_FTribunal;
            if (pFldFTribunal)
                m_FTribunal = value;
        }
    }

    [XmlAttribute]
    public int FCidade
    {
        get => m_FCidade;
        set
        {
            pFldFCidade = pFldFCidade || value != m_FCidade;
            if (pFldFCidade)
                m_FCidade = value;
        }
    }

    [XmlAttribute]
    public string? FEndereco
    {
        get => m_FEndereco ?? string.Empty;
        set
        {
            pFldFEndereco = pFldFEndereco || !(m_FEndereco ?? string.Empty).Equals(value);
            if (pFldFEndereco)
                m_FEndereco = value.trim().Length > 80 ? value.trim().substring(0, 80) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public string CEPMask() => DevourerOne.MaskCep(FCEP);
    [XmlAttribute]
    public string? FCEP
    {
        get => m_FCEP ?? string.Empty;
        set
        {
            pFldFCEP = pFldFCEP || !(m_FCEP ?? string.Empty).Equals(value);
            if (pFldFCEP)
                m_FCEP = value.trim().Length > 10 ? value.trim().substring(0, 10) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlAttribute]
    public string? FFone
    {
        get => m_FFone ?? string.Empty;
        set
        {
            pFldFFone = pFldFFone || !(m_FFone ?? string.Empty).Equals(value);
            if (pFldFFone)
                m_FFone = value.trim().FixAbc() ?? string.Empty;
        }
    }

    [XmlAttribute]
    public string? FFax
    {
        get => m_FFax ?? string.Empty;
        set
        {
            pFldFFax = pFldFFax || !(m_FFax ?? string.Empty).Equals(value);
            if (pFldFFax)
                m_FFax = value.trim().FixAbc() ?? string.Empty;
        }
    }

    [XmlAttribute]
    public string? FOBS
    {
        get => m_FOBS ?? string.Empty;
        set
        {
            pFldFOBS = pFldFOBS || !(m_FOBS ?? string.Empty).Equals(value);
            if (pFldFOBS)
                m_FOBS = value.trim().FixAbc() ?? string.Empty;
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