namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBEnderecos
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFTopIndex, pFldFDescricao, pFldFContato, pFldFDtNasc, pFldFEndereco, pFldFBairro, pFldFPrivativo, pFldFAddContato, pFldFCEP, pFldFOAB, pFldFOBS, pFldFFone, pFldFFax, pFldFTratamento, pFldFCidade, pFldFSite, pFldFEMail, pFldFQuem, pFldFQuemIndicou, pFldFReportECBOnly, pFldFEtiqueta, pFldFAni, pFldFBold;
    [XmlIgnore]
    private protected int m_FCidade, m_FQuem;
    [XmlIgnore]
    private protected string? m_FDescricao, m_FContato, m_FEndereco, m_FBairro, m_FCEP, m_FOAB, m_FOBS, m_FFone, m_FFax, m_FTratamento, m_FSite, m_FEMail, m_FQuemIndicou;
    [XmlIgnore]
    private protected DateTime? m_FDtNasc;
    [XmlIgnore]
    private protected bool m_FTopIndex, m_FPrivativo, m_FAddContato, m_FReportECBOnly, m_FEtiqueta, m_FAni, m_FBold;
    [XmlAttribute]
    public bool FTopIndex
    {
        get => m_FTopIndex;
        set
        {
            pFldFTopIndex = pFldFTopIndex || value != m_FTopIndex;
            if (pFldFTopIndex)
                m_FTopIndex = value;
        }
    }

    [XmlAttribute]
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

    [XmlAttribute]
    public string? FContato
    {
        get => m_FContato ?? string.Empty;
        set
        {
            pFldFContato = pFldFContato || !(m_FContato ?? string.Empty).Equals(value);
            if (pFldFContato)
                m_FContato = value.trim().FixAbc() ?? string.Empty;
        }
    }

    [XmlIgnore]
    public DateTime MDtNasc => Convert.ToDateTime(m_FDtNasc);

    [XmlAttribute]
    public string? FDtNasc
    {
        get => $"{m_FDtNasc:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FDtNasc:dd/MM/yyyy}";
        set
        {
            var(setUpNow, changed, data) = DevourerOne.DateUp7(pFldFDtNasc, m_FDtNasc, value);
            if (!setUpNow)
                return;
            pFldFDtNasc = changed;
            m_FDtNasc = data;
        }
    }

    [XmlAttribute]
    public string? FEndereco
    {
        get => m_FEndereco ?? string.Empty;
        set
        {
            pFldFEndereco = pFldFEndereco || !(m_FEndereco ?? string.Empty).Equals(value);
            if (pFldFEndereco)
                m_FEndereco = value.trim().Length > 50 ? value.trim().substring(0, 50) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlAttribute]
    public string? FBairro
    {
        get => m_FBairro ?? string.Empty;
        set
        {
            pFldFBairro = pFldFBairro || !(m_FBairro ?? string.Empty).Equals(value);
            if (pFldFBairro)
                m_FBairro = value.trim().Length > 30 ? value.trim().substring(0, 30) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlAttribute]
    public bool FPrivativo
    {
        get => m_FPrivativo;
        set
        {
            pFldFPrivativo = pFldFPrivativo || value != m_FPrivativo;
            if (pFldFPrivativo)
                m_FPrivativo = value;
        }
    }

    [XmlAttribute]
    public bool FAddContato
    {
        get => m_FAddContato;
        set
        {
            pFldFAddContato = pFldFAddContato || value != m_FAddContato;
            if (pFldFAddContato)
                m_FAddContato = value;
        }
    }

    public string CEPMask() => DevourerOne.MaskCep(FCEP);
    [XmlAttribute]
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

    [XmlAttribute]
    public string? FOAB
    {
        get => m_FOAB ?? string.Empty;
        set
        {
            pFldFOAB = pFldFOAB || !(m_FOAB ?? string.Empty).Equals(value);
            if (pFldFOAB)
                m_FOAB = value.trim().Length > 20 ? value.trim().substring(0, 20) : value.trim(); // ABC_FIND_CODE123
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

    [XmlAttribute]
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

    [XmlAttribute]
    public string? FTratamento
    {
        get => m_FTratamento ?? string.Empty;
        set
        {
            pFldFTratamento = pFldFTratamento || !(m_FTratamento ?? string.Empty).Equals(value);
            if (pFldFTratamento)
                m_FTratamento = value.trim().Length > 20 ? value.trim().substring(0, 20) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlAttribute]
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

    [XmlAttribute]
    public string? FSite
    {
        get => m_FSite ?? string.Empty;
        set
        {
            pFldFSite = pFldFSite || !(m_FSite ?? string.Empty).Equals(value);
            if (pFldFSite)
                m_FSite = value.trim().Length > 200 ? value.trim().substring(0, 200) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlAttribute]
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

    [XmlAttribute]
    public int FQuem
    {
        get => m_FQuem;
        set
        {
            pFldFQuem = pFldFQuem || value != m_FQuem;
            if (pFldFQuem)
                m_FQuem = value;
        }
    }

    [XmlAttribute]
    public string? FQuemIndicou
    {
        get => m_FQuemIndicou ?? string.Empty;
        set
        {
            pFldFQuemIndicou = pFldFQuemIndicou || !(m_FQuemIndicou ?? string.Empty).Equals(value);
            if (pFldFQuemIndicou)
                m_FQuemIndicou = value.trim().Length > 150 ? value.trim().substring(0, 150) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlAttribute]
    public bool FReportECBOnly
    {
        get => m_FReportECBOnly;
        set
        {
            pFldFReportECBOnly = pFldFReportECBOnly || value != m_FReportECBOnly;
            if (pFldFReportECBOnly)
                m_FReportECBOnly = value;
        }
    }

    [XmlAttribute]
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

    [XmlAttribute]
    public bool FAni
    {
        get => m_FAni;
        set
        {
            pFldFAni = pFldFAni || value != m_FAni;
            if (pFldFAni)
                m_FAni = value;
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
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public int GetID() => ID;
}