namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBRito
{
    public DBRito(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBRitoDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBRitoDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBRitoDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBRitoDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBRitoDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.Top]))
                m_FTop = (bool)dbRec[DBRitoDicInfo.Top];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBRitoDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FDescricao = dbRec[DBRitoDicInfo.Descricao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBRitoDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBRito(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBRitoDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBRitoDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBRitoDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBRitoDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBRitoDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.Top]))
                m_FTop = (bool)dbRec[DBRitoDicInfo.Top];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBRitoDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FDescricao = dbRec[DBRitoDicInfo.Descricao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBRitoDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_Rito
    protected void Carregar(int id, SqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM dbo.[Rito] (NOLOCK) WHERE [ritCodigo] = @ThisIDToLoad", oCnn);
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
m_FDescricao = dbRec[DBRitoDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBRitoDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { m_FDescricao = dbRec[DBRitoDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBRitoDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FDescricao = dbRec[DBRitoDicInfo.Descricao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FDescricao = dbRec[DBRitoDicInfo.Descricao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.Top])) m_FTop = (bool)dbRec[DBRitoDicInfo.Top]; if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.Top])) m_FTop = (bool)dbRec[DBRitoDicInfo.Top];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.Top])) m_FTop = (bool)dbRec[DBRitoDicInfo.Top]; if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.Top])) m_FTop = (bool)dbRec[DBRitoDicInfo.Top];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.Top])) m_FTop = (bool)dbRec[DBRitoDicInfo.Top]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.Top]))
            m_FTop = (bool)dbRec[DBRitoDicInfo.Top];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.Bold])) m_FBold = (bool)dbRec[DBRitoDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.Bold])) m_FBold = (bool)dbRec[DBRitoDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.Bold])) m_FBold = (bool)dbRec[DBRitoDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.Bold])) m_FBold = (bool)dbRec[DBRitoDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.Bold])) m_FBold = (bool)dbRec[DBRitoDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBRitoDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBRitoDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBRitoDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBRitoDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBRitoDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBRitoDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBRitoDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBRitoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBRitoDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBRitoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBRitoDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBRitoDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBRitoDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBRitoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBRitoDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBRitoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBRitoDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBRitoDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBRitoDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBRitoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBRitoDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBRitoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBRitoDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBRitoDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBRitoDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBRitoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBRitoDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBRitoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBRitoDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBRitoDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBRitoDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBRitoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBRitoDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBRitoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBRitoDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBRitoDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBRitoDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_Rito
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
m_FDescricao = dbRec[DBRitoDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBRitoDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { m_FDescricao = dbRec[DBRitoDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBRitoDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FDescricao = dbRec[DBRitoDicInfo.Descricao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FDescricao = dbRec[DBRitoDicInfo.Descricao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.Top])) m_FTop = (bool)dbRec[DBRitoDicInfo.Top]; if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.Top])) m_FTop = (bool)dbRec[DBRitoDicInfo.Top];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.Top])) m_FTop = (bool)dbRec[DBRitoDicInfo.Top]; if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.Top])) m_FTop = (bool)dbRec[DBRitoDicInfo.Top];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.Top])) m_FTop = (bool)dbRec[DBRitoDicInfo.Top]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.Top]))
            m_FTop = (bool)dbRec[DBRitoDicInfo.Top];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.Bold])) m_FBold = (bool)dbRec[DBRitoDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.Bold])) m_FBold = (bool)dbRec[DBRitoDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.Bold])) m_FBold = (bool)dbRec[DBRitoDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.Bold])) m_FBold = (bool)dbRec[DBRitoDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.Bold])) m_FBold = (bool)dbRec[DBRitoDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBRitoDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBRitoDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBRitoDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBRitoDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBRitoDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBRitoDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBRitoDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBRitoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBRitoDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBRitoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBRitoDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBRitoDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBRitoDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBRitoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBRitoDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBRitoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBRitoDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBRitoDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBRitoDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBRitoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBRitoDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBRitoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBRitoDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBRitoDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBRitoDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBRitoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBRitoDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBRitoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBRitoDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBRitoDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBRitoDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBRitoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBRitoDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBRitoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBRitoDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBRitoDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBRitoDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBRitoDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}