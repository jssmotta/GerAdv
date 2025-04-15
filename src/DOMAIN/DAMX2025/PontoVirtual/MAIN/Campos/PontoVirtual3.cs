namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBPontoVirtual
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFHoraEntrada, pFldFHoraSaida, pFldFOperador, pFldFKey;
    [XmlIgnore]
    private protected int m_FOperador;
    [XmlIgnore]
    private protected string? m_FKey;
    [XmlIgnore]
    private protected DateTime? m_FHoraEntrada, m_FHoraSaida;
    public string NFHoraEntrada() => $"{m_FHoraEntrada:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FHoraEntrada:HH:mm}";
    [XmlIgnore]
    public DateTime MHoraEntrada => Convert.ToDateTime(m_FHoraEntrada);

    [XmlAttribute]
    public string? FHoraEntrada
    {
        // fdDate2 TRACE CODE
        get => $"{m_FHoraEntrada:HH:mm}";
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                pFldFHoraEntrada = pFldFHoraEntrada || m_FHoraEntrada != null;
                m_FHoraEntrada = null;
                return;
            }

            if (value.IsEquals(DevourerOne.PNow))
            {
                pFldFHoraEntrada = true;
                m_FHoraEntrada = DevourerOne.DateTimeUtc;
            }
            else
            {
                if (value.IsEquals($"{m_FHoraEntrada:HH:mm}"))
                    return;
                if (!DateTime.TryParse(value, out var dateTime))
                    return;
                pFldFHoraEntrada = true;
                m_FHoraEntrada = dateTime;
            }
        }
    }

    public string NFHoraSaida() => $"{m_FHoraSaida:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FHoraSaida:HH:mm}";
    [XmlIgnore]
    public DateTime MHoraSaida => Convert.ToDateTime(m_FHoraSaida);

    [XmlAttribute]
    public string? FHoraSaida
    {
        // fdDate2 TRACE CODE
        get => $"{m_FHoraSaida:HH:mm}";
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                pFldFHoraSaida = pFldFHoraSaida || m_FHoraSaida != null;
                m_FHoraSaida = null;
                return;
            }

            if (value.IsEquals(DevourerOne.PNow))
            {
                pFldFHoraSaida = true;
                m_FHoraSaida = DevourerOne.DateTimeUtc;
            }
            else
            {
                if (value.IsEquals($"{m_FHoraSaida:HH:mm}"))
                    return;
                if (!DateTime.TryParse(value, out var dateTime))
                    return;
                pFldFHoraSaida = true;
                m_FHoraSaida = dateTime;
            }
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

    public string NFKey() => m_FKey ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FKey
    {
        get => m_FKey ?? string.Empty;
        set
        {
            pFldFKey = pFldFKey || !(m_FKey ?? string.Empty).Equals(value);
            if (pFldFKey)
                m_FKey = value.trim().Length > 23 ? value.trim().substring(0, 23) : value.trim(); // ABC_FIND_CODE123
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