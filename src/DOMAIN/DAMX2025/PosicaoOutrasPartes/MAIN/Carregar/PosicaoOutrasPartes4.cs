namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBPosicaoOutrasPartes
{
    public DBPosicaoOutrasPartes(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBPosicaoOutrasPartesDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBPosicaoOutrasPartesDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBPosicaoOutrasPartesDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBPosicaoOutrasPartesDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBPosicaoOutrasPartesDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBPosicaoOutrasPartesDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FDescricao = dbRec[DBPosicaoOutrasPartesDicInfo.Descricao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBPosicaoOutrasPartesDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBPosicaoOutrasPartes(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.Bold]))
                m_FBold = (bool)dbRec[DBPosicaoOutrasPartesDicInfo.Bold];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBPosicaoOutrasPartesDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBPosicaoOutrasPartesDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBPosicaoOutrasPartesDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBPosicaoOutrasPartesDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBPosicaoOutrasPartesDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FDescricao = dbRec[DBPosicaoOutrasPartesDicInfo.Descricao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBPosicaoOutrasPartesDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_PosicaoOutrasPartes
    protected void Carregar(int id, SqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM dbo.[PosicaoOutrasPartes] (NOLOCK) WHERE [posCodigo] = @ThisIDToLoad", oCnn);
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
m_FDescricao = dbRec[DBPosicaoOutrasPartesDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBPosicaoOutrasPartesDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { m_FDescricao = dbRec[DBPosicaoOutrasPartesDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBPosicaoOutrasPartesDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FDescricao = dbRec[DBPosicaoOutrasPartesDicInfo.Descricao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FDescricao = dbRec[DBPosicaoOutrasPartesDicInfo.Descricao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.Bold])) m_FBold = (bool)dbRec[DBPosicaoOutrasPartesDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.Bold])) m_FBold = (bool)dbRec[DBPosicaoOutrasPartesDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.Bold])) m_FBold = (bool)dbRec[DBPosicaoOutrasPartesDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.Bold])) m_FBold = (bool)dbRec[DBPosicaoOutrasPartesDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.Bold])) m_FBold = (bool)dbRec[DBPosicaoOutrasPartesDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBPosicaoOutrasPartesDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBPosicaoOutrasPartesDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBPosicaoOutrasPartesDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBPosicaoOutrasPartesDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBPosicaoOutrasPartesDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBPosicaoOutrasPartesDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBPosicaoOutrasPartesDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPosicaoOutrasPartesDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPosicaoOutrasPartesDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPosicaoOutrasPartesDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPosicaoOutrasPartesDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPosicaoOutrasPartesDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBPosicaoOutrasPartesDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPosicaoOutrasPartesDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPosicaoOutrasPartesDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPosicaoOutrasPartesDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPosicaoOutrasPartesDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPosicaoOutrasPartesDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBPosicaoOutrasPartesDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPosicaoOutrasPartesDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPosicaoOutrasPartesDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPosicaoOutrasPartesDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPosicaoOutrasPartesDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPosicaoOutrasPartesDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBPosicaoOutrasPartesDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPosicaoOutrasPartesDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPosicaoOutrasPartesDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPosicaoOutrasPartesDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPosicaoOutrasPartesDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPosicaoOutrasPartesDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBPosicaoOutrasPartesDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPosicaoOutrasPartesDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPosicaoOutrasPartesDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPosicaoOutrasPartesDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPosicaoOutrasPartesDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPosicaoOutrasPartesDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBPosicaoOutrasPartesDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_PosicaoOutrasPartes
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
m_FDescricao = dbRec[DBPosicaoOutrasPartesDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBPosicaoOutrasPartesDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { m_FDescricao = dbRec[DBPosicaoOutrasPartesDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBPosicaoOutrasPartesDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FDescricao = dbRec[DBPosicaoOutrasPartesDicInfo.Descricao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FDescricao = dbRec[DBPosicaoOutrasPartesDicInfo.Descricao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.Bold])) m_FBold = (bool)dbRec[DBPosicaoOutrasPartesDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.Bold])) m_FBold = (bool)dbRec[DBPosicaoOutrasPartesDicInfo.Bold];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.Bold])) m_FBold = (bool)dbRec[DBPosicaoOutrasPartesDicInfo.Bold]; if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.Bold])) m_FBold = (bool)dbRec[DBPosicaoOutrasPartesDicInfo.Bold];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.Bold])) m_FBold = (bool)dbRec[DBPosicaoOutrasPartesDicInfo.Bold]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.Bold]))
            m_FBold = (bool)dbRec[DBPosicaoOutrasPartesDicInfo.Bold];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBPosicaoOutrasPartesDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBPosicaoOutrasPartesDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBPosicaoOutrasPartesDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBPosicaoOutrasPartesDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBPosicaoOutrasPartesDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBPosicaoOutrasPartesDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPosicaoOutrasPartesDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPosicaoOutrasPartesDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPosicaoOutrasPartesDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPosicaoOutrasPartesDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPosicaoOutrasPartesDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBPosicaoOutrasPartesDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPosicaoOutrasPartesDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPosicaoOutrasPartesDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPosicaoOutrasPartesDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPosicaoOutrasPartesDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPosicaoOutrasPartesDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBPosicaoOutrasPartesDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPosicaoOutrasPartesDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPosicaoOutrasPartesDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPosicaoOutrasPartesDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPosicaoOutrasPartesDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPosicaoOutrasPartesDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBPosicaoOutrasPartesDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPosicaoOutrasPartesDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPosicaoOutrasPartesDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPosicaoOutrasPartesDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPosicaoOutrasPartesDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPosicaoOutrasPartesDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBPosicaoOutrasPartesDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPosicaoOutrasPartesDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPosicaoOutrasPartesDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPosicaoOutrasPartesDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPosicaoOutrasPartesDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPosicaoOutrasPartesDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPosicaoOutrasPartesDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBPosicaoOutrasPartesDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}