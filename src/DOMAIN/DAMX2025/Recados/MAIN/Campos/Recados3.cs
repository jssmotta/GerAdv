namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBRecados
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFClienteNome, pFldFDe, pFldFPara, pFldFAssunto, pFldFConcluido, pFldFProcesso, pFldFCliente, pFldFRecado, pFldFUrgente, pFldFImportante, pFldFHora, pFldFData, pFldFVoltara, pFldFPessoal, pFldFRetornar, pFldFRetornoData, pFldFEmotion, pFldFInternetID, pFldFUploaded, pFldFNatureza, pFldFBIU, pFldFAguardarRetorno, pFldFAguardarRetornoPara, pFldFAguardarRetornoOK, pFldFParaID, pFldFNaoPublicavel, pFldFIsContatoCRM, pFldFMasterID, pFldFListaPara, pFldFTyped, pFldFAssuntoRecado, pFldFHistorico, pFldFContatoCRM, pFldFLigacoes, pFldFAgenda;
    [XmlIgnore]
    private protected int m_FProcesso, m_FCliente, m_FEmotion, m_FInternetID, m_FNatureza, m_FParaID, m_FMasterID, m_FAssuntoRecado, m_FHistorico, m_FContatoCRM, m_FLigacoes, m_FAgenda;
    [XmlIgnore]
    private protected string? m_FClienteNome, m_FDe, m_FPara, m_FAssunto, m_FRecado, m_FAguardarRetornoPara, m_FListaPara;
    [XmlIgnore]
    private protected DateTime? m_FHora, m_FData, m_FRetornoData;
    [XmlIgnore]
    private protected bool m_FConcluido, m_FUrgente, m_FImportante, m_FVoltara, m_FPessoal, m_FRetornar, m_FUploaded, m_FBIU, m_FAguardarRetorno, m_FAguardarRetornoOK, m_FNaoPublicavel, m_FIsContatoCRM, m_FTyped;
    [XmlAttribute]
    public string? FClienteNome
    {
        get => m_FClienteNome ?? string.Empty;
        set
        {
            pFldFClienteNome = pFldFClienteNome || !(m_FClienteNome ?? string.Empty).Equals(value);
            if (pFldFClienteNome)
                m_FClienteNome = value.trim().Length > 255 ? value.trim().substring(0, 255) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlAttribute]
    public string? FDe
    {
        get => m_FDe ?? string.Empty;
        set
        {
            pFldFDe = pFldFDe || !(m_FDe ?? string.Empty).Equals(value);
            if (pFldFDe)
                m_FDe = value.trim().Length > 50 ? value.trim().substring(0, 50) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlAttribute]
    public string? FPara
    {
        get => m_FPara ?? string.Empty;
        set
        {
            pFldFPara = pFldFPara || !(m_FPara ?? string.Empty).Equals(value);
            if (pFldFPara)
                m_FPara = value.trim().Length > 50 ? value.trim().substring(0, 50) : value.trim(); // ABC_FIND_CODE123
        }
    }

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

    [XmlAttribute]
    public bool FConcluido
    {
        get => m_FConcluido;
        set
        {
            pFldFConcluido = pFldFConcluido || value != m_FConcluido;
            if (pFldFConcluido)
                m_FConcluido = value;
        }
    }

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

    [XmlAttribute]
    public string? FRecado
    {
        get => m_FRecado ?? string.Empty;
        set
        {
            pFldFRecado = pFldFRecado || !(m_FRecado ?? string.Empty).Equals(value);
            if (pFldFRecado)
                m_FRecado = value.trim().FixAbc() ?? string.Empty;
        }
    }

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

    [XmlAttribute]
    public bool FVoltara
    {
        get => m_FVoltara;
        set
        {
            pFldFVoltara = pFldFVoltara || value != m_FVoltara;
            if (pFldFVoltara)
                m_FVoltara = value;
        }
    }

    [XmlAttribute]
    public bool FPessoal
    {
        get => m_FPessoal;
        set
        {
            pFldFPessoal = pFldFPessoal || value != m_FPessoal;
            if (pFldFPessoal)
                m_FPessoal = value;
        }
    }

    [XmlAttribute]
    public bool FRetornar
    {
        get => m_FRetornar;
        set
        {
            pFldFRetornar = pFldFRetornar || value != m_FRetornar;
            if (pFldFRetornar)
                m_FRetornar = value;
        }
    }

    [XmlIgnore]
    public DateTime MRetornoData => Convert.ToDateTime(m_FRetornoData);

    [XmlAttribute]
    public string? FRetornoData
    {
        get => $"{m_FRetornoData:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FRetornoData:dd/MM/yyyy}";
        set
        {
            var(setUpNow, changed, data) = DevourerOne.DateUp7(pFldFRetornoData, m_FRetornoData, value);
            if (!setUpNow)
                return;
            pFldFRetornoData = changed;
            m_FRetornoData = data;
        }
    }

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

    [XmlAttribute]
    public int FInternetID
    {
        get => m_FInternetID;
        set
        {
            pFldFInternetID = pFldFInternetID || value != m_FInternetID;
            if (pFldFInternetID)
                m_FInternetID = value;
        }
    }

    [XmlAttribute]
    public bool FUploaded
    {
        get => m_FUploaded;
        set
        {
            pFldFUploaded = pFldFUploaded || value != m_FUploaded;
            if (pFldFUploaded)
                m_FUploaded = value;
        }
    }

    [XmlAttribute]
    public int FNatureza
    {
        get => m_FNatureza;
        set
        {
            pFldFNatureza = pFldFNatureza || value != m_FNatureza;
            if (pFldFNatureza)
                m_FNatureza = value;
        }
    }

    [XmlAttribute]
    public bool FBIU
    {
        get => m_FBIU;
        set
        {
            pFldFBIU = pFldFBIU || value != m_FBIU;
            if (pFldFBIU)
                m_FBIU = value;
        }
    }

    [XmlAttribute]
    public bool FAguardarRetorno
    {
        get => m_FAguardarRetorno;
        set
        {
            pFldFAguardarRetorno = pFldFAguardarRetorno || value != m_FAguardarRetorno;
            if (pFldFAguardarRetorno)
                m_FAguardarRetorno = value;
        }
    }

    [XmlAttribute]
    public string? FAguardarRetornoPara
    {
        get => m_FAguardarRetornoPara ?? string.Empty;
        set
        {
            pFldFAguardarRetornoPara = pFldFAguardarRetornoPara || !(m_FAguardarRetornoPara ?? string.Empty).Equals(value);
            if (pFldFAguardarRetornoPara)
                m_FAguardarRetornoPara = value.trim().Length > 255 ? value.trim().substring(0, 255) : value.trim(); // ABC_FIND_CODE123
        }
    }

    [XmlAttribute]
    public bool FAguardarRetornoOK
    {
        get => m_FAguardarRetornoOK;
        set
        {
            pFldFAguardarRetornoOK = pFldFAguardarRetornoOK || value != m_FAguardarRetornoOK;
            if (pFldFAguardarRetornoOK)
                m_FAguardarRetornoOK = value;
        }
    }

    [XmlAttribute]
    public int FParaID
    {
        get => m_FParaID;
        set
        {
            pFldFParaID = pFldFParaID || value != m_FParaID;
            if (pFldFParaID)
                m_FParaID = value;
        }
    }

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

    [XmlAttribute]
    public bool FIsContatoCRM
    {
        get => m_FIsContatoCRM;
        set
        {
            pFldFIsContatoCRM = pFldFIsContatoCRM || value != m_FIsContatoCRM;
            if (pFldFIsContatoCRM)
                m_FIsContatoCRM = value;
        }
    }

    [XmlAttribute]
    public int FMasterID
    {
        get => m_FMasterID;
        set
        {
            pFldFMasterID = pFldFMasterID || value != m_FMasterID;
            if (pFldFMasterID)
                m_FMasterID = value;
        }
    }

    [XmlAttribute]
    public string? FListaPara
    {
        get => m_FListaPara ?? string.Empty;
        set
        {
            pFldFListaPara = pFldFListaPara || !(m_FListaPara ?? string.Empty).Equals(value);
            if (pFldFListaPara)
                m_FListaPara = value.trim().FixAbc() ?? string.Empty;
        }
    }

    [XmlAttribute]
    public bool FTyped
    {
        get => m_FTyped;
        set
        {
            pFldFTyped = pFldFTyped || value != m_FTyped;
            if (pFldFTyped)
                m_FTyped = value;
        }
    }

    [XmlAttribute]
    public int FAssuntoRecado
    {
        get => m_FAssuntoRecado;
        set
        {
            pFldFAssuntoRecado = pFldFAssuntoRecado || value != m_FAssuntoRecado;
            if (pFldFAssuntoRecado)
                m_FAssuntoRecado = value;
        }
    }

    [XmlAttribute]
    public int FHistorico
    {
        get => m_FHistorico;
        set
        {
            pFldFHistorico = pFldFHistorico || value != m_FHistorico;
            if (pFldFHistorico)
                m_FHistorico = value;
        }
    }

    [XmlAttribute]
    public int FContatoCRM
    {
        get => m_FContatoCRM;
        set
        {
            pFldFContatoCRM = pFldFContatoCRM || value != m_FContatoCRM;
            if (pFldFContatoCRM)
                m_FContatoCRM = value;
        }
    }

    [XmlAttribute]
    public int FLigacoes
    {
        get => m_FLigacoes;
        set
        {
            pFldFLigacoes = pFldFLigacoes || value != m_FLigacoes;
            if (pFldFLigacoes)
                m_FLigacoes = value;
        }
    }

    [XmlAttribute]
    public int FAgenda
    {
        get => m_FAgenda;
        set
        {
            pFldFAgenda = pFldFAgenda || value != m_FAgenda;
            if (pFldFAgenda)
                m_FAgenda = value;
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