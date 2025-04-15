namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBHorasTrab
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFIDContatoCRM, pFldFHonorario, pFldFIDAgenda, pFldFData, pFldFCliente, pFldFStatus, pFldFProcesso, pFldFAdvogado, pFldFFuncionario, pFldFHrIni, pFldFHrFim, pFldFTempo, pFldFValor, pFldFOBS, pFldFAnexo, pFldFAnexoComp, pFldFAnexoUNC, pFldFServico;
    [XmlIgnore]
    private protected int m_FIDContatoCRM, m_FIDAgenda, m_FCliente, m_FStatus, m_FProcesso, m_FAdvogado, m_FFuncionario, m_FServico;
    [XmlIgnore]
    private protected string? m_FHrIni, m_FHrFim, m_FOBS, m_FAnexo, m_FAnexoComp, m_FAnexoUNC;
    [XmlIgnore]
    private protected DateTime? m_FData;
    [XmlIgnore]
    private protected bool m_FHonorario;
    [XmlIgnore]
    private protected decimal m_FTempo, m_FValor;
    public int NFIDContatoCRM() => m_FIDContatoCRM;
    [XmlAttribute]
    public int FIDContatoCRM
    {
        get => m_FIDContatoCRM;
        set
        {
            pFldFIDContatoCRM = pFldFIDContatoCRM || value != m_FIDContatoCRM;
            if (pFldFIDContatoCRM)
                m_FIDContatoCRM = value;
        }
    }

    public bool NFHonorario() => m_FHonorario;
    [XmlAttribute]
    public bool FHonorario
    {
        get => m_FHonorario;
        set
        {
            pFldFHonorario = pFldFHonorario || value != m_FHonorario;
            if (pFldFHonorario)
                m_FHonorario = value;
        }
    }

    public int NFIDAgenda() => m_FIDAgenda;
    [XmlAttribute]
    public int FIDAgenda
    {
        get => m_FIDAgenda;
        set
        {
            pFldFIDAgenda = pFldFIDAgenda || value != m_FIDAgenda;
            if (pFldFIDAgenda)
                m_FIDAgenda = value;
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

    public int NFCliente() => m_FCliente;
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

    public int NFStatus() => m_FStatus;
    [XmlAttribute]
    public int FStatus
    {
        get => m_FStatus;
        set
        {
            pFldFStatus = pFldFStatus || value != m_FStatus;
            if (pFldFStatus)
                m_FStatus = value;
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

    public int NFAdvogado() => m_FAdvogado;
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

    public int NFFuncionario() => m_FFuncionario;
    [XmlAttribute]
    public int FFuncionario
    {
        get => m_FFuncionario;
        set
        {
            pFldFFuncionario = pFldFFuncionario || value != m_FFuncionario;
            if (pFldFFuncionario)
                m_FFuncionario = value;
        }
    }

    public string NFHrIni() => m_FHrIni ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FHrIni
    {
        get => m_FHrIni ?? string.Empty;
        set
        {
            pFldFHrIni = pFldFHrIni || !(m_FHrIni ?? string.Empty).Equals(value);
            if (pFldFHrIni)
                m_FHrIni = value.trim().Length > 5 ? value.trim().substring(0, 5) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public string NFHrFim() => m_FHrFim ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FHrFim
    {
        get => m_FHrFim ?? string.Empty;
        set
        {
            pFldFHrFim = pFldFHrFim || !(m_FHrFim ?? string.Empty).Equals(value);
            if (pFldFHrFim)
                m_FHrFim = value.trim().Length > 5 ? value.trim().substring(0, 5) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public decimal NFTempo() => m_FTempo;
    [XmlAttribute]
    public decimal FTempo
    {
        get => m_FTempo;
        set
        {
            if (value == m_FTempo)
                return;
            pFldFTempo = true;
            m_FTempo = value;
        }
    }

    public decimal NFValor() => m_FValor;
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

    public string NFAnexo() => m_FAnexo ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FAnexo
    {
        get => m_FAnexo ?? string.Empty;
        set
        {
            pFldFAnexo = pFldFAnexo || !(m_FAnexo ?? string.Empty).Equals(value);
            if (pFldFAnexo)
                m_FAnexo = value.trim().Length > 255 ? value.trim().substring(0, 255) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public string NFAnexoComp() => m_FAnexoComp ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FAnexoComp
    {
        get => m_FAnexoComp ?? string.Empty;
        set
        {
            pFldFAnexoComp = pFldFAnexoComp || !(m_FAnexoComp ?? string.Empty).Equals(value);
            if (pFldFAnexoComp)
                m_FAnexoComp = value.trim().Length > 50 ? value.trim().substring(0, 50) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public string NFAnexoUNC() => m_FAnexoUNC ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FAnexoUNC
    {
        get => m_FAnexoUNC ?? string.Empty;
        set
        {
            pFldFAnexoUNC = pFldFAnexoUNC || !(m_FAnexoUNC ?? string.Empty).Equals(value);
            if (pFldFAnexoUNC)
                m_FAnexoUNC = value.trim().Length > 255 ? value.trim().substring(0, 255) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public int NFServico() => m_FServico;
    [XmlAttribute]
    public int FServico
    {
        get => m_FServico;
        set
        {
            pFldFServico = pFldFServico || value != m_FServico;
            if (pFldFServico)
                m_FServico = value;
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