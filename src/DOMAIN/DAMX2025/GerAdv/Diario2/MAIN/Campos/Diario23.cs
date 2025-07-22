namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBDiario2
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFData, pFldFHora, pFldFOperador, pFldFNome, pFldFOcorrencia, pFldFCliente, pFldFBold;
    [XmlIgnore]
    private protected int m_FOperador, m_FCliente;
    [XmlIgnore]
    private protected string? m_FNome, m_FOcorrencia;
    [XmlIgnore]
    private protected DateTime? m_FData, m_FHora;
    [XmlIgnore]
    private protected bool m_FBold;
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

    [XmlIgnore]
    public DateTime MHora => Convert.ToDateTime(m_FHora);

    public string? FHora
    {
        // fdDate2 TRACE CODE
        get => $"{m_FHora:HH:mm}";
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                pFldFHora = pFldFHora || m_FHora != null;
                m_FHora = null;
                return;
            }

            if (value.IsEquals(DevourerOne.PNow))
            {
                pFldFHora = true;
                m_FHora = DevourerOne.DateTimeUtc;
            }
            else
            {
                if (value.IsEquals($"{m_FHora:HH:mm}"))
                    return;
                if (!DateTime.TryParse(value, out var dateTime))
                    return;
                pFldFHora = true;
                m_FHora = dateTime;
            }
        }
    }

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

    public string? FNome
    {
        get => m_FNome ?? string.Empty;
        set
        {
            pFldFNome = pFldFNome || !(m_FNome ?? string.Empty).Equals(value);
            if (pFldFNome)
                m_FNome = value.trim().Length > 150 ? value.trim().substring(0, 150) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public string? FOcorrencia
    {
        get => m_FOcorrencia ?? string.Empty;
        set
        {
            pFldFOcorrencia = pFldFOcorrencia || !(m_FOcorrencia ?? string.Empty).Equals(value);
            if (pFldFOcorrencia)
                m_FOcorrencia = value.trim().Length > 2048 ? value.trim().substring(0, 2048) : value.trim(); // ABC_FIND_CODE123
        }
    }

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

    public bool FBold
    {
        get => m_FBold;
        set
        {
            pFldFBold = pFldFBold || value != m_FBold;
            if (pFldFBold)
                m_FBold = value;
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