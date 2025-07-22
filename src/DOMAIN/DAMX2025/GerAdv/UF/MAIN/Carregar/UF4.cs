namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBUF
{
    public DBUF(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBUFDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBUFDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.Pais]))
                m_FPais = Convert.ToInt32(dbRec[DBUFDicInfo.Pais]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBUFDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBUFDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.Top]))
                m_FTop = (bool)dbRec[DBUFDicInfo.Top];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBUFDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FDDD = dbRec[DBUFDicInfo.DDD]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FDescricao = dbRec[DBUFDicInfo.Descricao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBUFDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FID = dbRec[DBUFDicInfo.ID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBUF(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBUFDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBUFDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.Pais]))
                m_FPais = Convert.ToInt32(dbRec[DBUFDicInfo.Pais]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBUFDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBUFDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.Top]))
                m_FTop = (bool)dbRec[DBUFDicInfo.Top];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBUFDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FDDD = dbRec[DBUFDicInfo.DDD]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FDescricao = dbRec[DBUFDicInfo.Descricao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBUFDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FID = dbRec[DBUFDicInfo.ID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_UF
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [ufCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
m_FDDD = dbRec[DBUFDicInfo.DDD]?.ToString() ?? string.Empty; m_FDDD = dbRec[DBUFDicInfo.DDD]?.ToString() ?? string.Empty;  } catch {}  try { m_FDDD = dbRec[DBUFDicInfo.DDD]?.ToString() ?? string.Empty; m_FDDD = dbRec[DBUFDicInfo.DDD]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FDDD = dbRec[DBUFDicInfo.DDD]?.ToString() ?? string.Empty; } catch { }

#else
        m_FDDD = dbRec[DBUFDicInfo.DDD]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FID = dbRec[DBUFDicInfo.ID]?.ToString() ?? string.Empty; m_FID = dbRec[DBUFDicInfo.ID]?.ToString() ?? string.Empty;  } catch {}  try { m_FID = dbRec[DBUFDicInfo.ID]?.ToString() ?? string.Empty; m_FID = dbRec[DBUFDicInfo.ID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FID = dbRec[DBUFDicInfo.ID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FID = dbRec[DBUFDicInfo.ID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.Pais])) m_FPais = Convert.ToInt32(dbRec[DBUFDicInfo.Pais]); if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.Pais])) m_FPais = Convert.ToInt32(dbRec[DBUFDicInfo.Pais]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.Pais])) m_FPais = Convert.ToInt32(dbRec[DBUFDicInfo.Pais]); if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.Pais])) m_FPais = Convert.ToInt32(dbRec[DBUFDicInfo.Pais]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.Pais])) m_FPais = Convert.ToInt32(dbRec[DBUFDicInfo.Pais]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.Pais]))
            m_FPais = Convert.ToInt32(dbRec[DBUFDicInfo.Pais]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.Top])) m_FTop = (bool)dbRec[DBUFDicInfo.Top]; if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.Top])) m_FTop = (bool)dbRec[DBUFDicInfo.Top];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.Top])) m_FTop = (bool)dbRec[DBUFDicInfo.Top]; if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.Top])) m_FTop = (bool)dbRec[DBUFDicInfo.Top];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.Top])) m_FTop = (bool)dbRec[DBUFDicInfo.Top]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.Top]))
            m_FTop = (bool)dbRec[DBUFDicInfo.Top];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FDescricao = dbRec[DBUFDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBUFDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { m_FDescricao = dbRec[DBUFDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBUFDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FDescricao = dbRec[DBUFDicInfo.Descricao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FDescricao = dbRec[DBUFDicInfo.Descricao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBUFDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBUFDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBUFDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBUFDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBUFDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBUFDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBUFDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBUFDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBUFDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBUFDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBUFDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBUFDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBUFDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBUFDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBUFDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBUFDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBUFDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBUFDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBUFDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBUFDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBUFDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBUFDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBUFDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBUFDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBUFDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBUFDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBUFDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBUFDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBUFDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBUFDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.Visto])) m_FVisto = (bool)dbRec[DBUFDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.Visto])) m_FVisto = (bool)dbRec[DBUFDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.Visto])) m_FVisto = (bool)dbRec[DBUFDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.Visto])) m_FVisto = (bool)dbRec[DBUFDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.Visto])) m_FVisto = (bool)dbRec[DBUFDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBUFDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_UF
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
m_FDDD = dbRec[DBUFDicInfo.DDD]?.ToString() ?? string.Empty; m_FDDD = dbRec[DBUFDicInfo.DDD]?.ToString() ?? string.Empty;  } catch {}  try { m_FDDD = dbRec[DBUFDicInfo.DDD]?.ToString() ?? string.Empty; m_FDDD = dbRec[DBUFDicInfo.DDD]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FDDD = dbRec[DBUFDicInfo.DDD]?.ToString() ?? string.Empty; } catch { }

#else
        m_FDDD = dbRec[DBUFDicInfo.DDD]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FID = dbRec[DBUFDicInfo.ID]?.ToString() ?? string.Empty; m_FID = dbRec[DBUFDicInfo.ID]?.ToString() ?? string.Empty;  } catch {}  try { m_FID = dbRec[DBUFDicInfo.ID]?.ToString() ?? string.Empty; m_FID = dbRec[DBUFDicInfo.ID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FID = dbRec[DBUFDicInfo.ID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FID = dbRec[DBUFDicInfo.ID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.Pais])) m_FPais = Convert.ToInt32(dbRec[DBUFDicInfo.Pais]); if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.Pais])) m_FPais = Convert.ToInt32(dbRec[DBUFDicInfo.Pais]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.Pais])) m_FPais = Convert.ToInt32(dbRec[DBUFDicInfo.Pais]); if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.Pais])) m_FPais = Convert.ToInt32(dbRec[DBUFDicInfo.Pais]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.Pais])) m_FPais = Convert.ToInt32(dbRec[DBUFDicInfo.Pais]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.Pais]))
            m_FPais = Convert.ToInt32(dbRec[DBUFDicInfo.Pais]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.Top])) m_FTop = (bool)dbRec[DBUFDicInfo.Top]; if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.Top])) m_FTop = (bool)dbRec[DBUFDicInfo.Top];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.Top])) m_FTop = (bool)dbRec[DBUFDicInfo.Top]; if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.Top])) m_FTop = (bool)dbRec[DBUFDicInfo.Top];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.Top])) m_FTop = (bool)dbRec[DBUFDicInfo.Top]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.Top]))
            m_FTop = (bool)dbRec[DBUFDicInfo.Top];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FDescricao = dbRec[DBUFDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBUFDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { m_FDescricao = dbRec[DBUFDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBUFDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FDescricao = dbRec[DBUFDicInfo.Descricao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FDescricao = dbRec[DBUFDicInfo.Descricao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBUFDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBUFDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBUFDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBUFDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBUFDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBUFDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBUFDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBUFDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBUFDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBUFDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBUFDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBUFDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBUFDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBUFDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBUFDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBUFDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBUFDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBUFDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBUFDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBUFDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBUFDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBUFDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBUFDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBUFDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBUFDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBUFDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBUFDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBUFDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBUFDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBUFDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.Visto])) m_FVisto = (bool)dbRec[DBUFDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.Visto])) m_FVisto = (bool)dbRec[DBUFDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.Visto])) m_FVisto = (bool)dbRec[DBUFDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.Visto])) m_FVisto = (bool)dbRec[DBUFDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.Visto])) m_FVisto = (bool)dbRec[DBUFDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBUFDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBUFDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}