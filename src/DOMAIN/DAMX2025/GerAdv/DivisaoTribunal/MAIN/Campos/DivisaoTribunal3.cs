namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBDivisaoTribunal
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFNumCodigo, pFldFJustica, pFldFNomeEspecial, pFldFArea, pFldFCidade, pFldFForo, pFldFTribunal, pFldFCodigoDiv, pFldFEndereco, pFldFFone, pFldFFax, pFldFCEP, pFldFObs, pFldFEMail, pFldFAndar, pFldFEtiqueta, pFldFBold;
    [XmlIgnore]
    private protected int m_FNumCodigo, m_FJustica, m_FArea, m_FCidade, m_FForo, m_FTribunal;
    [XmlIgnore]
    private protected string? m_FNomeEspecial, m_FCodigoDiv, m_FEndereco, m_FFone, m_FFax, m_FCEP, m_FObs, m_FEMail, m_FAndar;
    [XmlIgnore]
    private protected bool m_FEtiqueta, m_FBold;
    public int FNumCodigo
    {
        get => m_FNumCodigo;
        set
        {
            pFldFNumCodigo = pFldFNumCodigo || value != m_FNumCodigo;
            if (pFldFNumCodigo)
                m_FNumCodigo = value;
        }
    }

    public int FJustica
    {
        get => m_FJustica;
        set
        {
            pFldFJustica = pFldFJustica || value != m_FJustica;
            if (pFldFJustica)
                m_FJustica = value;
        }
    }

    public string? FNomeEspecial
    {
        get => m_FNomeEspecial ?? string.Empty;
        set
        {
            pFldFNomeEspecial = pFldFNomeEspecial || !(m_FNomeEspecial ?? string.Empty).Equals(value);
            if (pFldFNomeEspecial)
                m_FNomeEspecial = value.trim().Length > 255 ? value.trim().substring(0, 255) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public int FArea
    {
        get => m_FArea;
        set
        {
            pFldFArea = pFldFArea || value != m_FArea;
            if (pFldFArea)
                m_FArea = value;
        }
    }

    public int FCidade
    {
        get => m_FCidade;
        set
        {
            pFldFCidade = pFldFCidade || value != m_FCidade;
            if (pFldFCidade)
                m_FCidade = value;
        }
    }

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

    public int FTribunal
    {
        get => m_FTribunal;
        set
        {
            pFldFTribunal = pFldFTribunal || value != m_FTribunal;
            if (pFldFTribunal)
                m_FTribunal = value;
        }
    }

    public string? FCodigoDiv
    {
        get => m_FCodigoDiv ?? string.Empty;
        set
        {
            pFldFCodigoDiv = pFldFCodigoDiv || !(m_FCodigoDiv ?? string.Empty).Equals(value);
            if (pFldFCodigoDiv)
                m_FCodigoDiv = value.trim().Length > 5 ? value.trim().substring(0, 5) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public string? FEndereco
    {
        get => m_FEndereco ?? string.Empty;
        set
        {
            pFldFEndereco = pFldFEndereco || !(m_FEndereco ?? string.Empty).Equals(value);
            if (pFldFEndereco)
                m_FEndereco = value.trim().Length > 40 ? value.trim().substring(0, 40) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public string? FFone
    {
        get => m_FFone ?? string.Empty;
        set
        {
            pFldFFone = pFldFFone || !(m_FFone ?? string.Empty).Equals(value);
            if (pFldFFone)
                m_FFone = value.trim().FixAbc() ?? string.Empty;
        }
    }

    public string? FFax
    {
        get => m_FFax ?? string.Empty;
        set
        {
            pFldFFax = pFldFFax || !(m_FFax ?? string.Empty).Equals(value);
            if (pFldFFax)
                m_FFax = value.trim().FixAbc() ?? string.Empty;
        }
    }

    public string? FCEP
    {
        get => m_FCEP ?? string.Empty;
        set
        {
            pFldFCEP = pFldFCEP || !(m_FCEP ?? string.Empty).Equals(value);
            if (pFldFCEP)
                m_FCEP = value.trim().Length > 10 ? value.trim().substring(0, 10) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public string? FObs
    {
        get => m_FObs ?? string.Empty;
        set
        {
            pFldFObs = pFldFObs || !(m_FObs ?? string.Empty).Equals(value);
            if (pFldFObs)
                m_FObs = value.trim().FixAbc() ?? string.Empty;
        }
    }

    public string? FEMail
    {
        get => m_FEMail ?? string.Empty;
        set
        {
            pFldFEMail = pFldFEMail || !(m_FEMail ?? string.Empty).Equals(value);
            if (pFldFEMail)
                m_FEMail = value.trim().Length > 150 ? value.trim().substring(0, 150) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public string? FAndar
    {
        get => m_FAndar ?? string.Empty;
        set
        {
            pFldFAndar = pFldFAndar || !(m_FAndar ?? string.Empty).Equals(value);
            if (pFldFAndar)
                m_FAndar = value.trim().Length > 12 ? value.trim().substring(0, 12) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public bool FEtiqueta
    {
        get => m_FEtiqueta;
        set
        {
            pFldFEtiqueta = pFldFEtiqueta || value != m_FEtiqueta;
            if (pFldFEtiqueta)
                m_FEtiqueta = value;
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
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public int GetID() => ID;
}