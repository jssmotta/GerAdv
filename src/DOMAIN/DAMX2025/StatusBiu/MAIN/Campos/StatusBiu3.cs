namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBStatusBiu
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFNome, pFldFTipoStatusBiu, pFldFOperador, pFldFIcone;
    [XmlIgnore]
    private protected int m_FTipoStatusBiu, m_FOperador, m_FIcone;
    [XmlIgnore]
    private protected string? m_FNome;
    [XmlAttribute]
    public string? FNome
    {
        get => m_FNome ?? string.Empty;
        set
        {
            pFldFNome = pFldFNome || !(m_FNome ?? string.Empty).Equals(value);
            if (pFldFNome)
                m_FNome = value.trim().Length > 1024 ? value.trim().substring(0, 1024) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlAttribute]
    public int FTipoStatusBiu
    {
        get => m_FTipoStatusBiu;
        set
        {
            pFldFTipoStatusBiu = pFldFTipoStatusBiu || value != m_FTipoStatusBiu;
            if (pFldFTipoStatusBiu)
                m_FTipoStatusBiu = value;
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
    public int FIcone
    {
        get => m_FIcone;
        set
        {
            pFldFIcone = pFldFIcone || value != m_FIcone;
            if (pFldFIcone)
                m_FIcone = value;
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
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public int GetID() => ID;
}