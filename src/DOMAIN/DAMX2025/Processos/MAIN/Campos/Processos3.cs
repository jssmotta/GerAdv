namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBProcessos
{
    // LOCALIZADOR: 09-06-2017 // Checkpoint campos Sexo
    [XmlIgnore]
    private protected bool pFldFAdvParc, pFldFAJGPedidoNegado, pFldFAJGCliente, pFldFAJGPedidoNegadoOPO, pFldFNotificarPOE, pFldFValorProvisionado, pFldFAJGOponente, pFldFValorCacheCalculo, pFldFAJGPedidoOPO, pFldFValorCacheCalculoProv, pFldFConsiderarParado, pFldFValorCalculado, pFldFAJGConcedidoOPO, pFldFCobranca, pFldFDataEntrada, pFldFPenhora, pFldFAJGPedido, pFldFTipoBaixa, pFldFClassRisco, pFldFIsApenso, pFldFValorCausaInicial, pFldFAJGConcedido, pFldFObsBCX, pFldFValorCausaDefinitivo, pFldFPercProbExito, pFldFMNA, pFldFPercExito, pFldFNroExtra, pFldFAdvOpo, pFldFExtra, pFldFJustica, pFldFAdvogado, pFldFNroCaixa, pFldFPreposto, pFldFCliente, pFldFOponente, pFldFArea, pFldFCidade, pFldFSituacao, pFldFIDSituacao, pFldFValor, pFldFRito, pFldFFato, pFldFNroPasta, pFldFAtividade, pFldFCaixaMorto, pFldFBaixado, pFldFDtBaixa, pFldFMotivoBaixa, pFldFOBS, pFldFPrinted, pFldFZKey, pFldFZKeyQuem, pFldFZKeyQuando, pFldFResumo, pFldFNaoImprimir, pFldFEletronico, pFldFNroContrato, pFldFPercProbExitoJustificativa, pFldFHonorarioValor, pFldFHonorarioPercentual, pFldFHonorarioSucumbencia, pFldFFaseAuditoria, pFldFValorCondenacao, pFldFValorCondenacaoCalculado, pFldFValorCondenacaoProvisorio;
    [XmlIgnore]
    private protected int m_FAdvParc, m_FTipoBaixa, m_FClassRisco, m_FAdvOpo, m_FJustica, m_FAdvogado, m_FPreposto, m_FCliente, m_FOponente, m_FArea, m_FCidade, m_FSituacao, m_FRito, m_FAtividade, m_FZKeyQuem, m_FFaseAuditoria, m_FValorCondenacaoProvisorio;
    [XmlIgnore]
    private protected string? m_FObsBCX, m_FNroExtra, m_FNroCaixa, m_FFato, m_FNroPasta, m_FCaixaMorto, m_FMotivoBaixa, m_FOBS, m_FZKey, m_FResumo, m_FNroContrato, m_FPercProbExitoJustificativa;
    [XmlIgnore]
    private protected DateTime? m_FDataEntrada, m_FDtBaixa, m_FZKeyQuando;
    [XmlIgnore]
    private protected bool m_FAJGPedidoNegado, m_FAJGCliente, m_FAJGPedidoNegadoOPO, m_FNotificarPOE, m_FAJGOponente, m_FAJGPedidoOPO, m_FConsiderarParado, m_FValorCalculado, m_FAJGConcedidoOPO, m_FCobranca, m_FPenhora, m_FAJGPedido, m_FIsApenso, m_FAJGConcedido, m_FMNA, m_FExtra, m_FIDSituacao, m_FBaixado, m_FPrinted, m_FNaoImprimir, m_FEletronico;
    [XmlIgnore]
    private protected decimal m_FValorProvisionado, m_FValorCacheCalculo, m_FValorCacheCalculoProv, m_FValorCausaInicial, m_FValorCausaDefinitivo, m_FPercProbExito, m_FPercExito, m_FValor, m_FHonorarioValor, m_FHonorarioPercentual, m_FHonorarioSucumbencia, m_FValorCondenacao, m_FValorCondenacaoCalculado;
    public int NFAdvParc() => m_FAdvParc;
    [XmlAttribute]
    public int FAdvParc
    {
        get => m_FAdvParc;
        set
        {
            pFldFAdvParc = pFldFAdvParc || value != m_FAdvParc;
            if (pFldFAdvParc)
                m_FAdvParc = value;
        }
    }

    public bool NFAJGPedidoNegado() => m_FAJGPedidoNegado;
    [XmlAttribute]
    public bool FAJGPedidoNegado
    {
        get => m_FAJGPedidoNegado;
        set
        {
            pFldFAJGPedidoNegado = pFldFAJGPedidoNegado || value != m_FAJGPedidoNegado;
            if (pFldFAJGPedidoNegado)
                m_FAJGPedidoNegado = value;
        }
    }

    public bool NFAJGCliente() => m_FAJGCliente;
    [XmlAttribute]
    public bool FAJGCliente
    {
        get => m_FAJGCliente;
        set
        {
            pFldFAJGCliente = pFldFAJGCliente || value != m_FAJGCliente;
            if (pFldFAJGCliente)
                m_FAJGCliente = value;
        }
    }

    public bool NFAJGPedidoNegadoOPO() => m_FAJGPedidoNegadoOPO;
    [XmlAttribute]
    public bool FAJGPedidoNegadoOPO
    {
        get => m_FAJGPedidoNegadoOPO;
        set
        {
            pFldFAJGPedidoNegadoOPO = pFldFAJGPedidoNegadoOPO || value != m_FAJGPedidoNegadoOPO;
            if (pFldFAJGPedidoNegadoOPO)
                m_FAJGPedidoNegadoOPO = value;
        }
    }

    public bool NFNotificarPOE() => m_FNotificarPOE;
    [XmlAttribute]
    public bool FNotificarPOE
    {
        get => m_FNotificarPOE;
        set
        {
            pFldFNotificarPOE = pFldFNotificarPOE || value != m_FNotificarPOE;
            if (pFldFNotificarPOE)
                m_FNotificarPOE = value;
        }
    }

    public decimal NFValorProvisionado() => m_FValorProvisionado;
    [XmlAttribute]
    public decimal FValorProvisionado
    {
        get => m_FValorProvisionado;
        set
        {
            if (value == m_FValorProvisionado)
                return;
            pFldFValorProvisionado = true;
            m_FValorProvisionado = value;
        }
    }

    public bool NFAJGOponente() => m_FAJGOponente;
    [XmlAttribute]
    public bool FAJGOponente
    {
        get => m_FAJGOponente;
        set
        {
            pFldFAJGOponente = pFldFAJGOponente || value != m_FAJGOponente;
            if (pFldFAJGOponente)
                m_FAJGOponente = value;
        }
    }

    public decimal NFValorCacheCalculo() => m_FValorCacheCalculo;
    [XmlAttribute]
    public decimal FValorCacheCalculo
    {
        get => m_FValorCacheCalculo;
        set
        {
            if (value == m_FValorCacheCalculo)
                return;
            pFldFValorCacheCalculo = true;
            m_FValorCacheCalculo = value;
        }
    }

    public bool NFAJGPedidoOPO() => m_FAJGPedidoOPO;
    [XmlAttribute]
    public bool FAJGPedidoOPO
    {
        get => m_FAJGPedidoOPO;
        set
        {
            pFldFAJGPedidoOPO = pFldFAJGPedidoOPO || value != m_FAJGPedidoOPO;
            if (pFldFAJGPedidoOPO)
                m_FAJGPedidoOPO = value;
        }
    }

    public decimal NFValorCacheCalculoProv() => m_FValorCacheCalculoProv;
    [XmlAttribute]
    public decimal FValorCacheCalculoProv
    {
        get => m_FValorCacheCalculoProv;
        set
        {
            if (value == m_FValorCacheCalculoProv)
                return;
            pFldFValorCacheCalculoProv = true;
            m_FValorCacheCalculoProv = value;
        }
    }

    public bool NFConsiderarParado() => m_FConsiderarParado;
    [XmlAttribute]
    public bool FConsiderarParado
    {
        get => m_FConsiderarParado;
        set
        {
            pFldFConsiderarParado = pFldFConsiderarParado || value != m_FConsiderarParado;
            if (pFldFConsiderarParado)
                m_FConsiderarParado = value;
        }
    }

    public bool NFValorCalculado() => m_FValorCalculado;
    [XmlAttribute]
    public bool FValorCalculado
    {
        get => m_FValorCalculado;
        set
        {
            pFldFValorCalculado = pFldFValorCalculado || value != m_FValorCalculado;
            if (pFldFValorCalculado)
                m_FValorCalculado = value;
        }
    }

    public bool NFAJGConcedidoOPO() => m_FAJGConcedidoOPO;
    [XmlAttribute]
    public bool FAJGConcedidoOPO
    {
        get => m_FAJGConcedidoOPO;
        set
        {
            pFldFAJGConcedidoOPO = pFldFAJGConcedidoOPO || value != m_FAJGConcedidoOPO;
            if (pFldFAJGConcedidoOPO)
                m_FAJGConcedidoOPO = value;
        }
    }

    public bool NFCobranca() => m_FCobranca;
    [XmlAttribute]
    public bool FCobranca
    {
        get => m_FCobranca;
        set
        {
            pFldFCobranca = pFldFCobranca || value != m_FCobranca;
            if (pFldFCobranca)
                m_FCobranca = value;
        }
    }

    public string NFDataEntrada() => $"{m_FDataEntrada:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FDataEntrada:dd/MM/yyyy}";
    [XmlIgnore]
    public DateTime MDataEntrada => Convert.ToDateTime(m_FDataEntrada);

    [XmlAttribute]
    public string? FDataEntrada
    {
        get => $"{m_FDataEntrada:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FDataEntrada:dd/MM/yyyy}";
        set
        {
            var(setUpNow, changed, data) = DevourerOne.DateUp7(pFldFDataEntrada, m_FDataEntrada, value);
            if (!setUpNow)
                return;
            pFldFDataEntrada = changed;
            m_FDataEntrada = data;
        }
    }

    public bool NFPenhora() => m_FPenhora;
    [XmlAttribute]
    public bool FPenhora
    {
        get => m_FPenhora;
        set
        {
            pFldFPenhora = pFldFPenhora || value != m_FPenhora;
            if (pFldFPenhora)
                m_FPenhora = value;
        }
    }

    public bool NFAJGPedido() => m_FAJGPedido;
    [XmlAttribute]
    public bool FAJGPedido
    {
        get => m_FAJGPedido;
        set
        {
            pFldFAJGPedido = pFldFAJGPedido || value != m_FAJGPedido;
            if (pFldFAJGPedido)
                m_FAJGPedido = value;
        }
    }

    public int NFTipoBaixa() => m_FTipoBaixa;
    [XmlAttribute]
    public int FTipoBaixa
    {
        get => m_FTipoBaixa;
        set
        {
            pFldFTipoBaixa = pFldFTipoBaixa || value != m_FTipoBaixa;
            if (pFldFTipoBaixa)
                m_FTipoBaixa = value;
        }
    }

    public int NFClassRisco() => m_FClassRisco;
    [XmlAttribute]
    public int FClassRisco
    {
        get => m_FClassRisco;
        set
        {
            pFldFClassRisco = pFldFClassRisco || value != m_FClassRisco;
            if (pFldFClassRisco)
                m_FClassRisco = value;
        }
    }

    public bool NFIsApenso() => m_FIsApenso;
    [XmlAttribute]
    public bool FIsApenso
    {
        get => m_FIsApenso;
        set
        {
            pFldFIsApenso = pFldFIsApenso || value != m_FIsApenso;
            if (pFldFIsApenso)
                m_FIsApenso = value;
        }
    }

    public decimal NFValorCausaInicial() => m_FValorCausaInicial;
    [XmlAttribute]
    public decimal FValorCausaInicial
    {
        get => m_FValorCausaInicial;
        set
        {
            if (value == m_FValorCausaInicial)
                return;
            pFldFValorCausaInicial = true;
            m_FValorCausaInicial = value;
        }
    }

    public bool NFAJGConcedido() => m_FAJGConcedido;
    [XmlAttribute]
    public bool FAJGConcedido
    {
        get => m_FAJGConcedido;
        set
        {
            pFldFAJGConcedido = pFldFAJGConcedido || value != m_FAJGConcedido;
            if (pFldFAJGConcedido)
                m_FAJGConcedido = value;
        }
    }

    public string NFObsBCX() => m_FObsBCX ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FObsBCX
    {
        get => m_FObsBCX ?? string.Empty;
        set
        {
            pFldFObsBCX = pFldFObsBCX || !(m_FObsBCX ?? string.Empty).Equals(value);
            if (pFldFObsBCX)
                m_FObsBCX = value.trim().FixAbc() ?? string.Empty;
        }
    }

    public decimal NFValorCausaDefinitivo() => m_FValorCausaDefinitivo;
    [XmlAttribute]
    public decimal FValorCausaDefinitivo
    {
        get => m_FValorCausaDefinitivo;
        set
        {
            if (value == m_FValorCausaDefinitivo)
                return;
            pFldFValorCausaDefinitivo = true;
            m_FValorCausaDefinitivo = value;
        }
    }

    public decimal NFPercProbExito() => m_FPercProbExito;
    [XmlAttribute]
    public decimal FPercProbExito
    {
        get => m_FPercProbExito;
        set
        {
            if (value == m_FPercProbExito)
                return;
            pFldFPercProbExito = true;
            m_FPercProbExito = value;
        }
    }

    public bool NFMNA() => m_FMNA;
    [XmlAttribute]
    public bool FMNA
    {
        get => m_FMNA;
        set
        {
            pFldFMNA = pFldFMNA || value != m_FMNA;
            if (pFldFMNA)
                m_FMNA = value;
        }
    }

    public decimal NFPercExito() => m_FPercExito;
    [XmlAttribute]
    public decimal FPercExito
    {
        get => m_FPercExito;
        set
        {
            if (value == m_FPercExito)
                return;
            pFldFPercExito = true;
            m_FPercExito = value;
        }
    }

    public string NFNroExtra() => m_FNroExtra ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FNroExtra
    {
        get => m_FNroExtra ?? string.Empty;
        set
        {
            pFldFNroExtra = pFldFNroExtra || !(m_FNroExtra ?? string.Empty).Equals(value);
            if (pFldFNroExtra)
                m_FNroExtra = value.trim().Length > 35 ? value.trim().substring(0, 35) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public int NFAdvOpo() => m_FAdvOpo;
    [XmlAttribute]
    public int FAdvOpo
    {
        get => m_FAdvOpo;
        set
        {
            pFldFAdvOpo = pFldFAdvOpo || value != m_FAdvOpo;
            if (pFldFAdvOpo)
                m_FAdvOpo = value;
        }
    }

    public bool NFExtra() => m_FExtra;
    [XmlAttribute]
    public bool FExtra
    {
        get => m_FExtra;
        set
        {
            pFldFExtra = pFldFExtra || value != m_FExtra;
            if (pFldFExtra)
                m_FExtra = value;
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

    public string NFNroCaixa() => m_FNroCaixa ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FNroCaixa
    {
        get => m_FNroCaixa ?? string.Empty;
        set
        {
            pFldFNroCaixa = pFldFNroCaixa || !(m_FNroCaixa ?? string.Empty).Equals(value);
            if (pFldFNroCaixa)
                m_FNroCaixa = value.trim().Length > 20 ? value.trim().substring(0, 20) : value.trim(); // ABC_FIND_CODE123
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

    public int NFOponente() => m_FOponente;
    [XmlAttribute]
    public int FOponente
    {
        get => m_FOponente;
        set
        {
            pFldFOponente = pFldFOponente || value != m_FOponente;
            if (pFldFOponente)
                m_FOponente = value;
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

    public int NFSituacao() => m_FSituacao;
    [XmlAttribute]
    public int FSituacao
    {
        get => m_FSituacao;
        set
        {
            pFldFSituacao = pFldFSituacao || value != m_FSituacao;
            if (pFldFSituacao)
                m_FSituacao = value;
        }
    }

    public bool NFIDSituacao() => m_FIDSituacao;
    [XmlAttribute]
    public bool FIDSituacao
    {
        get => m_FIDSituacao;
        set
        {
            pFldFIDSituacao = pFldFIDSituacao || value != m_FIDSituacao;
            if (pFldFIDSituacao)
                m_FIDSituacao = value;
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

    public int NFRito() => m_FRito;
    [XmlAttribute]
    public int FRito
    {
        get => m_FRito;
        set
        {
            pFldFRito = pFldFRito || value != m_FRito;
            if (pFldFRito)
                m_FRito = value;
        }
    }

    public string NFFato() => m_FFato ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FFato
    {
        get => m_FFato ?? string.Empty;
        set
        {
            pFldFFato = pFldFFato || !(m_FFato ?? string.Empty).Equals(value);
            if (pFldFFato)
                m_FFato = value.trim().FixAbc() ?? string.Empty;
        }
    }

    public string NFNroPasta() => m_FNroPasta ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FNroPasta
    {
        get => m_FNroPasta ?? string.Empty;
        set
        {
            pFldFNroPasta = pFldFNroPasta || !(m_FNroPasta ?? string.Empty).Equals(value);
            if (pFldFNroPasta)
                m_FNroPasta = value.trim().Length > 10 ? value.trim().substring(0, 10) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public int NFAtividade() => m_FAtividade;
    [XmlAttribute]
    public int FAtividade
    {
        get => m_FAtividade;
        set
        {
            pFldFAtividade = pFldFAtividade || value != m_FAtividade;
            if (pFldFAtividade)
                m_FAtividade = value;
        }
    }

    public string NFCaixaMorto() => m_FCaixaMorto ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FCaixaMorto
    {
        get => m_FCaixaMorto ?? string.Empty;
        set
        {
            pFldFCaixaMorto = pFldFCaixaMorto || !(m_FCaixaMorto ?? string.Empty).Equals(value);
            if (pFldFCaixaMorto)
                m_FCaixaMorto = value.trim().Length > 10 ? value.trim().substring(0, 10) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public bool NFBaixado() => m_FBaixado;
    [XmlAttribute]
    public bool FBaixado
    {
        get => m_FBaixado;
        set
        {
            pFldFBaixado = pFldFBaixado || value != m_FBaixado;
            if (pFldFBaixado)
                m_FBaixado = value;
        }
    }

    public string NFDtBaixa() => $"{m_FDtBaixa:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FDtBaixa:dd/MM/yyyy}";
    [XmlIgnore]
    public DateTime MDtBaixa => Convert.ToDateTime(m_FDtBaixa);

    [XmlAttribute]
    public string? FDtBaixa
    {
        get => $"{m_FDtBaixa:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FDtBaixa:dd/MM/yyyy}";
        set
        {
            var(setUpNow, changed, data) = DevourerOne.DateUp7(pFldFDtBaixa, m_FDtBaixa, value);
            if (!setUpNow)
                return;
            pFldFDtBaixa = changed;
            m_FDtBaixa = data;
        }
    }

    public string NFMotivoBaixa() => m_FMotivoBaixa ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FMotivoBaixa
    {
        get => m_FMotivoBaixa ?? string.Empty;
        set
        {
            pFldFMotivoBaixa = pFldFMotivoBaixa || !(m_FMotivoBaixa ?? string.Empty).Equals(value);
            if (pFldFMotivoBaixa)
                m_FMotivoBaixa = value.trim().FixAbc() ?? string.Empty;
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

    public bool NFPrinted() => m_FPrinted;
    [XmlAttribute]
    public bool FPrinted
    {
        get => m_FPrinted;
        set
        {
            pFldFPrinted = pFldFPrinted || value != m_FPrinted;
            if (pFldFPrinted)
                m_FPrinted = value;
        }
    }

    public string NFZKey() => m_FZKey ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FZKey
    {
        get => m_FZKey ?? string.Empty;
        set
        {
            pFldFZKey = pFldFZKey || !(m_FZKey ?? string.Empty).Equals(value);
            if (pFldFZKey)
                m_FZKey = value.trim().Length > 20 ? value.trim().substring(0, 20) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public int NFZKeyQuem() => m_FZKeyQuem;
    [XmlAttribute]
    public int FZKeyQuem
    {
        get => m_FZKeyQuem;
        set
        {
            pFldFZKeyQuem = pFldFZKeyQuem || value != m_FZKeyQuem;
            if (pFldFZKeyQuem)
                m_FZKeyQuem = value;
        }
    }

    public string NFZKeyQuando() => $"{m_FZKeyQuando:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FZKeyQuando:dd/MM/yyyy}";
    [XmlIgnore]
    public DateTime MZKeyQuando => Convert.ToDateTime(m_FZKeyQuando);

    [XmlAttribute]
    public string? FZKeyQuando
    {
        get => $"{m_FZKeyQuando:dd/MM/yyyy}".Equals(DevourerOne.PDataZerada) ? string.Empty : $"{m_FZKeyQuando:dd/MM/yyyy}";
        set
        {
            var(setUpNow, changed, data) = DevourerOne.DateUp7(pFldFZKeyQuando, m_FZKeyQuando, value);
            if (!setUpNow)
                return;
            pFldFZKeyQuando = changed;
            m_FZKeyQuando = data;
        }
    }

    public string NFResumo() => m_FResumo ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FResumo
    {
        get => m_FResumo ?? string.Empty;
        set
        {
            pFldFResumo = pFldFResumo || !(m_FResumo ?? string.Empty).Equals(value);
            if (pFldFResumo)
                m_FResumo = value.trim().FixAbc() ?? string.Empty;
        }
    }

    public bool NFNaoImprimir() => m_FNaoImprimir;
    [XmlAttribute]
    public bool FNaoImprimir
    {
        get => m_FNaoImprimir;
        set
        {
            pFldFNaoImprimir = pFldFNaoImprimir || value != m_FNaoImprimir;
            if (pFldFNaoImprimir)
                m_FNaoImprimir = value;
        }
    }

    public bool NFEletronico() => m_FEletronico;
    [XmlAttribute]
    public bool FEletronico
    {
        get => m_FEletronico;
        set
        {
            pFldFEletronico = pFldFEletronico || value != m_FEletronico;
            if (pFldFEletronico)
                m_FEletronico = value;
        }
    }

    public string NFNroContrato() => m_FNroContrato ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FNroContrato
    {
        get => m_FNroContrato ?? string.Empty;
        set
        {
            pFldFNroContrato = pFldFNroContrato || !(m_FNroContrato ?? string.Empty).Equals(value);
            if (pFldFNroContrato)
                m_FNroContrato = value.trim().Length > 100 ? value.trim().substring(0, 100) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public string NFPercProbExitoJustificativa() => m_FPercProbExitoJustificativa ?? string.Empty; // Nullable Helper String 1.0.6
    [XmlAttribute]
    public string? FPercProbExitoJustificativa
    {
        get => m_FPercProbExitoJustificativa ?? string.Empty;
        set
        {
            pFldFPercProbExitoJustificativa = pFldFPercProbExitoJustificativa || !(m_FPercProbExitoJustificativa ?? string.Empty).Equals(value);
            if (pFldFPercProbExitoJustificativa)
                m_FPercProbExitoJustificativa = value.trim().Length > 1024 ? value.trim().substring(0, 1024) : value.trim(); // ABC_FIND_CODE123
        }
    }

    public decimal NFHonorarioValor() => m_FHonorarioValor;
    [XmlAttribute]
    public decimal FHonorarioValor
    {
        get => m_FHonorarioValor;
        set
        {
            if (value == m_FHonorarioValor)
                return;
            pFldFHonorarioValor = true;
            m_FHonorarioValor = value;
        }
    }

    public decimal NFHonorarioPercentual() => m_FHonorarioPercentual;
    [XmlAttribute]
    public decimal FHonorarioPercentual
    {
        get => m_FHonorarioPercentual;
        set
        {
            if (value == m_FHonorarioPercentual)
                return;
            pFldFHonorarioPercentual = true;
            m_FHonorarioPercentual = value;
        }
    }

    public decimal NFHonorarioSucumbencia() => m_FHonorarioSucumbencia;
    [XmlAttribute]
    public decimal FHonorarioSucumbencia
    {
        get => m_FHonorarioSucumbencia;
        set
        {
            if (value == m_FHonorarioSucumbencia)
                return;
            pFldFHonorarioSucumbencia = true;
            m_FHonorarioSucumbencia = value;
        }
    }

    public int NFFaseAuditoria() => m_FFaseAuditoria;
    [XmlAttribute]
    public int FFaseAuditoria
    {
        get => m_FFaseAuditoria;
        set
        {
            pFldFFaseAuditoria = pFldFFaseAuditoria || value != m_FFaseAuditoria;
            if (pFldFFaseAuditoria)
                m_FFaseAuditoria = value;
        }
    }

    public decimal NFValorCondenacao() => m_FValorCondenacao;
    [XmlAttribute]
    public decimal FValorCondenacao
    {
        get => m_FValorCondenacao;
        set
        {
            if (value == m_FValorCondenacao)
                return;
            pFldFValorCondenacao = true;
            m_FValorCondenacao = value;
        }
    }

    public decimal NFValorCondenacaoCalculado() => m_FValorCondenacaoCalculado;
    [XmlAttribute]
    public decimal FValorCondenacaoCalculado
    {
        get => m_FValorCondenacaoCalculado;
        set
        {
            if (value == m_FValorCondenacaoCalculado)
                return;
            pFldFValorCondenacaoCalculado = true;
            m_FValorCondenacaoCalculado = value;
        }
    }

    public int NFValorCondenacaoProvisorio() => m_FValorCondenacaoProvisorio;
    [XmlAttribute]
    public int FValorCondenacaoProvisorio
    {
        get => m_FValorCondenacaoProvisorio;
        set
        {
            pFldFValorCondenacaoProvisorio = pFldFValorCondenacaoProvisorio || value != m_FValorCondenacaoProvisorio;
            if (pFldFValorCondenacaoProvisorio)
                m_FValorCondenacaoProvisorio = value;
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