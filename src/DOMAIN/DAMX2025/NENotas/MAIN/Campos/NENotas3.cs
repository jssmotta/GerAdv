namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBNENotas
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFApenso, pFldFPrecatoria, pFldFInstancia, pFldFMovPro, pFldFNome, pFldFNotaExpedida, pFldFRevisada, pFldFProcesso, pFldFPalavraChave, pFldFData, pFldFNotaPublicada;
    [XmlIgnore]
    private protected int m_FApenso, m_FPrecatoria, m_FInstancia, m_FProcesso, m_FPalavraChave;
    [XmlIgnore]
    private protected string? m_FNome, m_FNotaPublicada;
    [XmlIgnore]
    private protected DateTime? m_FData;
    [XmlIgnore]
    private protected bool m_FMovPro, m_FNotaExpedida, m_FRevisada;
    public int NFApenso() => m_FApenso;
    [XmlAttribute]
    public int FApenso
    {
        get => m_FApenso;
        set
        {
            pFldFApenso = pFldFApenso || value != m_FApenso;
            if (pFldFApenso)
                m_FApenso = value;
        }
    }

    public int NFPrecatoria() => m_FPrecatoria;
    [XmlAttribute]
    public int FPrecatoria
    {
        get => m_FPrecatoria;
        set
        {
            pFldFPrecatoria = pFldFPrecatoria || value != m_FPrecatoria;
            if (pFldFPrecatoria)
                m_FPrecatoria = value;
        }
    }

    public int NFInstancia() => m_FInstancia;
    [XmlAttribute]
    public int FInstancia
    {
        get => m_FInstancia;
        set
        {
            pFldFInstancia = pFldFInstancia || value != m_FInstancia;
            if (pFldFInstancia)
                m_FInstancia = value;
        }
    }

    public bool NFMovPro() => m_FMovPro;
    [XmlAttribute]
    public bool FMovPro
    {
        get => m_FMovPro;
        set
        {
            pFldFMovPro = pFldFMovPro || value != m_FMovPro;
            if (pFldFMovPro)
                m_FMovPro = value;
        }
    }

    public string NFNome() => m_FNome ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FNome
    {
        get => m_FNome ?? string.Empty;
        set
        {
            pFldFNome = pFldFNome || !(m_FNome ?? string.Empty).Equals(value);
            if (pFldFNome)
                m_FNome = value.trim().Length > 20 ? value.trim().substring(0, 20) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public bool NFNotaExpedida() => m_FNotaExpedida;
    [XmlAttribute]
    public bool FNotaExpedida
    {
        get => m_FNotaExpedida;
        set
        {
            pFldFNotaExpedida = pFldFNotaExpedida || value != m_FNotaExpedida;
            if (pFldFNotaExpedida)
                m_FNotaExpedida = value;
        }
    }

    public bool NFRevisada() => m_FRevisada;
    [XmlAttribute]
    public bool FRevisada
    {
        get => m_FRevisada;
        set
        {
            pFldFRevisada = pFldFRevisada || value != m_FRevisada;
            if (pFldFRevisada)
                m_FRevisada = value;
        }
    }

    public int NFProcesso() => m_FProcesso;
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

    public int NFPalavraChave() => m_FPalavraChave;
    [XmlAttribute]
    public int FPalavraChave
    {
        get => m_FPalavraChave;
        set
        {
            pFldFPalavraChave = pFldFPalavraChave || value != m_FPalavraChave;
            if (pFldFPalavraChave)
                m_FPalavraChave = value;
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

    public string NFNotaPublicada() => m_FNotaPublicada ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FNotaPublicada
    {
        get => m_FNotaPublicada ?? string.Empty;
        set
        {
            pFldFNotaPublicada = pFldFNotaPublicada || !(m_FNotaPublicada ?? string.Empty).Equals(value);
            if (pFldFNotaPublicada)
                m_FNotaPublicada = value.trim().FixAbc() ?? string.Empty;
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