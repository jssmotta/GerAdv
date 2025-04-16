#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProcessosReader
{
    ProcessosResponse? Read(int id, SqlConnection oCnn);
    ProcessosResponse? Read(string where, SqlConnection oCnn);
    ProcessosResponse? Read(Entity.DBProcessos dbRec);
    ProcessosResponse? Read(DBProcessos dbRec);
}

public partial class Processos : IProcessosReader
{
    public ProcessosResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProcessos(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProcessosResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProcessos(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProcessosResponse? Read(Entity.DBProcessos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var processos = new ProcessosResponse
        {
            Id = dbRec.ID,
            AdvParc = dbRec.FAdvParc,
            AJGPedidoNegado = dbRec.FAJGPedidoNegado,
            AJGCliente = dbRec.FAJGCliente,
            AJGPedidoNegadoOPO = dbRec.FAJGPedidoNegadoOPO,
            NotificarPOE = dbRec.FNotificarPOE,
            ValorProvisionado = dbRec.FValorProvisionado,
            AJGOponente = dbRec.FAJGOponente,
            ValorCacheCalculo = dbRec.FValorCacheCalculo,
            AJGPedidoOPO = dbRec.FAJGPedidoOPO,
            ValorCacheCalculoProv = dbRec.FValorCacheCalculoProv,
            ConsiderarParado = dbRec.FConsiderarParado,
            ValorCalculado = dbRec.FValorCalculado,
            AJGConcedidoOPO = dbRec.FAJGConcedidoOPO,
            Cobranca = dbRec.FCobranca,
            Penhora = dbRec.FPenhora,
            AJGPedido = dbRec.FAJGPedido,
            TipoBaixa = dbRec.FTipoBaixa,
            ClassRisco = dbRec.FClassRisco,
            IsApenso = dbRec.FIsApenso,
            ValorCausaInicial = dbRec.FValorCausaInicial,
            AJGConcedido = dbRec.FAJGConcedido,
            ObsBCX = dbRec.FObsBCX ?? string.Empty,
            ValorCausaDefinitivo = dbRec.FValorCausaDefinitivo,
            PercProbExito = dbRec.FPercProbExito,
            MNA = dbRec.FMNA,
            PercExito = dbRec.FPercExito,
            NroExtra = dbRec.FNroExtra ?? string.Empty,
            AdvOpo = dbRec.FAdvOpo,
            Extra = dbRec.FExtra,
            Justica = dbRec.FJustica,
            Advogado = dbRec.FAdvogado,
            NroCaixa = dbRec.FNroCaixa ?? string.Empty,
            Preposto = dbRec.FPreposto,
            Cliente = dbRec.FCliente,
            Oponente = dbRec.FOponente,
            Area = dbRec.FArea,
            Cidade = dbRec.FCidade,
            Situacao = dbRec.FSituacao,
            IDSituacao = dbRec.FIDSituacao,
            Valor = dbRec.FValor,
            Rito = dbRec.FRito,
            Fato = dbRec.FFato ?? string.Empty,
            NroPasta = dbRec.FNroPasta ?? string.Empty,
            Atividade = dbRec.FAtividade,
            CaixaMorto = dbRec.FCaixaMorto ?? string.Empty,
            Baixado = dbRec.FBaixado,
            MotivoBaixa = dbRec.FMotivoBaixa ?? string.Empty,
            OBS = dbRec.FOBS ?? string.Empty,
            Printed = dbRec.FPrinted,
            ZKey = dbRec.FZKey ?? string.Empty,
            ZKeyQuem = dbRec.FZKeyQuem,
            Resumo = dbRec.FResumo ?? string.Empty,
            NaoImprimir = dbRec.FNaoImprimir,
            Eletronico = dbRec.FEletronico,
            NroContrato = dbRec.FNroContrato ?? string.Empty,
            PercProbExitoJustificativa = dbRec.FPercProbExitoJustificativa ?? string.Empty,
            HonorarioValor = dbRec.FHonorarioValor,
            HonorarioPercentual = dbRec.FHonorarioPercentual,
            HonorarioSucumbencia = dbRec.FHonorarioSucumbencia,
            FaseAuditoria = dbRec.FFaseAuditoria,
            ValorCondenacao = dbRec.FValorCondenacao,
            ValorCondenacaoCalculado = dbRec.FValorCondenacaoCalculado,
            ValorCondenacaoProvisorio = dbRec.FValorCondenacaoProvisorio,
            Guid = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataEntrada, out _))
            processos.DataEntrada = dbRec.FDataEntrada;
        if (DateTime.TryParse(dbRec.FDtBaixa, out _))
            processos.DtBaixa = dbRec.FDtBaixa;
        if (DateTime.TryParse(dbRec.FZKeyQuando, out _))
            processos.ZKeyQuando = dbRec.FZKeyQuando;
        var auditor = new Auditor
        {
            Visto = dbRec.FVisto,
            QuemCad = dbRec.FQuemCad
        };
        if (auditor.QuemAtu > 0)
            auditor.QuemAtu = dbRec.FQuemAtu;
        if (dbRec.FDtCad.NotIsEmpty())
            auditor.DtCad = Convert.ToDateTime(dbRec.FDtCad);
        if (!(dbRec.FDtAtu is { }))
            auditor.DtAtu = Convert.ToDateTime(dbRec.FDtAtu);
        processos.Auditor = auditor;
        return processos;
    }

    public ProcessosResponse? Read(DBProcessos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var processos = new ProcessosResponse
        {
            Id = dbRec.ID,
            AdvParc = dbRec.FAdvParc,
            AJGPedidoNegado = dbRec.FAJGPedidoNegado,
            AJGCliente = dbRec.FAJGCliente,
            AJGPedidoNegadoOPO = dbRec.FAJGPedidoNegadoOPO,
            NotificarPOE = dbRec.FNotificarPOE,
            ValorProvisionado = dbRec.FValorProvisionado,
            AJGOponente = dbRec.FAJGOponente,
            ValorCacheCalculo = dbRec.FValorCacheCalculo,
            AJGPedidoOPO = dbRec.FAJGPedidoOPO,
            ValorCacheCalculoProv = dbRec.FValorCacheCalculoProv,
            ConsiderarParado = dbRec.FConsiderarParado,
            ValorCalculado = dbRec.FValorCalculado,
            AJGConcedidoOPO = dbRec.FAJGConcedidoOPO,
            Cobranca = dbRec.FCobranca,
            Penhora = dbRec.FPenhora,
            AJGPedido = dbRec.FAJGPedido,
            TipoBaixa = dbRec.FTipoBaixa,
            ClassRisco = dbRec.FClassRisco,
            IsApenso = dbRec.FIsApenso,
            ValorCausaInicial = dbRec.FValorCausaInicial,
            AJGConcedido = dbRec.FAJGConcedido,
            ObsBCX = dbRec.FObsBCX ?? string.Empty,
            ValorCausaDefinitivo = dbRec.FValorCausaDefinitivo,
            PercProbExito = dbRec.FPercProbExito,
            MNA = dbRec.FMNA,
            PercExito = dbRec.FPercExito,
            NroExtra = dbRec.FNroExtra ?? string.Empty,
            AdvOpo = dbRec.FAdvOpo,
            Extra = dbRec.FExtra,
            Justica = dbRec.FJustica,
            Advogado = dbRec.FAdvogado,
            NroCaixa = dbRec.FNroCaixa ?? string.Empty,
            Preposto = dbRec.FPreposto,
            Cliente = dbRec.FCliente,
            Oponente = dbRec.FOponente,
            Area = dbRec.FArea,
            Cidade = dbRec.FCidade,
            Situacao = dbRec.FSituacao,
            IDSituacao = dbRec.FIDSituacao,
            Valor = dbRec.FValor,
            Rito = dbRec.FRito,
            Fato = dbRec.FFato ?? string.Empty,
            NroPasta = dbRec.FNroPasta ?? string.Empty,
            Atividade = dbRec.FAtividade,
            CaixaMorto = dbRec.FCaixaMorto ?? string.Empty,
            Baixado = dbRec.FBaixado,
            MotivoBaixa = dbRec.FMotivoBaixa ?? string.Empty,
            OBS = dbRec.FOBS ?? string.Empty,
            Printed = dbRec.FPrinted,
            ZKey = dbRec.FZKey ?? string.Empty,
            ZKeyQuem = dbRec.FZKeyQuem,
            Resumo = dbRec.FResumo ?? string.Empty,
            NaoImprimir = dbRec.FNaoImprimir,
            Eletronico = dbRec.FEletronico,
            NroContrato = dbRec.FNroContrato ?? string.Empty,
            PercProbExitoJustificativa = dbRec.FPercProbExitoJustificativa ?? string.Empty,
            HonorarioValor = dbRec.FHonorarioValor,
            HonorarioPercentual = dbRec.FHonorarioPercentual,
            HonorarioSucumbencia = dbRec.FHonorarioSucumbencia,
            FaseAuditoria = dbRec.FFaseAuditoria,
            ValorCondenacao = dbRec.FValorCondenacao,
            ValorCondenacaoCalculado = dbRec.FValorCondenacaoCalculado,
            ValorCondenacaoProvisorio = dbRec.FValorCondenacaoProvisorio,
            Guid = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataEntrada, out _))
            processos.DataEntrada = dbRec.FDataEntrada;
        if (DateTime.TryParse(dbRec.FDtBaixa, out _))
            processos.DtBaixa = dbRec.FDtBaixa;
        if (DateTime.TryParse(dbRec.FZKeyQuando, out _))
            processos.ZKeyQuando = dbRec.FZKeyQuando;
        var auditor = new Auditor
        {
            Visto = dbRec.FVisto,
            QuemCad = dbRec.FQuemCad
        };
        if (auditor.QuemAtu > 0)
            auditor.QuemAtu = dbRec.FQuemAtu;
        if (dbRec.FDtCad.NotIsEmpty())
            auditor.DtCad = Convert.ToDateTime(dbRec.FDtCad);
        if (!(dbRec.FDtAtu is { }))
            auditor.DtAtu = Convert.ToDateTime(dbRec.FDtAtu);
        processos.Auditor = auditor;
        return processos;
    }
}