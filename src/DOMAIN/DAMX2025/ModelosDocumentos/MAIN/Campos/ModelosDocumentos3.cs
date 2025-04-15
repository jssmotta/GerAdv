namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBModelosDocumentos
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFNome, pFldFRemuneracao, pFldFAssinatura, pFldFHeader, pFldFFooter, pFldFExtra1, pFldFExtra2, pFldFExtra3, pFldFOutorgante, pFldFOutorgados, pFldFPoderes, pFldFObjeto, pFldFTitulo, pFldFTestemunhas, pFldFTipoModeloDocumento, pFldFCSS;
    [XmlIgnore]
    private protected int m_FTipoModeloDocumento;
    [XmlIgnore]
    private protected string? m_FNome, m_FRemuneracao, m_FAssinatura, m_FHeader, m_FFooter, m_FExtra1, m_FExtra2, m_FExtra3, m_FOutorgante, m_FOutorgados, m_FPoderes, m_FObjeto, m_FTitulo, m_FTestemunhas, m_FCSS;
    public string NFNome() => m_FNome ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FNome
    {
        get => m_FNome ?? string.Empty;
        set
        {
            pFldFNome = pFldFNome || !(m_FNome ?? string.Empty).Equals(value);
            if (pFldFNome)
                m_FNome = value.trim().Length > 50 ? value.trim().substring(0, 50) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public string NFRemuneracao() => m_FRemuneracao ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
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

    public string NFAssinatura() => m_FAssinatura ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FAssinatura
    {
        get => m_FAssinatura ?? string.Empty;
        set
        {
            pFldFAssinatura = pFldFAssinatura || !(m_FAssinatura ?? string.Empty).Equals(value);
            if (pFldFAssinatura)
                m_FAssinatura = value.trim().FixAbc() ?? string.Empty;
        }
    }

    public string NFHeader() => m_FHeader ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FHeader
    {
        get => m_FHeader ?? string.Empty;
        set
        {
            pFldFHeader = pFldFHeader || !(m_FHeader ?? string.Empty).Equals(value);
            if (pFldFHeader)
                m_FHeader = value.trim().FixAbc() ?? string.Empty;
        }
    }

    public string NFFooter() => m_FFooter ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FFooter
    {
        get => m_FFooter ?? string.Empty;
        set
        {
            pFldFFooter = pFldFFooter || !(m_FFooter ?? string.Empty).Equals(value);
            if (pFldFFooter)
                m_FFooter = value.trim().FixAbc() ?? string.Empty;
        }
    }

    public string NFExtra1() => m_FExtra1 ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FExtra1
    {
        get => m_FExtra1 ?? string.Empty;
        set
        {
            pFldFExtra1 = pFldFExtra1 || !(m_FExtra1 ?? string.Empty).Equals(value);
            if (pFldFExtra1)
                m_FExtra1 = value.trim().FixAbc() ?? string.Empty;
        }
    }

    public string NFExtra2() => m_FExtra2 ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FExtra2
    {
        get => m_FExtra2 ?? string.Empty;
        set
        {
            pFldFExtra2 = pFldFExtra2 || !(m_FExtra2 ?? string.Empty).Equals(value);
            if (pFldFExtra2)
                m_FExtra2 = value.trim().FixAbc() ?? string.Empty;
        }
    }

    public string NFExtra3() => m_FExtra3 ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FExtra3
    {
        get => m_FExtra3 ?? string.Empty;
        set
        {
            pFldFExtra3 = pFldFExtra3 || !(m_FExtra3 ?? string.Empty).Equals(value);
            if (pFldFExtra3)
                m_FExtra3 = value.trim().FixAbc() ?? string.Empty;
        }
    }

    public string NFOutorgante() => m_FOutorgante ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FOutorgante
    {
        get => m_FOutorgante ?? string.Empty;
        set
        {
            pFldFOutorgante = pFldFOutorgante || !(m_FOutorgante ?? string.Empty).Equals(value);
            if (pFldFOutorgante)
                m_FOutorgante = value.trim().FixAbc() ?? string.Empty;
        }
    }

    public string NFOutorgados() => m_FOutorgados ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FOutorgados
    {
        get => m_FOutorgados ?? string.Empty;
        set
        {
            pFldFOutorgados = pFldFOutorgados || !(m_FOutorgados ?? string.Empty).Equals(value);
            if (pFldFOutorgados)
                m_FOutorgados = value.trim().FixAbc() ?? string.Empty;
        }
    }

    public string NFPoderes() => m_FPoderes ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FPoderes
    {
        get => m_FPoderes ?? string.Empty;
        set
        {
            pFldFPoderes = pFldFPoderes || !(m_FPoderes ?? string.Empty).Equals(value);
            if (pFldFPoderes)
                m_FPoderes = value.trim().FixAbc() ?? string.Empty;
        }
    }

    public string NFObjeto() => m_FObjeto ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
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

    public string NFTitulo() => m_FTitulo ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FTitulo
    {
        get => m_FTitulo ?? string.Empty;
        set
        {
            pFldFTitulo = pFldFTitulo || !(m_FTitulo ?? string.Empty).Equals(value);
            if (pFldFTitulo)
                m_FTitulo = value.trim().Length > 2000 ? value.trim().substring(0, 2000) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public string NFTestemunhas() => m_FTestemunhas ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FTestemunhas
    {
        get => m_FTestemunhas ?? string.Empty;
        set
        {
            pFldFTestemunhas = pFldFTestemunhas || !(m_FTestemunhas ?? string.Empty).Equals(value);
            if (pFldFTestemunhas)
                m_FTestemunhas = value.trim().FixAbc() ?? string.Empty;
        }
    }

    public int NFTipoModeloDocumento() => m_FTipoModeloDocumento;
    [XmlAttribute]
    public int FTipoModeloDocumento
    {
        get => m_FTipoModeloDocumento;
        set
        {
            pFldFTipoModeloDocumento = pFldFTipoModeloDocumento || value != m_FTipoModeloDocumento;
            if (pFldFTipoModeloDocumento)
                m_FTipoModeloDocumento = value;
        }
    }

    public string NFCSS() => m_FCSS ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FCSS
    {
        get => m_FCSS ?? string.Empty;
        set
        {
            pFldFCSS = pFldFCSS || !(m_FCSS ?? string.Empty).Equals(value);
            if (pFldFCSS)
                m_FCSS = value.trim().FixAbc() ?? string.Empty;
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