namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBAgendaRecords
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFAgenda, pFldFJulgador, pFldFClientesSocios, pFldFPerito, pFldFColaborador, pFldFForo, pFldFAviso1, pFldFAviso2, pFldFAviso3, pFldFCrmAviso1, pFldFCrmAviso2, pFldFCrmAviso3, pFldFDataAviso1, pFldFDataAviso2, pFldFDataAviso3;
    [XmlIgnore]
    private protected int m_FAgenda, m_FJulgador, m_FClientesSocios, m_FPerito, m_FColaborador, m_FForo, m_FCrmAviso1, m_FCrmAviso2, m_FCrmAviso3;
    [XmlIgnore]
    private protected DateTime? m_FDataAviso1, m_FDataAviso2, m_FDataAviso3;
    [XmlIgnore]
    private protected bool m_FAviso1, m_FAviso2, m_FAviso3;
    [XmlAttribute]
    public int FAgenda
    {
        get => m_FAgenda;
        set
        {
            pFldFAgenda = pFldFAgenda || value != m_FAgenda;
            if (pFldFAgenda)
                m_FAgenda = value;
        }
    }

    [XmlAttribute]
    public int FJulgador
    {
        get => m_FJulgador;
        set
        {
            pFldFJulgador = pFldFJulgador || value != m_FJulgador;
            if (pFldFJulgador)
                m_FJulgador = value;
        }
    }

    [XmlAttribute]
    public int FClientesSocios
    {
        get => m_FClientesSocios;
        set
        {
            pFldFClientesSocios = pFldFClientesSocios || value != m_FClientesSocios;
            if (pFldFClientesSocios)
                m_FClientesSocios = value;
        }
    }

    [XmlAttribute]
    public int FPerito
    {
        get => m_FPerito;
        set
        {
            pFldFPerito = pFldFPerito || value != m_FPerito;
            if (pFldFPerito)
                m_FPerito = value;
        }
    }

    [XmlAttribute]
    public int FColaborador
    {
        get => m_FColaborador;
        set
        {
            pFldFColaborador = pFldFColaborador || value != m_FColaborador;
            if (pFldFColaborador)
                m_FColaborador = value;
        }
    }

    [XmlAttribute]
    public int FForo
    {
        get => m_FForo;
        set
        {
            pFldFForo = pFldFForo || value != m_FForo;
            if (pFldFForo)
                m_FForo = value;
        }
    }

    [XmlAttribute]
    public bool FAviso1
    {
        get => m_FAviso1;
        set
        {
            pFldFAviso1 = pFldFAviso1 || value != m_FAviso1;
            if (pFldFAviso1)
                m_FAviso1 = value;
        }
    }

    [XmlAttribute]
    public bool FAviso2
    {
        get => m_FAviso2;
        set
        {
            pFldFAviso2 = pFldFAviso2 || value != m_FAviso2;
            if (pFldFAviso2)
                m_FAviso2 = value;
        }
    }

    [XmlAttribute]
    public bool FAviso3
    {
        get => m_FAviso3;
        set
        {
            pFldFAviso3 = pFldFAviso3 || value != m_FAviso3;
            if (pFldFAviso3)
                m_FAviso3 = value;
        }
    }

    [XmlAttribute]
    public int FCrmAviso1
    {
        get => m_FCrmAviso1;
        set
        {
            pFldFCrmAviso1 = pFldFCrmAviso1 || value != m_FCrmAviso1;
            if (pFldFCrmAviso1)
                m_FCrmAviso1 = value;
        }
    }

    [XmlAttribute]
    public int FCrmAviso2
    {
        get => m_FCrmAviso2;
        set
        {
            pFldFCrmAviso2 = pFldFCrmAviso2 || value != m_FCrmAviso2;
            if (pFldFCrmAviso2)
                m_FCrmAviso2 = value;
        }
    }

    [XmlAttribute]
    public int FCrmAviso3
    {
        get => m_FCrmAviso3;
        set
        {
            pFldFCrmAviso3 = pFldFCrmAviso3 || value != m_FCrmAviso3;
            if (pFldFCrmAviso3)
                m_FCrmAviso3 = value;
        }
    }

    [XmlIgnore]
    public DateTime MDataAviso1 => Convert.ToDateTime(m_FDataAviso1);

    [XmlAttribute]
    public string? FDataAviso1
    {
        get => $"{m_FDataAviso1:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FDataAviso1:dd/MM/yyyy}";
        set
        {
            var(setUpNow, changed, data) = DevourerOne.DateUp7(pFldFDataAviso1, m_FDataAviso1, value);
            if (!setUpNow)
                return;
            pFldFDataAviso1 = changed;
            m_FDataAviso1 = data;
        }
    }

    [XmlIgnore]
    public DateTime MDataAviso2 => Convert.ToDateTime(m_FDataAviso2);

    [XmlAttribute]
    public string? FDataAviso2
    {
        get => $"{m_FDataAviso2:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FDataAviso2:dd/MM/yyyy}";
        set
        {
            var(setUpNow, changed, data) = DevourerOne.DateUp7(pFldFDataAviso2, m_FDataAviso2, value);
            if (!setUpNow)
                return;
            pFldFDataAviso2 = changed;
            m_FDataAviso2 = data;
        }
    }

    [XmlIgnore]
    public DateTime MDataAviso3 => Convert.ToDateTime(m_FDataAviso3);

    [XmlAttribute]
    public string? FDataAviso3
    {
        get => $"{m_FDataAviso3:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FDataAviso3:dd/MM/yyyy}";
        set
        {
            var(setUpNow, changed, data) = DevourerOne.DateUp7(pFldFDataAviso3, m_FDataAviso3, value);
            if (!setUpNow)
                return;
            pFldFDataAviso3 = changed;
            m_FDataAviso3 = data;
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