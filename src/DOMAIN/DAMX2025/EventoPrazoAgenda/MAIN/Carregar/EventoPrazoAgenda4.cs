namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBEventoPrazoAgenda
{
    public DBEventoPrazoAgenda(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBEventoPrazoAgendaDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBEventoPrazoAgendaDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBEventoPrazoAgendaDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBEventoPrazoAgendaDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBEventoPrazoAgendaDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBEventoPrazoAgendaDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBEventoPrazoAgendaDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBEventoPrazoAgenda(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBEventoPrazoAgendaDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBEventoPrazoAgendaDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBEventoPrazoAgendaDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBEventoPrazoAgendaDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBEventoPrazoAgendaDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBEventoPrazoAgendaDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBEventoPrazoAgendaDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_EventoPrazoAgenda
    protected void Carregar(int id, SqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM dbo.[EventoPrazoAgenda] (NOLOCK) WHERE [epaCodigo] = @ThisIDToLoad", oCnn);
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
// region JMen - nType = 203
m_FNome = dbRec[DBEventoPrazoAgendaDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBEventoPrazoAgendaDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBEventoPrazoAgendaDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBEventoPrazoAgendaDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBEventoPrazoAgendaDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBEventoPrazoAgendaDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.Bold])) m_FBold = (bool)dbRec[DBEventoPrazoAgendaDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.Bold])) m_FBold = (bool)dbRec[DBEventoPrazoAgendaDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.Bold])) m_FBold = (bool)dbRec[DBEventoPrazoAgendaDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.Bold])) m_FBold = (bool)dbRec[DBEventoPrazoAgendaDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.Bold])) m_FBold = (bool)dbRec[DBEventoPrazoAgendaDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBEventoPrazoAgendaDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBEventoPrazoAgendaDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBEventoPrazoAgendaDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBEventoPrazoAgendaDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBEventoPrazoAgendaDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBEventoPrazoAgendaDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBEventoPrazoAgendaDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBEventoPrazoAgendaDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBEventoPrazoAgendaDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBEventoPrazoAgendaDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBEventoPrazoAgendaDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBEventoPrazoAgendaDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBEventoPrazoAgendaDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBEventoPrazoAgendaDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBEventoPrazoAgendaDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBEventoPrazoAgendaDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBEventoPrazoAgendaDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBEventoPrazoAgendaDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBEventoPrazoAgendaDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBEventoPrazoAgendaDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBEventoPrazoAgendaDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBEventoPrazoAgendaDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBEventoPrazoAgendaDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBEventoPrazoAgendaDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBEventoPrazoAgendaDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBEventoPrazoAgendaDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBEventoPrazoAgendaDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBEventoPrazoAgendaDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBEventoPrazoAgendaDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBEventoPrazoAgendaDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBEventoPrazoAgendaDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_EventoPrazoAgenda
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
// region JMen - nType = 203
m_FNome = dbRec[DBEventoPrazoAgendaDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBEventoPrazoAgendaDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBEventoPrazoAgendaDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBEventoPrazoAgendaDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBEventoPrazoAgendaDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBEventoPrazoAgendaDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.Bold])) m_FBold = (bool)dbRec[DBEventoPrazoAgendaDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.Bold])) m_FBold = (bool)dbRec[DBEventoPrazoAgendaDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.Bold])) m_FBold = (bool)dbRec[DBEventoPrazoAgendaDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.Bold])) m_FBold = (bool)dbRec[DBEventoPrazoAgendaDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.Bold])) m_FBold = (bool)dbRec[DBEventoPrazoAgendaDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBEventoPrazoAgendaDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBEventoPrazoAgendaDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBEventoPrazoAgendaDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBEventoPrazoAgendaDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBEventoPrazoAgendaDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBEventoPrazoAgendaDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBEventoPrazoAgendaDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBEventoPrazoAgendaDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBEventoPrazoAgendaDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBEventoPrazoAgendaDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBEventoPrazoAgendaDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBEventoPrazoAgendaDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBEventoPrazoAgendaDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBEventoPrazoAgendaDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBEventoPrazoAgendaDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBEventoPrazoAgendaDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBEventoPrazoAgendaDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBEventoPrazoAgendaDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBEventoPrazoAgendaDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBEventoPrazoAgendaDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBEventoPrazoAgendaDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBEventoPrazoAgendaDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBEventoPrazoAgendaDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBEventoPrazoAgendaDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBEventoPrazoAgendaDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBEventoPrazoAgendaDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBEventoPrazoAgendaDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBEventoPrazoAgendaDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBEventoPrazoAgendaDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBEventoPrazoAgendaDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEventoPrazoAgendaDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBEventoPrazoAgendaDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}