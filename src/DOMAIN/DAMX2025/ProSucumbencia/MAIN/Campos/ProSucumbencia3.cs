namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBProSucumbencia
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFProcesso, pFldFInstancia, pFldFData, pFldFNome, pFldFTipoOrigemSucumbencia, pFldFValor, pFldFPercentual;
    [XmlIgnore]
    private protected int m_FProcesso, m_FInstancia, m_FTipoOrigemSucumbencia;
    [XmlIgnore]
    private protected string? m_FNome, m_FPercentual;
    [XmlIgnore]
    private protected DateTime? m_FData;
    [XmlIgnore]
    private protected decimal m_FValor;
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

    public int NFInstancia() => m_FInstancia;
    [XmlAttribute]
    public int FInstancia
    {
        get => m_FInstancia;
        set
        {
            pFldFInstancia = pFldFInstancia || value != m_FInstancia;
            if (pFldFInstancia)
                m_FInstancia = value;
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

    public int NFTipoOrigemSucumbencia() => m_FTipoOrigemSucumbencia;
    [XmlAttribute]
    public int FTipoOrigemSucumbencia
    {
        get => m_FTipoOrigemSucumbencia;
        set
        {
            pFldFTipoOrigemSucumbencia = pFldFTipoOrigemSucumbencia || value != m_FTipoOrigemSucumbencia;
            if (pFldFTipoOrigemSucumbencia)
                m_FTipoOrigemSucumbencia = value;
        }
    }

    public decimal NFValor() => m_FValor;
    [XmlAttribute]
    public decimal FValor
    {
        get => m_FValor;
        set
        {
            if (value == m_FValor)
                return;
            pFldFValor = true;
            m_FValor = value;
        }
    }

    public string NFPercentual() => m_FPercentual ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FPercentual
    {
        get => m_FPercentual ?? string.Empty;
        set
        {
            pFldFPercentual = pFldFPercentual || !(m_FPercentual ?? string.Empty).Equals(value);
            if (pFldFPercentual)
                m_FPercentual = value.trim().Length > 5 ? value.trim().substring(0, 5) : value.trim(); // ABC_FIND_CODE123
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