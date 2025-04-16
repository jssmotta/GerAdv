namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBPaises
{
    public DBPaises(DataRow? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBPaisesDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBPaisesDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBPaisesDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBPaisesDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBPaisesDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBPaisesDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBPaisesDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

    public DBPaises(SqlDataReader? dbRec)
    {
        if (dbRec is null)
            return;
        if (DBNull.Value.Equals(dbRec[CampoCodigo]))
            return;
        ID = Convert.ToInt32(dbRec[CampoCodigo]);
        // Checkpoint Carregar 
        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.DtAtu]))
                m_FDtAtu = Convert.ToDateTime(dbRec[DBPaisesDicInfo.DtAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.DtCad]))
                m_FDtCad = Convert.ToDateTime(dbRec[DBPaisesDicInfo.DtCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.QuemAtu]))
                m_FQuemAtu = Convert.ToInt32(dbRec[DBPaisesDicInfo.QuemAtu]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.QuemCad]))
                m_FQuemCad = Convert.ToInt32(dbRec[DBPaisesDicInfo.QuemCad]);
        }
        catch
        {
        }

        try
        {
            if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.Visto]))
                m_FVisto = (bool)dbRec[DBPaisesDicInfo.Visto];
        }
        catch
        {
        }

        try
        {
            m_FGUID = dbRec[DBPaisesDicInfo.GUID]?.ToString() ?? string.Empty;
        }
        catch
        {
        }

        try
        {
            m_FNome = dbRec[DBPaisesDicInfo.Nome]?.ToString() ?? string.Empty;
        }
        catch
        {
        }
    }

#region CarregarDados_Paises
    protected void Carregar(int id, SqlConnection? oCnn)
    {
        if (id.IsEmptyIDNumber())
            return;
        using var cmd = new SqlCommand($"SET NOCOUNT ON; SELECT TOP (1) {CamposSqlX} FROM dbo.[Paises] (NOLOCK) WHERE [paiCodigo] = @ThisIDToLoad", oCnn);
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
m_FNome = dbRec[DBPaisesDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBPaisesDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBPaisesDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBPaisesDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBPaisesDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBPaisesDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBPaisesDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBPaisesDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBPaisesDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBPaisesDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBPaisesDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBPaisesDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPaisesDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPaisesDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPaisesDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPaisesDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPaisesDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBPaisesDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPaisesDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPaisesDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPaisesDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPaisesDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPaisesDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBPaisesDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPaisesDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPaisesDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPaisesDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPaisesDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPaisesDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBPaisesDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPaisesDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPaisesDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPaisesDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPaisesDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPaisesDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBPaisesDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPaisesDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPaisesDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPaisesDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPaisesDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPaisesDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBPaisesDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }

#endregion
#region CarregarDados_Paises
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
m_FNome = dbRec[DBPaisesDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBPaisesDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { m_FNome = dbRec[DBPaisesDicInfo.Nome]?.ToString() ?? string.Empty; m_FNome = dbRec[DBPaisesDicInfo.Nome]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FNome = dbRec[DBPaisesDicInfo.Nome]?.ToString() ?? string.Empty; } catch { }

#else
        m_FNome = dbRec[DBPaisesDicInfo.Nome]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 203
m_FGUID = dbRec[DBPaisesDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBPaisesDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { m_FGUID = dbRec[DBPaisesDicInfo.GUID]?.ToString() ?? string.Empty; m_FGUID = dbRec[DBPaisesDicInfo.GUID]?.ToString() ?? string.Empty;  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {m_FGUID = dbRec[DBPaisesDicInfo.GUID]?.ToString() ?? string.Empty; } catch { }

#else
        m_FGUID = dbRec[DBPaisesDicInfo.GUID]?.ToString() ?? string.Empty;
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPaisesDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPaisesDicInfo.QuemCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPaisesDicInfo.QuemCad]); if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPaisesDicInfo.QuemCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.QuemCad])) m_FQuemCad = Convert.ToInt32(dbRec[DBPaisesDicInfo.QuemCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.QuemCad]))
            m_FQuemCad = Convert.ToInt32(dbRec[DBPaisesDicInfo.QuemCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPaisesDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPaisesDicInfo.DtCad]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPaisesDicInfo.DtCad]); if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPaisesDicInfo.DtCad]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.DtCad])) m_FDtCad = Convert.ToDateTime(dbRec[DBPaisesDicInfo.DtCad]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.DtCad]))
            m_FDtCad = Convert.ToDateTime(dbRec[DBPaisesDicInfo.DtCad]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 3
if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPaisesDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPaisesDicInfo.QuemAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPaisesDicInfo.QuemAtu]); if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPaisesDicInfo.QuemAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.QuemAtu])) m_FQuemAtu = Convert.ToInt32(dbRec[DBPaisesDicInfo.QuemAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.QuemAtu]))
            m_FQuemAtu = Convert.ToInt32(dbRec[DBPaisesDicInfo.QuemAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 7
if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPaisesDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPaisesDicInfo.DtAtu]);  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPaisesDicInfo.DtAtu]); if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPaisesDicInfo.DtAtu]);  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.DtAtu])) m_FDtAtu = Convert.ToDateTime(dbRec[DBPaisesDicInfo.DtAtu]); } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.DtAtu]))
            m_FDtAtu = Convert.ToDateTime(dbRec[DBPaisesDicInfo.DtAtu]);
#endif
#endif
#if (NofastCodeLoadToDebug)
// region JMen - nType = 2
if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPaisesDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPaisesDicInfo.Visto];  } catch {}  try { if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPaisesDicInfo.Visto]; if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPaisesDicInfo.Visto];  } catch {}  try { 
#else
#if (fastAndSecureCode)
try {if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.Visto])) m_FVisto = (bool)dbRec[DBPaisesDicInfo.Visto]; } catch { }

#else
        if (!DBNull.Value.Equals(dbRec[DBPaisesDicInfo.Visto]))
            m_FVisto = (bool)dbRec[DBPaisesDicInfo.Visto];
#endif
#endif
    ///RELATION_READ///
    }
#endregion
}