namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBProTipoBaixa
{
    public DBProTipoBaixa(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBProTipoBaixaDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBProTipoBaixaDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBProTipoBaixaDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBProTipoBaixaDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBProTipoBaixaDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBProTipoBaixaDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBProTipoBaixaDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBProTipoBaixaDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBProTipoBaixa(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBProTipoBaixaDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBProTipoBaixaDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBProTipoBaixaDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBProTipoBaixaDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBProTipoBaixaDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBProTipoBaixaDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBProTipoBaixaDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBProTipoBaixaDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_ProTipoBaixa
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [ptxCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
m_FNome = dbRec[DBProTipoBaixaDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBProTipoBaixaDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBProTipoBaixaDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBProTipoBaixaDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBProTipoBaixaDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBProTipoBaixaDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.Bold])) m_FBold = (bool)dbRec[DBProTipoBaixaDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.Bold])) m_FBold = (bool)dbRec[DBProTipoBaixaDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.Bold])) m_FBold = (bool)dbRec[DBProTipoBaixaDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.Bold])) m_FBold = (bool)dbRec[DBProTipoBaixaDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.Bold])) m_FBold = (bool)dbRec[DBProTipoBaixaDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBProTipoBaixaDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBProTipoBaixaDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBProTipoBaixaDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBProTipoBaixaDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBProTipoBaixaDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBProTipoBaixaDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBProTipoBaixaDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProTipoBaixaDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProTipoBaixaDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProTipoBaixaDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProTipoBaixaDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProTipoBaixaDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBProTipoBaixaDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProTipoBaixaDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProTipoBaixaDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProTipoBaixaDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProTipoBaixaDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProTipoBaixaDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBProTipoBaixaDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProTipoBaixaDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProTipoBaixaDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProTipoBaixaDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProTipoBaixaDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProTipoBaixaDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBProTipoBaixaDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProTipoBaixaDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProTipoBaixaDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProTipoBaixaDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProTipoBaixaDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProTipoBaixaDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBProTipoBaixaDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProTipoBaixaDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProTipoBaixaDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProTipoBaixaDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProTipoBaixaDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProTipoBaixaDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBProTipoBaixaDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_ProTipoBaixa
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
m_FNome = dbRec[DBProTipoBaixaDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBProTipoBaixaDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBProTipoBaixaDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBProTipoBaixaDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBProTipoBaixaDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBProTipoBaixaDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.Bold])) m_FBold = (bool)dbRec[DBProTipoBaixaDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.Bold])) m_FBold = (bool)dbRec[DBProTipoBaixaDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.Bold])) m_FBold = (bool)dbRec[DBProTipoBaixaDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.Bold])) m_FBold = (bool)dbRec[DBProTipoBaixaDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.Bold])) m_FBold = (bool)dbRec[DBProTipoBaixaDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBProTipoBaixaDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBProTipoBaixaDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBProTipoBaixaDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBProTipoBaixaDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBProTipoBaixaDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBProTipoBaixaDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBProTipoBaixaDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProTipoBaixaDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProTipoBaixaDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProTipoBaixaDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProTipoBaixaDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBProTipoBaixaDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBProTipoBaixaDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProTipoBaixaDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProTipoBaixaDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProTipoBaixaDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProTipoBaixaDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBProTipoBaixaDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBProTipoBaixaDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProTipoBaixaDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProTipoBaixaDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProTipoBaixaDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProTipoBaixaDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBProTipoBaixaDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBProTipoBaixaDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProTipoBaixaDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProTipoBaixaDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProTipoBaixaDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProTipoBaixaDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBProTipoBaixaDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBProTipoBaixaDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProTipoBaixaDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProTipoBaixaDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProTipoBaixaDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProTipoBaixaDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBProTipoBaixaDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBProTipoBaixaDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBProTipoBaixaDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}