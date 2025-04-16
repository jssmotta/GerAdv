namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBAgendaFinanceiro
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFIDCOB, pFldFIDNE, pFldFPrazoProvisionado, pFldFCidade, pFldFOculto, pFldFCartaPrecatoria, pFldFRepetirDias, pFldFHrFinal, pFldFRepetir, pFldFAdvogado, pFldFEventoGerador, pFldFEventoData, pFldFFuncionario, pFldFData, pFldFEventoPrazo, pFldFHora, pFldFCompromisso, pFldFTipoCompromisso, pFldFCliente, pFldFDDias, pFldFDias, pFldFLiberado, pFldFImportante, pFldFConcluido, pFldFArea, pFldFJustica, pFldFProcesso, pFldFIDHistorico, pFldFIDInsProcesso, pFldFUsuario, pFldFPreposto, pFldFQuemID, pFldFQuemCodigo, pFldFStatus, pFldFValor, pFldFCompromissoHTML, pFldFDecisao, pFldFRevisar, pFldFRevisarP2, pFldFSempre, pFldFPrazoDias, pFldFProtocoloIntegrado, pFldFDataInicioPrazo, pFldFUsuarioCiente;
    [XmlIgnore]
    private protected int m_FIDCOB, m_FIDNE, m_FPrazoProvisionado, m_FCidade, m_FOculto, m_FCartaPrecatoria, m_FRepetirDias, m_FRepetir, m_FAdvogado, m_FEventoGerador, m_FFuncionario, m_FEventoPrazo, m_FTipoCompromisso, m_FCliente, m_FDias, m_FArea, m_FJustica, m_FProcesso, m_FIDHistorico, m_FIDInsProcesso, m_FUsuario, m_FPreposto, m_FQuemID, m_FQuemCodigo, m_FSempre, m_FPrazoDias, m_FProtocoloIntegrado;
    [XmlIgnore]
    private protected string? m_FCompromisso, m_FStatus, m_FCompromissoHTML, m_FDecisao;
    [XmlIgnore]
    private protected DateTime? m_FHrFinal, m_FEventoData, m_FData, m_FHora, m_FDDias, m_FDataInicioPrazo;
    [XmlIgnore]
    private protected bool m_FLiberado, m_FImportante, m_FConcluido, m_FRevisar, m_FRevisarP2, m_FUsuarioCiente;
    [XmlIgnore]
    private protected decimal m_FValor;
    public int NFIDCOB() => m_FIDCOB;
    [XmlAttribute]
    public int FIDCOB
    {
        get => m_FIDCOB;
        set
        {
            pFldFIDCOB = pFldFIDCOB || value != m_FIDCOB;
            if (pFldFIDCOB)
                m_FIDCOB = value;
        }
    }

    public int NFIDNE() => m_FIDNE;
    [XmlAttribute]
    public int FIDNE
    {
        get => m_FIDNE;
        set
        {
            pFldFIDNE = pFldFIDNE || value != m_FIDNE;
            if (pFldFIDNE)
                m_FIDNE = value;
        }
    }

    public int NFPrazoProvisionado() => m_FPrazoProvisionado;
    [XmlAttribute]
    public int FPrazoProvisionado
    {
        get => m_FPrazoProvisionado;
        set
        {
            pFldFPrazoProvisionado = pFldFPrazoProvisionado || value != m_FPrazoProvisionado;
            if (pFldFPrazoProvisionado)
                m_FPrazoProvisionado = value;
        }
    }

    public int NFCidade() => m_FCidade;
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

    public int NFOculto() => m_FOculto;
    [XmlAttribute]
    public int FOculto
    {
        get => m_FOculto;
        set
        {
            pFldFOculto = pFldFOculto || value != m_FOculto;
            if (pFldFOculto)
                m_FOculto = value;
        }
    }

    public int NFCartaPrecatoria() => m_FCartaPrecatoria;
    [XmlAttribute]
    public int FCartaPrecatoria
    {
        get => m_FCartaPrecatoria;
        set
        {
            pFldFCartaPrecatoria = pFldFCartaPrecatoria || value != m_FCartaPrecatoria;
            if (pFldFCartaPrecatoria)
                m_FCartaPrecatoria = value;
        }
    }

    public int NFRepetirDias() => m_FRepetirDias;
    [XmlAttribute]
    public int FRepetirDias
    {
        get => m_FRepetirDias;
        set
        {
            pFldFRepetirDias = pFldFRepetirDias || value != m_FRepetirDias;
            if (pFldFRepetirDias)
                m_FRepetirDias = value;
        }
    }

    public string NFHrFinal() => $"{m_FHrFinal:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FHrFinal:HH:mm}";
    [XmlIgnore]
    public DateTime MHrFinal => Convert.ToDateTime(m_FHrFinal);

    [XmlAttribute]
    public string? FHrFinal
    {
        // fdDate2 TRACE CODE
        get => $"{m_FHrFinal:HH:mm}";
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                pFldFHrFinal = pFldFHrFinal || m_FHrFinal != null;
                m_FHrFinal = null;
                return;
            }

            if (value.IsEquals(DevourerOne.PNow))
            {
                pFldFHrFinal = true;
                m_FHrFinal = DevourerOne.DateTimeUtc;
            }
            else
            {
                if (value.IsEquals($"{m_FHrFinal:HH:mm}"))
                    return;
                if (!DateTime.TryParse(value, out var dateTime))
                    return;
                pFldFHrFinal = true;
                m_FHrFinal = dateTime;
            }
        }
    }

    public int NFRepetir() => m_FRepetir;
    [XmlAttribute]
    public int FRepetir
    {
        get => m_FRepetir;
        set
        {
            pFldFRepetir = pFldFRepetir || value != m_FRepetir;
            if (pFldFRepetir)
                m_FRepetir = value;
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

    public int NFEventoGerador() => m_FEventoGerador;
    [XmlAttribute]
    public int FEventoGerador
    {
        get => m_FEventoGerador;
        set
        {
            pFldFEventoGerador = pFldFEventoGerador || value != m_FEventoGerador;
            if (pFldFEventoGerador)
                m_FEventoGerador = value;
        }
    }

    public string NFEventoData() => $"{m_FEventoData:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FEventoData:dd/MM/yyyy}";
    [XmlIgnore]
    public DateTime MEventoData => Convert.ToDateTime(m_FEventoData);

    [XmlAttribute]
    public string? FEventoData
    {
        get => $"{m_FEventoData:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FEventoData:dd/MM/yyyy}";
        set
        {
            var(setUpNow, changed, data) = DevourerOne.DateUp7(pFldFEventoData, m_FEventoData, value);
            if (!setUpNow)
                return;
            pFldFEventoData = changed;
            m_FEventoData = data;
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

    public int NFEventoPrazo() => m_FEventoPrazo;
    [XmlAttribute]
    public int FEventoPrazo
    {
        get => m_FEventoPrazo;
        set
        {
            pFldFEventoPrazo = pFldFEventoPrazo || value != m_FEventoPrazo;
            if (pFldFEventoPrazo)
                m_FEventoPrazo = value;
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

    public string NFCompromisso() => m_FCompromisso ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FCompromisso
    {
        get => m_FCompromisso ?? string.Empty;
        set
        {
            pFldFCompromisso = pFldFCompromisso || !(m_FCompromisso ?? string.Empty).Equals(value);
            if (pFldFCompromisso)
                m_FCompromisso = value.trim().FixAbc() ?? string.Empty;
        }
    }

    public int NFTipoCompromisso() => m_FTipoCompromisso;
    [XmlAttribute]
    public int FTipoCompromisso
    {
        get => m_FTipoCompromisso;
        set
        {
            pFldFTipoCompromisso = pFldFTipoCompromisso || value != m_FTipoCompromisso;
            if (pFldFTipoCompromisso)
                m_FTipoCompromisso = value;
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

    public string NFDDias() => $"{m_FDDias:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FDDias:dd/MM/yyyy}";
    [XmlIgnore]
    public DateTime MDDias => Convert.ToDateTime(m_FDDias);

    [XmlAttribute]
    public string? FDDias
    {
        get => $"{m_FDDias:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FDDias:dd/MM/yyyy}";
        set
        {
            var(setUpNow, changed, data) = DevourerOne.DateUp7(pFldFDDias, m_FDDias, value);
            if (!setUpNow)
                return;
            pFldFDDias = changed;
            m_FDDias = data;
        }
    }

    public int NFDias() => m_FDias;
    [XmlAttribute]
    public int FDias
    {
        get => m_FDias;
        set
        {
            pFldFDias = pFldFDias || value != m_FDias;
            if (pFldFDias)
                m_FDias = value;
        }
    }

    public bool NFLiberado() => m_FLiberado;
    [XmlAttribute]
    public bool FLiberado
    {
        get => m_FLiberado;
        set
        {
            pFldFLiberado = pFldFLiberado || value != m_FLiberado;
            if (pFldFLiberado)
                m_FLiberado = value;
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

    public bool NFConcluido() => m_FConcluido;
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

    public int NFArea() => m_FArea;
    [XmlAttribute]
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

    public int NFJustica() => m_FJustica;
    [XmlAttribute]
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

    public int NFIDHistorico() => m_FIDHistorico;
    [XmlAttribute]
    public int FIDHistorico
    {
        get => m_FIDHistorico;
        set
        {
            pFldFIDHistorico = pFldFIDHistorico || value != m_FIDHistorico;
            if (pFldFIDHistorico)
                m_FIDHistorico = value;
        }
    }

    public int NFIDInsProcesso() => m_FIDInsProcesso;
    [XmlAttribute]
    public int FIDInsProcesso
    {
        get => m_FIDInsProcesso;
        set
        {
            pFldFIDInsProcesso = pFldFIDInsProcesso || value != m_FIDInsProcesso;
            if (pFldFIDInsProcesso)
                m_FIDInsProcesso = value;
        }
    }

    public int NFUsuario() => m_FUsuario;
    [XmlAttribute]
    public int FUsuario
    {
        get => m_FUsuario;
        set
        {
            pFldFUsuario = pFldFUsuario || value != m_FUsuario;
            if (pFldFUsuario)
                m_FUsuario = value;
        }
    }

    public int NFPreposto() => m_FPreposto;
    [XmlAttribute]
    public int FPreposto
    {
        get => m_FPreposto;
        set
        {
            pFldFPreposto = pFldFPreposto || value != m_FPreposto;
            if (pFldFPreposto)
                m_FPreposto = value;
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

    public string NFCompromissoHTML() => m_FCompromissoHTML ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FCompromissoHTML
    {
        get => m_FCompromissoHTML ?? string.Empty;
        set
        {
            pFldFCompromissoHTML = pFldFCompromissoHTML || !(m_FCompromissoHTML ?? string.Empty).Equals(value);
            if (pFldFCompromissoHTML)
                m_FCompromissoHTML = value.trim().FixAbc() ?? string.Empty;
        }
    }

    public string NFDecisao() => m_FDecisao ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FDecisao
    {
        get => m_FDecisao ?? string.Empty;
        set
        {
            pFldFDecisao = pFldFDecisao || !(m_FDecisao ?? string.Empty).Equals(value);
            if (pFldFDecisao)
                m_FDecisao = value.trim().Length > 2048 ? value.trim().substring(0, 2048) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public bool NFRevisar() => m_FRevisar;
    [XmlAttribute]
    public bool FRevisar
    {
        get => m_FRevisar;
        set
        {
            pFldFRevisar = pFldFRevisar || value != m_FRevisar;
            if (pFldFRevisar)
                m_FRevisar = value;
        }
    }

    public bool NFRevisarP2() => m_FRevisarP2;
    [XmlAttribute]
    public bool FRevisarP2
    {
        get => m_FRevisarP2;
        set
        {
            pFldFRevisarP2 = pFldFRevisarP2 || value != m_FRevisarP2;
            if (pFldFRevisarP2)
                m_FRevisarP2 = value;
        }
    }

    public int NFSempre() => m_FSempre;
    [XmlAttribute]
    public int FSempre
    {
        get => m_FSempre;
        set
        {
            pFldFSempre = pFldFSempre || value != m_FSempre;
            if (pFldFSempre)
                m_FSempre = value;
        }
    }

    public int NFPrazoDias() => m_FPrazoDias;
    [XmlAttribute]
    public int FPrazoDias
    {
        get => m_FPrazoDias;
        set
        {
            pFldFPrazoDias = pFldFPrazoDias || value != m_FPrazoDias;
            if (pFldFPrazoDias)
                m_FPrazoDias = value;
        }
    }

    public int NFProtocoloIntegrado() => m_FProtocoloIntegrado;
    [XmlAttribute]
    public int FProtocoloIntegrado
    {
        get => m_FProtocoloIntegrado;
        set
        {
            pFldFProtocoloIntegrado = pFldFProtocoloIntegrado || value != m_FProtocoloIntegrado;
            if (pFldFProtocoloIntegrado)
                m_FProtocoloIntegrado = value;
        }
    }

    public string NFDataInicioPrazo() => $"{m_FDataInicioPrazo:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FDataInicioPrazo:dd/MM/yyyy}";
    [XmlIgnore]
    public DateTime MDataInicioPrazo => Convert.ToDateTime(m_FDataInicioPrazo);

    [XmlAttribute]
    public string? FDataInicioPrazo
    {
        get => $"{m_FDataInicioPrazo:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FDataInicioPrazo:dd/MM/yyyy}";
        set
        {
            var(setUpNow, changed, data) = DevourerOne.DateUp7(pFldFDataInicioPrazo, m_FDataInicioPrazo, value);
            if (!setUpNow)
                return;
            pFldFDataInicioPrazo = changed;
            m_FDataInicioPrazo = data;
        }
    }

    public bool NFUsuarioCiente() => m_FUsuarioCiente;
    [XmlAttribute]
    public bool FUsuarioCiente
    {
        get => m_FUsuarioCiente;
        set
        {
            pFldFUsuarioCiente = pFldFUsuarioCiente || value != m_FUsuarioCiente;
            if (pFldFUsuarioCiente)
                m_FUsuarioCiente = value;
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