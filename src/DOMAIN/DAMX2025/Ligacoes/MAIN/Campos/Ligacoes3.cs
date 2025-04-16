namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBLigacoes
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFAssunto, pFldFAgeClienteAvisado, pFldFCelular, pFldFCliente, pFldFContato, pFldFDataRealizada, pFldFQuemID, pFldFTelefonista, pFldFUltimoAviso, pFldFHoraFinal, pFldFNome, pFldFQuemCodigo, pFldFSolicitante, pFldFPara, pFldFFone, pFldFRamal, pFldFParticular, pFldFRealizada, pFldFStatus, pFldFData, pFldFHora, pFldFUrgente, pFldFLigarPara, pFldFProcesso, pFldFStartScreen, pFldFEmotion, pFldFBold;
    [XmlIgnore]
    private protected int m_FAgeClienteAvisado, m_FCliente, m_FQuemID, m_FTelefonista, m_FQuemCodigo, m_FSolicitante, m_FRamal, m_FProcesso, m_FEmotion;
    [XmlIgnore]
    private protected string? m_FAssunto, m_FContato, m_FNome, m_FPara, m_FFone, m_FStatus, m_FLigarPara;
    [XmlIgnore]
    private protected DateTime? m_FDataRealizada, m_FUltimoAviso, m_FHoraFinal, m_FData, m_FHora;
    [XmlIgnore]
    private protected bool m_FCelular, m_FParticular, m_FRealizada, m_FUrgente, m_FStartScreen, m_FBold;
    public string NFAssunto() => m_FAssunto ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FAssunto
    {
        get => m_FAssunto ?? string.Empty;
        set
        {
            pFldFAssunto = pFldFAssunto || !(m_FAssunto ?? string.Empty).Equals(value);
            if (pFldFAssunto)
                m_FAssunto = value.trim().Length > 200 ? value.trim().substring(0, 200) : value.trim(); // ABC_FIND_CODE123
        }
    }

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

    public bool NFCelular() => m_FCelular;
    [XmlAttribute]
    public bool FCelular
    {
        get => m_FCelular;
        set
        {
            pFldFCelular = pFldFCelular || value != m_FCelular;
            if (pFldFCelular)
                m_FCelular = value;
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

    public string NFContato() => m_FContato ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FContato
    {
        get => m_FContato ?? string.Empty;
        set
        {
            pFldFContato = pFldFContato || !(m_FContato ?? string.Empty).Equals(value);
            if (pFldFContato)
                m_FContato = value.trim().Length > 200 ? value.trim().substring(0, 200) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public string NFDataRealizada() => $"{m_FDataRealizada:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FDataRealizada:dd/MM/yyyy}";
    [XmlIgnore]
    public DateTime MDataRealizada => Convert.ToDateTime(m_FDataRealizada);

    [XmlAttribute]
    public string? FDataRealizada
    {
        get => $"{m_FDataRealizada:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FDataRealizada:dd/MM/yyyy}";
        set
        {
            var(setUpNow, changed, data) = DevourerOne.DateUp7(pFldFDataRealizada, m_FDataRealizada, value);
            if (!setUpNow)
                return;
            pFldFDataRealizada = changed;
            m_FDataRealizada = data;
        }
    }

    public int NFQuemID() => m_FQuemID;
    [XmlAttribute]
    public int FQuemID
    {
        get => m_FQuemID;
        set
        {
            pFldFQuemID = pFldFQuemID || value != m_FQuemID;
            if (pFldFQuemID)
                m_FQuemID = value;
        }
    }

    public int NFTelefonista() => m_FTelefonista;
    [XmlAttribute]
    public int FTelefonista
    {
        get => m_FTelefonista;
        set
        {
            pFldFTelefonista = pFldFTelefonista || value != m_FTelefonista;
            if (pFldFTelefonista)
                m_FTelefonista = value;
        }
    }

    public string NFUltimoAviso() => $"{m_FUltimoAviso:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FUltimoAviso:dd/MM/yyyy}";
    [XmlIgnore]
    public DateTime MUltimoAviso => Convert.ToDateTime(m_FUltimoAviso);

    [XmlAttribute]
    public string? FUltimoAviso
    {
        get => $"{m_FUltimoAviso:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FUltimoAviso:dd/MM/yyyy}";
        set
        {
            var(setUpNow, changed, data) = DevourerOne.DateUp7(pFldFUltimoAviso, m_FUltimoAviso, value);
            if (!setUpNow)
                return;
            pFldFUltimoAviso = changed;
            m_FUltimoAviso = data;
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

    public int NFQuemCodigo() => m_FQuemCodigo;
    [XmlAttribute]
    public int FQuemCodigo
    {
        get => m_FQuemCodigo;
        set
        {
            pFldFQuemCodigo = pFldFQuemCodigo || value != m_FQuemCodigo;
            if (pFldFQuemCodigo)
                m_FQuemCodigo = value;
        }
    }

    public int NFSolicitante() => m_FSolicitante;
    [XmlAttribute]
    public int FSolicitante
    {
        get => m_FSolicitante;
        set
        {
            pFldFSolicitante = pFldFSolicitante || value != m_FSolicitante;
            if (pFldFSolicitante)
                m_FSolicitante = value;
        }
    }

    public string NFPara() => m_FPara ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FPara
    {
        get => m_FPara ?? string.Empty;
        set
        {
            pFldFPara = pFldFPara || !(m_FPara ?? string.Empty).Equals(value);
            if (pFldFPara)
                m_FPara = value.trim().Length > 100 ? value.trim().substring(0, 100) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public string NFFone() => m_FFone ?? string.Empty; // Nullable Helper String 1.0.6
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

    public int NFRamal() => m_FRamal;
    [XmlAttribute]
    public int FRamal
    {
        get => m_FRamal;
        set
        {
            pFldFRamal = pFldFRamal || value != m_FRamal;
            if (pFldFRamal)
                m_FRamal = value;
        }
    }

    public bool NFParticular() => m_FParticular;
    [XmlAttribute]
    public bool FParticular
    {
        get => m_FParticular;
        set
        {
            pFldFParticular = pFldFParticular || value != m_FParticular;
            if (pFldFParticular)
                m_FParticular = value;
        }
    }

    public bool NFRealizada() => m_FRealizada;
    [XmlAttribute]
    public bool FRealizada
    {
        get => m_FRealizada;
        set
        {
            pFldFRealizada = pFldFRealizada || value != m_FRealizada;
            if (pFldFRealizada)
                m_FRealizada = value;
        }
    }

    public string NFStatus() => m_FStatus ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FStatus
    {
        get => m_FStatus ?? string.Empty;
        set
        {
            pFldFStatus = pFldFStatus || !(m_FStatus ?? string.Empty).Equals(value);
            if (pFldFStatus)
                m_FStatus = value.trim().FixAbc() ?? string.Empty;
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

    public string NFHora() => $"{m_FHora:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FHora:HH:mm}";
    [XmlIgnore]
    public DateTime MHora => Convert.ToDateTime(m_FHora);

    [XmlAttribute]
    public string? FHora
    {
        // fdDate2 TRACE CODE
        get => $"{m_FHora:HH:mm}";
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                pFldFHora = pFldFHora || m_FHora != null;
                m_FHora = null;
                return;
            }

            if (value.IsEquals(DevourerOne.PNow))
            {
                pFldFHora = true;
                m_FHora = DevourerOne.DateTimeUtc;
            }
            else
            {
                if (value.IsEquals($"{m_FHora:HH:mm}"))
                    return;
                if (!DateTime.TryParse(value, out var dateTime))
                    return;
                pFldFHora = true;
                m_FHora = dateTime;
            }
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

    public string NFLigarPara() => m_FLigarPara ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FLigarPara
    {
        get => m_FLigarPara ?? string.Empty;
        set
        {
            pFldFLigarPara = pFldFLigarPara || !(m_FLigarPara ?? string.Empty).Equals(value);
            if (pFldFLigarPara)
                m_FLigarPara = value.trim().Length > 255 ? value.trim().substring(0, 255) : value.trim(); // ABC_FIND_CODE123
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

    public bool NFStartScreen() => m_FStartScreen;
    [XmlAttribute]
    public bool FStartScreen
    {
        get => m_FStartScreen;
        set
        {
            pFldFStartScreen = pFldFStartScreen || value != m_FStartScreen;
            if (pFldFStartScreen)
                m_FStartScreen = value;
        }
    }

    public int NFEmotion() => m_FEmotion;
    [XmlAttribute]
    public int FEmotion
    {
        get => m_FEmotion;
        set
        {
            pFldFEmotion = pFldFEmotion || value != m_FEmotion;
            if (pFldFEmotion)
                m_FEmotion = value;
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
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public int GetID() => ID;
}