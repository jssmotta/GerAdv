namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBEMPClassRiscos
{
    public DBEMPClassRiscos(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBEMPClassRiscosDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBEMPClassRiscosDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBEMPClassRiscosDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBEMPClassRiscosDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBEMPClassRiscosDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBEMPClassRiscosDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBEMPClassRiscosDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBEMPClassRiscosDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBEMPClassRiscos(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBEMPClassRiscosDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBEMPClassRiscosDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBEMPClassRiscosDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBEMPClassRiscosDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBEMPClassRiscosDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBEMPClassRiscosDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBEMPClassRiscosDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBEMPClassRiscosDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_EMPClassRiscos
    protected void Carregar(int id, SqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM dbo.[EMPClassRiscos] (NOLOCK) WHERE [ecrCodigo] = @ThisIDToLoad", oCnn);
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
m_FNome = dbRec[DBEMPClassRiscosDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBEMPClassRiscosDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBEMPClassRiscosDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBEMPClassRiscosDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBEMPClassRiscosDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBEMPClassRiscosDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.Bold])) m_FBold = (bool)dbRec[DBEMPClassRiscosDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.Bold])) m_FBold = (bool)dbRec[DBEMPClassRiscosDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.Bold])) m_FBold = (bool)dbRec[DBEMPClassRiscosDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.Bold])) m_FBold = (bool)dbRec[DBEMPClassRiscosDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.Bold])) m_FBold = (bool)dbRec[DBEMPClassRiscosDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBEMPClassRiscosDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBEMPClassRiscosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBEMPClassRiscosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBEMPClassRiscosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBEMPClassRiscosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBEMPClassRiscosDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBEMPClassRiscosDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBEMPClassRiscosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBEMPClassRiscosDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBEMPClassRiscosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBEMPClassRiscosDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBEMPClassRiscosDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBEMPClassRiscosDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBEMPClassRiscosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBEMPClassRiscosDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBEMPClassRiscosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBEMPClassRiscosDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBEMPClassRiscosDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBEMPClassRiscosDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBEMPClassRiscosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBEMPClassRiscosDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBEMPClassRiscosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBEMPClassRiscosDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBEMPClassRiscosDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBEMPClassRiscosDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBEMPClassRiscosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBEMPClassRiscosDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBEMPClassRiscosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBEMPClassRiscosDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBEMPClassRiscosDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBEMPClassRiscosDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBEMPClassRiscosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBEMPClassRiscosDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBEMPClassRiscosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBEMPClassRiscosDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBEMPClassRiscosDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBEMPClassRiscosDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_EMPClassRiscos
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
m_FNome = dbRec[DBEMPClassRiscosDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBEMPClassRiscosDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBEMPClassRiscosDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBEMPClassRiscosDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBEMPClassRiscosDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBEMPClassRiscosDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.Bold])) m_FBold = (bool)dbRec[DBEMPClassRiscosDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.Bold])) m_FBold = (bool)dbRec[DBEMPClassRiscosDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.Bold])) m_FBold = (bool)dbRec[DBEMPClassRiscosDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.Bold])) m_FBold = (bool)dbRec[DBEMPClassRiscosDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.Bold])) m_FBold = (bool)dbRec[DBEMPClassRiscosDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBEMPClassRiscosDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBEMPClassRiscosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBEMPClassRiscosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBEMPClassRiscosDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBEMPClassRiscosDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBEMPClassRiscosDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBEMPClassRiscosDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBEMPClassRiscosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBEMPClassRiscosDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBEMPClassRiscosDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBEMPClassRiscosDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBEMPClassRiscosDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBEMPClassRiscosDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBEMPClassRiscosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBEMPClassRiscosDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBEMPClassRiscosDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBEMPClassRiscosDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBEMPClassRiscosDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBEMPClassRiscosDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBEMPClassRiscosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBEMPClassRiscosDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBEMPClassRiscosDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBEMPClassRiscosDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBEMPClassRiscosDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBEMPClassRiscosDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBEMPClassRiscosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBEMPClassRiscosDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBEMPClassRiscosDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBEMPClassRiscosDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBEMPClassRiscosDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBEMPClassRiscosDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBEMPClassRiscosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBEMPClassRiscosDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBEMPClassRiscosDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBEMPClassRiscosDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.Visto])) m_FVisto = (bool)dbRec[DBEMPClassRiscosDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBEMPClassRiscosDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBEMPClassRiscosDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}