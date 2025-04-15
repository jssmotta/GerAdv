#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProcessosWriter
{
    Entity.DBProcessos Write(Models.Processos processos, int auditorQuem, SqlConnection oCnn);
}

public class Processos : IProcessosWriter
{
    public Entity.DBProcessos Write(Models.Processos processos, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = processos.Id.IsEmptyIDNumber() ? new Entity.DBProcessos() : new Entity.DBProcessos(processos.Id, oCnn);
        dbRec.FAdvParc = processos.AdvParc;
        dbRec.FAJGPedidoNegado = processos.AJGPedidoNegado;
        dbRec.FAJGCliente = processos.AJGCliente;
        dbRec.FAJGPedidoNegadoOPO = processos.AJGPedidoNegadoOPO;
        dbRec.FNotificarPOE = processos.NotificarPOE;
        dbRec.FValorProvisionado = processos.ValorProvisionado;
        dbRec.FAJGOponente = processos.AJGOponente;
        dbRec.FValorCacheCalculo = processos.ValorCacheCalculo;
        dbRec.FAJGPedidoOPO = processos.AJGPedidoOPO;
        dbRec.FValorCacheCalculoProv = processos.ValorCacheCalculoProv;
        dbRec.FConsiderarParado = processos.ConsiderarParado;
        dbRec.FValorCalculado = processos.ValorCalculado;
        dbRec.FAJGConcedidoOPO = processos.AJGConcedidoOPO;
        dbRec.FCobranca = processos.Cobranca;
        if (processos.DataEntrada != null)
            dbRec.FDataEntrada = processos.DataEntrada.ToString();
        dbRec.FPenhora = processos.Penhora;
        dbRec.FAJGPedido = processos.AJGPedido;
        dbRec.FTipoBaixa = processos.TipoBaixa;
        dbRec.FClassRisco = processos.ClassRisco;
        dbRec.FIsApenso = processos.IsApenso;
        dbRec.FValorCausaInicial = processos.ValorCausaInicial;
        dbRec.FAJGConcedido = processos.AJGConcedido;
        dbRec.FObsBCX = processos.ObsBCX;
        dbRec.FValorCausaDefinitivo = processos.ValorCausaDefinitivo;
        dbRec.FPercProbExito = processos.PercProbExito;
        dbRec.FMNA = processos.MNA;
        dbRec.FPercExito = processos.PercExito;
        dbRec.FNroExtra = processos.NroExtra;
        dbRec.FAdvOpo = processos.AdvOpo;
        dbRec.FExtra = processos.Extra;
        dbRec.FJustica = processos.Justica;
        dbRec.FAdvogado = processos.Advogado;
        dbRec.FNroCaixa = processos.NroCaixa;
        dbRec.FPreposto = processos.Preposto;
        dbRec.FCliente = processos.Cliente;
        dbRec.FOponente = processos.Oponente;
        dbRec.FArea = processos.Area;
        dbRec.FCidade = processos.Cidade;
        dbRec.FSituacao = processos.Situacao;
        dbRec.FIDSituacao = processos.IDSituacao;
        dbRec.FValor = processos.Valor;
        dbRec.FRito = processos.Rito;
        dbRec.FFato = processos.Fato;
        dbRec.FNroPasta = processos.NroPasta;
        dbRec.FAtividade = processos.Atividade;
        dbRec.FCaixaMorto = processos.CaixaMorto;
        dbRec.FBaixado = processos.Baixado;
        if (processos.DtBaixa != null)
            dbRec.FDtBaixa = processos.DtBaixa.ToString();
        dbRec.FMotivoBaixa = processos.MotivoBaixa;
        dbRec.FOBS = processos.OBS;
        dbRec.FPrinted = processos.Printed;
        dbRec.FZKey = processos.ZKey;
        dbRec.FZKeyQuem = processos.ZKeyQuem;
        if (processos.ZKeyQuando != null)
            dbRec.FZKeyQuando = processos.ZKeyQuando.ToString();
        dbRec.FResumo = processos.Resumo;
        dbRec.FNaoImprimir = processos.NaoImprimir;
        dbRec.FEletronico = processos.Eletronico;
        dbRec.FNroContrato = processos.NroContrato;
        dbRec.FPercProbExitoJustificativa = processos.PercProbExitoJustificativa;
        dbRec.FHonorarioValor = processos.HonorarioValor;
        dbRec.FHonorarioPercentual = processos.HonorarioPercentual;
        dbRec.FHonorarioSucumbencia = processos.HonorarioSucumbencia;
        dbRec.FFaseAuditoria = processos.FaseAuditoria;
        dbRec.FValorCondenacao = processos.ValorCondenacao;
        dbRec.FValorCondenacaoCalculado = processos.ValorCondenacaoCalculado;
        dbRec.FValorCondenacaoProvisorio = processos.ValorCondenacaoProvisorio;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}