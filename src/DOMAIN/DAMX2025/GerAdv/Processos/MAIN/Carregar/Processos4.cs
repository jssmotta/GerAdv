namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBProcessos
{
    public DBProcessos(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        InitFromRecord(name => dbRec.Table.Columns.Contains(name) ? dbRec[name] : null);
    }

    public DBProcessos(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        try
        {
            InitFromRecord(name => dbRec[name]);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao carregar dados do Processos: {ex.Message}", ex);
        }
    }

    private void InitFromRecord(Func<string, object?> getValue)
    {
        if (DBNull.Value.Equals(getValue(CampoCodigo)))
            return;
        ID = Convert.ToInt32(getValue(CampoCodigo));
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosDicInfo.Advogado)))
                m_FAdvogado = Convert.ToInt32(getValue(DBProcessosDicInfo.Advogado));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosDicInfo.AdvOpo)))
                m_FAdvOpo = Convert.ToInt32(getValue(DBProcessosDicInfo.AdvOpo));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosDicInfo.AdvParc)))
                m_FAdvParc = Convert.ToInt32(getValue(DBProcessosDicInfo.AdvParc));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosDicInfo.AJGCliente)))
                m_FAJGCliente = Convert.ToBoolean(getValue(DBProcessosDicInfo.AJGCliente));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosDicInfo.AJGConcedido)))
                m_FAJGConcedido = Convert.ToBoolean(getValue(DBProcessosDicInfo.AJGConcedido));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosDicInfo.AJGConcedidoOPO)))
                m_FAJGConcedidoOPO = Convert.ToBoolean(getValue(DBProcessosDicInfo.AJGConcedidoOPO));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosDicInfo.AJGOponente)))
                m_FAJGOponente = Convert.ToBoolean(getValue(DBProcessosDicInfo.AJGOponente));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosDicInfo.AJGPedido)))
                m_FAJGPedido = Convert.ToBoolean(getValue(DBProcessosDicInfo.AJGPedido));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosDicInfo.AJGPedidoNegado)))
                m_FAJGPedidoNegado = Convert.ToBoolean(getValue(DBProcessosDicInfo.AJGPedidoNegado));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosDicInfo.AJGPedidoNegadoOPO)))
                m_FAJGPedidoNegadoOPO = Convert.ToBoolean(getValue(DBProcessosDicInfo.AJGPedidoNegadoOPO));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosDicInfo.AJGPedidoOPO)))
                m_FAJGPedidoOPO = Convert.ToBoolean(getValue(DBProcessosDicInfo.AJGPedidoOPO));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosDicInfo.Area)))
                m_FArea = Convert.ToInt32(getValue(DBProcessosDicInfo.Area));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosDicInfo.Atividade)))
                m_FAtividade = Convert.ToInt32(getValue(DBProcessosDicInfo.Atividade));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosDicInfo.Baixado)))
                m_FBaixado = Convert.ToBoolean(getValue(DBProcessosDicInfo.Baixado));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosDicInfo.Cidade)))
                m_FCidade = Convert.ToInt32(getValue(DBProcessosDicInfo.Cidade));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosDicInfo.ClassRisco)))
                m_FClassRisco = Convert.ToInt32(getValue(DBProcessosDicInfo.ClassRisco));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosDicInfo.Cliente)))
                m_FCliente = Convert.ToInt32(getValue(DBProcessosDicInfo.Cliente));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosDicInfo.Cobranca)))
                m_FCobranca = Convert.ToBoolean(getValue(DBProcessosDicInfo.Cobranca));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosDicInfo.ConsiderarParado)))
                m_FConsiderarParado = Convert.ToBoolean(getValue(DBProcessosDicInfo.ConsiderarParado));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosDicInfo.DataEntrada)))
                m_FDataEntrada = Convert.ToDateTime(getValue(DBProcessosDicInfo.DataEntrada));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosDicInfo.DtAtu)))
                m_FDtAtu = Convert.ToDateTime(getValue(DBProcessosDicInfo.DtAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosDicInfo.DtBaixa)))
                m_FDtBaixa = Convert.ToDateTime(getValue(DBProcessosDicInfo.DtBaixa));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosDicInfo.DtCad)))
                m_FDtCad = Convert.ToDateTime(getValue(DBProcessosDicInfo.DtCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosDicInfo.Eletronico)))
                m_FEletronico = Convert.ToBoolean(getValue(DBProcessosDicInfo.Eletronico));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosDicInfo.Extra)))
                m_FExtra = Convert.ToBoolean(getValue(DBProcessosDicInfo.Extra));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosDicInfo.FaseAuditoria)))
                m_FFaseAuditoria = Convert.ToInt32(getValue(DBProcessosDicInfo.FaseAuditoria));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosDicInfo.HonorarioPercentual)))
                m_FHonorarioPercentual = Convert.ToDecimal(getValue(DBProcessosDicInfo.HonorarioPercentual));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosDicInfo.HonorarioSucumbencia)))
                m_FHonorarioSucumbencia = Convert.ToDecimal(getValue(DBProcessosDicInfo.HonorarioSucumbencia));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosDicInfo.HonorarioValor)))
                m_FHonorarioValor = Convert.ToDecimal(getValue(DBProcessosDicInfo.HonorarioValor));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosDicInfo.IDSituacao)))
                m_FIDSituacao = Convert.ToBoolean(getValue(DBProcessosDicInfo.IDSituacao));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosDicInfo.IsApenso)))
                m_FIsApenso = Convert.ToBoolean(getValue(DBProcessosDicInfo.IsApenso));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosDicInfo.Justica)))
                m_FJustica = Convert.ToInt32(getValue(DBProcessosDicInfo.Justica));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosDicInfo.MNA)))
                m_FMNA = Convert.ToBoolean(getValue(DBProcessosDicInfo.MNA));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosDicInfo.NaoImprimir)))
                m_FNaoImprimir = Convert.ToBoolean(getValue(DBProcessosDicInfo.NaoImprimir));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosDicInfo.NotificarPOE)))
                m_FNotificarPOE = Convert.ToBoolean(getValue(DBProcessosDicInfo.NotificarPOE));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosDicInfo.Oponente)))
                m_FOponente = Convert.ToInt32(getValue(DBProcessosDicInfo.Oponente));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosDicInfo.Penhora)))
                m_FPenhora = Convert.ToBoolean(getValue(DBProcessosDicInfo.Penhora));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosDicInfo.PercExito)))
                m_FPercExito = Convert.ToDecimal(getValue(DBProcessosDicInfo.PercExito));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosDicInfo.PercProbExito)))
                m_FPercProbExito = Convert.ToDecimal(getValue(DBProcessosDicInfo.PercProbExito));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosDicInfo.Preposto)))
                m_FPreposto = Convert.ToInt32(getValue(DBProcessosDicInfo.Preposto));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosDicInfo.Printed)))
                m_FPrinted = Convert.ToBoolean(getValue(DBProcessosDicInfo.Printed));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosDicInfo.QuemAtu)))
                m_FQuemAtu = Convert.ToInt32(getValue(DBProcessosDicInfo.QuemAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosDicInfo.QuemCad)))
                m_FQuemCad = Convert.ToInt32(getValue(DBProcessosDicInfo.QuemCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosDicInfo.Rito)))
                m_FRito = Convert.ToInt32(getValue(DBProcessosDicInfo.Rito));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosDicInfo.Situacao)))
                m_FSituacao = Convert.ToInt32(getValue(DBProcessosDicInfo.Situacao));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosDicInfo.TipoBaixa)))
                m_FTipoBaixa = Convert.ToInt32(getValue(DBProcessosDicInfo.TipoBaixa));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosDicInfo.Valor)))
                m_FValor = Convert.ToDecimal(getValue(DBProcessosDicInfo.Valor));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosDicInfo.ValorCacheCalculo)))
                m_FValorCacheCalculo = Convert.ToDecimal(getValue(DBProcessosDicInfo.ValorCacheCalculo));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosDicInfo.ValorCacheCalculoProv)))
                m_FValorCacheCalculoProv = Convert.ToDecimal(getValue(DBProcessosDicInfo.ValorCacheCalculoProv));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosDicInfo.ValorCalculado)))
                m_FValorCalculado = Convert.ToBoolean(getValue(DBProcessosDicInfo.ValorCalculado));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosDicInfo.ValorCausaDefinitivo)))
                m_FValorCausaDefinitivo = Convert.ToDecimal(getValue(DBProcessosDicInfo.ValorCausaDefinitivo));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosDicInfo.ValorCausaInicial)))
                m_FValorCausaInicial = Convert.ToDecimal(getValue(DBProcessosDicInfo.ValorCausaInicial));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosDicInfo.ValorCondenacao)))
                m_FValorCondenacao = Convert.ToDecimal(getValue(DBProcessosDicInfo.ValorCondenacao));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosDicInfo.ValorCondenacaoCalculado)))
                m_FValorCondenacaoCalculado = Convert.ToDecimal(getValue(DBProcessosDicInfo.ValorCondenacaoCalculado));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosDicInfo.ValorCondenacaoProvisorio)))
                m_FValorCondenacaoProvisorio = Convert.ToInt32(getValue(DBProcessosDicInfo.ValorCondenacaoProvisorio));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosDicInfo.ValorProvisionado)))
                m_FValorProvisionado = Convert.ToDecimal(getValue(DBProcessosDicInfo.ValorProvisionado));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosDicInfo.Visto)))
                m_FVisto = Convert.ToBoolean(getValue(DBProcessosDicInfo.Visto));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosDicInfo.ZKeyQuando)))
                m_FZKeyQuando = Convert.ToDateTime(getValue(DBProcessosDicInfo.ZKeyQuando));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBProcessosDicInfo.ZKeyQuem)))
                m_FZKeyQuem = Convert.ToInt32(getValue(DBProcessosDicInfo.ZKeyQuem));
        }
        catch
        {
        }

        try
        {
            m_FCaixaMorto = getValue(DBProcessosDicInfo.CaixaMorto)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FFato = getValue(DBProcessosDicInfo.Fato)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = getValue(DBProcessosDicInfo.GUID)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FMotivoBaixa = getValue(DBProcessosDicInfo.MotivoBaixa)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNroCaixa = getValue(DBProcessosDicInfo.NroCaixa)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNroContrato = getValue(DBProcessosDicInfo.NroContrato)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNroExtra = getValue(DBProcessosDicInfo.NroExtra)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNroPasta = getValue(DBProcessosDicInfo.NroPasta)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FOBS = getValue(DBProcessosDicInfo.OBS)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FObsBCX = getValue(DBProcessosDicInfo.ObsBCX)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FPercProbExitoJustificativa = getValue(DBProcessosDicInfo.PercProbExitoJustificativa)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FResumo = getValue(DBProcessosDicInfo.Resumo)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FZKey = getValue(DBProcessosDicInfo.ZKey)?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public void CarregarDadosBd(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        try
        {
            InitFromRecord(name => dbRec.Table.Columns.Contains(name) ? dbRec[name] : null);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao carregar dados do Processos: {ex.Message}", ex);
        }
    }

    public void CarregarDadosBd(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        try
        {
            InitFromRecord(name => dbRec[name]);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao carregar dados do Processos: {ex.Message}", ex);
        }
    }
}