namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBProcessos
{
    public DBProcessos(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Advogado]))
                m_FAdvogado = Convert.ToInt32(dbRec[DBProcessosDicInfo.Advogado]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AdvOpo]))
                m_FAdvOpo = Convert.ToInt32(dbRec[DBProcessosDicInfo.AdvOpo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AdvParc]))
                m_FAdvParc = Convert.ToInt32(dbRec[DBProcessosDicInfo.AdvParc]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGCliente]))
                m_FAJGCliente = (bool)dbRec[DBProcessosDicInfo.AJGCliente];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGConcedido]))
                m_FAJGConcedido = (bool)dbRec[DBProcessosDicInfo.AJGConcedido];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGConcedidoOPO]))
                m_FAJGConcedidoOPO = (bool)dbRec[DBProcessosDicInfo.AJGConcedidoOPO];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGOponente]))
                m_FAJGOponente = (bool)dbRec[DBProcessosDicInfo.AJGOponente];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGPedido]))
                m_FAJGPedido = (bool)dbRec[DBProcessosDicInfo.AJGPedido];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGPedidoNegado]))
                m_FAJGPedidoNegado = (bool)dbRec[DBProcessosDicInfo.AJGPedidoNegado];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGPedidoNegadoOPO]))
                m_FAJGPedidoNegadoOPO = (bool)dbRec[DBProcessosDicInfo.AJGPedidoNegadoOPO];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGPedidoOPO]))
                m_FAJGPedidoOPO = (bool)dbRec[DBProcessosDicInfo.AJGPedidoOPO];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Area]))
                m_FArea = Convert.ToInt32(dbRec[DBProcessosDicInfo.Area]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Atividade]))
                m_FAtividade = Convert.ToInt32(dbRec[DBProcessosDicInfo.Atividade]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Baixado]))
                m_FBaixado = (bool)dbRec[DBProcessosDicInfo.Baixado];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Cidade]))
                m_FCidade = Convert.ToInt32(dbRec[DBProcessosDicInfo.Cidade]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ClassRisco]))
                m_FClassRisco = Convert.ToInt32(dbRec[DBProcessosDicInfo.ClassRisco]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Cliente]))
                m_FCliente = Convert.ToInt32(dbRec[DBProcessosDicInfo.Cliente]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Cobranca]))
                m_FCobranca = (bool)dbRec[DBProcessosDicInfo.Cobranca];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ConsiderarParado]))
                m_FConsiderarParado = (bool)dbRec[DBProcessosDicInfo.ConsiderarParado];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.DataEntrada]))
                m_FDataEntrada = Convert.ToDateTime(dbRec[DBProcessosDicInfo.DataEntrada]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBProcessosDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.DtBaixa]))
                m_FDtBaixa = Convert.ToDateTime(dbRec[DBProcessosDicInfo.DtBaixa]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBProcessosDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Eletronico]))
                m_FEletronico = (bool)dbRec[DBProcessosDicInfo.Eletronico];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Extra]))
                m_FExtra = (bool)dbRec[DBProcessosDicInfo.Extra];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.FaseAuditoria]))
                m_FFaseAuditoria = Convert.ToInt32(dbRec[DBProcessosDicInfo.FaseAuditoria]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.HonorarioPercentual]))
                m_FHonorarioPercentual = Convert.ToDecimal(dbRec[DBProcessosDicInfo.HonorarioPercentual]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.HonorarioSucumbencia]))
                m_FHonorarioSucumbencia = Convert.ToDecimal(dbRec[DBProcessosDicInfo.HonorarioSucumbencia]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.HonorarioValor]))
                m_FHonorarioValor = Convert.ToDecimal(dbRec[DBProcessosDicInfo.HonorarioValor]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.IDSituacao]))
                m_FIDSituacao = (bool)dbRec[DBProcessosDicInfo.IDSituacao];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.IsApenso]))
                m_FIsApenso = (bool)dbRec[DBProcessosDicInfo.IsApenso];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Justica]))
                m_FJustica = Convert.ToInt32(dbRec[DBProcessosDicInfo.Justica]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.MNA]))
                m_FMNA = (bool)dbRec[DBProcessosDicInfo.MNA];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.NaoImprimir]))
                m_FNaoImprimir = (bool)dbRec[DBProcessosDicInfo.NaoImprimir];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.NotificarPOE]))
                m_FNotificarPOE = (bool)dbRec[DBProcessosDicInfo.NotificarPOE];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Oponente]))
                m_FOponente = Convert.ToInt32(dbRec[DBProcessosDicInfo.Oponente]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Penhora]))
                m_FPenhora = (bool)dbRec[DBProcessosDicInfo.Penhora];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.PercExito]))
                m_FPercExito = Convert.ToDecimal(dbRec[DBProcessosDicInfo.PercExito]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.PercProbExito]))
                m_FPercProbExito = Convert.ToDecimal(dbRec[DBProcessosDicInfo.PercProbExito]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Preposto]))
                m_FPreposto = Convert.ToInt32(dbRec[DBProcessosDicInfo.Preposto]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Printed]))
                m_FPrinted = (bool)dbRec[DBProcessosDicInfo.Printed];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBProcessosDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBProcessosDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Rito]))
                m_FRito = Convert.ToInt32(dbRec[DBProcessosDicInfo.Rito]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Situacao]))
                m_FSituacao = Convert.ToInt32(dbRec[DBProcessosDicInfo.Situacao]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.TipoBaixa]))
                m_FTipoBaixa = Convert.ToInt32(dbRec[DBProcessosDicInfo.TipoBaixa]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Valor]))
                m_FValor = Convert.ToDecimal(dbRec[DBProcessosDicInfo.Valor]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCacheCalculo]))
                m_FValorCacheCalculo = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCacheCalculo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCacheCalculoProv]))
                m_FValorCacheCalculoProv = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCacheCalculoProv]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCalculado]))
                m_FValorCalculado = (bool)dbRec[DBProcessosDicInfo.ValorCalculado];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCausaDefinitivo]))
                m_FValorCausaDefinitivo = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCausaDefinitivo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCausaInicial]))
                m_FValorCausaInicial = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCausaInicial]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCondenacao]))
                m_FValorCondenacao = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCondenacao]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCondenacaoCalculado]))
                m_FValorCondenacaoCalculado = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCondenacaoCalculado]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCondenacaoProvisorio]))
                m_FValorCondenacaoProvisorio = Convert.ToInt32(dbRec[DBProcessosDicInfo.ValorCondenacaoProvisorio]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorProvisionado]))
                m_FValorProvisionado = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorProvisionado]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBProcessosDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ZKeyQuando]))
                m_FZKeyQuando = Convert.ToDateTime(dbRec[DBProcessosDicInfo.ZKeyQuando]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ZKeyQuem]))
                m_FZKeyQuem = Convert.ToInt32(dbRec[DBProcessosDicInfo.ZKeyQuem]);
        }
        catch
        {
        }

        try
        {
            m_FCaixaMorto = dbRec[DBProcessosDicInfo.CaixaMorto]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFato = dbRec[DBProcessosDicInfo.Fato]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBProcessosDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FMotivoBaixa = dbRec[DBProcessosDicInfo.MotivoBaixa]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNroCaixa = dbRec[DBProcessosDicInfo.NroCaixa]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNroContrato = dbRec[DBProcessosDicInfo.NroContrato]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNroExtra = dbRec[DBProcessosDicInfo.NroExtra]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNroPasta = dbRec[DBProcessosDicInfo.NroPasta]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FOBS = dbRec[DBProcessosDicInfo.OBS]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FObsBCX = dbRec[DBProcessosDicInfo.ObsBCX]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FPercProbExitoJustificativa = dbRec[DBProcessosDicInfo.PercProbExitoJustificativa]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FResumo = dbRec[DBProcessosDicInfo.Resumo]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FZKey = dbRec[DBProcessosDicInfo.ZKey]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBProcessos(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Advogado]))
                m_FAdvogado = Convert.ToInt32(dbRec[DBProcessosDicInfo.Advogado]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AdvOpo]))
                m_FAdvOpo = Convert.ToInt32(dbRec[DBProcessosDicInfo.AdvOpo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AdvParc]))
                m_FAdvParc = Convert.ToInt32(dbRec[DBProcessosDicInfo.AdvParc]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGCliente]))
                m_FAJGCliente = (bool)dbRec[DBProcessosDicInfo.AJGCliente];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGConcedido]))
                m_FAJGConcedido = (bool)dbRec[DBProcessosDicInfo.AJGConcedido];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGConcedidoOPO]))
                m_FAJGConcedidoOPO = (bool)dbRec[DBProcessosDicInfo.AJGConcedidoOPO];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGOponente]))
                m_FAJGOponente = (bool)dbRec[DBProcessosDicInfo.AJGOponente];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGPedido]))
                m_FAJGPedido = (bool)dbRec[DBProcessosDicInfo.AJGPedido];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGPedidoNegado]))
                m_FAJGPedidoNegado = (bool)dbRec[DBProcessosDicInfo.AJGPedidoNegado];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGPedidoNegadoOPO]))
                m_FAJGPedidoNegadoOPO = (bool)dbRec[DBProcessosDicInfo.AJGPedidoNegadoOPO];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGPedidoOPO]))
                m_FAJGPedidoOPO = (bool)dbRec[DBProcessosDicInfo.AJGPedidoOPO];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Area]))
                m_FArea = Convert.ToInt32(dbRec[DBProcessosDicInfo.Area]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Atividade]))
                m_FAtividade = Convert.ToInt32(dbRec[DBProcessosDicInfo.Atividade]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Baixado]))
                m_FBaixado = (bool)dbRec[DBProcessosDicInfo.Baixado];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Cidade]))
                m_FCidade = Convert.ToInt32(dbRec[DBProcessosDicInfo.Cidade]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ClassRisco]))
                m_FClassRisco = Convert.ToInt32(dbRec[DBProcessosDicInfo.ClassRisco]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Cliente]))
                m_FCliente = Convert.ToInt32(dbRec[DBProcessosDicInfo.Cliente]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Cobranca]))
                m_FCobranca = (bool)dbRec[DBProcessosDicInfo.Cobranca];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ConsiderarParado]))
                m_FConsiderarParado = (bool)dbRec[DBProcessosDicInfo.ConsiderarParado];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.DataEntrada]))
                m_FDataEntrada = Convert.ToDateTime(dbRec[DBProcessosDicInfo.DataEntrada]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBProcessosDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.DtBaixa]))
                m_FDtBaixa = Convert.ToDateTime(dbRec[DBProcessosDicInfo.DtBaixa]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBProcessosDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Eletronico]))
                m_FEletronico = (bool)dbRec[DBProcessosDicInfo.Eletronico];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Extra]))
                m_FExtra = (bool)dbRec[DBProcessosDicInfo.Extra];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.FaseAuditoria]))
                m_FFaseAuditoria = Convert.ToInt32(dbRec[DBProcessosDicInfo.FaseAuditoria]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.HonorarioPercentual]))
                m_FHonorarioPercentual = Convert.ToDecimal(dbRec[DBProcessosDicInfo.HonorarioPercentual]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.HonorarioSucumbencia]))
                m_FHonorarioSucumbencia = Convert.ToDecimal(dbRec[DBProcessosDicInfo.HonorarioSucumbencia]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.HonorarioValor]))
                m_FHonorarioValor = Convert.ToDecimal(dbRec[DBProcessosDicInfo.HonorarioValor]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.IDSituacao]))
                m_FIDSituacao = (bool)dbRec[DBProcessosDicInfo.IDSituacao];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.IsApenso]))
                m_FIsApenso = (bool)dbRec[DBProcessosDicInfo.IsApenso];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Justica]))
                m_FJustica = Convert.ToInt32(dbRec[DBProcessosDicInfo.Justica]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.MNA]))
                m_FMNA = (bool)dbRec[DBProcessosDicInfo.MNA];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.NaoImprimir]))
                m_FNaoImprimir = (bool)dbRec[DBProcessosDicInfo.NaoImprimir];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.NotificarPOE]))
                m_FNotificarPOE = (bool)dbRec[DBProcessosDicInfo.NotificarPOE];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Oponente]))
                m_FOponente = Convert.ToInt32(dbRec[DBProcessosDicInfo.Oponente]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Penhora]))
                m_FPenhora = (bool)dbRec[DBProcessosDicInfo.Penhora];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.PercExito]))
                m_FPercExito = Convert.ToDecimal(dbRec[DBProcessosDicInfo.PercExito]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.PercProbExito]))
                m_FPercProbExito = Convert.ToDecimal(dbRec[DBProcessosDicInfo.PercProbExito]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Preposto]))
                m_FPreposto = Convert.ToInt32(dbRec[DBProcessosDicInfo.Preposto]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Printed]))
                m_FPrinted = (bool)dbRec[DBProcessosDicInfo.Printed];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBProcessosDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBProcessosDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Rito]))
                m_FRito = Convert.ToInt32(dbRec[DBProcessosDicInfo.Rito]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Situacao]))
                m_FSituacao = Convert.ToInt32(dbRec[DBProcessosDicInfo.Situacao]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.TipoBaixa]))
                m_FTipoBaixa = Convert.ToInt32(dbRec[DBProcessosDicInfo.TipoBaixa]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Valor]))
                m_FValor = Convert.ToDecimal(dbRec[DBProcessosDicInfo.Valor]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCacheCalculo]))
                m_FValorCacheCalculo = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCacheCalculo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCacheCalculoProv]))
                m_FValorCacheCalculoProv = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCacheCalculoProv]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCalculado]))
                m_FValorCalculado = (bool)dbRec[DBProcessosDicInfo.ValorCalculado];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCausaDefinitivo]))
                m_FValorCausaDefinitivo = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCausaDefinitivo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCausaInicial]))
                m_FValorCausaInicial = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCausaInicial]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCondenacao]))
                m_FValorCondenacao = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCondenacao]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCondenacaoCalculado]))
                m_FValorCondenacaoCalculado = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCondenacaoCalculado]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCondenacaoProvisorio]))
                m_FValorCondenacaoProvisorio = Convert.ToInt32(dbRec[DBProcessosDicInfo.ValorCondenacaoProvisorio]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorProvisionado]))
                m_FValorProvisionado = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorProvisionado]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBProcessosDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ZKeyQuando]))
                m_FZKeyQuando = Convert.ToDateTime(dbRec[DBProcessosDicInfo.ZKeyQuando]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ZKeyQuem]))
                m_FZKeyQuem = Convert.ToInt32(dbRec[DBProcessosDicInfo.ZKeyQuem]);
        }
        catch
        {
        }

        try
        {
            m_FCaixaMorto = dbRec[DBProcessosDicInfo.CaixaMorto]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFato = dbRec[DBProcessosDicInfo.Fato]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBProcessosDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FMotivoBaixa = dbRec[DBProcessosDicInfo.MotivoBaixa]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNroCaixa = dbRec[DBProcessosDicInfo.NroCaixa]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNroContrato = dbRec[DBProcessosDicInfo.NroContrato]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNroExtra = dbRec[DBProcessosDicInfo.NroExtra]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNroPasta = dbRec[DBProcessosDicInfo.NroPasta]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FOBS = dbRec[DBProcessosDicInfo.OBS]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FObsBCX = dbRec[DBProcessosDicInfo.ObsBCX]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FPercProbExitoJustificativa = dbRec[DBProcessosDicInfo.PercProbExitoJustificativa]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FResumo = dbRec[DBProcessosDicInfo.Resumo]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FZKey = dbRec[DBProcessosDicInfo.ZKey]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_Processos
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [proCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
        cmd.Parameters.AddWithValue("@ThisIDToLoad", id);
        using var ds = ConfiguracoesDBT.GetDataTable(cmd, CommandBehavior.SingleRow, oCnn);
        if (ds != null)
            CarregarDadosBd(ds.Rows.Count.IsEmptyIDNumber() ? null : ds.Rows[0]);
    }

    public void CarregarDadosBd(DataRow? dbRec)
    {
        if (dbRec == null)
            return;
#if (fastAndSecureCode)
try
{
#endif
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
#if (DEBUG)
if (ID == 0)
{
throw new Exception($"ID==0: {TabelaNome}");
}
#endif
#if (fastAndSecureCode)
} 
catch
{
try { ID = Convert.ToInt32(dbRec[CampoCodigo]); } catch { } 
}

#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AdvParc])) m_FAdvParc = Convert.ToInt32(dbRec[DBProcessosDicInfo.AdvParc]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AdvParc])) m_FAdvParc = Convert.ToInt32(dbRec[DBProcessosDicInfo.AdvParc]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AdvParc])) m_FAdvParc = Convert.ToInt32(dbRec[DBProcessosDicInfo.AdvParc]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AdvParc])) m_FAdvParc = Convert.ToInt32(dbRec[DBProcessosDicInfo.AdvParc]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AdvParc])) m_FAdvParc = Convert.ToInt32(dbRec[DBProcessosDicInfo.AdvParc]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AdvParc]))
            m_FAdvParc = Convert.ToInt32(dbRec[DBProcessosDicInfo.AdvParc]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGPedidoNegado])) m_FAJGPedidoNegado = (bool)dbRec[DBProcessosDicInfo.AJGPedidoNegado]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGPedidoNegado])) m_FAJGPedidoNegado = (bool)dbRec[DBProcessosDicInfo.AJGPedidoNegado];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGPedidoNegado])) m_FAJGPedidoNegado = (bool)dbRec[DBProcessosDicInfo.AJGPedidoNegado]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGPedidoNegado])) m_FAJGPedidoNegado = (bool)dbRec[DBProcessosDicInfo.AJGPedidoNegado];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGPedidoNegado])) m_FAJGPedidoNegado = (bool)dbRec[DBProcessosDicInfo.AJGPedidoNegado]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGPedidoNegado]))
            m_FAJGPedidoNegado = (bool)dbRec[DBProcessosDicInfo.AJGPedidoNegado];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGCliente])) m_FAJGCliente = (bool)dbRec[DBProcessosDicInfo.AJGCliente]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGCliente])) m_FAJGCliente = (bool)dbRec[DBProcessosDicInfo.AJGCliente];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGCliente])) m_FAJGCliente = (bool)dbRec[DBProcessosDicInfo.AJGCliente]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGCliente])) m_FAJGCliente = (bool)dbRec[DBProcessosDicInfo.AJGCliente];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGCliente])) m_FAJGCliente = (bool)dbRec[DBProcessosDicInfo.AJGCliente]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGCliente]))
            m_FAJGCliente = (bool)dbRec[DBProcessosDicInfo.AJGCliente];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGPedidoNegadoOPO])) m_FAJGPedidoNegadoOPO = (bool)dbRec[DBProcessosDicInfo.AJGPedidoNegadoOPO]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGPedidoNegadoOPO])) m_FAJGPedidoNegadoOPO = (bool)dbRec[DBProcessosDicInfo.AJGPedidoNegadoOPO];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGPedidoNegadoOPO])) m_FAJGPedidoNegadoOPO = (bool)dbRec[DBProcessosDicInfo.AJGPedidoNegadoOPO]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGPedidoNegadoOPO])) m_FAJGPedidoNegadoOPO = (bool)dbRec[DBProcessosDicInfo.AJGPedidoNegadoOPO];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGPedidoNegadoOPO])) m_FAJGPedidoNegadoOPO = (bool)dbRec[DBProcessosDicInfo.AJGPedidoNegadoOPO]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGPedidoNegadoOPO]))
            m_FAJGPedidoNegadoOPO = (bool)dbRec[DBProcessosDicInfo.AJGPedidoNegadoOPO];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.NotificarPOE])) m_FNotificarPOE = (bool)dbRec[DBProcessosDicInfo.NotificarPOE]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.NotificarPOE])) m_FNotificarPOE = (bool)dbRec[DBProcessosDicInfo.NotificarPOE];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.NotificarPOE])) m_FNotificarPOE = (bool)dbRec[DBProcessosDicInfo.NotificarPOE]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.NotificarPOE])) m_FNotificarPOE = (bool)dbRec[DBProcessosDicInfo.NotificarPOE];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.NotificarPOE])) m_FNotificarPOE = (bool)dbRec[DBProcessosDicInfo.NotificarPOE]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.NotificarPOE]))
            m_FNotificarPOE = (bool)dbRec[DBProcessosDicInfo.NotificarPOE];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorProvisionado])) m_FValorProvisionado = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorProvisionado]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorProvisionado])) m_FValorProvisionado = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorProvisionado]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorProvisionado])) m_FValorProvisionado = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorProvisionado]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorProvisionado])) m_FValorProvisionado = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorProvisionado]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorProvisionado])) m_FValorProvisionado = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorProvisionado]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorProvisionado]))
            m_FValorProvisionado = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorProvisionado]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGOponente])) m_FAJGOponente = (bool)dbRec[DBProcessosDicInfo.AJGOponente]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGOponente])) m_FAJGOponente = (bool)dbRec[DBProcessosDicInfo.AJGOponente];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGOponente])) m_FAJGOponente = (bool)dbRec[DBProcessosDicInfo.AJGOponente]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGOponente])) m_FAJGOponente = (bool)dbRec[DBProcessosDicInfo.AJGOponente];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGOponente])) m_FAJGOponente = (bool)dbRec[DBProcessosDicInfo.AJGOponente]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGOponente]))
            m_FAJGOponente = (bool)dbRec[DBProcessosDicInfo.AJGOponente];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCacheCalculo])) m_FValorCacheCalculo = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCacheCalculo]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCacheCalculo])) m_FValorCacheCalculo = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCacheCalculo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCacheCalculo])) m_FValorCacheCalculo = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCacheCalculo]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCacheCalculo])) m_FValorCacheCalculo = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCacheCalculo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCacheCalculo])) m_FValorCacheCalculo = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCacheCalculo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCacheCalculo]))
            m_FValorCacheCalculo = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCacheCalculo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGPedidoOPO])) m_FAJGPedidoOPO = (bool)dbRec[DBProcessosDicInfo.AJGPedidoOPO]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGPedidoOPO])) m_FAJGPedidoOPO = (bool)dbRec[DBProcessosDicInfo.AJGPedidoOPO];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGPedidoOPO])) m_FAJGPedidoOPO = (bool)dbRec[DBProcessosDicInfo.AJGPedidoOPO]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGPedidoOPO])) m_FAJGPedidoOPO = (bool)dbRec[DBProcessosDicInfo.AJGPedidoOPO];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGPedidoOPO])) m_FAJGPedidoOPO = (bool)dbRec[DBProcessosDicInfo.AJGPedidoOPO]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGPedidoOPO]))
            m_FAJGPedidoOPO = (bool)dbRec[DBProcessosDicInfo.AJGPedidoOPO];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCacheCalculoProv])) m_FValorCacheCalculoProv = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCacheCalculoProv]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCacheCalculoProv])) m_FValorCacheCalculoProv = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCacheCalculoProv]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCacheCalculoProv])) m_FValorCacheCalculoProv = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCacheCalculoProv]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCacheCalculoProv])) m_FValorCacheCalculoProv = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCacheCalculoProv]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCacheCalculoProv])) m_FValorCacheCalculoProv = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCacheCalculoProv]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCacheCalculoProv]))
            m_FValorCacheCalculoProv = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCacheCalculoProv]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ConsiderarParado])) m_FConsiderarParado = (bool)dbRec[DBProcessosDicInfo.ConsiderarParado]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ConsiderarParado])) m_FConsiderarParado = (bool)dbRec[DBProcessosDicInfo.ConsiderarParado];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ConsiderarParado])) m_FConsiderarParado = (bool)dbRec[DBProcessosDicInfo.ConsiderarParado]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ConsiderarParado])) m_FConsiderarParado = (bool)dbRec[DBProcessosDicInfo.ConsiderarParado];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ConsiderarParado])) m_FConsiderarParado = (bool)dbRec[DBProcessosDicInfo.ConsiderarParado]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ConsiderarParado]))
            m_FConsiderarParado = (bool)dbRec[DBProcessosDicInfo.ConsiderarParado];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCalculado])) m_FValorCalculado = (bool)dbRec[DBProcessosDicInfo.ValorCalculado]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCalculado])) m_FValorCalculado = (bool)dbRec[DBProcessosDicInfo.ValorCalculado];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCalculado])) m_FValorCalculado = (bool)dbRec[DBProcessosDicInfo.ValorCalculado]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCalculado])) m_FValorCalculado = (bool)dbRec[DBProcessosDicInfo.ValorCalculado];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCalculado])) m_FValorCalculado = (bool)dbRec[DBProcessosDicInfo.ValorCalculado]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCalculado]))
            m_FValorCalculado = (bool)dbRec[DBProcessosDicInfo.ValorCalculado];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGConcedidoOPO])) m_FAJGConcedidoOPO = (bool)dbRec[DBProcessosDicInfo.AJGConcedidoOPO]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGConcedidoOPO])) m_FAJGConcedidoOPO = (bool)dbRec[DBProcessosDicInfo.AJGConcedidoOPO];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGConcedidoOPO])) m_FAJGConcedidoOPO = (bool)dbRec[DBProcessosDicInfo.AJGConcedidoOPO]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGConcedidoOPO])) m_FAJGConcedidoOPO = (bool)dbRec[DBProcessosDicInfo.AJGConcedidoOPO];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGConcedidoOPO])) m_FAJGConcedidoOPO = (bool)dbRec[DBProcessosDicInfo.AJGConcedidoOPO]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGConcedidoOPO]))
            m_FAJGConcedidoOPO = (bool)dbRec[DBProcessosDicInfo.AJGConcedidoOPO];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Cobranca])) m_FCobranca = (bool)dbRec[DBProcessosDicInfo.Cobranca]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Cobranca])) m_FCobranca = (bool)dbRec[DBProcessosDicInfo.Cobranca];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Cobranca])) m_FCobranca = (bool)dbRec[DBProcessosDicInfo.Cobranca]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Cobranca])) m_FCobranca = (bool)dbRec[DBProcessosDicInfo.Cobranca];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Cobranca])) m_FCobranca = (bool)dbRec[DBProcessosDicInfo.Cobranca]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Cobranca]))
            m_FCobranca = (bool)dbRec[DBProcessosDicInfo.Cobranca];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.DataEntrada])) m_FDataEntrada = Convert.ToDateTime(dbRec[DBProcessosDicInfo.DataEntrada]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.DataEntrada])) m_FDataEntrada = Convert.ToDateTime(dbRec[DBProcessosDicInfo.DataEntrada]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.DataEntrada])) m_FDataEntrada = Convert.ToDateTime(dbRec[DBProcessosDicInfo.DataEntrada]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.DataEntrada])) m_FDataEntrada = Convert.ToDateTime(dbRec[DBProcessosDicInfo.DataEntrada]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.DataEntrada])) m_FDataEntrada = Convert.ToDateTime(dbRec[DBProcessosDicInfo.DataEntrada]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.DataEntrada]))
            m_FDataEntrada = Convert.ToDateTime(dbRec[DBProcessosDicInfo.DataEntrada]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Penhora])) m_FPenhora = (bool)dbRec[DBProcessosDicInfo.Penhora]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Penhora])) m_FPenhora = (bool)dbRec[DBProcessosDicInfo.Penhora];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Penhora])) m_FPenhora = (bool)dbRec[DBProcessosDicInfo.Penhora]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Penhora])) m_FPenhora = (bool)dbRec[DBProcessosDicInfo.Penhora];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Penhora])) m_FPenhora = (bool)dbRec[DBProcessosDicInfo.Penhora]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Penhora]))
            m_FPenhora = (bool)dbRec[DBProcessosDicInfo.Penhora];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGPedido])) m_FAJGPedido = (bool)dbRec[DBProcessosDicInfo.AJGPedido]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGPedido])) m_FAJGPedido = (bool)dbRec[DBProcessosDicInfo.AJGPedido];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGPedido])) m_FAJGPedido = (bool)dbRec[DBProcessosDicInfo.AJGPedido]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGPedido])) m_FAJGPedido = (bool)dbRec[DBProcessosDicInfo.AJGPedido];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGPedido])) m_FAJGPedido = (bool)dbRec[DBProcessosDicInfo.AJGPedido]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGPedido]))
            m_FAJGPedido = (bool)dbRec[DBProcessosDicInfo.AJGPedido];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.TipoBaixa])) m_FTipoBaixa = Convert.ToInt32(dbRec[DBProcessosDicInfo.TipoBaixa]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.TipoBaixa])) m_FTipoBaixa = Convert.ToInt32(dbRec[DBProcessosDicInfo.TipoBaixa]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.TipoBaixa])) m_FTipoBaixa = Convert.ToInt32(dbRec[DBProcessosDicInfo.TipoBaixa]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.TipoBaixa])) m_FTipoBaixa = Convert.ToInt32(dbRec[DBProcessosDicInfo.TipoBaixa]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.TipoBaixa])) m_FTipoBaixa = Convert.ToInt32(dbRec[DBProcessosDicInfo.TipoBaixa]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.TipoBaixa]))
            m_FTipoBaixa = Convert.ToInt32(dbRec[DBProcessosDicInfo.TipoBaixa]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ClassRisco])) m_FClassRisco = Convert.ToInt32(dbRec[DBProcessosDicInfo.ClassRisco]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ClassRisco])) m_FClassRisco = Convert.ToInt32(dbRec[DBProcessosDicInfo.ClassRisco]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ClassRisco])) m_FClassRisco = Convert.ToInt32(dbRec[DBProcessosDicInfo.ClassRisco]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ClassRisco])) m_FClassRisco = Convert.ToInt32(dbRec[DBProcessosDicInfo.ClassRisco]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ClassRisco])) m_FClassRisco = Convert.ToInt32(dbRec[DBProcessosDicInfo.ClassRisco]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ClassRisco]))
            m_FClassRisco = Convert.ToInt32(dbRec[DBProcessosDicInfo.ClassRisco]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.IsApenso])) m_FIsApenso = (bool)dbRec[DBProcessosDicInfo.IsApenso]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.IsApenso])) m_FIsApenso = (bool)dbRec[DBProcessosDicInfo.IsApenso];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.IsApenso])) m_FIsApenso = (bool)dbRec[DBProcessosDicInfo.IsApenso]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.IsApenso])) m_FIsApenso = (bool)dbRec[DBProcessosDicInfo.IsApenso];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.IsApenso])) m_FIsApenso = (bool)dbRec[DBProcessosDicInfo.IsApenso]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.IsApenso]))
            m_FIsApenso = (bool)dbRec[DBProcessosDicInfo.IsApenso];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCausaInicial])) m_FValorCausaInicial = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCausaInicial]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCausaInicial])) m_FValorCausaInicial = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCausaInicial]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCausaInicial])) m_FValorCausaInicial = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCausaInicial]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCausaInicial])) m_FValorCausaInicial = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCausaInicial]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCausaInicial])) m_FValorCausaInicial = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCausaInicial]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCausaInicial]))
            m_FValorCausaInicial = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCausaInicial]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGConcedido])) m_FAJGConcedido = (bool)dbRec[DBProcessosDicInfo.AJGConcedido]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGConcedido])) m_FAJGConcedido = (bool)dbRec[DBProcessosDicInfo.AJGConcedido];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGConcedido])) m_FAJGConcedido = (bool)dbRec[DBProcessosDicInfo.AJGConcedido]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGConcedido])) m_FAJGConcedido = (bool)dbRec[DBProcessosDicInfo.AJGConcedido];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGConcedido])) m_FAJGConcedido = (bool)dbRec[DBProcessosDicInfo.AJGConcedido]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGConcedido]))
            m_FAJGConcedido = (bool)dbRec[DBProcessosDicInfo.AJGConcedido];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FObsBCX = dbRec[DBProcessosDicInfo.ObsBCX]?.ToString() ?? string.Empty; m_FObsBCX = dbRec[DBProcessosDicInfo.ObsBCX]?.ToString() ?? string.Empty;  } catch {}  try { m_FObsBCX = dbRec[DBProcessosDicInfo.ObsBCX]?.ToString() ?? string.Empty; m_FObsBCX = dbRec[DBProcessosDicInfo.ObsBCX]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FObsBCX = dbRec[DBProcessosDicInfo.ObsBCX]?.ToString() ?? string.Empty; } catch { }

#else
        m_FObsBCX = dbRec[DBProcessosDicInfo.ObsBCX]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCausaDefinitivo])) m_FValorCausaDefinitivo = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCausaDefinitivo]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCausaDefinitivo])) m_FValorCausaDefinitivo = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCausaDefinitivo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCausaDefinitivo])) m_FValorCausaDefinitivo = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCausaDefinitivo]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCausaDefinitivo])) m_FValorCausaDefinitivo = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCausaDefinitivo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCausaDefinitivo])) m_FValorCausaDefinitivo = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCausaDefinitivo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCausaDefinitivo]))
            m_FValorCausaDefinitivo = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCausaDefinitivo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.PercProbExito])) m_FPercProbExito = Convert.ToDecimal(dbRec[DBProcessosDicInfo.PercProbExito]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.PercProbExito])) m_FPercProbExito = Convert.ToDecimal(dbRec[DBProcessosDicInfo.PercProbExito]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.PercProbExito])) m_FPercProbExito = Convert.ToDecimal(dbRec[DBProcessosDicInfo.PercProbExito]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.PercProbExito])) m_FPercProbExito = Convert.ToDecimal(dbRec[DBProcessosDicInfo.PercProbExito]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.PercProbExito])) m_FPercProbExito = Convert.ToDecimal(dbRec[DBProcessosDicInfo.PercProbExito]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.PercProbExito]))
            m_FPercProbExito = Convert.ToDecimal(dbRec[DBProcessosDicInfo.PercProbExito]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.MNA])) m_FMNA = (bool)dbRec[DBProcessosDicInfo.MNA]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.MNA])) m_FMNA = (bool)dbRec[DBProcessosDicInfo.MNA];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.MNA])) m_FMNA = (bool)dbRec[DBProcessosDicInfo.MNA]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.MNA])) m_FMNA = (bool)dbRec[DBProcessosDicInfo.MNA];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.MNA])) m_FMNA = (bool)dbRec[DBProcessosDicInfo.MNA]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.MNA]))
            m_FMNA = (bool)dbRec[DBProcessosDicInfo.MNA];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.PercExito])) m_FPercExito = Convert.ToDecimal(dbRec[DBProcessosDicInfo.PercExito]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.PercExito])) m_FPercExito = Convert.ToDecimal(dbRec[DBProcessosDicInfo.PercExito]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.PercExito])) m_FPercExito = Convert.ToDecimal(dbRec[DBProcessosDicInfo.PercExito]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.PercExito])) m_FPercExito = Convert.ToDecimal(dbRec[DBProcessosDicInfo.PercExito]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.PercExito])) m_FPercExito = Convert.ToDecimal(dbRec[DBProcessosDicInfo.PercExito]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.PercExito]))
            m_FPercExito = Convert.ToDecimal(dbRec[DBProcessosDicInfo.PercExito]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNroExtra = dbRec[DBProcessosDicInfo.NroExtra]?.ToString() ?? string.Empty; m_FNroExtra = dbRec[DBProcessosDicInfo.NroExtra]?.ToString() ?? string.Empty;  } catch {}  try { m_FNroExtra = dbRec[DBProcessosDicInfo.NroExtra]?.ToString() ?? string.Empty; m_FNroExtra = dbRec[DBProcessosDicInfo.NroExtra]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNroExtra = dbRec[DBProcessosDicInfo.NroExtra]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNroExtra = dbRec[DBProcessosDicInfo.NroExtra]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AdvOpo])) m_FAdvOpo = Convert.ToInt32(dbRec[DBProcessosDicInfo.AdvOpo]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AdvOpo])) m_FAdvOpo = Convert.ToInt32(dbRec[DBProcessosDicInfo.AdvOpo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AdvOpo])) m_FAdvOpo = Convert.ToInt32(dbRec[DBProcessosDicInfo.AdvOpo]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AdvOpo])) m_FAdvOpo = Convert.ToInt32(dbRec[DBProcessosDicInfo.AdvOpo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AdvOpo])) m_FAdvOpo = Convert.ToInt32(dbRec[DBProcessosDicInfo.AdvOpo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AdvOpo]))
            m_FAdvOpo = Convert.ToInt32(dbRec[DBProcessosDicInfo.AdvOpo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Extra])) m_FExtra = (bool)dbRec[DBProcessosDicInfo.Extra]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Extra])) m_FExtra = (bool)dbRec[DBProcessosDicInfo.Extra];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Extra])) m_FExtra = (bool)dbRec[DBProcessosDicInfo.Extra]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Extra])) m_FExtra = (bool)dbRec[DBProcessosDicInfo.Extra];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Extra])) m_FExtra = (bool)dbRec[DBProcessosDicInfo.Extra]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Extra]))
            m_FExtra = (bool)dbRec[DBProcessosDicInfo.Extra];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBProcessosDicInfo.Justica]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBProcessosDicInfo.Justica]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBProcessosDicInfo.Justica]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBProcessosDicInfo.Justica]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBProcessosDicInfo.Justica]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Justica]))
            m_FJustica = Convert.ToInt32(dbRec[DBProcessosDicInfo.Justica]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBProcessosDicInfo.Advogado]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBProcessosDicInfo.Advogado]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBProcessosDicInfo.Advogado]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBProcessosDicInfo.Advogado]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBProcessosDicInfo.Advogado]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Advogado]))
            m_FAdvogado = Convert.ToInt32(dbRec[DBProcessosDicInfo.Advogado]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNroCaixa = dbRec[DBProcessosDicInfo.NroCaixa]?.ToString() ?? string.Empty; m_FNroCaixa = dbRec[DBProcessosDicInfo.NroCaixa]?.ToString() ?? string.Empty;  } catch {}  try { m_FNroCaixa = dbRec[DBProcessosDicInfo.NroCaixa]?.ToString() ?? string.Empty; m_FNroCaixa = dbRec[DBProcessosDicInfo.NroCaixa]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNroCaixa = dbRec[DBProcessosDicInfo.NroCaixa]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNroCaixa = dbRec[DBProcessosDicInfo.NroCaixa]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Preposto])) m_FPreposto = Convert.ToInt32(dbRec[DBProcessosDicInfo.Preposto]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Preposto])) m_FPreposto = Convert.ToInt32(dbRec[DBProcessosDicInfo.Preposto]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Preposto])) m_FPreposto = Convert.ToInt32(dbRec[DBProcessosDicInfo.Preposto]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Preposto])) m_FPreposto = Convert.ToInt32(dbRec[DBProcessosDicInfo.Preposto]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Preposto])) m_FPreposto = Convert.ToInt32(dbRec[DBProcessosDicInfo.Preposto]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Preposto]))
            m_FPreposto = Convert.ToInt32(dbRec[DBProcessosDicInfo.Preposto]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBProcessosDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBProcessosDicInfo.Cliente]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBProcessosDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBProcessosDicInfo.Cliente]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBProcessosDicInfo.Cliente]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Cliente]))
            m_FCliente = Convert.ToInt32(dbRec[DBProcessosDicInfo.Cliente]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Oponente])) m_FOponente = Convert.ToInt32(dbRec[DBProcessosDicInfo.Oponente]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Oponente])) m_FOponente = Convert.ToInt32(dbRec[DBProcessosDicInfo.Oponente]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Oponente])) m_FOponente = Convert.ToInt32(dbRec[DBProcessosDicInfo.Oponente]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Oponente])) m_FOponente = Convert.ToInt32(dbRec[DBProcessosDicInfo.Oponente]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Oponente])) m_FOponente = Convert.ToInt32(dbRec[DBProcessosDicInfo.Oponente]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Oponente]))
            m_FOponente = Convert.ToInt32(dbRec[DBProcessosDicInfo.Oponente]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBProcessosDicInfo.Area]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBProcessosDicInfo.Area]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBProcessosDicInfo.Area]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBProcessosDicInfo.Area]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBProcessosDicInfo.Area]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Area]))
            m_FArea = Convert.ToInt32(dbRec[DBProcessosDicInfo.Area]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBProcessosDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBProcessosDicInfo.Cidade]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBProcessosDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBProcessosDicInfo.Cidade]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBProcessosDicInfo.Cidade]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Cidade]))
            m_FCidade = Convert.ToInt32(dbRec[DBProcessosDicInfo.Cidade]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Situacao])) m_FSituacao = Convert.ToInt32(dbRec[DBProcessosDicInfo.Situacao]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Situacao])) m_FSituacao = Convert.ToInt32(dbRec[DBProcessosDicInfo.Situacao]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Situacao])) m_FSituacao = Convert.ToInt32(dbRec[DBProcessosDicInfo.Situacao]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Situacao])) m_FSituacao = Convert.ToInt32(dbRec[DBProcessosDicInfo.Situacao]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Situacao])) m_FSituacao = Convert.ToInt32(dbRec[DBProcessosDicInfo.Situacao]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Situacao]))
            m_FSituacao = Convert.ToInt32(dbRec[DBProcessosDicInfo.Situacao]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.IDSituacao])) m_FIDSituacao = (bool)dbRec[DBProcessosDicInfo.IDSituacao]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.IDSituacao])) m_FIDSituacao = (bool)dbRec[DBProcessosDicInfo.IDSituacao];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.IDSituacao])) m_FIDSituacao = (bool)dbRec[DBProcessosDicInfo.IDSituacao]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.IDSituacao])) m_FIDSituacao = (bool)dbRec[DBProcessosDicInfo.IDSituacao];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.IDSituacao])) m_FIDSituacao = (bool)dbRec[DBProcessosDicInfo.IDSituacao]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.IDSituacao]))
            m_FIDSituacao = (bool)dbRec[DBProcessosDicInfo.IDSituacao];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBProcessosDicInfo.Valor]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBProcessosDicInfo.Valor]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBProcessosDicInfo.Valor]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBProcessosDicInfo.Valor]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBProcessosDicInfo.Valor]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Valor]))
            m_FValor = Convert.ToDecimal(dbRec[DBProcessosDicInfo.Valor]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Rito])) m_FRito = Convert.ToInt32(dbRec[DBProcessosDicInfo.Rito]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Rito])) m_FRito = Convert.ToInt32(dbRec[DBProcessosDicInfo.Rito]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Rito])) m_FRito = Convert.ToInt32(dbRec[DBProcessosDicInfo.Rito]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Rito])) m_FRito = Convert.ToInt32(dbRec[DBProcessosDicInfo.Rito]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Rito])) m_FRito = Convert.ToInt32(dbRec[DBProcessosDicInfo.Rito]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Rito]))
            m_FRito = Convert.ToInt32(dbRec[DBProcessosDicInfo.Rito]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFato = dbRec[DBProcessosDicInfo.Fato]?.ToString() ?? string.Empty; m_FFato = dbRec[DBProcessosDicInfo.Fato]?.ToString() ?? string.Empty;  } catch {}  try { m_FFato = dbRec[DBProcessosDicInfo.Fato]?.ToString() ?? string.Empty; m_FFato = dbRec[DBProcessosDicInfo.Fato]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFato = dbRec[DBProcessosDicInfo.Fato]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFato = dbRec[DBProcessosDicInfo.Fato]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNroPasta = dbRec[DBProcessosDicInfo.NroPasta]?.ToString() ?? string.Empty; m_FNroPasta = dbRec[DBProcessosDicInfo.NroPasta]?.ToString() ?? string.Empty;  } catch {}  try { m_FNroPasta = dbRec[DBProcessosDicInfo.NroPasta]?.ToString() ?? string.Empty; m_FNroPasta = dbRec[DBProcessosDicInfo.NroPasta]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNroPasta = dbRec[DBProcessosDicInfo.NroPasta]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNroPasta = dbRec[DBProcessosDicInfo.NroPasta]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Atividade])) m_FAtividade = Convert.ToInt32(dbRec[DBProcessosDicInfo.Atividade]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Atividade])) m_FAtividade = Convert.ToInt32(dbRec[DBProcessosDicInfo.Atividade]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Atividade])) m_FAtividade = Convert.ToInt32(dbRec[DBProcessosDicInfo.Atividade]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Atividade])) m_FAtividade = Convert.ToInt32(dbRec[DBProcessosDicInfo.Atividade]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Atividade])) m_FAtividade = Convert.ToInt32(dbRec[DBProcessosDicInfo.Atividade]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Atividade]))
            m_FAtividade = Convert.ToInt32(dbRec[DBProcessosDicInfo.Atividade]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCaixaMorto = dbRec[DBProcessosDicInfo.CaixaMorto]?.ToString() ?? string.Empty; m_FCaixaMorto = dbRec[DBProcessosDicInfo.CaixaMorto]?.ToString() ?? string.Empty;  } catch {}  try { m_FCaixaMorto = dbRec[DBProcessosDicInfo.CaixaMorto]?.ToString() ?? string.Empty; m_FCaixaMorto = dbRec[DBProcessosDicInfo.CaixaMorto]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCaixaMorto = dbRec[DBProcessosDicInfo.CaixaMorto]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCaixaMorto = dbRec[DBProcessosDicInfo.CaixaMorto]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Baixado])) m_FBaixado = (bool)dbRec[DBProcessosDicInfo.Baixado]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Baixado])) m_FBaixado = (bool)dbRec[DBProcessosDicInfo.Baixado];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Baixado])) m_FBaixado = (bool)dbRec[DBProcessosDicInfo.Baixado]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Baixado])) m_FBaixado = (bool)dbRec[DBProcessosDicInfo.Baixado];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Baixado])) m_FBaixado = (bool)dbRec[DBProcessosDicInfo.Baixado]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Baixado]))
            m_FBaixado = (bool)dbRec[DBProcessosDicInfo.Baixado];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.DtBaixa])) m_FDtBaixa = Convert.ToDateTime(dbRec[DBProcessosDicInfo.DtBaixa]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.DtBaixa])) m_FDtBaixa = Convert.ToDateTime(dbRec[DBProcessosDicInfo.DtBaixa]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.DtBaixa])) m_FDtBaixa = Convert.ToDateTime(dbRec[DBProcessosDicInfo.DtBaixa]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.DtBaixa])) m_FDtBaixa = Convert.ToDateTime(dbRec[DBProcessosDicInfo.DtBaixa]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.DtBaixa])) m_FDtBaixa = Convert.ToDateTime(dbRec[DBProcessosDicInfo.DtBaixa]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.DtBaixa]))
            m_FDtBaixa = Convert.ToDateTime(dbRec[DBProcessosDicInfo.DtBaixa]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FMotivoBaixa = dbRec[DBProcessosDicInfo.MotivoBaixa]?.ToString() ?? string.Empty; m_FMotivoBaixa = dbRec[DBProcessosDicInfo.MotivoBaixa]?.ToString() ?? string.Empty;  } catch {}  try { m_FMotivoBaixa = dbRec[DBProcessosDicInfo.MotivoBaixa]?.ToString() ?? string.Empty; m_FMotivoBaixa = dbRec[DBProcessosDicInfo.MotivoBaixa]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FMotivoBaixa = dbRec[DBProcessosDicInfo.MotivoBaixa]?.ToString() ?? string.Empty; } catch { }

#else
        m_FMotivoBaixa = dbRec[DBProcessosDicInfo.MotivoBaixa]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FOBS = dbRec[DBProcessosDicInfo.OBS]?.ToString() ?? string.Empty; m_FOBS = dbRec[DBProcessosDicInfo.OBS]?.ToString() ?? string.Empty;  } catch {}  try { m_FOBS = dbRec[DBProcessosDicInfo.OBS]?.ToString() ?? string.Empty; m_FOBS = dbRec[DBProcessosDicInfo.OBS]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FOBS = dbRec[DBProcessosDicInfo.OBS]?.ToString() ?? string.Empty; } catch { }

#else
        m_FOBS = dbRec[DBProcessosDicInfo.OBS]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Printed])) m_FPrinted = (bool)dbRec[DBProcessosDicInfo.Printed]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Printed])) m_FPrinted = (bool)dbRec[DBProcessosDicInfo.Printed];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Printed])) m_FPrinted = (bool)dbRec[DBProcessosDicInfo.Printed]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Printed])) m_FPrinted = (bool)dbRec[DBProcessosDicInfo.Printed];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Printed])) m_FPrinted = (bool)dbRec[DBProcessosDicInfo.Printed]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Printed]))
            m_FPrinted = (bool)dbRec[DBProcessosDicInfo.Printed];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FZKey = dbRec[DBProcessosDicInfo.ZKey]?.ToString() ?? string.Empty; m_FZKey = dbRec[DBProcessosDicInfo.ZKey]?.ToString() ?? string.Empty;  } catch {}  try { m_FZKey = dbRec[DBProcessosDicInfo.ZKey]?.ToString() ?? string.Empty; m_FZKey = dbRec[DBProcessosDicInfo.ZKey]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FZKey = dbRec[DBProcessosDicInfo.ZKey]?.ToString() ?? string.Empty; } catch { }

#else
        m_FZKey = dbRec[DBProcessosDicInfo.ZKey]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ZKeyQuem])) m_FZKeyQuem = Convert.ToInt32(dbRec[DBProcessosDicInfo.ZKeyQuem]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ZKeyQuem])) m_FZKeyQuem = Convert.ToInt32(dbRec[DBProcessosDicInfo.ZKeyQuem]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ZKeyQuem])) m_FZKeyQuem = Convert.ToInt32(dbRec[DBProcessosDicInfo.ZKeyQuem]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ZKeyQuem])) m_FZKeyQuem = Convert.ToInt32(dbRec[DBProcessosDicInfo.ZKeyQuem]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ZKeyQuem])) m_FZKeyQuem = Convert.ToInt32(dbRec[DBProcessosDicInfo.ZKeyQuem]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ZKeyQuem]))
            m_FZKeyQuem = Convert.ToInt32(dbRec[DBProcessosDicInfo.ZKeyQuem]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ZKeyQuando])) m_FZKeyQuando = Convert.ToDateTime(dbRec[DBProcessosDicInfo.ZKeyQuando]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ZKeyQuando])) m_FZKeyQuando = Convert.ToDateTime(dbRec[DBProcessosDicInfo.ZKeyQuando]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ZKeyQuando])) m_FZKeyQuando = Convert.ToDateTime(dbRec[DBProcessosDicInfo.ZKeyQuando]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ZKeyQuando])) m_FZKeyQuando = Convert.ToDateTime(dbRec[DBProcessosDicInfo.ZKeyQuando]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ZKeyQuando])) m_FZKeyQuando = Convert.ToDateTime(dbRec[DBProcessosDicInfo.ZKeyQuando]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ZKeyQuando]))
            m_FZKeyQuando = Convert.ToDateTime(dbRec[DBProcessosDicInfo.ZKeyQuando]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FResumo = dbRec[DBProcessosDicInfo.Resumo]?.ToString() ?? string.Empty; m_FResumo = dbRec[DBProcessosDicInfo.Resumo]?.ToString() ?? string.Empty;  } catch {}  try { m_FResumo = dbRec[DBProcessosDicInfo.Resumo]?.ToString() ?? string.Empty; m_FResumo = dbRec[DBProcessosDicInfo.Resumo]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FResumo = dbRec[DBProcessosDicInfo.Resumo]?.ToString() ?? string.Empty; } catch { }

#else
        m_FResumo = dbRec[DBProcessosDicInfo.Resumo]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.NaoImprimir])) m_FNaoImprimir = (bool)dbRec[DBProcessosDicInfo.NaoImprimir]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.NaoImprimir])) m_FNaoImprimir = (bool)dbRec[DBProcessosDicInfo.NaoImprimir];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.NaoImprimir])) m_FNaoImprimir = (bool)dbRec[DBProcessosDicInfo.NaoImprimir]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.NaoImprimir])) m_FNaoImprimir = (bool)dbRec[DBProcessosDicInfo.NaoImprimir];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.NaoImprimir])) m_FNaoImprimir = (bool)dbRec[DBProcessosDicInfo.NaoImprimir]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.NaoImprimir]))
            m_FNaoImprimir = (bool)dbRec[DBProcessosDicInfo.NaoImprimir];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Eletronico])) m_FEletronico = (bool)dbRec[DBProcessosDicInfo.Eletronico]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Eletronico])) m_FEletronico = (bool)dbRec[DBProcessosDicInfo.Eletronico];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Eletronico])) m_FEletronico = (bool)dbRec[DBProcessosDicInfo.Eletronico]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Eletronico])) m_FEletronico = (bool)dbRec[DBProcessosDicInfo.Eletronico];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Eletronico])) m_FEletronico = (bool)dbRec[DBProcessosDicInfo.Eletronico]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Eletronico]))
            m_FEletronico = (bool)dbRec[DBProcessosDicInfo.Eletronico];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNroContrato = dbRec[DBProcessosDicInfo.NroContrato]?.ToString() ?? string.Empty; m_FNroContrato = dbRec[DBProcessosDicInfo.NroContrato]?.ToString() ?? string.Empty;  } catch {}  try { m_FNroContrato = dbRec[DBProcessosDicInfo.NroContrato]?.ToString() ?? string.Empty; m_FNroContrato = dbRec[DBProcessosDicInfo.NroContrato]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNroContrato = dbRec[DBProcessosDicInfo.NroContrato]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNroContrato = dbRec[DBProcessosDicInfo.NroContrato]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FPercProbExitoJustificativa = dbRec[DBProcessosDicInfo.PercProbExitoJustificativa]?.ToString() ?? string.Empty; m_FPercProbExitoJustificativa = dbRec[DBProcessosDicInfo.PercProbExitoJustificativa]?.ToString() ?? string.Empty;  } catch {}  try { m_FPercProbExitoJustificativa = dbRec[DBProcessosDicInfo.PercProbExitoJustificativa]?.ToString() ?? string.Empty; m_FPercProbExitoJustificativa = dbRec[DBProcessosDicInfo.PercProbExitoJustificativa]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FPercProbExitoJustificativa = dbRec[DBProcessosDicInfo.PercProbExitoJustificativa]?.ToString() ?? string.Empty; } catch { }

#else
        m_FPercProbExitoJustificativa = dbRec[DBProcessosDicInfo.PercProbExitoJustificativa]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.HonorarioValor])) m_FHonorarioValor = Convert.ToDecimal(dbRec[DBProcessosDicInfo.HonorarioValor]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.HonorarioValor])) m_FHonorarioValor = Convert.ToDecimal(dbRec[DBProcessosDicInfo.HonorarioValor]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.HonorarioValor])) m_FHonorarioValor = Convert.ToDecimal(dbRec[DBProcessosDicInfo.HonorarioValor]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.HonorarioValor])) m_FHonorarioValor = Convert.ToDecimal(dbRec[DBProcessosDicInfo.HonorarioValor]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.HonorarioValor])) m_FHonorarioValor = Convert.ToDecimal(dbRec[DBProcessosDicInfo.HonorarioValor]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.HonorarioValor]))
            m_FHonorarioValor = Convert.ToDecimal(dbRec[DBProcessosDicInfo.HonorarioValor]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.HonorarioPercentual])) m_FHonorarioPercentual = Convert.ToDecimal(dbRec[DBProcessosDicInfo.HonorarioPercentual]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.HonorarioPercentual])) m_FHonorarioPercentual = Convert.ToDecimal(dbRec[DBProcessosDicInfo.HonorarioPercentual]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.HonorarioPercentual])) m_FHonorarioPercentual = Convert.ToDecimal(dbRec[DBProcessosDicInfo.HonorarioPercentual]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.HonorarioPercentual])) m_FHonorarioPercentual = Convert.ToDecimal(dbRec[DBProcessosDicInfo.HonorarioPercentual]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.HonorarioPercentual])) m_FHonorarioPercentual = Convert.ToDecimal(dbRec[DBProcessosDicInfo.HonorarioPercentual]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.HonorarioPercentual]))
            m_FHonorarioPercentual = Convert.ToDecimal(dbRec[DBProcessosDicInfo.HonorarioPercentual]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.HonorarioSucumbencia])) m_FHonorarioSucumbencia = Convert.ToDecimal(dbRec[DBProcessosDicInfo.HonorarioSucumbencia]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.HonorarioSucumbencia])) m_FHonorarioSucumbencia = Convert.ToDecimal(dbRec[DBProcessosDicInfo.HonorarioSucumbencia]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.HonorarioSucumbencia])) m_FHonorarioSucumbencia = Convert.ToDecimal(dbRec[DBProcessosDicInfo.HonorarioSucumbencia]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.HonorarioSucumbencia])) m_FHonorarioSucumbencia = Convert.ToDecimal(dbRec[DBProcessosDicInfo.HonorarioSucumbencia]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.HonorarioSucumbencia])) m_FHonorarioSucumbencia = Convert.ToDecimal(dbRec[DBProcessosDicInfo.HonorarioSucumbencia]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.HonorarioSucumbencia]))
            m_FHonorarioSucumbencia = Convert.ToDecimal(dbRec[DBProcessosDicInfo.HonorarioSucumbencia]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.FaseAuditoria])) m_FFaseAuditoria = Convert.ToInt32(dbRec[DBProcessosDicInfo.FaseAuditoria]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.FaseAuditoria])) m_FFaseAuditoria = Convert.ToInt32(dbRec[DBProcessosDicInfo.FaseAuditoria]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.FaseAuditoria])) m_FFaseAuditoria = Convert.ToInt32(dbRec[DBProcessosDicInfo.FaseAuditoria]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.FaseAuditoria])) m_FFaseAuditoria = Convert.ToInt32(dbRec[DBProcessosDicInfo.FaseAuditoria]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.FaseAuditoria])) m_FFaseAuditoria = Convert.ToInt32(dbRec[DBProcessosDicInfo.FaseAuditoria]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.FaseAuditoria]))
            m_FFaseAuditoria = Convert.ToInt32(dbRec[DBProcessosDicInfo.FaseAuditoria]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCondenacao])) m_FValorCondenacao = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCondenacao]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCondenacao])) m_FValorCondenacao = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCondenacao]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCondenacao])) m_FValorCondenacao = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCondenacao]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCondenacao])) m_FValorCondenacao = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCondenacao]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCondenacao])) m_FValorCondenacao = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCondenacao]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCondenacao]))
            m_FValorCondenacao = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCondenacao]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCondenacaoCalculado])) m_FValorCondenacaoCalculado = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCondenacaoCalculado]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCondenacaoCalculado])) m_FValorCondenacaoCalculado = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCondenacaoCalculado]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCondenacaoCalculado])) m_FValorCondenacaoCalculado = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCondenacaoCalculado]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCondenacaoCalculado])) m_FValorCondenacaoCalculado = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCondenacaoCalculado]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCondenacaoCalculado])) m_FValorCondenacaoCalculado = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCondenacaoCalculado]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCondenacaoCalculado]))
            m_FValorCondenacaoCalculado = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCondenacaoCalculado]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCondenacaoProvisorio])) m_FValorCondenacaoProvisorio = Convert.ToInt32(dbRec[DBProcessosDicInfo.ValorCondenacaoProvisorio]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCondenacaoProvisorio])) m_FValorCondenacaoProvisorio = Convert.ToInt32(dbRec[DBProcessosDicInfo.ValorCondenacaoProvisorio]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCondenacaoProvisorio])) m_FValorCondenacaoProvisorio = Convert.ToInt32(dbRec[DBProcessosDicInfo.ValorCondenacaoProvisorio]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCondenacaoProvisorio])) m_FValorCondenacaoProvisorio = Convert.ToInt32(dbRec[DBProcessosDicInfo.ValorCondenacaoProvisorio]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCondenacaoProvisorio])) m_FValorCondenacaoProvisorio = Convert.ToInt32(dbRec[DBProcessosDicInfo.ValorCondenacaoProvisorio]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCondenacaoProvisorio]))
            m_FValorCondenacaoProvisorio = Convert.ToInt32(dbRec[DBProcessosDicInfo.ValorCondenacaoProvisorio]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBProcessosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBProcessosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBProcessosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBProcessosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBProcessosDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBProcessosDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProcessosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProcessosDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProcessosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProcessosDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProcessosDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBProcessosDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProcessosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProcessosDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProcessosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProcessosDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProcessosDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBProcessosDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProcessosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProcessosDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProcessosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProcessosDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProcessosDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBProcessosDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProcessosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProcessosDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProcessosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProcessosDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProcessosDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBProcessosDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProcessosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProcessosDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProcessosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProcessosDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProcessosDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBProcessosDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_Processos
    public void CarregarDadosBd(SqlDataReader? dbRec)
    {
        if (dbRec == null)
            return;
#if (fastAndSecureCode)
try
{
#endif
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
#if (DEBUG)
if (ID == 0)
{
throw new Exception($"ID==0: {TabelaNome}");
}
#endif
#if (fastAndSecureCode)
} 
catch
{
try { ID = Convert.ToInt32(dbRec[CampoCodigo]); } catch { } 
}

#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AdvParc])) m_FAdvParc = Convert.ToInt32(dbRec[DBProcessosDicInfo.AdvParc]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AdvParc])) m_FAdvParc = Convert.ToInt32(dbRec[DBProcessosDicInfo.AdvParc]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AdvParc])) m_FAdvParc = Convert.ToInt32(dbRec[DBProcessosDicInfo.AdvParc]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AdvParc])) m_FAdvParc = Convert.ToInt32(dbRec[DBProcessosDicInfo.AdvParc]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AdvParc])) m_FAdvParc = Convert.ToInt32(dbRec[DBProcessosDicInfo.AdvParc]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AdvParc]))
            m_FAdvParc = Convert.ToInt32(dbRec[DBProcessosDicInfo.AdvParc]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGPedidoNegado])) m_FAJGPedidoNegado = (bool)dbRec[DBProcessosDicInfo.AJGPedidoNegado]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGPedidoNegado])) m_FAJGPedidoNegado = (bool)dbRec[DBProcessosDicInfo.AJGPedidoNegado];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGPedidoNegado])) m_FAJGPedidoNegado = (bool)dbRec[DBProcessosDicInfo.AJGPedidoNegado]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGPedidoNegado])) m_FAJGPedidoNegado = (bool)dbRec[DBProcessosDicInfo.AJGPedidoNegado];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGPedidoNegado])) m_FAJGPedidoNegado = (bool)dbRec[DBProcessosDicInfo.AJGPedidoNegado]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGPedidoNegado]))
            m_FAJGPedidoNegado = (bool)dbRec[DBProcessosDicInfo.AJGPedidoNegado];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGCliente])) m_FAJGCliente = (bool)dbRec[DBProcessosDicInfo.AJGCliente]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGCliente])) m_FAJGCliente = (bool)dbRec[DBProcessosDicInfo.AJGCliente];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGCliente])) m_FAJGCliente = (bool)dbRec[DBProcessosDicInfo.AJGCliente]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGCliente])) m_FAJGCliente = (bool)dbRec[DBProcessosDicInfo.AJGCliente];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGCliente])) m_FAJGCliente = (bool)dbRec[DBProcessosDicInfo.AJGCliente]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGCliente]))
            m_FAJGCliente = (bool)dbRec[DBProcessosDicInfo.AJGCliente];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGPedidoNegadoOPO])) m_FAJGPedidoNegadoOPO = (bool)dbRec[DBProcessosDicInfo.AJGPedidoNegadoOPO]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGPedidoNegadoOPO])) m_FAJGPedidoNegadoOPO = (bool)dbRec[DBProcessosDicInfo.AJGPedidoNegadoOPO];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGPedidoNegadoOPO])) m_FAJGPedidoNegadoOPO = (bool)dbRec[DBProcessosDicInfo.AJGPedidoNegadoOPO]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGPedidoNegadoOPO])) m_FAJGPedidoNegadoOPO = (bool)dbRec[DBProcessosDicInfo.AJGPedidoNegadoOPO];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGPedidoNegadoOPO])) m_FAJGPedidoNegadoOPO = (bool)dbRec[DBProcessosDicInfo.AJGPedidoNegadoOPO]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGPedidoNegadoOPO]))
            m_FAJGPedidoNegadoOPO = (bool)dbRec[DBProcessosDicInfo.AJGPedidoNegadoOPO];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.NotificarPOE])) m_FNotificarPOE = (bool)dbRec[DBProcessosDicInfo.NotificarPOE]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.NotificarPOE])) m_FNotificarPOE = (bool)dbRec[DBProcessosDicInfo.NotificarPOE];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.NotificarPOE])) m_FNotificarPOE = (bool)dbRec[DBProcessosDicInfo.NotificarPOE]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.NotificarPOE])) m_FNotificarPOE = (bool)dbRec[DBProcessosDicInfo.NotificarPOE];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.NotificarPOE])) m_FNotificarPOE = (bool)dbRec[DBProcessosDicInfo.NotificarPOE]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.NotificarPOE]))
            m_FNotificarPOE = (bool)dbRec[DBProcessosDicInfo.NotificarPOE];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorProvisionado])) m_FValorProvisionado = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorProvisionado]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorProvisionado])) m_FValorProvisionado = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorProvisionado]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorProvisionado])) m_FValorProvisionado = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorProvisionado]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorProvisionado])) m_FValorProvisionado = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorProvisionado]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorProvisionado])) m_FValorProvisionado = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorProvisionado]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorProvisionado]))
            m_FValorProvisionado = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorProvisionado]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGOponente])) m_FAJGOponente = (bool)dbRec[DBProcessosDicInfo.AJGOponente]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGOponente])) m_FAJGOponente = (bool)dbRec[DBProcessosDicInfo.AJGOponente];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGOponente])) m_FAJGOponente = (bool)dbRec[DBProcessosDicInfo.AJGOponente]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGOponente])) m_FAJGOponente = (bool)dbRec[DBProcessosDicInfo.AJGOponente];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGOponente])) m_FAJGOponente = (bool)dbRec[DBProcessosDicInfo.AJGOponente]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGOponente]))
            m_FAJGOponente = (bool)dbRec[DBProcessosDicInfo.AJGOponente];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCacheCalculo])) m_FValorCacheCalculo = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCacheCalculo]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCacheCalculo])) m_FValorCacheCalculo = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCacheCalculo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCacheCalculo])) m_FValorCacheCalculo = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCacheCalculo]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCacheCalculo])) m_FValorCacheCalculo = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCacheCalculo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCacheCalculo])) m_FValorCacheCalculo = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCacheCalculo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCacheCalculo]))
            m_FValorCacheCalculo = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCacheCalculo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGPedidoOPO])) m_FAJGPedidoOPO = (bool)dbRec[DBProcessosDicInfo.AJGPedidoOPO]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGPedidoOPO])) m_FAJGPedidoOPO = (bool)dbRec[DBProcessosDicInfo.AJGPedidoOPO];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGPedidoOPO])) m_FAJGPedidoOPO = (bool)dbRec[DBProcessosDicInfo.AJGPedidoOPO]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGPedidoOPO])) m_FAJGPedidoOPO = (bool)dbRec[DBProcessosDicInfo.AJGPedidoOPO];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGPedidoOPO])) m_FAJGPedidoOPO = (bool)dbRec[DBProcessosDicInfo.AJGPedidoOPO]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGPedidoOPO]))
            m_FAJGPedidoOPO = (bool)dbRec[DBProcessosDicInfo.AJGPedidoOPO];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCacheCalculoProv])) m_FValorCacheCalculoProv = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCacheCalculoProv]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCacheCalculoProv])) m_FValorCacheCalculoProv = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCacheCalculoProv]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCacheCalculoProv])) m_FValorCacheCalculoProv = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCacheCalculoProv]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCacheCalculoProv])) m_FValorCacheCalculoProv = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCacheCalculoProv]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCacheCalculoProv])) m_FValorCacheCalculoProv = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCacheCalculoProv]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCacheCalculoProv]))
            m_FValorCacheCalculoProv = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCacheCalculoProv]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ConsiderarParado])) m_FConsiderarParado = (bool)dbRec[DBProcessosDicInfo.ConsiderarParado]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ConsiderarParado])) m_FConsiderarParado = (bool)dbRec[DBProcessosDicInfo.ConsiderarParado];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ConsiderarParado])) m_FConsiderarParado = (bool)dbRec[DBProcessosDicInfo.ConsiderarParado]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ConsiderarParado])) m_FConsiderarParado = (bool)dbRec[DBProcessosDicInfo.ConsiderarParado];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ConsiderarParado])) m_FConsiderarParado = (bool)dbRec[DBProcessosDicInfo.ConsiderarParado]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ConsiderarParado]))
            m_FConsiderarParado = (bool)dbRec[DBProcessosDicInfo.ConsiderarParado];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCalculado])) m_FValorCalculado = (bool)dbRec[DBProcessosDicInfo.ValorCalculado]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCalculado])) m_FValorCalculado = (bool)dbRec[DBProcessosDicInfo.ValorCalculado];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCalculado])) m_FValorCalculado = (bool)dbRec[DBProcessosDicInfo.ValorCalculado]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCalculado])) m_FValorCalculado = (bool)dbRec[DBProcessosDicInfo.ValorCalculado];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCalculado])) m_FValorCalculado = (bool)dbRec[DBProcessosDicInfo.ValorCalculado]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCalculado]))
            m_FValorCalculado = (bool)dbRec[DBProcessosDicInfo.ValorCalculado];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGConcedidoOPO])) m_FAJGConcedidoOPO = (bool)dbRec[DBProcessosDicInfo.AJGConcedidoOPO]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGConcedidoOPO])) m_FAJGConcedidoOPO = (bool)dbRec[DBProcessosDicInfo.AJGConcedidoOPO];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGConcedidoOPO])) m_FAJGConcedidoOPO = (bool)dbRec[DBProcessosDicInfo.AJGConcedidoOPO]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGConcedidoOPO])) m_FAJGConcedidoOPO = (bool)dbRec[DBProcessosDicInfo.AJGConcedidoOPO];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGConcedidoOPO])) m_FAJGConcedidoOPO = (bool)dbRec[DBProcessosDicInfo.AJGConcedidoOPO]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGConcedidoOPO]))
            m_FAJGConcedidoOPO = (bool)dbRec[DBProcessosDicInfo.AJGConcedidoOPO];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Cobranca])) m_FCobranca = (bool)dbRec[DBProcessosDicInfo.Cobranca]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Cobranca])) m_FCobranca = (bool)dbRec[DBProcessosDicInfo.Cobranca];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Cobranca])) m_FCobranca = (bool)dbRec[DBProcessosDicInfo.Cobranca]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Cobranca])) m_FCobranca = (bool)dbRec[DBProcessosDicInfo.Cobranca];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Cobranca])) m_FCobranca = (bool)dbRec[DBProcessosDicInfo.Cobranca]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Cobranca]))
            m_FCobranca = (bool)dbRec[DBProcessosDicInfo.Cobranca];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.DataEntrada])) m_FDataEntrada = Convert.ToDateTime(dbRec[DBProcessosDicInfo.DataEntrada]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.DataEntrada])) m_FDataEntrada = Convert.ToDateTime(dbRec[DBProcessosDicInfo.DataEntrada]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.DataEntrada])) m_FDataEntrada = Convert.ToDateTime(dbRec[DBProcessosDicInfo.DataEntrada]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.DataEntrada])) m_FDataEntrada = Convert.ToDateTime(dbRec[DBProcessosDicInfo.DataEntrada]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.DataEntrada])) m_FDataEntrada = Convert.ToDateTime(dbRec[DBProcessosDicInfo.DataEntrada]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.DataEntrada]))
            m_FDataEntrada = Convert.ToDateTime(dbRec[DBProcessosDicInfo.DataEntrada]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Penhora])) m_FPenhora = (bool)dbRec[DBProcessosDicInfo.Penhora]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Penhora])) m_FPenhora = (bool)dbRec[DBProcessosDicInfo.Penhora];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Penhora])) m_FPenhora = (bool)dbRec[DBProcessosDicInfo.Penhora]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Penhora])) m_FPenhora = (bool)dbRec[DBProcessosDicInfo.Penhora];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Penhora])) m_FPenhora = (bool)dbRec[DBProcessosDicInfo.Penhora]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Penhora]))
            m_FPenhora = (bool)dbRec[DBProcessosDicInfo.Penhora];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGPedido])) m_FAJGPedido = (bool)dbRec[DBProcessosDicInfo.AJGPedido]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGPedido])) m_FAJGPedido = (bool)dbRec[DBProcessosDicInfo.AJGPedido];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGPedido])) m_FAJGPedido = (bool)dbRec[DBProcessosDicInfo.AJGPedido]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGPedido])) m_FAJGPedido = (bool)dbRec[DBProcessosDicInfo.AJGPedido];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGPedido])) m_FAJGPedido = (bool)dbRec[DBProcessosDicInfo.AJGPedido]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGPedido]))
            m_FAJGPedido = (bool)dbRec[DBProcessosDicInfo.AJGPedido];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.TipoBaixa])) m_FTipoBaixa = Convert.ToInt32(dbRec[DBProcessosDicInfo.TipoBaixa]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.TipoBaixa])) m_FTipoBaixa = Convert.ToInt32(dbRec[DBProcessosDicInfo.TipoBaixa]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.TipoBaixa])) m_FTipoBaixa = Convert.ToInt32(dbRec[DBProcessosDicInfo.TipoBaixa]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.TipoBaixa])) m_FTipoBaixa = Convert.ToInt32(dbRec[DBProcessosDicInfo.TipoBaixa]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.TipoBaixa])) m_FTipoBaixa = Convert.ToInt32(dbRec[DBProcessosDicInfo.TipoBaixa]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.TipoBaixa]))
            m_FTipoBaixa = Convert.ToInt32(dbRec[DBProcessosDicInfo.TipoBaixa]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ClassRisco])) m_FClassRisco = Convert.ToInt32(dbRec[DBProcessosDicInfo.ClassRisco]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ClassRisco])) m_FClassRisco = Convert.ToInt32(dbRec[DBProcessosDicInfo.ClassRisco]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ClassRisco])) m_FClassRisco = Convert.ToInt32(dbRec[DBProcessosDicInfo.ClassRisco]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ClassRisco])) m_FClassRisco = Convert.ToInt32(dbRec[DBProcessosDicInfo.ClassRisco]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ClassRisco])) m_FClassRisco = Convert.ToInt32(dbRec[DBProcessosDicInfo.ClassRisco]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ClassRisco]))
            m_FClassRisco = Convert.ToInt32(dbRec[DBProcessosDicInfo.ClassRisco]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.IsApenso])) m_FIsApenso = (bool)dbRec[DBProcessosDicInfo.IsApenso]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.IsApenso])) m_FIsApenso = (bool)dbRec[DBProcessosDicInfo.IsApenso];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.IsApenso])) m_FIsApenso = (bool)dbRec[DBProcessosDicInfo.IsApenso]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.IsApenso])) m_FIsApenso = (bool)dbRec[DBProcessosDicInfo.IsApenso];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.IsApenso])) m_FIsApenso = (bool)dbRec[DBProcessosDicInfo.IsApenso]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.IsApenso]))
            m_FIsApenso = (bool)dbRec[DBProcessosDicInfo.IsApenso];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCausaInicial])) m_FValorCausaInicial = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCausaInicial]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCausaInicial])) m_FValorCausaInicial = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCausaInicial]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCausaInicial])) m_FValorCausaInicial = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCausaInicial]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCausaInicial])) m_FValorCausaInicial = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCausaInicial]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCausaInicial])) m_FValorCausaInicial = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCausaInicial]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCausaInicial]))
            m_FValorCausaInicial = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCausaInicial]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGConcedido])) m_FAJGConcedido = (bool)dbRec[DBProcessosDicInfo.AJGConcedido]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGConcedido])) m_FAJGConcedido = (bool)dbRec[DBProcessosDicInfo.AJGConcedido];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGConcedido])) m_FAJGConcedido = (bool)dbRec[DBProcessosDicInfo.AJGConcedido]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGConcedido])) m_FAJGConcedido = (bool)dbRec[DBProcessosDicInfo.AJGConcedido];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGConcedido])) m_FAJGConcedido = (bool)dbRec[DBProcessosDicInfo.AJGConcedido]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AJGConcedido]))
            m_FAJGConcedido = (bool)dbRec[DBProcessosDicInfo.AJGConcedido];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FObsBCX = dbRec[DBProcessosDicInfo.ObsBCX]?.ToString() ?? string.Empty; m_FObsBCX = dbRec[DBProcessosDicInfo.ObsBCX]?.ToString() ?? string.Empty;  } catch {}  try { m_FObsBCX = dbRec[DBProcessosDicInfo.ObsBCX]?.ToString() ?? string.Empty; m_FObsBCX = dbRec[DBProcessosDicInfo.ObsBCX]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FObsBCX = dbRec[DBProcessosDicInfo.ObsBCX]?.ToString() ?? string.Empty; } catch { }

#else
        m_FObsBCX = dbRec[DBProcessosDicInfo.ObsBCX]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCausaDefinitivo])) m_FValorCausaDefinitivo = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCausaDefinitivo]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCausaDefinitivo])) m_FValorCausaDefinitivo = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCausaDefinitivo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCausaDefinitivo])) m_FValorCausaDefinitivo = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCausaDefinitivo]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCausaDefinitivo])) m_FValorCausaDefinitivo = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCausaDefinitivo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCausaDefinitivo])) m_FValorCausaDefinitivo = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCausaDefinitivo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCausaDefinitivo]))
            m_FValorCausaDefinitivo = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCausaDefinitivo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.PercProbExito])) m_FPercProbExito = Convert.ToDecimal(dbRec[DBProcessosDicInfo.PercProbExito]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.PercProbExito])) m_FPercProbExito = Convert.ToDecimal(dbRec[DBProcessosDicInfo.PercProbExito]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.PercProbExito])) m_FPercProbExito = Convert.ToDecimal(dbRec[DBProcessosDicInfo.PercProbExito]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.PercProbExito])) m_FPercProbExito = Convert.ToDecimal(dbRec[DBProcessosDicInfo.PercProbExito]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.PercProbExito])) m_FPercProbExito = Convert.ToDecimal(dbRec[DBProcessosDicInfo.PercProbExito]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.PercProbExito]))
            m_FPercProbExito = Convert.ToDecimal(dbRec[DBProcessosDicInfo.PercProbExito]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.MNA])) m_FMNA = (bool)dbRec[DBProcessosDicInfo.MNA]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.MNA])) m_FMNA = (bool)dbRec[DBProcessosDicInfo.MNA];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.MNA])) m_FMNA = (bool)dbRec[DBProcessosDicInfo.MNA]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.MNA])) m_FMNA = (bool)dbRec[DBProcessosDicInfo.MNA];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.MNA])) m_FMNA = (bool)dbRec[DBProcessosDicInfo.MNA]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.MNA]))
            m_FMNA = (bool)dbRec[DBProcessosDicInfo.MNA];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.PercExito])) m_FPercExito = Convert.ToDecimal(dbRec[DBProcessosDicInfo.PercExito]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.PercExito])) m_FPercExito = Convert.ToDecimal(dbRec[DBProcessosDicInfo.PercExito]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.PercExito])) m_FPercExito = Convert.ToDecimal(dbRec[DBProcessosDicInfo.PercExito]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.PercExito])) m_FPercExito = Convert.ToDecimal(dbRec[DBProcessosDicInfo.PercExito]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.PercExito])) m_FPercExito = Convert.ToDecimal(dbRec[DBProcessosDicInfo.PercExito]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.PercExito]))
            m_FPercExito = Convert.ToDecimal(dbRec[DBProcessosDicInfo.PercExito]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNroExtra = dbRec[DBProcessosDicInfo.NroExtra]?.ToString() ?? string.Empty; m_FNroExtra = dbRec[DBProcessosDicInfo.NroExtra]?.ToString() ?? string.Empty;  } catch {}  try { m_FNroExtra = dbRec[DBProcessosDicInfo.NroExtra]?.ToString() ?? string.Empty; m_FNroExtra = dbRec[DBProcessosDicInfo.NroExtra]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNroExtra = dbRec[DBProcessosDicInfo.NroExtra]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNroExtra = dbRec[DBProcessosDicInfo.NroExtra]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AdvOpo])) m_FAdvOpo = Convert.ToInt32(dbRec[DBProcessosDicInfo.AdvOpo]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AdvOpo])) m_FAdvOpo = Convert.ToInt32(dbRec[DBProcessosDicInfo.AdvOpo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AdvOpo])) m_FAdvOpo = Convert.ToInt32(dbRec[DBProcessosDicInfo.AdvOpo]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AdvOpo])) m_FAdvOpo = Convert.ToInt32(dbRec[DBProcessosDicInfo.AdvOpo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AdvOpo])) m_FAdvOpo = Convert.ToInt32(dbRec[DBProcessosDicInfo.AdvOpo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.AdvOpo]))
            m_FAdvOpo = Convert.ToInt32(dbRec[DBProcessosDicInfo.AdvOpo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Extra])) m_FExtra = (bool)dbRec[DBProcessosDicInfo.Extra]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Extra])) m_FExtra = (bool)dbRec[DBProcessosDicInfo.Extra];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Extra])) m_FExtra = (bool)dbRec[DBProcessosDicInfo.Extra]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Extra])) m_FExtra = (bool)dbRec[DBProcessosDicInfo.Extra];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Extra])) m_FExtra = (bool)dbRec[DBProcessosDicInfo.Extra]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Extra]))
            m_FExtra = (bool)dbRec[DBProcessosDicInfo.Extra];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBProcessosDicInfo.Justica]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBProcessosDicInfo.Justica]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBProcessosDicInfo.Justica]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBProcessosDicInfo.Justica]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBProcessosDicInfo.Justica]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Justica]))
            m_FJustica = Convert.ToInt32(dbRec[DBProcessosDicInfo.Justica]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBProcessosDicInfo.Advogado]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBProcessosDicInfo.Advogado]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBProcessosDicInfo.Advogado]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBProcessosDicInfo.Advogado]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBProcessosDicInfo.Advogado]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Advogado]))
            m_FAdvogado = Convert.ToInt32(dbRec[DBProcessosDicInfo.Advogado]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNroCaixa = dbRec[DBProcessosDicInfo.NroCaixa]?.ToString() ?? string.Empty; m_FNroCaixa = dbRec[DBProcessosDicInfo.NroCaixa]?.ToString() ?? string.Empty;  } catch {}  try { m_FNroCaixa = dbRec[DBProcessosDicInfo.NroCaixa]?.ToString() ?? string.Empty; m_FNroCaixa = dbRec[DBProcessosDicInfo.NroCaixa]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNroCaixa = dbRec[DBProcessosDicInfo.NroCaixa]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNroCaixa = dbRec[DBProcessosDicInfo.NroCaixa]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Preposto])) m_FPreposto = Convert.ToInt32(dbRec[DBProcessosDicInfo.Preposto]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Preposto])) m_FPreposto = Convert.ToInt32(dbRec[DBProcessosDicInfo.Preposto]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Preposto])) m_FPreposto = Convert.ToInt32(dbRec[DBProcessosDicInfo.Preposto]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Preposto])) m_FPreposto = Convert.ToInt32(dbRec[DBProcessosDicInfo.Preposto]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Preposto])) m_FPreposto = Convert.ToInt32(dbRec[DBProcessosDicInfo.Preposto]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Preposto]))
            m_FPreposto = Convert.ToInt32(dbRec[DBProcessosDicInfo.Preposto]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBProcessosDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBProcessosDicInfo.Cliente]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBProcessosDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBProcessosDicInfo.Cliente]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBProcessosDicInfo.Cliente]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Cliente]))
            m_FCliente = Convert.ToInt32(dbRec[DBProcessosDicInfo.Cliente]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Oponente])) m_FOponente = Convert.ToInt32(dbRec[DBProcessosDicInfo.Oponente]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Oponente])) m_FOponente = Convert.ToInt32(dbRec[DBProcessosDicInfo.Oponente]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Oponente])) m_FOponente = Convert.ToInt32(dbRec[DBProcessosDicInfo.Oponente]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Oponente])) m_FOponente = Convert.ToInt32(dbRec[DBProcessosDicInfo.Oponente]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Oponente])) m_FOponente = Convert.ToInt32(dbRec[DBProcessosDicInfo.Oponente]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Oponente]))
            m_FOponente = Convert.ToInt32(dbRec[DBProcessosDicInfo.Oponente]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBProcessosDicInfo.Area]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBProcessosDicInfo.Area]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBProcessosDicInfo.Area]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBProcessosDicInfo.Area]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBProcessosDicInfo.Area]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Area]))
            m_FArea = Convert.ToInt32(dbRec[DBProcessosDicInfo.Area]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBProcessosDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBProcessosDicInfo.Cidade]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBProcessosDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBProcessosDicInfo.Cidade]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBProcessosDicInfo.Cidade]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Cidade]))
            m_FCidade = Convert.ToInt32(dbRec[DBProcessosDicInfo.Cidade]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Situacao])) m_FSituacao = Convert.ToInt32(dbRec[DBProcessosDicInfo.Situacao]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Situacao])) m_FSituacao = Convert.ToInt32(dbRec[DBProcessosDicInfo.Situacao]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Situacao])) m_FSituacao = Convert.ToInt32(dbRec[DBProcessosDicInfo.Situacao]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Situacao])) m_FSituacao = Convert.ToInt32(dbRec[DBProcessosDicInfo.Situacao]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Situacao])) m_FSituacao = Convert.ToInt32(dbRec[DBProcessosDicInfo.Situacao]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Situacao]))
            m_FSituacao = Convert.ToInt32(dbRec[DBProcessosDicInfo.Situacao]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.IDSituacao])) m_FIDSituacao = (bool)dbRec[DBProcessosDicInfo.IDSituacao]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.IDSituacao])) m_FIDSituacao = (bool)dbRec[DBProcessosDicInfo.IDSituacao];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.IDSituacao])) m_FIDSituacao = (bool)dbRec[DBProcessosDicInfo.IDSituacao]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.IDSituacao])) m_FIDSituacao = (bool)dbRec[DBProcessosDicInfo.IDSituacao];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.IDSituacao])) m_FIDSituacao = (bool)dbRec[DBProcessosDicInfo.IDSituacao]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.IDSituacao]))
            m_FIDSituacao = (bool)dbRec[DBProcessosDicInfo.IDSituacao];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBProcessosDicInfo.Valor]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBProcessosDicInfo.Valor]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBProcessosDicInfo.Valor]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBProcessosDicInfo.Valor]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBProcessosDicInfo.Valor]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Valor]))
            m_FValor = Convert.ToDecimal(dbRec[DBProcessosDicInfo.Valor]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Rito])) m_FRito = Convert.ToInt32(dbRec[DBProcessosDicInfo.Rito]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Rito])) m_FRito = Convert.ToInt32(dbRec[DBProcessosDicInfo.Rito]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Rito])) m_FRito = Convert.ToInt32(dbRec[DBProcessosDicInfo.Rito]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Rito])) m_FRito = Convert.ToInt32(dbRec[DBProcessosDicInfo.Rito]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Rito])) m_FRito = Convert.ToInt32(dbRec[DBProcessosDicInfo.Rito]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Rito]))
            m_FRito = Convert.ToInt32(dbRec[DBProcessosDicInfo.Rito]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FFato = dbRec[DBProcessosDicInfo.Fato]?.ToString() ?? string.Empty; m_FFato = dbRec[DBProcessosDicInfo.Fato]?.ToString() ?? string.Empty;  } catch {}  try { m_FFato = dbRec[DBProcessosDicInfo.Fato]?.ToString() ?? string.Empty; m_FFato = dbRec[DBProcessosDicInfo.Fato]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FFato = dbRec[DBProcessosDicInfo.Fato]?.ToString() ?? string.Empty; } catch { }

#else
        m_FFato = dbRec[DBProcessosDicInfo.Fato]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNroPasta = dbRec[DBProcessosDicInfo.NroPasta]?.ToString() ?? string.Empty; m_FNroPasta = dbRec[DBProcessosDicInfo.NroPasta]?.ToString() ?? string.Empty;  } catch {}  try { m_FNroPasta = dbRec[DBProcessosDicInfo.NroPasta]?.ToString() ?? string.Empty; m_FNroPasta = dbRec[DBProcessosDicInfo.NroPasta]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNroPasta = dbRec[DBProcessosDicInfo.NroPasta]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNroPasta = dbRec[DBProcessosDicInfo.NroPasta]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Atividade])) m_FAtividade = Convert.ToInt32(dbRec[DBProcessosDicInfo.Atividade]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Atividade])) m_FAtividade = Convert.ToInt32(dbRec[DBProcessosDicInfo.Atividade]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Atividade])) m_FAtividade = Convert.ToInt32(dbRec[DBProcessosDicInfo.Atividade]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Atividade])) m_FAtividade = Convert.ToInt32(dbRec[DBProcessosDicInfo.Atividade]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Atividade])) m_FAtividade = Convert.ToInt32(dbRec[DBProcessosDicInfo.Atividade]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Atividade]))
            m_FAtividade = Convert.ToInt32(dbRec[DBProcessosDicInfo.Atividade]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCaixaMorto = dbRec[DBProcessosDicInfo.CaixaMorto]?.ToString() ?? string.Empty; m_FCaixaMorto = dbRec[DBProcessosDicInfo.CaixaMorto]?.ToString() ?? string.Empty;  } catch {}  try { m_FCaixaMorto = dbRec[DBProcessosDicInfo.CaixaMorto]?.ToString() ?? string.Empty; m_FCaixaMorto = dbRec[DBProcessosDicInfo.CaixaMorto]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCaixaMorto = dbRec[DBProcessosDicInfo.CaixaMorto]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCaixaMorto = dbRec[DBProcessosDicInfo.CaixaMorto]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Baixado])) m_FBaixado = (bool)dbRec[DBProcessosDicInfo.Baixado]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Baixado])) m_FBaixado = (bool)dbRec[DBProcessosDicInfo.Baixado];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Baixado])) m_FBaixado = (bool)dbRec[DBProcessosDicInfo.Baixado]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Baixado])) m_FBaixado = (bool)dbRec[DBProcessosDicInfo.Baixado];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Baixado])) m_FBaixado = (bool)dbRec[DBProcessosDicInfo.Baixado]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Baixado]))
            m_FBaixado = (bool)dbRec[DBProcessosDicInfo.Baixado];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.DtBaixa])) m_FDtBaixa = Convert.ToDateTime(dbRec[DBProcessosDicInfo.DtBaixa]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.DtBaixa])) m_FDtBaixa = Convert.ToDateTime(dbRec[DBProcessosDicInfo.DtBaixa]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.DtBaixa])) m_FDtBaixa = Convert.ToDateTime(dbRec[DBProcessosDicInfo.DtBaixa]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.DtBaixa])) m_FDtBaixa = Convert.ToDateTime(dbRec[DBProcessosDicInfo.DtBaixa]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.DtBaixa])) m_FDtBaixa = Convert.ToDateTime(dbRec[DBProcessosDicInfo.DtBaixa]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.DtBaixa]))
            m_FDtBaixa = Convert.ToDateTime(dbRec[DBProcessosDicInfo.DtBaixa]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FMotivoBaixa = dbRec[DBProcessosDicInfo.MotivoBaixa]?.ToString() ?? string.Empty; m_FMotivoBaixa = dbRec[DBProcessosDicInfo.MotivoBaixa]?.ToString() ?? string.Empty;  } catch {}  try { m_FMotivoBaixa = dbRec[DBProcessosDicInfo.MotivoBaixa]?.ToString() ?? string.Empty; m_FMotivoBaixa = dbRec[DBProcessosDicInfo.MotivoBaixa]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FMotivoBaixa = dbRec[DBProcessosDicInfo.MotivoBaixa]?.ToString() ?? string.Empty; } catch { }

#else
        m_FMotivoBaixa = dbRec[DBProcessosDicInfo.MotivoBaixa]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FOBS = dbRec[DBProcessosDicInfo.OBS]?.ToString() ?? string.Empty; m_FOBS = dbRec[DBProcessosDicInfo.OBS]?.ToString() ?? string.Empty;  } catch {}  try { m_FOBS = dbRec[DBProcessosDicInfo.OBS]?.ToString() ?? string.Empty; m_FOBS = dbRec[DBProcessosDicInfo.OBS]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FOBS = dbRec[DBProcessosDicInfo.OBS]?.ToString() ?? string.Empty; } catch { }

#else
        m_FOBS = dbRec[DBProcessosDicInfo.OBS]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Printed])) m_FPrinted = (bool)dbRec[DBProcessosDicInfo.Printed]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Printed])) m_FPrinted = (bool)dbRec[DBProcessosDicInfo.Printed];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Printed])) m_FPrinted = (bool)dbRec[DBProcessosDicInfo.Printed]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Printed])) m_FPrinted = (bool)dbRec[DBProcessosDicInfo.Printed];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Printed])) m_FPrinted = (bool)dbRec[DBProcessosDicInfo.Printed]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Printed]))
            m_FPrinted = (bool)dbRec[DBProcessosDicInfo.Printed];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FZKey = dbRec[DBProcessosDicInfo.ZKey]?.ToString() ?? string.Empty; m_FZKey = dbRec[DBProcessosDicInfo.ZKey]?.ToString() ?? string.Empty;  } catch {}  try { m_FZKey = dbRec[DBProcessosDicInfo.ZKey]?.ToString() ?? string.Empty; m_FZKey = dbRec[DBProcessosDicInfo.ZKey]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FZKey = dbRec[DBProcessosDicInfo.ZKey]?.ToString() ?? string.Empty; } catch { }

#else
        m_FZKey = dbRec[DBProcessosDicInfo.ZKey]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ZKeyQuem])) m_FZKeyQuem = Convert.ToInt32(dbRec[DBProcessosDicInfo.ZKeyQuem]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ZKeyQuem])) m_FZKeyQuem = Convert.ToInt32(dbRec[DBProcessosDicInfo.ZKeyQuem]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ZKeyQuem])) m_FZKeyQuem = Convert.ToInt32(dbRec[DBProcessosDicInfo.ZKeyQuem]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ZKeyQuem])) m_FZKeyQuem = Convert.ToInt32(dbRec[DBProcessosDicInfo.ZKeyQuem]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ZKeyQuem])) m_FZKeyQuem = Convert.ToInt32(dbRec[DBProcessosDicInfo.ZKeyQuem]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ZKeyQuem]))
            m_FZKeyQuem = Convert.ToInt32(dbRec[DBProcessosDicInfo.ZKeyQuem]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ZKeyQuando])) m_FZKeyQuando = Convert.ToDateTime(dbRec[DBProcessosDicInfo.ZKeyQuando]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ZKeyQuando])) m_FZKeyQuando = Convert.ToDateTime(dbRec[DBProcessosDicInfo.ZKeyQuando]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ZKeyQuando])) m_FZKeyQuando = Convert.ToDateTime(dbRec[DBProcessosDicInfo.ZKeyQuando]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ZKeyQuando])) m_FZKeyQuando = Convert.ToDateTime(dbRec[DBProcessosDicInfo.ZKeyQuando]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ZKeyQuando])) m_FZKeyQuando = Convert.ToDateTime(dbRec[DBProcessosDicInfo.ZKeyQuando]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ZKeyQuando]))
            m_FZKeyQuando = Convert.ToDateTime(dbRec[DBProcessosDicInfo.ZKeyQuando]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FResumo = dbRec[DBProcessosDicInfo.Resumo]?.ToString() ?? string.Empty; m_FResumo = dbRec[DBProcessosDicInfo.Resumo]?.ToString() ?? string.Empty;  } catch {}  try { m_FResumo = dbRec[DBProcessosDicInfo.Resumo]?.ToString() ?? string.Empty; m_FResumo = dbRec[DBProcessosDicInfo.Resumo]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FResumo = dbRec[DBProcessosDicInfo.Resumo]?.ToString() ?? string.Empty; } catch { }

#else
        m_FResumo = dbRec[DBProcessosDicInfo.Resumo]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.NaoImprimir])) m_FNaoImprimir = (bool)dbRec[DBProcessosDicInfo.NaoImprimir]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.NaoImprimir])) m_FNaoImprimir = (bool)dbRec[DBProcessosDicInfo.NaoImprimir];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.NaoImprimir])) m_FNaoImprimir = (bool)dbRec[DBProcessosDicInfo.NaoImprimir]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.NaoImprimir])) m_FNaoImprimir = (bool)dbRec[DBProcessosDicInfo.NaoImprimir];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.NaoImprimir])) m_FNaoImprimir = (bool)dbRec[DBProcessosDicInfo.NaoImprimir]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.NaoImprimir]))
            m_FNaoImprimir = (bool)dbRec[DBProcessosDicInfo.NaoImprimir];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Eletronico])) m_FEletronico = (bool)dbRec[DBProcessosDicInfo.Eletronico]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Eletronico])) m_FEletronico = (bool)dbRec[DBProcessosDicInfo.Eletronico];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Eletronico])) m_FEletronico = (bool)dbRec[DBProcessosDicInfo.Eletronico]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Eletronico])) m_FEletronico = (bool)dbRec[DBProcessosDicInfo.Eletronico];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Eletronico])) m_FEletronico = (bool)dbRec[DBProcessosDicInfo.Eletronico]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Eletronico]))
            m_FEletronico = (bool)dbRec[DBProcessosDicInfo.Eletronico];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNroContrato = dbRec[DBProcessosDicInfo.NroContrato]?.ToString() ?? string.Empty; m_FNroContrato = dbRec[DBProcessosDicInfo.NroContrato]?.ToString() ?? string.Empty;  } catch {}  try { m_FNroContrato = dbRec[DBProcessosDicInfo.NroContrato]?.ToString() ?? string.Empty; m_FNroContrato = dbRec[DBProcessosDicInfo.NroContrato]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNroContrato = dbRec[DBProcessosDicInfo.NroContrato]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNroContrato = dbRec[DBProcessosDicInfo.NroContrato]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FPercProbExitoJustificativa = dbRec[DBProcessosDicInfo.PercProbExitoJustificativa]?.ToString() ?? string.Empty; m_FPercProbExitoJustificativa = dbRec[DBProcessosDicInfo.PercProbExitoJustificativa]?.ToString() ?? string.Empty;  } catch {}  try { m_FPercProbExitoJustificativa = dbRec[DBProcessosDicInfo.PercProbExitoJustificativa]?.ToString() ?? string.Empty; m_FPercProbExitoJustificativa = dbRec[DBProcessosDicInfo.PercProbExitoJustificativa]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FPercProbExitoJustificativa = dbRec[DBProcessosDicInfo.PercProbExitoJustificativa]?.ToString() ?? string.Empty; } catch { }

#else
        m_FPercProbExitoJustificativa = dbRec[DBProcessosDicInfo.PercProbExitoJustificativa]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.HonorarioValor])) m_FHonorarioValor = Convert.ToDecimal(dbRec[DBProcessosDicInfo.HonorarioValor]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.HonorarioValor])) m_FHonorarioValor = Convert.ToDecimal(dbRec[DBProcessosDicInfo.HonorarioValor]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.HonorarioValor])) m_FHonorarioValor = Convert.ToDecimal(dbRec[DBProcessosDicInfo.HonorarioValor]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.HonorarioValor])) m_FHonorarioValor = Convert.ToDecimal(dbRec[DBProcessosDicInfo.HonorarioValor]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.HonorarioValor])) m_FHonorarioValor = Convert.ToDecimal(dbRec[DBProcessosDicInfo.HonorarioValor]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.HonorarioValor]))
            m_FHonorarioValor = Convert.ToDecimal(dbRec[DBProcessosDicInfo.HonorarioValor]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.HonorarioPercentual])) m_FHonorarioPercentual = Convert.ToDecimal(dbRec[DBProcessosDicInfo.HonorarioPercentual]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.HonorarioPercentual])) m_FHonorarioPercentual = Convert.ToDecimal(dbRec[DBProcessosDicInfo.HonorarioPercentual]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.HonorarioPercentual])) m_FHonorarioPercentual = Convert.ToDecimal(dbRec[DBProcessosDicInfo.HonorarioPercentual]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.HonorarioPercentual])) m_FHonorarioPercentual = Convert.ToDecimal(dbRec[DBProcessosDicInfo.HonorarioPercentual]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.HonorarioPercentual])) m_FHonorarioPercentual = Convert.ToDecimal(dbRec[DBProcessosDicInfo.HonorarioPercentual]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.HonorarioPercentual]))
            m_FHonorarioPercentual = Convert.ToDecimal(dbRec[DBProcessosDicInfo.HonorarioPercentual]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.HonorarioSucumbencia])) m_FHonorarioSucumbencia = Convert.ToDecimal(dbRec[DBProcessosDicInfo.HonorarioSucumbencia]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.HonorarioSucumbencia])) m_FHonorarioSucumbencia = Convert.ToDecimal(dbRec[DBProcessosDicInfo.HonorarioSucumbencia]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.HonorarioSucumbencia])) m_FHonorarioSucumbencia = Convert.ToDecimal(dbRec[DBProcessosDicInfo.HonorarioSucumbencia]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.HonorarioSucumbencia])) m_FHonorarioSucumbencia = Convert.ToDecimal(dbRec[DBProcessosDicInfo.HonorarioSucumbencia]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.HonorarioSucumbencia])) m_FHonorarioSucumbencia = Convert.ToDecimal(dbRec[DBProcessosDicInfo.HonorarioSucumbencia]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.HonorarioSucumbencia]))
            m_FHonorarioSucumbencia = Convert.ToDecimal(dbRec[DBProcessosDicInfo.HonorarioSucumbencia]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.FaseAuditoria])) m_FFaseAuditoria = Convert.ToInt32(dbRec[DBProcessosDicInfo.FaseAuditoria]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.FaseAuditoria])) m_FFaseAuditoria = Convert.ToInt32(dbRec[DBProcessosDicInfo.FaseAuditoria]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.FaseAuditoria])) m_FFaseAuditoria = Convert.ToInt32(dbRec[DBProcessosDicInfo.FaseAuditoria]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.FaseAuditoria])) m_FFaseAuditoria = Convert.ToInt32(dbRec[DBProcessosDicInfo.FaseAuditoria]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.FaseAuditoria])) m_FFaseAuditoria = Convert.ToInt32(dbRec[DBProcessosDicInfo.FaseAuditoria]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.FaseAuditoria]))
            m_FFaseAuditoria = Convert.ToInt32(dbRec[DBProcessosDicInfo.FaseAuditoria]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCondenacao])) m_FValorCondenacao = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCondenacao]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCondenacao])) m_FValorCondenacao = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCondenacao]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCondenacao])) m_FValorCondenacao = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCondenacao]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCondenacao])) m_FValorCondenacao = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCondenacao]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCondenacao])) m_FValorCondenacao = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCondenacao]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCondenacao]))
            m_FValorCondenacao = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCondenacao]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCondenacaoCalculado])) m_FValorCondenacaoCalculado = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCondenacaoCalculado]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCondenacaoCalculado])) m_FValorCondenacaoCalculado = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCondenacaoCalculado]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCondenacaoCalculado])) m_FValorCondenacaoCalculado = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCondenacaoCalculado]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCondenacaoCalculado])) m_FValorCondenacaoCalculado = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCondenacaoCalculado]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCondenacaoCalculado])) m_FValorCondenacaoCalculado = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCondenacaoCalculado]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCondenacaoCalculado]))
            m_FValorCondenacaoCalculado = Convert.ToDecimal(dbRec[DBProcessosDicInfo.ValorCondenacaoCalculado]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCondenacaoProvisorio])) m_FValorCondenacaoProvisorio = Convert.ToInt32(dbRec[DBProcessosDicInfo.ValorCondenacaoProvisorio]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCondenacaoProvisorio])) m_FValorCondenacaoProvisorio = Convert.ToInt32(dbRec[DBProcessosDicInfo.ValorCondenacaoProvisorio]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCondenacaoProvisorio])) m_FValorCondenacaoProvisorio = Convert.ToInt32(dbRec[DBProcessosDicInfo.ValorCondenacaoProvisorio]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCondenacaoProvisorio])) m_FValorCondenacaoProvisorio = Convert.ToInt32(dbRec[DBProcessosDicInfo.ValorCondenacaoProvisorio]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCondenacaoProvisorio])) m_FValorCondenacaoProvisorio = Convert.ToInt32(dbRec[DBProcessosDicInfo.ValorCondenacaoProvisorio]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.ValorCondenacaoProvisorio]))
            m_FValorCondenacaoProvisorio = Convert.ToInt32(dbRec[DBProcessosDicInfo.ValorCondenacaoProvisorio]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBProcessosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBProcessosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBProcessosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBProcessosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBProcessosDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBProcessosDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProcessosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProcessosDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProcessosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProcessosDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProcessosDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBProcessosDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProcessosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProcessosDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProcessosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProcessosDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProcessosDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBProcessosDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProcessosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProcessosDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProcessosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProcessosDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProcessosDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBProcessosDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProcessosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProcessosDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProcessosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProcessosDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProcessosDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBProcessosDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProcessosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProcessosDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProcessosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProcessosDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProcessosDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBProcessosDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}