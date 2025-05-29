namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBBensClassificacao
{
    public DBBensClassificacao(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBBensClassificacaoDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBBensClassificacaoDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBBensClassificacaoDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBBensClassificacaoDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBBensClassificacaoDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBBensClassificacaoDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBBensClassificacaoDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBBensClassificacaoDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBBensClassificacao(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBBensClassificacaoDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBBensClassificacaoDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBBensClassificacaoDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBBensClassificacaoDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBBensClassificacaoDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBBensClassificacaoDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBBensClassificacaoDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBBensClassificacaoDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_BensClassificacao
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [bcsCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
m_FNome = dbRec[DBBensClassificacaoDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBBensClassificacaoDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBBensClassificacaoDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBBensClassificacaoDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBBensClassificacaoDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBBensClassificacaoDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.Bold])) m_FBold = (bool)dbRec[DBBensClassificacaoDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.Bold])) m_FBold = (bool)dbRec[DBBensClassificacaoDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.Bold])) m_FBold = (bool)dbRec[DBBensClassificacaoDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.Bold])) m_FBold = (bool)dbRec[DBBensClassificacaoDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.Bold])) m_FBold = (bool)dbRec[DBBensClassificacaoDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBBensClassificacaoDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBBensClassificacaoDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBBensClassificacaoDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBBensClassificacaoDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBBensClassificacaoDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBBensClassificacaoDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBBensClassificacaoDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBBensClassificacaoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBBensClassificacaoDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBBensClassificacaoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBBensClassificacaoDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBBensClassificacaoDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBBensClassificacaoDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBBensClassificacaoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBBensClassificacaoDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBBensClassificacaoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBBensClassificacaoDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBBensClassificacaoDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBBensClassificacaoDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBBensClassificacaoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBBensClassificacaoDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBBensClassificacaoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBBensClassificacaoDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBBensClassificacaoDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBBensClassificacaoDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBBensClassificacaoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBBensClassificacaoDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBBensClassificacaoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBBensClassificacaoDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBBensClassificacaoDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBBensClassificacaoDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBBensClassificacaoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBBensClassificacaoDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBBensClassificacaoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBBensClassificacaoDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBBensClassificacaoDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBBensClassificacaoDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_BensClassificacao
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
m_FNome = dbRec[DBBensClassificacaoDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBBensClassificacaoDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBBensClassificacaoDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBBensClassificacaoDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBBensClassificacaoDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBBensClassificacaoDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.Bold])) m_FBold = (bool)dbRec[DBBensClassificacaoDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.Bold])) m_FBold = (bool)dbRec[DBBensClassificacaoDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.Bold])) m_FBold = (bool)dbRec[DBBensClassificacaoDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.Bold])) m_FBold = (bool)dbRec[DBBensClassificacaoDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.Bold])) m_FBold = (bool)dbRec[DBBensClassificacaoDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBBensClassificacaoDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBBensClassificacaoDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBBensClassificacaoDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBBensClassificacaoDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBBensClassificacaoDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBBensClassificacaoDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBBensClassificacaoDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBBensClassificacaoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBBensClassificacaoDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBBensClassificacaoDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBBensClassificacaoDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBBensClassificacaoDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBBensClassificacaoDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBBensClassificacaoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBBensClassificacaoDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBBensClassificacaoDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBBensClassificacaoDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBBensClassificacaoDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBBensClassificacaoDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBBensClassificacaoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBBensClassificacaoDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBBensClassificacaoDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBBensClassificacaoDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBBensClassificacaoDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBBensClassificacaoDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBBensClassificacaoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBBensClassificacaoDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBBensClassificacaoDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBBensClassificacaoDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBBensClassificacaoDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBBensClassificacaoDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBBensClassificacaoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBBensClassificacaoDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBBensClassificacaoDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBBensClassificacaoDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.Visto])) m_FVisto = (bool)dbRec[DBBensClassificacaoDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBBensClassificacaoDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBBensClassificacaoDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}