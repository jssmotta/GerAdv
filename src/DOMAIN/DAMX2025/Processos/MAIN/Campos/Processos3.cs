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