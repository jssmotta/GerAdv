namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBAgenda
{
    public DBAgenda(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Advogado]))
                m_FAdvogado = Convert.ToInt32(dbRec[DBAgendaDicInfo.Advogado]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Area]))
                m_FArea = Convert.ToInt32(dbRec[DBAgendaDicInfo.Area]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.CartaPrecatoria]))
                m_FCartaPrecatoria = Convert.ToInt32(dbRec[DBAgendaDicInfo.CartaPrecatoria]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Cidade]))
                m_FCidade = Convert.ToInt32(dbRec[DBAgendaDicInfo.Cidade]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Cliente]))
                m_FCliente = Convert.ToInt32(dbRec[DBAgendaDicInfo.Cliente]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.ClienteAvisado]))
                m_FClienteAvisado = (bool)dbRec[DBAgendaDicInfo.ClienteAvisado];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Concluido]))
                m_FConcluido = (bool)dbRec[DBAgendaDicInfo.Concluido];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Data]))
                m_FData = Convert.ToDateTime(dbRec[DBAgendaDicInfo.Data]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.DataInicioPrazo]))
                m_FDataInicioPrazo = Convert.ToDateTime(dbRec[DBAgendaDicInfo.DataInicioPrazo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBAgendaDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBAgendaDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.EventoData]))
                m_FEventoData = Convert.ToDateTime(dbRec[DBAgendaDicInfo.EventoData]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.EventoGerador]))
                m_FEventoGerador = Convert.ToInt32(dbRec[DBAgendaDicInfo.EventoGerador]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.EventoPrazo]))
                m_FEventoPrazo = Convert.ToInt32(dbRec[DBAgendaDicInfo.EventoPrazo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Funcionario]))
                m_FFuncionario = Convert.ToInt32(dbRec[DBAgendaDicInfo.Funcionario]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Hora]))
                m_FHora = Convert.ToDateTime(dbRec[DBAgendaDicInfo.Hora]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.HrFinal]))
                m_FHrFinal = Convert.ToDateTime(dbRec[DBAgendaDicInfo.HrFinal]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.IDCOB]))
                m_FIDCOB = Convert.ToInt32(dbRec[DBAgendaDicInfo.IDCOB]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.IDHistorico]))
                m_FIDHistorico = Convert.ToInt32(dbRec[DBAgendaDicInfo.IDHistorico]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.IDInsProcesso]))
                m_FIDInsProcesso = Convert.ToInt32(dbRec[DBAgendaDicInfo.IDInsProcesso]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.IDNE]))
                m_FIDNE = Convert.ToInt32(dbRec[DBAgendaDicInfo.IDNE]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Importante]))
                m_FImportante = (bool)dbRec[DBAgendaDicInfo.Importante];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Justica]))
                m_FJustica = Convert.ToInt32(dbRec[DBAgendaDicInfo.Justica]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Liberado]))
                m_FLiberado = (bool)dbRec[DBAgendaDicInfo.Liberado];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Oculto]))
                m_FOculto = Convert.ToInt32(dbRec[DBAgendaDicInfo.Oculto]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.PrazoDias]))
                m_FPrazoDias = Convert.ToInt32(dbRec[DBAgendaDicInfo.PrazoDias]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Preposto]))
                m_FPreposto = Convert.ToInt32(dbRec[DBAgendaDicInfo.Preposto]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBAgendaDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.ProtocoloIntegrado]))
                m_FProtocoloIntegrado = Convert.ToInt32(dbRec[DBAgendaDicInfo.ProtocoloIntegrado]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBAgendaDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBAgendaDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.QuemCodigo]))
                m_FQuemCodigo = Convert.ToInt32(dbRec[DBAgendaDicInfo.QuemCodigo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.QuemID]))
                m_FQuemID = Convert.ToInt32(dbRec[DBAgendaDicInfo.QuemID]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Revisar]))
                m_FRevisar = (bool)dbRec[DBAgendaDicInfo.Revisar];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.RevisarP2]))
                m_FRevisarP2 = (bool)dbRec[DBAgendaDicInfo.RevisarP2];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Sempre]))
                m_FSempre = Convert.ToInt32(dbRec[DBAgendaDicInfo.Sempre]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.TipoCompromisso]))
                m_FTipoCompromisso = Convert.ToInt32(dbRec[DBAgendaDicInfo.TipoCompromisso]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Usuario]))
                m_FUsuario = Convert.ToInt32(dbRec[DBAgendaDicInfo.Usuario]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.UsuarioCiente]))
                m_FUsuarioCiente = (bool)dbRec[DBAgendaDicInfo.UsuarioCiente];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Valor]))
                m_FValor = Convert.ToDecimal(dbRec[DBAgendaDicInfo.Valor]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBAgendaDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FCompromisso = dbRec[DBAgendaDicInfo.Compromisso]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FDecisao = dbRec[DBAgendaDicInfo.Decisao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBAgendaDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FStatus = dbRec[DBAgendaDicInfo.Status]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBAgenda(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Advogado]))
                m_FAdvogado = Convert.ToInt32(dbRec[DBAgendaDicInfo.Advogado]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Area]))
                m_FArea = Convert.ToInt32(dbRec[DBAgendaDicInfo.Area]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.CartaPrecatoria]))
                m_FCartaPrecatoria = Convert.ToInt32(dbRec[DBAgendaDicInfo.CartaPrecatoria]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Cidade]))
                m_FCidade = Convert.ToInt32(dbRec[DBAgendaDicInfo.Cidade]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Cliente]))
                m_FCliente = Convert.ToInt32(dbRec[DBAgendaDicInfo.Cliente]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.ClienteAvisado]))
                m_FClienteAvisado = (bool)dbRec[DBAgendaDicInfo.ClienteAvisado];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Concluido]))
                m_FConcluido = (bool)dbRec[DBAgendaDicInfo.Concluido];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Data]))
                m_FData = Convert.ToDateTime(dbRec[DBAgendaDicInfo.Data]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.DataInicioPrazo]))
                m_FDataInicioPrazo = Convert.ToDateTime(dbRec[DBAgendaDicInfo.DataInicioPrazo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBAgendaDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBAgendaDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.EventoData]))
                m_FEventoData = Convert.ToDateTime(dbRec[DBAgendaDicInfo.EventoData]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.EventoGerador]))
                m_FEventoGerador = Convert.ToInt32(dbRec[DBAgendaDicInfo.EventoGerador]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.EventoPrazo]))
                m_FEventoPrazo = Convert.ToInt32(dbRec[DBAgendaDicInfo.EventoPrazo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Funcionario]))
                m_FFuncionario = Convert.ToInt32(dbRec[DBAgendaDicInfo.Funcionario]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Hora]))
                m_FHora = Convert.ToDateTime(dbRec[DBAgendaDicInfo.Hora]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.HrFinal]))
                m_FHrFinal = Convert.ToDateTime(dbRec[DBAgendaDicInfo.HrFinal]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.IDCOB]))
                m_FIDCOB = Convert.ToInt32(dbRec[DBAgendaDicInfo.IDCOB]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.IDHistorico]))
                m_FIDHistorico = Convert.ToInt32(dbRec[DBAgendaDicInfo.IDHistorico]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.IDInsProcesso]))
                m_FIDInsProcesso = Convert.ToInt32(dbRec[DBAgendaDicInfo.IDInsProcesso]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.IDNE]))
                m_FIDNE = Convert.ToInt32(dbRec[DBAgendaDicInfo.IDNE]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Importante]))
                m_FImportante = (bool)dbRec[DBAgendaDicInfo.Importante];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Justica]))
                m_FJustica = Convert.ToInt32(dbRec[DBAgendaDicInfo.Justica]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Liberado]))
                m_FLiberado = (bool)dbRec[DBAgendaDicInfo.Liberado];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Oculto]))
                m_FOculto = Convert.ToInt32(dbRec[DBAgendaDicInfo.Oculto]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.PrazoDias]))
                m_FPrazoDias = Convert.ToInt32(dbRec[DBAgendaDicInfo.PrazoDias]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Preposto]))
                m_FPreposto = Convert.ToInt32(dbRec[DBAgendaDicInfo.Preposto]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBAgendaDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.ProtocoloIntegrado]))
                m_FProtocoloIntegrado = Convert.ToInt32(dbRec[DBAgendaDicInfo.ProtocoloIntegrado]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBAgendaDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBAgendaDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.QuemCodigo]))
                m_FQuemCodigo = Convert.ToInt32(dbRec[DBAgendaDicInfo.QuemCodigo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.QuemID]))
                m_FQuemID = Convert.ToInt32(dbRec[DBAgendaDicInfo.QuemID]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Revisar]))
                m_FRevisar = (bool)dbRec[DBAgendaDicInfo.Revisar];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.RevisarP2]))
                m_FRevisarP2 = (bool)dbRec[DBAgendaDicInfo.RevisarP2];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Sempre]))
                m_FSempre = Convert.ToInt32(dbRec[DBAgendaDicInfo.Sempre]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.TipoCompromisso]))
                m_FTipoCompromisso = Convert.ToInt32(dbRec[DBAgendaDicInfo.TipoCompromisso]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Usuario]))
                m_FUsuario = Convert.ToInt32(dbRec[DBAgendaDicInfo.Usuario]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.UsuarioCiente]))
                m_FUsuarioCiente = (bool)dbRec[DBAgendaDicInfo.UsuarioCiente];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Valor]))
                m_FValor = Convert.ToDecimal(dbRec[DBAgendaDicInfo.Valor]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBAgendaDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FCompromisso = dbRec[DBAgendaDicInfo.Compromisso]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FDecisao = dbRec[DBAgendaDicInfo.Decisao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBAgendaDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FStatus = dbRec[DBAgendaDicInfo.Status]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_Agenda
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [ageCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.IDCOB])) m_FIDCOB = Convert.ToInt32(dbRec[DBAgendaDicInfo.IDCOB]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.IDCOB])) m_FIDCOB = Convert.ToInt32(dbRec[DBAgendaDicInfo.IDCOB]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.IDCOB])) m_FIDCOB = Convert.ToInt32(dbRec[DBAgendaDicInfo.IDCOB]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.IDCOB])) m_FIDCOB = Convert.ToInt32(dbRec[DBAgendaDicInfo.IDCOB]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.IDCOB])) m_FIDCOB = Convert.ToInt32(dbRec[DBAgendaDicInfo.IDCOB]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.IDCOB]))
            m_FIDCOB = Convert.ToInt32(dbRec[DBAgendaDicInfo.IDCOB]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.ClienteAvisado])) m_FClienteAvisado = (bool)dbRec[DBAgendaDicInfo.ClienteAvisado]; if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.ClienteAvisado])) m_FClienteAvisado = (bool)dbRec[DBAgendaDicInfo.ClienteAvisado];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.ClienteAvisado])) m_FClienteAvisado = (bool)dbRec[DBAgendaDicInfo.ClienteAvisado]; if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.ClienteAvisado])) m_FClienteAvisado = (bool)dbRec[DBAgendaDicInfo.ClienteAvisado];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.ClienteAvisado])) m_FClienteAvisado = (bool)dbRec[DBAgendaDicInfo.ClienteAvisado]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.ClienteAvisado]))
            m_FClienteAvisado = (bool)dbRec[DBAgendaDicInfo.ClienteAvisado];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.RevisarP2])) m_FRevisarP2 = (bool)dbRec[DBAgendaDicInfo.RevisarP2]; if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.RevisarP2])) m_FRevisarP2 = (bool)dbRec[DBAgendaDicInfo.RevisarP2];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.RevisarP2])) m_FRevisarP2 = (bool)dbRec[DBAgendaDicInfo.RevisarP2]; if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.RevisarP2])) m_FRevisarP2 = (bool)dbRec[DBAgendaDicInfo.RevisarP2];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.RevisarP2])) m_FRevisarP2 = (bool)dbRec[DBAgendaDicInfo.RevisarP2]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.RevisarP2]))
            m_FRevisarP2 = (bool)dbRec[DBAgendaDicInfo.RevisarP2];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.IDNE])) m_FIDNE = Convert.ToInt32(dbRec[DBAgendaDicInfo.IDNE]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.IDNE])) m_FIDNE = Convert.ToInt32(dbRec[DBAgendaDicInfo.IDNE]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.IDNE])) m_FIDNE = Convert.ToInt32(dbRec[DBAgendaDicInfo.IDNE]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.IDNE])) m_FIDNE = Convert.ToInt32(dbRec[DBAgendaDicInfo.IDNE]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.IDNE])) m_FIDNE = Convert.ToInt32(dbRec[DBAgendaDicInfo.IDNE]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.IDNE]))
            m_FIDNE = Convert.ToInt32(dbRec[DBAgendaDicInfo.IDNE]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBAgendaDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBAgendaDicInfo.Cidade]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBAgendaDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBAgendaDicInfo.Cidade]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBAgendaDicInfo.Cidade]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Cidade]))
            m_FCidade = Convert.ToInt32(dbRec[DBAgendaDicInfo.Cidade]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Oculto])) m_FOculto = Convert.ToInt32(dbRec[DBAgendaDicInfo.Oculto]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Oculto])) m_FOculto = Convert.ToInt32(dbRec[DBAgendaDicInfo.Oculto]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Oculto])) m_FOculto = Convert.ToInt32(dbRec[DBAgendaDicInfo.Oculto]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Oculto])) m_FOculto = Convert.ToInt32(dbRec[DBAgendaDicInfo.Oculto]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Oculto])) m_FOculto = Convert.ToInt32(dbRec[DBAgendaDicInfo.Oculto]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Oculto]))
            m_FOculto = Convert.ToInt32(dbRec[DBAgendaDicInfo.Oculto]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.CartaPrecatoria])) m_FCartaPrecatoria = Convert.ToInt32(dbRec[DBAgendaDicInfo.CartaPrecatoria]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.CartaPrecatoria])) m_FCartaPrecatoria = Convert.ToInt32(dbRec[DBAgendaDicInfo.CartaPrecatoria]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.CartaPrecatoria])) m_FCartaPrecatoria = Convert.ToInt32(dbRec[DBAgendaDicInfo.CartaPrecatoria]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.CartaPrecatoria])) m_FCartaPrecatoria = Convert.ToInt32(dbRec[DBAgendaDicInfo.CartaPrecatoria]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.CartaPrecatoria])) m_FCartaPrecatoria = Convert.ToInt32(dbRec[DBAgendaDicInfo.CartaPrecatoria]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.CartaPrecatoria]))
            m_FCartaPrecatoria = Convert.ToInt32(dbRec[DBAgendaDicInfo.CartaPrecatoria]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Revisar])) m_FRevisar = (bool)dbRec[DBAgendaDicInfo.Revisar]; if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Revisar])) m_FRevisar = (bool)dbRec[DBAgendaDicInfo.Revisar];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Revisar])) m_FRevisar = (bool)dbRec[DBAgendaDicInfo.Revisar]; if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Revisar])) m_FRevisar = (bool)dbRec[DBAgendaDicInfo.Revisar];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Revisar])) m_FRevisar = (bool)dbRec[DBAgendaDicInfo.Revisar]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Revisar]))
            m_FRevisar = (bool)dbRec[DBAgendaDicInfo.Revisar];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.HrFinal])) m_FHrFinal = Convert.ToDateTime(dbRec[DBAgendaDicInfo.HrFinal]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.HrFinal])) m_FHrFinal = Convert.ToDateTime(dbRec[DBAgendaDicInfo.HrFinal]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.HrFinal])) m_FHrFinal = Convert.ToDateTime(dbRec[DBAgendaDicInfo.HrFinal]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.HrFinal])) m_FHrFinal = Convert.ToDateTime(dbRec[DBAgendaDicInfo.HrFinal]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.HrFinal])) m_FHrFinal = Convert.ToDateTime(dbRec[DBAgendaDicInfo.HrFinal]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.HrFinal]))
            m_FHrFinal = Convert.ToDateTime(dbRec[DBAgendaDicInfo.HrFinal]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBAgendaDicInfo.Advogado]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBAgendaDicInfo.Advogado]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBAgendaDicInfo.Advogado]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBAgendaDicInfo.Advogado]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBAgendaDicInfo.Advogado]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Advogado]))
            m_FAdvogado = Convert.ToInt32(dbRec[DBAgendaDicInfo.Advogado]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.EventoGerador])) m_FEventoGerador = Convert.ToInt32(dbRec[DBAgendaDicInfo.EventoGerador]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.EventoGerador])) m_FEventoGerador = Convert.ToInt32(dbRec[DBAgendaDicInfo.EventoGerador]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.EventoGerador])) m_FEventoGerador = Convert.ToInt32(dbRec[DBAgendaDicInfo.EventoGerador]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.EventoGerador])) m_FEventoGerador = Convert.ToInt32(dbRec[DBAgendaDicInfo.EventoGerador]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.EventoGerador])) m_FEventoGerador = Convert.ToInt32(dbRec[DBAgendaDicInfo.EventoGerador]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.EventoGerador]))
            m_FEventoGerador = Convert.ToInt32(dbRec[DBAgendaDicInfo.EventoGerador]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.EventoData])) m_FEventoData = Convert.ToDateTime(dbRec[DBAgendaDicInfo.EventoData]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.EventoData])) m_FEventoData = Convert.ToDateTime(dbRec[DBAgendaDicInfo.EventoData]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.EventoData])) m_FEventoData = Convert.ToDateTime(dbRec[DBAgendaDicInfo.EventoData]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.EventoData])) m_FEventoData = Convert.ToDateTime(dbRec[DBAgendaDicInfo.EventoData]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.EventoData])) m_FEventoData = Convert.ToDateTime(dbRec[DBAgendaDicInfo.EventoData]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.EventoData]))
            m_FEventoData = Convert.ToDateTime(dbRec[DBAgendaDicInfo.EventoData]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Funcionario])) m_FFuncionario = Convert.ToInt32(dbRec[DBAgendaDicInfo.Funcionario]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Funcionario])) m_FFuncionario = Convert.ToInt32(dbRec[DBAgendaDicInfo.Funcionario]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Funcionario])) m_FFuncionario = Convert.ToInt32(dbRec[DBAgendaDicInfo.Funcionario]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Funcionario])) m_FFuncionario = Convert.ToInt32(dbRec[DBAgendaDicInfo.Funcionario]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Funcionario])) m_FFuncionario = Convert.ToInt32(dbRec[DBAgendaDicInfo.Funcionario]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Funcionario]))
            m_FFuncionario = Convert.ToInt32(dbRec[DBAgendaDicInfo.Funcionario]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBAgendaDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBAgendaDicInfo.Data]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBAgendaDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBAgendaDicInfo.Data]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBAgendaDicInfo.Data]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Data]))
            m_FData = Convert.ToDateTime(dbRec[DBAgendaDicInfo.Data]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.EventoPrazo])) m_FEventoPrazo = Convert.ToInt32(dbRec[DBAgendaDicInfo.EventoPrazo]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.EventoPrazo])) m_FEventoPrazo = Convert.ToInt32(dbRec[DBAgendaDicInfo.EventoPrazo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.EventoPrazo])) m_FEventoPrazo = Convert.ToInt32(dbRec[DBAgendaDicInfo.EventoPrazo]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.EventoPrazo])) m_FEventoPrazo = Convert.ToInt32(dbRec[DBAgendaDicInfo.EventoPrazo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.EventoPrazo])) m_FEventoPrazo = Convert.ToInt32(dbRec[DBAgendaDicInfo.EventoPrazo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.EventoPrazo]))
            m_FEventoPrazo = Convert.ToInt32(dbRec[DBAgendaDicInfo.EventoPrazo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBAgendaDicInfo.Hora]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBAgendaDicInfo.Hora]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBAgendaDicInfo.Hora]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBAgendaDicInfo.Hora]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBAgendaDicInfo.Hora]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Hora]))
            m_FHora = Convert.ToDateTime(dbRec[DBAgendaDicInfo.Hora]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCompromisso = dbRec[DBAgendaDicInfo.Compromisso]?.ToString() ?? string.Empty; m_FCompromisso = dbRec[DBAgendaDicInfo.Compromisso]?.ToString() ?? string.Empty;  } catch {}  try { m_FCompromisso = dbRec[DBAgendaDicInfo.Compromisso]?.ToString() ?? string.Empty; m_FCompromisso = dbRec[DBAgendaDicInfo.Compromisso]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCompromisso = dbRec[DBAgendaDicInfo.Compromisso]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCompromisso = dbRec[DBAgendaDicInfo.Compromisso]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.TipoCompromisso])) m_FTipoCompromisso = Convert.ToInt32(dbRec[DBAgendaDicInfo.TipoCompromisso]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.TipoCompromisso])) m_FTipoCompromisso = Convert.ToInt32(dbRec[DBAgendaDicInfo.TipoCompromisso]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.TipoCompromisso])) m_FTipoCompromisso = Convert.ToInt32(dbRec[DBAgendaDicInfo.TipoCompromisso]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.TipoCompromisso])) m_FTipoCompromisso = Convert.ToInt32(dbRec[DBAgendaDicInfo.TipoCompromisso]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.TipoCompromisso])) m_FTipoCompromisso = Convert.ToInt32(dbRec[DBAgendaDicInfo.TipoCompromisso]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.TipoCompromisso]))
            m_FTipoCompromisso = Convert.ToInt32(dbRec[DBAgendaDicInfo.TipoCompromisso]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBAgendaDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBAgendaDicInfo.Cliente]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBAgendaDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBAgendaDicInfo.Cliente]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBAgendaDicInfo.Cliente]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Cliente]))
            m_FCliente = Convert.ToInt32(dbRec[DBAgendaDicInfo.Cliente]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Liberado])) m_FLiberado = (bool)dbRec[DBAgendaDicInfo.Liberado]; if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Liberado])) m_FLiberado = (bool)dbRec[DBAgendaDicInfo.Liberado];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Liberado])) m_FLiberado = (bool)dbRec[DBAgendaDicInfo.Liberado]; if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Liberado])) m_FLiberado = (bool)dbRec[DBAgendaDicInfo.Liberado];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Liberado])) m_FLiberado = (bool)dbRec[DBAgendaDicInfo.Liberado]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Liberado]))
            m_FLiberado = (bool)dbRec[DBAgendaDicInfo.Liberado];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Importante])) m_FImportante = (bool)dbRec[DBAgendaDicInfo.Importante]; if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Importante])) m_FImportante = (bool)dbRec[DBAgendaDicInfo.Importante];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Importante])) m_FImportante = (bool)dbRec[DBAgendaDicInfo.Importante]; if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Importante])) m_FImportante = (bool)dbRec[DBAgendaDicInfo.Importante];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Importante])) m_FImportante = (bool)dbRec[DBAgendaDicInfo.Importante]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Importante]))
            m_FImportante = (bool)dbRec[DBAgendaDicInfo.Importante];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Concluido])) m_FConcluido = (bool)dbRec[DBAgendaDicInfo.Concluido]; if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Concluido])) m_FConcluido = (bool)dbRec[DBAgendaDicInfo.Concluido];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Concluido])) m_FConcluido = (bool)dbRec[DBAgendaDicInfo.Concluido]; if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Concluido])) m_FConcluido = (bool)dbRec[DBAgendaDicInfo.Concluido];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Concluido])) m_FConcluido = (bool)dbRec[DBAgendaDicInfo.Concluido]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Concluido]))
            m_FConcluido = (bool)dbRec[DBAgendaDicInfo.Concluido];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBAgendaDicInfo.Area]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBAgendaDicInfo.Area]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBAgendaDicInfo.Area]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBAgendaDicInfo.Area]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBAgendaDicInfo.Area]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Area]))
            m_FArea = Convert.ToInt32(dbRec[DBAgendaDicInfo.Area]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBAgendaDicInfo.Justica]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBAgendaDicInfo.Justica]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBAgendaDicInfo.Justica]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBAgendaDicInfo.Justica]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBAgendaDicInfo.Justica]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Justica]))
            m_FJustica = Convert.ToInt32(dbRec[DBAgendaDicInfo.Justica]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBAgendaDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBAgendaDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBAgendaDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBAgendaDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBAgendaDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBAgendaDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.IDHistorico])) m_FIDHistorico = Convert.ToInt32(dbRec[DBAgendaDicInfo.IDHistorico]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.IDHistorico])) m_FIDHistorico = Convert.ToInt32(dbRec[DBAgendaDicInfo.IDHistorico]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.IDHistorico])) m_FIDHistorico = Convert.ToInt32(dbRec[DBAgendaDicInfo.IDHistorico]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.IDHistorico])) m_FIDHistorico = Convert.ToInt32(dbRec[DBAgendaDicInfo.IDHistorico]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.IDHistorico])) m_FIDHistorico = Convert.ToInt32(dbRec[DBAgendaDicInfo.IDHistorico]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.IDHistorico]))
            m_FIDHistorico = Convert.ToInt32(dbRec[DBAgendaDicInfo.IDHistorico]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.IDInsProcesso])) m_FIDInsProcesso = Convert.ToInt32(dbRec[DBAgendaDicInfo.IDInsProcesso]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.IDInsProcesso])) m_FIDInsProcesso = Convert.ToInt32(dbRec[DBAgendaDicInfo.IDInsProcesso]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.IDInsProcesso])) m_FIDInsProcesso = Convert.ToInt32(dbRec[DBAgendaDicInfo.IDInsProcesso]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.IDInsProcesso])) m_FIDInsProcesso = Convert.ToInt32(dbRec[DBAgendaDicInfo.IDInsProcesso]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.IDInsProcesso])) m_FIDInsProcesso = Convert.ToInt32(dbRec[DBAgendaDicInfo.IDInsProcesso]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.IDInsProcesso]))
            m_FIDInsProcesso = Convert.ToInt32(dbRec[DBAgendaDicInfo.IDInsProcesso]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Usuario])) m_FUsuario = Convert.ToInt32(dbRec[DBAgendaDicInfo.Usuario]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Usuario])) m_FUsuario = Convert.ToInt32(dbRec[DBAgendaDicInfo.Usuario]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Usuario])) m_FUsuario = Convert.ToInt32(dbRec[DBAgendaDicInfo.Usuario]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Usuario])) m_FUsuario = Convert.ToInt32(dbRec[DBAgendaDicInfo.Usuario]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Usuario])) m_FUsuario = Convert.ToInt32(dbRec[DBAgendaDicInfo.Usuario]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Usuario]))
            m_FUsuario = Convert.ToInt32(dbRec[DBAgendaDicInfo.Usuario]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Preposto])) m_FPreposto = Convert.ToInt32(dbRec[DBAgendaDicInfo.Preposto]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Preposto])) m_FPreposto = Convert.ToInt32(dbRec[DBAgendaDicInfo.Preposto]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Preposto])) m_FPreposto = Convert.ToInt32(dbRec[DBAgendaDicInfo.Preposto]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Preposto])) m_FPreposto = Convert.ToInt32(dbRec[DBAgendaDicInfo.Preposto]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Preposto])) m_FPreposto = Convert.ToInt32(dbRec[DBAgendaDicInfo.Preposto]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Preposto]))
            m_FPreposto = Convert.ToInt32(dbRec[DBAgendaDicInfo.Preposto]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.QuemID])) m_FQuemID = Convert.ToInt32(dbRec[DBAgendaDicInfo.QuemID]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.QuemID])) m_FQuemID = Convert.ToInt32(dbRec[DBAgendaDicInfo.QuemID]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.QuemID])) m_FQuemID = Convert.ToInt32(dbRec[DBAgendaDicInfo.QuemID]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.QuemID])) m_FQuemID = Convert.ToInt32(dbRec[DBAgendaDicInfo.QuemID]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.QuemID])) m_FQuemID = Convert.ToInt32(dbRec[DBAgendaDicInfo.QuemID]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.QuemID]))
            m_FQuemID = Convert.ToInt32(dbRec[DBAgendaDicInfo.QuemID]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.QuemCodigo])) m_FQuemCodigo = Convert.ToInt32(dbRec[DBAgendaDicInfo.QuemCodigo]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.QuemCodigo])) m_FQuemCodigo = Convert.ToInt32(dbRec[DBAgendaDicInfo.QuemCodigo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.QuemCodigo])) m_FQuemCodigo = Convert.ToInt32(dbRec[DBAgendaDicInfo.QuemCodigo]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.QuemCodigo])) m_FQuemCodigo = Convert.ToInt32(dbRec[DBAgendaDicInfo.QuemCodigo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.QuemCodigo])) m_FQuemCodigo = Convert.ToInt32(dbRec[DBAgendaDicInfo.QuemCodigo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.QuemCodigo]))
            m_FQuemCodigo = Convert.ToInt32(dbRec[DBAgendaDicInfo.QuemCodigo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FStatus = dbRec[DBAgendaDicInfo.Status]?.ToString() ?? string.Empty; m_FStatus = dbRec[DBAgendaDicInfo.Status]?.ToString() ?? string.Empty;  } catch {}  try { m_FStatus = dbRec[DBAgendaDicInfo.Status]?.ToString() ?? string.Empty; m_FStatus = dbRec[DBAgendaDicInfo.Status]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FStatus = dbRec[DBAgendaDicInfo.Status]?.ToString() ?? string.Empty; } catch { }

#else
        m_FStatus = dbRec[DBAgendaDicInfo.Status]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBAgendaDicInfo.Valor]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBAgendaDicInfo.Valor]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBAgendaDicInfo.Valor]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBAgendaDicInfo.Valor]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBAgendaDicInfo.Valor]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Valor]))
            m_FValor = Convert.ToDecimal(dbRec[DBAgendaDicInfo.Valor]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FDecisao = dbRec[DBAgendaDicInfo.Decisao]?.ToString() ?? string.Empty; m_FDecisao = dbRec[DBAgendaDicInfo.Decisao]?.ToString() ?? string.Empty;  } catch {}  try { m_FDecisao = dbRec[DBAgendaDicInfo.Decisao]?.ToString() ?? string.Empty; m_FDecisao = dbRec[DBAgendaDicInfo.Decisao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FDecisao = dbRec[DBAgendaDicInfo.Decisao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FDecisao = dbRec[DBAgendaDicInfo.Decisao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Sempre])) m_FSempre = Convert.ToInt32(dbRec[DBAgendaDicInfo.Sempre]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Sempre])) m_FSempre = Convert.ToInt32(dbRec[DBAgendaDicInfo.Sempre]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Sempre])) m_FSempre = Convert.ToInt32(dbRec[DBAgendaDicInfo.Sempre]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Sempre])) m_FSempre = Convert.ToInt32(dbRec[DBAgendaDicInfo.Sempre]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Sempre])) m_FSempre = Convert.ToInt32(dbRec[DBAgendaDicInfo.Sempre]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Sempre]))
            m_FSempre = Convert.ToInt32(dbRec[DBAgendaDicInfo.Sempre]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.PrazoDias])) m_FPrazoDias = Convert.ToInt32(dbRec[DBAgendaDicInfo.PrazoDias]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.PrazoDias])) m_FPrazoDias = Convert.ToInt32(dbRec[DBAgendaDicInfo.PrazoDias]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.PrazoDias])) m_FPrazoDias = Convert.ToInt32(dbRec[DBAgendaDicInfo.PrazoDias]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.PrazoDias])) m_FPrazoDias = Convert.ToInt32(dbRec[DBAgendaDicInfo.PrazoDias]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.PrazoDias])) m_FPrazoDias = Convert.ToInt32(dbRec[DBAgendaDicInfo.PrazoDias]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.PrazoDias]))
            m_FPrazoDias = Convert.ToInt32(dbRec[DBAgendaDicInfo.PrazoDias]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.ProtocoloIntegrado])) m_FProtocoloIntegrado = Convert.ToInt32(dbRec[DBAgendaDicInfo.ProtocoloIntegrado]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.ProtocoloIntegrado])) m_FProtocoloIntegrado = Convert.ToInt32(dbRec[DBAgendaDicInfo.ProtocoloIntegrado]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.ProtocoloIntegrado])) m_FProtocoloIntegrado = Convert.ToInt32(dbRec[DBAgendaDicInfo.ProtocoloIntegrado]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.ProtocoloIntegrado])) m_FProtocoloIntegrado = Convert.ToInt32(dbRec[DBAgendaDicInfo.ProtocoloIntegrado]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.ProtocoloIntegrado])) m_FProtocoloIntegrado = Convert.ToInt32(dbRec[DBAgendaDicInfo.ProtocoloIntegrado]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.ProtocoloIntegrado]))
            m_FProtocoloIntegrado = Convert.ToInt32(dbRec[DBAgendaDicInfo.ProtocoloIntegrado]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.DataInicioPrazo])) m_FDataInicioPrazo = Convert.ToDateTime(dbRec[DBAgendaDicInfo.DataInicioPrazo]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.DataInicioPrazo])) m_FDataInicioPrazo = Convert.ToDateTime(dbRec[DBAgendaDicInfo.DataInicioPrazo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.DataInicioPrazo])) m_FDataInicioPrazo = Convert.ToDateTime(dbRec[DBAgendaDicInfo.DataInicioPrazo]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.DataInicioPrazo])) m_FDataInicioPrazo = Convert.ToDateTime(dbRec[DBAgendaDicInfo.DataInicioPrazo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.DataInicioPrazo])) m_FDataInicioPrazo = Convert.ToDateTime(dbRec[DBAgendaDicInfo.DataInicioPrazo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.DataInicioPrazo]))
            m_FDataInicioPrazo = Convert.ToDateTime(dbRec[DBAgendaDicInfo.DataInicioPrazo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.UsuarioCiente])) m_FUsuarioCiente = (bool)dbRec[DBAgendaDicInfo.UsuarioCiente]; if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.UsuarioCiente])) m_FUsuarioCiente = (bool)dbRec[DBAgendaDicInfo.UsuarioCiente];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.UsuarioCiente])) m_FUsuarioCiente = (bool)dbRec[DBAgendaDicInfo.UsuarioCiente]; if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.UsuarioCiente])) m_FUsuarioCiente = (bool)dbRec[DBAgendaDicInfo.UsuarioCiente];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.UsuarioCiente])) m_FUsuarioCiente = (bool)dbRec[DBAgendaDicInfo.UsuarioCiente]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.UsuarioCiente]))
            m_FUsuarioCiente = (bool)dbRec[DBAgendaDicInfo.UsuarioCiente];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBAgendaDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBAgendaDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBAgendaDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBAgendaDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBAgendaDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBAgendaDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAgendaDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAgendaDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAgendaDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAgendaDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAgendaDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBAgendaDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAgendaDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAgendaDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAgendaDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAgendaDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAgendaDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBAgendaDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAgendaDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAgendaDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAgendaDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAgendaDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAgendaDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBAgendaDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAgendaDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAgendaDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAgendaDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAgendaDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAgendaDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBAgendaDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAgendaDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAgendaDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAgendaDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAgendaDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAgendaDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBAgendaDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_Agenda
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
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.IDCOB])) m_FIDCOB = Convert.ToInt32(dbRec[DBAgendaDicInfo.IDCOB]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.IDCOB])) m_FIDCOB = Convert.ToInt32(dbRec[DBAgendaDicInfo.IDCOB]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.IDCOB])) m_FIDCOB = Convert.ToInt32(dbRec[DBAgendaDicInfo.IDCOB]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.IDCOB])) m_FIDCOB = Convert.ToInt32(dbRec[DBAgendaDicInfo.IDCOB]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.IDCOB])) m_FIDCOB = Convert.ToInt32(dbRec[DBAgendaDicInfo.IDCOB]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.IDCOB]))
            m_FIDCOB = Convert.ToInt32(dbRec[DBAgendaDicInfo.IDCOB]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.ClienteAvisado])) m_FClienteAvisado = (bool)dbRec[DBAgendaDicInfo.ClienteAvisado]; if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.ClienteAvisado])) m_FClienteAvisado = (bool)dbRec[DBAgendaDicInfo.ClienteAvisado];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.ClienteAvisado])) m_FClienteAvisado = (bool)dbRec[DBAgendaDicInfo.ClienteAvisado]; if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.ClienteAvisado])) m_FClienteAvisado = (bool)dbRec[DBAgendaDicInfo.ClienteAvisado];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.ClienteAvisado])) m_FClienteAvisado = (bool)dbRec[DBAgendaDicInfo.ClienteAvisado]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.ClienteAvisado]))
            m_FClienteAvisado = (bool)dbRec[DBAgendaDicInfo.ClienteAvisado];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.RevisarP2])) m_FRevisarP2 = (bool)dbRec[DBAgendaDicInfo.RevisarP2]; if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.RevisarP2])) m_FRevisarP2 = (bool)dbRec[DBAgendaDicInfo.RevisarP2];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.RevisarP2])) m_FRevisarP2 = (bool)dbRec[DBAgendaDicInfo.RevisarP2]; if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.RevisarP2])) m_FRevisarP2 = (bool)dbRec[DBAgendaDicInfo.RevisarP2];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.RevisarP2])) m_FRevisarP2 = (bool)dbRec[DBAgendaDicInfo.RevisarP2]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.RevisarP2]))
            m_FRevisarP2 = (bool)dbRec[DBAgendaDicInfo.RevisarP2];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.IDNE])) m_FIDNE = Convert.ToInt32(dbRec[DBAgendaDicInfo.IDNE]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.IDNE])) m_FIDNE = Convert.ToInt32(dbRec[DBAgendaDicInfo.IDNE]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.IDNE])) m_FIDNE = Convert.ToInt32(dbRec[DBAgendaDicInfo.IDNE]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.IDNE])) m_FIDNE = Convert.ToInt32(dbRec[DBAgendaDicInfo.IDNE]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.IDNE])) m_FIDNE = Convert.ToInt32(dbRec[DBAgendaDicInfo.IDNE]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.IDNE]))
            m_FIDNE = Convert.ToInt32(dbRec[DBAgendaDicInfo.IDNE]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBAgendaDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBAgendaDicInfo.Cidade]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBAgendaDicInfo.Cidade]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBAgendaDicInfo.Cidade]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Cidade])) m_FCidade = Convert.ToInt32(dbRec[DBAgendaDicInfo.Cidade]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Cidade]))
            m_FCidade = Convert.ToInt32(dbRec[DBAgendaDicInfo.Cidade]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Oculto])) m_FOculto = Convert.ToInt32(dbRec[DBAgendaDicInfo.Oculto]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Oculto])) m_FOculto = Convert.ToInt32(dbRec[DBAgendaDicInfo.Oculto]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Oculto])) m_FOculto = Convert.ToInt32(dbRec[DBAgendaDicInfo.Oculto]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Oculto])) m_FOculto = Convert.ToInt32(dbRec[DBAgendaDicInfo.Oculto]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Oculto])) m_FOculto = Convert.ToInt32(dbRec[DBAgendaDicInfo.Oculto]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Oculto]))
            m_FOculto = Convert.ToInt32(dbRec[DBAgendaDicInfo.Oculto]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.CartaPrecatoria])) m_FCartaPrecatoria = Convert.ToInt32(dbRec[DBAgendaDicInfo.CartaPrecatoria]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.CartaPrecatoria])) m_FCartaPrecatoria = Convert.ToInt32(dbRec[DBAgendaDicInfo.CartaPrecatoria]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.CartaPrecatoria])) m_FCartaPrecatoria = Convert.ToInt32(dbRec[DBAgendaDicInfo.CartaPrecatoria]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.CartaPrecatoria])) m_FCartaPrecatoria = Convert.ToInt32(dbRec[DBAgendaDicInfo.CartaPrecatoria]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.CartaPrecatoria])) m_FCartaPrecatoria = Convert.ToInt32(dbRec[DBAgendaDicInfo.CartaPrecatoria]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.CartaPrecatoria]))
            m_FCartaPrecatoria = Convert.ToInt32(dbRec[DBAgendaDicInfo.CartaPrecatoria]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Revisar])) m_FRevisar = (bool)dbRec[DBAgendaDicInfo.Revisar]; if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Revisar])) m_FRevisar = (bool)dbRec[DBAgendaDicInfo.Revisar];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Revisar])) m_FRevisar = (bool)dbRec[DBAgendaDicInfo.Revisar]; if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Revisar])) m_FRevisar = (bool)dbRec[DBAgendaDicInfo.Revisar];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Revisar])) m_FRevisar = (bool)dbRec[DBAgendaDicInfo.Revisar]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Revisar]))
            m_FRevisar = (bool)dbRec[DBAgendaDicInfo.Revisar];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.HrFinal])) m_FHrFinal = Convert.ToDateTime(dbRec[DBAgendaDicInfo.HrFinal]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.HrFinal])) m_FHrFinal = Convert.ToDateTime(dbRec[DBAgendaDicInfo.HrFinal]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.HrFinal])) m_FHrFinal = Convert.ToDateTime(dbRec[DBAgendaDicInfo.HrFinal]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.HrFinal])) m_FHrFinal = Convert.ToDateTime(dbRec[DBAgendaDicInfo.HrFinal]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.HrFinal])) m_FHrFinal = Convert.ToDateTime(dbRec[DBAgendaDicInfo.HrFinal]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.HrFinal]))
            m_FHrFinal = Convert.ToDateTime(dbRec[DBAgendaDicInfo.HrFinal]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBAgendaDicInfo.Advogado]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBAgendaDicInfo.Advogado]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBAgendaDicInfo.Advogado]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBAgendaDicInfo.Advogado]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Advogado])) m_FAdvogado = Convert.ToInt32(dbRec[DBAgendaDicInfo.Advogado]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Advogado]))
            m_FAdvogado = Convert.ToInt32(dbRec[DBAgendaDicInfo.Advogado]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.EventoGerador])) m_FEventoGerador = Convert.ToInt32(dbRec[DBAgendaDicInfo.EventoGerador]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.EventoGerador])) m_FEventoGerador = Convert.ToInt32(dbRec[DBAgendaDicInfo.EventoGerador]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.EventoGerador])) m_FEventoGerador = Convert.ToInt32(dbRec[DBAgendaDicInfo.EventoGerador]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.EventoGerador])) m_FEventoGerador = Convert.ToInt32(dbRec[DBAgendaDicInfo.EventoGerador]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.EventoGerador])) m_FEventoGerador = Convert.ToInt32(dbRec[DBAgendaDicInfo.EventoGerador]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.EventoGerador]))
            m_FEventoGerador = Convert.ToInt32(dbRec[DBAgendaDicInfo.EventoGerador]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.EventoData])) m_FEventoData = Convert.ToDateTime(dbRec[DBAgendaDicInfo.EventoData]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.EventoData])) m_FEventoData = Convert.ToDateTime(dbRec[DBAgendaDicInfo.EventoData]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.EventoData])) m_FEventoData = Convert.ToDateTime(dbRec[DBAgendaDicInfo.EventoData]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.EventoData])) m_FEventoData = Convert.ToDateTime(dbRec[DBAgendaDicInfo.EventoData]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.EventoData])) m_FEventoData = Convert.ToDateTime(dbRec[DBAgendaDicInfo.EventoData]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.EventoData]))
            m_FEventoData = Convert.ToDateTime(dbRec[DBAgendaDicInfo.EventoData]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Funcionario])) m_FFuncionario = Convert.ToInt32(dbRec[DBAgendaDicInfo.Funcionario]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Funcionario])) m_FFuncionario = Convert.ToInt32(dbRec[DBAgendaDicInfo.Funcionario]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Funcionario])) m_FFuncionario = Convert.ToInt32(dbRec[DBAgendaDicInfo.Funcionario]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Funcionario])) m_FFuncionario = Convert.ToInt32(dbRec[DBAgendaDicInfo.Funcionario]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Funcionario])) m_FFuncionario = Convert.ToInt32(dbRec[DBAgendaDicInfo.Funcionario]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Funcionario]))
            m_FFuncionario = Convert.ToInt32(dbRec[DBAgendaDicInfo.Funcionario]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBAgendaDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBAgendaDicInfo.Data]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBAgendaDicInfo.Data]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBAgendaDicInfo.Data]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Data])) m_FData = Convert.ToDateTime(dbRec[DBAgendaDicInfo.Data]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Data]))
            m_FData = Convert.ToDateTime(dbRec[DBAgendaDicInfo.Data]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.EventoPrazo])) m_FEventoPrazo = Convert.ToInt32(dbRec[DBAgendaDicInfo.EventoPrazo]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.EventoPrazo])) m_FEventoPrazo = Convert.ToInt32(dbRec[DBAgendaDicInfo.EventoPrazo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.EventoPrazo])) m_FEventoPrazo = Convert.ToInt32(dbRec[DBAgendaDicInfo.EventoPrazo]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.EventoPrazo])) m_FEventoPrazo = Convert.ToInt32(dbRec[DBAgendaDicInfo.EventoPrazo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.EventoPrazo])) m_FEventoPrazo = Convert.ToInt32(dbRec[DBAgendaDicInfo.EventoPrazo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.EventoPrazo]))
            m_FEventoPrazo = Convert.ToInt32(dbRec[DBAgendaDicInfo.EventoPrazo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBAgendaDicInfo.Hora]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBAgendaDicInfo.Hora]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBAgendaDicInfo.Hora]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBAgendaDicInfo.Hora]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Hora])) m_FHora = Convert.ToDateTime(dbRec[DBAgendaDicInfo.Hora]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Hora]))
            m_FHora = Convert.ToDateTime(dbRec[DBAgendaDicInfo.Hora]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FCompromisso = dbRec[DBAgendaDicInfo.Compromisso]?.ToString() ?? string.Empty; m_FCompromisso = dbRec[DBAgendaDicInfo.Compromisso]?.ToString() ?? string.Empty;  } catch {}  try { m_FCompromisso = dbRec[DBAgendaDicInfo.Compromisso]?.ToString() ?? string.Empty; m_FCompromisso = dbRec[DBAgendaDicInfo.Compromisso]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FCompromisso = dbRec[DBAgendaDicInfo.Compromisso]?.ToString() ?? string.Empty; } catch { }

#else
        m_FCompromisso = dbRec[DBAgendaDicInfo.Compromisso]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.TipoCompromisso])) m_FTipoCompromisso = Convert.ToInt32(dbRec[DBAgendaDicInfo.TipoCompromisso]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.TipoCompromisso])) m_FTipoCompromisso = Convert.ToInt32(dbRec[DBAgendaDicInfo.TipoCompromisso]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.TipoCompromisso])) m_FTipoCompromisso = Convert.ToInt32(dbRec[DBAgendaDicInfo.TipoCompromisso]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.TipoCompromisso])) m_FTipoCompromisso = Convert.ToInt32(dbRec[DBAgendaDicInfo.TipoCompromisso]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.TipoCompromisso])) m_FTipoCompromisso = Convert.ToInt32(dbRec[DBAgendaDicInfo.TipoCompromisso]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.TipoCompromisso]))
            m_FTipoCompromisso = Convert.ToInt32(dbRec[DBAgendaDicInfo.TipoCompromisso]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBAgendaDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBAgendaDicInfo.Cliente]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBAgendaDicInfo.Cliente]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBAgendaDicInfo.Cliente]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Cliente])) m_FCliente = Convert.ToInt32(dbRec[DBAgendaDicInfo.Cliente]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Cliente]))
            m_FCliente = Convert.ToInt32(dbRec[DBAgendaDicInfo.Cliente]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Liberado])) m_FLiberado = (bool)dbRec[DBAgendaDicInfo.Liberado]; if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Liberado])) m_FLiberado = (bool)dbRec[DBAgendaDicInfo.Liberado];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Liberado])) m_FLiberado = (bool)dbRec[DBAgendaDicInfo.Liberado]; if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Liberado])) m_FLiberado = (bool)dbRec[DBAgendaDicInfo.Liberado];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Liberado])) m_FLiberado = (bool)dbRec[DBAgendaDicInfo.Liberado]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Liberado]))
            m_FLiberado = (bool)dbRec[DBAgendaDicInfo.Liberado];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Importante])) m_FImportante = (bool)dbRec[DBAgendaDicInfo.Importante]; if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Importante])) m_FImportante = (bool)dbRec[DBAgendaDicInfo.Importante];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Importante])) m_FImportante = (bool)dbRec[DBAgendaDicInfo.Importante]; if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Importante])) m_FImportante = (bool)dbRec[DBAgendaDicInfo.Importante];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Importante])) m_FImportante = (bool)dbRec[DBAgendaDicInfo.Importante]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Importante]))
            m_FImportante = (bool)dbRec[DBAgendaDicInfo.Importante];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Concluido])) m_FConcluido = (bool)dbRec[DBAgendaDicInfo.Concluido]; if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Concluido])) m_FConcluido = (bool)dbRec[DBAgendaDicInfo.Concluido];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Concluido])) m_FConcluido = (bool)dbRec[DBAgendaDicInfo.Concluido]; if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Concluido])) m_FConcluido = (bool)dbRec[DBAgendaDicInfo.Concluido];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Concluido])) m_FConcluido = (bool)dbRec[DBAgendaDicInfo.Concluido]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Concluido]))
            m_FConcluido = (bool)dbRec[DBAgendaDicInfo.Concluido];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBAgendaDicInfo.Area]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBAgendaDicInfo.Area]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBAgendaDicInfo.Area]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBAgendaDicInfo.Area]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBAgendaDicInfo.Area]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Area]))
            m_FArea = Convert.ToInt32(dbRec[DBAgendaDicInfo.Area]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBAgendaDicInfo.Justica]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBAgendaDicInfo.Justica]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBAgendaDicInfo.Justica]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBAgendaDicInfo.Justica]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBAgendaDicInfo.Justica]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Justica]))
            m_FJustica = Convert.ToInt32(dbRec[DBAgendaDicInfo.Justica]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBAgendaDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBAgendaDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBAgendaDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBAgendaDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBAgendaDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBAgendaDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.IDHistorico])) m_FIDHistorico = Convert.ToInt32(dbRec[DBAgendaDicInfo.IDHistorico]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.IDHistorico])) m_FIDHistorico = Convert.ToInt32(dbRec[DBAgendaDicInfo.IDHistorico]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.IDHistorico])) m_FIDHistorico = Convert.ToInt32(dbRec[DBAgendaDicInfo.IDHistorico]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.IDHistorico])) m_FIDHistorico = Convert.ToInt32(dbRec[DBAgendaDicInfo.IDHistorico]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.IDHistorico])) m_FIDHistorico = Convert.ToInt32(dbRec[DBAgendaDicInfo.IDHistorico]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.IDHistorico]))
            m_FIDHistorico = Convert.ToInt32(dbRec[DBAgendaDicInfo.IDHistorico]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.IDInsProcesso])) m_FIDInsProcesso = Convert.ToInt32(dbRec[DBAgendaDicInfo.IDInsProcesso]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.IDInsProcesso])) m_FIDInsProcesso = Convert.ToInt32(dbRec[DBAgendaDicInfo.IDInsProcesso]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.IDInsProcesso])) m_FIDInsProcesso = Convert.ToInt32(dbRec[DBAgendaDicInfo.IDInsProcesso]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.IDInsProcesso])) m_FIDInsProcesso = Convert.ToInt32(dbRec[DBAgendaDicInfo.IDInsProcesso]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.IDInsProcesso])) m_FIDInsProcesso = Convert.ToInt32(dbRec[DBAgendaDicInfo.IDInsProcesso]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.IDInsProcesso]))
            m_FIDInsProcesso = Convert.ToInt32(dbRec[DBAgendaDicInfo.IDInsProcesso]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Usuario])) m_FUsuario = Convert.ToInt32(dbRec[DBAgendaDicInfo.Usuario]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Usuario])) m_FUsuario = Convert.ToInt32(dbRec[DBAgendaDicInfo.Usuario]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Usuario])) m_FUsuario = Convert.ToInt32(dbRec[DBAgendaDicInfo.Usuario]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Usuario])) m_FUsuario = Convert.ToInt32(dbRec[DBAgendaDicInfo.Usuario]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Usuario])) m_FUsuario = Convert.ToInt32(dbRec[DBAgendaDicInfo.Usuario]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Usuario]))
            m_FUsuario = Convert.ToInt32(dbRec[DBAgendaDicInfo.Usuario]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Preposto])) m_FPreposto = Convert.ToInt32(dbRec[DBAgendaDicInfo.Preposto]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Preposto])) m_FPreposto = Convert.ToInt32(dbRec[DBAgendaDicInfo.Preposto]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Preposto])) m_FPreposto = Convert.ToInt32(dbRec[DBAgendaDicInfo.Preposto]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Preposto])) m_FPreposto = Convert.ToInt32(dbRec[DBAgendaDicInfo.Preposto]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Preposto])) m_FPreposto = Convert.ToInt32(dbRec[DBAgendaDicInfo.Preposto]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Preposto]))
            m_FPreposto = Convert.ToInt32(dbRec[DBAgendaDicInfo.Preposto]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.QuemID])) m_FQuemID = Convert.ToInt32(dbRec[DBAgendaDicInfo.QuemID]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.QuemID])) m_FQuemID = Convert.ToInt32(dbRec[DBAgendaDicInfo.QuemID]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.QuemID])) m_FQuemID = Convert.ToInt32(dbRec[DBAgendaDicInfo.QuemID]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.QuemID])) m_FQuemID = Convert.ToInt32(dbRec[DBAgendaDicInfo.QuemID]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.QuemID])) m_FQuemID = Convert.ToInt32(dbRec[DBAgendaDicInfo.QuemID]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.QuemID]))
            m_FQuemID = Convert.ToInt32(dbRec[DBAgendaDicInfo.QuemID]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.QuemCodigo])) m_FQuemCodigo = Convert.ToInt32(dbRec[DBAgendaDicInfo.QuemCodigo]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.QuemCodigo])) m_FQuemCodigo = Convert.ToInt32(dbRec[DBAgendaDicInfo.QuemCodigo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.QuemCodigo])) m_FQuemCodigo = Convert.ToInt32(dbRec[DBAgendaDicInfo.QuemCodigo]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.QuemCodigo])) m_FQuemCodigo = Convert.ToInt32(dbRec[DBAgendaDicInfo.QuemCodigo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.QuemCodigo])) m_FQuemCodigo = Convert.ToInt32(dbRec[DBAgendaDicInfo.QuemCodigo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.QuemCodigo]))
            m_FQuemCodigo = Convert.ToInt32(dbRec[DBAgendaDicInfo.QuemCodigo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FStatus = dbRec[DBAgendaDicInfo.Status]?.ToString() ?? string.Empty; m_FStatus = dbRec[DBAgendaDicInfo.Status]?.ToString() ?? string.Empty;  } catch {}  try { m_FStatus = dbRec[DBAgendaDicInfo.Status]?.ToString() ?? string.Empty; m_FStatus = dbRec[DBAgendaDicInfo.Status]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FStatus = dbRec[DBAgendaDicInfo.Status]?.ToString() ?? string.Empty; } catch { }

#else
        m_FStatus = dbRec[DBAgendaDicInfo.Status]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 5
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBAgendaDicInfo.Valor]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBAgendaDicInfo.Valor]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBAgendaDicInfo.Valor]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBAgendaDicInfo.Valor]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Valor])) m_FValor = Convert.ToDecimal(dbRec[DBAgendaDicInfo.Valor]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Valor]))
            m_FValor = Convert.ToDecimal(dbRec[DBAgendaDicInfo.Valor]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FDecisao = dbRec[DBAgendaDicInfo.Decisao]?.ToString() ?? string.Empty; m_FDecisao = dbRec[DBAgendaDicInfo.Decisao]?.ToString() ?? string.Empty;  } catch {}  try { m_FDecisao = dbRec[DBAgendaDicInfo.Decisao]?.ToString() ?? string.Empty; m_FDecisao = dbRec[DBAgendaDicInfo.Decisao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FDecisao = dbRec[DBAgendaDicInfo.Decisao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FDecisao = dbRec[DBAgendaDicInfo.Decisao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Sempre])) m_FSempre = Convert.ToInt32(dbRec[DBAgendaDicInfo.Sempre]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Sempre])) m_FSempre = Convert.ToInt32(dbRec[DBAgendaDicInfo.Sempre]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Sempre])) m_FSempre = Convert.ToInt32(dbRec[DBAgendaDicInfo.Sempre]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Sempre])) m_FSempre = Convert.ToInt32(dbRec[DBAgendaDicInfo.Sempre]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Sempre])) m_FSempre = Convert.ToInt32(dbRec[DBAgendaDicInfo.Sempre]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Sempre]))
            m_FSempre = Convert.ToInt32(dbRec[DBAgendaDicInfo.Sempre]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.PrazoDias])) m_FPrazoDias = Convert.ToInt32(dbRec[DBAgendaDicInfo.PrazoDias]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.PrazoDias])) m_FPrazoDias = Convert.ToInt32(dbRec[DBAgendaDicInfo.PrazoDias]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.PrazoDias])) m_FPrazoDias = Convert.ToInt32(dbRec[DBAgendaDicInfo.PrazoDias]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.PrazoDias])) m_FPrazoDias = Convert.ToInt32(dbRec[DBAgendaDicInfo.PrazoDias]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.PrazoDias])) m_FPrazoDias = Convert.ToInt32(dbRec[DBAgendaDicInfo.PrazoDias]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.PrazoDias]))
            m_FPrazoDias = Convert.ToInt32(dbRec[DBAgendaDicInfo.PrazoDias]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.ProtocoloIntegrado])) m_FProtocoloIntegrado = Convert.ToInt32(dbRec[DBAgendaDicInfo.ProtocoloIntegrado]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.ProtocoloIntegrado])) m_FProtocoloIntegrado = Convert.ToInt32(dbRec[DBAgendaDicInfo.ProtocoloIntegrado]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.ProtocoloIntegrado])) m_FProtocoloIntegrado = Convert.ToInt32(dbRec[DBAgendaDicInfo.ProtocoloIntegrado]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.ProtocoloIntegrado])) m_FProtocoloIntegrado = Convert.ToInt32(dbRec[DBAgendaDicInfo.ProtocoloIntegrado]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.ProtocoloIntegrado])) m_FProtocoloIntegrado = Convert.ToInt32(dbRec[DBAgendaDicInfo.ProtocoloIntegrado]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.ProtocoloIntegrado]))
            m_FProtocoloIntegrado = Convert.ToInt32(dbRec[DBAgendaDicInfo.ProtocoloIntegrado]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.DataInicioPrazo])) m_FDataInicioPrazo = Convert.ToDateTime(dbRec[DBAgendaDicInfo.DataInicioPrazo]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.DataInicioPrazo])) m_FDataInicioPrazo = Convert.ToDateTime(dbRec[DBAgendaDicInfo.DataInicioPrazo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.DataInicioPrazo])) m_FDataInicioPrazo = Convert.ToDateTime(dbRec[DBAgendaDicInfo.DataInicioPrazo]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.DataInicioPrazo])) m_FDataInicioPrazo = Convert.ToDateTime(dbRec[DBAgendaDicInfo.DataInicioPrazo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.DataInicioPrazo])) m_FDataInicioPrazo = Convert.ToDateTime(dbRec[DBAgendaDicInfo.DataInicioPrazo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.DataInicioPrazo]))
            m_FDataInicioPrazo = Convert.ToDateTime(dbRec[DBAgendaDicInfo.DataInicioPrazo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.UsuarioCiente])) m_FUsuarioCiente = (bool)dbRec[DBAgendaDicInfo.UsuarioCiente]; if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.UsuarioCiente])) m_FUsuarioCiente = (bool)dbRec[DBAgendaDicInfo.UsuarioCiente];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.UsuarioCiente])) m_FUsuarioCiente = (bool)dbRec[DBAgendaDicInfo.UsuarioCiente]; if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.UsuarioCiente])) m_FUsuarioCiente = (bool)dbRec[DBAgendaDicInfo.UsuarioCiente];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.UsuarioCiente])) m_FUsuarioCiente = (bool)dbRec[DBAgendaDicInfo.UsuarioCiente]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.UsuarioCiente]))
            m_FUsuarioCiente = (bool)dbRec[DBAgendaDicInfo.UsuarioCiente];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBAgendaDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBAgendaDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBAgendaDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBAgendaDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBAgendaDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBAgendaDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAgendaDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAgendaDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAgendaDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAgendaDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAgendaDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBAgendaDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAgendaDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAgendaDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAgendaDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAgendaDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAgendaDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBAgendaDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAgendaDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAgendaDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAgendaDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAgendaDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAgendaDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBAgendaDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAgendaDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAgendaDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAgendaDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAgendaDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAgendaDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBAgendaDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAgendaDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAgendaDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAgendaDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAgendaDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAgendaDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBAgendaDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}