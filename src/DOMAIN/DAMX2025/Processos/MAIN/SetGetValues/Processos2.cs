namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBProcessos
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBProcessosDicInfo.AdvParc:
                FAdvParc = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProcessosDicInfo.AJGPedidoNegado:
                FAJGPedidoNegado = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBProcessosDicInfo.AJGCliente:
                FAJGCliente = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBProcessosDicInfo.AJGPedidoNegadoOPO:
                FAJGPedidoNegadoOPO = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBProcessosDicInfo.NotificarPOE:
                FNotificarPOE = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBProcessosDicInfo.ValorProvisionado:
                FValorProvisionado = Convert.ToDecimal(value); // rgo J3: decimal
                return;
            case DBProcessosDicInfo.AJGOponente:
                FAJGOponente = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBProcessosDicInfo.ValorCacheCalculo:
                FValorCacheCalculo = Convert.ToDecimal(value); // rgo J3: decimal
                return;
            case DBProcessosDicInfo.AJGPedidoOPO:
                FAJGPedidoOPO = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBProcessosDicInfo.ValorCacheCalculoProv:
                FValorCacheCalculoProv = Convert.ToDecimal(value); // rgo J3: decimal
                return;
            case DBProcessosDicInfo.ConsiderarParado:
                FConsiderarParado = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBProcessosDicInfo.ValorCalculado:
                FValorCalculado = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBProcessosDicInfo.AJGConcedidoOPO:
                FAJGConcedidoOPO = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBProcessosDicInfo.Cobranca:
                FCobranca = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBProcessosDicInfo.DataEntrada:
                FDataEntrada = $"{value}"; // rgo J3: DateTime
                return;
            case DBProcessosDicInfo.Penhora:
                FPenhora = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBProcessosDicInfo.AJGPedido:
                FAJGPedido = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBProcessosDicInfo.TipoBaixa:
                FTipoBaixa = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProcessosDicInfo.ClassRisco:
                FClassRisco = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProcessosDicInfo.IsApenso:
                FIsApenso = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBProcessosDicInfo.ValorCausaInicial:
                FValorCausaInicial = Convert.ToDecimal(value); // rgo J3: decimal
                return;
            case DBProcessosDicInfo.AJGConcedido:
                FAJGConcedido = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBProcessosDicInfo.ObsBCX:
                FObsBCX = $"{value}"; // rgo J3: string
                return;
            case DBProcessosDicInfo.ValorCausaDefinitivo:
                FValorCausaDefinitivo = Convert.ToDecimal(value); // rgo J3: decimal
                return;
            case DBProcessosDicInfo.PercProbExito:
                FPercProbExito = Convert.ToDecimal(value); // rgo J3: decimal
                return;
            case DBProcessosDicInfo.MNA:
                FMNA = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBProcessosDicInfo.PercExito:
                FPercExito = Convert.ToDecimal(value); // rgo J3: decimal
                return;
            case DBProcessosDicInfo.NroExtra:
                FNroExtra = $"{value}"; // rgo J3: string
                return;
            case DBProcessosDicInfo.AdvOpo:
                FAdvOpo = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProcessosDicInfo.Extra:
                FExtra = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBProcessosDicInfo.Justica:
                FJustica = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProcessosDicInfo.Advogado:
                FAdvogado = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProcessosDicInfo.NroCaixa:
                FNroCaixa = $"{value}"; // rgo J3: string
                return;
            case DBProcessosDicInfo.Preposto:
                FPreposto = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProcessosDicInfo.Cliente:
                FCliente = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProcessosDicInfo.Oponente:
                FOponente = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProcessosDicInfo.Area:
                FArea = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProcessosDicInfo.Cidade:
                FCidade = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProcessosDicInfo.Situacao:
                FSituacao = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProcessosDicInfo.IDSituacao:
                FIDSituacao = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBProcessosDicInfo.Valor:
                FValor = Convert.ToDecimal(value); // rgo J3: decimal
                return;
            case DBProcessosDicInfo.Rito:
                FRito = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProcessosDicInfo.Fato:
                FFato = $"{value}"; // rgo J3: string
                return;
            case DBProcessosDicInfo.NroPasta:
                FNroPasta = $"{value}"; // rgo J3: string
                return;
            case DBProcessosDicInfo.Atividade:
                FAtividade = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProcessosDicInfo.CaixaMorto:
                FCaixaMorto = $"{value}"; // rgo J3: string
                return;
            case DBProcessosDicInfo.Baixado:
                FBaixado = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBProcessosDicInfo.DtBaixa:
                FDtBaixa = $"{value}"; // rgo J3: DateTime
                return;
            case DBProcessosDicInfo.MotivoBaixa:
                FMotivoBaixa = $"{value}"; // rgo J3: string
                return;
            case DBProcessosDicInfo.OBS:
                FOBS = $"{value}"; // rgo J3: string
                return;
            case DBProcessosDicInfo.Printed:
                FPrinted = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBProcessosDicInfo.ZKey:
                FZKey = $"{value}"; // rgo J3: string
                return;
            case DBProcessosDicInfo.ZKeyQuem:
                FZKeyQuem = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProcessosDicInfo.ZKeyQuando:
                FZKeyQuando = $"{value}"; // rgo J3: DateTime
                return;
            case DBProcessosDicInfo.Resumo:
                FResumo = $"{value}"; // rgo J3: string
                return;
            case DBProcessosDicInfo.NaoImprimir:
                FNaoImprimir = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBProcessosDicInfo.Eletronico:
                FEletronico = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBProcessosDicInfo.NroContrato:
                FNroContrato = $"{value}"; // rgo J3: string
                return;
            case DBProcessosDicInfo.PercProbExitoJustificativa:
                FPercProbExitoJustificativa = $"{value}"; // rgo J3: string
                return;
            case DBProcessosDicInfo.HonorarioValor:
                FHonorarioValor = Convert.ToDecimal(value); // rgo J3: decimal
                return;
            case DBProcessosDicInfo.HonorarioPercentual:
                FHonorarioPercentual = Convert.ToDecimal(value); // rgo J3: decimal
                return;
            case DBProcessosDicInfo.HonorarioSucumbencia:
                FHonorarioSucumbencia = Convert.ToDecimal(value); // rgo J3: decimal
                return;
            case DBProcessosDicInfo.FaseAuditoria:
                FFaseAuditoria = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProcessosDicInfo.ValorCondenacao:
                FValorCondenacao = Convert.ToDecimal(value); // rgo J3: decimal
                return;
            case DBProcessosDicInfo.ValorCondenacaoCalculado:
                FValorCondenacaoCalculado = Convert.ToDecimal(value); // rgo J3: decimal
                return;
            case DBProcessosDicInfo.ValorCondenacaoProvisorio:
                FValorCondenacaoProvisorio = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProcessosDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBProcessosDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProcessosDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBProcessosDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProcessosDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBProcessosDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBProcessosDicInfo.AdvParc => NFAdvParc(),
        DBProcessosDicInfo.AJGPedidoNegado => FAJGPedidoNegado.ToString(),
        DBProcessosDicInfo.AJGCliente => FAJGCliente.ToString(),
        DBProcessosDicInfo.AJGPedidoNegadoOPO => FAJGPedidoNegadoOPO.ToString(),
        DBProcessosDicInfo.NotificarPOE => FNotificarPOE.ToString(),
        DBProcessosDicInfo.ValorProvisionado => NFValorProvisionado(),
        DBProcessosDicInfo.AJGOponente => FAJGOponente.ToString(),
        DBProcessosDicInfo.ValorCacheCalculo => NFValorCacheCalculo(),
        DBProcessosDicInfo.AJGPedidoOPO => FAJGPedidoOPO.ToString(),
        DBProcessosDicInfo.ValorCacheCalculoProv => NFValorCacheCalculoProv(),
        DBProcessosDicInfo.ConsiderarParado => FConsiderarParado.ToString(),
        DBProcessosDicInfo.ValorCalculado => FValorCalculado.ToString(),
        DBProcessosDicInfo.AJGConcedidoOPO => FAJGConcedidoOPO.ToString(),
        DBProcessosDicInfo.Cobranca => FCobranca.ToString(),
        DBProcessosDicInfo.DataEntrada => NFDataEntrada(),
        DBProcessosDicInfo.Penhora => FPenhora.ToString(),
        DBProcessosDicInfo.AJGPedido => FAJGPedido.ToString(),
        DBProcessosDicInfo.TipoBaixa => NFTipoBaixa(),
        DBProcessosDicInfo.ClassRisco => NFClassRisco(),
        DBProcessosDicInfo.IsApenso => FIsApenso.ToString(),
        DBProcessosDicInfo.ValorCausaInicial => NFValorCausaInicial(),
        DBProcessosDicInfo.AJGConcedido => FAJGConcedido.ToString(),
        DBProcessosDicInfo.ObsBCX => NFObsBCX(),
        DBProcessosDicInfo.ValorCausaDefinitivo => NFValorCausaDefinitivo(),
        DBProcessosDicInfo.PercProbExito => NFPercProbExito(),
        DBProcessosDicInfo.MNA => FMNA.ToString(),
        DBProcessosDicInfo.PercExito => NFPercExito(),
        DBProcessosDicInfo.NroExtra => NFNroExtra(),
        DBProcessosDicInfo.AdvOpo => NFAdvOpo(),
        DBProcessosDicInfo.Extra => FExtra.ToString(),
        DBProcessosDicInfo.Justica => NFJustica(),
        DBProcessosDicInfo.Advogado => NFAdvogado(),
        DBProcessosDicInfo.NroCaixa => NFNroCaixa(),
        DBProcessosDicInfo.Preposto => NFPreposto(),
        DBProcessosDicInfo.Cliente => NFCliente(),
        DBProcessosDicInfo.Oponente => NFOponente(),
        DBProcessosDicInfo.Area => NFArea(),
        DBProcessosDicInfo.Cidade => NFCidade(),
        DBProcessosDicInfo.Situacao => NFSituacao(),
        DBProcessosDicInfo.IDSituacao => FIDSituacao.ToString(),
        DBProcessosDicInfo.Valor => NFValor(),
        DBProcessosDicInfo.Rito => NFRito(),
        DBProcessosDicInfo.Fato => NFFato(),
        DBProcessosDicInfo.NroPasta => NFNroPasta(),
        DBProcessosDicInfo.Atividade => NFAtividade(),
        DBProcessosDicInfo.CaixaMorto => NFCaixaMorto(),
        DBProcessosDicInfo.Baixado => FBaixado.ToString(),
        DBProcessosDicInfo.DtBaixa => NFDtBaixa(),
        DBProcessosDicInfo.MotivoBaixa => NFMotivoBaixa(),
        DBProcessosDicInfo.OBS => NFOBS(),
        DBProcessosDicInfo.Printed => FPrinted.ToString(),
        DBProcessosDicInfo.ZKey => NFZKey(),
        DBProcessosDicInfo.ZKeyQuem => NFZKeyQuem(),
        DBProcessosDicInfo.ZKeyQuando => NFZKeyQuando(),
        DBProcessosDicInfo.Resumo => NFResumo(),
        DBProcessosDicInfo.NaoImprimir => FNaoImprimir.ToString(),
        DBProcessosDicInfo.Eletronico => FEletronico.ToString(),
        DBProcessosDicInfo.NroContrato => NFNroContrato(),
        DBProcessosDicInfo.PercProbExitoJustificativa => NFPercProbExitoJustificativa(),
        DBProcessosDicInfo.HonorarioValor => NFHonorarioValor(),
        DBProcessosDicInfo.HonorarioPercentual => NFHonorarioPercentual(),
        DBProcessosDicInfo.HonorarioSucumbencia => NFHonorarioSucumbencia(),
        DBProcessosDicInfo.FaseAuditoria => NFFaseAuditoria(),
        DBProcessosDicInfo.ValorCondenacao => NFValorCondenacao(),
        DBProcessosDicInfo.ValorCondenacaoCalculado => NFValorCondenacaoCalculado(),
        DBProcessosDicInfo.ValorCondenacaoProvisorio => NFValorCondenacaoProvisorio(),
        DBProcessosDicInfo.GUID => NFGUID(),
        DBProcessosDicInfo.QuemCad => NFQuemCad(),
        DBProcessosDicInfo.DtCad => MDtCad,
        DBProcessosDicInfo.QuemAtu => NFQuemAtu(),
        DBProcessosDicInfo.DtAtu => MDtAtu,
        DBProcessosDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}