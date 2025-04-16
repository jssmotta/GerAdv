namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBGUTMatriz
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFDescricao, pFldFGUTTipo, pFldFValor;
    [XmlIgnore]
    private protected int m_FGUTTipo, m_FValor;
    [XmlIgnore]
    private protected string? m_FDescricao;
    public string NFDescricao() => m_FDescricao ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FDescricao
    {
        get => m_FDescricao ?? string.Empty;
        set
        {
            pFldFDescricao = pFldFDescricao || !(m_FDescricao ?? string.Empty).Equals(value);
            if (pFldFDescricao)
                m_FDescricao = value.trim().Length > 150 ? value.trim().substring(0, 150) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public int NFGUTTipo() => m_FGUTTipo;
    [XmlAttribute]
    public int FGUTTipo
    {
        get => m_FGUTTipo;
        set
        {
            pFldFGUTTipo = pFldFGUTTipo || value != m_FGUTTipo;
            if (pFldFGUTTipo)
                m_FGUTTipo = value;
        }
    }

    public int NFValor() => m_FValor;
    [XmlAttribute]
    public int FValor
    {
        get => m_FValor;
        set
        {
            pFldFValor = pFldFValor || value != m_FValor;
            if (pFldFValor)
                m_FValor = value;
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