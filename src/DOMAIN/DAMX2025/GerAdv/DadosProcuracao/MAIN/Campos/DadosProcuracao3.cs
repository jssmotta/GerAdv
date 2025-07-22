namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBDadosProcuracao
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFCliente, pFldFEstadoCivil, pFldFNacionalidade, pFldFProfissao, pFldFCTPS, pFldFPisPasep, pFldFRemuneracao, pFldFObjeto;
    [XmlIgnore]
    private protected int m_FCliente;
    [XmlIgnore]
    private protected string? m_FEstadoCivil, m_FNacionalidade, m_FProfissao, m_FCTPS, m_FPisPasep, m_FRemuneracao, m_FObjeto;
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

    public string? FEstadoCivil
    {
        get => m_FEstadoCivil ?? string.Empty;
        set
        {
            pFldFEstadoCivil = pFldFEstadoCivil || !(m_FEstadoCivil ?? string.Empty).Equals(value);
            if (pFldFEstadoCivil)
                m_FEstadoCivil = value.trim().Length > 100 ? value.trim().substring(0, 100) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public string? FNacionalidade
    {
        get => m_FNacionalidade ?? string.Empty;
        set
        {
            pFldFNacionalidade = pFldFNacionalidade || !(m_FNacionalidade ?? string.Empty).Equals(value);
            if (pFldFNacionalidade)
                m_FNacionalidade = value.trim().Length > 100 ? value.trim().substring(0, 100) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public string? FProfissao
    {
        get => m_FProfissao ?? string.Empty;
        set
        {
            pFldFProfissao = pFldFProfissao || !(m_FProfissao ?? string.Empty).Equals(value);
            if (pFldFProfissao)
                m_FProfissao = value.trim().Length > 100 ? value.trim().substring(0, 100) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public string? FCTPS
    {
        get => m_FCTPS ?? string.Empty;
        set
        {
            pFldFCTPS = pFldFCTPS || !(m_FCTPS ?? string.Empty).Equals(value);
            if (pFldFCTPS)
                m_FCTPS = value.trim().Length > 100 ? value.trim().substring(0, 100) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public string? FPisPasep
    {
        get => m_FPisPasep ?? string.Empty;
        set
        {
            pFldFPisPasep = pFldFPisPasep || !(m_FPisPasep ?? string.Empty).Equals(value);
            if (pFldFPisPasep)
                m_FPisPasep = value.trim().Length > 100 ? value.trim().substring(0, 100) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public string? FRemuneracao
    {
        get => m_FRemuneracao ?? string.Empty;
        set
        {
            pFldFRemuneracao = pFldFRemuneracao || !(m_FRemuneracao ?? string.Empty).Equals(value);
            if (pFldFRemuneracao)
                m_FRemuneracao = value.trim().FixAbc() ?? string.Empty;
        }
    }

    public string? FObjeto
    {
        get => m_FObjeto ?? string.Empty;
        set
        {
            pFldFObjeto = pFldFObjeto || !(m_FObjeto ?? string.Empty).Equals(value);
            if (pFldFObjeto)
                m_FObjeto = value.trim().FixAbc() ?? string.Empty;
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