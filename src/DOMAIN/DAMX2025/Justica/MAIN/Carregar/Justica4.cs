namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBJustica
{
    public DBJustica(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBJusticaDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBJusticaDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBJusticaDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBJusticaDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBJusticaDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBJusticaDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBJusticaDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBJusticaDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBJustica(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBJusticaDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBJusticaDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBJusticaDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBJusticaDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBJusticaDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBJusticaDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBJusticaDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBJusticaDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_Justica
    protected void Carregar(int id, SqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM dbo.[Justica] (NOLOCK) WHERE [jusCodigo] = @ThisIDToLoad", oCnn);
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
m_FNome = dbRec[DBJusticaDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBJusticaDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBJusticaDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBJusticaDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBJusticaDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBJusticaDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.Bold])) m_FBold = (bool)dbRec[DBJusticaDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.Bold])) m_FBold = (bool)dbRec[DBJusticaDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.Bold])) m_FBold = (bool)dbRec[DBJusticaDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.Bold])) m_FBold = (bool)dbRec[DBJusticaDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.Bold])) m_FBold = (bool)dbRec[DBJusticaDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBJusticaDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBJusticaDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBJusticaDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBJusticaDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBJusticaDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBJusticaDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBJusticaDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBJusticaDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBJusticaDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBJusticaDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBJusticaDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBJusticaDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBJusticaDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBJusticaDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBJusticaDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBJusticaDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBJusticaDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBJusticaDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBJusticaDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBJusticaDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBJusticaDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBJusticaDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBJusticaDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBJusticaDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBJusticaDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBJusticaDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBJusticaDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBJusticaDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBJusticaDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBJusticaDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBJusticaDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBJusticaDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBJusticaDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBJusticaDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBJusticaDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBJusticaDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBJusticaDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_Justica
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
m_FNome = dbRec[DBJusticaDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBJusticaDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBJusticaDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBJusticaDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBJusticaDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBJusticaDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.Bold])) m_FBold = (bool)dbRec[DBJusticaDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.Bold])) m_FBold = (bool)dbRec[DBJusticaDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.Bold])) m_FBold = (bool)dbRec[DBJusticaDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.Bold])) m_FBold = (bool)dbRec[DBJusticaDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.Bold])) m_FBold = (bool)dbRec[DBJusticaDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBJusticaDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBJusticaDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBJusticaDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBJusticaDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBJusticaDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBJusticaDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBJusticaDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBJusticaDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBJusticaDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBJusticaDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBJusticaDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBJusticaDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBJusticaDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBJusticaDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBJusticaDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBJusticaDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBJusticaDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBJusticaDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBJusticaDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBJusticaDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBJusticaDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBJusticaDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBJusticaDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBJusticaDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBJusticaDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBJusticaDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBJusticaDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBJusticaDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBJusticaDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBJusticaDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBJusticaDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBJusticaDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBJusticaDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBJusticaDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBJusticaDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBJusticaDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBJusticaDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBJusticaDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}