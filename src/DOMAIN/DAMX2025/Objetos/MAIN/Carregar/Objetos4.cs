namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBObjetos
{
    public DBObjetos(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.Area]))
                m_FArea = Convert.ToInt32(dbRec[DBObjetosDicInfo.Area]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBObjetosDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBObjetosDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBObjetosDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.Justica]))
                m_FJustica = Convert.ToInt32(dbRec[DBObjetosDicInfo.Justica]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBObjetosDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBObjetosDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBObjetosDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBObjetosDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBObjetosDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBObjetos(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.Area]))
                m_FArea = Convert.ToInt32(dbRec[DBObjetosDicInfo.Area]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBObjetosDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBObjetosDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBObjetosDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.Justica]))
                m_FJustica = Convert.ToInt32(dbRec[DBObjetosDicInfo.Justica]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBObjetosDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBObjetosDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBObjetosDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBObjetosDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBObjetosDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_Objetos
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [ojtCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBObjetosDicInfo.Justica]); if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBObjetosDicInfo.Justica]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBObjetosDicInfo.Justica]); if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBObjetosDicInfo.Justica]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBObjetosDicInfo.Justica]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.Justica]))
            m_FJustica = Convert.ToInt32(dbRec[DBObjetosDicInfo.Justica]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBObjetosDicInfo.Area]); if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBObjetosDicInfo.Area]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBObjetosDicInfo.Area]); if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBObjetosDicInfo.Area]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBObjetosDicInfo.Area]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.Area]))
            m_FArea = Convert.ToInt32(dbRec[DBObjetosDicInfo.Area]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNome = dbRec[DBObjetosDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBObjetosDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBObjetosDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBObjetosDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBObjetosDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBObjetosDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.Bold])) m_FBold = (bool)dbRec[DBObjetosDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.Bold])) m_FBold = (bool)dbRec[DBObjetosDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.Bold])) m_FBold = (bool)dbRec[DBObjetosDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.Bold])) m_FBold = (bool)dbRec[DBObjetosDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.Bold])) m_FBold = (bool)dbRec[DBObjetosDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBObjetosDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBObjetosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBObjetosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBObjetosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBObjetosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBObjetosDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBObjetosDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBObjetosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBObjetosDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBObjetosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBObjetosDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBObjetosDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBObjetosDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBObjetosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBObjetosDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBObjetosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBObjetosDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBObjetosDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBObjetosDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBObjetosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBObjetosDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBObjetosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBObjetosDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBObjetosDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBObjetosDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBObjetosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBObjetosDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBObjetosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBObjetosDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBObjetosDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBObjetosDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBObjetosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBObjetosDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBObjetosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBObjetosDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBObjetosDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBObjetosDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_Objetos
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
if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBObjetosDicInfo.Justica]); if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBObjetosDicInfo.Justica]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBObjetosDicInfo.Justica]); if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBObjetosDicInfo.Justica]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.Justica])) m_FJustica = Convert.ToInt32(dbRec[DBObjetosDicInfo.Justica]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.Justica]))
            m_FJustica = Convert.ToInt32(dbRec[DBObjetosDicInfo.Justica]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBObjetosDicInfo.Area]); if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBObjetosDicInfo.Area]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBObjetosDicInfo.Area]); if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBObjetosDicInfo.Area]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.Area])) m_FArea = Convert.ToInt32(dbRec[DBObjetosDicInfo.Area]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.Area]))
            m_FArea = Convert.ToInt32(dbRec[DBObjetosDicInfo.Area]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FNome = dbRec[DBObjetosDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBObjetosDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBObjetosDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBObjetosDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBObjetosDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBObjetosDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.Bold])) m_FBold = (bool)dbRec[DBObjetosDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.Bold])) m_FBold = (bool)dbRec[DBObjetosDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.Bold])) m_FBold = (bool)dbRec[DBObjetosDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.Bold])) m_FBold = (bool)dbRec[DBObjetosDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.Bold])) m_FBold = (bool)dbRec[DBObjetosDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBObjetosDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBObjetosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBObjetosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBObjetosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBObjetosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBObjetosDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBObjetosDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBObjetosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBObjetosDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBObjetosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBObjetosDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBObjetosDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBObjetosDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBObjetosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBObjetosDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBObjetosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBObjetosDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBObjetosDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBObjetosDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBObjetosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBObjetosDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBObjetosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBObjetosDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBObjetosDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBObjetosDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBObjetosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBObjetosDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBObjetosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBObjetosDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBObjetosDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBObjetosDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBObjetosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBObjetosDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBObjetosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBObjetosDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBObjetosDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBObjetosDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBObjetosDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}