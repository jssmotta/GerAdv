namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBAlertas
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFNome, pFldFData, pFldFOperador, pFldFDataAte;
    [XmlIgnore]
    private protected int m_FOperador;
    [XmlIgnore]
    private protected string? m_FNome;
    [XmlIgnore]
    private protected DateTime? m_FData, m_FDataAte;
    public string NFNome() => m_FNome ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FNome
    {
        get => m_FNome ?? string.Empty;
        set
        {
            pFldFNome = pFldFNome || !(m_FNome ?? string.Empty).Equals(value);
            if (pFldFNome)
                m_FNome = value.trim().Length > 2048 ? value.trim().substring(0, 2048) : value.trim(); // ABC_FIND_CODE123
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

    public int NFOperador() => m_FOperador;
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

    public string NFDataAte() => $"{m_FDataAte:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FDataAte:dd/MM/yyyy}";
    [XmlIgnore]
    public DateTime MDataAte => Convert.ToDateTime(m_FDataAte);

    [XmlAttribute]
    public string? FDataAte
    {
        get => $"{m_FDataAte:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FDataAte:dd/MM/yyyy}";
        set
        {
            var(setUpNow, changed, data) = DevourerOne.DateUp7(pFldFDataAte, m_FDataAte, value);
            if (!setUpNow)
                return;
            pFldFDataAte = changed;
            m_FDataAte = data;
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
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public int GetID() => ID;
}