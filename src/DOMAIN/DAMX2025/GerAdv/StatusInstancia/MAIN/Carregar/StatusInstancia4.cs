namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBStatusInstancia
{
    public DBStatusInstancia(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBStatusInstanciaDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBStatusInstanciaDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBStatusInstanciaDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBStatusInstanciaDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBStatusInstanciaDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBStatusInstanciaDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBStatusInstanciaDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBStatusInstanciaDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBStatusInstancia(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBStatusInstanciaDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBStatusInstanciaDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBStatusInstanciaDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBStatusInstanciaDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBStatusInstanciaDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBStatusInstanciaDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBStatusInstanciaDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBStatusInstanciaDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_StatusInstancia
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [istCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
m_FNome = dbRec[DBStatusInstanciaDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBStatusInstanciaDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBStatusInstanciaDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBStatusInstanciaDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBStatusInstanciaDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBStatusInstanciaDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.Bold])) m_FBold = (bool)dbRec[DBStatusInstanciaDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.Bold])) m_FBold = (bool)dbRec[DBStatusInstanciaDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.Bold])) m_FBold = (bool)dbRec[DBStatusInstanciaDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.Bold])) m_FBold = (bool)dbRec[DBStatusInstanciaDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.Bold])) m_FBold = (bool)dbRec[DBStatusInstanciaDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBStatusInstanciaDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBStatusInstanciaDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBStatusInstanciaDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBStatusInstanciaDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBStatusInstanciaDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBStatusInstanciaDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBStatusInstanciaDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBStatusInstanciaDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBStatusInstanciaDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBStatusInstanciaDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBStatusInstanciaDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBStatusInstanciaDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBStatusInstanciaDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBStatusInstanciaDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBStatusInstanciaDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBStatusInstanciaDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBStatusInstanciaDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBStatusInstanciaDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBStatusInstanciaDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBStatusInstanciaDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBStatusInstanciaDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBStatusInstanciaDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBStatusInstanciaDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBStatusInstanciaDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBStatusInstanciaDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBStatusInstanciaDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBStatusInstanciaDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBStatusInstanciaDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBStatusInstanciaDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBStatusInstanciaDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBStatusInstanciaDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBStatusInstanciaDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBStatusInstanciaDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBStatusInstanciaDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBStatusInstanciaDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBStatusInstanciaDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBStatusInstanciaDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_StatusInstancia
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
m_FNome = dbRec[DBStatusInstanciaDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBStatusInstanciaDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBStatusInstanciaDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBStatusInstanciaDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBStatusInstanciaDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBStatusInstanciaDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.Bold])) m_FBold = (bool)dbRec[DBStatusInstanciaDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.Bold])) m_FBold = (bool)dbRec[DBStatusInstanciaDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.Bold])) m_FBold = (bool)dbRec[DBStatusInstanciaDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.Bold])) m_FBold = (bool)dbRec[DBStatusInstanciaDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.Bold])) m_FBold = (bool)dbRec[DBStatusInstanciaDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBStatusInstanciaDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBStatusInstanciaDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBStatusInstanciaDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBStatusInstanciaDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBStatusInstanciaDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBStatusInstanciaDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBStatusInstanciaDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBStatusInstanciaDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBStatusInstanciaDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBStatusInstanciaDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBStatusInstanciaDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBStatusInstanciaDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBStatusInstanciaDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBStatusInstanciaDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBStatusInstanciaDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBStatusInstanciaDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBStatusInstanciaDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBStatusInstanciaDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBStatusInstanciaDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBStatusInstanciaDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBStatusInstanciaDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBStatusInstanciaDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBStatusInstanciaDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBStatusInstanciaDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBStatusInstanciaDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBStatusInstanciaDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBStatusInstanciaDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBStatusInstanciaDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBStatusInstanciaDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBStatusInstanciaDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBStatusInstanciaDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBStatusInstanciaDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBStatusInstanciaDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBStatusInstanciaDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBStatusInstanciaDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBStatusInstanciaDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBStatusInstanciaDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBStatusInstanciaDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}