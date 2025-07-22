namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBProDepositos
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFProcesso, pFldFFase, pFldFData, pFldFValor, pFldFTipoProDesposito;
    [XmlIgnore]
    private protected int m_FProcesso, m_FFase, m_FTipoProDesposito;
    [XmlIgnore]
    private protected DateTime? m_FData;
    [XmlIgnore]
    private protected decimal m_FValor;
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

    public int FFase
    {
        get => m_FFase;
        set
        {
            pFldFFase = pFldFFase || value != m_FFase;
            if (pFldFFase)
                m_FFase = value;
        }
    }

    [XmlIgnore]
    public DateTime MData => Convert.ToDateTime(m_FData);

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

    public int FTipoProDesposito
    {
        get => m_FTipoProDesposito;
        set
        {
            pFldFTipoProDesposito = pFldFTipoProDesposito || value != m_FTipoProDesposito;
            if (pFldFTipoProDesposito)
                m_FTipoProDesposito = value;
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