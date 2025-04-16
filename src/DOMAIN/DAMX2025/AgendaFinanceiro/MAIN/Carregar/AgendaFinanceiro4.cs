namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBAgendaFinanceiro
{
    public DBAgendaFinanceiro(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Advogado]))
                m_FAdvogado = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Advogado]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Area]))
                m_FArea = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Area]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.CartaPrecatoria]))
                m_FCartaPrecatoria = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.CartaPrecatoria]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Cidade]))
                m_FCidade = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Cidade]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Cliente]))
                m_FCliente = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Cliente]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Concluido]))
                m_FConcluido = (bool)dbRec[DBAgendaFinanceiroDicInfo.Concluido];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Data]))
                m_FData = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.Data]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.DataInicioPrazo]))
                m_FDataInicioPrazo = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.DataInicioPrazo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.DDias]))
                m_FDDias = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.DDias]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Dias]))
                m_FDias = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Dias]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.EventoData]))
                m_FEventoData = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.EventoData]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.EventoGerador]))
                m_FEventoGerador = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.EventoGerador]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.EventoPrazo]))
                m_FEventoPrazo = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.EventoPrazo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Funcionario]))
                m_FFuncionario = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Funcionario]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Hora]))
                m_FHora = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.Hora]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.HrFinal]))
                m_FHrFinal = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.HrFinal]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.IDCOB]))
                m_FIDCOB = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.IDCOB]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.IDHistorico]))
                m_FIDHistorico = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.IDHistorico]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.IDInsProcesso]))
                m_FIDInsProcesso = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.IDInsProcesso]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.IDNE]))
                m_FIDNE = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.IDNE]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Importante]))
                m_FImportante = (bool)dbRec[DBAgendaFinanceiroDicInfo.Importante];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Justica]))
                m_FJustica = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Justica]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Liberado]))
                m_FLiberado = (bool)dbRec[DBAgendaFinanceiroDicInfo.Liberado];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Oculto]))
                m_FOculto = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Oculto]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.PrazoDias]))
                m_FPrazoDias = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.PrazoDias]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.PrazoProvisionado]))
                m_FPrazoProvisionado = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.PrazoProvisionado]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Preposto]))
                m_FPreposto = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Preposto]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.ProtocoloIntegrado]))
                m_FProtocoloIntegrado = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.ProtocoloIntegrado]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.QuemCodigo]))
                m_FQuemCodigo = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.QuemCodigo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.QuemID]))
                m_FQuemID = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.QuemID]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Repetir]))
                m_FRepetir = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Repetir]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.RepetirDias]))
                m_FRepetirDias = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.RepetirDias]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Revisar]))
                m_FRevisar = (bool)dbRec[DBAgendaFinanceiroDicInfo.Revisar];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.RevisarP2]))
                m_FRevisarP2 = (bool)dbRec[DBAgendaFinanceiroDicInfo.RevisarP2];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Sempre]))
                m_FSempre = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Sempre]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.TipoCompromisso]))
                m_FTipoCompromisso = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.TipoCompromisso]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Usuario]))
                m_FUsuario = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Usuario]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.UsuarioCiente]))
                m_FUsuarioCiente = (bool)dbRec[DBAgendaFinanceiroDicInfo.UsuarioCiente];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Valor]))
                m_FValor = Convert.ToDecimal(dbRec[DBAgendaFinanceiroDicInfo.Valor]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBAgendaFinanceiroDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FCompromisso = dbRec[DBAgendaFinanceiroDicInfo.Compromisso]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FCompromissoHTML = dbRec[DBAgendaFinanceiroDicInfo.CompromissoHTML]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FDecisao = dbRec[DBAgendaFinanceiroDicInfo.Decisao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBAgendaFinanceiroDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FStatus = dbRec[DBAgendaFinanceiroDicInfo.Status]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBAgendaFinanceiro(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Advogado]))
                m_FAdvogado = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Advogado]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Area]))
                m_FArea = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Area]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.CartaPrecatoria]))
                m_FCartaPrecatoria = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.CartaPrecatoria]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Cidade]))
                m_FCidade = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Cidade]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Cliente]))
                m_FCliente = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Cliente]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Concluido]))
                m_FConcluido = (bool)dbRec[DBAgendaFinanceiroDicInfo.Concluido];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Data]))
                m_FData = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.Data]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.DataInicioPrazo]))
                m_FDataInicioPrazo = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.DataInicioPrazo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.DDias]))
                m_FDDias = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.DDias]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Dias]))
                m_FDias = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Dias]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.EventoData]))
                m_FEventoData = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.EventoData]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.EventoGerador]))
                m_FEventoGerador = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.EventoGerador]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.EventoPrazo]))
                m_FEventoPrazo = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.EventoPrazo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Funcionario]))
                m_FFuncionario = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Funcionario]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Hora]))
                m_FHora = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.Hora]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.HrFinal]))
                m_FHrFinal = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.HrFinal]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.IDCOB]))
                m_FIDCOB = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.IDCOB]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.IDHistorico]))
                m_FIDHistorico = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.IDHistorico]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.IDInsProcesso]))
                m_FIDInsProcesso = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.IDInsProcesso]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.IDNE]))
                m_FIDNE = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.IDNE]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Importante]))
                m_FImportante = (bool)dbRec[DBAgendaFinanceiroDicInfo.Importante];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Justica]))
                m_FJustica = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Justica]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Liberado]))
                m_FLiberado = (bool)dbRec[DBAgendaFinanceiroDicInfo.Liberado];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Oculto]))
                m_FOculto = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Oculto]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.PrazoDias]))
                m_FPrazoDias = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.PrazoDias]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.PrazoProvisionado]))
                m_FPrazoProvisionado = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.PrazoProvisionado]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Preposto]))
                m_FPreposto = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Preposto]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.ProtocoloIntegrado]))
                m_FProtocoloIntegrado = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.ProtocoloIntegrado]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.QuemCodigo]))
                m_FQuemCodigo = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.QuemCodigo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.QuemID]))
                m_FQuemID = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.QuemID]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Repetir]))
                m_FRepetir = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Repetir]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.RepetirDias]))
                m_FRepetirDias = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.RepetirDias]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Revisar]))
                m_FRevisar = (bool)dbRec[DBAgendaFinanceiroDicInfo.Revisar];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.RevisarP2]))
                m_FRevisarP2 = (bool)dbRec[DBAgendaFinanceiroDicInfo.RevisarP2];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Sempre]))
                m_FSempre = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Sempre]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.TipoCompromisso]))
                m_FTipoCompromisso = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.TipoCompromisso]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Usuario]))
                m_FUsuario = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Usuario]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.UsuarioCiente]))
                m_FUsuarioCiente = (bool)dbRec[DBAgendaFinanceiroDicInfo.UsuarioCiente];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Valor]))
                m_FValor = Convert.ToDecimal(dbRec[DBAgendaFinanceiroDicInfo.Valor]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBAgendaFinanceiroDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FCompromisso = dbRec[DBAgendaFinanceiroDicInfo.Compromisso]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FCompromissoHTML = dbRec[DBAgendaFinanceiroDicInfo.CompromissoHTML]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FDecisao = dbRec[DBAgendaFinanceiroDicInfo.Decisao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBAgendaFinanceiroDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FStatus = dbRec[DBAgendaFinanceiroDicInfo.Status]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_AgendaFinanceiro
    protected void Carregar(int id, SqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM dbo.[AgendaFinanceiro] (NOLOCK) WHERE [ageCodigo] = @ThisIDToLoad", oCnn);
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
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.IDCOB])) m_FIDCOB = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.IDCOB]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.IDCOB])) m_FIDCOB = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.IDCOB]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.IDCOB])) m_FIDCOB = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.IDCOB]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.IDCOB])) m_FIDCOB = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.IDCOB]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.IDCOB])) m_FIDCOB = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.IDCOB]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.IDCOB]))
            m_FIDCOB = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.IDCOB]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.IDNE])) m_FIDNE = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.IDNE]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.IDNE])) m_FIDNE = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.IDNE]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.IDNE])) m_FIDNE = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.IDNE]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.IDNE])) m_FIDNE = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.IDNE]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.IDNE])) m_FIDNE = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.IDNE]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.IDNE]))
            m_FIDNE = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.IDNE]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.PrazoProvisionado])) m_FPrazoProvisionado = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.PrazoProvisionado]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.PrazoProvisionado])) m_FPrazoProvisionado = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.PrazoProvisionado]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.PrazoProvisionado])) m_FPrazoProvisionado = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.PrazoProvisionado]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.PrazoProvisionado])) m_FPrazoProvisionado = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.PrazoProvisionado]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.PrazoProvisionado])) m_FPrazoProvisionado = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.PrazoProvisionado]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.PrazoProvisionado]))
            m_FPrazoProvisionado = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.PrazoProvisionado]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Cidade]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Cidade]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Cidade]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Cidade]))
            m_FCidade = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Cidade]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Oculto])) m_FOculto = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Oculto]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Oculto])) m_FOculto = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Oculto]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Oculto])) m_FOculto = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Oculto]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Oculto])) m_FOculto = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Oculto]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Oculto])) m_FOculto = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Oculto]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Oculto]))
            m_FOculto = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Oculto]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.CartaPrecatoria])) m_FCartaPrecatoria = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.CartaPrecatoria]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.CartaPrecatoria])) m_FCartaPrecatoria = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.CartaPrecatoria]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.CartaPrecatoria])) m_FCartaPrecatoria = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.CartaPrecatoria]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.CartaPrecatoria])) m_FCartaPrecatoria = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.CartaPrecatoria]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.CartaPrecatoria])) m_FCartaPrecatoria = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.CartaPrecatoria]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.CartaPrecatoria]))
            m_FCartaPrecatoria = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.CartaPrecatoria]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.RepetirDias])) m_FRepetirDias = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.RepetirDias]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.RepetirDias])) m_FRepetirDias = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.RepetirDias]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.RepetirDias])) m_FRepetirDias = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.RepetirDias]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.RepetirDias])) m_FRepetirDias = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.RepetirDias]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.RepetirDias])) m_FRepetirDias = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.RepetirDias]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.RepetirDias]))
            m_FRepetirDias = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.RepetirDias]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.HrFinal])) m_FHrFinal = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.HrFinal]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.HrFinal])) m_FHrFinal = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.HrFinal]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.HrFinal])) m_FHrFinal = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.HrFinal]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.HrFinal])) m_FHrFinal = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.HrFinal]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.HrFinal])) m_FHrFinal = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.HrFinal]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.HrFinal]))
            m_FHrFinal = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.HrFinal]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Repetir])) m_FRepetir = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Repetir]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Repetir])) m_FRepetir = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Repetir]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Repetir])) m_FRepetir = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Repetir]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Repetir])) m_FRepetir = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Repetir]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Repetir])) m_FRepetir = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Repetir]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Repetir]))
            m_FRepetir = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Repetir]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Advogado]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Advogado]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Advogado]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Advogado]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Advogado]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Advogado]))
            m_FAdvogado = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Advogado]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.EventoGerador])) m_FEventoGerador = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.EventoGerador]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.EventoGerador])) m_FEventoGerador = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.EventoGerador]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.EventoGerador])) m_FEventoGerador = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.EventoGerador]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.EventoGerador])) m_FEventoGerador = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.EventoGerador]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.EventoGerador])) m_FEventoGerador = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.EventoGerador]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.EventoGerador]))
            m_FEventoGerador = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.EventoGerador]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.EventoData])) m_FEventoData = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.EventoData]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.EventoData])) m_FEventoData = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.EventoData]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.EventoData])) m_FEventoData = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.EventoData]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.EventoData])) m_FEventoData = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.EventoData]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.EventoData])) m_FEventoData = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.EventoData]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.EventoData]))
            m_FEventoData = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.EventoData]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Funcionario])) m_FFuncionario = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Funcionario]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Funcionario])) m_FFuncionario = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Funcionario]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Funcionario])) m_FFuncionario = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Funcionario]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Funcionario])) m_FFuncionario = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Funcionario]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Funcionario])) m_FFuncionario = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Funcionario]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Funcionario]))
            m_FFuncionario = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Funcionario]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.Data]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.Data]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.Data]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Data]))
            m_FData = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.Data]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.EventoPrazo])) m_FEventoPrazo = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.EventoPrazo]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.EventoPrazo])) m_FEventoPrazo = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.EventoPrazo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.EventoPrazo])) m_FEventoPrazo = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.EventoPrazo]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.EventoPrazo])) m_FEventoPrazo = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.EventoPrazo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.EventoPrazo])) m_FEventoPrazo = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.EventoPrazo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.EventoPrazo]))
            m_FEventoPrazo = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.EventoPrazo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.Hora]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.Hora]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.Hora]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.Hora]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.Hora]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Hora]))
            m_FHora = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.Hora]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCompromisso = dbRec[DBAgendaFinanceiroDicInfo.Compromisso]?.ToString() ?? string.Empty; m_FCompromisso = dbRec[DBAgendaFinanceiroDicInfo.Compromisso]?.ToString() ?? string.Empty;  } catch {}  try { m_FCompromisso = dbRec[DBAgendaFinanceiroDicInfo.Compromisso]?.ToString() ?? string.Empty; m_FCompromisso = dbRec[DBAgendaFinanceiroDicInfo.Compromisso]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCompromisso = dbRec[DBAgendaFinanceiroDicInfo.Compromisso]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCompromisso = dbRec[DBAgendaFinanceiroDicInfo.Compromisso]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.TipoCompromisso])) m_FTipoCompromisso = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.TipoCompromisso]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.TipoCompromisso])) m_FTipoCompromisso = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.TipoCompromisso]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.TipoCompromisso])) m_FTipoCompromisso = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.TipoCompromisso]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.TipoCompromisso])) m_FTipoCompromisso = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.TipoCompromisso]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.TipoCompromisso])) m_FTipoCompromisso = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.TipoCompromisso]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.TipoCompromisso]))
            m_FTipoCompromisso = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.TipoCompromisso]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Cliente]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Cliente]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Cliente]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Cliente]))
            m_FCliente = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Cliente]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.DDias])) m_FDDias = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.DDias]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.DDias])) m_FDDias = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.DDias]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.DDias])) m_FDDias = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.DDias]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.DDias])) m_FDDias = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.DDias]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.DDias])) m_FDDias = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.DDias]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.DDias]))
            m_FDDias = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.DDias]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Dias])) m_FDias = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Dias]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Dias])) m_FDias = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Dias]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Dias])) m_FDias = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Dias]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Dias])) m_FDias = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Dias]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Dias])) m_FDias = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Dias]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Dias]))
            m_FDias = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Dias]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Liberado])) m_FLiberado = (bool)dbRec[DBAgendaFinanceiroDicInfo.Liberado]; if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Liberado])) m_FLiberado = (bool)dbRec[DBAgendaFinanceiroDicInfo.Liberado];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Liberado])) m_FLiberado = (bool)dbRec[DBAgendaFinanceiroDicInfo.Liberado]; if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Liberado])) m_FLiberado = (bool)dbRec[DBAgendaFinanceiroDicInfo.Liberado];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Liberado])) m_FLiberado = (bool)dbRec[DBAgendaFinanceiroDicInfo.Liberado]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Liberado]))
            m_FLiberado = (bool)dbRec[DBAgendaFinanceiroDicInfo.Liberado];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Importante])) m_FImportante = (bool)dbRec[DBAgendaFinanceiroDicInfo.Importante]; if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Importante])) m_FImportante = (bool)dbRec[DBAgendaFinanceiroDicInfo.Importante];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Importante])) m_FImportante = (bool)dbRec[DBAgendaFinanceiroDicInfo.Importante]; if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Importante])) m_FImportante = (bool)dbRec[DBAgendaFinanceiroDicInfo.Importante];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Importante])) m_FImportante = (bool)dbRec[DBAgendaFinanceiroDicInfo.Importante]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Importante]))
            m_FImportante = (bool)dbRec[DBAgendaFinanceiroDicInfo.Importante];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Concluido])) m_FConcluido = (bool)dbRec[DBAgendaFinanceiroDicInfo.Concluido]; if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Concluido])) m_FConcluido = (bool)dbRec[DBAgendaFinanceiroDicInfo.Concluido];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Concluido])) m_FConcluido = (bool)dbRec[DBAgendaFinanceiroDicInfo.Concluido]; if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Concluido])) m_FConcluido = (bool)dbRec[DBAgendaFinanceiroDicInfo.Concluido];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Concluido])) m_FConcluido = (bool)dbRec[DBAgendaFinanceiroDicInfo.Concluido]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Concluido]))
            m_FConcluido = (bool)dbRec[DBAgendaFinanceiroDicInfo.Concluido];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Area]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Area]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Area]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Area]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Area]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Area]))
            m_FArea = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Area]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Justica]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Justica]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Justica]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Justica]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Justica]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Justica]))
            m_FJustica = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Justica]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.IDHistorico])) m_FIDHistorico = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.IDHistorico]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.IDHistorico])) m_FIDHistorico = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.IDHistorico]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.IDHistorico])) m_FIDHistorico = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.IDHistorico]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.IDHistorico])) m_FIDHistorico = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.IDHistorico]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.IDHistorico])) m_FIDHistorico = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.IDHistorico]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.IDHistorico]))
            m_FIDHistorico = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.IDHistorico]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.IDInsProcesso])) m_FIDInsProcesso = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.IDInsProcesso]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.IDInsProcesso])) m_FIDInsProcesso = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.IDInsProcesso]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.IDInsProcesso])) m_FIDInsProcesso = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.IDInsProcesso]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.IDInsProcesso])) m_FIDInsProcesso = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.IDInsProcesso]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.IDInsProcesso])) m_FIDInsProcesso = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.IDInsProcesso]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.IDInsProcesso]))
            m_FIDInsProcesso = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.IDInsProcesso]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Usuario])) m_FUsuario = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Usuario]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Usuario])) m_FUsuario = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Usuario]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Usuario])) m_FUsuario = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Usuario]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Usuario])) m_FUsuario = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Usuario]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Usuario])) m_FUsuario = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Usuario]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Usuario]))
            m_FUsuario = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Usuario]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Preposto])) m_FPreposto = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Preposto]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Preposto])) m_FPreposto = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Preposto]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Preposto])) m_FPreposto = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Preposto]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Preposto])) m_FPreposto = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Preposto]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Preposto])) m_FPreposto = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Preposto]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Preposto]))
            m_FPreposto = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Preposto]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.QuemID])) m_FQuemID = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.QuemID]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.QuemID])) m_FQuemID = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.QuemID]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.QuemID])) m_FQuemID = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.QuemID]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.QuemID])) m_FQuemID = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.QuemID]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.QuemID])) m_FQuemID = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.QuemID]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.QuemID]))
            m_FQuemID = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.QuemID]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.QuemCodigo])) m_FQuemCodigo = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.QuemCodigo]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.QuemCodigo])) m_FQuemCodigo = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.QuemCodigo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.QuemCodigo])) m_FQuemCodigo = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.QuemCodigo]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.QuemCodigo])) m_FQuemCodigo = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.QuemCodigo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.QuemCodigo])) m_FQuemCodigo = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.QuemCodigo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.QuemCodigo]))
            m_FQuemCodigo = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.QuemCodigo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FStatus = dbRec[DBAgendaFinanceiroDicInfo.Status]?.ToString() ?? string.Empty; m_FStatus = dbRec[DBAgendaFinanceiroDicInfo.Status]?.ToString() ?? string.Empty;  } catch {}  try { m_FStatus = dbRec[DBAgendaFinanceiroDicInfo.Status]?.ToString() ?? string.Empty; m_FStatus = dbRec[DBAgendaFinanceiroDicInfo.Status]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FStatus = dbRec[DBAgendaFinanceiroDicInfo.Status]?.ToString() ?? string.Empty; } catch { }

#else
        m_FStatus = dbRec[DBAgendaFinanceiroDicInfo.Status]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBAgendaFinanceiroDicInfo.Valor]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBAgendaFinanceiroDicInfo.Valor]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBAgendaFinanceiroDicInfo.Valor]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBAgendaFinanceiroDicInfo.Valor]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBAgendaFinanceiroDicInfo.Valor]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Valor]))
            m_FValor = Convert.ToDecimal(dbRec[DBAgendaFinanceiroDicInfo.Valor]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCompromissoHTML = dbRec[DBAgendaFinanceiroDicInfo.CompromissoHTML]?.ToString() ?? string.Empty; m_FCompromissoHTML = dbRec[DBAgendaFinanceiroDicInfo.CompromissoHTML]?.ToString() ?? string.Empty;  } catch {}  try { m_FCompromissoHTML = dbRec[DBAgendaFinanceiroDicInfo.CompromissoHTML]?.ToString() ?? string.Empty; m_FCompromissoHTML = dbRec[DBAgendaFinanceiroDicInfo.CompromissoHTML]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCompromissoHTML = dbRec[DBAgendaFinanceiroDicInfo.CompromissoHTML]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCompromissoHTML = dbRec[DBAgendaFinanceiroDicInfo.CompromissoHTML]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FDecisao = dbRec[DBAgendaFinanceiroDicInfo.Decisao]?.ToString() ?? string.Empty; m_FDecisao = dbRec[DBAgendaFinanceiroDicInfo.Decisao]?.ToString() ?? string.Empty;  } catch {}  try { m_FDecisao = dbRec[DBAgendaFinanceiroDicInfo.Decisao]?.ToString() ?? string.Empty; m_FDecisao = dbRec[DBAgendaFinanceiroDicInfo.Decisao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FDecisao = dbRec[DBAgendaFinanceiroDicInfo.Decisao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FDecisao = dbRec[DBAgendaFinanceiroDicInfo.Decisao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Revisar])) m_FRevisar = (bool)dbRec[DBAgendaFinanceiroDicInfo.Revisar]; if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Revisar])) m_FRevisar = (bool)dbRec[DBAgendaFinanceiroDicInfo.Revisar];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Revisar])) m_FRevisar = (bool)dbRec[DBAgendaFinanceiroDicInfo.Revisar]; if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Revisar])) m_FRevisar = (bool)dbRec[DBAgendaFinanceiroDicInfo.Revisar];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Revisar])) m_FRevisar = (bool)dbRec[DBAgendaFinanceiroDicInfo.Revisar]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Revisar]))
            m_FRevisar = (bool)dbRec[DBAgendaFinanceiroDicInfo.Revisar];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.RevisarP2])) m_FRevisarP2 = (bool)dbRec[DBAgendaFinanceiroDicInfo.RevisarP2]; if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.RevisarP2])) m_FRevisarP2 = (bool)dbRec[DBAgendaFinanceiroDicInfo.RevisarP2];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.RevisarP2])) m_FRevisarP2 = (bool)dbRec[DBAgendaFinanceiroDicInfo.RevisarP2]; if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.RevisarP2])) m_FRevisarP2 = (bool)dbRec[DBAgendaFinanceiroDicInfo.RevisarP2];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.RevisarP2])) m_FRevisarP2 = (bool)dbRec[DBAgendaFinanceiroDicInfo.RevisarP2]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.RevisarP2]))
            m_FRevisarP2 = (bool)dbRec[DBAgendaFinanceiroDicInfo.RevisarP2];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Sempre])) m_FSempre = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Sempre]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Sempre])) m_FSempre = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Sempre]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Sempre])) m_FSempre = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Sempre]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Sempre])) m_FSempre = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Sempre]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Sempre])) m_FSempre = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Sempre]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Sempre]))
            m_FSempre = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Sempre]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.PrazoDias])) m_FPrazoDias = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.PrazoDias]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.PrazoDias])) m_FPrazoDias = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.PrazoDias]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.PrazoDias])) m_FPrazoDias = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.PrazoDias]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.PrazoDias])) m_FPrazoDias = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.PrazoDias]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.PrazoDias])) m_FPrazoDias = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.PrazoDias]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.PrazoDias]))
            m_FPrazoDias = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.PrazoDias]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.ProtocoloIntegrado])) m_FProtocoloIntegrado = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.ProtocoloIntegrado]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.ProtocoloIntegrado])) m_FProtocoloIntegrado = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.ProtocoloIntegrado]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.ProtocoloIntegrado])) m_FProtocoloIntegrado = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.ProtocoloIntegrado]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.ProtocoloIntegrado])) m_FProtocoloIntegrado = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.ProtocoloIntegrado]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.ProtocoloIntegrado])) m_FProtocoloIntegrado = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.ProtocoloIntegrado]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.ProtocoloIntegrado]))
            m_FProtocoloIntegrado = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.ProtocoloIntegrado]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.DataInicioPrazo])) m_FDataInicioPrazo = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.DataInicioPrazo]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.DataInicioPrazo])) m_FDataInicioPrazo = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.DataInicioPrazo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.DataInicioPrazo])) m_FDataInicioPrazo = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.DataInicioPrazo]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.DataInicioPrazo])) m_FDataInicioPrazo = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.DataInicioPrazo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.DataInicioPrazo])) m_FDataInicioPrazo = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.DataInicioPrazo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.DataInicioPrazo]))
            m_FDataInicioPrazo = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.DataInicioPrazo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.UsuarioCiente])) m_FUsuarioCiente = (bool)dbRec[DBAgendaFinanceiroDicInfo.UsuarioCiente]; if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.UsuarioCiente])) m_FUsuarioCiente = (bool)dbRec[DBAgendaFinanceiroDicInfo.UsuarioCiente];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.UsuarioCiente])) m_FUsuarioCiente = (bool)dbRec[DBAgendaFinanceiroDicInfo.UsuarioCiente]; if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.UsuarioCiente])) m_FUsuarioCiente = (bool)dbRec[DBAgendaFinanceiroDicInfo.UsuarioCiente];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.UsuarioCiente])) m_FUsuarioCiente = (bool)dbRec[DBAgendaFinanceiroDicInfo.UsuarioCiente]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.UsuarioCiente]))
            m_FUsuarioCiente = (bool)dbRec[DBAgendaFinanceiroDicInfo.UsuarioCiente];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBAgendaFinanceiroDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBAgendaFinanceiroDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBAgendaFinanceiroDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBAgendaFinanceiroDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBAgendaFinanceiroDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBAgendaFinanceiroDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAgendaFinanceiroDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAgendaFinanceiroDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAgendaFinanceiroDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAgendaFinanceiroDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAgendaFinanceiroDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBAgendaFinanceiroDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_AgendaFinanceiro
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
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.IDCOB])) m_FIDCOB = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.IDCOB]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.IDCOB])) m_FIDCOB = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.IDCOB]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.IDCOB])) m_FIDCOB = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.IDCOB]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.IDCOB])) m_FIDCOB = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.IDCOB]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.IDCOB])) m_FIDCOB = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.IDCOB]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.IDCOB]))
            m_FIDCOB = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.IDCOB]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.IDNE])) m_FIDNE = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.IDNE]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.IDNE])) m_FIDNE = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.IDNE]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.IDNE])) m_FIDNE = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.IDNE]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.IDNE])) m_FIDNE = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.IDNE]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.IDNE])) m_FIDNE = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.IDNE]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.IDNE]))
            m_FIDNE = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.IDNE]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.PrazoProvisionado])) m_FPrazoProvisionado = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.PrazoProvisionado]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.PrazoProvisionado])) m_FPrazoProvisionado = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.PrazoProvisionado]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.PrazoProvisionado])) m_FPrazoProvisionado = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.PrazoProvisionado]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.PrazoProvisionado])) m_FPrazoProvisionado = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.PrazoProvisionado]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.PrazoProvisionado])) m_FPrazoProvisionado = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.PrazoProvisionado]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.PrazoProvisionado]))
            m_FPrazoProvisionado = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.PrazoProvisionado]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Cidade]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Cidade]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Cidade]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Cidade]))
            m_FCidade = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Cidade]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Oculto])) m_FOculto = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Oculto]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Oculto])) m_FOculto = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Oculto]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Oculto])) m_FOculto = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Oculto]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Oculto])) m_FOculto = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Oculto]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Oculto])) m_FOculto = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Oculto]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Oculto]))
            m_FOculto = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Oculto]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.CartaPrecatoria])) m_FCartaPrecatoria = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.CartaPrecatoria]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.CartaPrecatoria])) m_FCartaPrecatoria = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.CartaPrecatoria]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.CartaPrecatoria])) m_FCartaPrecatoria = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.CartaPrecatoria]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.CartaPrecatoria])) m_FCartaPrecatoria = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.CartaPrecatoria]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.CartaPrecatoria])) m_FCartaPrecatoria = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.CartaPrecatoria]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.CartaPrecatoria]))
            m_FCartaPrecatoria = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.CartaPrecatoria]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.RepetirDias])) m_FRepetirDias = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.RepetirDias]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.RepetirDias])) m_FRepetirDias = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.RepetirDias]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.RepetirDias])) m_FRepetirDias = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.RepetirDias]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.RepetirDias])) m_FRepetirDias = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.RepetirDias]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.RepetirDias])) m_FRepetirDias = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.RepetirDias]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.RepetirDias]))
            m_FRepetirDias = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.RepetirDias]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.HrFinal])) m_FHrFinal = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.HrFinal]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.HrFinal])) m_FHrFinal = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.HrFinal]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.HrFinal])) m_FHrFinal = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.HrFinal]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.HrFinal])) m_FHrFinal = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.HrFinal]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.HrFinal])) m_FHrFinal = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.HrFinal]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.HrFinal]))
            m_FHrFinal = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.HrFinal]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Repetir])) m_FRepetir = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Repetir]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Repetir])) m_FRepetir = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Repetir]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Repetir])) m_FRepetir = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Repetir]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Repetir])) m_FRepetir = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Repetir]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Repetir])) m_FRepetir = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Repetir]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Repetir]))
            m_FRepetir = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Repetir]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Advogado]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Advogado]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Advogado]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Advogado]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Advogado]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Advogado]))
            m_FAdvogado = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Advogado]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.EventoGerador])) m_FEventoGerador = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.EventoGerador]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.EventoGerador])) m_FEventoGerador = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.EventoGerador]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.EventoGerador])) m_FEventoGerador = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.EventoGerador]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.EventoGerador])) m_FEventoGerador = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.EventoGerador]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.EventoGerador])) m_FEventoGerador = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.EventoGerador]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.EventoGerador]))
            m_FEventoGerador = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.EventoGerador]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.EventoData])) m_FEventoData = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.EventoData]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.EventoData])) m_FEventoData = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.EventoData]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.EventoData])) m_FEventoData = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.EventoData]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.EventoData])) m_FEventoData = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.EventoData]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.EventoData])) m_FEventoData = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.EventoData]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.EventoData]))
            m_FEventoData = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.EventoData]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Funcionario])) m_FFuncionario = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Funcionario]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Funcionario])) m_FFuncionario = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Funcionario]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Funcionario])) m_FFuncionario = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Funcionario]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Funcionario])) m_FFuncionario = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Funcionario]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Funcionario])) m_FFuncionario = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Funcionario]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Funcionario]))
            m_FFuncionario = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Funcionario]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.Data]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.Data]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.Data]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Data]))
            m_FData = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.Data]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.EventoPrazo])) m_FEventoPrazo = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.EventoPrazo]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.EventoPrazo])) m_FEventoPrazo = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.EventoPrazo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.EventoPrazo])) m_FEventoPrazo = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.EventoPrazo]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.EventoPrazo])) m_FEventoPrazo = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.EventoPrazo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.EventoPrazo])) m_FEventoPrazo = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.EventoPrazo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.EventoPrazo]))
            m_FEventoPrazo = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.EventoPrazo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.Hora]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.Hora]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.Hora]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.Hora]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.Hora]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Hora]))
            m_FHora = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.Hora]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCompromisso = dbRec[DBAgendaFinanceiroDicInfo.Compromisso]?.ToString() ?? string.Empty; m_FCompromisso = dbRec[DBAgendaFinanceiroDicInfo.Compromisso]?.ToString() ?? string.Empty;  } catch {}  try { m_FCompromisso = dbRec[DBAgendaFinanceiroDicInfo.Compromisso]?.ToString() ?? string.Empty; m_FCompromisso = dbRec[DBAgendaFinanceiroDicInfo.Compromisso]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCompromisso = dbRec[DBAgendaFinanceiroDicInfo.Compromisso]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCompromisso = dbRec[DBAgendaFinanceiroDicInfo.Compromisso]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.TipoCompromisso])) m_FTipoCompromisso = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.TipoCompromisso]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.TipoCompromisso])) m_FTipoCompromisso = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.TipoCompromisso]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.TipoCompromisso])) m_FTipoCompromisso = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.TipoCompromisso]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.TipoCompromisso])) m_FTipoCompromisso = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.TipoCompromisso]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.TipoCompromisso])) m_FTipoCompromisso = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.TipoCompromisso]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.TipoCompromisso]))
            m_FTipoCompromisso = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.TipoCompromisso]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Cliente]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Cliente]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Cliente]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Cliente]))
            m_FCliente = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Cliente]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.DDias])) m_FDDias = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.DDias]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.DDias])) m_FDDias = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.DDias]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.DDias])) m_FDDias = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.DDias]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.DDias])) m_FDDias = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.DDias]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.DDias])) m_FDDias = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.DDias]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.DDias]))
            m_FDDias = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.DDias]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Dias])) m_FDias = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Dias]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Dias])) m_FDias = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Dias]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Dias])) m_FDias = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Dias]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Dias])) m_FDias = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Dias]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Dias])) m_FDias = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Dias]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Dias]))
            m_FDias = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Dias]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Liberado])) m_FLiberado = (bool)dbRec[DBAgendaFinanceiroDicInfo.Liberado]; if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Liberado])) m_FLiberado = (bool)dbRec[DBAgendaFinanceiroDicInfo.Liberado];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Liberado])) m_FLiberado = (bool)dbRec[DBAgendaFinanceiroDicInfo.Liberado]; if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Liberado])) m_FLiberado = (bool)dbRec[DBAgendaFinanceiroDicInfo.Liberado];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Liberado])) m_FLiberado = (bool)dbRec[DBAgendaFinanceiroDicInfo.Liberado]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Liberado]))
            m_FLiberado = (bool)dbRec[DBAgendaFinanceiroDicInfo.Liberado];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Importante])) m_FImportante = (bool)dbRec[DBAgendaFinanceiroDicInfo.Importante]; if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Importante])) m_FImportante = (bool)dbRec[DBAgendaFinanceiroDicInfo.Importante];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Importante])) m_FImportante = (bool)dbRec[DBAgendaFinanceiroDicInfo.Importante]; if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Importante])) m_FImportante = (bool)dbRec[DBAgendaFinanceiroDicInfo.Importante];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Importante])) m_FImportante = (bool)dbRec[DBAgendaFinanceiroDicInfo.Importante]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Importante]))
            m_FImportante = (bool)dbRec[DBAgendaFinanceiroDicInfo.Importante];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Concluido])) m_FConcluido = (bool)dbRec[DBAgendaFinanceiroDicInfo.Concluido]; if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Concluido])) m_FConcluido = (bool)dbRec[DBAgendaFinanceiroDicInfo.Concluido];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Concluido])) m_FConcluido = (bool)dbRec[DBAgendaFinanceiroDicInfo.Concluido]; if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Concluido])) m_FConcluido = (bool)dbRec[DBAgendaFinanceiroDicInfo.Concluido];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Concluido])) m_FConcluido = (bool)dbRec[DBAgendaFinanceiroDicInfo.Concluido]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Concluido]))
            m_FConcluido = (bool)dbRec[DBAgendaFinanceiroDicInfo.Concluido];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Area]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Area]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Area]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Area]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Area]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Area]))
            m_FArea = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Area]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Justica]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Justica]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Justica]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Justica]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Justica]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Justica]))
            m_FJustica = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Justica]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.IDHistorico])) m_FIDHistorico = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.IDHistorico]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.IDHistorico])) m_FIDHistorico = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.IDHistorico]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.IDHistorico])) m_FIDHistorico = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.IDHistorico]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.IDHistorico])) m_FIDHistorico = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.IDHistorico]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.IDHistorico])) m_FIDHistorico = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.IDHistorico]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.IDHistorico]))
            m_FIDHistorico = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.IDHistorico]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.IDInsProcesso])) m_FIDInsProcesso = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.IDInsProcesso]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.IDInsProcesso])) m_FIDInsProcesso = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.IDInsProcesso]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.IDInsProcesso])) m_FIDInsProcesso = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.IDInsProcesso]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.IDInsProcesso])) m_FIDInsProcesso = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.IDInsProcesso]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.IDInsProcesso])) m_FIDInsProcesso = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.IDInsProcesso]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.IDInsProcesso]))
            m_FIDInsProcesso = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.IDInsProcesso]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Usuario])) m_FUsuario = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Usuario]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Usuario])) m_FUsuario = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Usuario]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Usuario])) m_FUsuario = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Usuario]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Usuario])) m_FUsuario = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Usuario]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Usuario])) m_FUsuario = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Usuario]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Usuario]))
            m_FUsuario = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Usuario]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Preposto])) m_FPreposto = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Preposto]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Preposto])) m_FPreposto = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Preposto]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Preposto])) m_FPreposto = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Preposto]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Preposto])) m_FPreposto = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Preposto]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Preposto])) m_FPreposto = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Preposto]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Preposto]))
            m_FPreposto = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Preposto]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.QuemID])) m_FQuemID = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.QuemID]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.QuemID])) m_FQuemID = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.QuemID]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.QuemID])) m_FQuemID = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.QuemID]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.QuemID])) m_FQuemID = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.QuemID]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.QuemID])) m_FQuemID = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.QuemID]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.QuemID]))
            m_FQuemID = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.QuemID]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.QuemCodigo])) m_FQuemCodigo = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.QuemCodigo]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.QuemCodigo])) m_FQuemCodigo = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.QuemCodigo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.QuemCodigo])) m_FQuemCodigo = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.QuemCodigo]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.QuemCodigo])) m_FQuemCodigo = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.QuemCodigo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.QuemCodigo])) m_FQuemCodigo = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.QuemCodigo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.QuemCodigo]))
            m_FQuemCodigo = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.QuemCodigo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FStatus = dbRec[DBAgendaFinanceiroDicInfo.Status]?.ToString() ?? string.Empty; m_FStatus = dbRec[DBAgendaFinanceiroDicInfo.Status]?.ToString() ?? string.Empty;  } catch {}  try { m_FStatus = dbRec[DBAgendaFinanceiroDicInfo.Status]?.ToString() ?? string.Empty; m_FStatus = dbRec[DBAgendaFinanceiroDicInfo.Status]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FStatus = dbRec[DBAgendaFinanceiroDicInfo.Status]?.ToString() ?? string.Empty; } catch { }

#else
        m_FStatus = dbRec[DBAgendaFinanceiroDicInfo.Status]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBAgendaFinanceiroDicInfo.Valor]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBAgendaFinanceiroDicInfo.Valor]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBAgendaFinanceiroDicInfo.Valor]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBAgendaFinanceiroDicInfo.Valor]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBAgendaFinanceiroDicInfo.Valor]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Valor]))
            m_FValor = Convert.ToDecimal(dbRec[DBAgendaFinanceiroDicInfo.Valor]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCompromissoHTML = dbRec[DBAgendaFinanceiroDicInfo.CompromissoHTML]?.ToString() ?? string.Empty; m_FCompromissoHTML = dbRec[DBAgendaFinanceiroDicInfo.CompromissoHTML]?.ToString() ?? string.Empty;  } catch {}  try { m_FCompromissoHTML = dbRec[DBAgendaFinanceiroDicInfo.CompromissoHTML]?.ToString() ?? string.Empty; m_FCompromissoHTML = dbRec[DBAgendaFinanceiroDicInfo.CompromissoHTML]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCompromissoHTML = dbRec[DBAgendaFinanceiroDicInfo.CompromissoHTML]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCompromissoHTML = dbRec[DBAgendaFinanceiroDicInfo.CompromissoHTML]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FDecisao = dbRec[DBAgendaFinanceiroDicInfo.Decisao]?.ToString() ?? string.Empty; m_FDecisao = dbRec[DBAgendaFinanceiroDicInfo.Decisao]?.ToString() ?? string.Empty;  } catch {}  try { m_FDecisao = dbRec[DBAgendaFinanceiroDicInfo.Decisao]?.ToString() ?? string.Empty; m_FDecisao = dbRec[DBAgendaFinanceiroDicInfo.Decisao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FDecisao = dbRec[DBAgendaFinanceiroDicInfo.Decisao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FDecisao = dbRec[DBAgendaFinanceiroDicInfo.Decisao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Revisar])) m_FRevisar = (bool)dbRec[DBAgendaFinanceiroDicInfo.Revisar]; if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Revisar])) m_FRevisar = (bool)dbRec[DBAgendaFinanceiroDicInfo.Revisar];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Revisar])) m_FRevisar = (bool)dbRec[DBAgendaFinanceiroDicInfo.Revisar]; if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Revisar])) m_FRevisar = (bool)dbRec[DBAgendaFinanceiroDicInfo.Revisar];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Revisar])) m_FRevisar = (bool)dbRec[DBAgendaFinanceiroDicInfo.Revisar]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Revisar]))
            m_FRevisar = (bool)dbRec[DBAgendaFinanceiroDicInfo.Revisar];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.RevisarP2])) m_FRevisarP2 = (bool)dbRec[DBAgendaFinanceiroDicInfo.RevisarP2]; if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.RevisarP2])) m_FRevisarP2 = (bool)dbRec[DBAgendaFinanceiroDicInfo.RevisarP2];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.RevisarP2])) m_FRevisarP2 = (bool)dbRec[DBAgendaFinanceiroDicInfo.RevisarP2]; if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.RevisarP2])) m_FRevisarP2 = (bool)dbRec[DBAgendaFinanceiroDicInfo.RevisarP2];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.RevisarP2])) m_FRevisarP2 = (bool)dbRec[DBAgendaFinanceiroDicInfo.RevisarP2]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.RevisarP2]))
            m_FRevisarP2 = (bool)dbRec[DBAgendaFinanceiroDicInfo.RevisarP2];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Sempre])) m_FSempre = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Sempre]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Sempre])) m_FSempre = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Sempre]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Sempre])) m_FSempre = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Sempre]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Sempre])) m_FSempre = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Sempre]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Sempre])) m_FSempre = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Sempre]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Sempre]))
            m_FSempre = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.Sempre]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.PrazoDias])) m_FPrazoDias = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.PrazoDias]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.PrazoDias])) m_FPrazoDias = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.PrazoDias]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.PrazoDias])) m_FPrazoDias = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.PrazoDias]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.PrazoDias])) m_FPrazoDias = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.PrazoDias]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.PrazoDias])) m_FPrazoDias = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.PrazoDias]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.PrazoDias]))
            m_FPrazoDias = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.PrazoDias]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.ProtocoloIntegrado])) m_FProtocoloIntegrado = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.ProtocoloIntegrado]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.ProtocoloIntegrado])) m_FProtocoloIntegrado = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.ProtocoloIntegrado]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.ProtocoloIntegrado])) m_FProtocoloIntegrado = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.ProtocoloIntegrado]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.ProtocoloIntegrado])) m_FProtocoloIntegrado = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.ProtocoloIntegrado]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.ProtocoloIntegrado])) m_FProtocoloIntegrado = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.ProtocoloIntegrado]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.ProtocoloIntegrado]))
            m_FProtocoloIntegrado = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.ProtocoloIntegrado]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.DataInicioPrazo])) m_FDataInicioPrazo = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.DataInicioPrazo]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.DataInicioPrazo])) m_FDataInicioPrazo = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.DataInicioPrazo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.DataInicioPrazo])) m_FDataInicioPrazo = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.DataInicioPrazo]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.DataInicioPrazo])) m_FDataInicioPrazo = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.DataInicioPrazo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.DataInicioPrazo])) m_FDataInicioPrazo = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.DataInicioPrazo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.DataInicioPrazo]))
            m_FDataInicioPrazo = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.DataInicioPrazo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.UsuarioCiente])) m_FUsuarioCiente = (bool)dbRec[DBAgendaFinanceiroDicInfo.UsuarioCiente]; if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.UsuarioCiente])) m_FUsuarioCiente = (bool)dbRec[DBAgendaFinanceiroDicInfo.UsuarioCiente];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.UsuarioCiente])) m_FUsuarioCiente = (bool)dbRec[DBAgendaFinanceiroDicInfo.UsuarioCiente]; if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.UsuarioCiente])) m_FUsuarioCiente = (bool)dbRec[DBAgendaFinanceiroDicInfo.UsuarioCiente];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.UsuarioCiente])) m_FUsuarioCiente = (bool)dbRec[DBAgendaFinanceiroDicInfo.UsuarioCiente]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.UsuarioCiente]))
            m_FUsuarioCiente = (bool)dbRec[DBAgendaFinanceiroDicInfo.UsuarioCiente];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBAgendaFinanceiroDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBAgendaFinanceiroDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBAgendaFinanceiroDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBAgendaFinanceiroDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBAgendaFinanceiroDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBAgendaFinanceiroDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBAgendaFinanceiroDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBAgendaFinanceiroDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAgendaFinanceiroDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAgendaFinanceiroDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAgendaFinanceiroDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAgendaFinanceiroDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAgendaFinanceiroDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaFinanceiroDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBAgendaFinanceiroDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}