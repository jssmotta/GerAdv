#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProcessosReader
{
    ProcessosResponse? Read(int id, MsiSqlConnection oCnn);
    ProcessosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ProcessosResponse? Read(Entity.DBProcessos dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ProcessosResponse? Read(DBProcessos dbRec);
    ProcessosResponseAll? ReadAll(DBProcessos dbRec, DataRow dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class Processos : IProcessosReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery(cWhere, order), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    static string BuildSqlQuery(string whereClause, string orderClause, int max = 200, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) proCodigo, proNroPasta FROM {"Processos".dbo(oCnn)} (NOLOCK) ");
        if (!string.IsNullOrEmpty(whereClause))
        {
            query.Append(!whereClause.ToUpperInvariant().Contains(TSql.Where, StringComparison.OrdinalIgnoreCase) ? TSql.Where : string.Empty).Append(whereClause);
        }

        if (!string.IsNullOrEmpty(orderClause))
        {
            query.Append(!orderClause.ToUpperInvariant().Contains(TSql.OrderBy, StringComparison.OrdinalIgnoreCase) ? TSql.OrderBy : string.Empty).Append(orderClause);
        }
        else
        {
            query.Append($"{TSql.OrderBy}proNroPasta");
        }

        return query.ToString();
    }

    public ProcessosResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProcessos(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProcessosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProcessos(sqlWhere: where, parameters: parameters, oCnn: oCnn);
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
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataEntrada, out _))
            processos.DataEntrada = dbRec.FDataEntrada;
        if (DateTime.TryParse(dbRec.FDtBaixa, out _))
            processos.DtBaixa = dbRec.FDtBaixa;
        if (DateTime.TryParse(dbRec.FZKeyQuando, out _))
            processos.ZKeyQuando = dbRec.FZKeyQuando;
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
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataEntrada, out _))
            processos.DataEntrada = dbRec.FDataEntrada;
        if (DateTime.TryParse(dbRec.FDtBaixa, out _))
            processos.DtBaixa = dbRec.FDtBaixa;
        if (DateTime.TryParse(dbRec.FZKeyQuando, out _))
            processos.ZKeyQuando = dbRec.FZKeyQuando;
        return processos;
    }

    public ProcessosResponseAll? ReadAll(DBProcessos dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var processos = new ProcessosResponseAll
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
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataEntrada, out _))
            processos.DataEntrada = dbRec.FDataEntrada;
        if (DateTime.TryParse(dbRec.FDtBaixa, out _))
            processos.DtBaixa = dbRec.FDtBaixa;
        if (DateTime.TryParse(dbRec.FZKeyQuando, out _))
            processos.ZKeyQuando = dbRec.FZKeyQuando;
        processos.NomeAdvogados = dr["advNome"]?.ToString() ?? string.Empty;
        processos.NomeJustica = dr["jusNome"]?.ToString() ?? string.Empty;
        processos.NomeAdvogados = dr["advNome"]?.ToString() ?? string.Empty;
        processos.NomePrepostos = dr["preNome"]?.ToString() ?? string.Empty;
        processos.NomeClientes = dr["cliNome"]?.ToString() ?? string.Empty;
        processos.NomeOponentes = dr["opoNome"]?.ToString() ?? string.Empty;
        processos.DescricaoArea = dr["areDescricao"]?.ToString() ?? string.Empty;
        processos.NomeCidade = dr["cidNome"]?.ToString() ?? string.Empty;
        processos.DescricaoRito = dr["ritDescricao"]?.ToString() ?? string.Empty;
        processos.DescricaoAtividades = dr["atvDescricao"]?.ToString() ?? string.Empty;
        return processos;
    }
}