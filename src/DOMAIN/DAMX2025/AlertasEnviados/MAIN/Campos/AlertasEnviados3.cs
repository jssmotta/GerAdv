namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBAlertasEnviados
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFOperador, pFldFAlerta, pFldFDataAlertado, pFldFVisualizado;
    [XmlIgnore]
    private protected int m_FOperador, m_FAlerta;
    [XmlIgnore]
    private protected DateTime? m_FDataAlertado;
    [XmlIgnore]
    private protected bool m_FVisualizado;
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
    public int FAlerta
    {
        get => m_FAlerta;
        set
        {
            pFldFAlerta = pFldFAlerta || value != m_FAlerta;
            if (pFldFAlerta)
                m_FAlerta = value;
        }
    }

    [XmlIgnore]
    public DateTime MDataAlertado => Convert.ToDateTime(m_FDataAlertado);

    [XmlAttribute]
    public string? FDataAlertado
    {
        get => $"{m_FDataAlertado:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FDataAlertado:dd/MM/yyyy}";
        set
        {
            var(setUpNow, changed, data) = DevourerOne.DateUp7(pFldFDataAlertado, m_FDataAlertado, value);
            if (!setUpNow)
                return;
            pFldFDataAlertado = changed;
            m_FDataAlertado = data;
        }
    }

    [XmlAttribute]
    public bool FVisualizado
    {
        get => m_FVisualizado;
        set
        {
            pFldFVisualizado = pFldFVisualizado || value != m_FVisualizado;
            if (pFldFVisualizado)
                m_FVisualizado = value;
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