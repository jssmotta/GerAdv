namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBHonorariosDadosContrato
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFCliente, pFldFFixo, pFldFVariavel, pFldFPercSucesso, pFldFProcesso, pFldFArquivoContrato, pFldFTextoContrato, pFldFValorFixo, pFldFObservacao, pFldFDataContrato;
    [XmlIgnore]
    private protected int m_FCliente, m_FProcesso;
    [XmlIgnore]
    private protected string? m_FArquivoContrato, m_FTextoContrato, m_FObservacao;
    [XmlIgnore]
    private protected DateTime? m_FDataContrato;
    [XmlIgnore]
    private protected bool m_FFixo, m_FVariavel;
    [XmlIgnore]
    private protected decimal m_FPercSucesso, m_FValorFixo;
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

    public bool FFixo
    {
        get => m_FFixo;
        set
        {
            pFldFFixo = pFldFFixo || value != m_FFixo;
            if (pFldFFixo)
                m_FFixo = value;
        }
    }

    public bool FVariavel
    {
        get => m_FVariavel;
        set
        {
            pFldFVariavel = pFldFVariavel || value != m_FVariavel;
            if (pFldFVariavel)
                m_FVariavel = value;
        }
    }

    public decimal FPercSucesso
    {
        get => m_FPercSucesso;
        set
        {
            if (value == m_FPercSucesso)
                return;
            pFldFPercSucesso = true;
            m_FPercSucesso = value;
        }
    }

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

    public string? FArquivoContrato
    {
        get => m_FArquivoContrato ?? string.Empty;
        set
        {
            pFldFArquivoContrato = pFldFArquivoContrato || !(m_FArquivoContrato ?? string.Empty).Equals(value);
            if (pFldFArquivoContrato)
                m_FArquivoContrato = value.trim().Length > 2048 ? value.trim().substring(0, 2048) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public string? FTextoContrato
    {
        get => m_FTextoContrato ?? string.Empty;
        set
        {
            pFldFTextoContrato = pFldFTextoContrato || !(m_FTextoContrato ?? string.Empty).Equals(value);
            if (pFldFTextoContrato)
                m_FTextoContrato = value.trim().FixAbc() ?? string.Empty;
        }
    }

    public decimal FValorFixo
    {
        get => m_FValorFixo;
        set
        {
            if (value == m_FValorFixo)
                return;
            pFldFValorFixo = true;
            m_FValorFixo = value;
        }
    }

    public string? FObservacao
    {
        get => m_FObservacao ?? string.Empty;
        set
        {
            pFldFObservacao = pFldFObservacao || !(m_FObservacao ?? string.Empty).Equals(value);
            if (pFldFObservacao)
                m_FObservacao = value.trim().Length > 2048 ? value.trim().substring(0, 2048) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlIgnore]
    public DateTime MDataContrato => Convert.ToDateTime(m_FDataContrato);

    public string? FDataContrato
    {
        get => $"{m_FDataContrato:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FDataContrato:dd/MM/yyyy}";
        set
        {
            var(setUpNow, changed, data) = DevourerOne.DateUp7(pFldFDataContrato, m_FDataContrato, value);
            if (!setUpNow)
                return;
            pFldFDataContrato = changed;
            m_FDataContrato = data;
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