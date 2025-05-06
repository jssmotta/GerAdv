namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBContaCorrente
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFCIAcordo, pFldFQuitado, pFldFIDContrato, pFldFQuitadoID, pFldFDebitoID, pFldFLivroCaixaID, pFldFSucumbencia, pFldFDistRegra, pFldFDtOriginal, pFldFProcesso, pFldFParcelaX, pFldFValor, pFldFData, pFldFCliente, pFldFHistorico, pFldFContrato, pFldFPago, pFldFDistribuir, pFldFLC, pFldFIDHTrab, pFldFNroParcelas, pFldFValorPrincipal, pFldFParcelaPrincipalID, pFldFHide, pFldFDataPgto;
    [XmlIgnore]
    private protected int m_FCIAcordo, m_FIDContrato, m_FQuitadoID, m_FDebitoID, m_FLivroCaixaID, m_FProcesso, m_FParcelaX, m_FCliente, m_FIDHTrab, m_FNroParcelas, m_FParcelaPrincipalID;
    [XmlIgnore]
    private protected string? m_FHistorico;
    [XmlIgnore]
    private protected DateTime? m_FDtOriginal, m_FData, m_FDataPgto;
    [XmlIgnore]
    private protected bool m_FQuitado, m_FSucumbencia, m_FDistRegra, m_FContrato, m_FPago, m_FDistribuir, m_FLC, m_FHide;
    [XmlIgnore]
    private protected decimal m_FValor, m_FValorPrincipal;
    [XmlAttribute]
    public int FCIAcordo
    {
        get => m_FCIAcordo;
        set
        {
            pFldFCIAcordo = pFldFCIAcordo || value != m_FCIAcordo;
            if (pFldFCIAcordo)
                m_FCIAcordo = value;
        }
    }

    [XmlAttribute]
    public bool FQuitado
    {
        get => m_FQuitado;
        set
        {
            pFldFQuitado = pFldFQuitado || value != m_FQuitado;
            if (pFldFQuitado)
                m_FQuitado = value;
        }
    }

    [XmlAttribute]
    public int FIDContrato
    {
        get => m_FIDContrato;
        set
        {
            pFldFIDContrato = pFldFIDContrato || value != m_FIDContrato;
            if (pFldFIDContrato)
                m_FIDContrato = value;
        }
    }

    [XmlAttribute]
    public int FQuitadoID
    {
        get => m_FQuitadoID;
        set
        {
            pFldFQuitadoID = pFldFQuitadoID || value != m_FQuitadoID;
            if (pFldFQuitadoID)
                m_FQuitadoID = value;
        }
    }

    [XmlAttribute]
    public int FDebitoID
    {
        get => m_FDebitoID;
        set
        {
            pFldFDebitoID = pFldFDebitoID || value != m_FDebitoID;
            if (pFldFDebitoID)
                m_FDebitoID = value;
        }
    }

    [XmlAttribute]
    public int FLivroCaixaID
    {
        get => m_FLivroCaixaID;
        set
        {
            pFldFLivroCaixaID = pFldFLivroCaixaID || value != m_FLivroCaixaID;
            if (pFldFLivroCaixaID)
                m_FLivroCaixaID = value;
        }
    }

    [XmlAttribute]
    public bool FSucumbencia
    {
        get => m_FSucumbencia;
        set
        {
            pFldFSucumbencia = pFldFSucumbencia || value != m_FSucumbencia;
            if (pFldFSucumbencia)
                m_FSucumbencia = value;
        }
    }

    [XmlAttribute]
    public bool FDistRegra
    {
        get => m_FDistRegra;
        set
        {
            pFldFDistRegra = pFldFDistRegra || value != m_FDistRegra;
            if (pFldFDistRegra)
                m_FDistRegra = value;
        }
    }

    [XmlIgnore]
    public DateTime MDtOriginal => Convert.ToDateTime(m_FDtOriginal);

    [XmlAttribute]
    public string? FDtOriginal
    {
        get => $"{m_FDtOriginal:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FDtOriginal:dd/MM/yyyy}";
        set
        {
            var(setUpNow, changed, data) = DevourerOne.DateUp7(pFldFDtOriginal, m_FDtOriginal, value);
            if (!setUpNow)
                return;
            pFldFDtOriginal = changed;
            m_FDtOriginal = data;
        }
    }

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
    public int FParcelaX
    {
        get => m_FParcelaX;
        set
        {
            pFldFParcelaX = pFldFParcelaX || value != m_FParcelaX;
            if (pFldFParcelaX)
                m_FParcelaX = value;
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
    public string? FHistorico
    {
        get => m_FHistorico ?? string.Empty;
        set
        {
            pFldFHistorico = pFldFHistorico || !(m_FHistorico ?? string.Empty).Equals(value);
            if (pFldFHistorico)
                m_FHistorico = value.trim().FixAbc() ?? string.Empty;
        }
    }

    [XmlAttribute]
    public bool FContrato
    {
        get => m_FContrato;
        set
        {
            pFldFContrato = pFldFContrato || value != m_FContrato;
            if (pFldFContrato)
                m_FContrato = value;
        }
    }

    [XmlAttribute]
    public bool FPago
    {
        get => m_FPago;
        set
        {
            pFldFPago = pFldFPago || value != m_FPago;
            if (pFldFPago)
                m_FPago = value;
        }
    }

    [XmlAttribute]
    public bool FDistribuir
    {
        get => m_FDistribuir;
        set
        {
            pFldFDistribuir = pFldFDistribuir || value != m_FDistribuir;
            if (pFldFDistribuir)
                m_FDistribuir = value;
        }
    }

    [XmlAttribute]
    public bool FLC
    {
        get => m_FLC;
        set
        {
            pFldFLC = pFldFLC || value != m_FLC;
            if (pFldFLC)
                m_FLC = value;
        }
    }

    [XmlAttribute]
    public int FIDHTrab
    {
        get => m_FIDHTrab;
        set
        {
            pFldFIDHTrab = pFldFIDHTrab || value != m_FIDHTrab;
            if (pFldFIDHTrab)
                m_FIDHTrab = value;
        }
    }

    [XmlAttribute]
    public int FNroParcelas
    {
        get => m_FNroParcelas;
        set
        {
            pFldFNroParcelas = pFldFNroParcelas || value != m_FNroParcelas;
            if (pFldFNroParcelas)
                m_FNroParcelas = value;
        }
    }

    [XmlAttribute]
    public decimal FValorPrincipal
    {
        get => m_FValorPrincipal;
        set
        {
            if (value == m_FValorPrincipal)
                return;
            pFldFValorPrincipal = true;
            m_FValorPrincipal = value;
        }
    }

    [XmlAttribute]
    public int FParcelaPrincipalID
    {
        get => m_FParcelaPrincipalID;
        set
        {
            pFldFParcelaPrincipalID = pFldFParcelaPrincipalID || value != m_FParcelaPrincipalID;
            if (pFldFParcelaPrincipalID)
                m_FParcelaPrincipalID = value;
        }
    }

    [XmlAttribute]
    public bool FHide
    {
        get => m_FHide;
        set
        {
            pFldFHide = pFldFHide || value != m_FHide;
            if (pFldFHide)
                m_FHide = value;
        }
    }

    [XmlIgnore]
    public DateTime MDataPgto => Convert.ToDateTime(m_FDataPgto);

    [XmlAttribute]
    public string? FDataPgto
    {
        get => $"{m_FDataPgto:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FDataPgto:dd/MM/yyyy}";
        set
        {
            var(setUpNow, changed, data) = DevourerOne.DateUp7(pFldFDataPgto, m_FDataPgto, value);
            if (!setUpNow)
                return;
            pFldFDataPgto = changed;
            m_FDataPgto = data;
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