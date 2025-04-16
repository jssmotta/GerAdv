namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBAgendaRepetirDias
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFHoraFinal, pFldFMaster, pFldFDia, pFldFHora;
    [XmlIgnore]
    private protected int m_FMaster, m_FDia;
    [XmlIgnore]
    private protected DateTime? m_FHoraFinal, m_FHora;
    public string NFHoraFinal() => $"{m_FHoraFinal:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FHoraFinal:HH:mm}";
    [XmlIgnore]
    public DateTime MHoraFinal => Convert.ToDateTime(m_FHoraFinal);

    [XmlAttribute]
    public string? FHoraFinal
    {
        // fdDate2 TRACE CODE
        get => $"{m_FHoraFinal:HH:mm}";
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                pFldFHoraFinal = pFldFHoraFinal || m_FHoraFinal != null;
                m_FHoraFinal = null;
                return;
            }

            if (value.IsEquals(DevourerOne.PNow))
            {
                pFldFHoraFinal = true;
                m_FHoraFinal = DevourerOne.DateTimeUtc;
            }
            else
            {
                if (value.IsEquals($"{m_FHoraFinal:HH:mm}"))
                    return;
                if (!DateTime.TryParse(value, out var dateTime))
                    return;
                pFldFHoraFinal = true;
                m_FHoraFinal = dateTime;
            }
        }
    }

    public int NFMaster() => m_FMaster;
    [XmlAttribute]
    public int FMaster
    {
        get => m_FMaster;
        set
        {
            pFldFMaster = pFldFMaster || value != m_FMaster;
            if (pFldFMaster)
                m_FMaster = value;
        }
    }

    public int NFDia() => m_FDia;
    [XmlAttribute]
    public int FDia
    {
        get => m_FDia;
        set
        {
            pFldFDia = pFldFDia || value != m_FDia;
            if (pFldFDia)
                m_FDia = value;
        }
    }

    public string NFHora() => $"{m_FHora:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FHora:HH:mm}";
    [XmlIgnore]
    public DateTime MHora => Convert.ToDateTime(m_FHora);

    [XmlAttribute]
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