namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBGruposEmpresas
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFEMail, pFldFInativo, pFldFOponente, pFldFDescricao, pFldFObservacoes, pFldFCliente, pFldFIcone, pFldFDespesaUnificada;
    [XmlIgnore]
    private protected int m_FOponente, m_FCliente;
    [XmlIgnore]
    private protected string? m_FEMail, m_FDescricao, m_FObservacoes, m_FIcone;
    [XmlIgnore]
    private protected bool m_FInativo, m_FDespesaUnificada;
    public string? FEMail
    {
        get => m_FEMail ?? string.Empty;
        set
        {
            pFldFEMail = pFldFEMail || !(m_FEMail ?? string.Empty).Equals(value);
            if (pFldFEMail)
                m_FEMail = value.trim().Length > 255 ? value.trim().substring(0, 255) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public bool FInativo
    {
        get => m_FInativo;
        set
        {
            pFldFInativo = pFldFInativo || value != m_FInativo;
            if (pFldFInativo)
                m_FInativo = value;
        }
    }

    public int FOponente
    {
        get => m_FOponente;
        set
        {
            pFldFOponente = pFldFOponente || value != m_FOponente;
            if (pFldFOponente)
                m_FOponente = value;
        }
    }

    public string? FDescricao
    {
        get => m_FDescricao ?? string.Empty;
        set
        {
            pFldFDescricao = pFldFDescricao || !(m_FDescricao ?? string.Empty).Equals(value);
            if (pFldFDescricao)
                m_FDescricao = value.trim().Length > 50 ? value.trim().substring(0, 50) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public string? FObservacoes
    {
        get => m_FObservacoes ?? string.Empty;
        set
        {
            pFldFObservacoes = pFldFObservacoes || !(m_FObservacoes ?? string.Empty).Equals(value);
            if (pFldFObservacoes)
                m_FObservacoes = value.trim().FixAbc() ?? string.Empty;
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

    public string? FIcone
    {
        get => m_FIcone ?? string.Empty;
        set
        {
            pFldFIcone = pFldFIcone || !(m_FIcone ?? string.Empty).Equals(value);
            if (pFldFIcone)
                m_FIcone = value.trim().Length > 255 ? value.trim().substring(0, 255) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public bool FDespesaUnificada
    {
        get => m_FDespesaUnificada;
        set
        {
            pFldFDespesaUnificada = pFldFDespesaUnificada || value != m_FDespesaUnificada;
            if (pFldFDespesaUnificada)
                m_FDespesaUnificada = value;
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