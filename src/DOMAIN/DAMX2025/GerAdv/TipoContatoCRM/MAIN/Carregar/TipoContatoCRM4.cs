namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBTipoContatoCRM
{
    public DBTipoContatoCRM(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBTipoContatoCRMDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoContatoCRMDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBTipoContatoCRMDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoContatoCRMDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBTipoContatoCRMDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBTipoContatoCRMDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBTipoContatoCRMDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBTipoContatoCRMDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBTipoContatoCRM(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBTipoContatoCRMDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoContatoCRMDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBTipoContatoCRMDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoContatoCRMDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBTipoContatoCRMDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBTipoContatoCRMDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBTipoContatoCRMDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBTipoContatoCRMDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_TipoContatoCRM
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [tccCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
m_FNome = dbRec[DBTipoContatoCRMDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBTipoContatoCRMDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBTipoContatoCRMDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBTipoContatoCRMDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBTipoContatoCRMDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBTipoContatoCRMDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.Bold])) m_FBold = (bool)dbRec[DBTipoContatoCRMDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.Bold])) m_FBold = (bool)dbRec[DBTipoContatoCRMDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.Bold])) m_FBold = (bool)dbRec[DBTipoContatoCRMDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.Bold])) m_FBold = (bool)dbRec[DBTipoContatoCRMDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.Bold])) m_FBold = (bool)dbRec[DBTipoContatoCRMDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBTipoContatoCRMDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBTipoContatoCRMDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBTipoContatoCRMDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBTipoContatoCRMDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBTipoContatoCRMDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBTipoContatoCRMDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBTipoContatoCRMDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTipoContatoCRMDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTipoContatoCRMDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTipoContatoCRMDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTipoContatoCRMDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTipoContatoCRMDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBTipoContatoCRMDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTipoContatoCRMDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTipoContatoCRMDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTipoContatoCRMDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTipoContatoCRMDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTipoContatoCRMDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBTipoContatoCRMDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoContatoCRMDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoContatoCRMDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoContatoCRMDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoContatoCRMDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoContatoCRMDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoContatoCRMDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoContatoCRMDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoContatoCRMDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoContatoCRMDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoContatoCRMDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoContatoCRMDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoContatoCRMDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTipoContatoCRMDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTipoContatoCRMDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTipoContatoCRMDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTipoContatoCRMDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTipoContatoCRMDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBTipoContatoCRMDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_TipoContatoCRM
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
m_FNome = dbRec[DBTipoContatoCRMDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBTipoContatoCRMDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBTipoContatoCRMDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBTipoContatoCRMDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBTipoContatoCRMDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBTipoContatoCRMDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.Bold])) m_FBold = (bool)dbRec[DBTipoContatoCRMDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.Bold])) m_FBold = (bool)dbRec[DBTipoContatoCRMDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.Bold])) m_FBold = (bool)dbRec[DBTipoContatoCRMDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.Bold])) m_FBold = (bool)dbRec[DBTipoContatoCRMDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.Bold])) m_FBold = (bool)dbRec[DBTipoContatoCRMDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBTipoContatoCRMDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBTipoContatoCRMDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBTipoContatoCRMDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBTipoContatoCRMDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBTipoContatoCRMDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBTipoContatoCRMDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBTipoContatoCRMDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTipoContatoCRMDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTipoContatoCRMDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTipoContatoCRMDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTipoContatoCRMDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBTipoContatoCRMDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBTipoContatoCRMDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTipoContatoCRMDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTipoContatoCRMDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTipoContatoCRMDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTipoContatoCRMDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBTipoContatoCRMDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBTipoContatoCRMDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoContatoCRMDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoContatoCRMDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoContatoCRMDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoContatoCRMDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoContatoCRMDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBTipoContatoCRMDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoContatoCRMDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoContatoCRMDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoContatoCRMDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoContatoCRMDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoContatoCRMDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBTipoContatoCRMDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTipoContatoCRMDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTipoContatoCRMDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTipoContatoCRMDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTipoContatoCRMDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.Visto])) m_FVisto = (bool)dbRec[DBTipoContatoCRMDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBTipoContatoCRMDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBTipoContatoCRMDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}