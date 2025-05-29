namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBPenhoraStatus
{
    public DBPenhoraStatus(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBPenhoraStatusDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBPenhoraStatusDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBPenhoraStatusDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBPenhoraStatusDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBPenhoraStatusDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBPenhoraStatusDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBPenhoraStatusDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBPenhoraStatus(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBPenhoraStatusDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBPenhoraStatusDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBPenhoraStatusDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBPenhoraStatusDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBPenhoraStatusDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBPenhoraStatusDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBPenhoraStatusDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_PenhoraStatus
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [phsCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
m_FNome = dbRec[DBPenhoraStatusDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBPenhoraStatusDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBPenhoraStatusDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBPenhoraStatusDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBPenhoraStatusDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBPenhoraStatusDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBPenhoraStatusDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBPenhoraStatusDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBPenhoraStatusDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBPenhoraStatusDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBPenhoraStatusDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBPenhoraStatusDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPenhoraStatusDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPenhoraStatusDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPenhoraStatusDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPenhoraStatusDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPenhoraStatusDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBPenhoraStatusDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPenhoraStatusDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPenhoraStatusDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPenhoraStatusDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPenhoraStatusDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPenhoraStatusDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBPenhoraStatusDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPenhoraStatusDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPenhoraStatusDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPenhoraStatusDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPenhoraStatusDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPenhoraStatusDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBPenhoraStatusDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPenhoraStatusDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPenhoraStatusDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPenhoraStatusDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPenhoraStatusDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPenhoraStatusDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBPenhoraStatusDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPenhoraStatusDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPenhoraStatusDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPenhoraStatusDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPenhoraStatusDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPenhoraStatusDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBPenhoraStatusDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_PenhoraStatus
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
m_FNome = dbRec[DBPenhoraStatusDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBPenhoraStatusDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBPenhoraStatusDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBPenhoraStatusDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBPenhoraStatusDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBPenhoraStatusDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBPenhoraStatusDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBPenhoraStatusDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBPenhoraStatusDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBPenhoraStatusDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBPenhoraStatusDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBPenhoraStatusDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPenhoraStatusDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPenhoraStatusDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPenhoraStatusDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPenhoraStatusDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPenhoraStatusDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBPenhoraStatusDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPenhoraStatusDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPenhoraStatusDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPenhoraStatusDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPenhoraStatusDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPenhoraStatusDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBPenhoraStatusDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPenhoraStatusDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPenhoraStatusDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPenhoraStatusDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPenhoraStatusDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPenhoraStatusDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBPenhoraStatusDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPenhoraStatusDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPenhoraStatusDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPenhoraStatusDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPenhoraStatusDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPenhoraStatusDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBPenhoraStatusDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPenhoraStatusDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPenhoraStatusDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPenhoraStatusDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPenhoraStatusDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPenhoraStatusDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPenhoraStatusDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBPenhoraStatusDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}