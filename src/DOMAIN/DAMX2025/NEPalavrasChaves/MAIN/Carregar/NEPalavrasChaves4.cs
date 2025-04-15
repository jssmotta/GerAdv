namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBNEPalavrasChaves
{
    public DBNEPalavrasChaves(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBNEPalavrasChavesDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBNEPalavrasChavesDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBNEPalavrasChavesDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBNEPalavrasChavesDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBNEPalavrasChavesDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBNEPalavrasChavesDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBNEPalavrasChavesDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBNEPalavrasChaves(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBNEPalavrasChavesDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBNEPalavrasChavesDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBNEPalavrasChavesDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBNEPalavrasChavesDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBNEPalavrasChavesDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBNEPalavrasChavesDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBNEPalavrasChavesDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_NEPalavrasChaves
    protected void Carregar(int id, SqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM dbo.[NEPalavrasChaves] (NOLOCK) WHERE [npcCodigo] = @ThisIDToLoad", oCnn);
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
m_FNome = dbRec[DBNEPalavrasChavesDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBNEPalavrasChavesDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBNEPalavrasChavesDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBNEPalavrasChavesDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBNEPalavrasChavesDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBNEPalavrasChavesDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.Bold])) m_FBold = (bool)dbRec[DBNEPalavrasChavesDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.Bold])) m_FBold = (bool)dbRec[DBNEPalavrasChavesDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.Bold])) m_FBold = (bool)dbRec[DBNEPalavrasChavesDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.Bold])) m_FBold = (bool)dbRec[DBNEPalavrasChavesDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.Bold])) m_FBold = (bool)dbRec[DBNEPalavrasChavesDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBNEPalavrasChavesDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBNEPalavrasChavesDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBNEPalavrasChavesDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBNEPalavrasChavesDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBNEPalavrasChavesDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBNEPalavrasChavesDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBNEPalavrasChavesDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBNEPalavrasChavesDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBNEPalavrasChavesDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBNEPalavrasChavesDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBNEPalavrasChavesDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBNEPalavrasChavesDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBNEPalavrasChavesDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBNEPalavrasChavesDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBNEPalavrasChavesDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBNEPalavrasChavesDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBNEPalavrasChavesDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBNEPalavrasChavesDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBNEPalavrasChavesDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBNEPalavrasChavesDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBNEPalavrasChavesDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBNEPalavrasChavesDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBNEPalavrasChavesDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBNEPalavrasChavesDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBNEPalavrasChavesDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBNEPalavrasChavesDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBNEPalavrasChavesDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBNEPalavrasChavesDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBNEPalavrasChavesDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBNEPalavrasChavesDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBNEPalavrasChavesDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_NEPalavrasChaves
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
m_FNome = dbRec[DBNEPalavrasChavesDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBNEPalavrasChavesDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBNEPalavrasChavesDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBNEPalavrasChavesDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBNEPalavrasChavesDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBNEPalavrasChavesDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.Bold])) m_FBold = (bool)dbRec[DBNEPalavrasChavesDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.Bold])) m_FBold = (bool)dbRec[DBNEPalavrasChavesDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.Bold])) m_FBold = (bool)dbRec[DBNEPalavrasChavesDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.Bold])) m_FBold = (bool)dbRec[DBNEPalavrasChavesDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.Bold])) m_FBold = (bool)dbRec[DBNEPalavrasChavesDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBNEPalavrasChavesDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBNEPalavrasChavesDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBNEPalavrasChavesDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBNEPalavrasChavesDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBNEPalavrasChavesDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBNEPalavrasChavesDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBNEPalavrasChavesDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBNEPalavrasChavesDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBNEPalavrasChavesDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBNEPalavrasChavesDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBNEPalavrasChavesDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBNEPalavrasChavesDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBNEPalavrasChavesDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBNEPalavrasChavesDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBNEPalavrasChavesDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBNEPalavrasChavesDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBNEPalavrasChavesDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBNEPalavrasChavesDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBNEPalavrasChavesDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBNEPalavrasChavesDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBNEPalavrasChavesDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBNEPalavrasChavesDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBNEPalavrasChavesDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBNEPalavrasChavesDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBNEPalavrasChavesDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBNEPalavrasChavesDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBNEPalavrasChavesDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBNEPalavrasChavesDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBNEPalavrasChavesDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBNEPalavrasChavesDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBNEPalavrasChavesDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBNEPalavrasChavesDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}