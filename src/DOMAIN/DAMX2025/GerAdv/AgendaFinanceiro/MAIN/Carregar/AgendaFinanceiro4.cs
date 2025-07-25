namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBAgendaFinanceiro
{
    public DBAgendaFinanceiro(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        InitFromRecord(name => dbRec.Table.Columns.Contains(name) ? dbRec[name] : null);
    }

    public DBAgendaFinanceiro(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        try
        {
            InitFromRecord(name => dbRec[name]);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao carregar dados do AgendaFinanceiro: {ex.Message}", ex);
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
            if (!DBNull.Value.Equals(getValue(DBAgendaFinanceiroDicInfo.Advogado)))
                m_FAdvogado = Convert.ToInt32(getValue(DBAgendaFinanceiroDicInfo.Advogado));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaFinanceiroDicInfo.Area)))
                m_FArea = Convert.ToInt32(getValue(DBAgendaFinanceiroDicInfo.Area));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaFinanceiroDicInfo.CartaPrecatoria)))
                m_FCartaPrecatoria = Convert.ToInt32(getValue(DBAgendaFinanceiroDicInfo.CartaPrecatoria));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaFinanceiroDicInfo.Cidade)))
                m_FCidade = Convert.ToInt32(getValue(DBAgendaFinanceiroDicInfo.Cidade));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaFinanceiroDicInfo.Cliente)))
                m_FCliente = Convert.ToInt32(getValue(DBAgendaFinanceiroDicInfo.Cliente));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaFinanceiroDicInfo.Concluido)))
                m_FConcluido = Convert.ToBoolean(getValue(DBAgendaFinanceiroDicInfo.Concluido));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaFinanceiroDicInfo.Data)))
                m_FData = Convert.ToDateTime(getValue(DBAgendaFinanceiroDicInfo.Data));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaFinanceiroDicInfo.DataInicioPrazo)))
                m_FDataInicioPrazo = Convert.ToDateTime(getValue(DBAgendaFinanceiroDicInfo.DataInicioPrazo));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaFinanceiroDicInfo.DDias)))
                m_FDDias = Convert.ToDateTime(getValue(DBAgendaFinanceiroDicInfo.DDias));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaFinanceiroDicInfo.Dias)))
                m_FDias = Convert.ToInt32(getValue(DBAgendaFinanceiroDicInfo.Dias));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaFinanceiroDicInfo.DtAtu)))
                m_FDtAtu = Convert.ToDateTime(getValue(DBAgendaFinanceiroDicInfo.DtAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaFinanceiroDicInfo.DtCad)))
                m_FDtCad = Convert.ToDateTime(getValue(DBAgendaFinanceiroDicInfo.DtCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaFinanceiroDicInfo.EventoData)))
                m_FEventoData = Convert.ToDateTime(getValue(DBAgendaFinanceiroDicInfo.EventoData));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaFinanceiroDicInfo.EventoGerador)))
                m_FEventoGerador = Convert.ToInt32(getValue(DBAgendaFinanceiroDicInfo.EventoGerador));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaFinanceiroDicInfo.EventoPrazo)))
                m_FEventoPrazo = Convert.ToInt32(getValue(DBAgendaFinanceiroDicInfo.EventoPrazo));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaFinanceiroDicInfo.Funcionario)))
                m_FFuncionario = Convert.ToInt32(getValue(DBAgendaFinanceiroDicInfo.Funcionario));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaFinanceiroDicInfo.Hora)))
                m_FHora = Convert.ToDateTime(getValue(DBAgendaFinanceiroDicInfo.Hora));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaFinanceiroDicInfo.HrFinal)))
                m_FHrFinal = Convert.ToDateTime(getValue(DBAgendaFinanceiroDicInfo.HrFinal));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaFinanceiroDicInfo.IDCOB)))
                m_FIDCOB = Convert.ToInt32(getValue(DBAgendaFinanceiroDicInfo.IDCOB));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaFinanceiroDicInfo.IDHistorico)))
                m_FIDHistorico = Convert.ToInt32(getValue(DBAgendaFinanceiroDicInfo.IDHistorico));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaFinanceiroDicInfo.IDInsProcesso)))
                m_FIDInsProcesso = Convert.ToInt32(getValue(DBAgendaFinanceiroDicInfo.IDInsProcesso));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaFinanceiroDicInfo.IDNE)))
                m_FIDNE = Convert.ToInt32(getValue(DBAgendaFinanceiroDicInfo.IDNE));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaFinanceiroDicInfo.Importante)))
                m_FImportante = Convert.ToBoolean(getValue(DBAgendaFinanceiroDicInfo.Importante));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaFinanceiroDicInfo.Justica)))
                m_FJustica = Convert.ToInt32(getValue(DBAgendaFinanceiroDicInfo.Justica));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaFinanceiroDicInfo.Liberado)))
                m_FLiberado = Convert.ToBoolean(getValue(DBAgendaFinanceiroDicInfo.Liberado));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaFinanceiroDicInfo.Oculto)))
                m_FOculto = Convert.ToInt32(getValue(DBAgendaFinanceiroDicInfo.Oculto));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaFinanceiroDicInfo.PrazoDias)))
                m_FPrazoDias = Convert.ToInt32(getValue(DBAgendaFinanceiroDicInfo.PrazoDias));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaFinanceiroDicInfo.PrazoProvisionado)))
                m_FPrazoProvisionado = Convert.ToInt32(getValue(DBAgendaFinanceiroDicInfo.PrazoProvisionado));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaFinanceiroDicInfo.Preposto)))
                m_FPreposto = Convert.ToInt32(getValue(DBAgendaFinanceiroDicInfo.Preposto));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaFinanceiroDicInfo.Processo)))
                m_FProcesso = Convert.ToInt32(getValue(DBAgendaFinanceiroDicInfo.Processo));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaFinanceiroDicInfo.ProtocoloIntegrado)))
                m_FProtocoloIntegrado = Convert.ToInt32(getValue(DBAgendaFinanceiroDicInfo.ProtocoloIntegrado));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaFinanceiroDicInfo.QuemAtu)))
                m_FQuemAtu = Convert.ToInt32(getValue(DBAgendaFinanceiroDicInfo.QuemAtu));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaFinanceiroDicInfo.QuemCad)))
                m_FQuemCad = Convert.ToInt32(getValue(DBAgendaFinanceiroDicInfo.QuemCad));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaFinanceiroDicInfo.QuemCodigo)))
                m_FQuemCodigo = Convert.ToInt32(getValue(DBAgendaFinanceiroDicInfo.QuemCodigo));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaFinanceiroDicInfo.QuemID)))
                m_FQuemID = Convert.ToInt32(getValue(DBAgendaFinanceiroDicInfo.QuemID));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaFinanceiroDicInfo.Repetir)))
                m_FRepetir = Convert.ToInt32(getValue(DBAgendaFinanceiroDicInfo.Repetir));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaFinanceiroDicInfo.RepetirDias)))
                m_FRepetirDias = Convert.ToInt32(getValue(DBAgendaFinanceiroDicInfo.RepetirDias));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaFinanceiroDicInfo.Revisar)))
                m_FRevisar = Convert.ToBoolean(getValue(DBAgendaFinanceiroDicInfo.Revisar));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaFinanceiroDicInfo.RevisarP2)))
                m_FRevisarP2 = Convert.ToBoolean(getValue(DBAgendaFinanceiroDicInfo.RevisarP2));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaFinanceiroDicInfo.Sempre)))
                m_FSempre = Convert.ToInt32(getValue(DBAgendaFinanceiroDicInfo.Sempre));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaFinanceiroDicInfo.TipoCompromisso)))
                m_FTipoCompromisso = Convert.ToInt32(getValue(DBAgendaFinanceiroDicInfo.TipoCompromisso));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaFinanceiroDicInfo.Usuario)))
                m_FUsuario = Convert.ToInt32(getValue(DBAgendaFinanceiroDicInfo.Usuario));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaFinanceiroDicInfo.UsuarioCiente)))
                m_FUsuarioCiente = Convert.ToBoolean(getValue(DBAgendaFinanceiroDicInfo.UsuarioCiente));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaFinanceiroDicInfo.Valor)))
                m_FValor = Convert.ToDecimal(getValue(DBAgendaFinanceiroDicInfo.Valor));
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(getValue(DBAgendaFinanceiroDicInfo.Visto)))
                m_FVisto = Convert.ToBoolean(getValue(DBAgendaFinanceiroDicInfo.Visto));
        }
        catch
        {
        }

        try
        {
            m_FCompromisso = getValue(DBAgendaFinanceiroDicInfo.Compromisso)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FCompromissoHTML = getValue(DBAgendaFinanceiroDicInfo.CompromissoHTML)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FDecisao = getValue(DBAgendaFinanceiroDicInfo.Decisao)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = getValue(DBAgendaFinanceiroDicInfo.GUID)?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FStatus = getValue(DBAgendaFinanceiroDicInfo.Status)?.ToString() ?? string.Empty;
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
            throw new Exception($"Erro ao carregar dados do AgendaFinanceiro: {ex.Message}", ex);
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
            throw new Exception($"Erro ao carregar dados do AgendaFinanceiro: {ex.Message}", ex);
        }
    }
}