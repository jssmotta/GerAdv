namespace MenphisSI.SG.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBArea
{
    public DBArea(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBAreaDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBAreaDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBAreaDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBAreaDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.Top]))
                m_FTop = (bool)dbRec[DBAreaDicInfo.Top];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBAreaDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FDescricao = dbRec[DBAreaDicInfo.Descricao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBAreaDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBArea(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBAreaDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBAreaDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBAreaDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBAreaDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.Top]))
                m_FTop = (bool)dbRec[DBAreaDicInfo.Top];
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBAreaDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FDescricao = dbRec[DBAreaDicInfo.Descricao]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBAreaDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_Area
    protected void Carregar(int id, MsiSqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) WHERE [areCodigo] = @ThisIDToLoad", oCnn?.InnerConnection);
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
m_FDescricao = dbRec[DBAreaDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBAreaDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { m_FDescricao = dbRec[DBAreaDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBAreaDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FDescricao = dbRec[DBAreaDicInfo.Descricao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FDescricao = dbRec[DBAreaDicInfo.Descricao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.Top])) m_FTop = (bool)dbRec[DBAreaDicInfo.Top]; if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.Top])) m_FTop = (bool)dbRec[DBAreaDicInfo.Top];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.Top])) m_FTop = (bool)dbRec[DBAreaDicInfo.Top]; if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.Top])) m_FTop = (bool)dbRec[DBAreaDicInfo.Top];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.Top])) m_FTop = (bool)dbRec[DBAreaDicInfo.Top]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.Top]))
            m_FTop = (bool)dbRec[DBAreaDicInfo.Top];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBAreaDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBAreaDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBAreaDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBAreaDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBAreaDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBAreaDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAreaDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAreaDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAreaDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAreaDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAreaDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBAreaDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAreaDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAreaDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAreaDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAreaDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAreaDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBAreaDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAreaDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAreaDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAreaDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAreaDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAreaDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBAreaDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAreaDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAreaDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAreaDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAreaDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAreaDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBAreaDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAreaDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAreaDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAreaDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAreaDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAreaDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBAreaDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_Area
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
m_FDescricao = dbRec[DBAreaDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBAreaDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { m_FDescricao = dbRec[DBAreaDicInfo.Descricao]?.ToString() ?? string.Empty; m_FDescricao = dbRec[DBAreaDicInfo.Descricao]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FDescricao = dbRec[DBAreaDicInfo.Descricao]?.ToString() ?? string.Empty; } catch { }

#else
        m_FDescricao = dbRec[DBAreaDicInfo.Descricao]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.Top])) m_FTop = (bool)dbRec[DBAreaDicInfo.Top]; if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.Top])) m_FTop = (bool)dbRec[DBAreaDicInfo.Top];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.Top])) m_FTop = (bool)dbRec[DBAreaDicInfo.Top]; if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.Top])) m_FTop = (bool)dbRec[DBAreaDicInfo.Top];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.Top])) m_FTop = (bool)dbRec[DBAreaDicInfo.Top]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.Top]))
            m_FTop = (bool)dbRec[DBAreaDicInfo.Top];
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBAreaDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBAreaDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBAreaDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBAreaDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBAreaDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBAreaDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAreaDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAreaDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAreaDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAreaDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBAreaDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBAreaDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAreaDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAreaDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAreaDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAreaDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBAreaDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBAreaDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAreaDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAreaDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAreaDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAreaDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBAreaDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBAreaDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAreaDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAreaDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAreaDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAreaDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBAreaDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBAreaDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAreaDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAreaDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAreaDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAreaDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.Visto])) m_FVisto = (bool)dbRec[DBAreaDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBAreaDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBAreaDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}