namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBApenso
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFProcesso, pFldFApenso, pFldFAcao, pFldFDtDist, pFldFOBS, pFldFValorCausa;
    [XmlIgnore]
    private protected int m_FProcesso;
    [XmlIgnore]
    private protected string? m_FApenso, m_FAcao, m_FOBS;
    [XmlIgnore]
    private protected DateTime? m_FDtDist;
    [XmlIgnore]
    private protected decimal m_FValorCausa;
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

    public string NFApenso() => m_FApenso ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FApenso
    {
        get => m_FApenso ?? string.Empty;
        set
        {
            pFldFApenso = pFldFApenso || !(m_FApenso ?? string.Empty).Equals(value);
            if (pFldFApenso)
                m_FApenso = value.trim().Length > 25 ? value.trim().substring(0, 25) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public string NFAcao() => m_FAcao ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FAcao
    {
        get => m_FAcao ?? string.Empty;
        set
        {
            pFldFAcao = pFldFAcao || !(m_FAcao ?? string.Empty).Equals(value);
            if (pFldFAcao)
                m_FAcao = value.trim().Length > 25 ? value.trim().substring(0, 25) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public string NFDtDist() => $"{m_FDtDist:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FDtDist:dd/MM/yyyy}";
    [XmlIgnore]
    public DateTime MDtDist => Convert.ToDateTime(m_FDtDist);

    [XmlAttribute]
    public string? FDtDist
    {
        get => $"{m_FDtDist:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FDtDist:dd/MM/yyyy}";
        set
        {
            var(setUpNow, changed, data) = DevourerOne.DateUp7(pFldFDtDist, m_FDtDist, value);
            if (!setUpNow)
                return;
            pFldFDtDist = changed;
            m_FDtDist = data;
        }
    }

    public string NFOBS() => m_FOBS ?? string.Empty; // Nullable Helper String 1.0.6
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

    public decimal NFValorCausa() => m_FValorCausa;
    [XmlAttribute]
    public decimal FValorCausa
    {
        get => m_FValorCausa;
        set
        {
            if (value == m_FValorCausa)
                return;
            pFldFValorCausa = true;
            m_FValorCausa = value;
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