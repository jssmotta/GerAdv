namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBAnexamentoRegistros
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFCliente, pFldFGUIDReg, pFldFCodigoReg, pFldFIDReg, pFldFData;
    [XmlIgnore]
    private protected int m_FCliente, m_FCodigoReg, m_FIDReg;
    [XmlIgnore]
    private protected string? m_FGUIDReg;
    [XmlIgnore]
    private protected DateTime? m_FData;
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

    public string NFGUIDReg() => m_FGUIDReg ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FGUIDReg
    {
        get => m_FGUIDReg ?? string.Empty;
        set
        {
            pFldFGUIDReg = pFldFGUIDReg || !(m_FGUIDReg ?? string.Empty).Equals(value);
            if (pFldFGUIDReg)
                m_FGUIDReg = value.trim().Length > 100 ? value.trim().substring(0, 100) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public int NFCodigoReg() => m_FCodigoReg;
    [XmlAttribute]
    public int FCodigoReg
    {
        get => m_FCodigoReg;
        set
        {
            pFldFCodigoReg = pFldFCodigoReg || value != m_FCodigoReg;
            if (pFldFCodigoReg)
                m_FCodigoReg = value;
        }
    }

    public int NFIDReg() => m_FIDReg;
    [XmlAttribute]
    public int FIDReg
    {
        get => m_FIDReg;
        set
        {
            pFldFIDReg = pFldFIDReg || value != m_FIDReg;
            if (pFldFIDReg)
                m_FIDReg = value;
        }
    }

    public string NFData() => $"{m_FData:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FData:dd/MM/yyyy}";
    [XmlIgnore]
    public DateTime MData => Convert.ToDateTime(m_FData);

    [XmlAttribute]
    public string? FData
    {
        get => $"{m_FData:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FData:dd/MM/yyyy}";
        set
        {
            var(setUpNow, changed, data) = DevourerOne.DateUp7(pFldFData, m_FData, value);
            if (!setUpNow)
                return;
            pFldFData = changed;
            m_FData = data;
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