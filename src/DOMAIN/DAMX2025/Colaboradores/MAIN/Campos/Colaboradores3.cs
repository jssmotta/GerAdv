namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBColaboradores
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFCargo, pFldFCliente, pFldFNome, pFldFRG, pFldFIdade, pFldFFone, pFldFObservacao, pFldFEMail, pFldFCNH;
    [XmlIgnore]
    private protected int m_FCargo, m_FCliente, m_FIdade;
    [XmlIgnore]
    private protected string? m_FRG, m_FFone, m_FObservacao, m_FEMail, m_FCNH;
    public int NFCargo() => m_FCargo;
    [XmlAttribute]
    public int FCargo
    {
        get => m_FCargo;
        set
        {
            pFldFCargo = pFldFCargo || value != m_FCargo;
            if (pFldFCargo)
                m_FCargo = value;
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

    [XmlAttribute]
    public string? FNome
    {
        get => sex.m_FNome ?? string.Empty;
        set
        {
            pFldFNome = pFldFNome || !sex.m_FNome.IsEquals(value);
            if (pFldFNome)
                sex.m_FNome = value.trim().FixAbc().Length > 80 ? value.trim().substring(0, 80).FixAbc() : value.trim().FixAbc(); // SEX_ABC_FIND_CODE123
        }
    }

    public string NFRG() => m_FRG ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FRG
    {
        get => m_FRG ?? string.Empty;
        set
        {
            pFldFRG = pFldFRG || !(m_FRG ?? string.Empty).Equals(value);
            if (pFldFRG)
                m_FRG = value.trim().Length > 30 ? value.trim().substring(0, 30) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public int NFIdade() => m_FIdade;
    [XmlAttribute]
    public int FIdade
    {
        get => m_FIdade;
        set
        {
            pFldFIdade = pFldFIdade || value != m_FIdade;
            if (pFldFIdade)
                m_FIdade = value;
        }
    }

    public string NFFone() => m_FFone ?? string.Empty; // Nullable Helper String 1.0.6
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

    public string NFObservacao() => m_FObservacao ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FObservacao
    {
        get => m_FObservacao ?? string.Empty;
        set
        {
            pFldFObservacao = pFldFObservacao || !(m_FObservacao ?? string.Empty).Equals(value);
            if (pFldFObservacao)
                m_FObservacao = value.trim().FixAbc() ?? string.Empty;
        }
    }

    public string NFEMail() => m_FEMail ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FEMail
    {
        get => m_FEMail ?? string.Empty;
        set
        {
            pFldFEMail = pFldFEMail || !(m_FEMail ?? string.Empty).Equals(value);
            if (pFldFEMail)
                m_FEMail = value.trim().Length > 150 ? value.trim().substring(0, 150) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public string NFCNH() => m_FCNH ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FCNH
    {
        get => m_FCNH ?? string.Empty;
        set
        {
            pFldFCNH = pFldFCNH || !(m_FCNH ?? string.Empty).Equals(value);
            if (pFldFCNH)
                m_FCNH = value.trim().Length > 100 ? value.trim().substring(0, 100) : value.trim(); // ABC_FIND_CODE123
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
    public bool HasPersonSex() => true;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public int GetID() => ID;
}