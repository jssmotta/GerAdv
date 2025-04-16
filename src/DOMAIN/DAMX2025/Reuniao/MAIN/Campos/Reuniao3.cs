namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBReuniao
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFCliente, pFldFIDAgenda, pFldFData, pFldFPauta, pFldFATA, pFldFHoraInicial, pFldFHoraFinal, pFldFExterna, pFldFHoraSaida, pFldFHoraRetorno, pFldFPrincipaisDecisoes, pFldFBold;
    [XmlIgnore]
    private protected int m_FCliente, m_FIDAgenda;
    [XmlIgnore]
    private protected string? m_FPauta, m_FATA, m_FPrincipaisDecisoes;
    [XmlIgnore]
    private protected DateTime? m_FData, m_FHoraInicial, m_FHoraFinal, m_FHoraSaida, m_FHoraRetorno;
    [XmlIgnore]
    private protected bool m_FExterna, m_FBold;
    public int NFCliente() => m_FCliente;
    [XmlAttribute]
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

    public int NFIDAgenda() => m_FIDAgenda;
    [XmlAttribute]
    public int FIDAgenda
    {
        get => m_FIDAgenda;
        set
        {
            pFldFIDAgenda = pFldFIDAgenda || value != m_FIDAgenda;
            if (pFldFIDAgenda)
                m_FIDAgenda = value;
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

    public string NFPauta() => m_FPauta ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FPauta
    {
        get => m_FPauta ?? string.Empty;
        set
        {
            pFldFPauta = pFldFPauta || !(m_FPauta ?? string.Empty).Equals(value);
            if (pFldFPauta)
                m_FPauta = value.trim().FixAbc() ?? string.Empty;
        }
    }

    public string NFATA() => m_FATA ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FATA
    {
        get => m_FATA ?? string.Empty;
        set
        {
            pFldFATA = pFldFATA || !(m_FATA ?? string.Empty).Equals(value);
            if (pFldFATA)
                m_FATA = value.trim().FixAbc() ?? string.Empty;
        }
    }

    public string NFHoraInicial() => $"{m_FHoraInicial:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FHoraInicial:HH:mm}";
    [XmlIgnore]
    public DateTime MHoraInicial => Convert.ToDateTime(m_FHoraInicial);

    [XmlAttribute]
    public string? FHoraInicial
    {
        // fdDate2 TRACE CODE
        get => $"{m_FHoraInicial:HH:mm}";
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                pFldFHoraInicial = pFldFHoraInicial || m_FHoraInicial != null;
                m_FHoraInicial = null;
                return;
            }

            if (value.IsEquals(DevourerOne.PNow))
            {
                pFldFHoraInicial = true;
                m_FHoraInicial = DevourerOne.DateTimeUtc;
            }
            else
            {
                if (value.IsEquals($"{m_FHoraInicial:HH:mm}"))
                    return;
                if (!DateTime.TryParse(value, out var dateTime))
                    return;
                pFldFHoraInicial = true;
                m_FHoraInicial = dateTime;
            }
        }
    }

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

    public bool NFExterna() => m_FExterna;
    [XmlAttribute]
    public bool FExterna
    {
        get => m_FExterna;
        set
        {
            pFldFExterna = pFldFExterna || value != m_FExterna;
            if (pFldFExterna)
                m_FExterna = value;
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

    public string NFHoraRetorno() => $"{m_FHoraRetorno:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FHoraRetorno:HH:mm}";
    [XmlIgnore]
    public DateTime MHoraRetorno => Convert.ToDateTime(m_FHoraRetorno);

    [XmlAttribute]
    public string? FHoraRetorno
    {
        // fdDate2 TRACE CODE
        get => $"{m_FHoraRetorno:HH:mm}";
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                pFldFHoraRetorno = pFldFHoraRetorno || m_FHoraRetorno != null;
                m_FHoraRetorno = null;
                return;
            }

            if (value.IsEquals(DevourerOne.PNow))
            {
                pFldFHoraRetorno = true;
                m_FHoraRetorno = DevourerOne.DateTimeUtc;
            }
            else
            {
                if (value.IsEquals($"{m_FHoraRetorno:HH:mm}"))
                    return;
                if (!DateTime.TryParse(value, out var dateTime))
                    return;
                pFldFHoraRetorno = true;
                m_FHoraRetorno = dateTime;
            }
        }
    }

    public string NFPrincipaisDecisoes() => m_FPrincipaisDecisoes ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FPrincipaisDecisoes
    {
        get => m_FPrincipaisDecisoes ?? string.Empty;
        set
        {
            pFldFPrincipaisDecisoes = pFldFPrincipaisDecisoes || !(m_FPrincipaisDecisoes ?? string.Empty).Equals(value);
            if (pFldFPrincipaisDecisoes)
                m_FPrincipaisDecisoes = value.trim().FixAbc() ?? string.Empty;
        }
    }

    public bool NFBold() => m_FBold;
    [XmlAttribute]
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
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public int GetID() => ID;
}