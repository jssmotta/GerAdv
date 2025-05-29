namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBSituacao
{
    public DBSituacao(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBSituacaoDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBSituacaoDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBSituacaoDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBSituacaoDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBSituacaoDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.Top]))
                m_FTop = (bool)dbRec[DBSituacaoDicInfo.Top];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBSituacaoDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBSituacaoDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FParte_Int = dbRec[DBSituacaoDicInfo.Parte_Int]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FParte_Opo = dbRec[DBSituacaoDicInfo.Parte_Opo]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBSituacao(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBSituacaoDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBSituacaoDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBSituacaoDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBSituacaoDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBSituacaoDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.Top]))
                m_FTop = (bool)dbRec[DBSituacaoDicInfo.Top];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBSituacaoDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBSituacaoDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FParte_Int = dbRec[DBSituacaoDicInfo.Parte_Int]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FParte_Opo = dbRec[DBSituacaoDicInfo.Parte_Opo]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_Situacao
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [sitCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
m_FParte_Int = dbRec[DBSituacaoDicInfo.Parte_Int]?.ToString() ?? string.Empty; m_FParte_Int = dbRec[DBSituacaoDicInfo.Parte_Int]?.ToString() ?? string.Empty;  } catch {}  try { m_FParte_Int = dbRec[DBSituacaoDicInfo.Parte_Int]?.ToString() ?? string.Empty; m_FParte_Int = dbRec[DBSituacaoDicInfo.Parte_Int]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FParte_Int = dbRec[DBSituacaoDicInfo.Parte_Int]?.ToString() ?? string.Empty; } catch { }

#else
        m_FParte_Int = dbRec[DBSituacaoDicInfo.Parte_Int]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FParte_Opo = dbRec[DBSituacaoDicInfo.Parte_Opo]?.ToString() ?? string.Empty; m_FParte_Opo = dbRec[DBSituacaoDicInfo.Parte_Opo]?.ToString() ?? string.Empty;  } catch {}  try { m_FParte_Opo = dbRec[DBSituacaoDicInfo.Parte_Opo]?.ToString() ?? string.Empty; m_FParte_Opo = dbRec[DBSituacaoDicInfo.Parte_Opo]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FParte_Opo = dbRec[DBSituacaoDicInfo.Parte_Opo]?.ToString() ?? string.Empty; } catch { }

#else
        m_FParte_Opo = dbRec[DBSituacaoDicInfo.Parte_Opo]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.Top])) m_FTop = (bool)dbRec[DBSituacaoDicInfo.Top]; if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.Top])) m_FTop = (bool)dbRec[DBSituacaoDicInfo.Top];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.Top])) m_FTop = (bool)dbRec[DBSituacaoDicInfo.Top]; if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.Top])) m_FTop = (bool)dbRec[DBSituacaoDicInfo.Top];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.Top])) m_FTop = (bool)dbRec[DBSituacaoDicInfo.Top]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.Top]))
            m_FTop = (bool)dbRec[DBSituacaoDicInfo.Top];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.Bold])) m_FBold = (bool)dbRec[DBSituacaoDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.Bold])) m_FBold = (bool)dbRec[DBSituacaoDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.Bold])) m_FBold = (bool)dbRec[DBSituacaoDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.Bold])) m_FBold = (bool)dbRec[DBSituacaoDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.Bold])) m_FBold = (bool)dbRec[DBSituacaoDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBSituacaoDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBSituacaoDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBSituacaoDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBSituacaoDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBSituacaoDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBSituacaoDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBSituacaoDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBSituacaoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBSituacaoDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBSituacaoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBSituacaoDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBSituacaoDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBSituacaoDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBSituacaoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBSituacaoDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBSituacaoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBSituacaoDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBSituacaoDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBSituacaoDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBSituacaoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBSituacaoDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBSituacaoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBSituacaoDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBSituacaoDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBSituacaoDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBSituacaoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBSituacaoDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBSituacaoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBSituacaoDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBSituacaoDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBSituacaoDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBSituacaoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBSituacaoDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBSituacaoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBSituacaoDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBSituacaoDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBSituacaoDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_Situacao
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
m_FParte_Int = dbRec[DBSituacaoDicInfo.Parte_Int]?.ToString() ?? string.Empty; m_FParte_Int = dbRec[DBSituacaoDicInfo.Parte_Int]?.ToString() ?? string.Empty;  } catch {}  try { m_FParte_Int = dbRec[DBSituacaoDicInfo.Parte_Int]?.ToString() ?? string.Empty; m_FParte_Int = dbRec[DBSituacaoDicInfo.Parte_Int]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FParte_Int = dbRec[DBSituacaoDicInfo.Parte_Int]?.ToString() ?? string.Empty; } catch { }

#else
        m_FParte_Int = dbRec[DBSituacaoDicInfo.Parte_Int]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FParte_Opo = dbRec[DBSituacaoDicInfo.Parte_Opo]?.ToString() ?? string.Empty; m_FParte_Opo = dbRec[DBSituacaoDicInfo.Parte_Opo]?.ToString() ?? string.Empty;  } catch {}  try { m_FParte_Opo = dbRec[DBSituacaoDicInfo.Parte_Opo]?.ToString() ?? string.Empty; m_FParte_Opo = dbRec[DBSituacaoDicInfo.Parte_Opo]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FParte_Opo = dbRec[DBSituacaoDicInfo.Parte_Opo]?.ToString() ?? string.Empty; } catch { }

#else
        m_FParte_Opo = dbRec[DBSituacaoDicInfo.Parte_Opo]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.Top])) m_FTop = (bool)dbRec[DBSituacaoDicInfo.Top]; if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.Top])) m_FTop = (bool)dbRec[DBSituacaoDicInfo.Top];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.Top])) m_FTop = (bool)dbRec[DBSituacaoDicInfo.Top]; if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.Top])) m_FTop = (bool)dbRec[DBSituacaoDicInfo.Top];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.Top])) m_FTop = (bool)dbRec[DBSituacaoDicInfo.Top]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.Top]))
            m_FTop = (bool)dbRec[DBSituacaoDicInfo.Top];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.Bold])) m_FBold = (bool)dbRec[DBSituacaoDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.Bold])) m_FBold = (bool)dbRec[DBSituacaoDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.Bold])) m_FBold = (bool)dbRec[DBSituacaoDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.Bold])) m_FBold = (bool)dbRec[DBSituacaoDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.Bold])) m_FBold = (bool)dbRec[DBSituacaoDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBSituacaoDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBSituacaoDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBSituacaoDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBSituacaoDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBSituacaoDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBSituacaoDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBSituacaoDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBSituacaoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBSituacaoDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBSituacaoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBSituacaoDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBSituacaoDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBSituacaoDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBSituacaoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBSituacaoDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBSituacaoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBSituacaoDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBSituacaoDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBSituacaoDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBSituacaoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBSituacaoDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBSituacaoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBSituacaoDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBSituacaoDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBSituacaoDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBSituacaoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBSituacaoDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBSituacaoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBSituacaoDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBSituacaoDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBSituacaoDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBSituacaoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBSituacaoDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBSituacaoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBSituacaoDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBSituacaoDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBSituacaoDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBSituacaoDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}