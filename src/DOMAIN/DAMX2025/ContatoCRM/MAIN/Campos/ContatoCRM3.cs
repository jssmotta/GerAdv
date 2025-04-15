namespace MenphisSI.GerAdv;
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
    public int NFAgeClienteAvisado() => m_FAgeClienteAvisado;
    [XmlAttribute]
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

    public int NFDocsViaRecebimento() => m_FDocsViaRecebimento;
    [XmlAttribute]
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

    public bool NFNaoPublicavel() => m_FNaoPublicavel;
    [XmlAttribute]
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

    public bool NFNotificar() => m_FNotificar;
    [XmlAttribute]
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

    public bool NFOcultar() => m_FOcultar;
    [XmlAttribute]
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

    public string NFAssunto() => m_FAssunto ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
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

    public bool NFIsDocsRecebidos() => m_FIsDocsRecebidos;
    [XmlAttribute]
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

    public int NFQuemNotificou() => m_FQuemNotificou;
    [XmlAttribute]
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

    public string NFDataNotificou() => $"{m_FDataNotificou:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FDataNotificou:dd/MM/yyyy}";
    [XmlIgnore]
    public DateTime MDataNotificou => Convert.ToDateTime(m_FDataNotificou);

    [XmlAttribute]
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

    public int NFOperador() => m_FOperador;
    [XmlAttribute]
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

    public string NFHoraNotificou() => $"{m_FHoraNotificou:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FHoraNotificou:HH:mm}";
    [XmlIgnore]
    public DateTime MHoraNotificou => Convert.ToDateTime(m_FHoraNotificou);

    [XmlAttribute]
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

    public int NFObjetoNotificou() => m_FObjetoNotificou;
    [XmlAttribute]
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

    public string NFPessoaContato() => m_FPessoaContato ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
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

    public string NFHoraInicial() => $"{m_FHoraInicial:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FHoraInicial:HH:mm}";
    [XmlIgnore]
    public DateTime MHoraInicial => Convert.ToDateTime(m_FHoraInicial);

    [XmlAttribute]
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

    public string NFHoraFinal() => $"{m_FHoraFinal:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FHoraFinal:HH:mm}";
    [XmlIgnore]
    public DateTime MHoraFinal => Convert.ToDateTime(m_FHoraFinal);

    [XmlAttribute]
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

    public bool NFImportante() => m_FImportante;
    [XmlAttribute]
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

    public bool NFUrgente() => m_FUrgente;
    [XmlAttribute]
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

    public bool NFGerarHoraTrabalhada() => m_FGerarHoraTrabalhada;
    [XmlAttribute]
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

    public bool NFExibirNoTopo() => m_FExibirNoTopo;
    [XmlAttribute]
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

    public int NFTipoContatoCRM() => m_FTipoContatoCRM;
    [XmlAttribute]
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

    public string NFContato() => m_FContato ?? string.Empty; // Nullable Helper String 1.0.6
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

    public int NFEmocao() => m_FEmocao;
    [XmlAttribute]
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

    public bool NFContinuar() => m_FContinuar;
    [XmlAttribute]
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

    public bool NFBold() => m_FBold;
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
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public int GetID() => ID;
}