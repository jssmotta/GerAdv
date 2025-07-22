namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBUltimosProcessos
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFProcesso, pFldFQuando, pFldFQuem;
    [XmlIgnore]
    private protected int m_FProcesso, m_FQuem;
    [XmlIgnore]
    private protected DateTime? m_FQuando;
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

    [XmlIgnore]
    public DateTime MQuando => Convert.ToDateTime(m_FQuando);

    public string? FQuando
    {
        get => $"{m_FQuando:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FQuando:dd/MM/yyyy}";
        set
        {
            var(setUpNow, changed, data) = DevourerOne.DateUp7(pFldFQuando, m_FQuando, value);
            if (!setUpNow)
                return;
            pFldFQuando = changed;
            m_FQuando = data;
        }
    }

    public int FQuem
    {
        get => m_FQuem;
        set
        {
            pFldFQuem = pFldFQuem || value != m_FQuem;
            if (pFldFQuem)
                m_FQuem = value;
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