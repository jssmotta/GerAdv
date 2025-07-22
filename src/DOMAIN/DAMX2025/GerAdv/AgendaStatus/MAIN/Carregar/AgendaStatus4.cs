namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBAgendaStatus
{
    public DBAgendaStatus(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.Agenda]))
                m_FAgenda = Convert.ToInt32(dbRec[DBAgendaStatusDicInfo.Agenda]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.Completed]))
                m_FCompleted = Convert.ToInt32(dbRec[DBAgendaStatusDicInfo.Completed]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBAgendaStatusDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBAgendaStatusDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBAgendaStatusDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBAgendaStatusDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBAgendaStatusDicInfo.Visto];
        }
        catch
        {
        }
    }

    public DBAgendaStatus(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.Agenda]))
                m_FAgenda = Convert.ToInt32(dbRec[DBAgendaStatusDicInfo.Agenda]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.Completed]))
                m_FCompleted = Convert.ToInt32(dbRec[DBAgendaStatusDicInfo.Completed]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBAgendaStatusDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBAgendaStatusDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBAgendaStatusDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBAgendaStatusDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBAgendaStatusDicInfo.Visto];
        }
        catch
        {
        }
    }

#region CarregarDados_AgendaStatus
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [astCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.Agenda])) m_FAgenda = Convert.ToInt32(dbRec[DBAgendaStatusDicInfo.Agenda]); if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.Agenda])) m_FAgenda = Convert.ToInt32(dbRec[DBAgendaStatusDicInfo.Agenda]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.Agenda])) m_FAgenda = Convert.ToInt32(dbRec[DBAgendaStatusDicInfo.Agenda]); if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.Agenda])) m_FAgenda = Convert.ToInt32(dbRec[DBAgendaStatusDicInfo.Agenda]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.Agenda])) m_FAgenda = Convert.ToInt32(dbRec[DBAgendaStatusDicInfo.Agenda]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.Agenda]))
            m_FAgenda = Convert.ToInt32(dbRec[DBAgendaStatusDicInfo.Agenda]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.Completed])) m_FCompleted = Convert.ToInt32(dbRec[DBAgendaStatusDicInfo.Completed]); if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.Completed])) m_FCompleted = Convert.ToInt32(dbRec[DBAgendaStatusDicInfo.Completed]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.Completed])) m_FCompleted = Convert.ToInt32(dbRec[DBAgendaStatusDicInfo.Completed]); if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.Completed])) m_FCompleted = Convert.ToInt32(dbRec[DBAgendaStatusDicInfo.Completed]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.Completed])) m_FCompleted = Convert.ToInt32(dbRec[DBAgendaStatusDicInfo.Completed]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.Completed]))
            m_FCompleted = Convert.ToInt32(dbRec[DBAgendaStatusDicInfo.Completed]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAgendaStatusDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAgendaStatusDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAgendaStatusDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAgendaStatusDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAgendaStatusDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBAgendaStatusDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAgendaStatusDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAgendaStatusDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAgendaStatusDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAgendaStatusDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAgendaStatusDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBAgendaStatusDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAgendaStatusDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAgendaStatusDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAgendaStatusDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAgendaStatusDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAgendaStatusDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBAgendaStatusDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAgendaStatusDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAgendaStatusDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAgendaStatusDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAgendaStatusDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAgendaStatusDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBAgendaStatusDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAgendaStatusDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAgendaStatusDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAgendaStatusDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAgendaStatusDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAgendaStatusDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBAgendaStatusDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_AgendaStatus
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
if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.Agenda])) m_FAgenda = Convert.ToInt32(dbRec[DBAgendaStatusDicInfo.Agenda]); if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.Agenda])) m_FAgenda = Convert.ToInt32(dbRec[DBAgendaStatusDicInfo.Agenda]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.Agenda])) m_FAgenda = Convert.ToInt32(dbRec[DBAgendaStatusDicInfo.Agenda]); if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.Agenda])) m_FAgenda = Convert.ToInt32(dbRec[DBAgendaStatusDicInfo.Agenda]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.Agenda])) m_FAgenda = Convert.ToInt32(dbRec[DBAgendaStatusDicInfo.Agenda]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.Agenda]))
            m_FAgenda = Convert.ToInt32(dbRec[DBAgendaStatusDicInfo.Agenda]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.Completed])) m_FCompleted = Convert.ToInt32(dbRec[DBAgendaStatusDicInfo.Completed]); if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.Completed])) m_FCompleted = Convert.ToInt32(dbRec[DBAgendaStatusDicInfo.Completed]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.Completed])) m_FCompleted = Convert.ToInt32(dbRec[DBAgendaStatusDicInfo.Completed]); if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.Completed])) m_FCompleted = Convert.ToInt32(dbRec[DBAgendaStatusDicInfo.Completed]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.Completed])) m_FCompleted = Convert.ToInt32(dbRec[DBAgendaStatusDicInfo.Completed]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.Completed]))
            m_FCompleted = Convert.ToInt32(dbRec[DBAgendaStatusDicInfo.Completed]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAgendaStatusDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAgendaStatusDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAgendaStatusDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAgendaStatusDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAgendaStatusDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBAgendaStatusDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAgendaStatusDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAgendaStatusDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAgendaStatusDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAgendaStatusDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAgendaStatusDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBAgendaStatusDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAgendaStatusDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAgendaStatusDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAgendaStatusDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAgendaStatusDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAgendaStatusDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBAgendaStatusDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAgendaStatusDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAgendaStatusDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAgendaStatusDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAgendaStatusDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAgendaStatusDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBAgendaStatusDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAgendaStatusDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAgendaStatusDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAgendaStatusDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAgendaStatusDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAgendaStatusDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgendaStatusDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBAgendaStatusDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}