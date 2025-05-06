namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBContratos
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFProcesso, pFldFCliente, pFldFAdvogado, pFldFDia, pFldFValor, pFldFDataInicio, pFldFDataTermino, pFldFOcultarRelatorio, pFldFPercEscritorio, pFldFValorConsultoria, pFldFTipoCobranca, pFldFProtestar, pFldFJuros, pFldFValorRealizavel, pFldFDOCUMENTO, pFldFEMail1, pFldFEMail2, pFldFEMail3, pFldFPessoa1, pFldFPessoa2, pFldFPessoa3, pFldFOBS, pFldFClienteContrato, pFldFIdExtrangeiro, pFldFChaveContrato, pFldFAvulso, pFldFSuspenso, pFldFMulta, pFldFBold;
    [XmlIgnore]
    private protected int m_FProcesso, m_FCliente, m_FAdvogado, m_FDia, m_FTipoCobranca, m_FClienteContrato, m_FIdExtrangeiro;
    [XmlIgnore]
    private protected string? m_FProtestar, m_FJuros, m_FDOCUMENTO, m_FEMail1, m_FEMail2, m_FEMail3, m_FPessoa1, m_FPessoa2, m_FPessoa3, m_FOBS, m_FChaveContrato, m_FMulta;
    [XmlIgnore]
    private protected DateTime? m_FDataInicio, m_FDataTermino;
    [XmlIgnore]
    private protected bool m_FOcultarRelatorio, m_FAvulso, m_FSuspenso, m_FBold;
    [XmlIgnore]
    private protected decimal m_FValor, m_FPercEscritorio, m_FValorConsultoria, m_FValorRealizavel;
    [XmlAttribute]
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

    [XmlAttribute]
    public int FAdvogado
    {
        get => m_FAdvogado;
        set
        {
            pFldFAdvogado = pFldFAdvogado || value != m_FAdvogado;
            if (pFldFAdvogado)
                m_FAdvogado = value;
        }
    }

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

    [XmlAttribute]
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

    [XmlIgnore]
    public DateTime MDataInicio => Convert.ToDateTime(m_FDataInicio);

    [XmlAttribute]
    public string? FDataInicio
    {
        get => $"{m_FDataInicio:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FDataInicio:dd/MM/yyyy}";
        set
        {
            var(setUpNow, changed, data) = DevourerOne.DateUp7(pFldFDataInicio, m_FDataInicio, value);
            if (!setUpNow)
                return;
            pFldFDataInicio = changed;
            m_FDataInicio = data;
        }
    }

    [XmlIgnore]
    public DateTime MDataTermino => Convert.ToDateTime(m_FDataTermino);

    [XmlAttribute]
    public string? FDataTermino
    {
        get => $"{m_FDataTermino:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FDataTermino:dd/MM/yyyy}";
        set
        {
            var(setUpNow, changed, data) = DevourerOne.DateUp7(pFldFDataTermino, m_FDataTermino, value);
            if (!setUpNow)
                return;
            pFldFDataTermino = changed;
            m_FDataTermino = data;
        }
    }

    [XmlAttribute]
    public bool FOcultarRelatorio
    {
        get => m_FOcultarRelatorio;
        set
        {
            pFldFOcultarRelatorio = pFldFOcultarRelatorio || value != m_FOcultarRelatorio;
            if (pFldFOcultarRelatorio)
                m_FOcultarRelatorio = value;
        }
    }

    [XmlAttribute]
    public decimal FPercEscritorio
    {
        get => m_FPercEscritorio;
        set
        {
            if (value == m_FPercEscritorio)
                return;
            pFldFPercEscritorio = true;
            m_FPercEscritorio = value;
        }
    }

    [XmlAttribute]
    public decimal FValorConsultoria
    {
        get => m_FValorConsultoria;
        set
        {
            if (value == m_FValorConsultoria)
                return;
            pFldFValorConsultoria = true;
            m_FValorConsultoria = value;
        }
    }

    [XmlAttribute]
    public int FTipoCobranca
    {
        get => m_FTipoCobranca;
        set
        {
            pFldFTipoCobranca = pFldFTipoCobranca || value != m_FTipoCobranca;
            if (pFldFTipoCobranca)
                m_FTipoCobranca = value;
        }
    }

    [XmlAttribute]
    public string? FProtestar
    {
        get => m_FProtestar ?? string.Empty;
        set
        {
            pFldFProtestar = pFldFProtestar || !(m_FProtestar ?? string.Empty).Equals(value);
            if (pFldFProtestar)
                m_FProtestar = value.trim().Length > 50 ? value.trim().substring(0, 50) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlAttribute]
    public string? FJuros
    {
        get => m_FJuros ?? string.Empty;
        set
        {
            pFldFJuros = pFldFJuros || !(m_FJuros ?? string.Empty).Equals(value);
            if (pFldFJuros)
                m_FJuros = value.trim().Length > 5 ? value.trim().substring(0, 5) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlAttribute]
    public decimal FValorRealizavel
    {
        get => m_FValorRealizavel;
        set
        {
            if (value == m_FValorRealizavel)
                return;
            pFldFValorRealizavel = true;
            m_FValorRealizavel = value;
        }
    }

    [XmlAttribute]
    public string? FDOCUMENTO
    {
        get => m_FDOCUMENTO ?? string.Empty;
        set
        {
            pFldFDOCUMENTO = pFldFDOCUMENTO || !(m_FDOCUMENTO ?? string.Empty).Equals(value);
            if (pFldFDOCUMENTO)
                m_FDOCUMENTO = value.trim().Length > 15 ? value.trim().substring(0, 15) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlAttribute]
    public string? FEMail1
    {
        get => m_FEMail1 ?? string.Empty;
        set
        {
            pFldFEMail1 = pFldFEMail1 || !(m_FEMail1 ?? string.Empty).Equals(value);
            if (pFldFEMail1)
                m_FEMail1 = value.trim().Length > 300 ? value.trim().substring(0, 300) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlAttribute]
    public string? FEMail2
    {
        get => m_FEMail2 ?? string.Empty;
        set
        {
            pFldFEMail2 = pFldFEMail2 || !(m_FEMail2 ?? string.Empty).Equals(value);
            if (pFldFEMail2)
                m_FEMail2 = value.trim().Length > 300 ? value.trim().substring(0, 300) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlAttribute]
    public string? FEMail3
    {
        get => m_FEMail3 ?? string.Empty;
        set
        {
            pFldFEMail3 = pFldFEMail3 || !(m_FEMail3 ?? string.Empty).Equals(value);
            if (pFldFEMail3)
                m_FEMail3 = value.trim().Length > 300 ? value.trim().substring(0, 300) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlAttribute]
    public string? FPessoa1
    {
        get => m_FPessoa1 ?? string.Empty;
        set
        {
            pFldFPessoa1 = pFldFPessoa1 || !(m_FPessoa1 ?? string.Empty).Equals(value);
            if (pFldFPessoa1)
                m_FPessoa1 = value.trim().Length > 100 ? value.trim().substring(0, 100) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlAttribute]
    public string? FPessoa2
    {
        get => m_FPessoa2 ?? string.Empty;
        set
        {
            pFldFPessoa2 = pFldFPessoa2 || !(m_FPessoa2 ?? string.Empty).Equals(value);
            if (pFldFPessoa2)
                m_FPessoa2 = value.trim().Length > 100 ? value.trim().substring(0, 100) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlAttribute]
    public string? FPessoa3
    {
        get => m_FPessoa3 ?? string.Empty;
        set
        {
            pFldFPessoa3 = pFldFPessoa3 || !(m_FPessoa3 ?? string.Empty).Equals(value);
            if (pFldFPessoa3)
                m_FPessoa3 = value.trim().Length > 100 ? value.trim().substring(0, 100) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlAttribute]
    public string? FOBS
    {
        get => m_FOBS ?? string.Empty;
        set
        {
            pFldFOBS = pFldFOBS || !(m_FOBS ?? string.Empty).Equals(value);
            if (pFldFOBS)
                m_FOBS = value.trim().FixAbc() ?? string.Empty;
        }
    }

    [XmlAttribute]
    public int FClienteContrato
    {
        get => m_FClienteContrato;
        set
        {
            pFldFClienteContrato = pFldFClienteContrato || value != m_FClienteContrato;
            if (pFldFClienteContrato)
                m_FClienteContrato = value;
        }
    }

    [XmlAttribute]
    public int FIdExtrangeiro
    {
        get => m_FIdExtrangeiro;
        set
        {
            pFldFIdExtrangeiro = pFldFIdExtrangeiro || value != m_FIdExtrangeiro;
            if (pFldFIdExtrangeiro)
                m_FIdExtrangeiro = value;
        }
    }

    [XmlAttribute]
    public string? FChaveContrato
    {
        get => m_FChaveContrato ?? string.Empty;
        set
        {
            pFldFChaveContrato = pFldFChaveContrato || !(m_FChaveContrato ?? string.Empty).Equals(value);
            if (pFldFChaveContrato)
                m_FChaveContrato = value.trim().Length > 50 ? value.trim().substring(0, 50) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlAttribute]
    public bool FAvulso
    {
        get => m_FAvulso;
        set
        {
            pFldFAvulso = pFldFAvulso || value != m_FAvulso;
            if (pFldFAvulso)
                m_FAvulso = value;
        }
    }

    [XmlAttribute]
    public bool FSuspenso
    {
        get => m_FSuspenso;
        set
        {
            pFldFSuspenso = pFldFSuspenso || value != m_FSuspenso;
            if (pFldFSuspenso)
                m_FSuspenso = value;
        }
    }

    [XmlAttribute]
    public string? FMulta
    {
        get => m_FMulta ?? string.Empty;
        set
        {
            pFldFMulta = pFldFMulta || !(m_FMulta ?? string.Empty).Equals(value);
            if (pFldFMulta)
                m_FMulta = value.trim().Length > 10 ? value.trim().substring(0, 10) : value.trim(); // ABC_FIND_CODE123
        }
    }

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