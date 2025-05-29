namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBProcessosParados
{
    public DBProcessosParados(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.Ano]))
                m_FAno = Convert.ToInt32(dbRec[DBProcessosParadosDicInfo.Ano]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.DataHistorico]))
                m_FDataHistorico = Convert.ToDateTime(dbRec[DBProcessosParadosDicInfo.DataHistorico]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.DataHora]))
                m_FDataHora = Convert.ToDateTime(dbRec[DBProcessosParadosDicInfo.DataHora]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.DataNENotas]))
                m_FDataNENotas = Convert.ToDateTime(dbRec[DBProcessosParadosDicInfo.DataNENotas]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.Operador]))
                m_FOperador = Convert.ToInt32(dbRec[DBProcessosParadosDicInfo.Operador]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBProcessosParadosDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.Semana]))
                m_FSemana = Convert.ToInt32(dbRec[DBProcessosParadosDicInfo.Semana]);
        }
        catch
        {
        }
    }

    public DBProcessosParados(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.Ano]))
                m_FAno = Convert.ToInt32(dbRec[DBProcessosParadosDicInfo.Ano]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.DataHistorico]))
                m_FDataHistorico = Convert.ToDateTime(dbRec[DBProcessosParadosDicInfo.DataHistorico]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.DataHora]))
                m_FDataHora = Convert.ToDateTime(dbRec[DBProcessosParadosDicInfo.DataHora]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.DataNENotas]))
                m_FDataNENotas = Convert.ToDateTime(dbRec[DBProcessosParadosDicInfo.DataNENotas]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.Operador]))
                m_FOperador = Convert.ToInt32(dbRec[DBProcessosParadosDicInfo.Operador]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.Processo]))
                m_FProcesso = Convert.ToInt32(dbRec[DBProcessosParadosDicInfo.Processo]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.Semana]))
                m_FSemana = Convert.ToInt32(dbRec[DBProcessosParadosDicInfo.Semana]);
        }
        catch
        {
        }
    }

#region CarregarDados_ProcessosParados
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [pprCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProcessosParadosDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProcessosParadosDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProcessosParadosDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProcessosParadosDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProcessosParadosDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBProcessosParadosDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.Semana])) m_FSemana = Convert.ToInt32(dbRec[DBProcessosParadosDicInfo.Semana]); if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.Semana])) m_FSemana = Convert.ToInt32(dbRec[DBProcessosParadosDicInfo.Semana]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.Semana])) m_FSemana = Convert.ToInt32(dbRec[DBProcessosParadosDicInfo.Semana]); if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.Semana])) m_FSemana = Convert.ToInt32(dbRec[DBProcessosParadosDicInfo.Semana]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.Semana])) m_FSemana = Convert.ToInt32(dbRec[DBProcessosParadosDicInfo.Semana]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.Semana]))
            m_FSemana = Convert.ToInt32(dbRec[DBProcessosParadosDicInfo.Semana]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.Ano])) m_FAno = Convert.ToInt32(dbRec[DBProcessosParadosDicInfo.Ano]); if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.Ano])) m_FAno = Convert.ToInt32(dbRec[DBProcessosParadosDicInfo.Ano]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.Ano])) m_FAno = Convert.ToInt32(dbRec[DBProcessosParadosDicInfo.Ano]); if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.Ano])) m_FAno = Convert.ToInt32(dbRec[DBProcessosParadosDicInfo.Ano]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.Ano])) m_FAno = Convert.ToInt32(dbRec[DBProcessosParadosDicInfo.Ano]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.Ano]))
            m_FAno = Convert.ToInt32(dbRec[DBProcessosParadosDicInfo.Ano]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.DataHora])) m_FDataHora = Convert.ToDateTime(dbRec[DBProcessosParadosDicInfo.DataHora]); if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.DataHora])) m_FDataHora = Convert.ToDateTime(dbRec[DBProcessosParadosDicInfo.DataHora]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.DataHora])) m_FDataHora = Convert.ToDateTime(dbRec[DBProcessosParadosDicInfo.DataHora]); if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.DataHora])) m_FDataHora = Convert.ToDateTime(dbRec[DBProcessosParadosDicInfo.DataHora]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.DataHora])) m_FDataHora = Convert.ToDateTime(dbRec[DBProcessosParadosDicInfo.DataHora]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.DataHora]))
            m_FDataHora = Convert.ToDateTime(dbRec[DBProcessosParadosDicInfo.DataHora]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBProcessosParadosDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBProcessosParadosDicInfo.Operador]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBProcessosParadosDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBProcessosParadosDicInfo.Operador]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBProcessosParadosDicInfo.Operador]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.Operador]))
            m_FOperador = Convert.ToInt32(dbRec[DBProcessosParadosDicInfo.Operador]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.DataHistorico])) m_FDataHistorico = Convert.ToDateTime(dbRec[DBProcessosParadosDicInfo.DataHistorico]); if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.DataHistorico])) m_FDataHistorico = Convert.ToDateTime(dbRec[DBProcessosParadosDicInfo.DataHistorico]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.DataHistorico])) m_FDataHistorico = Convert.ToDateTime(dbRec[DBProcessosParadosDicInfo.DataHistorico]); if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.DataHistorico])) m_FDataHistorico = Convert.ToDateTime(dbRec[DBProcessosParadosDicInfo.DataHistorico]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.DataHistorico])) m_FDataHistorico = Convert.ToDateTime(dbRec[DBProcessosParadosDicInfo.DataHistorico]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.DataHistorico]))
            m_FDataHistorico = Convert.ToDateTime(dbRec[DBProcessosParadosDicInfo.DataHistorico]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.DataNENotas])) m_FDataNENotas = Convert.ToDateTime(dbRec[DBProcessosParadosDicInfo.DataNENotas]); if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.DataNENotas])) m_FDataNENotas = Convert.ToDateTime(dbRec[DBProcessosParadosDicInfo.DataNENotas]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.DataNENotas])) m_FDataNENotas = Convert.ToDateTime(dbRec[DBProcessosParadosDicInfo.DataNENotas]); if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.DataNENotas])) m_FDataNENotas = Convert.ToDateTime(dbRec[DBProcessosParadosDicInfo.DataNENotas]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.DataNENotas])) m_FDataNENotas = Convert.ToDateTime(dbRec[DBProcessosParadosDicInfo.DataNENotas]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.DataNENotas]))
            m_FDataNENotas = Convert.ToDateTime(dbRec[DBProcessosParadosDicInfo.DataNENotas]);
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_ProcessosParados
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
if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProcessosParadosDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProcessosParadosDicInfo.Processo]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProcessosParadosDicInfo.Processo]); if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProcessosParadosDicInfo.Processo]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.Processo])) m_FProcesso = Convert.ToInt32(dbRec[DBProcessosParadosDicInfo.Processo]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.Processo]))
            m_FProcesso = Convert.ToInt32(dbRec[DBProcessosParadosDicInfo.Processo]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.Semana])) m_FSemana = Convert.ToInt32(dbRec[DBProcessosParadosDicInfo.Semana]); if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.Semana])) m_FSemana = Convert.ToInt32(dbRec[DBProcessosParadosDicInfo.Semana]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.Semana])) m_FSemana = Convert.ToInt32(dbRec[DBProcessosParadosDicInfo.Semana]); if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.Semana])) m_FSemana = Convert.ToInt32(dbRec[DBProcessosParadosDicInfo.Semana]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.Semana])) m_FSemana = Convert.ToInt32(dbRec[DBProcessosParadosDicInfo.Semana]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.Semana]))
            m_FSemana = Convert.ToInt32(dbRec[DBProcessosParadosDicInfo.Semana]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.Ano])) m_FAno = Convert.ToInt32(dbRec[DBProcessosParadosDicInfo.Ano]); if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.Ano])) m_FAno = Convert.ToInt32(dbRec[DBProcessosParadosDicInfo.Ano]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.Ano])) m_FAno = Convert.ToInt32(dbRec[DBProcessosParadosDicInfo.Ano]); if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.Ano])) m_FAno = Convert.ToInt32(dbRec[DBProcessosParadosDicInfo.Ano]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.Ano])) m_FAno = Convert.ToInt32(dbRec[DBProcessosParadosDicInfo.Ano]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.Ano]))
            m_FAno = Convert.ToInt32(dbRec[DBProcessosParadosDicInfo.Ano]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.DataHora])) m_FDataHora = Convert.ToDateTime(dbRec[DBProcessosParadosDicInfo.DataHora]); if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.DataHora])) m_FDataHora = Convert.ToDateTime(dbRec[DBProcessosParadosDicInfo.DataHora]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.DataHora])) m_FDataHora = Convert.ToDateTime(dbRec[DBProcessosParadosDicInfo.DataHora]); if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.DataHora])) m_FDataHora = Convert.ToDateTime(dbRec[DBProcessosParadosDicInfo.DataHora]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.DataHora])) m_FDataHora = Convert.ToDateTime(dbRec[DBProcessosParadosDicInfo.DataHora]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.DataHora]))
            m_FDataHora = Convert.ToDateTime(dbRec[DBProcessosParadosDicInfo.DataHora]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBProcessosParadosDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBProcessosParadosDicInfo.Operador]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBProcessosParadosDicInfo.Operador]); if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBProcessosParadosDicInfo.Operador]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.Operador])) m_FOperador = Convert.ToInt32(dbRec[DBProcessosParadosDicInfo.Operador]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.Operador]))
            m_FOperador = Convert.ToInt32(dbRec[DBProcessosParadosDicInfo.Operador]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.DataHistorico])) m_FDataHistorico = Convert.ToDateTime(dbRec[DBProcessosParadosDicInfo.DataHistorico]); if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.DataHistorico])) m_FDataHistorico = Convert.ToDateTime(dbRec[DBProcessosParadosDicInfo.DataHistorico]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.DataHistorico])) m_FDataHistorico = Convert.ToDateTime(dbRec[DBProcessosParadosDicInfo.DataHistorico]); if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.DataHistorico])) m_FDataHistorico = Convert.ToDateTime(dbRec[DBProcessosParadosDicInfo.DataHistorico]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.DataHistorico])) m_FDataHistorico = Convert.ToDateTime(dbRec[DBProcessosParadosDicInfo.DataHistorico]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.DataHistorico]))
            m_FDataHistorico = Convert.ToDateTime(dbRec[DBProcessosParadosDicInfo.DataHistorico]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.DataNENotas])) m_FDataNENotas = Convert.ToDateTime(dbRec[DBProcessosParadosDicInfo.DataNENotas]); if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.DataNENotas])) m_FDataNENotas = Convert.ToDateTime(dbRec[DBProcessosParadosDicInfo.DataNENotas]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.DataNENotas])) m_FDataNENotas = Convert.ToDateTime(dbRec[DBProcessosParadosDicInfo.DataNENotas]); if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.DataNENotas])) m_FDataNENotas = Convert.ToDateTime(dbRec[DBProcessosParadosDicInfo.DataNENotas]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.DataNENotas])) m_FDataNENotas = Convert.ToDateTime(dbRec[DBProcessosParadosDicInfo.DataNENotas]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProcessosParadosDicInfo.DataNENotas]))
            m_FDataNENotas = Convert.ToDateTime(dbRec[DBProcessosParadosDicInfo.DataNENotas]);
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}