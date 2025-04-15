namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBPontoVirtualAcessos
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFOperador, pFldFDataHora, pFldFTipo, pFldFOrigem;
    [XmlIgnore]
    private protected int m_FOperador;
    [XmlIgnore]
    private protected string? m_FOrigem;
    [XmlIgnore]
    private protected DateTime? m_FDataHora;
    [XmlIgnore]
    private protected bool m_FTipo;
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

    public string NFDataHora() => $"{m_FDataHora:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FDataHora:dd/MM/yyyy}";
    [XmlIgnore]
    public DateTime MDataHora => Convert.ToDateTime(m_FDataHora);

    [XmlAttribute]
    public string? FDataHora
    {
        get => $"{m_FDataHora:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FDataHora:dd/MM/yyyy}";
        set
        {
            var(setUpNow, changed, data) = DevourerOne.DateUp7(pFldFDataHora, m_FDataHora, value);
            if (!setUpNow)
                return;
            pFldFDataHora = changed;
            m_FDataHora = data;
        }
    }

    public bool NFTipo() => m_FTipo;
    [XmlAttribute]
    public bool FTipo
    {
        get => m_FTipo;
        set
        {
            pFldFTipo = pFldFTipo || value != m_FTipo;
            if (pFldFTipo)
                m_FTipo = value;
        }
    }

    public string NFOrigem() => m_FOrigem ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FOrigem
    {
        get => m_FOrigem ?? string.Empty;
        set
        {
            pFldFOrigem = pFldFOrigem || !(m_FOrigem ?? string.Empty).Equals(value);
            if (pFldFOrigem)
                m_FOrigem = value.trim().Length > 150 ? value.trim().substring(0, 150) : value.trim(); // ABC_FIND_CODE123
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