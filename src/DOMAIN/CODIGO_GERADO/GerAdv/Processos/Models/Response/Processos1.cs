#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Models.Response;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Serializable]
public partial class ProcessosResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - proAdvOpo  
    /// </summary>
    [JsonPropertyName("advopo")]
    public int AdvOpo { get; set; }

    /// <summary>
    /// Sem descrição - proJustica  
    /// </summary>
    [JsonPropertyName("justica")]
    public int Justica { get; set; }

    /// <summary>
    /// Sem descrição - proAdvogado  
    /// </summary>
    [JsonPropertyName("advogado")]
    public int Advogado { get; set; }

    /// <summary>
    /// Sem descrição - proPreposto  
    /// </summary>
    [JsonPropertyName("preposto")]
    public int Preposto { get; set; }

    /// <summary>
    /// Sem descrição - proCliente  
    /// </summary>
    [JsonPropertyName("cliente")]
    public int Cliente { get; set; }

    /// <summary>
    /// Sem descrição - proOponente  
    /// </summary>
    [JsonPropertyName("oponente")]
    public int Oponente { get; set; }

    /// <summary>
    /// Sem descrição - proArea  
    /// </summary>
    [JsonPropertyName("area")]
    public int Area { get; set; }

    /// <summary>
    /// Sem descrição - proCidade  
    /// </summary>
    [JsonPropertyName("cidade")]
    public int Cidade { get; set; }

    /// <summary>
    /// Sem descrição - proSituacao  
    /// </summary>
    [JsonPropertyName("situacao")]
    public int Situacao { get; set; }

    /// <summary>
    /// Sem descrição - proRito  
    /// </summary>
    [JsonPropertyName("rito")]
    public int Rito { get; set; }

    /// <summary>
    /// Sem descrição - proAtividade  
    /// </summary>
    [JsonPropertyName("atividade")]
    public int Atividade { get; set; }

    /// <summary>
    /// Sem descrição - proAdvParc  
    /// </summary>
    [JsonPropertyName("advparc")]
    public int AdvParc { get; set; }

    /// <summary>
    /// Sem descrição - proAJGPedidoNegado  
    /// </summary>
    [JsonPropertyName("ajgpedidonegado")]
    public bool AJGPedidoNegado { get; set; }

    /// <summary>
    /// Sem descrição - proAJGCliente  
    /// </summary>
    [JsonPropertyName("ajgcliente")]
    public bool AJGCliente { get; set; }

    /// <summary>
    /// Sem descrição - proAJGPedidoNegadoOPO  
    /// </summary>
    [JsonPropertyName("ajgpedidonegadoopo")]
    public bool AJGPedidoNegadoOPO { get; set; }

    /// <summary>
    /// Sem descrição - proNotificarPOE  
    /// </summary>
    [JsonPropertyName("notificarpoe")]
    public bool NotificarPOE { get; set; }

    /// <summary>
    /// Sem descrição - proValorProvisionado  
    /// </summary>
    [JsonPropertyName("valorprovisionado")]
    public decimal ValorProvisionado { get; set; }

    /// <summary>
    /// Sem descrição - proAJGOponente  
    /// </summary>
    [JsonPropertyName("ajgoponente")]
    public bool AJGOponente { get; set; }

    /// <summary>
    /// Sem descrição - proValorCacheCalculo  
    /// </summary>
    [JsonPropertyName("valorcachecalculo")]
    public decimal ValorCacheCalculo { get; set; }

    /// <summary>
    /// Sem descrição - proAJGPedidoOPO  
    /// </summary>
    [JsonPropertyName("ajgpedidoopo")]
    public bool AJGPedidoOPO { get; set; }

    /// <summary>
    /// Sem descrição - proValorCacheCalculoProv  
    /// </summary>
    [JsonPropertyName("valorcachecalculoprov")]
    public decimal ValorCacheCalculoProv { get; set; }

    /// <summary>
    /// Sem descrição - proConsiderarParado  
    /// </summary>
    [JsonPropertyName("considerarparado")]
    public bool ConsiderarParado { get; set; }

    /// <summary>
    /// Sem descrição - proValorCalculado  
    /// </summary>
    [JsonPropertyName("valorcalculado")]
    public bool ValorCalculado { get; set; }

    /// <summary>
    /// Sem descrição - proAJGConcedidoOPO  
    /// </summary>
    [JsonPropertyName("ajgconcedidoopo")]
    public bool AJGConcedidoOPO { get; set; }

    /// <summary>
    /// Sem descrição - proCobranca  
    /// </summary>
    [JsonPropertyName("cobranca")]
    public bool Cobranca { get; set; }

    /// <summary>
    /// Sem descrição - proDataEntrada  
    /// </summary>
    [JsonPropertyName("dataentrada")]
    public string DataEntrada { get; set; } = "";

    /// <summary>
    /// Sem descrição - proPenhora  
    /// </summary>
    [JsonPropertyName("penhora")]
    public bool Penhora { get; set; }

    /// <summary>
    /// Sem descrição - proAJGPedido  
    /// </summary>
    [JsonPropertyName("ajgpedido")]
    public bool AJGPedido { get; set; }

    /// <summary>
    /// Sem descrição - proTipoBaixa  
    /// </summary>
    [JsonPropertyName("tipobaixa")]
    public int TipoBaixa { get; set; }

    /// <summary>
    /// Sem descrição - proClassRisco  
    /// </summary>
    [JsonPropertyName("classrisco")]
    public int ClassRisco { get; set; }

    /// <summary>
    /// Sem descrição - proIsApenso  
    /// </summary>
    [JsonPropertyName("isapenso")]
    public bool IsApenso { get; set; }

    /// <summary>
    /// Sem descrição - proValorCausaInicial  
    /// </summary>
    [JsonPropertyName("valorcausainicial")]
    public decimal ValorCausaInicial { get; set; }

    /// <summary>
    /// Sem descrição - proAJGConcedido  
    /// </summary>
    [JsonPropertyName("ajgconcedido")]
    public bool AJGConcedido { get; set; }

    /// <summary>
    /// Sem descrição - proObsBCX  
    /// </summary>
    [JsonPropertyName("obsbcx")]
    public string ObsBCX { get; set; } = "";

    /// <summary>
    /// Sem descrição - proValorCausaDefinitivo  
    /// </summary>
    [JsonPropertyName("valorcausadefinitivo")]
    public decimal ValorCausaDefinitivo { get; set; }

    /// <summary>
    /// Sem descrição - proPercProbExito  
    /// </summary>
    [JsonPropertyName("percprobexito")]
    public decimal PercProbExito { get; set; }

    /// <summary>
    /// Sem descrição - proMNA  
    /// </summary>
    [JsonPropertyName("mna")]
    public bool MNA { get; set; }

    /// <summary>
    /// Sem descrição - proPercExito  
    /// </summary>
    [JsonPropertyName("percexito")]
    public decimal PercExito { get; set; }

    /// <summary>
    /// Sem descrição - proNroExtra - tamanho máximo: 35 
    /// </summary>
    [JsonPropertyName("nroextra")]
    public string NroExtra { get; set; } = "";

    /// <summary>
    /// Sem descrição - proExtra  
    /// </summary>
    [JsonPropertyName("extra")]
    public bool Extra { get; set; }

    /// <summary>
    /// Sem descrição - proNroCaixa - tamanho máximo: 20 
    /// </summary>
    [JsonPropertyName("nrocaixa")]
    public string NroCaixa { get; set; } = "";

    /// <summary>
    /// Sem descrição - proIDSituacao  
    /// </summary>
    [JsonPropertyName("idsituacao")]
    public bool IDSituacao { get; set; }

    /// <summary>
    /// Sem descrição - proValor  
    /// </summary>
    [JsonPropertyName("valor")]
    public decimal Valor { get; set; }

    /// <summary>
    /// Sem descrição - proFato  
    /// </summary>
    [JsonPropertyName("fato")]
    public string Fato { get; set; } = "";

    /// <summary>
    /// Sem descrição - proNroPasta - tamanho máximo: 10 
    /// </summary>
    [JsonPropertyName("nropasta")]
    public string NroPasta { get; set; } = "";

    /// <summary>
    /// Sem descrição - proCaixaMorto - tamanho máximo: 10 
    /// </summary>
    [JsonPropertyName("caixamorto")]
    public string CaixaMorto { get; set; } = "";

    /// <summary>
    /// Sem descrição - proBaixado  
    /// </summary>
    [JsonPropertyName("baixado")]
    public bool Baixado { get; set; }

    /// <summary>
    /// Sem descrição - proDtBaixa  
    /// </summary>
    [JsonPropertyName("dtbaixa")]
    public string DtBaixa { get; set; } = "";

    /// <summary>
    /// Sem descrição - proMotivoBaixa  
    /// </summary>
    [JsonPropertyName("motivobaixa")]
    public string MotivoBaixa { get; set; } = "";

    /// <summary>
    /// Sem descrição - proOBS  
    /// </summary>
    [JsonPropertyName("obs")]
    public string OBS { get; set; } = "";

    /// <summary>
    /// Sem descrição - proPrinted  
    /// </summary>
    [JsonPropertyName("printed")]
    public bool Printed { get; set; }

    /// <summary>
    /// Sem descrição - proZKey - tamanho máximo: 20 
    /// </summary>
    [JsonPropertyName("zkey")]
    public string ZKey { get; set; } = "";

    /// <summary>
    /// Sem descrição - proZKeyQuem  
    /// </summary>
    [JsonPropertyName("zkeyquem")]
    public int ZKeyQuem { get; set; }

    /// <summary>
    /// Sem descrição - proZKeyQuando  
    /// </summary>
    [JsonPropertyName("zkeyquando")]
    public string ZKeyQuando { get; set; } = "";

    /// <summary>
    /// Sem descrição - proResumo  
    /// </summary>
    [JsonPropertyName("resumo")]
    public string Resumo { get; set; } = "";

    /// <summary>
    /// Sem descrição - proNaoImprimir  
    /// </summary>
    [JsonPropertyName("naoimprimir")]
    public bool NaoImprimir { get; set; }

    /// <summary>
    /// Sem descrição - proEletronico  
    /// </summary>
    [JsonPropertyName("eletronico")]
    public bool Eletronico { get; set; }

    /// <summary>
    /// Sem descrição - proNroContrato - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("nrocontrato")]
    public string NroContrato { get; set; } = "";

    /// <summary>
    /// Sem descrição - proPercProbExitoJustificativa - tamanho máximo: 1024 
    /// </summary>
    [JsonPropertyName("percprobexitojustificativa")]
    public string PercProbExitoJustificativa { get; set; } = "";

    /// <summary>
    /// Sem descrição - proHonorarioValor  
    /// </summary>
    [JsonPropertyName("honorariovalor")]
    public decimal HonorarioValor { get; set; }

    /// <summary>
    /// Sem descrição - proHonorarioPercentual  
    /// </summary>
    [JsonPropertyName("honorariopercentual")]
    public decimal HonorarioPercentual { get; set; }

    /// <summary>
    /// Sem descrição - proHonorarioSucumbencia  
    /// </summary>
    [JsonPropertyName("honorariosucumbencia")]
    public decimal HonorarioSucumbencia { get; set; }

    /// <summary>
    /// Sem descrição - proFaseAuditoria  
    /// </summary>
    [JsonPropertyName("faseauditoria")]
    public int FaseAuditoria { get; set; }

    /// <summary>
    /// Sem descrição - proValorCondenacao  
    /// </summary>
    [JsonPropertyName("valorcondenacao")]
    public decimal ValorCondenacao { get; set; }

    /// <summary>
    /// Sem descrição - proValorCondenacaoCalculado  
    /// </summary>
    [JsonPropertyName("valorcondenacaocalculado")]
    public decimal ValorCondenacaoCalculado { get; set; }

    /// <summary>
    /// Sem descrição - proValorCondenacaoProvisorio  
    /// </summary>
    [JsonPropertyName("valorcondenacaoprovisorio")]
    public int ValorCondenacaoProvisorio { get; set; }

    /// <summary>
    /// GUId - proGUID - tamanho máximo: 120 
    /// </summary>
    [JsonPropertyName("guid")]
    public string GUID { get; set; } = "";
}

[Serializable]
public partial class ProcessosResponseAll
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sem descrição - proAdvOpo  
    /// </summary>
    [JsonPropertyName("advopo")]
    public int AdvOpo { get; set; }

    /// <summary>
    /// Sem descrição - proJustica  
    /// </summary>
    [JsonPropertyName("justica")]
    public int Justica { get; set; }

    /// <summary>
    /// Sem descrição - proAdvogado  
    /// </summary>
    [JsonPropertyName("advogado")]
    public int Advogado { get; set; }

    /// <summary>
    /// Sem descrição - proPreposto  
    /// </summary>
    [JsonPropertyName("preposto")]
    public int Preposto { get; set; }

    /// <summary>
    /// Sem descrição - proCliente  
    /// </summary>
    [JsonPropertyName("cliente")]
    public int Cliente { get; set; }

    /// <summary>
    /// Sem descrição - proOponente  
    /// </summary>
    [JsonPropertyName("oponente")]
    public int Oponente { get; set; }

    /// <summary>
    /// Sem descrição - proArea  
    /// </summary>
    [JsonPropertyName("area")]
    public int Area { get; set; }

    /// <summary>
    /// Sem descrição - proCidade  
    /// </summary>
    [JsonPropertyName("cidade")]
    public int Cidade { get; set; }

    /// <summary>
    /// Sem descrição - proSituacao  
    /// </summary>
    [JsonPropertyName("situacao")]
    public int Situacao { get; set; }

    /// <summary>
    /// Sem descrição - proRito  
    /// </summary>
    [JsonPropertyName("rito")]
    public int Rito { get; set; }

    /// <summary>
    /// Sem descrição - proAtividade  
    /// </summary>
    [JsonPropertyName("atividade")]
    public int Atividade { get; set; }

    /// <summary>
    /// Sem descrição - proAdvParc  
    /// </summary>
    [JsonPropertyName("advparc")]
    public int AdvParc { get; set; }

    /// <summary>
    /// Sem descrição - proAJGPedidoNegado  
    /// </summary>
    [JsonPropertyName("ajgpedidonegado")]
    public bool AJGPedidoNegado { get; set; }

    /// <summary>
    /// Sem descrição - proAJGCliente  
    /// </summary>
    [JsonPropertyName("ajgcliente")]
    public bool AJGCliente { get; set; }

    /// <summary>
    /// Sem descrição - proAJGPedidoNegadoOPO  
    /// </summary>
    [JsonPropertyName("ajgpedidonegadoopo")]
    public bool AJGPedidoNegadoOPO { get; set; }

    /// <summary>
    /// Sem descrição - proNotificarPOE  
    /// </summary>
    [JsonPropertyName("notificarpoe")]
    public bool NotificarPOE { get; set; }

    /// <summary>
    /// Sem descrição - proValorProvisionado  
    /// </summary>
    [JsonPropertyName("valorprovisionado")]
    public decimal ValorProvisionado { get; set; }

    /// <summary>
    /// Sem descrição - proAJGOponente  
    /// </summary>
    [JsonPropertyName("ajgoponente")]
    public bool AJGOponente { get; set; }

    /// <summary>
    /// Sem descrição - proValorCacheCalculo  
    /// </summary>
    [JsonPropertyName("valorcachecalculo")]
    public decimal ValorCacheCalculo { get; set; }

    /// <summary>
    /// Sem descrição - proAJGPedidoOPO  
    /// </summary>
    [JsonPropertyName("ajgpedidoopo")]
    public bool AJGPedidoOPO { get; set; }

    /// <summary>
    /// Sem descrição - proValorCacheCalculoProv  
    /// </summary>
    [JsonPropertyName("valorcachecalculoprov")]
    public decimal ValorCacheCalculoProv { get; set; }

    /// <summary>
    /// Sem descrição - proConsiderarParado  
    /// </summary>
    [JsonPropertyName("considerarparado")]
    public bool ConsiderarParado { get; set; }

    /// <summary>
    /// Sem descrição - proValorCalculado  
    /// </summary>
    [JsonPropertyName("valorcalculado")]
    public bool ValorCalculado { get; set; }

    /// <summary>
    /// Sem descrição - proAJGConcedidoOPO  
    /// </summary>
    [JsonPropertyName("ajgconcedidoopo")]
    public bool AJGConcedidoOPO { get; set; }

    /// <summary>
    /// Sem descrição - proCobranca  
    /// </summary>
    [JsonPropertyName("cobranca")]
    public bool Cobranca { get; set; }

    /// <summary>
    /// Sem descrição - proDataEntrada  
    /// </summary>
    [JsonPropertyName("dataentrada")]
    public string DataEntrada { get; set; } = "";

    /// <summary>
    /// Sem descrição - proPenhora  
    /// </summary>
    [JsonPropertyName("penhora")]
    public bool Penhora { get; set; }

    /// <summary>
    /// Sem descrição - proAJGPedido  
    /// </summary>
    [JsonPropertyName("ajgpedido")]
    public bool AJGPedido { get; set; }

    /// <summary>
    /// Sem descrição - proTipoBaixa  
    /// </summary>
    [JsonPropertyName("tipobaixa")]
    public int TipoBaixa { get; set; }

    /// <summary>
    /// Sem descrição - proClassRisco  
    /// </summary>
    [JsonPropertyName("classrisco")]
    public int ClassRisco { get; set; }

    /// <summary>
    /// Sem descrição - proIsApenso  
    /// </summary>
    [JsonPropertyName("isapenso")]
    public bool IsApenso { get; set; }

    /// <summary>
    /// Sem descrição - proValorCausaInicial  
    /// </summary>
    [JsonPropertyName("valorcausainicial")]
    public decimal ValorCausaInicial { get; set; }

    /// <summary>
    /// Sem descrição - proAJGConcedido  
    /// </summary>
    [JsonPropertyName("ajgconcedido")]
    public bool AJGConcedido { get; set; }

    /// <summary>
    /// Sem descrição - proObsBCX  
    /// </summary>
    [JsonPropertyName("obsbcx")]
    public string ObsBCX { get; set; } = "";

    /// <summary>
    /// Sem descrição - proValorCausaDefinitivo  
    /// </summary>
    [JsonPropertyName("valorcausadefinitivo")]
    public decimal ValorCausaDefinitivo { get; set; }

    /// <summary>
    /// Sem descrição - proPercProbExito  
    /// </summary>
    [JsonPropertyName("percprobexito")]
    public decimal PercProbExito { get; set; }

    /// <summary>
    /// Sem descrição - proMNA  
    /// </summary>
    [JsonPropertyName("mna")]
    public bool MNA { get; set; }

    /// <summary>
    /// Sem descrição - proPercExito  
    /// </summary>
    [JsonPropertyName("percexito")]
    public decimal PercExito { get; set; }

    /// <summary>
    /// Sem descrição - proNroExtra - tamanho máximo: 35 
    /// </summary>
    [JsonPropertyName("nroextra")]
    public string NroExtra { get; set; } = "";

    /// <summary>
    /// Sem descrição - proExtra  
    /// </summary>
    [JsonPropertyName("extra")]
    public bool Extra { get; set; }

    /// <summary>
    /// Sem descrição - proNroCaixa - tamanho máximo: 20 
    /// </summary>
    [JsonPropertyName("nrocaixa")]
    public string NroCaixa { get; set; } = "";

    /// <summary>
    /// Sem descrição - proIDSituacao  
    /// </summary>
    [JsonPropertyName("idsituacao")]
    public bool IDSituacao { get; set; }

    /// <summary>
    /// Sem descrição - proValor  
    /// </summary>
    [JsonPropertyName("valor")]
    public decimal Valor { get; set; }

    /// <summary>
    /// Sem descrição - proFato  
    /// </summary>
    [JsonPropertyName("fato")]
    public string Fato { get; set; } = "";

    /// <summary>
    /// Sem descrição - proNroPasta - tamanho máximo: 10 
    /// </summary>
    [JsonPropertyName("nropasta")]
    public string NroPasta { get; set; } = "";

    /// <summary>
    /// Sem descrição - proCaixaMorto - tamanho máximo: 10 
    /// </summary>
    [JsonPropertyName("caixamorto")]
    public string CaixaMorto { get; set; } = "";

    /// <summary>
    /// Sem descrição - proBaixado  
    /// </summary>
    [JsonPropertyName("baixado")]
    public bool Baixado { get; set; }

    /// <summary>
    /// Sem descrição - proDtBaixa  
    /// </summary>
    [JsonPropertyName("dtbaixa")]
    public string DtBaixa { get; set; } = "";

    /// <summary>
    /// Sem descrição - proMotivoBaixa  
    /// </summary>
    [JsonPropertyName("motivobaixa")]
    public string MotivoBaixa { get; set; } = "";

    /// <summary>
    /// Sem descrição - proOBS  
    /// </summary>
    [JsonPropertyName("obs")]
    public string OBS { get; set; } = "";

    /// <summary>
    /// Sem descrição - proPrinted  
    /// </summary>
    [JsonPropertyName("printed")]
    public bool Printed { get; set; }

    /// <summary>
    /// Sem descrição - proZKey - tamanho máximo: 20 
    /// </summary>
    [JsonPropertyName("zkey")]
    public string ZKey { get; set; } = "";

    /// <summary>
    /// Sem descrição - proZKeyQuem  
    /// </summary>
    [JsonPropertyName("zkeyquem")]
    public int ZKeyQuem { get; set; }

    /// <summary>
    /// Sem descrição - proZKeyQuando  
    /// </summary>
    [JsonPropertyName("zkeyquando")]
    public string ZKeyQuando { get; set; } = "";

    /// <summary>
    /// Sem descrição - proResumo  
    /// </summary>
    [JsonPropertyName("resumo")]
    public string Resumo { get; set; } = "";

    /// <summary>
    /// Sem descrição - proNaoImprimir  
    /// </summary>
    [JsonPropertyName("naoimprimir")]
    public bool NaoImprimir { get; set; }

    /// <summary>
    /// Sem descrição - proEletronico  
    /// </summary>
    [JsonPropertyName("eletronico")]
    public bool Eletronico { get; set; }

    /// <summary>
    /// Sem descrição - proNroContrato - tamanho máximo: 100 
    /// </summary>
    [JsonPropertyName("nrocontrato")]
    public string NroContrato { get; set; } = "";

    /// <summary>
    /// Sem descrição - proPercProbExitoJustificativa - tamanho máximo: 1024 
    /// </summary>
    [JsonPropertyName("percprobexitojustificativa")]
    public string PercProbExitoJustificativa { get; set; } = "";

    /// <summary>
    /// Sem descrição - proHonorarioValor  
    /// </summary>
    [JsonPropertyName("honorariovalor")]
    public decimal HonorarioValor { get; set; }

    /// <summary>
    /// Sem descrição - proHonorarioPercentual  
    /// </summary>
    [JsonPropertyName("honorariopercentual")]
    public decimal HonorarioPercentual { get; set; }

    /// <summary>
    /// Sem descrição - proHonorarioSucumbencia  
    /// </summary>
    [JsonPropertyName("honorariosucumbencia")]
    public decimal HonorarioSucumbencia { get; set; }

    /// <summary>
    /// Sem descrição - proFaseAuditoria  
    /// </summary>
    [JsonPropertyName("faseauditoria")]
    public int FaseAuditoria { get; set; }

    /// <summary>
    /// Sem descrição - proValorCondenacao  
    /// </summary>
    [JsonPropertyName("valorcondenacao")]
    public decimal ValorCondenacao { get; set; }

    /// <summary>
    /// Sem descrição - proValorCondenacaoCalculado  
    /// </summary>
    [JsonPropertyName("valorcondenacaocalculado")]
    public decimal ValorCondenacaoCalculado { get; set; }

    /// <summary>
    /// Sem descrição - proValorCondenacaoProvisorio  
    /// </summary>
    [JsonPropertyName("valorcondenacaoprovisorio")]
    public int ValorCondenacaoProvisorio { get; set; }

    /// <summary>
    /// GUId - proGUID - tamanho máximo: 120 
    /// </summary>
    [JsonPropertyName("guid")]
    public string GUID { get; set; } = "";

    [JsonPropertyName("nomeprepostos")]
    public string NomePrepostos { get; set; } = string.Empty;

    [JsonPropertyName("nomeadvogados")]
    public string NomeAdvogados { get; set; } = string.Empty;

    [JsonPropertyName("nomeadvogados")]
    public string NomeAdvogados { get; set; } = string.Empty;

    [JsonPropertyName("nomeclientes")]
    public string NomeClientes { get; set; } = string.Empty;

    [JsonPropertyName("nomejustica")]
    public string NomeJustica { get; set; } = string.Empty;

    [JsonPropertyName("nomeoponentes")]
    public string NomeOponentes { get; set; } = string.Empty;

    [JsonPropertyName("descricaoarea")]
    public string DescricaoArea { get; set; } = string.Empty;

    [JsonPropertyName("nomecidade")]
    public string NomeCidade { get; set; } = string.Empty;

    [JsonPropertyName("descricaorito")]
    public string DescricaoRito { get; set; } = string.Empty;

    [JsonPropertyName("descricaoatividades")]
    public string DescricaoAtividades { get; set; } = string.Empty;
}