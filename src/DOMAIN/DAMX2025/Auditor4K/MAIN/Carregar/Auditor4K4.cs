namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBAuditor4K
{
    public DBAuditor4K(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBAuditor4KDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBAuditor4KDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBAuditor4KDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBAuditor4KDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBAuditor4KDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBAuditor4KDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBAuditor4KDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBAuditor4K(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBAuditor4KDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBAuditor4KDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBAuditor4KDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBAuditor4KDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBAuditor4KDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBAuditor4KDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBAuditor4KDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_Auditor4K
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [audCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
m_FNome = dbRec[DBAuditor4KDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBAuditor4KDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBAuditor4KDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBAuditor4KDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBAuditor4KDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBAuditor4KDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBAuditor4KDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBAuditor4KDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBAuditor4KDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBAuditor4KDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBAuditor4KDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBAuditor4KDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAuditor4KDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAuditor4KDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAuditor4KDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAuditor4KDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAuditor4KDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBAuditor4KDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAuditor4KDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAuditor4KDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAuditor4KDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAuditor4KDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAuditor4KDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBAuditor4KDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAuditor4KDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAuditor4KDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAuditor4KDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAuditor4KDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAuditor4KDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBAuditor4KDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAuditor4KDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAuditor4KDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAuditor4KDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAuditor4KDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAuditor4KDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBAuditor4KDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAuditor4KDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAuditor4KDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAuditor4KDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAuditor4KDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAuditor4KDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBAuditor4KDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_Auditor4K
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
m_FNome = dbRec[DBAuditor4KDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBAuditor4KDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBAuditor4KDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBAuditor4KDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBAuditor4KDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBAuditor4KDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBAuditor4KDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBAuditor4KDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBAuditor4KDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBAuditor4KDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBAuditor4KDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBAuditor4KDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAuditor4KDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAuditor4KDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAuditor4KDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAuditor4KDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAuditor4KDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBAuditor4KDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAuditor4KDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAuditor4KDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAuditor4KDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAuditor4KDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAuditor4KDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBAuditor4KDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAuditor4KDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAuditor4KDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAuditor4KDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAuditor4KDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAuditor4KDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBAuditor4KDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAuditor4KDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAuditor4KDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAuditor4KDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAuditor4KDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAuditor4KDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBAuditor4KDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAuditor4KDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAuditor4KDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAuditor4KDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAuditor4KDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAuditor4KDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAuditor4KDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBAuditor4KDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}