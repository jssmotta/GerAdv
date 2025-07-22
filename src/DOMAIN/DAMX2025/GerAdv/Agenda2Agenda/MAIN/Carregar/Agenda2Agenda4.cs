namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBAgenda2Agenda
{
    public DBAgenda2Agenda(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.Agenda]))
                m_FAgenda = Convert.ToInt32(dbRec[DBAgenda2AgendaDicInfo.Agenda]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBAgenda2AgendaDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBAgenda2AgendaDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.Master]))
                m_FMaster = Convert.ToInt32(dbRec[DBAgenda2AgendaDicInfo.Master]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBAgenda2AgendaDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBAgenda2AgendaDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBAgenda2AgendaDicInfo.Visto];
        }
        catch
        {
        }
    }

    public DBAgenda2Agenda(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.Agenda]))
                m_FAgenda = Convert.ToInt32(dbRec[DBAgenda2AgendaDicInfo.Agenda]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBAgenda2AgendaDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBAgenda2AgendaDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.Master]))
                m_FMaster = Convert.ToInt32(dbRec[DBAgenda2AgendaDicInfo.Master]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBAgenda2AgendaDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBAgenda2AgendaDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBAgenda2AgendaDicInfo.Visto];
        }
        catch
        {
        }
    }

#region CarregarDados_Agenda2Agenda
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [ag2Codigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.Master])) m_FMaster = Convert.ToInt32(dbRec[DBAgenda2AgendaDicInfo.Master]); if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.Master])) m_FMaster = Convert.ToInt32(dbRec[DBAgenda2AgendaDicInfo.Master]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.Master])) m_FMaster = Convert.ToInt32(dbRec[DBAgenda2AgendaDicInfo.Master]); if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.Master])) m_FMaster = Convert.ToInt32(dbRec[DBAgenda2AgendaDicInfo.Master]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.Master])) m_FMaster = Convert.ToInt32(dbRec[DBAgenda2AgendaDicInfo.Master]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.Master]))
            m_FMaster = Convert.ToInt32(dbRec[DBAgenda2AgendaDicInfo.Master]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.Agenda])) m_FAgenda = Convert.ToInt32(dbRec[DBAgenda2AgendaDicInfo.Agenda]); if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.Agenda])) m_FAgenda = Convert.ToInt32(dbRec[DBAgenda2AgendaDicInfo.Agenda]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.Agenda])) m_FAgenda = Convert.ToInt32(dbRec[DBAgenda2AgendaDicInfo.Agenda]); if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.Agenda])) m_FAgenda = Convert.ToInt32(dbRec[DBAgenda2AgendaDicInfo.Agenda]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.Agenda])) m_FAgenda = Convert.ToInt32(dbRec[DBAgenda2AgendaDicInfo.Agenda]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.Agenda]))
            m_FAgenda = Convert.ToInt32(dbRec[DBAgenda2AgendaDicInfo.Agenda]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAgenda2AgendaDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAgenda2AgendaDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAgenda2AgendaDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAgenda2AgendaDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAgenda2AgendaDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBAgenda2AgendaDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAgenda2AgendaDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAgenda2AgendaDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAgenda2AgendaDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAgenda2AgendaDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAgenda2AgendaDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBAgenda2AgendaDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAgenda2AgendaDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAgenda2AgendaDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAgenda2AgendaDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAgenda2AgendaDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAgenda2AgendaDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBAgenda2AgendaDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAgenda2AgendaDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAgenda2AgendaDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAgenda2AgendaDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAgenda2AgendaDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAgenda2AgendaDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBAgenda2AgendaDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAgenda2AgendaDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAgenda2AgendaDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAgenda2AgendaDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAgenda2AgendaDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAgenda2AgendaDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBAgenda2AgendaDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_Agenda2Agenda
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
if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.Master])) m_FMaster = Convert.ToInt32(dbRec[DBAgenda2AgendaDicInfo.Master]); if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.Master])) m_FMaster = Convert.ToInt32(dbRec[DBAgenda2AgendaDicInfo.Master]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.Master])) m_FMaster = Convert.ToInt32(dbRec[DBAgenda2AgendaDicInfo.Master]); if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.Master])) m_FMaster = Convert.ToInt32(dbRec[DBAgenda2AgendaDicInfo.Master]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.Master])) m_FMaster = Convert.ToInt32(dbRec[DBAgenda2AgendaDicInfo.Master]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.Master]))
            m_FMaster = Convert.ToInt32(dbRec[DBAgenda2AgendaDicInfo.Master]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.Agenda])) m_FAgenda = Convert.ToInt32(dbRec[DBAgenda2AgendaDicInfo.Agenda]); if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.Agenda])) m_FAgenda = Convert.ToInt32(dbRec[DBAgenda2AgendaDicInfo.Agenda]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.Agenda])) m_FAgenda = Convert.ToInt32(dbRec[DBAgenda2AgendaDicInfo.Agenda]); if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.Agenda])) m_FAgenda = Convert.ToInt32(dbRec[DBAgenda2AgendaDicInfo.Agenda]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.Agenda])) m_FAgenda = Convert.ToInt32(dbRec[DBAgenda2AgendaDicInfo.Agenda]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.Agenda]))
            m_FAgenda = Convert.ToInt32(dbRec[DBAgenda2AgendaDicInfo.Agenda]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAgenda2AgendaDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAgenda2AgendaDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAgenda2AgendaDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAgenda2AgendaDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAgenda2AgendaDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBAgenda2AgendaDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAgenda2AgendaDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAgenda2AgendaDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAgenda2AgendaDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAgenda2AgendaDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAgenda2AgendaDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBAgenda2AgendaDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAgenda2AgendaDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAgenda2AgendaDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAgenda2AgendaDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAgenda2AgendaDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAgenda2AgendaDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBAgenda2AgendaDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAgenda2AgendaDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAgenda2AgendaDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAgenda2AgendaDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAgenda2AgendaDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAgenda2AgendaDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBAgenda2AgendaDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAgenda2AgendaDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAgenda2AgendaDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAgenda2AgendaDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAgenda2AgendaDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAgenda2AgendaDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAgenda2AgendaDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBAgenda2AgendaDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}