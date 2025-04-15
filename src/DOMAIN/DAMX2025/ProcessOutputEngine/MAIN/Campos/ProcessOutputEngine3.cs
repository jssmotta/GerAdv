namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBProcessOutputEngine
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFNome, pFldFDatabase, pFldFTabela, pFldFCampo, pFldFValor, pFldFOutput, pFldFAdministrador, pFldFOutputSource, pFldFDisabledItem, pFldFIDModulo, pFldFIsOnlyProcesso, pFldFMyID, pFldFGUID;
    [XmlIgnore]
    private protected int m_FOutputSource, m_FIDModulo, m_FMyID;
    [XmlIgnore]
    private protected string? m_FNome, m_FDatabase, m_FTabela, m_FCampo, m_FValor, m_FOutput, m_FGUID;
    [XmlIgnore]
    private protected bool m_FAdministrador, m_FDisabledItem, m_FIsOnlyProcesso;
    public string NFNome() => m_FNome ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FNome
    {
        get => m_FNome ?? string.Empty;
        set
        {
            pFldFNome = pFldFNome || !(m_FNome ?? string.Empty).Equals(value);
            if (pFldFNome)
                m_FNome = value.trim().Length > 255 ? value.trim().substring(0, 255) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public string NFDatabase() => m_FDatabase ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FDatabase
    {
        get => m_FDatabase ?? string.Empty;
        set
        {
            pFldFDatabase = pFldFDatabase || !(m_FDatabase ?? string.Empty).Equals(value);
            if (pFldFDatabase)
                m_FDatabase = value.trim().Length > 255 ? value.trim().substring(0, 255) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public string NFTabela() => m_FTabela ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FTabela
    {
        get => m_FTabela ?? string.Empty;
        set
        {
            pFldFTabela = pFldFTabela || !(m_FTabela ?? string.Empty).Equals(value);
            if (pFldFTabela)
                m_FTabela = value.trim().Length > 255 ? value.trim().substring(0, 255) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public string NFCampo() => m_FCampo ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FCampo
    {
        get => m_FCampo ?? string.Empty;
        set
        {
            pFldFCampo = pFldFCampo || !(m_FCampo ?? string.Empty).Equals(value);
            if (pFldFCampo)
                m_FCampo = value.trim().Length > 255 ? value.trim().substring(0, 255) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public string NFValor() => m_FValor ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FValor
    {
        get => m_FValor ?? string.Empty;
        set
        {
            pFldFValor = pFldFValor || !(m_FValor ?? string.Empty).Equals(value);
            if (pFldFValor)
                m_FValor = value.trim().Length > 255 ? value.trim().substring(0, 255) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public string NFOutput() => m_FOutput ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FOutput
    {
        get => m_FOutput ?? string.Empty;
        set
        {
            pFldFOutput = pFldFOutput || !(m_FOutput ?? string.Empty).Equals(value);
            if (pFldFOutput)
                m_FOutput = value.trim().FixAbc() ?? string.Empty;
        }
    }

    public bool NFAdministrador() => m_FAdministrador;
    [XmlAttribute]
    public bool FAdministrador
    {
        get => m_FAdministrador;
        set
        {
            pFldFAdministrador = pFldFAdministrador || value != m_FAdministrador;
            if (pFldFAdministrador)
                m_FAdministrador = value;
        }
    }

    public int NFOutputSource() => m_FOutputSource;
    [XmlAttribute]
    public int FOutputSource
    {
        get => m_FOutputSource;
        set
        {
            pFldFOutputSource = pFldFOutputSource || value != m_FOutputSource;
            if (pFldFOutputSource)
                m_FOutputSource = value;
        }
    }

    public bool NFDisabledItem() => m_FDisabledItem;
    [XmlAttribute]
    public bool FDisabledItem
    {
        get => m_FDisabledItem;
        set
        {
            pFldFDisabledItem = pFldFDisabledItem || value != m_FDisabledItem;
            if (pFldFDisabledItem)
                m_FDisabledItem = value;
        }
    }

    public int NFIDModulo() => m_FIDModulo;
    [XmlAttribute]
    public int FIDModulo
    {
        get => m_FIDModulo;
        set
        {
            pFldFIDModulo = pFldFIDModulo || value != m_FIDModulo;
            if (pFldFIDModulo)
                m_FIDModulo = value;
        }
    }

    public bool NFIsOnlyProcesso() => m_FIsOnlyProcesso;
    [XmlAttribute]
    public bool FIsOnlyProcesso
    {
        get => m_FIsOnlyProcesso;
        set
        {
            pFldFIsOnlyProcesso = pFldFIsOnlyProcesso || value != m_FIsOnlyProcesso;
            if (pFldFIsOnlyProcesso)
                m_FIsOnlyProcesso = value;
        }
    }

    public int NFMyID() => m_FMyID;
    [XmlAttribute]
    public int FMyID
    {
        get => m_FMyID;
        set
        {
            pFldFMyID = pFldFMyID || value != m_FMyID;
            if (pFldFMyID)
                m_FMyID = value;
        }
    }

    public string NFGUID() => m_FGUID ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FGUID
    {
        get => m_FGUID ?? string.Empty;
        set
        {
            pFldFGUID = pFldFGUID || !(m_FGUID ?? string.Empty).Equals(value);
            if (pFldFGUID)
                m_FGUID = value.trim().Length > 100 ? value.trim().substring(0, 100) : value.trim(); // NO_ABC_FIND_CODE2
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