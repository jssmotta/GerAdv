namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBContatoCRM
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFAgeClienteAvisado, pFldFDocsViaRecebimento, pFldFNaoPublicavel, pFldFNotificar, pFldFOcultar, pFldFAssunto, pFldFIsDocsRecebidos, pFldFQuemNotificou, pFldFDataNotificou, pFldFOperador, pFldFCliente, pFldFHoraNotificou, pFldFObjetoNotificou, pFldFPessoaContato, pFldFData, pFldFTempo, pFldFHoraInicial, pFldFHoraFinal, pFldFProcesso, pFldFImportante, pFldFUrgente, pFldFGerarHoraTrabalhada, pFldFExibirNoTopo, pFldFTipoContatoCRM, pFldFContato, pFldFEmocao, pFldFContinuar, pFldFBold;
    [XmlIgnore]
    private protected int m_FAgeClienteAvisado, m_FDocsViaRecebimento, m_FQuemNotificou, m_FOperador, m_FCliente, m_FObjetoNotificou, m_FProcesso, m_FTipoContatoCRM, m_FEmocao;
    [XmlIgnore]
    private protected string? m_FAssunto, m_FPessoaContato, m_FContato;
    [XmlIgnore]
    private protected DateTime? m_FDataNotificou, m_FHoraNotificou, m_FData, m_FHoraInicial, m_FHoraFinal;
    [XmlIgnore]
    private protected bool m_FNaoPublicavel, m_FNotificar, m_FOcultar, m_FIsDocsRecebidos, m_FImportante, m_FUrgente, m_FGerarHoraTrabalhada, m_FExibirNoTopo, m_FContinuar, m_FBold;
    [XmlIgnore]
    private protected decimal m_FTempo;
    public int FAgeClienteAvisado
    {
        get => m_FAgeClienteAvisado;
        set
        {
            pFldFAgeClienteAvisado = pFldFAgeClienteAvisado || value != m_FAgeClienteAvisado;
            if (pFldFAgeClienteAvisado)
                m_FAgeClienteAvisado = value;
        }
    }

    public int FDocsViaRecebimento
    {
        get => m_FDocsViaRecebimento;
        set
        {
            pFldFDocsViaRecebimento = pFldFDocsViaRecebimento || value != m_FDocsViaRecebimento;
            if (pFldFDocsViaRecebimento)
                m_FDocsViaRecebimento = value;
        }
    }

    public bool FNaoPublicavel
    {
        get => m_FNaoPublicavel;
        set
        {
            pFldFNaoPublicavel = pFldFNaoPublicavel || value != m_FNaoPublicavel;
            if (pFldFNaoPublicavel)
                m_FNaoPublicavel = value;
        }
    }

    public bool FNotificar
    {
        get => m_FNotificar;
        set
        {
            pFldFNotificar = pFldFNotificar || value != m_FNotificar;
            if (pFldFNotificar)
                m_FNotificar = value;
        }
    }

    public bool FOcultar
    {
        get => m_FOcultar;
        set
        {
            pFldFOcultar = pFldFOcultar || value != m_FOcultar;
            if (pFldFOcultar)
                m_FOcultar = value;
        }
    }

    public string? FAssunto
    {
        get => m_FAssunto ?? string.Empty;
        set
        {
            pFldFAssunto = pFldFAssunto || !(m_FAssunto ?? string.Empty).Equals(value);
            if (pFldFAssunto)
                m_FAssunto = value.trim().Length > 255 ? value.trim().substring(0, 255) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public bool FIsDocsRecebidos
    {
        get => m_FIsDocsRecebidos;
        set
        {
            pFldFIsDocsRecebidos = pFldFIsDocsRecebidos || value != m_FIsDocsRecebidos;
            if (pFldFIsDocsRecebidos)
                m_FIsDocsRecebidos = value;
        }
    }

    public int FQuemNotificou
    {
        get => m_FQuemNotificou;
        set
        {
            pFldFQuemNotificou = pFldFQuemNotificou || value != m_FQuemNotificou;
            if (pFldFQuemNotificou)
                m_FQuemNotificou = value;
        }
    }

    [XmlIgnore]
    public DateTime MDataNotificou => Convert.ToDateTime(m_FDataNotificou);

    public string? FDataNotificou
    {
        get => $"{m_FDataNotificou:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FDataNotificou:dd/MM/yyyy}";
        set
        {
            var(setUpNow, changed, data) = DevourerOne.DateUp7(pFldFDataNotificou, m_FDataNotificou, value);
            if (!setUpNow)
                return;
            pFldFDataNotificou = changed;
            m_FDataNotificou = data;
        }
    }

    public int FOperador
    {
        get => m_FOperador;
        set
        {
            pFldFOperador = pFldFOperador || value != m_FOperador;
            if (pFldFOperador)
                m_FOperador = value;
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

    [XmlIgnore]
    public DateTime MHoraNotificou => Convert.ToDateTime(m_FHoraNotificou);

    public string? FHoraNotificou
    {
        // fdDate2 TRACE CODE
        get => $"{m_FHoraNotificou:HH:mm}";
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                pFldFHoraNotificou = pFldFHoraNotificou || m_FHoraNotificou != null;
                m_FHoraNotificou = null;
                return;
            }

            if (value.IsEquals(DevourerOne.PNow))
            {
                pFldFHoraNotificou = true;
                m_FHoraNotificou = DevourerOne.DateTimeUtc;
            }
            else
            {
                if (value.IsEquals($"{m_FHoraNotificou:HH:mm}"))
                    return;
                if (!DateTime.TryParse(value, out var dateTime))
                    return;
                pFldFHoraNotificou = true;
                m_FHoraNotificou = dateTime;
            }
        }
    }

    public int FObjetoNotificou
    {
        get => m_FObjetoNotificou;
        set
        {
            pFldFObjetoNotificou = pFldFObjetoNotificou || value != m_FObjetoNotificou;
            if (pFldFObjetoNotificou)
                m_FObjetoNotificou = value;
        }
    }

    public string? FPessoaContato
    {
        get => m_FPessoaContato ?? string.Empty;
        set
        {
            pFldFPessoaContato = pFldFPessoaContato || !(m_FPessoaContato ?? string.Empty).Equals(value);
            if (pFldFPessoaContato)
                m_FPessoaContato = value.trim().Length > 255 ? value.trim().substring(0, 255) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlIgnore]
    public DateTime MData => Convert.ToDateTime(m_FData);

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

    [XmlIgnore]
    public DateTime MHoraInicial => Convert.ToDateTime(m_FHoraInicial);

    public string? FHoraInicial
    {
        // fdDate2 TRACE CODE
        get => $"{m_FHoraInicial:HH:mm}";
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                pFldFHoraInicial = pFldFHoraInicial || m_FHoraInicial != null;
                m_FHoraInicial = null;
                return;
            }

            if (value.IsEquals(DevourerOne.PNow))
            {
                pFldFHoraInicial = true;
                m_FHoraInicial = DevourerOne.DateTimeUtc;
            }
            else
            {
                if (value.IsEquals($"{m_FHoraInicial:HH:mm}"))
                    return;
                if (!DateTime.TryParse(value, out var dateTime))
                    return;
                pFldFHoraInicial = true;
                m_FHoraInicial = dateTime;
            }
        }
    }

    [XmlIgnore]
    public DateTime MHoraFinal => Convert.ToDateTime(m_FHoraFinal);

    public string? FHoraFinal
    {
        // fdDate2 TRACE CODE
        get => $"{m_FHoraFinal:HH:mm}";
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                pFldFHoraFinal = pFldFHoraFinal || m_FHoraFinal != null;
                m_FHoraFinal = null;
                return;
            }

            if (value.IsEquals(DevourerOne.PNow))
            {
                pFldFHoraFinal = true;
                m_FHoraFinal = DevourerOne.DateTimeUtc;
            }
            else
            {
                if (value.IsEquals($"{m_FHoraFinal:HH:mm}"))
                    return;
                if (!DateTime.TryParse(value, out var dateTime))
                    return;
                pFldFHoraFinal = true;
                m_FHoraFinal = dateTime;
            }
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

    public bool FImportante
    {
        get => m_FImportante;
        set
        {
            pFldFImportante = pFldFImportante || value != m_FImportante;
            if (pFldFImportante)
                m_FImportante = value;
        }
    }

    public bool FUrgente
    {
        get => m_FUrgente;
        set
        {
            pFldFUrgente = pFldFUrgente || value != m_FUrgente;
            if (pFldFUrgente)
                m_FUrgente = value;
        }
    }

    public bool FGerarHoraTrabalhada
    {
        get => m_FGerarHoraTrabalhada;
        set
        {
            pFldFGerarHoraTrabalhada = pFldFGerarHoraTrabalhada || value != m_FGerarHoraTrabalhada;
            if (pFldFGerarHoraTrabalhada)
                m_FGerarHoraTrabalhada = value;
        }
    }

    public bool FExibirNoTopo
    {
        get => m_FExibirNoTopo;
        set
        {
            pFldFExibirNoTopo = pFldFExibirNoTopo || value != m_FExibirNoTopo;
            if (pFldFExibirNoTopo)
                m_FExibirNoTopo = value;
        }
    }

    public int FTipoContatoCRM
    {
        get => m_FTipoContatoCRM;
        set
        {
            pFldFTipoContatoCRM = pFldFTipoContatoCRM || value != m_FTipoContatoCRM;
            if (pFldFTipoContatoCRM)
                m_FTipoContatoCRM = value;
        }
    }

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

    public int FEmocao
    {
        get => m_FEmocao;
        set
        {
            pFldFEmocao = pFldFEmocao || value != m_FEmocao;
            if (pFldFEmocao)
                m_FEmocao = value;
        }
    }

    public bool FContinuar
    {
        get => m_FContinuar;
        set
        {
            pFldFContinuar = pFldFContinuar || value != m_FContinuar;
            if (pFldFContinuar)
                m_FContinuar = value;
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